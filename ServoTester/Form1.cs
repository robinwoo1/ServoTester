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
    public _comm Comm = null;
    public _Packet Packet = null;
    public ScottPlot.WinForms.FormsPlot Plot = null;
    public SerialPort Port { get; } = new SerialPort();
    
    

    Thread myThread = null;
    bool myThread_flag = false;
    bool myThreading = false;

    bool timer_working = false;

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
      Packet = new _Packet(this);
      Comm = new _comm(this);
      // 통신포트목록을 만든다.
      PortRefresh();
      cbBaudrate.SelectedIndex = 0;
      Plot = this.formsPlot1;
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (Port.IsOpen)
      {
        // 통신 포트 닫기
        Comm.Close();
        // timer 정지
        while (timer_working) { Thread.Sleep(1); }
        workTimer.Stop();
        myThread_flag = false;
      }
    }

    private void btCommRefresh_Click(object sender, EventArgs e)
    {
      // 통신포트목록을 만든다.
      PortRefresh();
    }

    private void PortRefresh()
    {
      // 기존 목록 지운다.
      cbCommPorts.Items.Clear();
      // 목록을 가져온다.
      var ports = SerialPort.GetPortNames().OrderBy(x => x);
      // 포트항목을 정리한다.
      foreach (var port in ports)
        // 포트항목을 추가한다.
        cbCommPorts.Items.Add(port);
      // 가능한 갯수 확인한다.
      if (cbCommPorts.Items.Count > 0)
        // 첫항목을 선택한다.
        cbCommPorts.SelectedIndex = 0;
    }

    private void btCommOpen_Click(object sender, EventArgs e)
    {
      // 통신을 개시할지 닫을지 선택한다.
      switch (Port.IsOpen)
      {
        case false when btCommOpen.Text == @"Open":
          // 포트번호와 보드레이트 정보를 가져온다.
          var port = cbCommPorts.Text;
          var baudrate = Convert.ToInt32(cbBaudrate.Text);
          // 맞게 설정되었는지 확인한다.
          if (string.IsNullOrWhiteSpace(port))
            break;
          // try catch
          try
          {
            // 통신 시작
            Comm.Open(port, baudrate);
            // timer 시작
            workTimer.Start();
            // button text 바꾸기
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
            // 닫기
            Comm.Close();
            // timer 정지
            while (timer_working) { Thread.Sleep(1); }
            workTimer.Stop();
            // button text 바꾸기
            btCommOpen.Text = @"Open";
            myThread_flag = false;
            
            cbSpeedMode.Checked = false;
            cbTorqueMode.Checked = false;
            rbServoOff.Checked = false;
            btServoOnOff.Text = "Servo On";
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

    private void myFunc()
    {
      byte data;

      while (myThread_flag)
      {
        myThreading = true;
        Comm.ProcessPcMcReceivedCommData();
        myThreading = false;
        Thread.Sleep(20);
      }
    }

    private void workTimer_Tick(object sender, EventArgs e)
    {
      if (Port.IsOpen)
      {
        if (myThreading == false)
        {
          tbServoError.Text = Comm.ServoError.ToString();
          tbEncoder.Text = Comm.Encoder.ToString();
          // 제어 모드
          switch (Comm.ControlMode)
          {
            case 0:
              cbSpeedMode.Checked = true;
              cbTorqueMode.Checked = false;
              break;
            case 1:
              cbSpeedMode.Checked = false;
              cbTorqueMode.Checked = true;
              break;
          }
          // Servo On/Off
          switch (Comm.ServoOnOff)
          {
            case false when !rbServoOff.Checked:
              rbServoOff.Checked = true;
              btServoOnOff.Text = "Servo On";
              break;
            case true when !rbServoOn.Checked:
              rbServoOn.Checked = true;
              btServoOnOff.Text = "Servo Off";
              break;
          }
        }
      }
    }

    private void Click_Command(object sender, EventArgs e)
    {
      int Command = (int)(Convert.ToInt32(tbCommand.Text));
      Packet.MakeAndSendData(1, 3, Command);
    }

    private void Click_SpeedKi(object sender, EventArgs e)
    {
      int SpeedKp = (int)(Convert.ToInt32(tbSpeedKp.Text));
      Packet.MakeAndSendData(2, 1, SpeedKp);
    }

    private void Click_SpeedKp(object sender, EventArgs e)
    {
      int SpeedKi = (int)(Convert.ToInt32(tbSpeedKi.Text));
      Packet.MakeAndSendData(2, 2, SpeedKi);
    }

    private void Click_CurrentKp(object sender, EventArgs e)
    {
      int CurrentKp = (int)(Convert.ToInt32(tbCurrentKp.Text));
      Packet.MakeAndSendData(2, 3, CurrentKp);
    }

    private void Click_CurrentKi(object sender, EventArgs e)
    {
      int CurrentKi = (int)(Convert.ToInt32(tbCurrentKi.Text));
      Packet.MakeAndSendData(2, 4, CurrentKi);
    }

  }
}
