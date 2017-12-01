namespace lab6
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(740, 612);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Тетраэдр",
            "Гексаэдр",
            "Октаэдр"});
			this.comboBox1.Location = new System.Drawing.Point(758, 12);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(150, 21);
			this.comboBox1.TabIndex = 2;
			this.comboBox1.Text = "Выберите фигуру";
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBox3);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Location = new System.Drawing.Point(758, 48);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(156, 177);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Сместить по:";
			// 
			// button1
			// 
			this.button1.Enabled = false;
			this.button1.Location = new System.Drawing.Point(6, 132);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(144, 35);
			this.button1.TabIndex = 4;
			this.button1.Text = "Сместить";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 99);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(22, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "OZ";
			// 
			// textBox2
			// 
			this.textBox2.Enabled = false;
			this.textBox2.Location = new System.Drawing.Point(31, 59);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(103, 20);
			this.textBox2.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(22, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "OY";
			// 
			// textBox3
			// 
			this.textBox3.Enabled = false;
			this.textBox3.Location = new System.Drawing.Point(31, 96);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(103, 20);
			this.textBox3.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "OX";
			// 
			// textBox1
			// 
			this.textBox1.Enabled = false;
			this.textBox1.Location = new System.Drawing.Point(31, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(103, 20);
			this.textBox1.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.button2);
			this.groupBox2.Controls.Add(this.textBox6);
			this.groupBox2.Controls.Add(this.textBox5);
			this.groupBox2.Controls.Add(this.textBox4);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new System.Drawing.Point(931, 48);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(156, 177);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Повернуть по:";
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(6, 132);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(144, 35);
			this.button2.TabIndex = 6;
			this.button2.Text = "Повернуть";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button2_MouseClick);
			// 
			// textBox6
			// 
			this.textBox6.Enabled = false;
			this.textBox6.Location = new System.Drawing.Point(34, 96);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(103, 20);
			this.textBox6.TabIndex = 5;
			// 
			// textBox5
			// 
			this.textBox5.Enabled = false;
			this.textBox5.Location = new System.Drawing.Point(34, 59);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(103, 20);
			this.textBox5.TabIndex = 4;
			// 
			// textBox4
			// 
			this.textBox4.Enabled = false;
			this.textBox4.Location = new System.Drawing.Point(34, 24);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(103, 20);
			this.textBox4.TabIndex = 3;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 99);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(22, 13);
			this.label6.TabIndex = 2;
			this.label6.Text = "OZ";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 62);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(22, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "OY";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 27);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(22, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "OX";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.button3);
			this.groupBox3.Controls.Add(this.textBox9);
			this.groupBox3.Controls.Add(this.textBox8);
			this.groupBox3.Controls.Add(this.textBox7);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Location = new System.Drawing.Point(758, 231);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(156, 177);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Масштабировать по:";
			// 
			// button3
			// 
			this.button3.Enabled = false;
			this.button3.Location = new System.Drawing.Point(6, 132);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(144, 35);
			this.button3.TabIndex = 9;
			this.button3.Text = "Масштабировать";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button3_MouseClick);
			// 
			// textBox9
			// 
			this.textBox9.Enabled = false;
			this.textBox9.Location = new System.Drawing.Point(34, 96);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(103, 20);
			this.textBox9.TabIndex = 8;
			// 
			// textBox8
			// 
			this.textBox8.Enabled = false;
			this.textBox8.Location = new System.Drawing.Point(34, 59);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(103, 20);
			this.textBox8.TabIndex = 7;
			// 
			// textBox7
			// 
			this.textBox7.Enabled = false;
			this.textBox7.Location = new System.Drawing.Point(34, 24);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(103, 20);
			this.textBox7.TabIndex = 6;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 99);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(22, 13);
			this.label9.TabIndex = 2;
			this.label9.Text = "OZ";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 62);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(22, 13);
			this.label8.TabIndex = 1;
			this.label8.Text = "OY";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 27);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(22, 13);
			this.label7.TabIndex = 0;
			this.label7.Text = "OX";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1105, 636);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
    }
}

