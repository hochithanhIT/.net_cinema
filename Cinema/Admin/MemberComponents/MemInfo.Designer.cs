namespace Cinema.Admin.MemberComponents
{
    partial class MemInfo
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.NameTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.EmailTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.PhoneTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.BDTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.SpendTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Full Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 46);
            this.label1.TabIndex = 7;
            this.label1.Text = "Member Information";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(608, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Phone Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(72, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Email Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(608, 316);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Birthdate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(72, 491);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Spending";
            // 
            // NameTextBox
            // 
            this.NameTextBox.BorderColor = System.Drawing.Color.Silver;
            this.NameTextBox.BorderRadius = 15;
            this.NameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NameTextBox.DefaultText = "";
            this.NameTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.NameTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.NameTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NameTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NameTextBox.FillColor = System.Drawing.Color.WhiteSmoke;
            this.NameTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NameTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.NameTextBox.ForeColor = System.Drawing.Color.Black;
            this.NameTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NameTextBox.Location = new System.Drawing.Point(77, 193);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.PlaceholderText = "";
            this.NameTextBox.SelectedText = "";
            this.NameTextBox.Size = new System.Drawing.Size(460, 58);
            this.NameTextBox.TabIndex = 12;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.BorderColor = System.Drawing.Color.Silver;
            this.EmailTextBox.BorderRadius = 15;
            this.EmailTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EmailTextBox.DefaultText = "";
            this.EmailTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.EmailTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.EmailTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.EmailTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.EmailTextBox.FillColor = System.Drawing.Color.WhiteSmoke;
            this.EmailTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.EmailTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.EmailTextBox.ForeColor = System.Drawing.Color.Black;
            this.EmailTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.EmailTextBox.Location = new System.Drawing.Point(77, 364);
            this.EmailTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.PlaceholderText = "";
            this.EmailTextBox.SelectedText = "";
            this.EmailTextBox.Size = new System.Drawing.Size(460, 58);
            this.EmailTextBox.TabIndex = 13;
            this.EmailTextBox.TextChanged += new System.EventHandler(this.EmailTextBox_TextChanged);
            // 
            // PhoneTextBox
            // 
            this.PhoneTextBox.BorderColor = System.Drawing.Color.Silver;
            this.PhoneTextBox.BorderRadius = 15;
            this.PhoneTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PhoneTextBox.DefaultText = "";
            this.PhoneTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.PhoneTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.PhoneTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PhoneTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PhoneTextBox.FillColor = System.Drawing.Color.WhiteSmoke;
            this.PhoneTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PhoneTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.PhoneTextBox.ForeColor = System.Drawing.Color.Black;
            this.PhoneTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PhoneTextBox.Location = new System.Drawing.Point(613, 193);
            this.PhoneTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PhoneTextBox.Name = "PhoneTextBox";
            this.PhoneTextBox.PlaceholderText = "";
            this.PhoneTextBox.SelectedText = "";
            this.PhoneTextBox.Size = new System.Drawing.Size(345, 58);
            this.PhoneTextBox.TabIndex = 14;
            this.PhoneTextBox.TextChanged += new System.EventHandler(this.PhoneTextBox_TextChanged);
            // 
            // BDTextBox
            // 
            this.BDTextBox.BorderColor = System.Drawing.Color.Silver;
            this.BDTextBox.BorderRadius = 15;
            this.BDTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.BDTextBox.DefaultText = "";
            this.BDTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.BDTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.BDTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.BDTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.BDTextBox.FillColor = System.Drawing.Color.WhiteSmoke;
            this.BDTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BDTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.BDTextBox.ForeColor = System.Drawing.Color.Black;
            this.BDTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BDTextBox.Location = new System.Drawing.Point(613, 364);
            this.BDTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BDTextBox.Name = "BDTextBox";
            this.BDTextBox.PlaceholderText = "";
            this.BDTextBox.SelectedText = "";
            this.BDTextBox.Size = new System.Drawing.Size(253, 58);
            this.BDTextBox.TabIndex = 15;
            this.BDTextBox.TextChanged += new System.EventHandler(this.BDTextBox_TextChanged);
            // 
            // SpendTextBox
            // 
            this.SpendTextBox.BorderColor = System.Drawing.Color.Silver;
            this.SpendTextBox.BorderRadius = 15;
            this.SpendTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SpendTextBox.DefaultText = "";
            this.SpendTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.SpendTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.SpendTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SpendTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SpendTextBox.FillColor = System.Drawing.Color.WhiteSmoke;
            this.SpendTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SpendTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.SpendTextBox.ForeColor = System.Drawing.Color.Black;
            this.SpendTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SpendTextBox.Location = new System.Drawing.Point(77, 536);
            this.SpendTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SpendTextBox.Name = "SpendTextBox";
            this.SpendTextBox.PlaceholderText = "";
            this.SpendTextBox.SelectedText = "";
            this.SpendTextBox.Size = new System.Drawing.Size(221, 58);
            this.SpendTextBox.TabIndex = 16;
            this.SpendTextBox.TextChanged += new System.EventHandler(this.SpendTextBox_TextChanged);
            // 
            // MemInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1051, 719);
            this.Controls.Add(this.SpendTextBox);
            this.Controls.Add(this.BDTextBox);
            this.Controls.Add(this.PhoneTextBox);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "MemInfo";
            this.Text = "MemInfo";
            this.Load += new System.EventHandler(this.MemInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public Guna.UI2.WinForms.Guna2TextBox NameTextBox;
        public Guna.UI2.WinForms.Guna2TextBox EmailTextBox;
        public Guna.UI2.WinForms.Guna2TextBox PhoneTextBox;
        public Guna.UI2.WinForms.Guna2TextBox BDTextBox;
        public Guna.UI2.WinForms.Guna2TextBox SpendTextBox;

    }
}