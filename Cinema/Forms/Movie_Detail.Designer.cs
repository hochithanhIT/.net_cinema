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
            this.panel_Body = new System.Windows.Forms.Panel();
            this.Duration_Content = new System.Windows.Forms.Label();
            this.Duration_Label = new System.Windows.Forms.Label();
            this.Screening_Content = new System.Windows.Forms.Label();
            this.Screening_Label = new System.Windows.Forms.Label();
            this.Genre_Content = new System.Windows.Forms.Label();
            this.Genre_Label = new System.Windows.Forms.Label();
            this.Actor_Content = new System.Windows.Forms.TextBox();
            this.Actor_Label = new System.Windows.Forms.Label();
            this.Director_Content = new System.Windows.Forms.Label();
            this.Director_Label = new System.Windows.Forms.Label();
            this.Rated_Content = new System.Windows.Forms.Label();
            this.Rated_Label = new System.Windows.Forms.Label();
            this.Movie_Content = new System.Windows.Forms.TextBox();
            this.Movie_Name = new System.Windows.Forms.Label();
            this.Booking_Button = new System.Windows.Forms.Button();
            this.Poster = new System.Windows.Forms.PictureBox();
            this.panel_Body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Poster)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Body
            // 
            this.panel_Body.AutoSize = true;
            this.panel_Body.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel_Body.Controls.Add(this.Duration_Content);
            this.panel_Body.Controls.Add(this.Duration_Label);
            this.panel_Body.Controls.Add(this.Screening_Content);
            this.panel_Body.Controls.Add(this.Screening_Label);
            this.panel_Body.Controls.Add(this.Genre_Content);
            this.panel_Body.Controls.Add(this.Genre_Label);
            this.panel_Body.Controls.Add(this.Actor_Content);
            this.panel_Body.Controls.Add(this.Actor_Label);
            this.panel_Body.Controls.Add(this.Director_Content);
            this.panel_Body.Controls.Add(this.Director_Label);
            this.panel_Body.Controls.Add(this.Rated_Content);
            this.panel_Body.Controls.Add(this.Rated_Label);
            this.panel_Body.Controls.Add(this.Movie_Content);
            this.panel_Body.Controls.Add(this.Movie_Name);
            this.panel_Body.Controls.Add(this.Booking_Button);
            this.panel_Body.Controls.Add(this.Poster);
            this.panel_Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Body.Location = new System.Drawing.Point(0, 0);
            this.panel_Body.Name = "panel_Body";
            this.panel_Body.Size = new System.Drawing.Size(1924, 1055);
            this.panel_Body.TabIndex = 1;
            // 
            // Duration_Content
            // 
            this.Duration_Content.AutoSize = true;
            this.Duration_Content.Location = new System.Drawing.Point(733, 245);
            this.Duration_Content.Name = "Duration_Content";
            this.Duration_Content.Size = new System.Drawing.Size(142, 29);
            this.Duration_Content.TabIndex = 16;
            this.Duration_Content.Text = "117 minutes";
            // 
            // Duration_Label
            // 
            this.Duration_Label.AutoSize = true;
            this.Duration_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Duration_Label.Location = new System.Drawing.Point(609, 245);
            this.Duration_Label.Name = "Duration_Label";
            this.Duration_Label.Size = new System.Drawing.Size(118, 29);
            this.Duration_Label.TabIndex = 15;
            this.Duration_Label.Text = "Duration:";
            // 
            // Screening_Content
            // 
            this.Screening_Content.AutoSize = true;
            this.Screening_Content.Location = new System.Drawing.Point(754, 209);
            this.Screening_Content.Name = "Screening_Content";
            this.Screening_Content.Size = new System.Drawing.Size(131, 29);
            this.Screening_Content.TabIndex = 14;
            this.Screening_Content.Text = "21/02/2025";
            // 
            // Screening_Label
            // 
            this.Screening_Label.AutoSize = true;
            this.Screening_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Screening_Label.Location = new System.Drawing.Point(609, 209);
            this.Screening_Label.Name = "Screening_Label";
            this.Screening_Label.Size = new System.Drawing.Size(139, 29);
            this.Screening_Label.TabIndex = 13;
            this.Screening_Label.Text = "Screening:";
            // 
            // Genre_Content
            // 
            this.Genre_Content.AutoSize = true;
            this.Genre_Content.Location = new System.Drawing.Point(705, 170);
            this.Genre_Content.Name = "Genre_Content";
            this.Genre_Content.Size = new System.Drawing.Size(186, 29);
            this.Genre_Content.TabIndex = 12;
            this.Genre_Content.Text = "Family, Comedy";
            // 
            // Genre_Label
            // 
            this.Genre_Label.AutoSize = true;
            this.Genre_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Genre_Label.Location = new System.Drawing.Point(607, 170);
            this.Genre_Label.Name = "Genre_Label";
            this.Genre_Label.Size = new System.Drawing.Size(92, 29);
            this.Genre_Label.TabIndex = 11;
            this.Genre_Label.Text = "Genre:";
            // 
            // Actor_Content
            // 
            this.Actor_Content.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Actor_Content.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Actor_Content.Location = new System.Drawing.Point(695, 111);
            this.Actor_Content.Multiline = true;
            this.Actor_Content.Name = "Actor_Content";
            this.Actor_Content.ReadOnly = true;
            this.Actor_Content.Size = new System.Drawing.Size(449, 77);
            this.Actor_Content.TabIndex = 10;
            this.Actor_Content.Text = "Huynh Lap, Phuong My Chi, Artist Hanh Thuy, Artist Huynh Dong, Puka, Dao Anh Tuan" +
    ", Trung Dan,...";
            // 
            // Actor_Label
            // 
            this.Actor_Label.AutoSize = true;
            this.Actor_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Actor_Label.Location = new System.Drawing.Point(609, 111);
            this.Actor_Label.Name = "Actor_Label";
            this.Actor_Label.Size = new System.Drawing.Size(80, 29);
            this.Actor_Label.TabIndex = 8;
            this.Actor_Label.Text = "Actor:";
            // 
            // Director_Content
            // 
            this.Director_Content.AutoSize = true;
            this.Director_Content.Location = new System.Drawing.Point(726, 68);
            this.Director_Content.Name = "Director_Content";
            this.Director_Content.Size = new System.Drawing.Size(126, 29);
            this.Director_Content.TabIndex = 7;
            this.Director_Content.Text = "Huynh Lap";
            // 
            // Director_Label
            // 
            this.Director_Label.AutoSize = true;
            this.Director_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Director_Label.Location = new System.Drawing.Point(607, 68);
            this.Director_Label.Name = "Director_Label";
            this.Director_Label.Size = new System.Drawing.Size(113, 29);
            this.Director_Label.TabIndex = 6;
            this.Director_Label.Text = "Director:";
            // 
            // Rated_Content
            // 
            this.Rated_Content.AutoSize = true;
            this.Rated_Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rated_Content.Location = new System.Drawing.Point(705, 286);
            this.Rated_Content.Name = "Rated_Content";
            this.Rated_Content.Size = new System.Drawing.Size(510, 25);
            this.Rated_Content.TabIndex = 5;
            this.Rated_Content.Text = "The movie is popular with viewers aged 18 and over";
            // 
            // Rated_Label
            // 
            this.Rated_Label.AutoSize = true;
            this.Rated_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rated_Label.Location = new System.Drawing.Point(611, 283);
            this.Rated_Label.Name = "Rated_Label";
            this.Rated_Label.Size = new System.Drawing.Size(89, 29);
            this.Rated_Label.TabIndex = 4;
            this.Rated_Label.Text = "Rated:";
            // 
            // Movie_Content
            // 
            this.Movie_Content.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Movie_Content.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Movie_Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Movie_Content.Location = new System.Drawing.Point(613, 326);
            this.Movie_Content.Multiline = true;
            this.Movie_Content.Name = "Movie_Content";
            this.Movie_Content.ReadOnly = true;
            this.Movie_Content.Size = new System.Drawing.Size(1069, 300);
            this.Movie_Content.TabIndex = 3;
            this.Movie_Content.Text = resources.GetString("Movie_Content.Text");
            // 
            // Movie_Name
            // 
            this.Movie_Name.AutoSize = true;
            this.Movie_Name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Movie_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Movie_Name.ForeColor = System.Drawing.Color.SeaGreen;
            this.Movie_Name.Location = new System.Drawing.Point(603, 26);
            this.Movie_Name.Name = "Movie_Name";
            this.Movie_Name.Size = new System.Drawing.Size(258, 39);
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
            this.Booking_Button.Location = new System.Drawing.Point(234, 522);
            this.Booking_Button.Name = "Booking_Button";
            this.Booking_Button.Size = new System.Drawing.Size(140, 50);
            this.Booking_Button.TabIndex = 1;
            this.Booking_Button.Text = "Book ticket";
            this.Booking_Button.UseVisualStyleBackColor = false;
            this.Booking_Button.Click += new System.EventHandler(this.Booking_Button_Click);
            this.Booking_Button.MouseEnter += new System.EventHandler(this.Booking_Button_MouseEnter);
            this.Booking_Button.MouseLeave += new System.EventHandler(this.Booking_Button_MouseLeave);
            // 
            // Poster
            // 
            this.Poster.Image = ((System.Drawing.Image)(resources.GetObject("Poster.Image")));
            this.Poster.Location = new System.Drawing.Point(133, 68);
            this.Poster.Name = "Poster";
            this.Poster.Size = new System.Drawing.Size(348, 438);
            this.Poster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Poster.TabIndex = 0;
            this.Poster.TabStop = false;
            // 
            // Movie_Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.panel_Body);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Movie_Detail";
            this.Text = "MovieDetail";
            this.Load += new System.EventHandler(this.Movie_Detail_Load);
            this.panel_Body.ResumeLayout(false);
            this.panel_Body.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Poster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel_Body;
        private System.Windows.Forms.PictureBox Poster;
        private System.Windows.Forms.Button Booking_Button;
        private System.Windows.Forms.Label Movie_Name;
        private System.Windows.Forms.TextBox Movie_Content;
        private System.Windows.Forms.Label Rated_Label;
        private System.Windows.Forms.Label Rated_Content;
        private System.Windows.Forms.Label Director_Content;
        private System.Windows.Forms.Label Director_Label;
        private System.Windows.Forms.Label Screening_Content;
        private System.Windows.Forms.Label Screening_Label;
        private System.Windows.Forms.Label Genre_Content;
        private System.Windows.Forms.Label Genre_Label;
        private System.Windows.Forms.TextBox Actor_Content;
        private System.Windows.Forms.Label Actor_Label;
        private System.Windows.Forms.Label Duration_Content;
        private System.Windows.Forms.Label Duration_Label;
    }
}