using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            
            TheaterCombobox.SelectedIndexChanged += TheaterCombobox_SelectedIndexChanged;
        }



        private void TheaterCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TheaterCombobox.SelectedValue != null)
            {
                int selectedTheaterId;

                if (TheaterCombobox.SelectedValue is DataRowView rowView)
                {
                    // Lấy giá trị theater_id từ DataRowView
                    selectedTheaterId = Convert.ToInt32(rowView["theater_id"]);
                }
                else if (int.TryParse(TheaterCombobox.SelectedValue.ToString(), out selectedTheaterId))
                {
                    // Chuyển đổi nếu SelectedValue là số nguyên hợp lệ
                }
                else
                {
                    MessageBox.Show("Lỗi: Không thể chuyển đổi giá trị của phòng chiếu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoadSeats(selectedTheaterId);
            }
        }


        private void LoadSeats(int theaterId)
        {
            SeatPanel.Controls.Clear(); // Xóa sơ đồ ghế cũ

            // Lấy danh sách tất cả ghế trong phòng chiếu
            string querySeats = $"SELECT ID, SEAT_CODE FROM SEAT WHERE THEATER_ID = {theaterId}";
            DataTable seats = dataAccess.ExecuteQueryTable(querySeats);

            // Lấy danh sách các ghế đã được đặt từ bảng TICKET
            string queryBookedSeats = $"SELECT SEAT_ID FROM TICKET WHERE SCHEDULE_ID IN (SELECT ID FROM SCHEDULE WHERE THEATER_ID = {theaterId})";
            DataTable bookedSeats = dataAccess.ExecuteQueryTable(queryBookedSeats);

            // Chuyển danh sách ghế đã đặt thành HashSet để tra cứu nhanh
            HashSet<int> bookedSeatIds = new HashSet<int>();
            foreach (DataRow row in bookedSeats.Rows)
            {
                bookedSeatIds.Add(Convert.ToInt32(row["SEAT_ID"]));
            }

            int seatPerRow = 12; // Mỗi hàng có 12 ghế
            int index = 0;

            foreach (DataRow row in seats.Rows)
            {
                int seatId = Convert.ToInt32(row["ID"]);
                string seatCode = row["SEAT_CODE"].ToString();

                Button seatButton = new Button();
                seatButton.Text = seatCode;
                seatButton.Width = 60;
                seatButton.Height = 60;
                seatButton.Font = new Font("Arial", 8, FontStyle.Bold);
                seatButton.FlatStyle = FlatStyle.Flat;
                seatButton.FlatAppearance.BorderSize = 0;
                seatButton.Cursor = Cursors.Hand;

                // Kiểm tra nếu ghế đã được đặt
                if (bookedSeatIds.Contains(seatId))
                {
                    seatButton.BackColor = Color.FromArgb(155, 63, 65); // Màu đỏ
                    seatButton.ForeColor = Color.White; // Chữ màu trắng
                    
                }
                else
                {
                    seatButton.BackColor = Color.Gainsboro; // Màu ghế trống
                    seatButton.ForeColor = Color.Black; // Chữ màu đen
                    seatButton.Enabled = true; // Có thể bấm
                }

                // Bo góc ghế
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                int cornerRadius = 39;
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



        private void FMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FMovie.SelectedItem == null)
            {
                return;
            }

            try
            {
                // Kiểm tra nếu SelectedItem là DataRowView, thì lấy giá trị từ nó
                if (FMovie.SelectedItem is DataRowView rowView)
                {
                    int selectedMovieID = Convert.ToInt32(rowView["id"]);
                    LoadScheduleByMovie(selectedMovieID);
                }
                else
                {
                    int selectedMovieID = Convert.ToInt32(FMovie.SelectedValue);
                    LoadScheduleByMovie(selectedMovieID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chọn phim: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       



        private void FDate_ValueChanged(object sender, EventArgs e)
        {
            LoadMoviesByDate();
        }

        private void LoadMoviesByDate()
        {
            DateTime selectedDate = FDate.Value;
            string formattedDate = selectedDate.ToString("yyyy-MM-dd");

            string query = $@"
        SELECT DISTINCT m.id, m.movie_name
        FROM schedule s
        JOIN movie m ON s.movie_id = m.id
        WHERE CAST(s.start_time AS DATE) = '{formattedDate}'";

            DataTable movies = dataAccess.ExecuteQueryTable(query);

            // Kiểm tra nếu không có phim nào
            if (movies.Rows.Count == 0)
            {
                FMovie.DataSource = null; // Xóa dữ liệu cũ
                FMovie.Items.Clear();
                return;
            }

            FMovie.DataSource = movies;
            FMovie.DisplayMember = "movie_name";
            FMovie.ValueMember = "id";

            // Chỉ đặt SelectedIndex nếu có dữ liệu
            if (movies.Rows.Count > 0)
            {
                FMovie.SelectedIndex = 0;
            }

            // Điều chỉnh kích thước dropdown để hiển thị tên đầy đủ
            FMovie.DropDownWidth = GetDropDownWidth(FMovie);
        }


        private int GetDropDownWidth(ComboBox myCombo)
        {
            int maxWidth = myCombo.Width;
            using (Graphics g = myCombo.CreateGraphics())
            {
                foreach (DataRowView item in myCombo.Items)
                {
                    int itemWidth = (int)g.MeasureString(item["movie_name"].ToString(), myCombo.Font).Width + 10;
                    maxWidth = Math.Max(maxWidth, itemWidth);
                }
            }
            return maxWidth;
        }


        private void LoadScheduleByMovie(int movieID)
        {
            if (FDate.Value == null)
            {
                MessageBox.Show("Vui lòng chọn ngày hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime selectedDate = FDate.Value;  // Lấy ngày đã chọn
            string query = $@"
        SELECT FORMAT(START_TIME, 'HH:mm') AS ShowTime 
        FROM schedule 
        WHERE MOVIE_ID = {movieID} 
        AND CONVERT(date, START_TIME) = '{selectedDate:yyyy-MM-dd}' 
        ORDER BY START_TIME";

            try
            {
                DataAccess dataAccess = new DataAccess(); // Tạo kết nối từ lớp DataAccess
                DataTable dt = dataAccess.ExecuteQueryTable(query);

                // Xóa dữ liệu cũ và cập nhật danh sách suất chiếu
                FSchedule.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    FSchedule.Items.Add(row["ShowTime"].ToString());
                }

                // Kiểm tra nếu không có suất chiếu
                if (FSchedule.Items.Count == 0)
                {
                    FSchedule.Items.Add("Không có suất chiếu nào");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải suất chiếu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void FSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FSchedule.SelectedItem == null || FMovie.SelectedValue == null)
            {
                return;
            }

            try
            {
                string selectedTime = FSchedule.SelectedItem.ToString();
                int selectedMovieID = Convert.ToInt32(FMovie.SelectedValue);
                DateTime selectedDate = FDate.Value;

                string query = $@"
        SELECT DISTINCT s.theater_id, t.theater_name
        FROM schedule s
        JOIN theater t ON s.theater_id = t.id
        WHERE s.movie_id = {selectedMovieID}
        AND FORMAT(s.start_time, 'HH:mm') = '{selectedTime}'
        AND CONVERT(date, s.start_time) = '{selectedDate:yyyy-MM-dd}'
        ORDER BY t.theater_name";

                DataTable result = dataAccess.ExecuteQueryTable(query);

                // Kiểm tra nếu có dữ liệu
                if (result.Rows.Count > 0)
                {
                    TheaterCombobox.DataSource = result;
                    TheaterCombobox.DisplayMember = "theater_name";
                    TheaterCombobox.ValueMember = "theater_id";
                    TheaterCombobox.SelectedIndex = 0; // Chọn phòng đầu tiên

                    int selectedTheaterId = Convert.ToInt32(TheaterCombobox.SelectedValue);
                    LoadSeats(selectedTheaterId); // Load sơ đồ ghế cho phòng đó
                }
                else
                {
                    TheaterCombobox.DataSource = null; // Không có phòng chiếu
                    TheaterCombobox.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải rạp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UC_Theaters_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

