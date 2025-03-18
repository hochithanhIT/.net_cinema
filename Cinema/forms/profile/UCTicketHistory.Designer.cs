namespace Cinema.forms.profile
{
    partial class UCTicketHistory
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
            this.panelMovie = new System.Windows.Forms.Panel();
            this.lblMovieName = new System.Windows.Forms.Label();
            this.lblTicketHistory = new System.Windows.Forms.Label();
            this.lblTheaterName = new System.Windows.Forms.Label();
            this.blbSeatCode = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lnlTotalPrice = new System.Windows.Forms.Label();
            this.panelMovie.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMovie
            // 
            this.panelMovie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMovie.Controls.Add(this.lnlTotalPrice);
            this.panelMovie.Controls.Add(this.lblDate);
            this.panelMovie.Controls.Add(this.lblDiscount);
            this.panelMovie.Controls.Add(this.blbSeatCode);
            this.panelMovie.Controls.Add(this.lblTheaterName);
            this.panelMovie.Controls.Add(this.lblMovieName);
            this.panelMovie.Location = new System.Drawing.Point(47, 101);
            this.panelMovie.Name = "panelMovie";
            this.panelMovie.Size = new System.Drawing.Size(879, 153);
            this.panelMovie.TabIndex = 0;
            // 
            // lblMovieName
            // 
            this.lblMovieName.AutoSize = true;
            this.lblMovieName.Location = new System.Drawing.Point(30, 23);
            this.lblMovieName.Name = "lblMovieName";
            this.lblMovieName.Size = new System.Drawing.Size(50, 16);
            this.lblMovieName.TabIndex = 0;
            this.lblMovieName.Text = "Movie: ";
            // 
            // lblTicketHistory
            // 
            this.lblTicketHistory.AutoSize = true;
            this.lblTicketHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicketHistory.Location = new System.Drawing.Point(409, 39);
            this.lblTicketHistory.Name = "lblTicketHistory";
            this.lblTicketHistory.Size = new System.Drawing.Size(173, 29);
            this.lblTicketHistory.TabIndex = 1;
            this.lblTicketHistory.Text = "Ticket History";
            // 
            // lblTheaterName
            // 
            this.lblTheaterName.AutoSize = true;
            this.lblTheaterName.Location = new System.Drawing.Point(30, 66);
            this.lblTheaterName.Name = "lblTheaterName";
            this.lblTheaterName.Size = new System.Drawing.Size(60, 16);
            this.lblTheaterName.TabIndex = 1;
            this.lblTheaterName.Text = "Theater: ";
            // 
            // blbSeatCode
            // 
            this.blbSeatCode.AutoSize = true;
            this.blbSeatCode.Location = new System.Drawing.Point(30, 108);
            this.blbSeatCode.Name = "blbSeatCode";
            this.blbSeatCode.Size = new System.Drawing.Size(75, 16);
            this.blbSeatCode.TabIndex = 2;
            this.blbSeatCode.Text = "Seat code: ";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(480, 66);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(65, 16);
            this.lblDiscount.TabIndex = 3;
            this.lblDiscount.Text = "Discount: ";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(480, 23);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(42, 16);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date: ";
            // 
            // lnlTotalPrice
            // 
            this.lnlTotalPrice.AutoSize = true;
            this.lnlTotalPrice.Location = new System.Drawing.Point(480, 117);
            this.lnlTotalPrice.Name = "lnlTotalPrice";
            this.lnlTotalPrice.Size = new System.Drawing.Size(78, 16);
            this.lnlTotalPrice.TabIndex = 5;
            this.lnlTotalPrice.Text = "Total Price: ";
            // 
            // UCTicketHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTicketHistory);
            this.Controls.Add(this.panelMovie);
            this.Name = "UCTicketHistory";
            this.Size = new System.Drawing.Size(980, 653);
            this.panelMovie.ResumeLayout(false);
            this.panelMovie.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMovie;
        private System.Windows.Forms.Label lblMovieName;
        private System.Windows.Forms.Label blbSeatCode;
        private System.Windows.Forms.Label lblTheaterName;
        private System.Windows.Forms.Label lblTicketHistory;
        private System.Windows.Forms.Label lnlTotalPrice;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDiscount;
    }
}