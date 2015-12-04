namespace CANStream
{
    partial class Frm_CANConfiguration_SpecialPaste
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Lbl_CANMessage = new System.Windows.Forms.Label();
            this.Radio_Msg_RxTx = new System.Windows.Forms.RadioButton();
            this.Radio_Msg_Period = new System.Windows.Forms.RadioButton();
            this.Radio_Msg_Comment = new System.Windows.Forms.RadioButton();
            this.Radio_Msg_DLC = new System.Windows.Forms.RadioButton();
            this.Radio_Msg_Timeout = new System.Windows.Forms.RadioButton();
            this.Radio_Param_Endianess = new System.Windows.Forms.RadioButton();
            this.Radio_Param_Signedness = new System.Windows.Forms.RadioButton();
            this.Radio_Param_Linearization = new System.Windows.Forms.RadioButton();
            this.Radio_Param_VirtualChan = new System.Windows.Forms.RadioButton();
            this.Radio_Param_Format = new System.Windows.Forms.RadioButton();
            this.Radio_Param_Alarms = new System.Windows.Forms.RadioButton();
            this.Lbl_CANParameter = new System.Windows.Forms.Label();
            this.Radio_Param_Comment = new System.Windows.Forms.RadioButton();
            this.Radio_Param_Unit = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Cmd_Cancel = new System.Windows.Forms.Button();
            this.Cmd_Apply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lbl_CANMessage
            // 
            this.Lbl_CANMessage.AutoSize = true;
            this.Lbl_CANMessage.Location = new System.Drawing.Point(9, 9);
            this.Lbl_CANMessage.Name = "Lbl_CANMessage";
            this.Lbl_CANMessage.Size = new System.Drawing.Size(99, 13);
            this.Lbl_CANMessage.TabIndex = 0;
            this.Lbl_CANMessage.Text = "Message properties";
            // 
            // Radio_Msg_RxTx
            // 
            this.Radio_Msg_RxTx.AutoSize = true;
            this.Radio_Msg_RxTx.Location = new System.Drawing.Point(12, 25);
            this.Radio_Msg_RxTx.Name = "Radio_Msg_RxTx";
            this.Radio_Msg_RxTx.Size = new System.Drawing.Size(50, 17);
            this.Radio_Msg_RxTx.TabIndex = 1;
            this.Radio_Msg_RxTx.TabStop = true;
            this.Radio_Msg_RxTx.Text = "RxTx";
            this.Radio_Msg_RxTx.UseVisualStyleBackColor = true;
            // 
            // Radio_Msg_Period
            // 
            this.Radio_Msg_Period.AutoSize = true;
            this.Radio_Msg_Period.Location = new System.Drawing.Point(12, 48);
            this.Radio_Msg_Period.Name = "Radio_Msg_Period";
            this.Radio_Msg_Period.Size = new System.Drawing.Size(55, 17);
            this.Radio_Msg_Period.TabIndex = 2;
            this.Radio_Msg_Period.TabStop = true;
            this.Radio_Msg_Period.Text = "Period";
            this.Radio_Msg_Period.UseVisualStyleBackColor = true;
            // 
            // Radio_Msg_Comment
            // 
            this.Radio_Msg_Comment.AutoSize = true;
            this.Radio_Msg_Comment.Location = new System.Drawing.Point(12, 71);
            this.Radio_Msg_Comment.Name = "Radio_Msg_Comment";
            this.Radio_Msg_Comment.Size = new System.Drawing.Size(69, 17);
            this.Radio_Msg_Comment.TabIndex = 3;
            this.Radio_Msg_Comment.TabStop = true;
            this.Radio_Msg_Comment.Text = "Comment";
            this.Radio_Msg_Comment.UseVisualStyleBackColor = true;
            // 
            // Radio_Msg_DLC
            // 
            this.Radio_Msg_DLC.AutoSize = true;
            this.Radio_Msg_DLC.Location = new System.Drawing.Point(147, 25);
            this.Radio_Msg_DLC.Name = "Radio_Msg_DLC";
            this.Radio_Msg_DLC.Size = new System.Drawing.Size(46, 17);
            this.Radio_Msg_DLC.TabIndex = 4;
            this.Radio_Msg_DLC.TabStop = true;
            this.Radio_Msg_DLC.Text = "DLC";
            this.Radio_Msg_DLC.UseVisualStyleBackColor = true;
            // 
            // Radio_Msg_Timeout
            // 
            this.Radio_Msg_Timeout.AutoSize = true;
            this.Radio_Msg_Timeout.Location = new System.Drawing.Point(147, 48);
            this.Radio_Msg_Timeout.Name = "Radio_Msg_Timeout";
            this.Radio_Msg_Timeout.Size = new System.Drawing.Size(93, 17);
            this.Radio_Msg_Timeout.TabIndex = 5;
            this.Radio_Msg_Timeout.TabStop = true;
            this.Radio_Msg_Timeout.Text = "NoRx Timeout";
            this.Radio_Msg_Timeout.UseVisualStyleBackColor = true;
            // 
            // Radio_Param_Endianess
            // 
            this.Radio_Param_Endianess.AutoSize = true;
            this.Radio_Param_Endianess.Location = new System.Drawing.Point(12, 124);
            this.Radio_Param_Endianess.Name = "Radio_Param_Endianess";
            this.Radio_Param_Endianess.Size = new System.Drawing.Size(74, 17);
            this.Radio_Param_Endianess.TabIndex = 7;
            this.Radio_Param_Endianess.TabStop = true;
            this.Radio_Param_Endianess.Text = "Endianess";
            this.Radio_Param_Endianess.UseVisualStyleBackColor = true;
            // 
            // Radio_Param_Signedness
            // 
            this.Radio_Param_Signedness.AutoSize = true;
            this.Radio_Param_Signedness.Location = new System.Drawing.Point(147, 124);
            this.Radio_Param_Signedness.Name = "Radio_Param_Signedness";
            this.Radio_Param_Signedness.Size = new System.Drawing.Size(80, 17);
            this.Radio_Param_Signedness.TabIndex = 8;
            this.Radio_Param_Signedness.TabStop = true;
            this.Radio_Param_Signedness.Text = "Signedness";
            this.Radio_Param_Signedness.UseVisualStyleBackColor = true;
            // 
            // Radio_Param_Linearization
            // 
            this.Radio_Param_Linearization.AutoSize = true;
            this.Radio_Param_Linearization.Location = new System.Drawing.Point(12, 147);
            this.Radio_Param_Linearization.Name = "Radio_Param_Linearization";
            this.Radio_Param_Linearization.Size = new System.Drawing.Size(84, 17);
            this.Radio_Param_Linearization.TabIndex = 9;
            this.Radio_Param_Linearization.TabStop = true;
            this.Radio_Param_Linearization.Text = "Linearization";
            this.Radio_Param_Linearization.UseVisualStyleBackColor = true;
            // 
            // Radio_Param_VirtualChan
            // 
            this.Radio_Param_VirtualChan.AutoSize = true;
            this.Radio_Param_VirtualChan.Location = new System.Drawing.Point(147, 147);
            this.Radio_Param_VirtualChan.Name = "Radio_Param_VirtualChan";
            this.Radio_Param_VirtualChan.Size = new System.Drawing.Size(143, 17);
            this.Radio_Param_VirtualChan.TabIndex = 10;
            this.Radio_Param_VirtualChan.TabStop = true;
            this.Radio_Param_VirtualChan.Text = "Virtual channel reference";
            this.Radio_Param_VirtualChan.UseVisualStyleBackColor = true;
            // 
            // Radio_Param_Format
            // 
            this.Radio_Param_Format.AutoSize = true;
            this.Radio_Param_Format.Location = new System.Drawing.Point(12, 170);
            this.Radio_Param_Format.Name = "Radio_Param_Format";
            this.Radio_Param_Format.Size = new System.Drawing.Size(57, 17);
            this.Radio_Param_Format.TabIndex = 11;
            this.Radio_Param_Format.TabStop = true;
            this.Radio_Param_Format.Text = "Format";
            this.Radio_Param_Format.UseVisualStyleBackColor = true;
            // 
            // Radio_Param_Alarms
            // 
            this.Radio_Param_Alarms.AutoSize = true;
            this.Radio_Param_Alarms.Location = new System.Drawing.Point(147, 170);
            this.Radio_Param_Alarms.Name = "Radio_Param_Alarms";
            this.Radio_Param_Alarms.Size = new System.Drawing.Size(56, 17);
            this.Radio_Param_Alarms.TabIndex = 12;
            this.Radio_Param_Alarms.TabStop = true;
            this.Radio_Param_Alarms.Text = "Alarms";
            this.Radio_Param_Alarms.UseVisualStyleBackColor = true;
            // 
            // Lbl_CANParameter
            // 
            this.Lbl_CANParameter.AutoSize = true;
            this.Lbl_CANParameter.Location = new System.Drawing.Point(9, 108);
            this.Lbl_CANParameter.Name = "Lbl_CANParameter";
            this.Lbl_CANParameter.Size = new System.Drawing.Size(104, 13);
            this.Lbl_CANParameter.TabIndex = 13;
            this.Lbl_CANParameter.Text = "Parameter properties";
            // 
            // Radio_Param_Comment
            // 
            this.Radio_Param_Comment.AutoSize = true;
            this.Radio_Param_Comment.Location = new System.Drawing.Point(147, 193);
            this.Radio_Param_Comment.Name = "Radio_Param_Comment";
            this.Radio_Param_Comment.Size = new System.Drawing.Size(69, 17);
            this.Radio_Param_Comment.TabIndex = 15;
            this.Radio_Param_Comment.TabStop = true;
            this.Radio_Param_Comment.Text = "Comment";
            this.Radio_Param_Comment.UseVisualStyleBackColor = true;
            // 
            // Radio_Param_Unit
            // 
            this.Radio_Param_Unit.AutoSize = true;
            this.Radio_Param_Unit.Location = new System.Drawing.Point(12, 193);
            this.Radio_Param_Unit.Name = "Radio_Param_Unit";
            this.Radio_Param_Unit.Size = new System.Drawing.Size(44, 17);
            this.Radio_Param_Unit.TabIndex = 14;
            this.Radio_Param_Unit.TabStop = true;
            this.Radio_Param_Unit.Text = "Unit";
            this.Radio_Param_Unit.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(111, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 10);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(111, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(193, 10);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // Cmd_Cancel
            // 
            this.Cmd_Cancel.Location = new System.Drawing.Point(146, 236);
            this.Cmd_Cancel.Name = "Cmd_Cancel";
            this.Cmd_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cmd_Cancel.TabIndex = 18;
            this.Cmd_Cancel.Text = "Cancel";
            this.Cmd_Cancel.UseVisualStyleBackColor = true;
            this.Cmd_Cancel.Click += new System.EventHandler(this.Cmd_Cancel_Click);
            // 
            // Cmd_Apply
            // 
            this.Cmd_Apply.Location = new System.Drawing.Point(227, 236);
            this.Cmd_Apply.Name = "Cmd_Apply";
            this.Cmd_Apply.Size = new System.Drawing.Size(75, 23);
            this.Cmd_Apply.TabIndex = 19;
            this.Cmd_Apply.Text = "OK";
            this.Cmd_Apply.UseVisualStyleBackColor = true;
            this.Cmd_Apply.Click += new System.EventHandler(this.Cmd_Apply_Click);
            // 
            // Frm_CANConfiguration_SpecialPaste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 271);
            this.Controls.Add(this.Cmd_Apply);
            this.Controls.Add(this.Cmd_Cancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Radio_Param_Comment);
            this.Controls.Add(this.Radio_Param_Unit);
            this.Controls.Add(this.Lbl_CANParameter);
            this.Controls.Add(this.Radio_Param_Alarms);
            this.Controls.Add(this.Radio_Param_Format);
            this.Controls.Add(this.Radio_Param_VirtualChan);
            this.Controls.Add(this.Radio_Param_Linearization);
            this.Controls.Add(this.Radio_Param_Signedness);
            this.Controls.Add(this.Radio_Param_Endianess);
            this.Controls.Add(this.Radio_Msg_Timeout);
            this.Controls.Add(this.Radio_Msg_DLC);
            this.Controls.Add(this.Radio_Msg_Comment);
            this.Controls.Add(this.Radio_Msg_Period);
            this.Controls.Add(this.Radio_Msg_RxTx);
            this.Controls.Add(this.Lbl_CANMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_CANConfiguration_SpecialPaste";
            this.Text = "Special paste";
            this.Load += new System.EventHandler(this.Frm_CANConfiguration_SpecialPaste_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_CANMessage;
        private System.Windows.Forms.RadioButton Radio_Msg_RxTx;
        private System.Windows.Forms.RadioButton Radio_Msg_Period;
        private System.Windows.Forms.RadioButton Radio_Msg_Comment;
        private System.Windows.Forms.RadioButton Radio_Msg_DLC;
        private System.Windows.Forms.RadioButton Radio_Msg_Timeout;
        private System.Windows.Forms.RadioButton Radio_Param_Endianess;
        private System.Windows.Forms.RadioButton Radio_Param_Signedness;
        private System.Windows.Forms.RadioButton Radio_Param_Linearization;
        private System.Windows.Forms.RadioButton Radio_Param_VirtualChan;
        private System.Windows.Forms.RadioButton Radio_Param_Format;
        private System.Windows.Forms.RadioButton Radio_Param_Alarms;
        private System.Windows.Forms.Label Lbl_CANParameter;
        private System.Windows.Forms.RadioButton Radio_Param_Comment;
        private System.Windows.Forms.RadioButton Radio_Param_Unit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Cmd_Cancel;
        private System.Windows.Forms.Button Cmd_Apply;
    }
}