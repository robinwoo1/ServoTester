using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServoTester
{
  public class _Packet
  {
    Form1 form = null;
    //SerialPort Port = null;
    
    const int _LengthLow = 2;
    const int _LengthHigh = 3;
    const ushort SERIAL_BUF_SIZE = 128 * 16;
    byte[] SendDataPacket = new byte[SERIAL_BUF_SIZE];

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

    public _Packet(Form1 _form)
    {
      form = _form;
      //Port = form.Port;
    }

    public void MakeAndSendData(byte Command, ushort StartAddress, int Data)
    {
      ushort u16PtrCnt = 0;
      ushort calc_crc = 0;
      switch (Command)
      {
        case 1:
          if (StartAddress == 1 // 모드설정 1:속도, 0:토크
            || StartAddress == 2 // Servo 1:On, 0:Off
            || StartAddress == 3 // 0:속도(RPM), 1:토크(%)
            || StartAddress == 4 // 에러 클리어
            || StartAddress == 5)// Connect
          {
            MakePacket(Command, StartAddress, Data);
            u16PtrCnt = CmdAck.u16PtrCnt;
            calc_crc = GetCRC(SendDataPacket, u16PtrCnt + 2);
            SendDataPacket[u16PtrCnt++] = (byte)(calc_crc >> 0);
            SendDataPacket[u16PtrCnt++] = (byte)(calc_crc >> 8);
            SendPacket(SendDataPacket, u16PtrCnt);
          }
          else
            MessageBox.Show("Cammand 1 에러.");
          break;
        case 2://게인
          if (StartAddress == 1 // 속도 Kp
            || StartAddress == 2 // 속도 Ki
            || StartAddress == 3 // 전류 Kp
            || StartAddress == 4)// 전류 Ki
          {
            MakePacket(Command, StartAddress, Data);
            u16PtrCnt = CmdAck.u16PtrCnt;
            calc_crc = GetCRC(SendDataPacket, u16PtrCnt + 2);
            SendDataPacket[u16PtrCnt++] = (byte)(calc_crc >> 0);
            SendDataPacket[u16PtrCnt++] = (byte)(calc_crc >> 8);
            SendPacket(SendDataPacket, u16PtrCnt);
          }
          else
            MessageBox.Show("Cammand 2 에러.");
          break;
        //case 3: // 주기적인 Servo On/Off, 에러, 엔코더
        //  break;
        //case 4: // praph
        //  break;
        default:
          MessageBox.Show("Cammand 에러.");
          break;
      }
    }

    public void MakePacket(byte Command, ushort StartAddress, int Data)
    {
      ushort u16PtrCnt = 0;
      ushort Revision = 0;
      byte TryNum = 0;

      SendDataPacket[u16PtrCnt++] = (byte)0x5A;               // Start low            0
      SendDataPacket[u16PtrCnt++] = (byte)0xA5;               // Start high           1
      SendDataPacket[u16PtrCnt++] = (byte)0;                  // Length low           2
      SendDataPacket[u16PtrCnt++] = (byte)0;                  // Length high          3
      SendDataPacket[u16PtrCnt++] = Command;                  // Function code        4
      SendDataPacket[u16PtrCnt++] = (byte)(Revision >> 0);    // revision low         5
      SendDataPacket[u16PtrCnt++] = (byte)(Revision >> 8);    // revision high        6
      SendDataPacket[u16PtrCnt++] = TryNum;                   // TryNum               7
      SendDataPacket[u16PtrCnt++] = (byte)(StartAddress >> 0);// Start Address low    8
      SendDataPacket[u16PtrCnt++] = (byte)(StartAddress >> 8);// Start Address high   9

      if (Command == 1)
      {
        switch (StartAddress)
        {
          case 1:// 모드설정 0:속도, 1:토크
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 0);
            SendDataPacket[u16PtrCnt++] = (byte)0;
            SendDataPacket[u16PtrCnt++] = (byte)0;
            SendDataPacket[u16PtrCnt++] = (byte)0;
            break;
          case 2:// Servo 1:On, 0:Off
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 0);
            SendDataPacket[u16PtrCnt++] = (byte)0;
            SendDataPacket[u16PtrCnt++] = (byte)0;
            SendDataPacket[u16PtrCnt++] = (byte)0;
            break;
          case 3:// 0:속도(RPM), 1:토크(%)
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 0);
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 8);
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 16);
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 24);
            break;
          case 4:// 에러 클리어
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 0);
            SendDataPacket[u16PtrCnt++] = 0;
            SendDataPacket[u16PtrCnt++] = 0;
            SendDataPacket[u16PtrCnt++] = 0;
            break;
          case 5:// Connect
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 0);
            SendDataPacket[u16PtrCnt++] = 0;
            SendDataPacket[u16PtrCnt++] = 0;
            SendDataPacket[u16PtrCnt++] = 0;
            break;
          default:
            break;
        }
      }
      else if (Command == 2)
      {
        switch (StartAddress)
        {
          case 1:// 속도 Kp
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 0);
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 8);
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 16);
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 24);
            break;
          case 2:// 속도 Ki
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 0);
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 8);
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 16);
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 24);
            break;
          case 3:// 전류 Kp
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 0);
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 8);
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 16);
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 24);
            break;
          case 4:// 전류 Ki
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 0);
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 8);
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 16);
            SendDataPacket[u16PtrCnt++] = (byte)(Data >> 24);
            break;
          default:
            break;
        }
      }
      //else if (Command == 3)// 주기적인 servo on/off 상태, 엔코더 위치
      //else if (Command == 4)// 그래프 데이터

      ushort Length = (ushort)(u16PtrCnt - 4);
      SendDataPacket[_LengthLow] = (byte)(Length >> 0);     // Length low
      SendDataPacket[_LengthHigh] = (byte)(Length >> 8);    // Length high

      CmdAck.u8Command = Command;
      CmdAck.u16PtrCnt = u16PtrCnt;
      CmdAck.u16StartAddress = StartAddress;
      CmdAck.u8AckWait = 1;
    }

    public void ResetAckState()
    {
      CmdAck.u8Command = 0;
      CmdAck.u8AckWait = 0;
      CmdAck.u16StartAddress = 0;
      CmdAck.u16PtrCnt = 0;
    }

    // send ack code
    public void AckSend(byte command, byte Try_num, ushort StartAddress, byte code)
    {
      ushort u16PtrCnt = 0, calc_crc;
      byte[] DataPacket = new byte[20];

      DataPacket[u16PtrCnt++] = 0x5A;         // Start low
      DataPacket[u16PtrCnt++] = 0xA5;         // Start high
      DataPacket[u16PtrCnt++] = 0;            // Length low
      DataPacket[u16PtrCnt++] = 0;            // Length high
      if (code != 0)
        DataPacket[u16PtrCnt++] = (byte)(0x80 | command); // Function code
      else
        DataPacket[u16PtrCnt++] = command;    // Function code
      DataPacket[u16PtrCnt++] = 0;            // revision low, 1byte
      DataPacket[u16PtrCnt++] = 0;            // revision high, 1byte
      DataPacket[u16PtrCnt++] = Try_num;      // Try num.
      DataPacket[u16PtrCnt++] = (byte)(StartAddress);     // Start Address low
      DataPacket[u16PtrCnt++] = (byte)(StartAddress >> 8);// Start Address high
      DataPacket[u16PtrCnt++] = code;         // return ack code
      DataPacket[u16PtrCnt++] = 0;            // 
      DataPacket[u16PtrCnt++] = 0;            // reserved
      DataPacket[u16PtrCnt++] = 0;            // reserved

      ushort Length = (ushort)(u16PtrCnt - 4);
      DataPacket[_LengthLow] = (byte)(Length);      // Length low
      DataPacket[_LengthHigh] = (byte)(Length >> 8);// Length high

      calc_crc = GetCRC(DataPacket, u16PtrCnt + 2);
      DataPacket[u16PtrCnt++] = (byte)(calc_crc & 0xff);
      DataPacket[u16PtrCnt++] = (byte)((calc_crc >> 8) & 0xff);

      SendPacket(DataPacket, u16PtrCnt);
    }

    public void SendPacket(byte[] Packet, ushort Cnt)
    {
      try
      {
        if (form.Comm.Port.IsOpen && Cnt > 0)
          form.Comm.Port.Write(Packet, 0, Cnt);
      }
      finally
      {

      }
    }

    public struct CmdAck_
    {
      public byte u8Command;
      public byte u8AckWait;
      public ushort u16PtrCnt;
      public ushort u16StartAddress;
      public CmdAck_(byte Command_, ushort PtrCnt_, ushort StartAddress_)
      {
        this.u8Command = Command_;
        this.u8AckWait = 0;
        this.u16PtrCnt = PtrCnt_;
        this.u16StartAddress = StartAddress_;
      }
    }
    public CmdAck_ CmdAck = new CmdAck_(0, 0, 0);

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
  }
}
