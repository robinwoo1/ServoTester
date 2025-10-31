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
    SerialPort Port = null;
    public int ControlMode = 0;
    public bool ServoOnOff = false;
    public int ServoError = 0;
    public int Encoder = 0;
    public byte[] ComReadBuffer = new byte[128 * 16 * 8];
    public byte[] SendDataPacket = new byte[SERIAL_BUF_SIZE];
    public int ComReadIndex = 0;
    public ConcurrentQueue<byte> cq = new ConcurrentQueue<byte>();
    public bool port_working = false;

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

    public _comm(Form1 _form)
    {
      form = _form;
      Packet = _form.Packet;
      Port = _form.Port;
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
      // event 함수 설정
      Port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
    }

    public void Close()
    {
      // 닫기
      while (port_working) { Thread.Sleep(1); }
      // 통신 닫기
      Port.DiscardOutBuffer();
      Port.DiscardInBuffer();
      Port.Close();
      // event 함수 닫기
      Port.DataReceived -= new SerialDataReceivedEventHandler(DataReceivedHandler);
    }

    public void Enqueue()
    {
      if (Port.IsOpen)
      {
        try
        {
          port_working = true;
          byte[] data = Port.Encoding.GetBytes(Port.ReadExisting());
          for (int i = 0; i < data.Count(); i++)
          {
            cq.Enqueue(data[i]);
          }
          port_working = false;
        }
        finally
        {
          MessageBox.Show("Enque 에러.");
        }
      }
    }

    public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
      Enqueue();
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

    public void ProcessPcMcReceivedCommData()//ref _Parameter Mc)
    {
      byte data;
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
                  if (StartAddress == 1   // 모드설정
                    || StartAddress == 2  // Servo On/Off
                    || StartAddress == 3  // 속도 명령 RPM
                    || StartAddress == 4) // 토크 명령 %
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
                case 3: // 상태
                  if (ComReadBuffer[10] == 0)
                    ServoOnOff = false; // Off
                  else
                    ServoOnOff = true;  // On
                  if (ComReadBuffer[11] == 0)
                    ControlMode = 0;    // 속도 모드
                  else
                    ControlMode = 1;    // 토크 모드
                  ServoError = (int)(ComReadBuffer[14] << 0);
                  ServoError = (int)(ComReadBuffer[15] << 8);
                  ServoError = (int)(ComReadBuffer[16] << 16);
                  ServoError = (int)(ComReadBuffer[17] << 24);
                  
                  Encoder = (int)(ComReadBuffer[18] << 0);
                  Encoder = (int)(ComReadBuffer[19] << 8);
                  Encoder = (int)(ComReadBuffer[20] << 16);
                  Encoder = (int)(ComReadBuffer[21] << 24);
                  break;
                case 4: // graph
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
  }
}
