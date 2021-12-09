
namespace dynamic_balancing_machine
{
    partial class MachineControlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachineControlForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.mode = new System.Windows.Forms.Label();
            this.StepProcess = new System.Windows.Forms.ProgressBar();
            this.PanelProcess = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataAcquisiton = new System.Windows.Forms.Label();
            this.calculator = new System.Windows.Forms.Label();
            this.step4 = new System.Windows.Forms.PictureBox();
            this.step3 = new System.Windows.Forms.PictureBox();
            this.step2 = new System.Windows.Forms.PictureBox();
            this.step1 = new System.Windows.Forms.PictureBox();
            this.ptBoxMinimize = new System.Windows.Forms.PictureBox();
            this.ptBoxClose = new System.Windows.Forms.PictureBox();
            this.ptBoxMaximize = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.step4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.step3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.step2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.step1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptBoxMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptBoxMaximize)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.pnlNav);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 800);
            this.panel1.TabIndex = 0;
            this.panel1.UseWaitCursor = true;
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(190)))), ((int)(((byte)(214)))));
            this.pnlNav.Location = new System.Drawing.Point(0, 181);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(7, 70);
            this.pnlNav.TabIndex = 2;
            this.pnlNav.UseWaitCursor = true;
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(133)))), ((int)(((byte)(139)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(0, 527);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(212, 47);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.UseWaitCursor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.Leave += new System.EventHandler(this.btnExit_Leave);
            // 
            // btnHome
            // 
            this.btnHome.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(133)))), ((int)(((byte)(139)))));
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Location = new System.Drawing.Point(0, 129);
            this.btnHome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(212, 47);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.UseWaitCursor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            this.btnHome.Leave += new System.EventHandler(this.btnHome_Leave);
            // 
            // mode
            // 
            this.mode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mode.AutoSize = true;
            this.mode.Font = new System.Drawing.Font("Bahnschrift Condensed", 16F);
            this.mode.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.mode.Location = new System.Drawing.Point(228, 201);
            this.mode.Name = "mode";
            this.mode.Size = new System.Drawing.Size(89, 27);
            this.mode.TabIndex = 2;
            this.mode.Text = "Chọn Mode";
            this.mode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mode.UseWaitCursor = true;
            // 
            // StepProcess
            // 
            this.StepProcess.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StepProcess.Enabled = false;
            this.StepProcess.Location = new System.Drawing.Point(250, 150);
            this.StepProcess.Name = "StepProcess";
            this.StepProcess.Size = new System.Drawing.Size(912, 7);
            this.StepProcess.TabIndex = 7;
            this.StepProcess.UseWaitCursor = true;
            // 
            // PanelProcess
            // 
            this.PanelProcess.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PanelProcess.Location = new System.Drawing.Point(250, 290);
            this.PanelProcess.Name = "PanelProcess";
            this.PanelProcess.Size = new System.Drawing.Size(912, 420);
            this.PanelProcess.TabIndex = 8;
            this.PanelProcess.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 16F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(1095, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 27);
            this.label1.TabIndex = 9;
            this.label1.Text = "Chọn Mode";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseWaitCursor = true;
            // 
            // dataAcquisiton
            // 
            this.dataAcquisiton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataAcquisiton.AutoSize = true;
            this.dataAcquisiton.Font = new System.Drawing.Font("Bahnschrift Condensed", 16F);
            this.dataAcquisiton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.dataAcquisiton.Location = new System.Drawing.Point(497, 201);
            this.dataAcquisiton.Name = "dataAcquisiton";
            this.dataAcquisiton.Size = new System.Drawing.Size(129, 27);
            this.dataAcquisiton.TabIndex = 10;
            this.dataAcquisiton.Text = "Thu thập dữ liệu";
            this.dataAcquisiton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dataAcquisiton.UseWaitCursor = true;
            // 
            // calculator
            // 
            this.calculator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.calculator.AutoSize = true;
            this.calculator.Font = new System.Drawing.Font("Bahnschrift Condensed", 16F);
            this.calculator.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.calculator.Location = new System.Drawing.Point(776, 201);
            this.calculator.Name = "calculator";
            this.calculator.Size = new System.Drawing.Size(148, 27);
            this.calculator.TabIndex = 11;
            this.calculator.Text = "Tính toán cân bằng";
            this.calculator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.calculator.UseWaitCursor = true;
            // 
            // step4
            // 
            this.step4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.step4.Enabled = false;
            this.step4.Image = global::dynamic_balancing_machine.Properties.Resources.Pending;
            this.step4.Location = new System.Drawing.Point(1117, 131);
            this.step4.Name = "step4";
            this.step4.Size = new System.Drawing.Size(45, 45);
            this.step4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.step4.TabIndex = 5;
            this.step4.TabStop = false;
            this.step4.UseWaitCursor = true;
            // 
            // step3
            // 
            this.step3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.step3.Enabled = false;
            this.step3.Image = global::dynamic_balancing_machine.Properties.Resources.Pending;
            this.step3.Location = new System.Drawing.Point(828, 131);
            this.step3.Name = "step3";
            this.step3.Size = new System.Drawing.Size(45, 45);
            this.step3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.step3.TabIndex = 5;
            this.step3.TabStop = false;
            this.step3.UseWaitCursor = true;
            // 
            // step2
            // 
            this.step2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.step2.Enabled = false;
            this.step2.Image = global::dynamic_balancing_machine.Properties.Resources.Pending;
            this.step2.Location = new System.Drawing.Point(539, 131);
            this.step2.Name = "step2";
            this.step2.Size = new System.Drawing.Size(45, 45);
            this.step2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.step2.TabIndex = 3;
            this.step2.TabStop = false;
            this.step2.UseWaitCursor = true;
            // 
            // step1
            // 
            this.step1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.step1.Enabled = false;
            this.step1.Image = global::dynamic_balancing_machine.Properties.Resources.Current;
            this.step1.Location = new System.Drawing.Point(250, 131);
            this.step1.Name = "step1";
            this.step1.Size = new System.Drawing.Size(45, 45);
            this.step1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.step1.TabIndex = 1;
            this.step1.TabStop = false;
            this.step1.UseWaitCursor = true;
            // 
            // ptBoxMinimize
            // 
            this.ptBoxMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptBoxMinimize.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.ptBoxMinimize.Image = ((System.Drawing.Image)(resources.GetObject("ptBoxMinimize.Image")));
            this.ptBoxMinimize.Location = new System.Drawing.Point(1100, 12);
            this.ptBoxMinimize.Name = "ptBoxMinimize";
            this.ptBoxMinimize.Size = new System.Drawing.Size(25, 25);
            this.ptBoxMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptBoxMinimize.TabIndex = 15;
            this.ptBoxMinimize.TabStop = false;
            this.ptBoxMinimize.UseWaitCursor = true;
            this.ptBoxMinimize.Click += new System.EventHandler(this.ptBoxMinimize_Click_1);
            // 
            // ptBoxClose
            // 
            this.ptBoxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptBoxClose.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.ptBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("ptBoxClose.Image")));
            this.ptBoxClose.Location = new System.Drawing.Point(1163, 12);
            this.ptBoxClose.Name = "ptBoxClose";
            this.ptBoxClose.Size = new System.Drawing.Size(25, 25);
            this.ptBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptBoxClose.TabIndex = 16;
            this.ptBoxClose.TabStop = false;
            this.ptBoxClose.UseWaitCursor = true;
            this.ptBoxClose.Click += new System.EventHandler(this.ptBoxClose_Click);
            // 
            // ptBoxMaximize
            // 
            this.ptBoxMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptBoxMaximize.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.ptBoxMaximize.Image = global::dynamic_balancing_machine.Properties.Resources.maximize;
            this.ptBoxMaximize.Location = new System.Drawing.Point(1131, 12);
            this.ptBoxMaximize.Name = "ptBoxMaximize";
            this.ptBoxMaximize.Size = new System.Drawing.Size(25, 25);
            this.ptBoxMaximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptBoxMaximize.TabIndex = 17;
            this.ptBoxMaximize.TabStop = false;
            this.ptBoxMaximize.UseWaitCursor = true;
            this.ptBoxMaximize.Click += new System.EventHandler(this.ptBoxMaximize_Click);
            // 
            // MachineControlForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.ptBoxMaximize);
            this.Controls.Add(this.ptBoxClose);
            this.Controls.Add(this.ptBoxMinimize);
            this.Controls.Add(this.calculator);
            this.Controls.Add(this.dataAcquisiton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PanelProcess);
            this.Controls.Add(this.step4);
            this.Controls.Add(this.step3);
            this.Controls.Add(this.step2);
            this.Controls.Add(this.mode);
            this.Controls.Add(this.step1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.StepProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MachineControlForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MachineControlForm";
            this.TopMost = true;
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.MachineControlForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MachineControlForm_MouseDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.step4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.step3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.step2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.step1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptBoxMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptBoxMaximize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox step1;
        private System.Windows.Forms.Label mode;
        private System.Windows.Forms.PictureBox step2;
        private System.Windows.Forms.PictureBox step3;
        private System.Windows.Forms.PictureBox step4;
        private System.Windows.Forms.ProgressBar StepProcess;
        private System.Windows.Forms.Panel PanelProcess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label dataAcquisiton;
        private System.Windows.Forms.Label calculator;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.PictureBox ptBoxMinimize;
        private System.Windows.Forms.PictureBox ptBoxClose;
        private System.Windows.Forms.PictureBox ptBoxMaximize;
    }
}