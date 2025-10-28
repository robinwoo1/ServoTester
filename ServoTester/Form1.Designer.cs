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
      this.SuspendLayout();
      // 
      // formsPlot1
      // 
      this.formsPlot1.DisplayScale = 0F;
      this.formsPlot1.Location = new System.Drawing.Point(21, 25);
      this.formsPlot1.Name = "formsPlot1";
      this.formsPlot1.Size = new System.Drawing.Size(553, 309);
      this.formsPlot1.TabIndex = 0;
      // 
      // cbCommPorts
      // 
      this.cbCommPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbCommPorts.FormattingEnabled = true;
      this.cbCommPorts.Location = new System.Drawing.Point(643, 25);
      this.cbCommPorts.Name = "cbCommPorts";
      this.cbCommPorts.Size = new System.Drawing.Size(71, 20);
      this.cbCommPorts.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(582, 30);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(27, 12);
      this.label1.TabIndex = 0;
      this.label1.Text = "Port";
      // 
      // btCommRefresh
      // 
      this.btCommRefresh.Location = new System.Drawing.Point(721, 23);
      this.btCommRefresh.Name = "btCommRefresh";
      this.btCommRefresh.Size = new System.Drawing.Size(75, 23);
      this.btCommRefresh.TabIndex = 2;
      this.btCommRefresh.Text = "Refresh";
      this.btCommRefresh.UseVisualStyleBackColor = true;
      this.btCommRefresh.Click += new System.EventHandler(this.btCommRefresh_Click);
      // 
      // btCommOpen
      // 
      this.btCommOpen.Location = new System.Drawing.Point(721, 49);
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
      this.label2.Location = new System.Drawing.Point(582, 56);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(55, 12);
      this.label2.TabIndex = 3;
      this.label2.Text = "Baudrate";
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
      this.cbBaudrate.Location = new System.Drawing.Point(643, 51);
      this.cbBaudrate.Name = "cbBaudrate";
      this.cbBaudrate.Size = new System.Drawing.Size(71, 20);
      this.cbBaudrate.TabIndex = 4;
      // 
      // workTimer
      // 
      this.workTimer.Interval = 20;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.btCommOpen);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cbBaudrate);
      this.Controls.Add(this.btCommRefresh);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cbCommPorts);
      this.Controls.Add(this.formsPlot1);
      this.Name = "Form1";
      this.Text = "Form1";
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
  }
}

