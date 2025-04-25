namespace Cinema.Admin.SchedulesComponents
{
    partial class Schedule_Add
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
            this.label1 = new System.Windows.Forms.Label();
            this.FTheater = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.FMovie = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.ResetFil = new Guna.UI2.WinForms.Guna2Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(114, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add New Schedule";
            // 
            // FTheater
            // 
            this.FTheater.BackColor = System.Drawing.Color.Transparent;
            this.FTheater.BorderRadius = 8;
            this.FTheater.BorderThickness = 2;
            this.FTheater.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.FTheater.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FTheater.FocusedColor = System.Drawing.Color.Black;
            this.FTheater.FocusedState.BorderColor = System.Drawing.Color.Black;
            this.FTheater.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.FTheater.ForeColor = System.Drawing.Color.Black;
            this.FTheater.ItemHeight = 30;
            this.FTheater.Location = new System.Drawing.Point(203, 114);
            this.FTheater.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FTheater.Name = "FTheater";
            this.FTheater.Size = new System.Drawing.Size(246, 36);
            this.FTheater.TabIndex = 32;
            this.FTheater.SelectedIndexChanged += new System.EventHandler(this.FTheater_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 25);
            this.label2.TabIndex = 33;
            this.label2.Text = "Theater:";
            // 
            // FDate
            // 
            this.FDate.BackColor = System.Drawing.Color.White;
            this.FDate.BorderRadius = 10;
            this.FDate.BorderThickness = 2;
            this.FDate.Checked = true;
            this.FDate.FillColor = System.Drawing.Color.Black;
            this.FDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.FDate.ForeColor = System.Drawing.Color.White;
            this.FDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.FDate.Location = new System.Drawing.Point(202, 192);
            this.FDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.FDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.FDate.Name = "FDate";
            this.FDate.Size = new System.Drawing.Size(248, 41);
            this.FDate.TabIndex = 34;
            this.FDate.Value = new System.DateTime(2025, 3, 26, 0, 0, 0, 0);
            this.FDate.ValueChanged += new System.EventHandler(this.FDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 25);
            this.label3.TabIndex = 35;
            this.label3.Text = "Date:";
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
            this.FMovie.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.FMovie.ForeColor = System.Drawing.Color.Black;
            this.FMovie.ItemHeight = 30;
            this.FMovie.Location = new System.Drawing.Point(203, 281);
            this.FMovie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FMovie.Name = "FMovie";
            this.FMovie.Size = new System.Drawing.Size(246, 36);
            this.FMovie.TabIndex = 36;
            this.FMovie.SelectedIndexChanged += new System.EventHandler(this.FMovie_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 25);
            this.label4.TabIndex = 37;
            this.label4.Text = "Movie:";
            // 
            // guna2Button3
            // 
            this.guna2Button3.BackColor = System.Drawing.Color.White;
            this.guna2Button3.BorderRadius = 15;
            this.guna2Button3.BorderThickness = 2;
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.FillColor = System.Drawing.Color.White;
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button3.ForeColor = System.Drawing.Color.Black;
            this.guna2Button3.Location = new System.Drawing.Point(43, 361);
            this.guna2Button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.PressedDepth = 60;
            this.guna2Button3.Size = new System.Drawing.Size(128, 56);
            this.guna2Button3.TabIndex = 38;
            this.guna2Button3.Text = "Check available time";
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(202, 361);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(246, 240);
            this.dataGridView1.TabIndex = 39;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 646);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 25);
            this.label5.TabIndex = 40;
            this.label5.Text = "Start time:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(38, 708);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 25);
            this.label6.TabIndex = 41;
            this.label6.Text = "End time:";
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox2.Location = new System.Drawing.Point(202, 641);
            this.maskedTextBox2.Mask = "00:00";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(55, 30);
            this.maskedTextBox2.TabIndex = 43;
            this.maskedTextBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskedTextBox2_KeyDown);
            this.maskedTextBox2.Leave += new System.EventHandler(this.maskedTextBox2_Leave);
            // 
            // ResetFil
            // 
            this.ResetFil.BorderRadius = 17;
            this.ResetFil.BorderThickness = 2;
            this.ResetFil.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ResetFil.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ResetFil.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ResetFil.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ResetFil.FillColor = System.Drawing.Color.White;
            this.ResetFil.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetFil.ForeColor = System.Drawing.Color.Black;
            this.ResetFil.Location = new System.Drawing.Point(43, 444);
            this.ResetFil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ResetFil.Name = "ResetFil";
            this.ResetFil.PressedDepth = 60;
            this.ResetFil.Size = new System.Drawing.Size(128, 55);
            this.ResetFil.TabIndex = 44;
            this.ResetFil.Text = "Reset";
            this.ResetFil.Click += new System.EventHandler(this.ResetFil_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox1.Location = new System.Drawing.Point(202, 703);
            this.maskedTextBox1.Mask = "00:00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(55, 30);
            this.maskedTextBox1.TabIndex = 45;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 20;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Black;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Image = global::Cinema.Properties.Resources.plusico;
            this.guna2Button1.Location = new System.Drawing.Point(134, 768);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.PressedDepth = 60;
            this.guna2Button1.Size = new System.Drawing.Size(244, 46);
            this.guna2Button1.TabIndex = 46;
            this.guna2Button1.Text = "Add Schedule";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // Schedule_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(496, 844);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.ResetFil);
            this.Controls.Add(this.maskedTextBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.guna2Button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FMovie);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FTheater);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Schedule_Add";
            this.Text = "Adding Schedule";
            this.Load += new System.EventHandler(this.Schedule_Add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox FTheater;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DateTimePicker FDate;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox FMovie;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Button ResetFil;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}