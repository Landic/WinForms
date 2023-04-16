namespace Volkov_HW_WinForms_8
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.играToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.административныйРежимToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Clue3 = new System.Windows.Forms.Button();
            this.Clue2 = new System.Windows.Forms.Button();
            this.Clue1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Stop = new System.Windows.Forms.Button();
            this.Question = new System.Windows.Forms.TextBox();
            this.Answer1 = new System.Windows.Forms.Button();
            this.Answer2 = new System.Windows.Forms.Button();
            this.Answer4 = new System.Windows.Forms.Button();
            this.Answer3 = new System.Windows.Forms.Button();
            this.PhonedFriend = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.progressBar4 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhonedFriend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.играToolStripMenuItem,
            this.административныйРежимToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(793, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // играToolStripMenuItem
            // 
            this.играToolStripMenuItem.Name = "играToolStripMenuItem";
            this.играToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.играToolStripMenuItem.Text = "Игра";
            this.играToolStripMenuItem.Click += new System.EventHandler(this.GameToolStripMenuItem_Click);
            // 
            // административныйРежимToolStripMenuItem
            // 
            this.административныйРежимToolStripMenuItem.Name = "административныйРежимToolStripMenuItem";
            this.административныйРежимToolStripMenuItem.Size = new System.Drawing.Size(169, 20);
            this.административныйРежимToolStripMenuItem.Text = "Административный режим";
            this.административныйРежимToolStripMenuItem.Click += new System.EventHandler(this.AdministationToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.ProgrammToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Controls.Add(this.Clue3);
            this.groupBox1.Controls.Add(this.Clue2);
            this.groupBox1.Controls.Add(this.Clue1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(585, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 73);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Подсказки";
            // 
            // Clue3
            // 
            this.Clue3.BackColor = System.Drawing.SystemColors.Desktop;
            this.Clue3.Image = global::Volkov_HW_WinForms_8.Properties.Resources._3;
            this.Clue3.Location = new System.Drawing.Point(141, 19);
            this.Clue3.Name = "Clue3";
            this.Clue3.Size = new System.Drawing.Size(55, 37);
            this.Clue3.TabIndex = 0;
            this.Clue3.UseVisualStyleBackColor = false;
            this.Clue3.Click += new System.EventHandler(this.Clue3_Click);
            // 
            // Clue2
            // 
            this.Clue2.BackColor = System.Drawing.SystemColors.Desktop;
            this.Clue2.Image = global::Volkov_HW_WinForms_8.Properties.Resources._2;
            this.Clue2.Location = new System.Drawing.Point(73, 19);
            this.Clue2.Name = "Clue2";
            this.Clue2.Size = new System.Drawing.Size(55, 37);
            this.Clue2.TabIndex = 0;
            this.Clue2.UseVisualStyleBackColor = false;
            this.Clue2.Click += new System.EventHandler(this.Clue2_Click);
            // 
            // Clue1
            // 
            this.Clue1.BackColor = System.Drawing.SystemColors.Desktop;
            this.Clue1.Image = global::Volkov_HW_WinForms_8.Properties.Resources._1;
            this.Clue1.Location = new System.Drawing.Point(6, 19);
            this.Clue1.Name = "Clue1";
            this.Clue1.Size = new System.Drawing.Size(55, 37);
            this.Clue1.TabIndex = 0;
            this.Clue1.UseVisualStyleBackColor = false;
            this.Clue1.Click += new System.EventHandler(this.Clue1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Location = new System.Drawing.Point(605, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 491);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Enabled = false;
            this.listBox1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.ForeColor = System.Drawing.Color.Yellow;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 27;
            this.listBox1.Location = new System.Drawing.Point(6, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(176, 432);
            this.listBox1.TabIndex = 6;
            this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            // 
            // Stop
            // 
            this.Stop.BackColor = System.Drawing.Color.Black;
            this.Stop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Stop.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Stop.ForeColor = System.Drawing.Color.Yellow;
            this.Stop.Location = new System.Drawing.Point(154, 24);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(138, 41);
            this.Stop.TabIndex = 3;
            this.Stop.Text = "СТОП";
            this.Stop.UseVisualStyleBackColor = false;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Question
            // 
            this.Question.BackColor = System.Drawing.SystemColors.MenuText;
            this.Question.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Question.ForeColor = System.Drawing.Color.Yellow;
            this.Question.Location = new System.Drawing.Point(12, 360);
            this.Question.Multiline = true;
            this.Question.Name = "Question";
            this.Question.ReadOnly = true;
            this.Question.Size = new System.Drawing.Size(587, 54);
            this.Question.TabIndex = 4;
            // 
            // Answer1
            // 
            this.Answer1.BackColor = System.Drawing.SystemColors.ControlText;
            this.Answer1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Answer1.ForeColor = System.Drawing.Color.Yellow;
            this.Answer1.Location = new System.Drawing.Point(13, 421);
            this.Answer1.Name = "Answer1";
            this.Answer1.Size = new System.Drawing.Size(280, 43);
            this.Answer1.TabIndex = 5;
            this.Answer1.Text = "button7";
            this.Answer1.UseVisualStyleBackColor = false;
            this.Answer1.Click += new System.EventHandler(this.Answer1_Click);
            // 
            // Answer2
            // 
            this.Answer2.BackColor = System.Drawing.SystemColors.Desktop;
            this.Answer2.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Answer2.ForeColor = System.Drawing.Color.Yellow;
            this.Answer2.Location = new System.Drawing.Point(12, 501);
            this.Answer2.Name = "Answer2";
            this.Answer2.Size = new System.Drawing.Size(280, 43);
            this.Answer2.TabIndex = 5;
            this.Answer2.Text = "button7";
            this.Answer2.UseVisualStyleBackColor = false;
            this.Answer2.Click += new System.EventHandler(this.Answer2_Click);
            // 
            // Answer4
            // 
            this.Answer4.BackColor = System.Drawing.SystemColors.Desktop;
            this.Answer4.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Answer4.ForeColor = System.Drawing.Color.Yellow;
            this.Answer4.Location = new System.Drawing.Point(319, 501);
            this.Answer4.Name = "Answer4";
            this.Answer4.Size = new System.Drawing.Size(280, 43);
            this.Answer4.TabIndex = 5;
            this.Answer4.Text = "button7";
            this.Answer4.UseVisualStyleBackColor = false;
            this.Answer4.Click += new System.EventHandler(this.Answer4_Click);
            // 
            // Answer3
            // 
            this.Answer3.BackColor = System.Drawing.SystemColors.Desktop;
            this.Answer3.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Answer3.ForeColor = System.Drawing.Color.Yellow;
            this.Answer3.Location = new System.Drawing.Point(319, 421);
            this.Answer3.Name = "Answer3";
            this.Answer3.Size = new System.Drawing.Size(280, 43);
            this.Answer3.TabIndex = 5;
            this.Answer3.Text = "button7";
            this.Answer3.UseVisualStyleBackColor = false;
            this.Answer3.Click += new System.EventHandler(this.Answer3_Click);
            // 
            // PhonedFriend
            // 
            this.PhonedFriend.Image = global::Volkov_HW_WinForms_8.Properties.Resources.zvonok;
            this.PhonedFriend.Location = new System.Drawing.Point(12, 108);
            this.PhonedFriend.Name = "PhonedFriend";
            this.PhonedFriend.Size = new System.Drawing.Size(134, 107);
            this.PhonedFriend.TabIndex = 6;
            this.PhonedFriend.TabStop = false;
            this.PhonedFriend.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Image = global::Volkov_HW_WinForms_8.Properties.Resources.Exit;
            this.button2.Location = new System.Drawing.Point(68, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 41);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Image = global::Volkov_HW_WinForms_8.Properties.Resources._new;
            this.button1.Location = new System.Drawing.Point(1, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 41);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Volkov_HW_WinForms_8.Properties.Resources.mil;
            this.pictureBox1.InitialImage = global::Volkov_HW_WinForms_8.Properties.Resources.mil;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(793, 556);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.Color.Yellow;
            this.textBox1.Location = new System.Drawing.Point(153, 166);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(155, 48);
            this.textBox1.TabIndex = 7;
            this.textBox1.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Black;
            this.groupBox3.Controls.Add(this.progressBar4);
            this.groupBox3.Controls.Add(this.progressBar3);
            this.groupBox3.Controls.Add(this.progressBar2);
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox3.Location = new System.Drawing.Point(434, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(151, 88);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Зрители";
            this.groupBox3.Visible = false;
            // 
            // progressBar4
            // 
            this.progressBar4.Location = new System.Drawing.Point(6, 67);
            this.progressBar4.Name = "progressBar4";
            this.progressBar4.Size = new System.Drawing.Size(100, 10);
            this.progressBar4.TabIndex = 0;
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(6, 51);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(100, 10);
            this.progressBar3.TabIndex = 0;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(6, 35);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(100, 10);
            this.progressBar2.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 19);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 10);
            this.progressBar1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 580);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.PhonedFriend);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Answer3);
            this.Controls.Add(this.Answer4);
            this.Controls.Add(this.Answer2);
            this.Controls.Add(this.Answer1);
            this.Controls.Add(this.Question);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PhonedFriend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem играToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem административныйРежимToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Clue1;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button Clue3;
        private System.Windows.Forms.Button Clue2;
        private System.Windows.Forms.TextBox Question;
        private System.Windows.Forms.Button Answer1;
        private System.Windows.Forms.Button Answer2;
        private System.Windows.Forms.Button Answer4;
        private System.Windows.Forms.Button Answer3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox PhonedFriend;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar progressBar4;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

