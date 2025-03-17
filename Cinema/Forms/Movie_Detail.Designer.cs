namespace Cinema.Forms {
    partial class Movie_Detail {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Movie_Detail));
            this.panel_Top = new System.Windows.Forms.Panel();
            this.panel_Body = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Rated_Content = new System.Windows.Forms.Label();
            this.Rated_Label = new System.Windows.Forms.Label();
            this.Movie_Content = new System.Windows.Forms.TextBox();
            this.Movie_Name = new System.Windows.Forms.Label();
            this.Booking_Button = new System.Windows.Forms.Button();
            this.Poster = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel_Body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Poster)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Top
            // 
            this.panel_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(173)))), ((int)(((byte)(120)))));
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(0, 0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(1100, 55);
            this.panel_Top.TabIndex = 0;
            // 
            // panel_Body
            // 
            this.panel_Body.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel_Body.Controls.Add(this.label11);
            this.panel_Body.Controls.Add(this.label12);
            this.panel_Body.Controls.Add(this.label9);
            this.panel_Body.Controls.Add(this.label10);
            this.panel_Body.Controls.Add(this.label7);
            this.panel_Body.Controls.Add(this.label8);
            this.panel_Body.Controls.Add(this.label5);
            this.panel_Body.Controls.Add(this.label6);
            this.panel_Body.Controls.Add(this.textBox1);
            this.panel_Body.Controls.Add(this.label3);
            this.panel_Body.Controls.Add(this.label4);
            this.panel_Body.Controls.Add(this.label1);
            this.panel_Body.Controls.Add(this.label2);
            this.panel_Body.Controls.Add(this.Rated_Content);
            this.panel_Body.Controls.Add(this.Rated_Label);
            this.panel_Body.Controls.Add(this.Movie_Content);
            this.panel_Body.Controls.Add(this.Movie_Name);
            this.panel_Body.Controls.Add(this.Booking_Button);
            this.panel_Body.Controls.Add(this.Poster);
            this.panel_Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Body.Location = new System.Drawing.Point(0, 55);
            this.panel_Body.Name = "panel_Body";
            this.panel_Body.Size = new System.Drawing.Size(1100, 621);
            this.panel_Body.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(619, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Huynh Lap";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(533, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Director:";
            // 
            // Rated_Content
            // 
            this.Rated_Content.AutoSize = true;
            this.Rated_Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rated_Content.Location = new System.Drawing.Point(603, 568);
            this.Rated_Content.Name = "Rated_Content";
            this.Rated_Content.Size = new System.Drawing.Size(418, 20);
            this.Rated_Content.TabIndex = 5;
            this.Rated_Content.Text = "The movie is popular with viewers aged 18 and over";
            // 
            // Rated_Label
            // 
            this.Rated_Label.AutoSize = true;
            this.Rated_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rated_Label.Location = new System.Drawing.Point(533, 565);
            this.Rated_Label.Name = "Rated_Label";
            this.Rated_Label.Size = new System.Drawing.Size(70, 24);
            this.Rated_Label.TabIndex = 4;
            this.Rated_Label.Text = "Rated:";
            // 
            // Movie_Content
            // 
            this.Movie_Content.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Movie_Content.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Movie_Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Movie_Content.Location = new System.Drawing.Point(539, 120);
            this.Movie_Content.Multiline = true;
            this.Movie_Content.Name = "Movie_Content";
            this.Movie_Content.ReadOnly = true;
            this.Movie_Content.Size = new System.Drawing.Size(510, 108);
            this.Movie_Content.TabIndex = 3;
            this.Movie_Content.Text = resources.GetString("Movie_Content.Text");
            // 
            // Movie_Name
            // 
            this.Movie_Name.AutoSize = true;
            this.Movie_Name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Movie_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Movie_Name.ForeColor = System.Drawing.Color.SeaGreen;
            this.Movie_Name.Location = new System.Drawing.Point(533, 60);
            this.Movie_Name.Name = "Movie_Name";
            this.Movie_Name.Size = new System.Drawing.Size(208, 31);
            this.Movie_Name.TabIndex = 2;
            this.Movie_Name.Text = "NHÀ GIA TIÊN";
            // 
            // Booking_Button
            // 
            this.Booking_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(213)))), ((int)(((byte)(180)))));
            this.Booking_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Booking_Button.FlatAppearance.BorderSize = 0;
            this.Booking_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Booking_Button.ForeColor = System.Drawing.Color.SeaGreen;
            this.Booking_Button.Location = new System.Drawing.Point(161, 514);
            this.Booking_Button.Name = "Booking_Button";
            this.Booking_Button.Size = new System.Drawing.Size(140, 50);
            this.Booking_Button.TabIndex = 1;
            this.Booking_Button.Text = "Book ticket";
            this.Booking_Button.UseVisualStyleBackColor = false;
            this.Booking_Button.MouseEnter += new System.EventHandler(this.Booking_Button_MouseEnter);
            this.Booking_Button.MouseLeave += new System.EventHandler(this.Booking_Button_MouseLeave);
            // 
            // Poster
            // 
            this.Poster.Image = ((System.Drawing.Image)(resources.GetObject("Poster.Image")));
            this.Poster.Location = new System.Drawing.Point(60, 60);
            this.Poster.Name = "Poster";
            this.Poster.Size = new System.Drawing.Size(348, 438);
            this.Poster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Poster.TabIndex = 0;
            this.Poster.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(600, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 24);
            this.label3.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(535, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Actor:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(600, 272);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(449, 130);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(607, 414);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "Family, Comedy";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(533, 414);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "Genre:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(643, 453);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 24);
            this.label7.TabIndex = 14;
            this.label7.Text = "21/02/2025";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(535, 453);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 24);
            this.label8.TabIndex = 13;
            this.label8.Text = "Screening:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(626, 489);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 24);
            this.label9.TabIndex = 16;
            this.label9.Text = "117 minutes";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(535, 489);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 24);
            this.label10.TabIndex = 15;
            this.label10.Text = "Duration:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(641, 524);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(264, 24);
            this.label11.TabIndex = 18;
            this.label11.Text = "Vietnamese - English Subtitles";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(535, 524);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 24);
            this.label12.TabIndex = 17;
            this.label12.Text = "Language:";
            // 
            // Movie_Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 676);
            this.Controls.Add(this.panel_Body);
            this.Controls.Add(this.panel_Top);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Movie_Detail";
            this.Text = "MovieDetail";
            this.Load += new System.EventHandler(this.Movie_Detail_Load);
            this.panel_Body.ResumeLayout(false);
            this.panel_Body.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Poster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Panel panel_Body;
        private System.Windows.Forms.PictureBox Poster;
        private System.Windows.Forms.Button Booking_Button;
        private System.Windows.Forms.Label Movie_Name;
        private System.Windows.Forms.TextBox Movie_Content;
        private System.Windows.Forms.Label Rated_Label;
        private System.Windows.Forms.Label Rated_Content;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}