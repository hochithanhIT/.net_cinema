using System.Windows.Forms;

namespace Cinema.Forms {
    partial class Booking_Ticket {
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

        private void InitializeComponent() {
            this.panelSeats = new System.Windows.Forms.Panel();
            this.panelScreen = new System.Windows.Forms.Panel();
            this.pictureBoxScreen = new System.Windows.Forms.PictureBox();
            this.labelScreen = new System.Windows.Forms.Label();
            this.labelMovieName = new System.Windows.Forms.Label();
            this.labelSelectedSeats = new System.Windows.Forms.Label();
            this.labelTotalPrice = new System.Windows.Forms.Label();
            this.labelBooked = new System.Windows.Forms.Label();
            this.labelAvailable = new System.Windows.Forms.Label();
            this.panelLegend = new System.Windows.Forms.Panel();
            this.panelBookedColor = new System.Windows.Forms.Panel();
            this.panelAvailableColor = new System.Windows.Forms.Panel();
            this.buttonConfirmBooking = new System.Windows.Forms.Button();
            this.labelMovieNameValue = new System.Windows.Forms.Label();
            this.labelSelectedSeatsValue = new System.Windows.Forms.Label();
            this.labelTotalPriceValue = new System.Windows.Forms.Label();
            this.panelScreen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreen)).BeginInit();
            this.panelLegend.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSeats
            // 
            this.panelSeats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSeats.Location = new System.Drawing.Point(50, 100);
            this.panelSeats.Name = "panelSeats";
            this.panelSeats.Size = new System.Drawing.Size(800, 400);
            this.panelSeats.TabIndex = 0;
            // 
            // panelScreen
            // 
            this.panelScreen.Controls.Add(this.pictureBoxScreen);
            this.panelScreen.Controls.Add(this.labelScreen);
            this.panelScreen.Location = new System.Drawing.Point(50, 50);
            this.panelScreen.Name = "panelScreen";
            this.panelScreen.Size = new System.Drawing.Size(800, 40);
            this.panelScreen.TabIndex = 1;
            // 
            // pictureBoxScreen
            // 
            this.pictureBoxScreen.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxScreen.Name = "pictureBoxScreen";
            this.pictureBoxScreen.Size = new System.Drawing.Size(800, 40);
            this.pictureBoxScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxScreen.TabIndex = 0;
            this.pictureBoxScreen.TabStop = false;
            // 
            // labelScreen
            // 
            this.labelScreen.AutoSize = true;
            this.labelScreen.BackColor = System.Drawing.Color.Transparent;
            this.labelScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.labelScreen.ForeColor = System.Drawing.Color.Black;
            this.labelScreen.Location = new System.Drawing.Point(350, 5);
            this.labelScreen.Name = "labelScreen";
            this.labelScreen.Size = new System.Drawing.Size(155, 37);
            this.labelScreen.TabIndex = 1;
            this.labelScreen.Text = "SCREEN";
            this.labelScreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMovieName
            // 
            this.labelMovieName.AutoSize = true;
            this.labelMovieName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelMovieName.Location = new System.Drawing.Point(900, 100);
            this.labelMovieName.Name = "labelMovieName";
            this.labelMovieName.Size = new System.Drawing.Size(180, 32);
            this.labelMovieName.TabIndex = 2;
            this.labelMovieName.Text = "Movie Name:";
            // 
            // labelSelectedSeats
            // 
            this.labelSelectedSeats.AutoSize = true;
            this.labelSelectedSeats.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelSelectedSeats.Location = new System.Drawing.Point(900, 150);
            this.labelSelectedSeats.Name = "labelSelectedSeats";
            this.labelSelectedSeats.Size = new System.Drawing.Size(214, 32);
            this.labelSelectedSeats.TabIndex = 3;
            this.labelSelectedSeats.Text = "Selected Seats:";
            // 
            // labelTotalPrice
            // 
            this.labelTotalPrice.AutoSize = true;
            this.labelTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelTotalPrice.Location = new System.Drawing.Point(900, 351);
            this.labelTotalPrice.Name = "labelTotalPrice";
            this.labelTotalPrice.Size = new System.Drawing.Size(158, 32);
            this.labelTotalPrice.TabIndex = 4;
            this.labelTotalPrice.Text = "Total Price:";
            // 
            // labelBooked
            // 
            this.labelBooked.AutoSize = true;
            this.labelBooked.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelBooked.Location = new System.Drawing.Point(10, 10);
            this.labelBooked.Name = "labelBooked";
            this.labelBooked.Size = new System.Drawing.Size(97, 29);
            this.labelBooked.TabIndex = 5;
            this.labelBooked.Text = "Booked";
            // 
            // labelAvailable
            // 
            this.labelAvailable.AutoSize = true;
            this.labelAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelAvailable.Location = new System.Drawing.Point(120, 10);
            this.labelAvailable.Name = "labelAvailable";
            this.labelAvailable.Size = new System.Drawing.Size(111, 29);
            this.labelAvailable.TabIndex = 6;
            this.labelAvailable.Text = "Available";
            // 
            // panelLegend
            // 
            this.panelLegend.Controls.Add(this.labelBooked);
            this.panelLegend.Controls.Add(this.labelAvailable);
            this.panelLegend.Controls.Add(this.panelBookedColor);
            this.panelLegend.Controls.Add(this.panelAvailableColor);
            this.panelLegend.Location = new System.Drawing.Point(50, 520);
            this.panelLegend.Name = "panelLegend";
            this.panelLegend.Size = new System.Drawing.Size(300, 40);
            this.panelLegend.TabIndex = 7;
            // 
            // panelBookedColor
            // 
            this.panelBookedColor.BackColor = System.Drawing.Color.Red;
            this.panelBookedColor.Location = new System.Drawing.Point(80, 10);
            this.panelBookedColor.Name = "panelBookedColor";
            this.panelBookedColor.Size = new System.Drawing.Size(20, 20);
            this.panelBookedColor.TabIndex = 7;
            // 
            // panelAvailableColor
            // 
            this.panelAvailableColor.BackColor = System.Drawing.Color.LightGray;
            this.panelAvailableColor.Location = new System.Drawing.Point(200, 10);
            this.panelAvailableColor.Name = "panelAvailableColor";
            this.panelAvailableColor.Size = new System.Drawing.Size(24, 20);
            this.panelAvailableColor.TabIndex = 8;
            // 
            // buttonConfirmBooking
            // 
            this.buttonConfirmBooking.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonConfirmBooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonConfirmBooking.Location = new System.Drawing.Point(953, 408);
            this.buttonConfirmBooking.Name = "buttonConfirmBooking";
            this.buttonConfirmBooking.Size = new System.Drawing.Size(200, 50);
            this.buttonConfirmBooking.TabIndex = 8;
            this.buttonConfirmBooking.Text = "Confirm Booking";
            this.buttonConfirmBooking.UseVisualStyleBackColor = false;
            this.buttonConfirmBooking.Click += new System.EventHandler(this.buttonConfirmBooking_Click);
            // 
            // labelMovieNameValue
            // 
            this.labelMovieNameValue.AutoSize = true;
            this.labelMovieNameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelMovieNameValue.Location = new System.Drawing.Point(1095, 100);
            this.labelMovieNameValue.Name = "labelMovieNameValue";
            this.labelMovieNameValue.Size = new System.Drawing.Size(106, 32);
            this.labelMovieNameValue.TabIndex = 9;
            this.labelMovieNameValue.Text = "[Movie]";
            // 
            // labelSelectedSeatsValue
            // 
            this.labelSelectedSeatsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelSelectedSeatsValue.Location = new System.Drawing.Point(1120, 150);
            this.labelSelectedSeatsValue.Name = "labelSelectedSeatsValue";
            this.labelSelectedSeatsValue.Size = new System.Drawing.Size(265, 200);
            this.labelSelectedSeatsValue.TabIndex = 10;
            this.labelSelectedSeatsValue.Text = "None";
            // 
            // labelTotalPriceValue
            // 
            this.labelTotalPriceValue.AutoSize = true;
            this.labelTotalPriceValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelTotalPriceValue.Location = new System.Drawing.Point(1050, 351);
            this.labelTotalPriceValue.Name = "labelTotalPriceValue";
            this.labelTotalPriceValue.Size = new System.Drawing.Size(96, 32);
            this.labelTotalPriceValue.TabIndex = 11;
            this.labelTotalPriceValue.Text = "0 VND";
            // 
            // Booking_Ticket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 653);
            this.Controls.Add(this.labelTotalPriceValue);
            this.Controls.Add(this.labelSelectedSeatsValue);
            this.Controls.Add(this.labelMovieNameValue);
            this.Controls.Add(this.buttonConfirmBooking);
            this.Controls.Add(this.panelLegend);
            this.Controls.Add(this.labelTotalPrice);
            this.Controls.Add(this.labelSelectedSeats);
            this.Controls.Add(this.labelMovieName);
            this.Controls.Add(this.panelScreen);
            this.Controls.Add(this.panelSeats);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Booking_Ticket";
            this.Text = "Booking Ticket";
            this.Load += new System.EventHandler(this.Booking_Ticket_Load);
            this.panelScreen.ResumeLayout(false);
            this.panelScreen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreen)).EndInit();
            this.panelLegend.ResumeLayout(false);
            this.panelLegend.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSeats;
        private System.Windows.Forms.Panel panelScreen;
        private System.Windows.Forms.PictureBox pictureBoxScreen;
        private System.Windows.Forms.Label labelScreen;
        private System.Windows.Forms.Label labelMovieName;
        private System.Windows.Forms.Label labelSelectedSeats;
        private System.Windows.Forms.Label labelTotalPrice;
        private System.Windows.Forms.Label labelBooked;
        private System.Windows.Forms.Label labelAvailable;
        private System.Windows.Forms.Panel panelLegend;
        private System.Windows.Forms.Button buttonConfirmBooking;
        private System.Windows.Forms.Label labelMovieNameValue;
        private System.Windows.Forms.Label labelSelectedSeatsValue;
        private System.Windows.Forms.Label labelTotalPriceValue;
        private System.Windows.Forms.Panel panelBookedColor;
        private System.Windows.Forms.Panel panelAvailableColor;
    }
}