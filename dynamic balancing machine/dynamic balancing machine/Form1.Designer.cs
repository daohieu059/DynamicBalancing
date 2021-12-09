
namespace dynamic_balancing_machine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tBoxUser = new System.Windows.Forms.TextBox();
            this.tBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelExit = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cBoxShowPass = new System.Windows.Forms.CheckBox();
            this.lblError = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ptBoxMinimize = new System.Windows.Forms.PictureBox();
            this.ptBoxClose = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptBoxMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptBoxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // tBoxUser
            // 
            this.tBoxUser.AcceptsReturn = true;
            this.tBoxUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.tBoxUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxUser.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxUser.ForeColor = System.Drawing.Color.DarkGray;
            this.tBoxUser.Location = new System.Drawing.Point(33, 8);
            this.tBoxUser.Name = "tBoxUser";
            this.tBoxUser.Size = new System.Drawing.Size(254, 23);
            this.tBoxUser.TabIndex = 3;
            this.tBoxUser.Text = "Username";
            this.tBoxUser.Enter += new System.EventHandler(this.tBoxUser_Enter);
            this.tBoxUser.Leave += new System.EventHandler(this.tBoxUser_Leave);
            // 
            // tBoxPassword
            // 
            this.tBoxPassword.AcceptsReturn = true;
            this.tBoxPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.tBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxPassword.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F);
            this.tBoxPassword.ForeColor = System.Drawing.Color.DarkGray;
            this.tBoxPassword.Location = new System.Drawing.Point(33, 8);
            this.tBoxPassword.Name = "tBoxPassword";
            this.tBoxPassword.Size = new System.Drawing.Size(254, 23);
            this.tBoxPassword.TabIndex = 3;
            this.tBoxPassword.Text = "Password";
            this.tBoxPassword.Enter += new System.EventHandler(this.tBoxPassword_Enter);
            this.tBoxPassword.Leave += new System.EventHandler(this.tBoxPassword_Leave);
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(199)))));
            this.buttonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLogin.FlatAppearance.BorderSize = 0;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(362, 435);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(304, 40);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "LOG IN";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // labelExit
            // 
            this.labelExit.AutoSize = true;
            this.labelExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelExit.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExit.ForeColor = System.Drawing.Color.White;
            this.labelExit.Location = new System.Drawing.Point(492, 489);
            this.labelExit.Name = "labelExit";
            this.labelExit.Size = new System.Drawing.Size(37, 19);
            this.labelExit.TabIndex = 5;
            this.labelExit.Text = "EXIT";
            this.labelExit.Click += new System.EventHandler(this.labelExit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.tBoxUser);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(362, 248);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 40);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.tBoxPassword);
            this.panel2.Location = new System.Drawing.Point(362, 302);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(304, 40);
            this.panel2.TabIndex = 7;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(27, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(62, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(42)))));
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(305, 650);
            this.panel3.TabIndex = 8;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(459, 76);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(110, 110);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(476, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "LOG IN";
            // 
            // cBoxShowPass
            // 
            this.cBoxShowPass.AutoSize = true;
            this.cBoxShowPass.BackColor = System.Drawing.Color.Transparent;
            this.cBoxShowPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cBoxShowPass.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxShowPass.ForeColor = System.Drawing.Color.White;
            this.cBoxShowPass.Location = new System.Drawing.Point(362, 345);
            this.cBoxShowPass.Name = "cBoxShowPass";
            this.cBoxShowPass.Size = new System.Drawing.Size(112, 23);
            this.cBoxShowPass.TabIndex = 10;
            this.cBoxShowPass.Text = "Show Password";
            this.cBoxShowPass.UseVisualStyleBackColor = false;
            this.cBoxShowPass.CheckedChanged += new System.EventHandler(this.cBoxShowPass_CheckedChanged);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblError.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblError.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.DarkGray;
            this.lblError.Image = ((System.Drawing.Image)(resources.GetObject("lblError.Image")));
            this.lblError.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblError.Location = new System.Drawing.Point(358, 377);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(119, 19);
            this.lblError.TabIndex = 11;
            this.lblError.Text = "    Error massage";
            this.lblError.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(0, 34);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(304, 3);
            this.panel4.TabIndex = 12;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(0, 33);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(304, 3);
            this.panel5.TabIndex = 12;
            // 
            // ptBoxMinimize
            // 
            this.ptBoxMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptBoxMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptBoxMinimize.Image = ((System.Drawing.Image)(resources.GetObject("ptBoxMinimize.Image")));
            this.ptBoxMinimize.Location = new System.Drawing.Point(652, 12);
            this.ptBoxMinimize.Name = "ptBoxMinimize";
            this.ptBoxMinimize.Size = new System.Drawing.Size(25, 25);
            this.ptBoxMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptBoxMinimize.TabIndex = 13;
            this.ptBoxMinimize.TabStop = false;
            this.ptBoxMinimize.Click += new System.EventHandler(this.ptBoxMinimize_Click);
            // 
            // ptBoxClose
            // 
            this.ptBoxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("ptBoxClose.Image")));
            this.ptBoxClose.Location = new System.Drawing.Point(683, 12);
            this.ptBoxClose.Name = "ptBoxClose";
            this.ptBoxClose.Size = new System.Drawing.Size(25, 25);
            this.ptBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptBoxClose.TabIndex = 14;
            this.ptBoxClose.TabStop = false;
            this.ptBoxClose.Click += new System.EventHandler(this.ptBoxClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(720, 650);
            this.Controls.Add(this.ptBoxClose);
            this.Controls.Add(this.ptBoxMinimize);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.cBoxShowPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelExit);
            this.Controls.Add(this.buttonLogin);
            this.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptBoxMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptBoxClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox tBoxUser;
        private System.Windows.Forms.TextBox tBoxPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cBoxShowPass;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox ptBoxMinimize;
        private System.Windows.Forms.PictureBox ptBoxClose;
    }
}

