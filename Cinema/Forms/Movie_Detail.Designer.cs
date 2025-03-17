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
            this.Poster = new System.Windows.Forms.PictureBox();
            this.Booking_Button = new System.Windows.Forms.Button();
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
            this.panel_Body.Controls.Add(this.Booking_Button);
            this.panel_Body.Controls.Add(this.Poster);
            this.panel_Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Body.Location = new System.Drawing.Point(0, 55);
            this.panel_Body.Name = "panel_Body";
            this.panel_Body.Size = new System.Drawing.Size(1100, 621);
            this.panel_Body.TabIndex = 1;
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
            // Booking_Button
            // 
            this.Booking_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(213)))), ((int)(((byte)(180)))));
            this.Booking_Button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Booking_Button.Location = new System.Drawing.Point(162, 515);
            this.Booking_Button.Name = "Booking_Button";
            this.Booking_Button.Size = new System.Drawing.Size(134, 42);
            this.Booking_Button.TabIndex = 1;
            this.Booking_Button.Text = "Book ticket";
            this.Booking_Button.UseVisualStyleBackColor = false;
            // 
            // Movie_Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 676);
            this.Controls.Add(this.panel_Body);
            this.Controls.Add(this.panel_Top);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Movie_Detail";
            this.Text = "MovieDetail";
            this.Load += new System.EventHandler(this.Movie_Detail_Load);
            this.panel_Body.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Poster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Panel panel_Body;
        private System.Windows.Forms.PictureBox Poster;
        private System.Windows.Forms.Button Booking_Button;
    }
}