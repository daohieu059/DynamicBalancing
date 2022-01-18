
namespace dynamic_balancing_machine.User_control
{
    partial class DataAcquisition
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BackButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.maximumValueNumeric = new System.Windows.Forms.NumericUpDown();
            this.minimumValueNumeric = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PhysicalChannelrButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rateNumeric = new System.Windows.Forms.NumericUpDown();
            this.samplesPerChannelNumeric = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSpeed = new System.Windows.Forms.Button();
            this.txtBoxrateobject = new System.Windows.Forms.TextBox();
            this.txtBoxnumericSpeed = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.zedAcquisition = new ZedGraph.ZedGraphControl();
            this.acquisitionDataGrid = new System.Windows.Forms.DataGrid();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblmode = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maximumValueNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumValueNumeric)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.samplesPerChannelNumeric)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acquisitionDataGrid)).BeginInit();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.FlatAppearance.BorderSize = 0;
            this.BackButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(190)))), ((int)(((byte)(214)))));
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F);
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(0, 599);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(159, 51);
            this.BackButton.TabIndex = 2;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.NextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextButton.FlatAppearance.BorderSize = 0;
            this.NextButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(190)))), ((int)(((byte)(214)))));
            this.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextButton.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F);
            this.NextButton.ForeColor = System.Drawing.Color.White;
            this.NextButton.Location = new System.Drawing.Point(821, 599);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(159, 51);
            this.NextButton.TabIndex = 3;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = false;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.maximumValueNumeric);
            this.panel1.Controls.Add(this.minimumValueNumeric);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.PhysicalChannelrButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(2, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 167);
            this.panel1.TabIndex = 0;
            // 
            // maximumValueNumeric
            // 
            this.maximumValueNumeric.DecimalPlaces = 2;
            this.maximumValueNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maximumValueNumeric.Location = new System.Drawing.Point(139, 134);
            this.maximumValueNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.maximumValueNumeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.maximumValueNumeric.Name = "maximumValueNumeric";
            this.maximumValueNumeric.Size = new System.Drawing.Size(90, 22);
            this.maximumValueNumeric.TabIndex = 13;
            this.maximumValueNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // minimumValueNumeric
            // 
            this.minimumValueNumeric.DecimalPlaces = 2;
            this.minimumValueNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimumValueNumeric.Location = new System.Drawing.Point(139, 100);
            this.minimumValueNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.minimumValueNumeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.minimumValueNumeric.Name = "minimumValueNumeric";
            this.minimumValueNumeric.Size = new System.Drawing.Size(90, 22);
            this.minimumValueNumeric.TabIndex = 13;
            this.minimumValueNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Maximum Value(V):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Minimum Value(V):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PhysicalChannelrButton
            // 
            this.PhysicalChannelrButton.AutoSize = true;
            this.PhysicalChannelrButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PhysicalChannelrButton.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhysicalChannelrButton.ForeColor = System.Drawing.Color.Black;
            this.PhysicalChannelrButton.Location = new System.Drawing.Point(130, 56);
            this.PhysicalChannelrButton.Name = "PhysicalChannelrButton";
            this.PhysicalChannelrButton.Size = new System.Drawing.Size(135, 21);
            this.PhysicalChannelrButton.TabIndex = 11;
            this.PhysicalChannelrButton.Text = "Physical Channel";
            this.PhysicalChannelrButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Physical Channel:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 33);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 33);
            this.label1.TabIndex = 9;
            this.label1.Text = "Channel Parameters";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.rateNumeric);
            this.panel3.Controls.Add(this.samplesPerChannelNumeric);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(2, 325);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(268, 112);
            this.panel3.TabIndex = 14;
            // 
            // rateNumeric
            // 
            this.rateNumeric.DecimalPlaces = 2;
            this.rateNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rateNumeric.Location = new System.Drawing.Point(143, 73);
            this.rateNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.rateNumeric.Name = "rateNumeric";
            this.rateNumeric.Size = new System.Drawing.Size(90, 22);
            this.rateNumeric.TabIndex = 13;
            this.rateNumeric.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // samplesPerChannelNumeric
            // 
            this.samplesPerChannelNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.samplesPerChannelNumeric.Location = new System.Drawing.Point(143, 39);
            this.samplesPerChannelNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.samplesPerChannelNumeric.Name = "samplesPerChannelNumeric";
            this.samplesPerChannelNumeric.Size = new System.Drawing.Size(90, 22);
            this.samplesPerChannelNumeric.TabIndex = 13;
            this.samplesPerChannelNumeric.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(3, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Rate (Hz):";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(3, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Samples/Channel:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.label8);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(268, 33);
            this.panel4.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 33);
            this.label8.TabIndex = 9;
            this.label8.Text = "Timming Parameters";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Controls.Add(this.btnStop);
            this.panel5.Controls.Add(this.btnSpeed);
            this.panel5.Controls.Add(this.txtBoxrateobject);
            this.panel5.Controls.Add(this.txtBoxnumericSpeed);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(277, 143);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(149, 294);
            this.panel5.TabIndex = 14;
            // 
            // btnStop
            // 
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnStop.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(6, 220);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(133, 32);
            this.btnStop.TabIndex = 51;
            this.btnStop.Text = "Stop Motor";
            // 
            // btnSpeed
            // 
            this.btnSpeed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSpeed.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSpeed.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpeed.Location = new System.Drawing.Point(6, 182);
            this.btnSpeed.Name = "btnSpeed";
            this.btnSpeed.Size = new System.Drawing.Size(133, 32);
            this.btnSpeed.TabIndex = 50;
            this.btnSpeed.Text = "Run Motor";
            // 
            // txtBoxrateobject
            // 
            this.txtBoxrateobject.Location = new System.Drawing.Point(6, 134);
            this.txtBoxrateobject.Name = "txtBoxrateobject";
            this.txtBoxrateobject.Size = new System.Drawing.Size(133, 20);
            this.txtBoxrateobject.TabIndex = 49;
            // 
            // txtBoxnumericSpeed
            // 
            this.txtBoxnumericSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxnumericSpeed.Location = new System.Drawing.Point(6, 80);
            this.txtBoxnumericSpeed.Name = "txtBoxnumericSpeed";
            this.txtBoxnumericSpeed.Size = new System.Drawing.Size(133, 22);
            this.txtBoxnumericSpeed.TabIndex = 46;
            this.txtBoxnumericSpeed.Text = "20";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(3, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 17);
            this.label10.TabIndex = 14;
            this.label10.Text = "Rate (Hz):";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(3, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Rate Object RPM:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel6.Controls.Add(this.label11);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(149, 33);
            this.panel6.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(139, 33);
            this.label11.TabIndex = 9;
            this.label11.Text = "Control Speed";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.Control;
            this.panel7.Controls.Add(this.zedAcquisition);
            this.panel7.Controls.Add(this.acquisitionDataGrid);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Location = new System.Drawing.Point(433, 143);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(546, 294);
            this.panel7.TabIndex = 52;
            // 
            // zedAcquisition
            // 
            this.zedAcquisition.Location = new System.Drawing.Point(281, 66);
            this.zedAcquisition.Name = "zedAcquisition";
            this.zedAcquisition.ScrollGrace = 0D;
            this.zedAcquisition.ScrollMaxX = 0D;
            this.zedAcquisition.ScrollMaxY = 0D;
            this.zedAcquisition.ScrollMaxY2 = 0D;
            this.zedAcquisition.ScrollMinX = 0D;
            this.zedAcquisition.ScrollMinY = 0D;
            this.zedAcquisition.ScrollMinY2 = 0D;
            this.zedAcquisition.Size = new System.Drawing.Size(262, 216);
            this.zedAcquisition.TabIndex = 15;
            // 
            // acquisitionDataGrid
            // 
            this.acquisitionDataGrid.AllowSorting = false;
            this.acquisitionDataGrid.DataMember = "";
            this.acquisitionDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.acquisitionDataGrid.Location = new System.Drawing.Point(6, 66);
            this.acquisitionDataGrid.Name = "acquisitionDataGrid";
            this.acquisitionDataGrid.ParentRowsVisible = false;
            this.acquisitionDataGrid.ReadOnly = true;
            this.acquisitionDataGrid.Size = new System.Drawing.Size(269, 216);
            this.acquisitionDataGrid.TabIndex = 2;
            this.acquisitionDataGrid.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel8.Controls.Add(this.label13);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(546, 33);
            this.panel8.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(183, 33);
            this.label13.TabIndex = 9;
            this.label13.Text = "Acquisition Results";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(3, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 17);
            this.label9.TabIndex = 14;
            this.label9.Text = "Acquisition Data (V)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblmode
            // 
            this.lblmode.AutoSize = true;
            this.lblmode.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmode.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblmode.Location = new System.Drawing.Point(412, 0);
            this.lblmode.Name = "lblmode";
            this.lblmode.Size = new System.Drawing.Size(157, 33);
            this.lblmode.TabIndex = 53;
            this.lblmode.Text = "Thu thập dữ liệu";
            this.lblmode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DataAcquisition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.Controls.Add(this.lblmode);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.NextButton);
            this.Name = "DataAcquisition";
            this.Size = new System.Drawing.Size(980, 650);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maximumValueNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumValueNumeric)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.samplesPerChannelNumeric)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acquisitionDataGrid)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.NumericUpDown maximumValueNumeric;
        internal System.Windows.Forms.NumericUpDown minimumValueNumeric;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton PhysicalChannelrButton;
        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.NumericUpDown rateNumeric;
        private System.Windows.Forms.NumericUpDown samplesPerChannelNumeric;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtBoxrateobject;
        private System.Windows.Forms.TextBox txtBoxnumericSpeed;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSpeed;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGrid acquisitionDataGrid;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private ZedGraph.ZedGraphControl zedAcquisition;
        private System.Windows.Forms.Label lblmode;
    }
}
