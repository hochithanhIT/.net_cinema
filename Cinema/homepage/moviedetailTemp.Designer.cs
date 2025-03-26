namespace Cinema.homepage
{
    partial class moviedetailTemp
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
            this.lblMovieName = new System.Windows.Forms.Label();
            this.lblReleaseDate = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.pbPoster = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMovieName
            // 
            this.lblMovieName.AutoSize = true;
            this.lblMovieName.Location = new System.Drawing.Point(45, 52);
            this.lblMovieName.Name = "lblMovieName";
            this.lblMovieName.Size = new System.Drawing.Size(169, 29);
            this.lblMovieName.TabIndex = 0;
            this.lblMovieName.Text = "lblMovieName";
            // 
            // lblReleaseDate
            // 
            this.lblReleaseDate.AutoSize = true;
            this.lblReleaseDate.Location = new System.Drawing.Point(45, 124);
            this.lblReleaseDate.Name = "lblReleaseDate";
            this.lblReleaseDate.Size = new System.Drawing.Size(179, 29);
            this.lblReleaseDate.TabIndex = 1;
            this.lblReleaseDate.Text = "lblReleaseDate";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(45, 204);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(161, 29);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "lblDescription";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(45, 283);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(106, 29);
            this.lblGenre.TabIndex = 3;
            this.lblGenre.Text = "lblGenre";
            // 
            // pbPoster
            // 
            this.pbPoster.Location = new System.Drawing.Point(297, 55);
            this.pbPoster.Name = "pbPoster";
            this.pbPoster.Size = new System.Drawing.Size(282, 406);
            this.pbPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPoster.TabIndex = 4;
            this.pbPoster.TabStop = false;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(1191, 38);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(112, 60);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // moviedetailTemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 816);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.pbPoster);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblReleaseDate);
            this.Controls.Add(this.lblMovieName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "moviedetailTemp";
            this.Text = "moviedetailTemp";
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMovieName;
        private System.Windows.Forms.Label lblReleaseDate;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.PictureBox pbPoster;
        private System.Windows.Forms.Button btnBack;
    }
}