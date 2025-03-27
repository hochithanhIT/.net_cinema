namespace Cinema.homepage
{
    partial class HomepageForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblShow = new System.Windows.Forms.LinkLabel();
            this.lblCome = new System.Windows.Forms.LinkLabel();
            this.lblMovie = new System.Windows.Forms.Label();
            this.flpMovies = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(811, 107);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(320, 51);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Ticket Booking";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblShow
            // 
            this.lblShow.ActiveLinkColor = System.Drawing.Color.DimGray;
            this.lblShow.AutoSize = true;
            this.lblShow.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblShow.LinkColor = System.Drawing.Color.Black;
            this.lblShow.Location = new System.Drawing.Point(458, 219);
            this.lblShow.Name = "lblShow";
            this.lblShow.Size = new System.Drawing.Size(158, 29);
            this.lblShow.TabIndex = 6;
            this.lblShow.TabStop = true;
            this.lblShow.Text = "Showing now";
            this.lblShow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblShow_LinkClicked);
            // 
            // lblCome
            // 
            this.lblCome.ActiveLinkColor = System.Drawing.Color.DimGray;
            this.lblCome.AutoSize = true;
            this.lblCome.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblCome.LinkColor = System.Drawing.Color.Black;
            this.lblCome.Location = new System.Drawing.Point(706, 219);
            this.lblCome.Name = "lblCome";
            this.lblCome.Size = new System.Drawing.Size(160, 29);
            this.lblCome.TabIndex = 7;
            this.lblCome.TabStop = true;
            this.lblCome.Text = "Coming Soon";
            this.lblCome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCome_LinkClicked);
            // 
            // lblMovie
            // 
            this.lblMovie.AutoSize = true;
            this.lblMovie.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovie.Location = new System.Drawing.Point(211, 212);
            this.lblMovie.Name = "lblMovie";
            this.lblMovie.Size = new System.Drawing.Size(134, 36);
            this.lblMovie.TabIndex = 5;
            this.lblMovie.Text = "| Movies";
            // 
            // flpMovies
            // 
            this.flpMovies.AutoScroll = true;
            this.flpMovies.Location = new System.Drawing.Point(217, 326);
            this.flpMovies.Name = "flpMovies";
            this.flpMovies.Size = new System.Drawing.Size(1429, 629);
            this.flpMovies.TabIndex = 9;
            // 
            // HomepageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.flpMovies);
            this.Controls.Add(this.lblMovie);
            this.Controls.Add(this.lblCome);
            this.Controls.Add(this.lblShow);
            this.Controls.Add(this.lblName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "HomepageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomepageForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.LinkLabel lblShow;
        private System.Windows.Forms.LinkLabel lblCome;
        private System.Windows.Forms.Label lblMovie;
        private System.Windows.Forms.FlowLayoutPanel flpMovies;
    }
}