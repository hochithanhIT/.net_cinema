using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Cinema.Admin.UserControls
{
    public partial class UC_Theaters : UserControl
    {
        private DataAccess dataAccess = new DataAccess();

        public UC_Theaters()
        {
            InitializeComponent();
            LoadTheaters();
            TheaterCombobox.SelectedIndexChanged += TheaterCombobox_SelectedIndexChanged;
        }


        private void LoadTheaters()
        {
            string query = "SELECT id, theater_name FROM theater";
            DataTable theaters = dataAccess.ExecuteQueryTable(query);

            TheaterCombobox.DataSource = theaters;
            TheaterCombobox.DisplayMember = "theater_name";
            TheaterCombobox.ValueMember = "id";
            


            // Chọn rạp đầu tiên và load ghế
            if (TheaterCombobox.Items.Count > 0)
            {
                TheaterCombobox.SelectedIndex = 0;
                int firstTheaterId = Convert.ToInt32(TheaterCombobox.SelectedValue);
                LoadSeats(firstTheaterId);
            }
        }


        private void TheaterCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedTheaterId = Convert.ToInt32(TheaterCombobox.SelectedValue);
            LoadSeats(selectedTheaterId);
        }

        private void LoadSeats(int theaterId)
        {
            SeatPanel.Controls.Clear(); // Xóa sơ đồ ghế cũ

            string query = $"SELECT SEAT_CODE FROM seat WHERE THEATER_ID = {theaterId}";
            DataTable seats = dataAccess.ExecuteQueryTable(query);

            int seatPerRow = 12; // Mỗi hàng có 12 ghế
            int index = 0;

            foreach (DataRow row in seats.Rows)
            {
                Button seatButton = new Button();
                seatButton.Text = row["SEAT_CODE"].ToString();
                seatButton.Width = 60;
                seatButton.Height = 60;
                seatButton.Font = new Font("Arial", 8, FontStyle.Bold);
                seatButton.BackColor = Color.LightGray;
                seatButton.FlatStyle = FlatStyle.Flat;
                seatButton.FlatAppearance.BorderSize = 0;
                seatButton.Cursor = Cursors.Hand;

                // Giảm độ bo tròn (Bo góc 15px thay vì bo tròn hoàn toàn)
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                int cornerRadius = 39; // Điều chỉnh mức độ bo tròn
                path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
                path.AddArc(seatButton.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
                path.AddArc(seatButton.Width - cornerRadius, seatButton.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
                path.AddArc(0, seatButton.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
                path.CloseFigure();
                seatButton.Region = new Region(path);

                SeatPanel.Controls.Add(seatButton);

                // Chèn khoảng cách sau ghế thứ 6
                if ((index + 1) % seatPerRow == 6)
                {
                    Label space = new Label();
                    space.Width = 80;
                    SeatPanel.Controls.Add(space);
                }

                index++;

                // Xuống dòng sau mỗi hàng (12 ghế)
                if (index % seatPerRow == 0)
                {
                    SeatPanel.SetFlowBreak(seatButton, true);
                }
            }
        }

    }
}

