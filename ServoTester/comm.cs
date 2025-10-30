using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Common;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServoTester
{
  public class _comm
  {
    Form1 form = null;
    _Packet Packet = null;
    public const ushort SERIAL_BUF_SIZE = 128 * 16;
    public SerialPort Port { get; } = new SerialPort();
    //SerialPort Port = null;
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
        port_working = true;
        byte[] data = Port.Encoding.GetBytes(Port.ReadExisting());
        for (int i = 0; i < data.Count(); i++)
        {
          cq.Enqueue(data[i]);
        }
        port_working = false;
      }
    }

    public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
      try
      {
        Enqueue();
      }
      finally
      {
        //Packet.Port.Close();
      }
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
                case 1:
                  if (StartAddress == 1 || StartAddress == 2)// || StartAddress == 3)
                  {
                    Packet.ResetAckState();
                  }
                  else if (StartAddress == 3)
                  {
                    Packet.ResetAckState();
                    //Packet.MakeAndSendData(1, 1, 0, ref Mc);
                  }
                  else if (StartAddress == 4)
                  {
                    Packet.AckSend(Command, 0, StartAddress, 0);       // return Ack OK
                    //Mc.Info.u16Con_Model_Type = (ushort)((ComReadBuffer[11] << 8) | ComReadBuffer[10]);
                    //Mc.Info.u16Version = (ushort)((ComReadBuffer[13] << 8) | ComReadBuffer[12]);
                  }
                  break;
                case 2:
                  if (StartAddress == 1 || StartAddress == 2 || StartAddress == 3 || StartAddress == 4 ||
                      StartAddress == 6 || StartAddress == 7 || StartAddress == 8 || StartAddress == 9 || StartAddress == 10)
                  {
                    Packet.ResetAckState();
                  }
                  else if (StartAddress == 5)
                  {
                    // this.Invoke(new Action(delegate ()
                    // {
                    //   btMcInit.Text = @"Init MC - No";
                    // }));
                  }
                  else if (StartAddress == 11)
                  {
                    Packet.AckSend(Command, 0, StartAddress, 0);       // return Ack OK
                    //Mc.Var.Mcinitialized = ComReadBuffer[11];
                    // this.Invoke(new Action(delegate ()
                    // {
                    //   if (Mc.Var.Mcinitialized != 0)
                    //   {
                    //     btMcInit.Text = @"Init MC - Yes";
                    //   }
                    //   else
                    //   {
                    //     btMcInit.Text = @"Init MC - No";
                    //   }
                    // }));
                  }
                  break;
                case 3:// Pc <- Mc, Cyclic
                  //Mc.Var.TqSensorValue = (ushort)((ComReadBuffer[13] << 8) | ComReadBuffer[12]);

                  //Mc.Var.TqSensorOffsetValue = (ushort)((ComReadBuffer[15] << 8) | ComReadBuffer[14]);
                  //Mc.DriverInfo.u16TorqueSensorOffset = Mc.Var.TqSensorOffsetValue;

                  //Mc.Var.Error = (ushort)((ComReadBuffer[29] << 8) | ComReadBuffer[28]);
                  //// tbError.Text = Error.ToString();//ui
                  //Mc.Var.IniStep = ComReadBuffer[39];
                  //Mc.Var.MaintCnt = (uint)((ComReadBuffer[51] << 24) | (ComReadBuffer[50] << 16) | (ComReadBuffer[49] << 8) | ComReadBuffer[48]);
                  //// tbMaintCnt.Text = Mc.Var.MaintCnt.ToString();//ui
                  //Mc.Var.Enc = (ushort)((ComReadBuffer[41] << 8) | ComReadBuffer[40]);
                  //// tbEnc.Text = Mc.Var.Enc.ToString();//ui

                  //Mc.Var.MotorState = ((ComReadBuffer[27] << 8) | ComReadBuffer[26]) != 0;
                  //Mc.Flag.b1Run = ComReadBuffer[26];
                  //Mc.Flag.b1ControlFL = ComReadBuffer[30];

                  //if (ComReadBuffer[42] != 0)
                  //  Mc.AutoSetting.FlagSetting = true;
                  //else
                  //  Mc.AutoSetting.FlagSetting = false;

                  //if (ComReadBuffer[43] != 0)
                  //  Mc.AutoSetting.FlagStart = true;
                  //else
                  //  Mc.AutoSetting.FlagStart = false;

                  byte b1Run = (byte)(ComReadBuffer[44] & 0x01);
                  //if (Mc.Var.FlagRun[0] != b1Run)
                  //{
                  //  //Packet.MakeAndSendData(2, 2, b1Run, ref Mc);
                  //}
                  //Mc.Var.FlagRun[2] = Mc.Var.FlagRun[1];
                  //Mc.Var.FlagRun[1] = Mc.Var.FlagRun[0];
                  //Mc.Var.FlagRun[0] = (byte)(ComReadBuffer[44] & 0x01);

                  byte b1ControlFL = (byte)(ComReadBuffer[44] & 0x02);
                  //if (Mc.Var.FlagFL[0] != b1ControlFL)
                  //{
                  //  //if (b1ControlFL != 0)
                  //  //  Packet.MakeAndSendData(2, 1, 1, ref Mc);
                  //  //else
                  //  //  Packet.MakeAndSendData(2, 1, 0, ref Mc);
                  //}
                  //Mc.Var.FlagFL[2] = Mc.Var.FlagFL[1];
                  //Mc.Var.FlagFL[1] = Mc.Var.FlagFL[0];
                  //Mc.Var.FlagFL[0] = b1ControlFL;

                  //if (ComReadBuffer[63] != 0)
                  //  Mc.Var.Mot_or_Nut = true;
                  //else
                  //  Mc.Var.Mot_or_Nut = false;

                  break;
                case 4:
                  if (StartAddress == 1)
                  {
                    Packet.AckSend(Command, 0, StartAddress, 0);       // return Ack OK
                  }
                  //Mc.Var.graph_count++;
                  //fresh_graph_data(ref Mc);
                  break;
                case 5:
                  if (StartAddress == 1)
                  {
                    Packet.AckSend(Command, 0, StartAddress, 0);       // return Ack OK
                  }
                  //Mc.AutoSetting.CurrentSpeed = (ushort)((ComReadBuffer[119] << 8) | ComReadBuffer[118]);
                  //Mc.AutoSetting.CurrentSeatingPoint = (ushort)((ComReadBuffer[121] << 8) | ComReadBuffer[120]);
                  //Mc.AutoSetting.CurrentFSpeed = (ushort)((ComReadBuffer[123] << 8) | ComReadBuffer[122]);
                  //Mc.AutoSetting.CurrentFAngle = (ushort)((ComReadBuffer[125] << 8) | ComReadBuffer[124]);
                  break;
                case 6:
                  break;
                case 7:
                  // if (StartAddress == 1)//download Driver info
                  if (StartAddress == 2)//upload Driver info
                  {
                    Packet.AckSend(Command, 0, StartAddress, 0);       // return Ack OK
                    //Mc.DriverInfo.u16Type = (ushort)((ComReadBuffer[11] << 8) | ComReadBuffer[10]);
                    //Mc.DriverInfo.u16Version = (ushort)((ComReadBuffer[13] << 8) | ComReadBuffer[12]);
                    //Mc.DriverInfo.u16Serial_low = (ushort)((ComReadBuffer[15] << 8) | ComReadBuffer[14]);
                    //Mc.DriverInfo.u16Serial_high = (ushort)((ComReadBuffer[17] << 8) | ComReadBuffer[16]);
                    //Mc.DriverInfo.u8Factory_Gear_efficiency = (ushort)((ComReadBuffer[19] << 8) | ComReadBuffer[18]);
                    //Mc.DriverInfo.u8User_Gear_efficiency = (ushort)((ComReadBuffer[21] << 8) | ComReadBuffer[20]);
                    //Mc.DriverInfo.u16DriverVendor = (ushort)((ComReadBuffer[23] << 8) | ComReadBuffer[22]);
                    //Mc.Var.DriverInfoIsReady = true;
                    //if (Mc.Var.IniStep != 11)
                    //  Packet.MakeAndSendData(1, 3, 0, ref Mc);
                  }
                  else if (StartAddress == 3)//Speaker On/Off
                  { }
                  else if (StartAddress == 4)//Led band
                  { }
                  // else if (StartAddress == 5)//Reserved
                  // else if (StartAddress == 6)//Reserved
                  else if (StartAddress == 7)// Get Torque Offset
                  {
                    d.b0 = ComReadBuffer[12];
                    d.b0 = ComReadBuffer[13];
                    d.b0 = ComReadBuffer[14];
                    d.b0 = ComReadBuffer[15];
                    //Mc.DriverInfo.f32TorqueOffset = d.f;
                    //Mc.Var.DriverInfo_TorqueOffsetIsReady = true;
                  }
                  else if (StartAddress == 8)//reset maintenance
                  { }
                  // else if (StartAddress == 9)//Reserved
                  else if (StartAddress == 10)//Check Torque offset value
                  { }
                  else if (StartAddress == 11)//Save Torque offset value
                  { }
                  else if (StartAddress == 12)//Start/Stop Initail Angle
                  { }
                  else if (StartAddress == 13)// receive initial angle result Pc <- Mc
                  {
                    //Mc.Var.CalibResultState = (int)((ComReadBuffer[11] << 11) | ComReadBuffer[10]);
                    Packet.AckSend(Command, 0, StartAddress, 0);       // return Ack OK
                  }
                  // else if (StartAddress == 13)// Pc -> Mc
                  else if (StartAddress == 101)// Pc <- Mc
                  {
                    int CalibStepState1 = (int)((ComReadBuffer[11] << 8) | ComReadBuffer[10]);
                    //if (CalibStepState1 == 0)
                    //  Mc.Var.CalibStepState = 0;
                    //else if (CalibStepState1 == 1)
                    //  Mc.Var.CalibStepState = 1;
                    //else if (CalibStepState1 == 2 || CalibStepState1 == 3)
                    //  Mc.Var.CalibStepState = 2;
                    //else if (CalibStepState1 == 4 || CalibStepState1 == 5)
                    //  Mc.Var.CalibStepState = 3;
                    //else
                    //  Mc.Var.CalibStepState = 4;
                    Packet.AckSend(Command, Try_num, StartAddress, 0);       // return Ack OK
                  }
                  break;
                case 104:
                  // get value
                  // Mc.Var.MotorState = ((ComReadBuffer[3] << 8) | ComReadBuffer[4]) != 0;
                  if (StartAddress == 1)// Pc -> Mc
                  {

                  }
                  else if (StartAddress == 2)// Pc <- Mc
                  {
                    //Mc.Var.MotorState = ((ComReadBuffer[11] << 8) | ComReadBuffer[10]) != 0;
                    // Mc.Var.CalibStepState = ((ComReadBuffer[11] << 8) | ComReadBuffer[10]);
                    // Mc.Var.CalibResultState = ((ComReadBuffer[11] << 8) | ComReadBuffer[10]);
                  }
                  break;
                case 106:
                  break;
                default:
                  break;
              }
            }
            else
            {
              // AckSend(Command, Try_num, StartAddress, 2);       // return check CRC error
            }
          }
        }
        else if (((ComReadIndex > 0) && (ComReadBuffer[0] != 0x5A))  // packet 에러 검사
            || ((ComReadIndex > 1) && (ComReadBuffer[1] != 0xA5)))  // packet 에러 검사
        {
          ComReadIndex = 0;// no return Ack
        }
      }
    }
  }
}
