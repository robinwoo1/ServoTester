namespace ServoTester
{
  partial class Form1
  {
    /// <summary>
    /// 필수 디자이너 변수입니다.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// 사용 중인 모든 리소스를 정리합니다.
    /// </summary>
    /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form 디자이너에서 생성한 코드

    /// <summary>
    /// 디자이너 지원에 필요한 메서드입니다. 
    /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.formsPlot1 = new ScottPlot.WinForms.FormsPlot();
      this.cbCommPorts = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btCommRefresh = new System.Windows.Forms.Button();
      this.btCommOpen = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.cbBaudrate = new System.Windows.Forms.ComboBox();
      this.workTimer = new System.Windows.Forms.Timer(this.components);
      this.cbGraphCommandSpeed = new System.Windows.Forms.CheckBox();
      this.cbGraphCommandCurrent = new System.Windows.Forms.CheckBox();
      this.cbGraphFeedSpeed = new System.Windows.Forms.CheckBox();
      this.cbGraphFeedCurrent = new System.Windows.Forms.CheckBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.rbTorqueMode = new System.Windows.Forms.RadioButton();
      this.btSpeedTorque = new System.Windows.Forms.Button();
      this.rbSpeedMode = new System.Windows.Forms.RadioButton();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.btCurrentKiSet = new System.Windows.Forms.Button();
      this.btCurrentKpSet = new System.Windows.Forms.Button();
      this.btSpeedKiSet = new System.Windows.Forms.Button();
      this.btSpeedKpSet = new System.Windows.Forms.Button();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.tbCurrentKi = new System.Windows.Forms.TextBox();
      this.tbCurrentKp = new System.Windows.Forms.TextBox();
      this.tbSpeedKi = new System.Windows.Forms.TextBox();
      this.tbSpeedKp = new System.Windows.Forms.TextBox();
      this.tbServoError = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.btServoOnOff = new System.Windows.Forms.Button();
      this.label9 = new System.Windows.Forms.Label();
      this.tbCommand = new System.Windows.Forms.TextBox();
      this.rbServoOff = new System.Windows.Forms.RadioButton();
      this.rbServoOn = new System.Windows.Forms.RadioButton();
      this.label10 = new System.Windows.Forms.Label();
      this.tbEncoder = new System.Windows.Forms.TextBox();
      this.btSetCommand = new System.Windows.Forms.Button();
      this.btErrorClear = new System.Windows.Forms.Button();
      this.btStartStop = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // formsPlot1
      // 
      this.formsPlot1.DisplayScale = 0F;
      this.formsPlot1.Location = new System.Drawing.Point(89, 12);
      this.formsPlot1.Name = "formsPlot1";
      this.formsPlot1.Size = new System.Drawing.Size(673, 381);
      this.formsPlot1.TabIndex = 0;
      // 
      // cbCommPorts
      // 
      this.cbCommPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbCommPorts.FormattingEnabled = true;
      this.cbCommPorts.Location = new System.Drawing.Point(829, 17);
      this.cbCommPorts.Name = "cbCommPorts";
      this.cbCommPorts.Size = new System.Drawing.Size(71, 20);
      this.cbCommPorts.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(780, 22);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(29, 12);
      this.label1.TabIndex = 0;
      this.label1.Text = "포트";
      // 
      // btCommRefresh
      // 
      this.btCommRefresh.Location = new System.Drawing.Point(907, 15);
      this.btCommRefresh.Name = "btCommRefresh";
      this.btCommRefresh.Size = new System.Drawing.Size(75, 23);
      this.btCommRefresh.TabIndex = 2;
      this.btCommRefresh.Text = "재검색";
      this.btCommRefresh.UseVisualStyleBackColor = true;
      this.btCommRefresh.Click += new System.EventHandler(this.btCommRefresh_Click);
      // 
      // btCommOpen
      // 
      this.btCommOpen.Location = new System.Drawing.Point(907, 39);
      this.btCommOpen.Name = "btCommOpen";
      this.btCommOpen.Size = new System.Drawing.Size(75, 23);
      this.btCommOpen.TabIndex = 5;
      this.btCommOpen.Text = "Open";
      this.btCommOpen.UseVisualStyleBackColor = true;
      this.btCommOpen.Click += new System.EventHandler(this.btCommOpen_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(768, 46);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(53, 12);
      this.label2.TabIndex = 3;
      this.label2.Text = "통신속도";
      // 
      // cbBaudrate
      // 
      this.cbBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbBaudrate.FormattingEnabled = true;
      this.cbBaudrate.Items.AddRange(new object[] {
            "1152000",
            "921600",
            "576000",
            "460800",
            "230400",
            "115200",
            "57600",
            "38400",
            "19200",
            "9600"});
      this.cbBaudrate.Location = new System.Drawing.Point(829, 41);
      this.cbBaudrate.Name = "cbBaudrate";
      this.cbBaudrate.Size = new System.Drawing.Size(71, 20);
      this.cbBaudrate.TabIndex = 4;
      // 
      // workTimer
      // 
      this.workTimer.Interval = 50;
      this.workTimer.Tick += new System.EventHandler(this.workTimer_Tick);
      // 
      // cbGraphCommandSpeed
      // 
      this.cbGraphCommandSpeed.AutoSize = true;
      this.cbGraphCommandSpeed.Location = new System.Drawing.Point(7, 47);
      this.cbGraphCommandSpeed.Name = "cbGraphCommandSpeed";
      this.cbGraphCommandSpeed.Size = new System.Drawing.Size(76, 16);
      this.cbGraphCommandSpeed.TabIndex = 6;
      this.cbGraphCommandSpeed.Text = "명령 속도";
      this.cbGraphCommandSpeed.UseVisualStyleBackColor = true;
      // 
      // cbGraphCommandCurrent
      // 
      this.cbGraphCommandCurrent.AutoSize = true;
      this.cbGraphCommandCurrent.Location = new System.Drawing.Point(7, 69);
      this.cbGraphCommandCurrent.Name = "cbGraphCommandCurrent";
      this.cbGraphCommandCurrent.Size = new System.Drawing.Size(76, 16);
      this.cbGraphCommandCurrent.TabIndex = 7;
      this.cbGraphCommandCurrent.Text = "명령 전류";
      this.cbGraphCommandCurrent.UseVisualStyleBackColor = true;
      // 
      // cbGraphFeedSpeed
      // 
      this.cbGraphFeedSpeed.AutoSize = true;
      this.cbGraphFeedSpeed.Location = new System.Drawing.Point(7, 91);
      this.cbGraphFeedSpeed.Name = "cbGraphFeedSpeed";
      this.cbGraphFeedSpeed.Size = new System.Drawing.Size(76, 16);
      this.cbGraphFeedSpeed.TabIndex = 8;
      this.cbGraphFeedSpeed.Text = "현재 속도";
      this.cbGraphFeedSpeed.UseVisualStyleBackColor = true;
      // 
      // cbGraphFeedCurrent
      // 
      this.cbGraphFeedCurrent.AutoSize = true;
      this.cbGraphFeedCurrent.Location = new System.Drawing.Point(7, 113);
      this.cbGraphFeedCurrent.Name = "cbGraphFeedCurrent";
      this.cbGraphFeedCurrent.Size = new System.Drawing.Size(76, 16);
      this.cbGraphFeedCurrent.TabIndex = 9;
      this.cbGraphFeedCurrent.Text = "현재 전류";
      this.cbGraphFeedCurrent.UseVisualStyleBackColor = true;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.rbTorqueMode);
      this.groupBox1.Controls.Add(this.btSpeedTorque);
      this.groupBox1.Controls.Add(this.rbSpeedMode);
      this.groupBox1.Location = new System.Drawing.Point(778, 133);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(204, 37);
      this.groupBox1.TabIndex = 10;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "모드 설정";
      // 
      // rbTorqueMode
      // 
      this.rbTorqueMode.AutoSize = true;
      this.rbTorqueMode.Location = new System.Drawing.Point(153, 15);
      this.rbTorqueMode.Name = "rbTorqueMode";
      this.rbTorqueMode.Size = new System.Drawing.Size(47, 16);
      this.rbTorqueMode.TabIndex = 25;
      this.rbTorqueMode.TabStop = true;
      this.rbTorqueMode.Text = "토크";
      this.rbTorqueMode.UseVisualStyleBackColor = true;
      // 
      // btSpeedTorque
      // 
      this.btSpeedTorque.Location = new System.Drawing.Point(8, 12);
      this.btSpeedTorque.Name = "btSpeedTorque";
      this.btSpeedTorque.Size = new System.Drawing.Size(89, 20);
      this.btSpeedTorque.TabIndex = 23;
      this.btSpeedTorque.Text = "토크 모드";
      this.btSpeedTorque.UseVisualStyleBackColor = true;
      this.btSpeedTorque.Click += new System.EventHandler(this.Click_SpeedTorqueMode);
      // 
      // rbSpeedMode
      // 
      this.rbSpeedMode.AutoSize = true;
      this.rbSpeedMode.Location = new System.Drawing.Point(104, 15);
      this.rbSpeedMode.Name = "rbSpeedMode";
      this.rbSpeedMode.Size = new System.Drawing.Size(47, 16);
      this.rbSpeedMode.TabIndex = 24;
      this.rbSpeedMode.TabStop = true;
      this.rbSpeedMode.Text = "속도";
      this.rbSpeedMode.UseVisualStyleBackColor = true;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.btCurrentKiSet);
      this.groupBox2.Controls.Add(this.btCurrentKpSet);
      this.groupBox2.Controls.Add(this.btSpeedKiSet);
      this.groupBox2.Controls.Add(this.btSpeedKpSet);
      this.groupBox2.Controls.Add(this.label6);
      this.groupBox2.Controls.Add(this.label5);
      this.groupBox2.Controls.Add(this.label4);
      this.groupBox2.Controls.Add(this.label3);
      this.groupBox2.Controls.Add(this.tbCurrentKi);
      this.groupBox2.Controls.Add(this.tbCurrentKp);
      this.groupBox2.Controls.Add(this.tbSpeedKi);
      this.groupBox2.Controls.Add(this.tbSpeedKp);
      this.groupBox2.Location = new System.Drawing.Point(778, 248);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(200, 133);
      this.groupBox2.TabIndex = 11;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "게인 설정";
      // 
      // btCurrentKiSet
      // 
      this.btCurrentKiSet.Location = new System.Drawing.Point(153, 100);
      this.btCurrentKiSet.Name = "btCurrentKiSet";
      this.btCurrentKiSet.Size = new System.Drawing.Size(38, 23);
      this.btCurrentKiSet.TabIndex = 21;
      this.btCurrentKiSet.Text = "Set";
      this.btCurrentKiSet.UseVisualStyleBackColor = true;
      this.btCurrentKiSet.Click += new System.EventHandler(this.Click_CurrentKi);
      // 
      // btCurrentKpSet
      // 
      this.btCurrentKpSet.Location = new System.Drawing.Point(153, 74);
      this.btCurrentKpSet.Name = "btCurrentKpSet";
      this.btCurrentKpSet.Size = new System.Drawing.Size(38, 23);
      this.btCurrentKpSet.TabIndex = 20;
      this.btCurrentKpSet.Text = "Set";
      this.btCurrentKpSet.UseVisualStyleBackColor = true;
      this.btCurrentKpSet.Click += new System.EventHandler(this.Click_CurrentKp);
      // 
      // btSpeedKiSet
      // 
      this.btSpeedKiSet.Location = new System.Drawing.Point(153, 47);
      this.btSpeedKiSet.Name = "btSpeedKiSet";
      this.btSpeedKiSet.Size = new System.Drawing.Size(38, 23);
      this.btSpeedKiSet.TabIndex = 19;
      this.btSpeedKiSet.Text = "Set";
      this.btSpeedKiSet.UseVisualStyleBackColor = true;
      this.btSpeedKiSet.Click += new System.EventHandler(this.Click_SpeedKi);
      // 
      // btSpeedKpSet
      // 
      this.btSpeedKpSet.Location = new System.Drawing.Point(153, 20);
      this.btSpeedKpSet.Name = "btSpeedKpSet";
      this.btSpeedKpSet.Size = new System.Drawing.Size(38, 23);
      this.btSpeedKpSet.TabIndex = 18;
      this.btSpeedKpSet.Text = "Set";
      this.btSpeedKpSet.UseVisualStyleBackColor = true;
      this.btSpeedKpSet.Click += new System.EventHandler(this.Click_SpeedKp);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(6, 107);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(78, 12);
      this.label6.TabIndex = 7;
      this.label6.Text = "전류 게인(Ki)";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(6, 80);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(82, 12);
      this.label5.TabIndex = 6;
      this.label5.Text = "전류 게인(Kp)";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(6, 53);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(78, 12);
      this.label4.TabIndex = 5;
      this.label4.Text = "속도 게인(Ki)";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 26);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(82, 12);
      this.label3.TabIndex = 4;
      this.label3.Text = "속도 게인(Kp)";
      // 
      // tbCurrentKi
      // 
      this.tbCurrentKi.Location = new System.Drawing.Point(89, 102);
      this.tbCurrentKi.Name = "tbCurrentKi";
      this.tbCurrentKi.Size = new System.Drawing.Size(57, 21);
      this.tbCurrentKi.TabIndex = 3;
      this.tbCurrentKi.Text = "100";
      // 
      // tbCurrentKp
      // 
      this.tbCurrentKp.Location = new System.Drawing.Point(89, 75);
      this.tbCurrentKp.Name = "tbCurrentKp";
      this.tbCurrentKp.Size = new System.Drawing.Size(57, 21);
      this.tbCurrentKp.TabIndex = 2;
      this.tbCurrentKp.Text = "100";
      // 
      // tbSpeedKi
      // 
      this.tbSpeedKi.Location = new System.Drawing.Point(89, 48);
      this.tbSpeedKi.Name = "tbSpeedKi";
      this.tbSpeedKi.Size = new System.Drawing.Size(57, 21);
      this.tbSpeedKi.TabIndex = 1;
      this.tbSpeedKi.Text = "100";
      // 
      // tbSpeedKp
      // 
      this.tbSpeedKp.Location = new System.Drawing.Point(89, 21);
      this.tbSpeedKp.Name = "tbSpeedKp";
      this.tbSpeedKp.Size = new System.Drawing.Size(58, 21);
      this.tbSpeedKp.TabIndex = 0;
      this.tbSpeedKp.Text = "100";
      // 
      // tbServoError
      // 
      this.tbServoError.Location = new System.Drawing.Point(867, 74);
      this.tbServoError.Name = "tbServoError";
      this.tbServoError.Size = new System.Drawing.Size(57, 21);
      this.tbServoError.TabIndex = 8;
      this.tbServoError.Text = "0";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(801, 79);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(45, 12);
      this.label7.TabIndex = 8;
      this.label7.Text = "에러 값";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(709, 396);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(29, 12);
      this.label8.TabIndex = 12;
      this.label8.Text = "시간";
      // 
      // btServoOnOff
      // 
      this.btServoOnOff.Location = new System.Drawing.Point(786, 177);
      this.btServoOnOff.Name = "btServoOnOff";
      this.btServoOnOff.Size = new System.Drawing.Size(89, 23);
      this.btServoOnOff.TabIndex = 13;
      this.btServoOnOff.Text = "Servo On";
      this.btServoOnOff.UseVisualStyleBackColor = true;
      this.btServoOnOff.Click += new System.EventHandler(this.Click_ServoOnOff);
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(787, 213);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(29, 12);
      this.label9.TabIndex = 9;
      this.label9.Text = "명령";
      // 
      // tbCommand
      // 
      this.tbCommand.Location = new System.Drawing.Point(822, 208);
      this.tbCommand.Name = "tbCommand";
      this.tbCommand.Size = new System.Drawing.Size(58, 21);
      this.tbCommand.TabIndex = 8;
      this.tbCommand.Text = "0";
      // 
      // rbServoOff
      // 
      this.rbServoOff.AutoSize = true;
      this.rbServoOff.Location = new System.Drawing.Point(882, 182);
      this.rbServoOff.Name = "rbServoOff";
      this.rbServoOff.Size = new System.Drawing.Size(38, 16);
      this.rbServoOff.TabIndex = 14;
      this.rbServoOff.TabStop = true;
      this.rbServoOff.Text = "Off";
      this.rbServoOff.UseVisualStyleBackColor = true;
      // 
      // rbServoOn
      // 
      this.rbServoOn.AutoSize = true;
      this.rbServoOn.Location = new System.Drawing.Point(931, 182);
      this.rbServoOn.Name = "rbServoOn";
      this.rbServoOn.Size = new System.Drawing.Size(39, 16);
      this.rbServoOn.TabIndex = 15;
      this.rbServoOn.TabStop = true;
      this.rbServoOn.Text = "On";
      this.rbServoOn.UseVisualStyleBackColor = true;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(801, 105);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(57, 12);
      this.label10.TabIndex = 16;
      this.label10.Text = "엔코더 값";
      // 
      // tbEncoder
      // 
      this.tbEncoder.Location = new System.Drawing.Point(867, 100);
      this.tbEncoder.Name = "tbEncoder";
      this.tbEncoder.Size = new System.Drawing.Size(58, 21);
      this.tbEncoder.TabIndex = 17;
      this.tbEncoder.Text = "0";
      // 
      // btSetCommand
      // 
      this.btSetCommand.Location = new System.Drawing.Point(883, 207);
      this.btSetCommand.Name = "btSetCommand";
      this.btSetCommand.Size = new System.Drawing.Size(38, 23);
      this.btSetCommand.TabIndex = 22;
      this.btSetCommand.Text = "Set";
      this.btSetCommand.UseVisualStyleBackColor = true;
      this.btSetCommand.Click += new System.EventHandler(this.Click_SetCommand);
      // 
      // btErrorClear
      // 
      this.btErrorClear.Location = new System.Drawing.Point(930, 73);
      this.btErrorClear.Name = "btErrorClear";
      this.btErrorClear.Size = new System.Drawing.Size(48, 23);
      this.btErrorClear.TabIndex = 23;
      this.btErrorClear.Text = "Clear";
      this.btErrorClear.UseVisualStyleBackColor = true;
      this.btErrorClear.Click += new System.EventHandler(this.Click_ErrorClear);
      // 
      // btStartStop
      // 
      this.btStartStop.Location = new System.Drawing.Point(925, 207);
      this.btStartStop.Name = "btStartStop";
      this.btStartStop.Size = new System.Drawing.Size(52, 23);
      this.btStartStop.TabIndex = 24;
      this.btStartStop.Text = "Start";
      this.btStartStop.UseVisualStyleBackColor = true;
      this.btStartStop.Click += new System.EventHandler(this.Click_StartStop);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(993, 415);
      this.Controls.Add(this.btStartStop);
      this.Controls.Add(this.btErrorClear);
      this.Controls.Add(this.btSetCommand);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.tbEncoder);
      this.Controls.Add(this.rbServoOn);
      this.Controls.Add(this.rbServoOff);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.btServoOnOff);
      this.Controls.Add(this.tbCommand);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.tbServoError);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.cbGraphFeedCurrent);
      this.Controls.Add(this.cbGraphFeedSpeed);
      this.Controls.Add(this.cbGraphCommandCurrent);
      this.Controls.Add(this.cbGraphCommandSpeed);
      this.Controls.Add(this.btCommOpen);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cbBaudrate);
      this.Controls.Add(this.btCommRefresh);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cbCommPorts);
      this.Controls.Add(this.formsPlot1);
      this.Name = "Form1";
      this.Text = "모터 테스트";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private ScottPlot.WinForms.FormsPlot formsPlot1;
    private System.Windows.Forms.ComboBox cbCommPorts;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btCommRefresh;
    private System.Windows.Forms.Button btCommOpen;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cbBaudrate;
    private System.Windows.Forms.Timer workTimer;
    private System.Windows.Forms.CheckBox cbGraphCommandSpeed;
    private System.Windows.Forms.CheckBox cbGraphCommandCurrent;
    private System.Windows.Forms.CheckBox cbGraphFeedSpeed;
    private System.Windows.Forms.CheckBox cbGraphFeedCurrent;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox tbCurrentKi;
    private System.Windows.Forms.TextBox tbCurrentKp;
    private System.Windows.Forms.TextBox tbSpeedKi;
    private System.Windows.Forms.TextBox tbSpeedKp;
    private System.Windows.Forms.TextBox tbServoError;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Button btServoOnOff;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox tbCommand;
    private System.Windows.Forms.RadioButton rbServoOff;
    private System.Windows.Forms.RadioButton rbServoOn;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox tbEncoder;
    private System.Windows.Forms.Button btCurrentKiSet;
    private System.Windows.Forms.Button btCurrentKpSet;
    private System.Windows.Forms.Button btSpeedKiSet;
    private System.Windows.Forms.Button btSpeedKpSet;
    private System.Windows.Forms.Button btSetCommand;
    private System.Windows.Forms.RadioButton rbTorqueMode;
    private System.Windows.Forms.Button btSpeedTorque;
    private System.Windows.Forms.RadioButton rbSpeedMode;
    private System.Windows.Forms.Button btErrorClear;
    private System.Windows.Forms.Button btStartStop;
  }
}

