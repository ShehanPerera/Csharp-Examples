namespace PasswordShowHideEncrptDecrpt
{
    partial class PasswordForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.encryptBox = new System.Windows.Forms.TextBox();
            this.decryptBox = new System.Windows.Forms.TextBox();
            this.show = new System.Windows.Forms.CheckBox();
            this.Decrpt = new System.Windows.Forms.Button();
            this.Encrpt = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Password :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Encrpt :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Decrpt :";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(88, 27);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(100, 20);
            this.passwordBox.TabIndex = 3;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // encryptBox
            // 
            this.encryptBox.Location = new System.Drawing.Point(88, 60);
            this.encryptBox.Name = "encryptBox";
            this.encryptBox.Size = new System.Drawing.Size(100, 20);
            this.encryptBox.TabIndex = 4;
            // 
            // decryptBox
            // 
            this.decryptBox.Location = new System.Drawing.Point(88, 90);
            this.decryptBox.Name = "decryptBox";
            this.decryptBox.Size = new System.Drawing.Size(100, 20);
            this.decryptBox.TabIndex = 5;
            // 
            // show
            // 
            this.show.AutoSize = true;
            this.show.Location = new System.Drawing.Point(247, 26);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(53, 17);
            this.show.TabIndex = 6;
            this.show.Text = "Show";
            this.show.UseVisualStyleBackColor = true;
            this.show.CheckedChanged += new System.EventHandler(this.show_CheckedChanged);
            // 
            // Decrpt
            // 
            this.Decrpt.Location = new System.Drawing.Point(247, 90);
            this.Decrpt.Name = "Decrpt";
            this.Decrpt.Size = new System.Drawing.Size(75, 23);
            this.Decrpt.TabIndex = 7;
            this.Decrpt.Text = "Decrpt";
            this.Decrpt.UseVisualStyleBackColor = true;
            this.Decrpt.Click += new System.EventHandler(this.Decrpt_Click);
            // 
            // Encrpt
            // 
            this.Encrpt.Location = new System.Drawing.Point(247, 57);
            this.Encrpt.Name = "Encrpt";
            this.Encrpt.Size = new System.Drawing.Size(75, 23);
            this.Encrpt.TabIndex = 8;
            this.Encrpt.Text = "Encrpt";
            this.Encrpt.UseVisualStyleBackColor = true;
            this.Encrpt.Click += new System.EventHandler(this.Encrpt_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(158, 125);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(75, 23);
            this.aboutButton.TabIndex = 9;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.about_Click);
            // 
            // PasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(387, 160);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.Encrpt);
            this.Controls.Add(this.Decrpt);
            this.Controls.Add(this.show);
            this.Controls.Add(this.decryptBox);
            this.Controls.Add(this.encryptBox);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PasswordForm";
            this.Text = "Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox encryptBox;
        private System.Windows.Forms.TextBox decryptBox;
        private System.Windows.Forms.CheckBox show;
        private System.Windows.Forms.Button Decrpt;
        private System.Windows.Forms.Button Encrpt;
        private System.Windows.Forms.Button aboutButton;
    }
}

