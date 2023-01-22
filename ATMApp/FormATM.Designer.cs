namespace ATMApp
{
    partial class FormATM
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxDisplay = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.button000 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBoxCheck = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonEject = new System.Windows.Forms.Button();
            this.buttonPushCard = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBoxCardNumber = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttonCashOut = new System.Windows.Forms.Button();
            this.richTextBoxCashOut = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxDisplay
            // 
            this.richTextBoxDisplay.Location = new System.Drawing.Point(6, 22);
            this.richTextBoxDisplay.Name = "richTextBoxDisplay";
            this.richTextBoxDisplay.ReadOnly = true;
            this.richTextBoxDisplay.Size = new System.Drawing.Size(348, 137);
            this.richTextBoxDisplay.TabIndex = 0;
            this.richTextBoxDisplay.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button0);
            this.groupBox1.Controls.Add(this.buttonCancel);
            this.groupBox1.Controls.Add(this.buttonEnter);
            this.groupBox1.Controls.Add(this.button000);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(12, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 310);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Панель управления";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(6, 232);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 64);
            this.button10.TabIndex = 15;
            this.button10.Text = "-";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button0
            // 
            this.button0.Location = new System.Drawing.Point(87, 232);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(75, 64);
            this.button0.TabIndex = 10;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.button0_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(262, 92);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(92, 64);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "ОТМЕНА";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonEnter
            // 
            this.buttonEnter.Location = new System.Drawing.Point(262, 22);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(92, 64);
            this.buttonEnter.TabIndex = 14;
            this.buttonEnter.Text = "ВВОД";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // button000
            // 
            this.button000.Location = new System.Drawing.Point(168, 232);
            this.button000.Name = "button000";
            this.button000.Size = new System.Drawing.Size(75, 64);
            this.button000.TabIndex = 9;
            this.button000.Text = "000";
            this.button000.UseVisualStyleBackColor = true;
            this.button000.Click += new System.EventHandler(this.button000_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(87, 162);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 64);
            this.button8.TabIndex = 7;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 92);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 64);
            this.button4.TabIndex = 5;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 64);
            this.button1.TabIndex = 0;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(6, 162);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 64);
            this.button7.TabIndex = 8;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(168, 162);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 64);
            this.button9.TabIndex = 6;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(87, 92);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 64);
            this.button5.TabIndex = 4;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(168, 92);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 64);
            this.button6.TabIndex = 3;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(168, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 64);
            this.button3.TabIndex = 2;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(87, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 64);
            this.button2.TabIndex = 1;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBoxCheck);
            this.groupBox2.Location = new System.Drawing.Point(378, 353);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 142);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Справка";
            // 
            // richTextBoxCheck
            // 
            this.richTextBoxCheck.Location = new System.Drawing.Point(6, 16);
            this.richTextBoxCheck.Name = "richTextBoxCheck";
            this.richTextBoxCheck.ReadOnly = true;
            this.richTextBoxCheck.Size = new System.Drawing.Size(296, 112);
            this.richTextBoxCheck.TabIndex = 3;
            this.richTextBoxCheck.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonEject);
            this.groupBox3.Controls.Add(this.buttonPushCard);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.labelStatus);
            this.groupBox3.Location = new System.Drawing.Point(378, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(308, 182);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Приемник карт";
            // 
            // buttonEject
            // 
            this.buttonEject.Enabled = false;
            this.buttonEject.Location = new System.Drawing.Point(6, 118);
            this.buttonEject.Name = "buttonEject";
            this.buttonEject.Size = new System.Drawing.Size(296, 23);
            this.buttonEject.TabIndex = 7;
            this.buttonEject.Text = "Забрать карту";
            this.buttonEject.UseVisualStyleBackColor = true;
            this.buttonEject.Click += new System.EventHandler(this.buttonEject_Click);
            // 
            // buttonPushCard
            // 
            this.buttonPushCard.Location = new System.Drawing.Point(6, 89);
            this.buttonPushCard.Name = "buttonPushCard";
            this.buttonPushCard.Size = new System.Drawing.Size(296, 23);
            this.buttonPushCard.TabIndex = 6;
            this.buttonPushCard.Text = "Вставить карту";
            this.buttonPushCard.UseVisualStyleBackColor = true;
            this.buttonPushCard.Click += new System.EventHandler(this.buttonPushCard_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBoxCardNumber);
            this.groupBox5.Location = new System.Drawing.Point(6, 22);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(296, 61);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Номер карты";
            // 
            // textBoxCardNumber
            // 
            this.textBoxCardNumber.Location = new System.Drawing.Point(6, 22);
            this.textBoxCardNumber.Name = "textBoxCardNumber";
            this.textBoxCardNumber.Size = new System.Drawing.Size(284, 23);
            this.textBoxCardNumber.TabIndex = 1;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(6, 152);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(79, 15);
            this.labelStatus.TabIndex = 0;
            this.labelStatus.Text = "Статус карты";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.richTextBoxDisplay);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(360, 167);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Дисплей";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.buttonCashOut);
            this.groupBox6.Controls.Add(this.richTextBoxCashOut);
            this.groupBox6.Location = new System.Drawing.Point(378, 200);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(308, 147);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Лоток выдачи денег";
            // 
            // buttonCashOut
            // 
            this.buttonCashOut.Location = new System.Drawing.Point(6, 117);
            this.buttonCashOut.Name = "buttonCashOut";
            this.buttonCashOut.Size = new System.Drawing.Size(296, 23);
            this.buttonCashOut.TabIndex = 7;
            this.buttonCashOut.Text = "Забрать деньги";
            this.buttonCashOut.UseVisualStyleBackColor = true;
            this.buttonCashOut.Click += new System.EventHandler(this.buttonCashOut_Click);
            // 
            // richTextBoxCashOut
            // 
            this.richTextBoxCashOut.Location = new System.Drawing.Point(6, 22);
            this.richTextBoxCashOut.Name = "richTextBoxCashOut";
            this.richTextBoxCashOut.ReadOnly = true;
            this.richTextBoxCashOut.Size = new System.Drawing.Size(296, 89);
            this.richTextBoxCashOut.TabIndex = 4;
            this.richTextBoxCashOut.Text = "";
            // 
            // FormATM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 511);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormATM";
            this.Text = "Банкомат";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox richTextBoxDisplay;
        private GroupBox groupBox1;
        private Button button0;
        private Button button000;
        private Button button8;
        private Button button4;
        private Button button1;
        private Button button7;
        private Button button9;
        private Button button5;
        private Button button6;
        private Button button3;
        private Button button2;
        private GroupBox groupBox2;
        private RichTextBox richTextBoxCheck;
        private Button buttonCancel;
        private Button buttonEnter;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Label labelStatus;
        private GroupBox groupBox5;
        private TextBox textBoxCardNumber;
        private Button buttonPushCard;
        private GroupBox groupBox6;
        private Button buttonCashOut;
        private RichTextBox richTextBoxCashOut;
        private Button buttonEject;
        private Button button10;
    }
}