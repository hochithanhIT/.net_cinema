using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Cinema.homepage;

namespace Cinema.Forms.profile
{
    public partial class UCTicketHistory : UserControl
    {
        private ProfileForm ProfileForm;
        private DataAccess dataAccess = new DataAccess();
        private string userEmail;
        private string userPhone;
        private Panel mainPanel;

        public UCTicketHistory(ProfileForm ProfileForm, string email, string phone)
        {
            InitializeComponent();
            this.ProfileForm = ProfileForm;
            this.userEmail = email;
            this.userPhone = phone;

            // Main panel with scroll
            mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.FromArgb(255, 224, 180)
            };
            this.Controls.Add(mainPanel);

            // Add header
            AddHeader();

            // Load ticket history
            LoadTicketHistory();
        }

        private void AddHeader()
        {
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.White
            };

            Label lblTitle = new Label
            {
                Text = "TICKET HISTORY",
                Dock = DockStyle.Left,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 50, 50),
                Padding = new Padding(20, 15, 0, 0),
                AutoSize = true
            };

            Panel divider = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 1,
                BackColor = Color.FromArgb(230, 230, 230)
            };

            headerPanel.Controls.Add(divider);
            headerPanel.Controls.Add(lblTitle);
            mainPanel.Controls.Add(headerPanel);
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

                object userIdResult = userIdCmd.ExecuteScalar();
                if (userIdResult == null)
                {
                    DisplayEmptyMessage();
                    return;
                }

                int userId = Convert.ToInt32(userIdResult);

                // Query to get ticket history
                string query = @"
                    SELECT 
                        m.movie_name,
                        t.theater_name,
                        s.SEAT_CODE,
                        sch.START_TIME as date,
                        mr.DISCOUNT as discount_percent,
                        ti.FIRST_AMOUNT,
                        (ti.FIRST_AMOUNT * mr.DISCOUNT) as applied_discount,
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
                        SEAT s ON ti.SEAT_ID = s.ID
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
                        ti.CREATED_DATE DESC;";

                SqlCommand cmd = new SqlCommand(query, dataAccess.Sqlcon);
                cmd.Parameters.AddWithValue("@userId", userId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Clear existing tickets (except header)
                for (int i = mainPanel.Controls.Count - 1; i >= 0; i--)
                {
                    if (mainPanel.Controls[i].Tag?.ToString() == "ticket")
                    {
                        mainPanel.Controls.RemoveAt(i);
                    }
                }

                // Check if user has no tickets
                if (dt.Rows.Count == 0)
                {
                    DisplayEmptyMessage();
                    return;
                }

                // Create a card for each ticket
                int yPos = 70; // Below header
                foreach (DataRow row in dt.Rows)
                {
                    Panel ticketPanel = CreateTicketPanel(
                        row["movie_name"].ToString(),
                        row["theater_name"].ToString(),
                        row["SEAT_CODE"].ToString(),
                        Convert.ToDateTime(row["date"]),
                        Convert.ToDecimal(row["discount_percent"]),
                        Convert.ToInt32(row["FIRST_AMOUNT"]),
                        Convert.ToInt32(row["applied_discount"]),
                        Convert.ToInt32(row["total_price"]),
                        Convert.ToDateTime(row["purchase_date"])
                    );

                    ticketPanel.Location = new Point(20, yPos);
                    ticketPanel.Tag = "ticket";
                    mainPanel.Controls.Add(ticketPanel);
                    yPos += ticketPanel.Height + 20;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading ticket history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreateTicketPanel(string movieName, string theaterName, string seatCode,
                                       DateTime showDate, decimal discountRate, int firstAmount,
                                       int appliedDiscount, int totalPrice, DateTime purchaseDate)
        {
            CultureInfo vnCulture = new CultureInfo("vi-VN");

            // Main ticket panel
            Panel panel = new Panel
            {
                Size = new Size(760, 180),
                BackColor = Color.White,
                Padding = new Padding(0),
                BorderStyle = BorderStyle.None
            };

            // Add shadow effect
            panel.Paint += (s, e) =>
            {
                int shadowSize = 5;
                int shadowSpread = 3;
                for (int i = 0; i < shadowSize; i++)
                {
                    Rectangle shadowRect = new Rectangle(
                        i + shadowSpread,
                        i + shadowSpread,
                        panel.Width - (i * 2 + shadowSpread * 2),
                        panel.Height - (i * 2 + shadowSpread * 2));
                    using (Pen pen = new Pen(Color.FromArgb(10 * i, 0, 0, 0)))
                    {
                        e.Graphics.DrawRectangle(pen, shadowRect);
                    }
                }
                e.Graphics.FillRectangle(Brushes.White, 0, 0, panel.Width, panel.Height);
            };

            // Movie title and purchase date
            Label lblMovie = new Label
            {
                Text = movieName.ToUpper(),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 50, 50),
                Location = new Point(20, 15),
                AutoSize = true
            };

            Label lblPurchaseDate = new Label
            {
                Text = $"Purchased on {purchaseDate.ToString("dd MMM yyyy 'at' HH:mm")}",
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.FromArgb(120, 120, 120),
                Location = new Point(20, 45),
                AutoSize = true
            };

            // Divider line
            Panel divider = new Panel
            {
                Size = new Size(720, 1),
                Location = new Point(20, 70),
                BackColor = Color.FromArgb(230, 230, 230)
            };

            // Ticket details table
            TableLayoutPanel detailsTable = new TableLayoutPanel
            {
                RowCount = 2,
                ColumnCount = 4,
                Size = new Size(720, 80),
                Location = new Point(20, 80),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                Margin = new Padding(0)
            };

            detailsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            detailsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            detailsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            detailsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            detailsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            detailsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            // Header row
            AddTableHeader(detailsTable, "THEATER", 0, 0);
            AddTableHeader(detailsTable, "SEAT", 0, 1);
            AddTableHeader(detailsTable, "SHOW TIME", 0, 2);
            AddTableHeader(detailsTable, "DISCOUNT", 0, 3);

            // Values row
            AddTableCell(detailsTable, theaterName, 1, 0);
            AddTableCell(detailsTable, seatCode, 1, 1);
            AddTableCell(detailsTable, showDate.ToString("dd MMM yyyy HH:mm"), 1, 2);
            AddTableCell(detailsTable, $"{discountRate:P0}", 1, 3);

            // Price row
            AddTableHeader(detailsTable, "ORIGINAL PRICE", 2, 0);
            AddTableHeader(detailsTable, "DISCOUNT AMOUNT", 2, 1);
            AddTableHeader(detailsTable, "TOTAL PRICE", 2, 2);

            // Price values
            AddTableCell(detailsTable, firstAmount.ToString("C0", vnCulture), 3, 0);
            AddTableCell(detailsTable, appliedDiscount.ToString("C0", vnCulture), 3, 1);
            AddTableCell(detailsTable, totalPrice.ToString("C0", vnCulture), 3, 2, true);

            // Add controls to panel
            panel.Controls.Add(lblMovie);
            panel.Controls.Add(lblPurchaseDate);
            panel.Controls.Add(divider);
            panel.Controls.Add(detailsTable);

            return panel;
        }

        private void AddTableHeader(TableLayoutPanel table, string text, int row, int col)
        {
            Label lbl = new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                ForeColor = Color.FromArgb(120, 120, 120),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.BottomLeft,
                Margin = new Padding(5, 0, 5, 0)
            };
            table.Controls.Add(lbl, col, row);
        }

        private void AddTableCell(TableLayoutPanel table, string text, int row, int col, bool highlight = false)
        {
            Label lbl = new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 9, highlight ? FontStyle.Bold : FontStyle.Regular),
                ForeColor = highlight ? Color.FromArgb(0, 120, 215) : Color.FromArgb(70, 70, 70),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopLeft,
                Margin = new Padding(5, 0, 5, 0)
            };
            table.Controls.Add(lbl, col, row);
        }

        private void DisplayEmptyMessage()
        {
            Panel emptyPanel = new Panel
            {
                Size = new Size(760, 200),
                Location = new Point(20, 70),
                BackColor = Color.White
            };

            Label lblEmptyMessage = new Label
            {
                Text = "NO TICKETS FOUND",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(70, 70, 70),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 40
            };

            Label lblSubMessage = new Label
            {
                Text = "Your ticket history is empty.\nStart booking now to see your tickets here!",
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(120, 120, 120),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 60
            };

            Button btnBookNow = new Button
            {
                Text = "BOOK NOW",
                Size = new Size(180, 45),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Top,
                Margin = new Padding(0, 20, 0, 0)
            };
            btnBookNow.FlatAppearance.BorderSize = 0;
            btnBookNow.Click += (s, e) =>
            {
                HomepageForm homepageForm = new HomepageForm(userEmail, userEmail, userPhone, DateTime.Now, "0", "N/A", 0);
                homepageForm.Show();
                this.ProfileForm.Close();
            };

            emptyPanel.Controls.Add(btnBookNow);
            emptyPanel.Controls.Add(lblSubMessage);
            emptyPanel.Controls.Add(lblEmptyMessage);

            mainPanel.Controls.Add(emptyPanel);
        }
    }
}