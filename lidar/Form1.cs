using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;

namespace lidar
{
    public partial class Form1 : Form
    {
        System.Timers.Timer aTimer = new System.Timers.Timer();
        private SerialPort ComDevice = new SerialPort();
        string iniFilePath = "./Set.ini";
        string portName = "COM3";
        int buffer_index = 0;
        int frame_length = 0;
        float[] distance = new float[576];
        int frame_data_length = 0;
        int frame_data_index = 0;
        int frame_type = 0;
        int frame_protocol_sw = 0;
        int frame_cmd_type = 0;
        int frame_crc = 0;
        byte[] frame_buffer = new byte[256 + 20];
        float RotateSpeed = 0.0f;
        float startangle = 0.0f;
        float stopangle = 0.0f;
        float detdistance1= 0.0f;
        float detdistance2 = 0.0f;
        float detdistance3 = 0.0f;

        public Form1()
        {
            InitializeComponent();

            System.Windows.Forms.ContainerControl.CheckForIllegalCrossThreadCalls = false;

            InitialConfig();
        }

        private void InitialConfig()
        {
            if (File.Exists(iniFilePath))
            {
                portName = IniFiles.ReadIniData("Port", "端口号", "", iniFilePath);
                textBox_startangle.Text = IniFiles.ReadIniData("Lidar", "开始角度", "", iniFilePath);
                float.TryParse(IniFiles.ReadIniData("Lidar", "开始角度", "", iniFilePath), out startangle);
                textBox_stopangle.Text = IniFiles.ReadIniData("Lidar", "停止角度", "", iniFilePath);
                float.TryParse(IniFiles.ReadIniData("Lidar", "停止角度", "", iniFilePath), out stopangle);
                textBox_distance1.Text = IniFiles.ReadIniData("Lidar", "侦测距离1", "", iniFilePath);
                float.TryParse(IniFiles.ReadIniData("Lidar", "侦测距离1", "", iniFilePath), out detdistance1);
                textBox_distance2.Text = IniFiles.ReadIniData("Lidar", "侦测距离2", "", iniFilePath);
                float.TryParse(IniFiles.ReadIniData("Lidar", "侦测距离2", "", iniFilePath), out detdistance2);
                textBox_distance3.Text = IniFiles.ReadIniData("Lidar", "侦测距离3", "", iniFilePath);
                float.TryParse(IniFiles.ReadIniData("Lidar", "侦测距离3", "", iniFilePath), out detdistance3);
                Console.WriteLine(portName);

                ComDevice.PortName = portName;
                ComDevice.BaudRate = 230400;
                ComDevice.Parity = Parity.None;
                ComDevice.DataBits = 8;
                ComDevice.StopBits = StopBits.One;
                try
                {
                    ComDevice.Open();
                }
                catch (Exception ex)
                {
                    workstatus.Text = "请检查配置参数，并重新打开！";
                    MessageBox.Show(ex.Message, "请检查配置参数，并重新打开", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);
                workstatus.Text = "正在运行！";

                aTimer.Elapsed += new System.Timers.ElapsedEventHandler(TimerHanlder);
                aTimer.Interval = 300;
                aTimer.AutoReset = true;
                aTimer.Enabled = true;
            }
            else
            {
                workstatus.Text = "无配置文件，已创建配置文件，请配置参数并重新打开！";
                IniFiles.WriteIniData("Port", "端口号", "COM3", iniFilePath);
                IniFiles.WriteIniData("Lidar", "开始角度", "270", iniFilePath);
                IniFiles.WriteIniData("Lidar", "停止角度", "90", iniFilePath);
                IniFiles.WriteIniData("Lidar", "侦测距离1", "3000", iniFilePath);
                IniFiles.WriteIniData("Lidar", "侦测距离2", "2000", iniFilePath);
                IniFiles.WriteIniData("Lidar", "侦测距离3", "3000", iniFilePath);
            }

        }
        private void TimerHanlder(object source, System.Timers.ElapsedEventArgs e)
        {
            int startindex = (int)(startangle * 100.0f) / 2250 * 36;
            int stopindex = (int)(stopangle * 100.0f) / 2250 * 36;
            int tmp = (stopindex - startindex) / 3;
            int i = 0;
            int point1 = 0, point2 = 0, point3 = 0;

            if (startindex < stopindex)
            {
                tmp = (stopindex - startindex) / 3;
            }
            else
            {
                tmp = (576 + stopindex - startindex) / 3;
            }
            
            label_lidarstatus.Text = "雷达转速:" + RotateSpeed + "R/s";

            //侦测计算 顺时针方向
            if (startindex < stopindex)
            {
                for (i = startindex; i < startindex + tmp; i++)
                {
                    if (distance[i] < detdistance1)
                    {
                        point1 = 1;
                        break;
                    }
                }

                if (i == startindex + tmp)
                {
                    point1 = 0;
                }

                for (i = startindex + tmp; i < startindex + tmp + tmp; i++)
                {
                    if (distance[i] < detdistance2)
                    {
                        point2 = 1;
                        break;
                    }
                }

                if (i == startindex + tmp + tmp)
                {
                    point2 = 0;
                }

                for (i = startindex + tmp + tmp; i < stopindex; i++)
                {
                    if (distance[i] < detdistance3)
                    {
                        point3 = 1;
                        break;
                    }
                }

                if (i == stopindex)
                {
                    point3 = 0;
                }
            } 
            else
            {
                //第一段
                for (i = startindex; i < startindex + tmp; i++)
                {
                    if (i < distance.Length)
                    {
                        if (distance[i] < detdistance1 && distance[i] != 0)
                        {
                            point1 = 1;
                            break;
                        }
                    }
                    else
                    {
                        if (distance[i - distance.Length] < detdistance1 && distance[i - distance.Length] !=0)
                        {
                            point1 = 1;
                            break;
                        }
                    }
                }

                if (i == startindex + tmp)
                {
                    point1 = 0;
                }

                for (i = startindex + tmp; i < startindex + tmp + tmp; i++)
                {
                    if (i < distance.Length)
                    {
                        if (distance[i] < detdistance2 && distance[i] != 0)
                        {
                            point2 = 1;
                            break;
                        }
                    }
                    else
                    {
                        if (distance[i - distance.Length] < detdistance2 && distance[i - distance.Length] != 0)
                        {
                            point2 = 1;
                            break;
                        }
                    }
                }

                if (i == startindex + tmp + tmp)
                {
                    point2 = 0;
                }

                for (i = startindex + tmp + tmp; i < startindex + tmp + tmp + tmp; i++)
                {
                    if (i < distance.Length)
                    {
                        if (distance[i] < detdistance3 && distance[i] != 0)
                        {
                            point3 = 1;
                            break;
                        }
                    }
                    else
                    {
                        if (distance[i - distance.Length] < detdistance3 && distance[i - distance.Length] != 0)
                        {
                            point3 = 1;
                            break;
                        }
                    }
                }

                if (i == startindex + tmp + tmp + tmp)
                {
                    point3 = 0;
                }
            }

            if (point1 == 1)
            {
                label_point1.ForeColor = System.Drawing.Color.Red;
                SendKeys.SendWait("{1}");
            } 
            else
            {
                label_point1.ForeColor = System.Drawing.Color.Black;
            }

            if (point2 == 1)
            {
                label_point2.ForeColor = System.Drawing.Color.Red;
                SendKeys.SendWait("{2}");
            }
            else
            {
                label_point2.ForeColor = System.Drawing.Color.Black;
            }

            if (point3 == 1)
            {
                label_point3.ForeColor = System.Drawing.Color.Red;
                SendKeys.SendWait("{3}");
            }
            else
            {
                label_point3.ForeColor = System.Drawing.Color.Black;
            }

        }

        private UInt16 checksum(byte[] buffer, int length)
        {
            UInt16 checksum = 0;
            int i = 0;

            for (i = 0; i < length; i++)
            {
                checksum += buffer[i];
            }

            return checksum;
        }

        private void analysismeasureinfo(byte[] buffer, int length)
        {
            int i = 0;
            int ParamLen = buffer[1] * 256 + buffer[2];
            int FramePointNum = (buffer[6] * 256 + buffer[7] - 5) / 3;
            RotateSpeed = buffer[8] * 0.05f;
            float ZeroOffset = (buffer[9] * 256 + buffer[10]) * 0.01f;
            int FrameStartAngle = (buffer[11] * 256 + buffer[12]);
            int startindex = FrameStartAngle / 2250 * 36;

            //Console.WriteLine("rpm " + RotateSpeed.ToString() + " Start Angle " + FrameStartAngle.ToString() + " PointNum " + FramePointNum);

            for (i = 0; i < FramePointNum; i++)
            {
                distance[startindex + i] = (buffer[13 + 1 + i * 3] * 256 + buffer[13 + 1 + i * 3 + 1]) * 0.25f;
            }
        }

        private void analysismessage(byte[] buffer, int length)
        {
            int CmdType = buffer[4];
            int CmdId = buffer[5];

            if (CmdType != 0x61)
            {
                return;
            }

            switch (CmdId)
            {
                case 0xAD:
                    analysismeasureinfo(buffer, length);
                    break;
                case 0xAE:
                    break;
            }
        }

        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int i = 0;
            byte[] ReadDatabuf = new byte[ComDevice.BytesToRead];
            ComDevice.Read(ReadDatabuf, 0, ReadDatabuf.Length);
            for (i = 0; i < ReadDatabuf.Length; i++)
            {
                if(frame_data_index >= frame_buffer.Length)
                {
                    buffer_index = 0;
                    frame_data_index = 0;
                }
                switch (buffer_index)
                {
                    case 0:
                        //frame head
                        if (ReadDatabuf[i] == 0xAA)
                        {
                            frame_buffer[frame_data_index] = ReadDatabuf[i];
                            frame_data_index++;
                            buffer_index = 1;
                        }
                        break;
                    case 1:
                        //frame length high
                        frame_buffer[frame_data_index] = ReadDatabuf[i];
                        frame_data_index++;
                        frame_length = ReadDatabuf[i] * 256;
                        buffer_index = 2;
                        break;
                    case 2:
                        //frame lenght low
                        frame_buffer[frame_data_index] = ReadDatabuf[i];
                        frame_data_index++;
                        frame_length += ReadDatabuf[i];
                        buffer_index = 3;
                        break;
                    case 3:
                        //protocol version
                        frame_buffer[frame_data_index] = ReadDatabuf[i];
                        frame_data_index++;
                        frame_protocol_sw = ReadDatabuf[i];
                        buffer_index = 4;
                        break;
                    case 4:
                        //frame type
                        frame_buffer[frame_data_index] = ReadDatabuf[i];
                        frame_data_index++;
                        frame_type = ReadDatabuf[i];
                        buffer_index = 5;
                        break;
                    case 5:
                        //frame cmd type
                        frame_buffer[frame_data_index] = ReadDatabuf[i];
                        frame_data_index++;
                        frame_cmd_type = ReadDatabuf[i];
                        buffer_index = 6;
                        break;
                    case 6:
                        //data length high
                        frame_buffer[frame_data_index] = ReadDatabuf[i];
                        frame_data_index++;
                        frame_data_length = ReadDatabuf[i] * 256;
                        buffer_index = 7;
                        break;
                    case 7:
                        //data length low
                        frame_buffer[frame_data_index] = ReadDatabuf[i];
                        frame_data_index++;
                        frame_data_length += ReadDatabuf[i];
                        buffer_index = 8;
                        break;
                    case 8:
                        //receive data
                        frame_buffer[frame_data_index] = ReadDatabuf[i];
                        frame_data_index++;
                        if(frame_data_index >= frame_length)
                        {
                            buffer_index = 9;
                        }
                        break;
                    case 9:
                        //crc high
                        frame_crc = ReadDatabuf[i] * 256;
                        buffer_index = 10;
                        break;
                    case 10:
                        frame_crc += ReadDatabuf[i];
                        int crc = checksum(frame_buffer, frame_length);
                        if (frame_crc == crc)
                        {
                            //Console.WriteLine("校验成功");
                            analysismessage(frame_buffer, frame_length);
                        }
                        buffer_index = 0;
                        frame_data_index = 0;
                        break;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IniFiles.WriteIniData("Lidar", "开始角度", textBox_startangle.Text, iniFilePath);
            float.TryParse(textBox_startangle.Text, out startangle);
            IniFiles.WriteIniData("Lidar", "停止角度", textBox_stopangle.Text, iniFilePath);
            float.TryParse(textBox_stopangle.Text, out stopangle);
            IniFiles.WriteIniData("Lidar", "侦测距离1", textBox_distance1.Text, iniFilePath);
            float.TryParse(textBox_distance1.Text, out detdistance1);
            IniFiles.WriteIniData("Lidar", "侦测距离2", textBox_distance2.Text, iniFilePath);
            float.TryParse(textBox_distance2.Text, out detdistance2);
            IniFiles.WriteIniData("Lidar", "侦测距离3", textBox_distance3.Text, iniFilePath);
            float.TryParse(textBox_distance3.Text, out detdistance3);
        }
    }
    public class IniFiles
    {
        #region API函数声明

        [DllImport("kernel32")]//返回0表示失败，非0为成功
        private static extern long WritePrivateProfileString(string section, string key,
            string val, string filePath);

        [DllImport("kernel32")]//返回取得字符串缓冲区的长度
        private static extern long GetPrivateProfileString(string section, string key,
            string def, StringBuilder retVal, int size, string filePath);


        #endregion

        #region 读Ini文件

        public static string ReadIniData(string Section, string Key, string NoText, string iniFilePath)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(Section, Key, NoText, temp, 1024, iniFilePath);
            return temp.ToString();
        }

        #endregion

        #region 写Ini文件

        public static bool WriteIniData(string Section, string Key, string Value, string iniFilePath)
        {
            long OpStation = WritePrivateProfileString(Section, Key, Value, iniFilePath);
            if (OpStation == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion
    }
}
