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
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this.checkBox2 = new System.Windows.Forms.CheckBox();
      this.checkBox3 = new System.Windows.Forms.CheckBox();
      this.checkBox4 = new System.Windows.Forms.CheckBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.checkBox6 = new System.Windows.Forms.CheckBox();
      this.checkBox5 = new System.Windows.Forms.CheckBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.textBox4 = new System.Windows.Forms.TextBox();
      this.textBox3 = new System.Windows.Forms.TextBox();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.textBox5 = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.label9 = new System.Windows.Forms.Label();
      this.textBox6 = new System.Windows.Forms.TextBox();
      this.radioButton1 = new System.Windows.Forms.RadioButton();
      this.radioButton2 = new System.Windows.Forms.RadioButton();
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
      this.btCommOpen.Location = new System.Drawing.Point(907, 41);
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
      this.label2.Location = new System.Drawing.Point(768, 48);
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
      this.cbBaudrate.Location = new System.Drawing.Point(829, 43);
      this.cbBaudrate.Name = "cbBaudrate";
      this.cbBaudrate.Size = new System.Drawing.Size(71, 20);
      this.cbBaudrate.TabIndex = 4;
      // 
      // workTimer
      // 
      this.workTimer.Interval = 30;
      this.workTimer.Tick += new System.EventHandler(this.workTimer_Tick);
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new System.Drawing.Point(7, 47);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(76, 16);
      this.checkBox1.TabIndex = 6;
      this.checkBox1.Text = "명령 속도";
      this.checkBox1.UseVisualStyleBackColor = true;
      // 
      // checkBox2
      // 
      this.checkBox2.AutoSize = true;
      this.checkBox2.Location = new System.Drawing.Point(7, 69);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new System.Drawing.Size(76, 16);
      this.checkBox2.TabIndex = 7;
      this.checkBox2.Text = "명령 전류";
      this.checkBox2.UseVisualStyleBackColor = true;
      // 
      // checkBox3
      // 
      this.checkBox3.AutoSize = true;
      this.checkBox3.Location = new System.Drawing.Point(7, 91);
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new System.Drawing.Size(76, 16);
      this.checkBox3.TabIndex = 8;
      this.checkBox3.Text = "현재 속도";
      this.checkBox3.UseVisualStyleBackColor = true;
      // 
      // checkBox4
      // 
      this.checkBox4.AutoSize = true;
      this.checkBox4.Location = new System.Drawing.Point(7, 113);
      this.checkBox4.Name = "checkBox4";
      this.checkBox4.Size = new System.Drawing.Size(76, 16);
      this.checkBox4.TabIndex = 9;
      this.checkBox4.Text = "현재 전류";
      this.checkBox4.UseVisualStyleBackColor = true;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.checkBox6);
      this.groupBox1.Controls.Add(this.checkBox5);
      this.groupBox1.Location = new System.Drawing.Point(778, 92);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(200, 47);
      this.groupBox1.TabIndex = 10;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "모드 설정";
      // 
      // checkBox6
      // 
      this.checkBox6.AutoSize = true;
      this.checkBox6.Location = new System.Drawing.Point(105, 20);
      this.checkBox6.Name = "checkBox6";
      this.checkBox6.Size = new System.Drawing.Size(72, 16);
      this.checkBox6.TabIndex = 12;
      this.checkBox6.Text = "토크모드";
      this.checkBox6.UseVisualStyleBackColor = true;
      // 
      // checkBox5
      // 
      this.checkBox5.AutoSize = true;
      this.checkBox5.Location = new System.Drawing.Point(8, 20);
      this.checkBox5.Name = "checkBox5";
      this.checkBox5.Size = new System.Drawing.Size(72, 16);
      this.checkBox5.TabIndex = 11;
      this.checkBox5.Text = "속도모드";
      this.checkBox5.UseVisualStyleBackColor = true;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.label6);
      this.groupBox2.Controls.Add(this.label5);
      this.groupBox2.Controls.Add(this.label4);
      this.groupBox2.Controls.Add(this.label3);
      this.groupBox2.Controls.Add(this.textBox4);
      this.groupBox2.Controls.Add(this.textBox3);
      this.groupBox2.Controls.Add(this.textBox2);
      this.groupBox2.Controls.Add(this.textBox1);
      this.groupBox2.Location = new System.Drawing.Point(778, 248);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(200, 133);
      this.groupBox2.TabIndex = 11;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "게인 설정";
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
      // textBox4
      // 
      this.textBox4.Location = new System.Drawing.Point(89, 102);
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new System.Drawing.Size(100, 21);
      this.textBox4.TabIndex = 3;
      // 
      // textBox3
      // 
      this.textBox3.Location = new System.Drawing.Point(89, 75);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new System.Drawing.Size(100, 21);
      this.textBox3.TabIndex = 2;
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(89, 48);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(100, 21);
      this.textBox2.TabIndex = 1;
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(89, 21);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(100, 21);
      this.textBox1.TabIndex = 0;
      // 
      // textBox5
      // 
      this.textBox5.Location = new System.Drawing.Point(867, 202);
      this.textBox5.Name = "textBox5";
      this.textBox5.Size = new System.Drawing.Size(100, 21);
      this.textBox5.TabIndex = 8;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(801, 207);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(57, 12);
      this.label7.TabIndex = 8;
      this.label7.Text = "엔코더 값";
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
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(786, 145);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(89, 23);
      this.button1.TabIndex = 13;
      this.button1.Text = "Servo On/Off";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(811, 181);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(29, 12);
      this.label9.TabIndex = 9;
      this.label9.Text = "명령";
      // 
      // textBox6
      // 
      this.textBox6.Location = new System.Drawing.Point(867, 175);
      this.textBox6.Name = "textBox6";
      this.textBox6.Size = new System.Drawing.Size(100, 21);
      this.textBox6.TabIndex = 8;
      // 
      // radioButton1
      // 
      this.radioButton1.AutoSize = true;
      this.radioButton1.Location = new System.Drawing.Point(886, 150);
      this.radioButton1.Name = "radioButton1";
      this.radioButton1.Size = new System.Drawing.Size(38, 16);
      this.radioButton1.TabIndex = 14;
      this.radioButton1.TabStop = true;
      this.radioButton1.Text = "Off";
      this.radioButton1.UseVisualStyleBackColor = true;
      // 
      // radioButton2
      // 
      this.radioButton2.AutoSize = true;
      this.radioButton2.Location = new System.Drawing.Point(931, 150);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new System.Drawing.Size(39, 16);
      this.radioButton2.TabIndex = 15;
      this.radioButton2.TabStop = true;
      this.radioButton2.Text = "On";
      this.radioButton2.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(993, 415);
      this.Controls.Add(this.radioButton2);
      this.Controls.Add(this.radioButton1);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.textBox6);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.textBox5);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.checkBox4);
      this.Controls.Add(this.checkBox3);
      this.Controls.Add(this.checkBox2);
      this.Controls.Add(this.checkBox1);
      this.Controls.Add(this.btCommOpen);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cbBaudrate);
      this.Controls.Add(this.btCommRefresh);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cbCommPorts);
      this.Controls.Add(this.formsPlot1);
      this.Name = "Form1";
      this.Text = "모터 테스트";
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
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.CheckBox checkBox2;
    private System.Windows.Forms.CheckBox checkBox3;
    private System.Windows.Forms.CheckBox checkBox4;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.CheckBox checkBox6;
    private System.Windows.Forms.CheckBox checkBox5;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBox4;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox5;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox textBox6;
    private System.Windows.Forms.RadioButton radioButton1;
    private System.Windows.Forms.RadioButton radioButton2;
  }
}

