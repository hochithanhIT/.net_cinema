//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace Cinema.forms.profile
//{
//    public partial class UCTicketHistory : UserControl
//    {
//        private ProfileForm ProfileForm;
//        public UCTicketHistory(ProfileForm ProfileForm)
//        {
//            InitializeComponent();
//            this.ProfileForm = ProfileForm;
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Cinema.forms.profile
{
    public partial class UCTicketHistory : UserControl
    {
        private ProfileForm ProfileForm;
        private DataAccess dataAccess = new DataAccess();
        private string userEmail;
        private string userPhone;

        public UCTicketHistory(ProfileForm ProfileForm, string email, string phone)
        {
            InitializeComponent();
            this.ProfileForm = ProfileForm;
            this.userEmail = email;
            this.userPhone = phone;

            // Load ticket history when the control is initialized
            LoadTicketHistory();
        }

        private void LoadTicketHistory()
        {
            try
            {
                // Get user ID based on email or phone
                string userIdQuery = "SELECT ID FROM THEATER_MEM WHERE EMAIL = @email OR PHONE = @phone";
                SqlCommand userIdCmd = new SqlCommand(userIdQuery, dataAccess.Sqlcon);
                userIdCmd.Parameters.AddWithValue("@email", userEmail);
                userIdCmd.Parameters.AddWithValue("@phone", userPhone);

                int userId = Convert.ToInt32(userIdCmd.ExecuteScalar());

                // Query to get ticket history with all required information
                string query = @"
                    SELECT 
                        m.movie_name,
                        t.theater_name,
                        s.SEAT_CODE,
                        sch.START_TIME as date,
                        mr.DISCOUNT,
                        ti.FIRST_AMOUNT,
                        ti.DISCOUNT as applied_discount,
                        (ti.FIRST_AMOUNT - ti.DISCOUNT) as total_price,
                        ti.CREATED_DATE as purchase_date
                    FROM 
                        TICKET ti
                    JOIN 
                        SCHEDULE sch ON ti.SCHEDULE_ID = sch.ID
                    JOIN 
                        movie m ON sch.MOVIE_ID = m.id
                    JOIN 
                        theater t ON sch.THEATER_ID = t.id
                    JOIN 
                        SEAT s ON ti.SEAT_CODE = s.ID
                    JOIN 
                        THEATER_MEM tm ON ti.MEM_ID = tm.ID
                    LEFT JOIN 
                        MEMBER_RANK mr ON 
                            (CASE 
                                WHEN tm.SPENDING < 1000000 THEN 0
                                WHEN tm.SPENDING < 3000000 THEN 1000000
                                WHEN tm.SPENDING < 10000000 THEN 3000000
                                ELSE 10000000
                            END) = mr.THRESHOLD
                    WHERE 
                        ti.MEM_ID = @userId
                    ORDER BY 
                        ti.CREATED_DATE DESC";

                SqlCommand cmd = new SqlCommand(query, dataAccess.Sqlcon);
                cmd.Parameters.AddWithValue("@userId", userId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Remove the template panel and create dynamic panels for each ticket
                panelMovie.Visible = false;

                // Clear any existing ticket panels (for refreshes)
                foreach (Control control in Controls)
                {
                    if (control is Panel && control.Name.StartsWith("ticketPanel_"))
                    {
                        Controls.Remove(control);
                    }
                }

                // Create a panel for each ticket
                int panelHeight = 153;
                int panelGap = 20;
                int startY = 101;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];

                    Panel ticketPanel = CreateTicketPanel(
                        row["movie_name"].ToString(),
                        row["theater_name"].ToString(),
                        row["SEAT_CODE"].ToString(),
                        Convert.ToDateTime(row["date"]),
                        Convert.ToDecimal(row["DISCOUNT"]),
                        Convert.ToInt32(row["FIRST_AMOUNT"]),
                        Convert.ToInt32(row["applied_discount"]),
                        Convert.ToInt32(row["total_price"]),
                        startY + (i * (panelHeight + panelGap))
                    );

                    Controls.Add(ticketPanel);
                    ticketPanel.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading ticket history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreateTicketPanel(string movieName, string theaterName, string seatCode,
                                       DateTime showDate, decimal discountRate, int firstAmount,
                                       int appliedDiscount, int totalPrice, int yPosition)
        {
            // Create a new panel based on the template
            Panel panel = new Panel();
            panel.Name = $"ticketPanel_{Guid.NewGuid()}";
            panel.Size = panelMovie.Size;
            panel.Location = new Point(panelMovie.Location.X, yPosition);
            panel.BorderStyle = BorderStyle.FixedSingle;

            // Movie name
            Label lblMovie = new Label();
            lblMovie.AutoSize = true;
            lblMovie.Location = new Point(30, 23);
            lblMovie.Text = $"Movie: {movieName}";
            lblMovie.Font = lblMovieName.Font;

            // Theater name
            Label lblTheater = new Label();
            lblTheater.AutoSize = true;
            lblTheater.Location = new Point(30, 66);
            lblTheater.Text = $"Theater: {theaterName}";
            lblTheater.Font = lblTheaterName.Font;

            // Seat code
            Label lblSeat = new Label();
            lblSeat.AutoSize = true;
            lblSeat.Location = new Point(30, 108);
            lblSeat.Text = $"Seat code: {seatCode}";
            lblSeat.Font = blbSeatCode.Font;

            // Date
            Label lblShowDate = new Label();
            lblShowDate.AutoSize = true;
            lblShowDate.Location = new Point(480, 23);
            lblShowDate.Text = $"Date: {showDate.ToString("yyyy-MM-dd HH:mm")}";
            lblShowDate.Font = lblDate.Font;

            // Discount
            Label lblDiscountValue = new Label();
            lblDiscountValue.AutoSize = true;
            lblDiscountValue.Location = new Point(480, 66);
            lblDiscountValue.Text = $"Discount: {discountRate:P0} ({appliedDiscount:C0})";
            lblDiscountValue.Font = lblDiscount.Font;

            // Total price
            Label lblTotalPrice = new Label();
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Location = new Point(480, 108);
            lblTotalPrice.Text = $"Total Price: {totalPrice:C0} (Original: {firstAmount:C0})";
            lblTotalPrice.Font = lnlTotalPrice.Font;

            // Add all labels to the panel
            panel.Controls.Add(lblMovie);
            panel.Controls.Add(lblTheater);
            panel.Controls.Add(lblSeat);
            panel.Controls.Add(lblShowDate);
            panel.Controls.Add(lblDiscountValue);
            panel.Controls.Add(lblTotalPrice);

            return panel;
        }
    }
}