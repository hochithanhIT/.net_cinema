namespace Cinema
{
    partial class MovieControl
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.picPoster = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.Location = new System.Drawing.Point(18, 274);
            this.lblTitle.MaximumSize = new System.Drawing.Size(200, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "lblTitle";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picPoster
            // 
            this.picPoster.Location = new System.Drawing.Point(7, 13);
            this.picPoster.Name = "picPoster";
            this.picPoster.Size = new System.Drawing.Size(225, 258);
            this.picPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPoster.TabIndex = 2;
            this.picPoster.TabStop = false;
            // 
            // MovieControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picPoster);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "MovieControl";
            this.Size = new System.Drawing.Size(250, 330);
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox picPoster;
    }
}
