namespace CSClipping
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tB1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BRY = new System.Windows.Forms.TextBox();
            this.BRX = new System.Windows.Forms.TextBox();
            this.TLY = new System.Windows.Forms.TextBox();
            this.TLX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.P3Y = new System.Windows.Forms.TextBox();
            this.P3X = new System.Windows.Forms.TextBox();
            this.P2Y = new System.Windows.Forms.TextBox();
            this.P2X = new System.Windows.Forms.TextBox();
            this.P1Y = new System.Windows.Forms.TextBox();
            this.P1X = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(631, 197);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 56;
            this.label12.Text = "Height";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(588, 197);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 55;
            this.label13.Text = "Width";
            // 
            // tB1
            // 
            this.tB1.Location = new System.Drawing.Point(54, 344);
            this.tB1.Multiline = true;
            this.tB1.Name = "tB1";
            this.tB1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tB1.Size = new System.Drawing.Size(677, 99);
            this.tB1.TabIndex = 54;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(553, 274);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(178, 28);
            this.button2.TabIndex = 53;
            this.button2.Text = "Найти";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(550, 137);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(196, 13);
            this.label11.TabIndex = 52;
            this.label11.Text = "координаты углов клиппинг области ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(550, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(181, 13);
            this.label10.TabIndex = 51;
            this.label10.Text = "координаты вершин треугольника";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(631, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "Y";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(588, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(550, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 48;
            this.label6.Text = "BR";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(550, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "TL";
            // 
            // BRY
            // 
            this.BRY.Location = new System.Drawing.Point(634, 214);
            this.BRY.Name = "BRY";
            this.BRY.Size = new System.Drawing.Size(37, 20);
            this.BRY.TabIndex = 46;
            this.BRY.Text = "1";
            this.BRY.TextChanged += new System.EventHandler(this.AllXYClippingChanged);
            // 
            // BRX
            // 
            this.BRX.Location = new System.Drawing.Point(591, 214);
            this.BRX.Name = "BRX";
            this.BRX.Size = new System.Drawing.Size(37, 20);
            this.BRX.TabIndex = 45;
            this.BRX.Text = "2";
            this.BRX.TextChanged += new System.EventHandler(this.AllXYClippingChanged);
            // 
            // TLY
            // 
            this.TLY.Location = new System.Drawing.Point(634, 174);
            this.TLY.Name = "TLY";
            this.TLY.Size = new System.Drawing.Size(37, 20);
            this.TLY.TabIndex = 44;
            this.TLY.Text = "2";
            this.TLY.TextChanged += new System.EventHandler(this.AllXYClippingChanged);
            // 
            // TLX
            // 
            this.TLX.Location = new System.Drawing.Point(591, 174);
            this.TLX.Name = "TLX";
            this.TLX.Size = new System.Drawing.Size(37, 20);
            this.TLX.TabIndex = 43;
            this.TLX.Text = "0";
            this.TLX.TextChanged += new System.EventHandler(this.AllXYClippingChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(631, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(588, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(550, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "P3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(550, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "P2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(550, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "P1";
            // 
            // P3Y
            // 
            this.P3Y.Location = new System.Drawing.Point(634, 103);
            this.P3Y.Name = "P3Y";
            this.P3Y.Size = new System.Drawing.Size(37, 20);
            this.P3Y.TabIndex = 37;
            this.P3Y.Text = "1";
            this.P3Y.TextChanged += new System.EventHandler(this.AllXYClippingChanged);
            // 
            // P3X
            // 
            this.P3X.Location = new System.Drawing.Point(591, 103);
            this.P3X.Name = "P3X";
            this.P3X.Size = new System.Drawing.Size(37, 20);
            this.P3X.TabIndex = 36;
            this.P3X.Text = "2";
            this.P3X.TextChanged += new System.EventHandler(this.AllXYClippingChanged);
            // 
            // P2Y
            // 
            this.P2Y.Location = new System.Drawing.Point(634, 77);
            this.P2Y.Name = "P2Y";
            this.P2Y.Size = new System.Drawing.Size(37, 20);
            this.P2Y.TabIndex = 35;
            this.P2Y.Text = "2";
            this.P2Y.TextChanged += new System.EventHandler(this.AllXYClippingChanged);
            // 
            // P2X
            // 
            this.P2X.Location = new System.Drawing.Point(591, 77);
            this.P2X.Name = "P2X";
            this.P2X.Size = new System.Drawing.Size(37, 20);
            this.P2X.TabIndex = 34;
            this.P2X.Text = "-1";
            this.P2X.TextChanged += new System.EventHandler(this.AllXYClippingChanged);
            // 
            // P1Y
            // 
            this.P1Y.Location = new System.Drawing.Point(634, 51);
            this.P1Y.Name = "P1Y";
            this.P1Y.Size = new System.Drawing.Size(37, 20);
            this.P1Y.TabIndex = 33;
            this.P1Y.Text = "1";
            this.P1Y.TextChanged += new System.EventHandler(this.AllXYClippingChanged);
            // 
            // P1X
            // 
            this.P1X.Location = new System.Drawing.Point(591, 51);
            this.P1X.Name = "P1X";
            this.P1X.Size = new System.Drawing.Size(37, 20);
            this.P1X.TabIndex = 32;
            this.P1X.Text = "-1";
            this.P1X.TextChanged += new System.EventHandler(this.AllXYClippingChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(553, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 28);
            this.button1.TabIndex = 31;
            this.button1.Text = "Построить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(54, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(480, 331);
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tB1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BRY);
            this.Controls.Add(this.BRX);
            this.Controls.Add(this.TLY);
            this.Controls.Add(this.TLX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.P3Y);
            this.Controls.Add(this.P3X);
            this.Controls.Add(this.P2Y);
            this.Controls.Add(this.P2X);
            this.Controls.Add(this.P1Y);
            this.Controls.Add(this.P1X);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "CSClipping";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tB1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox BRY;
        private System.Windows.Forms.TextBox BRX;
        private System.Windows.Forms.TextBox TLY;
        private System.Windows.Forms.TextBox TLX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox P3Y;
        private System.Windows.Forms.TextBox P3X;
        private System.Windows.Forms.TextBox P2Y;
        private System.Windows.Forms.TextBox P2X;
        private System.Windows.Forms.TextBox P1Y;
        private System.Windows.Forms.TextBox P1X;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

