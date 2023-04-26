namespace Volkov_HW_WinForms_16
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
            this.DirectoryBox = new System.Windows.Forms.TextBox();
            this.WordBox = new System.Windows.Forms.TextBox();
            this.SearchBut = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DirectoryBox
            // 
            this.DirectoryBox.Location = new System.Drawing.Point(12, 21);
            this.DirectoryBox.Name = "DirectoryBox";
            this.DirectoryBox.Size = new System.Drawing.Size(152, 20);
            this.DirectoryBox.TabIndex = 0;
            // 
            // WordBox
            // 
            this.WordBox.Location = new System.Drawing.Point(203, 21);
            this.WordBox.Name = "WordBox";
            this.WordBox.Size = new System.Drawing.Size(152, 20);
            this.WordBox.TabIndex = 0;
            // 
            // SearchBut
            // 
            this.SearchBut.Location = new System.Drawing.Point(385, 18);
            this.SearchBut.Name = "SearchBut";
            this.SearchBut.Size = new System.Drawing.Size(75, 23);
            this.SearchBut.TabIndex = 1;
            this.SearchBut.Text = "Поиск";
            this.SearchBut.UseVisualStyleBackColor = true;
            this.SearchBut.Click += new System.EventHandler(this.SearchBut_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 48);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(447, 378);
            this.textBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.SearchBut);
            this.Controls.Add(this.WordBox);
            this.Controls.Add(this.DirectoryBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DirectoryBox;
        private System.Windows.Forms.TextBox WordBox;
        private System.Windows.Forms.Button SearchBut;
        private System.Windows.Forms.TextBox textBox1;
    }
}

