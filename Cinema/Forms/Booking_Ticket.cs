using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cinema.Forms {
    public partial class Booking_Ticket : Form {
        private DataAccess dataAccess;
        private int scheduleId;
        private int memberId;
        private List<string> selectedSeats;
        private Dictionary<string, Button> seatButtons;
        private const int ticketPrice = 80000;

        public Booking_Ticket(int scheduleId, int memberId) {
            InitializeComponent();
            this.scheduleId = scheduleId;
            this.memberId = memberId;
            this.dataAccess = new DataAccess();
            this.selectedSeats = new List<string>();
            this.seatButtons = new Dictionary<string, Button>();
        }

        private void Booking_Ticket_Load(object sender, EventArgs e) {
            //MessageBox.Show($"Schedule ID: {scheduleId}, Member ID: {memberId}", "Debug");

            // Load the screen.png image
            try {
                string imagePath = System.IO.Path.Combine(Application.StartupPath, "assets", "icon", "screen.png");
                pictureBoxScreen.Image = Image.FromFile(imagePath);
            }
            catch (Exception ex) {
                MessageBox.Show($"Error loading screen.png: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadMovieDetails();
            LoadSeatLayout();
            UpdateBookingInfo();
            panelLegend.Refresh();
        }

        private void panelScreen_Paint(object sender, PaintEventArgs e) {
            using (Font font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold)) {
                string text = "SCREEN";
                SizeF textSize = e.Graphics.MeasureString(text, font);
                float textX = (panelScreen.Width - textSize.Width) / 2;
                float textY = (panelScreen.Height - textSize.Height) / 2;
                e.Graphics.DrawString(text, font, Brushes.Black, textX, textY);
            }

            using (Pen pen = new Pen(Color.Red, 3)) {
                int arcWidth = 200;
                int arcHeight = 50;
                int arcX = (panelScreen.Width - arcWidth) / 2;
                int arcY = 0;
                e.Graphics.DrawArc(pen, arcX, arcY, arcWidth, arcHeight, 0, 180);
            }
        }

        private void LoadMovieDetails() {
            try {
                string query = @"
                    SELECT M.movie_name
                    FROM SCHEDULE S
                    JOIN MOVIE M ON S.MOVIE_ID = M.id
                    WHERE S.ID = @scheduleId";

                var command = new System.Data.SqlClient.SqlCommand(query, dataAccess.Sqlcon);
                command.Parameters.AddWithValue("@scheduleId", scheduleId);
                dataAccess.Sqlcom = command;

                var reader = command.ExecuteReader();
                if (reader.Read()) {
                    labelMovieNameValue.Text = reader["movie_name"].ToString();
                }
                else {
                    MessageBox.Show("No movie found for the given schedule ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                reader.Close();
            }
            catch (Exception ex) {
                MessageBox.Show($"Error loading movie details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSeatLayout() {
            try {
                string query = @"
            SELECT S.SEAT_CODE, T.ID AS THEATER_ID,
                   CASE WHEN TK.ID IS NOT NULL THEN 1 ELSE 0 END AS IsBooked
            FROM SCHEDULE SCH
            JOIN THEATER T ON SCH.THEATER_ID = T.id
            JOIN SEAT S ON S.THEATER_ID = T.ID
            LEFT JOIN TICKET TK ON TK.SEAT_ID = S.ID AND TK.SCHEDULE_ID = SCH.ID
            WHERE SCH.ID = @scheduleId";

                var command = new System.Data.SqlClient.SqlCommand(query, dataAccess.Sqlcon);
                command.Parameters.AddWithValue("@scheduleId", scheduleId);
                dataAccess.Sqlcom = command;

                var reader = command.ExecuteReader();
                int rowCount = 0;
                int bookedCount = 0;
                List<string> bookedSeats = new List<string>();

                // First pass: Count total seats and booked seats
                while (reader.Read()) {
                    rowCount++;
                    bool isBooked = Convert.ToBoolean(reader["IsBooked"]);
                    if (isBooked) {
                        bookedCount++;
                        bookedSeats.Add(reader["SEAT_CODE"].ToString());
                    }
                }
                reader.Close();


                // Second pass: Create seat buttons
                reader = command.ExecuteReader();
                int buttonWidth = 60;
                int buttonHeight = 40;
                int spacing = 5;
                int startX = 10;
                int startY = 10;

                while (reader.Read()) {
                    string seatCode = reader["SEAT_CODE"].ToString();
                    bool isBooked = Convert.ToBoolean(reader["IsBooked"]);

                    Button seatButton = new Button {
                        Text = seatCode,
                        Size = new Size(buttonWidth, buttonHeight),
                        Font = new Font("Microsoft Sans Serif", 10F),
                        Tag = seatCode,
                        Enabled = !isBooked
                    };

                    int row = seatCode[0] - 'A';
                    int col = int.Parse(seatCode.Substring(1)) - 1;
                    seatButton.Location = new Point(startX + col * (buttonWidth + spacing), startY + row * (buttonHeight + spacing));

                    seatButton.BackColor = isBooked ? Color.Red : Color.LightGray;
                    seatButton.ForeColor = isBooked ? Color.White : Color.Black;

                    if (!isBooked) {
                        seatButton.Click += SeatButton_Click;
                    }

                    panelSeats.Controls.Add(seatButton);
                    seatButtons.Add(seatCode, seatButton);
                }
                reader.Close();
            }
            catch (Exception ex) {
                MessageBox.Show($"Error loading seat layout: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeatButton_Click(object sender, EventArgs e) {
            Button clickedButton = sender as Button;
            string seatCode = clickedButton.Tag.ToString();

            if (selectedSeats.Contains(seatCode)) {
                selectedSeats.Remove(seatCode);
                clickedButton.BackColor = Color.LightGray; // Available color
                clickedButton.ForeColor = Color.Black; // Default text color
            }
            else {
                selectedSeats.Add(seatCode);
                clickedButton.BackColor = Color.Red; // Selected color
                clickedButton.ForeColor = Color.White; // White text for selected seats
            }

            UpdateBookingInfo();
        }

        private void UpdateBookingInfo() {
            string selectedSeatsText = selectedSeats.Any() ? string.Join(", ", selectedSeats) : "None";
            labelSelectedSeatsValue.Text = selectedSeatsText;
            int totalPrice = selectedSeats.Count * ticketPrice;
            labelTotalPriceValue.Text = $"{totalPrice:N0} VND";
        }

        private void buttonConfirmBooking_Click(object sender, EventArgs e) {
            if (!selectedSeats.Any()) {
                MessageBox.Show("Please select at least one seat to book.", "No Seats Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try {
                string memberCheckQuery = "SELECT COUNT(*) FROM THEATER_MEM WHERE ID = @memberId";
                var memberCheckCommand = new System.Data.SqlClient.SqlCommand(memberCheckQuery, dataAccess.Sqlcon);
                memberCheckCommand.Parameters.AddWithValue("@memberId", memberId);
                int memberCount = Convert.ToInt32(memberCheckCommand.ExecuteScalar());

                if (memberCount == 0) {
                    MessageBox.Show("Invalid member ID. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string rankQuery = @"
                    SELECT MR.DISCOUNT
                    FROM THEATER_MEM TM
                    JOIN MEMBER_RANK MR ON TM.SPENDING >= MR.THRESHOLD
                    WHERE TM.ID = @memberId
                    ORDER BY MR.THRESHOLD DESC";

                var rankCommand = new System.Data.SqlClient.SqlCommand(rankQuery, dataAccess.Sqlcon);
                rankCommand.Parameters.AddWithValue("@memberId", memberId);
                var discount = Convert.ToDecimal(rankCommand.ExecuteScalar());

                int totalPrice = selectedSeats.Count * ticketPrice;
                int discountAmount = (int)(totalPrice * discount);
                int finalPrice = totalPrice - discountAmount;

                foreach (var seatCode in selectedSeats) {
                    string seatQuery = "SELECT ID FROM SEAT WHERE SEAT_CODE = @seatCode AND THEATER_ID = (SELECT THEATER_ID FROM SCHEDULE WHERE ID = @scheduleId)";
                    var seatCommand = new System.Data.SqlClient.SqlCommand(seatQuery, dataAccess.Sqlcon);
                    seatCommand.Parameters.AddWithValue("@seatCode", seatCode);
                    seatCommand.Parameters.AddWithValue("@scheduleId", scheduleId);
                    int seatId = Convert.ToInt32(seatCommand.ExecuteScalar());

                    string insertQuery = @"
                        INSERT INTO TICKET (MEM_ID, SCHEDULE_ID, SEAT_ID, FIRST_AMOUNT, DISCOUNT, CREATED_DATE)
                        VALUES (@memId, @scheduleId, @seatId, @firstAmount, @discount, GETDATE())";

                    var insertCommand = new System.Data.SqlClient.SqlCommand(insertQuery, dataAccess.Sqlcon);
                    insertCommand.Parameters.AddWithValue("@memId", memberId);
                    insertCommand.Parameters.AddWithValue("@scheduleId", scheduleId);
                    insertCommand.Parameters.AddWithValue("@seatId", seatId);
                    insertCommand.Parameters.AddWithValue("@firstAmount", ticketPrice);
                    insertCommand.Parameters.AddWithValue("@discount", (int)(ticketPrice * discount));
                    insertCommand.ExecuteNonQuery();
                }

                string updateSpendingQuery = "UPDATE THEATER_MEM SET SPENDING = SPENDING + @amount WHERE ID = @memberId";
                var updateCommand = new System.Data.SqlClient.SqlCommand(updateSpendingQuery, dataAccess.Sqlcon);
                updateCommand.Parameters.AddWithValue("@amount", finalPrice);
                updateCommand.Parameters.AddWithValue("@memberId", memberId);
                updateCommand.ExecuteNonQuery();

                MessageBox.Show("Booking confirmed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex) {
                MessageBox.Show($"Error confirming booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}