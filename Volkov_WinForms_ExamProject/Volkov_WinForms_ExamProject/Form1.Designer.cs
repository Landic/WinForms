namespace Volkov_WinForms_ExamProject
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ElementPanel = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxSearch = new System.Windows.Forms.TextBox();
            this.InformationPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SettingsPanel = new System.Windows.Forms.Panel();
            this.PanelData = new System.Windows.Forms.Panel();
            this.CancelButData = new System.Windows.Forms.Button();
            this.SaveButData = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.SetDataButton = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ChangeBoxTask = new System.Windows.Forms.TextBox();
            this.AddPanel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.EndTaskPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.TaskPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ElementPanel.SuspendLayout();
            this.panel5.SuspendLayout();
            this.InformationPanel.SuspendLayout();
            this.SettingsPanel.SuspendLayout();
            this.PanelData.SuspendLayout();
            this.panel1.SuspendLayout();
            this.AddPanel.SuspendLayout();
            this.EndTaskPanel.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ElementPanel
            // 
            this.ElementPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElementPanel.Controls.Add(this.button5);
            this.ElementPanel.Controls.Add(this.panel5);
            this.ElementPanel.Controls.Add(this.button3);
            this.ElementPanel.Controls.Add(this.button2);
            this.ElementPanel.Controls.Add(this.button1);
            this.ElementPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ElementPanel.Location = new System.Drawing.Point(0, 0);
            this.ElementPanel.Name = "ElementPanel";
            this.ElementPanel.Size = new System.Drawing.Size(205, 450);
            this.ElementPanel.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.TextBoxSearch);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(205, 68);
            this.panel5.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(4, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Search";
            // 
            // TextBoxSearch
            // 
            this.TextBoxSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.TextBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxSearch.ForeColor = System.Drawing.Color.White;
            this.TextBoxSearch.Location = new System.Drawing.Point(6, 36);
            this.TextBoxSearch.Multiline = true;
            this.TextBoxSearch.Name = "TextBoxSearch";
            this.TextBoxSearch.Size = new System.Drawing.Size(196, 20);
            this.TextBoxSearch.TabIndex = 0;
            this.TextBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // InformationPanel
            // 
            this.InformationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.InformationPanel.Controls.Add(this.pictureBox1);
            this.InformationPanel.Controls.Add(this.label2);
            this.InformationPanel.Controls.Add(this.label1);
            this.InformationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InformationPanel.Location = new System.Drawing.Point(205, 0);
            this.InformationPanel.Name = "InformationPanel";
            this.InformationPanel.Size = new System.Drawing.Size(395, 100);
            this.InformationPanel.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(122)))), ((int)(((byte)(188)))));
            this.label2.Location = new System.Drawing.Point(53, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(122)))), ((int)(((byte)(188)))));
            this.label1.Location = new System.Drawing.Point(51, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Мой день";
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SettingsPanel.Controls.Add(this.PanelData);
            this.SettingsPanel.Controls.Add(this.SetDataButton);
            this.SettingsPanel.Controls.Add(this.Delete);
            this.SettingsPanel.Controls.Add(this.panel1);
            this.SettingsPanel.Controls.Add(this.button4);
            this.SettingsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.SettingsPanel.Location = new System.Drawing.Point(600, 0);
            this.SettingsPanel.Name = "SettingsPanel";
            this.SettingsPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SettingsPanel.Size = new System.Drawing.Size(200, 450);
            this.SettingsPanel.TabIndex = 0;
            this.SettingsPanel.Visible = false;
            // 
            // PanelData
            // 
            this.PanelData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.PanelData.Controls.Add(this.CancelButData);
            this.PanelData.Controls.Add(this.SaveButData);
            this.PanelData.Controls.Add(this.monthCalendar1);
            this.PanelData.Location = new System.Drawing.Point(22, 111);
            this.PanelData.Name = "PanelData";
            this.PanelData.Size = new System.Drawing.Size(166, 196);
            this.PanelData.TabIndex = 4;
            this.PanelData.Visible = false;
            // 
            // CancelButData
            // 
            this.CancelButData.FlatAppearance.BorderSize = 0;
            this.CancelButData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButData.ForeColor = System.Drawing.Color.Gainsboro;
            this.CancelButData.Location = new System.Drawing.Point(0, 170);
            this.CancelButData.Name = "CancelButData";
            this.CancelButData.Size = new System.Drawing.Size(75, 23);
            this.CancelButData.TabIndex = 4;
            this.CancelButData.Text = "Отмена";
            this.CancelButData.UseVisualStyleBackColor = true;
            this.CancelButData.Click += new System.EventHandler(this.CancelButData_Click);
            // 
            // SaveButData
            // 
            this.SaveButData.FlatAppearance.BorderSize = 0;
            this.SaveButData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButData.ForeColor = System.Drawing.Color.Gainsboro;
            this.SaveButData.Location = new System.Drawing.Point(88, 170);
            this.SaveButData.Name = "SaveButData";
            this.SaveButData.Size = new System.Drawing.Size(75, 23);
            this.SaveButData.TabIndex = 4;
            this.SaveButData.Text = "Сохранить";
            this.SaveButData.UseVisualStyleBackColor = true;
            this.SaveButData.Click += new System.EventHandler(this.SaveButData_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.Color.White;
            this.monthCalendar1.Location = new System.Drawing.Point(0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 3;
            // 
            // SetDataButton
            // 
            this.SetDataButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.SetDataButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SetDataButton.FlatAppearance.BorderSize = 0;
            this.SetDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetDataButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.SetDataButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SetDataButton.Location = new System.Drawing.Point(0, 79);
            this.SetDataButton.Name = "SetDataButton";
            this.SetDataButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SetDataButton.Size = new System.Drawing.Size(200, 32);
            this.SetDataButton.TabIndex = 2;
            this.SetDataButton.Text = "Добавить дату выполнения";
            this.SetDataButton.UseVisualStyleBackColor = false;
            this.SetDataButton.Click += new System.EventHandler(this.SetDataButton_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Delete.FlatAppearance.BorderSize = 0;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.ForeColor = System.Drawing.Color.Gainsboro;
            this.Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Delete.Location = new System.Drawing.Point(0, 117);
            this.Delete.Name = "Delete";
            this.Delete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Delete.Size = new System.Drawing.Size(200, 32);
            this.Delete.TabIndex = 2;
            this.Delete.Text = "Удалить";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.panel1.Controls.Add(this.ChangeBoxTask);
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 32);
            this.panel1.TabIndex = 1;
            // 
            // ChangeBoxTask
            // 
            this.ChangeBoxTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.ChangeBoxTask.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChangeBoxTask.ForeColor = System.Drawing.Color.White;
            this.ChangeBoxTask.Location = new System.Drawing.Point(34, 10);
            this.ChangeBoxTask.Name = "ChangeBoxTask";
            this.ChangeBoxTask.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ChangeBoxTask.Size = new System.Drawing.Size(127, 13);
            this.ChangeBoxTask.TabIndex = 0;
            this.ChangeBoxTask.TextChanged += new System.EventHandler(this.ChangeBoxTask_TextChanged);
            // 
            // AddPanel
            // 
            this.AddPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.AddPanel.Controls.Add(this.textBox1);
            this.AddPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AddPanel.Location = new System.Drawing.Point(205, 397);
            this.AddPanel.Name = "AddPanel";
            this.AddPanel.Size = new System.Drawing.Size(395, 53);
            this.AddPanel.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(6, 6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.Size = new System.Drawing.Size(577, 35);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // EndTaskPanel
            // 
            this.EndTaskPanel.AutoScroll = true;
            this.EndTaskPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.EndTaskPanel.Controls.Add(this.label4);
            this.EndTaskPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EndTaskPanel.Location = new System.Drawing.Point(205, 253);
            this.EndTaskPanel.Name = "EndTaskPanel";
            this.EndTaskPanel.Size = new System.Drawing.Size(395, 144);
            this.EndTaskPanel.TabIndex = 3;
            this.EndTaskPanel.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Завершенные задачи:";
            // 
            // TaskPanel
            // 
            this.TaskPanel.AutoScroll = true;
            this.TaskPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.TaskPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskPanel.Location = new System.Drawing.Point(205, 100);
            this.TaskPanel.Name = "TaskPanel";
            this.TaskPanel.Size = new System.Drawing.Size(395, 153);
            this.TaskPanel.TabIndex = 4;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip2;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "To Do";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(121, 26);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 32);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(168, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(20, 20);
            this.button4.TabIndex = 0;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::Volkov_WinForms_ExamProject.Properties.Resources.Dark_Theam_Ico;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(0, 416);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(34, 34);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.button3.ForeColor = System.Drawing.Color.Gainsboro;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(0, 135);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(205, 32);
            this.button3.TabIndex = 2;
            this.button3.Text = "Задачи";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.button2.ForeColor = System.Drawing.Color.Gainsboro;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(205, 32);
            this.button2.TabIndex = 1;
            this.button2.Text = "Важно";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.Gainsboro;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 74);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(205, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Мой день";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TaskPanel);
            this.Controls.Add(this.EndTaskPanel);
            this.Controls.Add(this.AddPanel);
            this.Controls.Add(this.InformationPanel);
            this.Controls.Add(this.SettingsPanel);
            this.Controls.Add(this.ElementPanel);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "To Do";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ElementPanel.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.InformationPanel.ResumeLayout(false);
            this.InformationPanel.PerformLayout();
            this.SettingsPanel.ResumeLayout(false);
            this.PanelData.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.AddPanel.ResumeLayout(false);
            this.AddPanel.PerformLayout();
            this.EndTaskPanel.ResumeLayout(false);
            this.EndTaskPanel.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ElementPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel SettingsPanel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel InformationPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel AddPanel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxSearch;
        private System.Windows.Forms.Panel EndTaskPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel TaskPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox ChangeBoxTask;
        private System.Windows.Forms.Button SetDataButton;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Panel PanelData;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button CancelButData;
        private System.Windows.Forms.Button SaveButData;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.Button button5;
    }
}

