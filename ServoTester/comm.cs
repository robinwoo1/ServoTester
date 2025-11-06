using OpenTK.Graphics.OpenGL;
using ScottPlot.Colormaps;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServoTester
{
  public class _comm
  {
    Form1 form = null;
    _Packet Packet = null;
    public const ushort SERIAL_BUF_SIZE = 128 * 16;
    public SerialPort Port { get; } = new SerialPort();
    public int ControlMode = 0;
    public bool ServoOnOff = false;
    public int ServoError = 0;
    public int Encoder = 0;
    public byte[] ComReadBuffer = new byte[128 * 16 * 8];
    public byte[] SendDataPacket = new byte[SERIAL_BUF_SIZE];
    public int ComReadIndex = 0;
    public ConcurrentQueue<byte> cq = new ConcurrentQueue<byte>();
    public bool port_working = false;
    public bool GraphUpdate = false;
    public int ReadIndex = 0;

    public List<double> Data_ch1 = new List<double>();
    public List<double> Data_ch2 = new List<double>();
    public List<double> Data_ch3 = new List<double>();
    public List<double> Data_ch4 = new List<double>();

    public List<double> Graph_ch1 = new List<double>();
    public List<double> Graph_ch2 = new List<double>();
    public List<double> Graph_ch3 = new List<double>();
    public List<double> Graph_ch4 = new List<double>();

    [StructLayout(LayoutKind.Explicit)]
    struct TestUnion
    {
      [FieldOffset(0)] public float f;
      [FieldOffset(0)] public int i;
      [FieldOffset(0)] public uint u;
      [FieldOffset(0)] public ushort us0;
      [FieldOffset(2)] public ushort us1;
      [FieldOffset(0)] public short s0;
      [FieldOffset(2)] public short s1;
      [FieldOffset(0)] public byte b0;
      [FieldOffset(1)] public byte b1;
      [FieldOffset(2)] public byte b2;
      [FieldOffset(3)] public byte b3;
    }
    TestUnion d = new TestUnion();

    public struct _RingBuf
    {
      public uint tail;       // read data pointer
      public uint head;       // write data pointer
      public uint old_pos;
      public byte[] data; // receive buffer
      public _RingBuf(int a)
      {
        this.tail = 0;
        this.head = 0;
        this.old_pos = 0;
        this.data = new byte[SERIAL_BUF_SIZE];
      }
    }
    public _RingBuf RingBuf;

    public _comm(Form1 _form)
    {
      form = _form;
      Packet = _form.Packet;
      this.RingBuf = new _RingBuf(0);
      //Port = _form.Port;
    }

    public void Open(string port,int baudrate)
    {
      ComReadIndex = 0;
      // port와 baudrate 설정
      Port.PortName = port;
      Port.BaudRate = baudrate;
      Port.Encoding = Encoding.GetEncoding(28591);
      // 통신 시작
      Port.Open();
      //clear_data();
    }

    public void Close()
    {
      // 닫기
      while (port_working) { Thread.Sleep(1); }
      // 통신 닫기
      Port.DiscardOutBuffer();
      Port.DiscardInBuffer();
      Port.Close();
    }

    public ushort GetCRC(byte[] data, int Length)
    {
      int i, j;
      ushort CRCFull = 0xFFFF;
      byte CRCLSB;
      for (i = 0; i < Length - 2; i++)
      {
        CRCFull = (ushort)(CRCFull ^ data[i]);
        for (j = 0; j < 8; j++)
        {
          CRCLSB = (byte)(CRCFull & 0x0001);
          CRCFull = (ushort)((CRCFull >> 1) & 0x7FFF);
          if (CRCLSB == 1)
            CRCFull = (ushort)(CRCFull ^ 0xA001);
        }
      }
      return CRCFull;
    }

    public void clear_data()
    {
      Data_ch1.Clear();
      Data_ch2.Clear();
      Data_ch3.Clear();
      Data_ch4.Clear();

      Graph_ch1.Clear();
      Graph_ch2.Clear();
      Graph_ch3.Clear();
      Graph_ch4.Clear();
    }

    public void ProcessPcMcReceivedCommData()//ref _Parameter Mc)
    {
      byte data;
      bool err;
      TestUnion d = new TestUnion();
      while (cq.Count > 0)
      {
        cq.TryDequeue(out data);

        ComReadBuffer[ComReadIndex++] = data;
        // 패킷 분석 시작
        if ((ComReadBuffer[0] == 0x5A) && (ComReadBuffer[1] == 0xA5) && (ComReadIndex >= 4))
        {
          // 받은 패킷의 data수를 가져온다.
          var data_length = (ComReadBuffer[3] << 8) | ComReadBuffer[2];
          if (data_length > 900 || ComReadIndex > 900)
          {
            ComReadIndex = 0;
            continue;
          }
          // 데이터수만큼 데이터를 받았는지 확인한다.
          if (ComReadIndex == (data_length + 6))
          {
            byte check_Command = ComReadBuffer[4];
            byte Command = (byte)(check_Command & 0x7f);
            byte Try_num = ComReadBuffer[7];
            ushort StartAddress = (ushort)((ComReadBuffer[9] << 8) | (ushort)ComReadBuffer[8]);
            ushort received_crc = (ushort)(ComReadBuffer[ComReadIndex - 2] & 0xff);
            received_crc |= (ushort)(ComReadBuffer[ComReadIndex - 1] << 8);
            ushort calc_crc = GetCRC(ComReadBuffer, ComReadIndex);
            ComReadIndex = 0;
            if (calc_crc == received_crc)
            {
              // check command
              switch (Command)
              {
                case 1: // 명령
                  if (StartAddress == 1   // 모드설정 1:속도, 0:토크
                    || StartAddress == 2  // Servo 1:On, 0:Off
                    || StartAddress == 3  // 속도 명령 RPM / 토크 명령 %
                    || StartAddress == 4  // 에러 Clear
                    || StartAddress == 5  // connect
                    || StartAddress == 6) // 1:Start, 0:Stop
                  {
                    Packet.ResetAckState();
                  }
                  else
                  {
                    MessageBox.Show("Cammand 1 에러.");
                  } 
                  break;
                case 2: // 게인
                  if (StartAddress == 1   // 속도 Kp
                    || StartAddress == 2  // 속도 Ki
                    || StartAddress == 3  // 전류 Kp
                    || StartAddress == 4) // 전류 Ki
                  {
                    Packet.ResetAckState();
                  }
                  else
                  {
                    MessageBox.Show("Cammand 2 에러.");
                  }
                  break;
                case 3: // 일정 시간마다 상태 업데이트
                  if (ComReadBuffer[10] == 0)
                    ServoOnOff = false; // Off
                  else
                    ServoOnOff = true;  // On
                  if (ComReadBuffer[11] == 0)
                    ControlMode = 0;    // 속도 모드
                  else
                    ControlMode = 1;    // 토크 모드
                  ServoError = (int)(ComReadBuffer[12] << 0);
                  ServoError |= (int)(ComReadBuffer[13] << 8);
                  ServoError |= (int)(ComReadBuffer[14] << 16);
                  ServoError |= (int)(ComReadBuffer[15] << 24);
                  
                  Encoder = (int)(ComReadBuffer[16] << 0);
                  Encoder |= (int)(ComReadBuffer[17] << 8);
                  Encoder |= (int)(ComReadBuffer[18] << 16);
                  Encoder |= (int)(ComReadBuffer[19] << 24);
                  //Packet.AckSend(Command, Try_num, StartAddress, 0);
                  break;
                case 4: // graph
                  d.b0 = ComReadBuffer[10 + 0];
                  d.b1 = ComReadBuffer[10 + 1];
                  d.b2 = ComReadBuffer[10 + 2];
                  d.b3 = ComReadBuffer[10 + 3];
                  float current_gain = d.f;
                  
                  d.b0 = ComReadBuffer[14 + 0];
                  d.b1 = ComReadBuffer[15 + 1];
                  d.b2 = ComReadBuffer[16 + 2];
                  d.b3 = ComReadBuffer[17 + 3];
                  float speed_gain = d.f;

                  d.b0 = ComReadBuffer[18];
                  d.b1 = ComReadBuffer[19];
                  ushort Graph_Data_Length = d.us0;
                  if (Graph_Data_Length > 0 )
                  {
                    for (ushort j = 0; j < Graph_Data_Length; j++)
                    {
                      d.b0 = ComReadBuffer[100 * 0 + 20 + j * 2 + 0];
                      d.b1 = ComReadBuffer[100 * 0 + 20 + j * 2 + 1];
                      Data_ch1.Add(d.s0 * speed_gain);// Command Speed
                      d.b0 = ComReadBuffer[100 * 1 + 20 + j * 2 + 0];
                      d.b1 = ComReadBuffer[100 * 1 + 30 + j * 2 + 1];
                      Data_ch2.Add(d.s0 * current_gain);//Command current
                      d.b0 = ComReadBuffer[100 * 2 + 20 + j * 2 + 0];
                      d.b1 = ComReadBuffer[100 * 2 + 20 + j * 2 + 1];
                      Data_ch3.Add(d.s0 * speed_gain); //Feed Speed
                      d.b0 = ComReadBuffer[100 * 3 + 20 + j * 2 + 0];
                      d.b1 = ComReadBuffer[100 * 3 + 20 + j * 2 + 1];
                      Data_ch4.Add(d.s0 * current_gain); //Feed Current
                    }
                    Graph_ch1.AddRange(Data_ch1);
                    Graph_ch2.AddRange(Data_ch2);
                    Graph_ch3.AddRange(Data_ch3);
                    Graph_ch4.AddRange(Data_ch4);
                    GraphUpdate = true;
                  }
                  
                  Packet.AckSend(Command, Try_num, StartAddress, 0);
                  break;
                default:
                  MessageBox.Show("알 수 없는 Cammand 에러.");
                  break;
              }
            }
            else
            {
              MessageBox.Show("CRC 에러.");
            }
          }
        }
        else if (((ComReadIndex > 0) && (ComReadBuffer[0] != 0x5A)) // packet 에러 검사
            || ((ComReadIndex > 1) && (ComReadBuffer[1] != 0xA5)))  // packet 에러 검사
        {
          ComReadIndex = 0;// no return Ack
          MessageBox.Show("Packet 에러.");
        }
      }
    }

    public bool rb_put(byte d)
    {
      uint nhead = (RingBuf.head + 1) & (SERIAL_BUF_SIZE - 1);    // buffer size는 2n으로 
      if (RingBuf.tail == nhead)
      {
        return false;
      }
      RingBuf.data[RingBuf.head] = d;
      RingBuf.head = nhead;
      return true;
    }

    public byte rb_get() // pop -> send Ethernet
    {
      byte d;
      uint ntail = (RingBuf.tail + 1) & (SERIAL_BUF_SIZE - 1);
      
      if (RingBuf.head == RingBuf.tail)
      {
        return 0;       // buffer non-write -> empty
      }
      d = RingBuf.data[RingBuf.tail];
      RingBuf.tail = ntail;
      return d;       // buffer read
    }

  }
}
