using Cinema.Admin.Components;
using Cinema.Admin.TheaterComponents;
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
            
            
        }



        private int selectedTheaterId = -1; // Lưu lại ID phòng chiếu đã chọn

        private void TheaterCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TheaterCombobox.SelectedValue != null)
            {
                if (TheaterCombobox.SelectedValue is DataRowView rowView)
                {
                    selectedTheaterId = Convert.ToInt32(rowView["theater_id"]);
                }
                else if (!int.TryParse(TheaterCombobox.SelectedValue.ToString(), out selectedTheaterId))
                {
                    MessageBox.Show("Lỗi: Không thể chuyển đổi giá trị của phòng chiếu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    selectedTheaterId = -1;
                }
            }
        }




        private void LoadSeats(int theaterId, int movieId, DateTime date, string time)
        {
            SeatPanel.Controls.Clear(); // Xóa sơ đồ ghế cũ

            // Lấy danh sách ghế trong phòng chiếu
            string querySeats = $"SELECT ID, SEAT_CODE FROM SEAT WHERE THEATER_ID = {theaterId}";
            DataTable seats = dataAccess.ExecuteQueryTable(querySeats);

            // Lấy danh sách ghế đã đặt theo lịch chiếu, phim và thời gian cụ thể
            string queryBookedSeats = $@"
        SELECT SEAT_ID FROM TICKET 
        WHERE SCHEDULE_ID IN (
            SELECT ID FROM SCHEDULE 
            WHERE THEATER_ID = {theaterId}
            AND MOVIE_ID = {movieId}
            AND CONVERT(date, START_TIME) = '{date:yyyy-MM-dd}'
            AND FORMAT(START_TIME, 'HH:mm') = '{time}'
        )";

            DataTable bookedSeats = dataAccess.ExecuteQueryTable(queryBookedSeats);

            // Chuyển danh sách ghế đã đặt thành HashSet để tra cứu nhanh
            HashSet<int> bookedSeatIds = new HashSet<int>();
            foreach (DataRow row in bookedSeats.Rows)
            {
                bookedSeatIds.Add(Convert.ToInt32(row["SEAT_ID"]));
            }

            int seatPerRow = 12;
            int index = 0;

            foreach (DataRow row in seats.Rows)
            {
                int seatId = Convert.ToInt32(row["ID"]);
                string seatCode = row["SEAT_CODE"].ToString();

                Button seatButton = new Button();
                seatButton.Text = seatCode;
                seatButton.Width = 50;
                seatButton.Height = 50;
                seatButton.Font = new Font("Arial", 7, FontStyle.Bold);
                seatButton.FlatStyle = FlatStyle.Flat;
                seatButton.FlatAppearance.BorderSize = 0;
                seatButton.Cursor = Cursors.Hand;
                seatButton.Margin = new Padding(7);

                // Kiểm tra nếu ghế đã đặt
                if (bookedSeatIds.Contains(seatId))
                {
                    seatButton.BackColor = Color.FromArgb(155, 63, 65);
                    seatButton.ForeColor = Color.White;
                }
                else
                {
                    seatButton.BackColor = Color.Gainsboro;
                    seatButton.ForeColor = Color.Black;
                    seatButton.Enabled = true;
                }

                SeatPanel.Controls.Add(seatButton);

                if ((index + 1) % seatPerRow == 6)
                {
                    Label space = new Label();
                    space.Width = 90;
                    SeatPanel.Controls.Add(space);
                }

                index++;

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
                DateTime parsedTime;
                if (!DateTime.TryParse(FSchedule.SelectedItem.ToString(), out parsedTime))
                {
                    MessageBox.Show("Giờ chiếu không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string selectedTime = parsedTime.ToString("HH:mm");

                int selectedMovieID = Convert.ToInt32(FMovie.SelectedValue);
                DateTime selectedDate = FDate.Value.Date;

                string query = @"
SELECT DISTINCT s.theater_id, t.theater_name
FROM schedule s
JOIN theater t ON s.theater_id = t.id
WHERE s.movie_id = @MovieID
AND FORMAT(s.start_time, 'HH:mm') = @StartTime
AND CAST(s.start_time AS DATE) = @SelectedDate
ORDER BY t.theater_name";

                DataAccess dataAccess = new DataAccess(); // Không dùng `using`

                using (SqlCommand cmd = new SqlCommand(query, dataAccess.Sqlcon))
                {
                    cmd.Parameters.AddWithValue("@MovieID", selectedMovieID);
                    cmd.Parameters.AddWithValue("@StartTime", selectedTime);
                    cmd.Parameters.AddWithValue("@SelectedDate", selectedDate.ToString("yyyy-MM-dd"));

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable result = new DataTable();
                        adapter.Fill(result);

                        if (result.Rows.Count > 0)
                        {
                            TheaterCombobox.DataSource = result;
                            TheaterCombobox.DisplayMember = "theater_name";
                            TheaterCombobox.ValueMember = "theater_id";
                            TheaterCombobox.SelectedIndex = 0;
                        }
                        else
                        {
                            TheaterCombobox.DataSource = null;
                            TheaterCombobox.Items.Clear();
                        }
                    }
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (TheaterCombobox.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng chiếu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedTheaterId;

            if (TheaterCombobox.SelectedValue is DataRowView rowView)
            {
                selectedTheaterId = Convert.ToInt32(rowView["theater_id"]);
            }
            else if (int.TryParse(TheaterCombobox.SelectedValue.ToString(), out selectedTheaterId))
            {
                // Giá trị hợp lệ, tiếp tục xử lý
            }
            else
            {
                MessageBox.Show("Lỗi: Không thể chuyển đổi giá trị của phòng chiếu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem FMovie và FSchedule đã chọn hay chưa
            if (FMovie.SelectedValue == null || FSchedule.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phim và suất chiếu trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ID phim
            int selectedMovieID = Convert.ToInt32(FMovie.SelectedValue);

            // Lấy ngày chiếu
            DateTime selectedDate = FDate.Value;

            // Lấy giờ chiếu từ FSchedule
            string selectedTime = FSchedule.SelectedItem.ToString();

            // Gọi LoadSeats với thông tin đầy đủ
            LoadSeats(selectedTheaterId, selectedMovieID, selectedDate, selectedTime);
        }

        private void ResetFil_Click(object sender, EventArgs e)
        {
            // Reset DateTimePicker về ngày hiện tại
            FDate.Value = DateTime.Now;

            // Xóa và đặt lại danh sách phim
            FMovie.SelectedIndex = -1; // Không chọn phim nào
            FMovie.DataSource = null;

            // Xóa và đặt lại danh sách suất chiếu
            FSchedule.SelectedIndex = -1;
            FSchedule.DataSource = null;

            // Xóa và đặt lại danh sách rạp
            TheaterCombobox.SelectedIndex = -1;
            TheaterCombobox.DataSource = null;

            // Xóa sơ đồ ghế hiện tại
            SeatPanel.Controls.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            // Tạo một instance của ManageTheaters
            ManageTheaters manageTheatersForm = new ManageTheaters();

            // Mở dưới dạng dialog (cửa sổ modal)
            manageTheatersForm.ShowDialog();

            manageTheatersForm.Location = new Point(650, 130);
        }

    }
}

