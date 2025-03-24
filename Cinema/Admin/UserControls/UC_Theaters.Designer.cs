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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.FMovie = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.FSchedule = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.ResetFil = new Guna.UI2.WinForms.Guna2Button();
            this.label9 = new System.Windows.Forms.Label();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 46);
            this.label1.TabIndex = 4;
            this.label1.Text = "Theaters";
            // 
            // TheaterCombobox
            // 
            this.TheaterCombobox.BackColor = System.Drawing.Color.Transparent;
            this.TheaterCombobox.BorderRadius = 8;
            this.TheaterCombobox.BorderThickness = 2;
            this.TheaterCombobox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.TheaterCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TheaterCombobox.FocusedColor = System.Drawing.Color.Black;
            this.TheaterCombobox.FocusedState.BorderColor = System.Drawing.Color.Black;
            this.TheaterCombobox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.TheaterCombobox.ForeColor = System.Drawing.Color.Black;
            this.TheaterCombobox.ItemHeight = 30;
            this.TheaterCombobox.Location = new System.Drawing.Point(39, 560);
            this.TheaterCombobox.Name = "TheaterCombobox";
            this.TheaterCombobox.Size = new System.Drawing.Size(295, 36);
            this.TheaterCombobox.TabIndex = 5;
            // 
            // SeatPanel
            // 
            this.SeatPanel.AutoSize = true;
            this.SeatPanel.Location = new System.Drawing.Point(446, 245);
            this.SeatPanel.Name = "SeatPanel";
            this.SeatPanel.Size = new System.Drawing.Size(925, 499);
            this.SeatPanel.TabIndex = 6;
            this.SeatPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SeatPanel_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.label2.Location = new System.Drawing.Point(814, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "Screen";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(37, 520);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Theater";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // FDate
            // 
            this.FDate.BackColor = System.Drawing.Color.Transparent;
            this.FDate.BorderRadius = 15;
            this.FDate.Checked = true;
            this.FDate.FillColor = System.Drawing.Color.Black;
            this.FDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.FDate.ForeColor = System.Drawing.Color.White;
            this.FDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.FDate.Location = new System.Drawing.Point(37, 229);
            this.FDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.FDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.FDate.Name = "FDate";
            this.FDate.Size = new System.Drawing.Size(301, 46);
            this.FDate.TabIndex = 10;
            this.FDate.Value = new System.DateTime(2025, 3, 23, 16, 19, 9, 416);
            this.FDate.ValueChanged += new System.EventHandler(this.FDate_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(37, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Movie";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // FMovie
            // 
            this.FMovie.BackColor = System.Drawing.Color.Transparent;
            this.FMovie.BorderRadius = 8;
            this.FMovie.BorderThickness = 2;
            this.FMovie.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.FMovie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FMovie.FocusedColor = System.Drawing.Color.Black;
            this.FMovie.FocusedState.BorderColor = System.Drawing.Color.Black;
            this.FMovie.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.FMovie.ForeColor = System.Drawing.Color.Black;
            this.FMovie.ItemHeight = 30;
            this.FMovie.Location = new System.Drawing.Point(40, 344);
            this.FMovie.Name = "FMovie";
            this.FMovie.Size = new System.Drawing.Size(293, 36);
            this.FMovie.TabIndex = 13;
            this.FMovie.SelectedIndexChanged += new System.EventHandler(this.FMovie_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(37, 414);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Schedule";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // FSchedule
            // 
            this.FSchedule.BackColor = System.Drawing.Color.Transparent;
            this.FSchedule.BorderRadius = 8;
            this.FSchedule.BorderThickness = 2;
            this.FSchedule.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.FSchedule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FSchedule.FocusedColor = System.Drawing.Color.Black;
            this.FSchedule.FocusedState.BorderColor = System.Drawing.Color.Black;
            this.FSchedule.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.FSchedule.ForeColor = System.Drawing.Color.Black;
            this.FSchedule.ItemHeight = 30;
            this.FSchedule.Location = new System.Drawing.Point(43, 450);
            this.FSchedule.Name = "FSchedule";
            this.FSchedule.Size = new System.Drawing.Size(288, 36);
            this.FSchedule.TabIndex = 15;
            this.FSchedule.SelectedIndexChanged += new System.EventHandler(this.FSchedule_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(749, 817);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 26);
            this.label7.TabIndex = 17;
            this.label7.Text = "Booked";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(1008, 817);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 26);
            this.label8.TabIndex = 19;
            this.label8.Text = "Available";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(41, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Date";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.BackColor = System.Drawing.Color.Silver;
            this.guna2Separator1.Location = new System.Drawing.Point(383, 127);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1, 750);
            this.guna2Separator1.TabIndex = 20;
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(673, 800);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(50, 50);
            this.guna2Button1.TabIndex = 16;
            // 
            // guna2Button2
            // 
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.Gainsboro;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(927, 800);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.PressedColor = System.Drawing.Color.LightGray;
            this.guna2Button2.PressedDepth = 0;
            this.guna2Button2.Size = new System.Drawing.Size(50, 50);
            this.guna2Button2.TabIndex = 18;
            // 
            // guna2Button3
            // 
            this.guna2Button3.BorderRadius = 20;
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.FillColor = System.Drawing.Color.Black;
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.Location = new System.Drawing.Point(39, 648);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.PressedDepth = 60;
            this.guna2Button3.Size = new System.Drawing.Size(140, 47);
            this.guna2Button3.TabIndex = 21;
            this.guna2Button3.Text = "Check";
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // ResetFil
            // 
            this.ResetFil.BorderRadius = 20;
            this.ResetFil.BorderThickness = 2;
            this.ResetFil.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ResetFil.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ResetFil.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ResetFil.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ResetFil.FillColor = System.Drawing.Color.White;
            this.ResetFil.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ResetFil.ForeColor = System.Drawing.Color.Black;
            this.ResetFil.Location = new System.Drawing.Point(194, 648);
            this.ResetFil.Name = "ResetFil";
            this.ResetFil.PressedDepth = 60;
            this.ResetFil.Size = new System.Drawing.Size(140, 47);
            this.ResetFil.TabIndex = 22;
            this.ResetFil.Text = "Reset";
            this.ResetFil.Click += new System.EventHandler(this.ResetFil_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(38, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(278, 29);
            this.label9.TabIndex = 23;
            this.label9.Text = "Check Reserved Seats";
            // 
            // guna2Button4
            // 
            this.guna2Button4.BorderRadius = 20;
            this.guna2Button4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button4.FillColor = System.Drawing.Color.Black;
            this.guna2Button4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.guna2Button4.ForeColor = System.Drawing.Color.White;
            this.guna2Button4.Image = global::Cinema.Properties.Resources.eww2;
            this.guna2Button4.ImageSize = new System.Drawing.Size(30, 22);
            this.guna2Button4.Location = new System.Drawing.Point(1066, 38);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.PressedDepth = 60;
            this.guna2Button4.Size = new System.Drawing.Size(242, 58);
            this.guna2Button4.TabIndex = 24;
            this.guna2Button4.Text = "Manage Theaters";
            this.guna2Button4.Click += new System.EventHandler(this.guna2Button4_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::Cinema.Properties.Resources.screen;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(450, 140);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(858, 39);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 7;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.Click += new System.EventHandler(this.guna2PictureBox1_Click);
            // 
            // UC_Theaters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2Button4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ResetFil);
            this.Controls.Add(this.guna2Button3);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.FSchedule);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.FMovie);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.SeatPanel);
            this.Controls.Add(this.TheaterCombobox);
            this.Controls.Add(this.label1);
            this.Name = "UC_Theaters";
            this.Size = new System.Drawing.Size(1360, 1024);
            this.Load += new System.EventHandler(this.UC_Theaters_Load);
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
        private Guna.UI2.WinForms.Guna2DateTimePicker FDate;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox FMovie;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox FSchedule;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2Button ResetFil;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
    }
}
