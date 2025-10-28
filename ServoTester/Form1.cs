using ScottPlot;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServoTester
{
  public partial class Form1 : Form
  {
    //_Packet Packet = new _Packet();

    public const ushort SERIAL_BUF_SIZE = 128 * 16;
    Thread myThread = null;
    public bool myThread_flag = false;
    //SerialPort serialPort;
    SerialPort Port { get; } = new SerialPort();
    public byte[] ComReadBuffer = new byte[128 * 16 * 8];
    public byte[] SendDataPacket = new byte[SERIAL_BUF_SIZE];
    public int ComReadIndex = 0;
    public ConcurrentQueue<byte> cq = new ConcurrentQueue<byte>();

    bool timer_working = false;
    private bool port_working = false;

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
    
    public Form1()
    {
      InitializeComponent();
      // refresh port
      PortRefresh();
      cbBaudrate.SelectedIndex = 0;
    }
    private void btCommRefresh_Click(object sender, EventArgs e)
    {
      //Refresh
      PortRefresh();
    }
    private void PortRefresh()
    {
      // clear
      cbCommPorts.Items.Clear();
      // get port list
      var ports = SerialPort.GetPortNames().OrderBy(x => x);
      // check ports
      foreach (var port in ports)
        // add port
        cbCommPorts.Items.Add(port);
      // check item count
      if (cbCommPorts.Items.Count > 0)
        // select first
        cbCommPorts.SelectedIndex = 0;
    }
    private void btCommOpen_Click(object sender, EventArgs e)
    {
      // check port
      switch (Port.IsOpen)
      {
        case false when btCommOpen.Text == @"Open":
          // get port and baudrate
          var port = cbCommPorts.Text;
          var baudrate = Convert.ToInt32(cbBaudrate.Text);
          // check port
          if (string.IsNullOrWhiteSpace(port))
            break;
          // try catch
          try
          {
            ComReadIndex = 0;
            // set port
            Port.PortName = port;
            Port.BaudRate = baudrate;
            Port.Encoding = Encoding.GetEncoding(28591);
            // open
            Port.Open();
            // set event
            Port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            // start timer
            workTimer.Start();
            // change button text
            btCommOpen.Text = @"Close";

            myThread_flag = true;
            myThread = new Thread(myFunc);
            myThread.Start();
          }
          catch (Exception ex)
          {
            // debug
            Debug.WriteLine(ex.Message);
            // error
            MessageBox.Show($@"{port} isn't enable to open.");
          }
          break;
        case true when btCommOpen.Text == @"Close":
          // try catch
          try
          {
            // close
            while (port_working) { }
            //clear Port
            Port.DiscardOutBuffer();
            Port.DiscardInBuffer();
            Port.Close();
            // stop timer
            while (timer_working) { }
            workTimer.Stop();
            // change button text
            btCommOpen.Text = @"Open";
            Port.DataReceived -= new SerialDataReceivedEventHandler(DataReceivedHandler);

            myThread_flag = false;
          }
          catch (Exception ex)
          {
            // debug
            Debug.WriteLine(ex.Message);
            // error
            MessageBox.Show(@"Port closing error.");
          }
          break;
        default:
          break;
      }
    }
    private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
      try
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
      finally
      {
        //Packet.Port.Close();
      }
    }
    private void myFunc()
    {
      byte data;

      while (myThread_flag)
      {
        //Packet.ProcessPcMcReceivedCommData(ref Mc);
        Thread.Sleep(10);
      }
    }
  }
}
