namespace Cinema.Admin.UserControls
{
    partial class UC_Theaters
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
            this.label1 = new System.Windows.Forms.Label();
            this.TheaterCombobox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.SeatPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 46);
            this.label1.TabIndex = 4;
            this.label1.Text = "Theaters";
            // 
            // TheaterCombobox
            // 
            this.TheaterCombobox.BackColor = System.Drawing.Color.Transparent;
            this.TheaterCombobox.BorderRadius = 15;
            this.TheaterCombobox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.TheaterCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TheaterCombobox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.TheaterCombobox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.TheaterCombobox.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.TheaterCombobox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.TheaterCombobox.ItemHeight = 30;
            this.TheaterCombobox.Location = new System.Drawing.Point(48, 195);
            this.TheaterCombobox.Name = "TheaterCombobox";
            this.TheaterCombobox.Size = new System.Drawing.Size(274, 36);
            this.TheaterCombobox.TabIndex = 5;
            // 
            // SeatPanel
            // 
            this.SeatPanel.AutoSize = true;
            this.SeatPanel.Location = new System.Drawing.Point(435, 245);
            this.SeatPanel.Name = "SeatPanel";
            this.SeatPanel.Size = new System.Drawing.Size(925, 499);
            this.SeatPanel.TabIndex = 6;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::Cinema.Properties.Resources.screen;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(450, 127);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(858, 64);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 7;
            this.guna2PictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.label2.Location = new System.Drawing.Point(823, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "Screen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(43, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 26);
            this.label3.TabIndex = 9;
            this.label3.Text = "Choose a Theater";
            // 
            // UC_Theaters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.SeatPanel);
            this.Controls.Add(this.TheaterCombobox);
            this.Controls.Add(this.label1);
            this.Name = "UC_Theaters";
            this.Size = new System.Drawing.Size(1360, 1024);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox TheaterCombobox;
        private System.Windows.Forms.FlowLayoutPanel SeatPanel;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
