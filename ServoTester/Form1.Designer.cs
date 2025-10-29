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
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // formsPlot1
      // 
      this.formsPlot1.DisplayScale = 0F;
      this.formsPlot1.Location = new System.Drawing.Point(12, 12);
      this.formsPlot1.Name = "formsPlot1";
      this.formsPlot1.Size = new System.Drawing.Size(750, 381);
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
      this.workTimer.Interval = 20;
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new System.Drawing.Point(779, 81);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(76, 16);
      this.checkBox1.TabIndex = 6;
      this.checkBox1.Text = "명령 속도";
      this.checkBox1.UseVisualStyleBackColor = true;
      // 
      // checkBox2
      // 
      this.checkBox2.AutoSize = true;
      this.checkBox2.Location = new System.Drawing.Point(779, 103);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new System.Drawing.Size(76, 16);
      this.checkBox2.TabIndex = 7;
      this.checkBox2.Text = "명령 전류";
      this.checkBox2.UseVisualStyleBackColor = true;
      // 
      // checkBox3
      // 
      this.checkBox3.AutoSize = true;
      this.checkBox3.Location = new System.Drawing.Point(779, 125);
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new System.Drawing.Size(76, 16);
      this.checkBox3.TabIndex = 8;
      this.checkBox3.Text = "현재 속도";
      this.checkBox3.UseVisualStyleBackColor = true;
      // 
      // checkBox4
      // 
      this.checkBox4.AutoSize = true;
      this.checkBox4.Location = new System.Drawing.Point(779, 147);
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
      this.groupBox1.Location = new System.Drawing.Point(770, 179);
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
      this.groupBox2.Location = new System.Drawing.Point(770, 249);
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
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(993, 405);
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
  }
}

