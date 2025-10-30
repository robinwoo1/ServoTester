using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ServoTester
{
  public class _Packet
  {
    Form1 form = null;
    SerialPort Port = null;
    public const int _LengthLow = 2;
    public const int _LengthHigh = 3;

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
      Port = form.Comm.Port;
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

      DataPacket[u16PtrCnt++] = 0x5A;    // Start low
      DataPacket[u16PtrCnt++] = 0xA5;     // Start high
      DataPacket[u16PtrCnt++] = 0;              // Length low
      DataPacket[u16PtrCnt++] = 0;            // Length high
      if (code != 0)
        DataPacket[u16PtrCnt++] = (byte)(0x80 | command);         // Function code
      else
        DataPacket[u16PtrCnt++] = command;        // Function code
      DataPacket[u16PtrCnt++] = 0;            // revision low, 1byte
      DataPacket[u16PtrCnt++] = 0;            // revision high, 1byte
      DataPacket[u16PtrCnt++] = Try_num; // u8LcdMcComReadBuffer[7];		  // Try num.
      DataPacket[u16PtrCnt++] = (byte)(StartAddress);     // Start Address low
      DataPacket[u16PtrCnt++] = (byte)(StartAddress >> 8);      // Start Address high
      DataPacket[u16PtrCnt++] = code;     // return ack code
      DataPacket[u16PtrCnt++] = 0;            // 
      DataPacket[u16PtrCnt++] = 0;            // reserved
      DataPacket[u16PtrCnt++] = 0;            // reserved

      ushort Length = (ushort)(u16PtrCnt - 4);
      DataPacket[_LengthLow] = (byte)(Length);      // Length low
      DataPacket[_LengthHigh] = (byte)(Length >> 8);    // Length high

      calc_crc = GetCRC(DataPacket, u16PtrCnt + 2);
      DataPacket[u16PtrCnt++] = (byte)(calc_crc & 0xff);
      DataPacket[u16PtrCnt++] = (byte)((calc_crc >> 8) & 0xff);

      // SerialPuts_Pc((uint16_t)u16PtrCnt, (uint8_t*)DataPacket);
      SendPacket(DataPacket, u16PtrCnt);
    }

    public void SendPacket(byte[] Packet, ushort Cnt)
    {
      try
      {
        if (Port.IsOpen && Cnt > 0)
          Port.Write(Packet, 0, Cnt);
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
