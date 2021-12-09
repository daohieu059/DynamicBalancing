
namespace dynamic_balancing_machine.User_control
{
    partial class Step4
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
            this.BackButton = new System.Windows.Forms.Button();
            this.FinishButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.FlatAppearance.BorderSize = 0;
            this.BackButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(190)))), ((int)(((byte)(214)))));
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(588, 369);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(159, 51);
            this.BackButton.TabIndex = 2;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click_1);
            // 
            // FinishButton
            // 
            this.FinishButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.FinishButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FinishButton.FlatAppearance.BorderSize = 0;
            this.FinishButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(190)))), ((int)(((byte)(214)))));
            this.FinishButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FinishButton.ForeColor = System.Drawing.Color.White;
            this.FinishButton.Location = new System.Drawing.Point(753, 369);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(159, 51);
            this.FinishButton.TabIndex = 3;
            this.FinishButton.Text = "Finish";
            this.FinishButton.UseVisualStyleBackColor = false;
            this.FinishButton.Click += new System.EventHandler(this.FinishButton_Click_1);
            // 
            // Step4
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.FinishButton);
            this.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "Step4";
            this.Size = new System.Drawing.Size(912, 420);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button FinishButton;
    }
}
