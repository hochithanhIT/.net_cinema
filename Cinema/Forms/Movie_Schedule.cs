using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Cinema.Forms.SignUp_SignIn;
using Cinema.homepage;

namespace Cinema.Forms
{
    public partial class Movie_Schedule : Form
    {
        private int _movieId; // Lưu movieId (nếu có)
        private header_bar _headerBar; // Thêm header_bar

        public Movie_Schedule(int movieId = -1)
        {
            InitializeComponent();
            _movieId = movieId;

            // Khởi tạo và thêm header_bar vào form
            _headerBar = new header_bar();
            _headerBar.Dock = DockStyle.Top; // Đặt header_bar ở đầu form
            this.Controls.Add(_headerBar);
        }

        private void MovieSchedule_Load(object sender, EventArgs e)
        {
            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("Please login to view schedule.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormRegistration loginForm = new FormRegistration();
                loginForm.Show();
                this.Close();
                return;
            }

            LoadShowDates();
        }

        private void LoadShowDates()
        {
            try
            {
                panelDateSelector.Controls.Clear(); // Xóa các ngày cũ
                DateTime today = DateTime.Today; // Ngày hiện tại 
                int daysToShow = 7; // Hiển thị 7 ngày tới

                Button selectedButton = null; // Lưu nút của ngày hiện tại

                for (int i = 0; i < daysToShow; i++)
                {
                    DateTime showDate = today.AddDays(i);
                    Button btn = new Button()
                    {
                        Text = showDate.ToString("dd/MM/yyyy"),
                        Width = 150,
                        Height = 40,
                        BackColor = Color.LightGray,
                        Tag = showDate
                    };

                    // Nếu ngày này là ngày hiện tại, đánh dấu để chọn mặc định
                    if (showDate.Date == today.Date)
                    {
                        selectedButton = btn;
                        btn.BackColor = Color.Blue;
                        btn.ForeColor = Color.White; // Đặt màu chữ thành trắng cho ngày hiện tại
                    }

                    btn.Click += (s, e) =>
                    {
                        foreach (Button b in panelDateSelector.Controls)
                        {
                            b.BackColor = Color.LightGray;
                            b.ForeColor = Color.Black; // Đặt lại màu chữ của các nút khác
                        }
                        btn.BackColor = Color.Blue;
                        btn.ForeColor = Color.White; // Đặt màu chữ của nút được chọn thành trắng
                        LoadMovies(showDate);
                    };

                    panelDateSelector.Controls.Add(btn);
                }

                // Tự động chọn ngày hiện tại và load suất chiếu
                if (selectedButton != null)
                {
                    LoadMovies(today);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch chiếu: " + ex.Message);
            }
        }

        private void LoadMovies(DateTime selectedDate)
        {
            try
            {
                DataAccess db = new DataAccess();
                // Định dạng selectedDate thành chuỗi yyyy-MM-dd để sử dụng trong truy vấn
                string formattedDate = selectedDate.ToString("yyyy-MM-dd");
                string query = @"
                    SELECT DISTINCT M.ID, M.MOVIE_NAME, M.POSTER, S.START_TIME 
                    FROM schedule S 
                    JOIN movie M ON S.MOVIE_ID = M.ID 
                    WHERE CAST(S.START_TIME AS DATE) = '" + formattedDate + "' AND M.isDeleted = 0";

                // Nếu movieId được truyền vào (khác -1), thêm điều kiện lọc theo movieId
                if (_movieId != -1)
                {
                    query += " AND M.ID = " + _movieId;
                }

                query += " ORDER BY M.ID, S.START_TIME"; // Sắp xếp theo ID phim và giờ chiếu

                // Sử dụng ExecuteQueryTable với chuỗi truy vấn đã được nối
                DataTable dt = db.ExecuteQueryTable(query);
                panelMovies.Controls.Clear(); // Xóa danh sách phim cũ

                if (dt.Rows.Count == 0)
                {
                    Label lblNoMovies = new Label()
                    {
                        Text = "Không có phim nào được chiếu trong ngày này.",
                        ForeColor = Color.Red,
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Top
                    };
                    panelMovies.Controls.Add(lblNoMovies);
                    return;
                }

                // Nhóm các suất chiếu theo phim
                var movies = dt.AsEnumerable()
                    .GroupBy(row => new
                    {
                        Id = row.Field<int>("ID"),
                        MovieName = row.Field<string>("MOVIE_NAME"),
                        Poster = row.Field<string>("POSTER")
                    });

                foreach (var movie in movies)
                {
                    string title = movie.Key.MovieName;
                    string posterPath = movie.Key.Poster;

                    // Tạo panel cho mỗi phim
                    Panel moviePanel = new Panel()
                    {
                        Width = 1150, // Chiều rộng tối đa của panelMovies
                        Height = 150,
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    // Hiển thị poster
                    PictureBox poster = new PictureBox()
                    {
                        ImageLocation = posterPath,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Width = 100,
                        Height = 150,
                        Left = 10
                    };

                    // Hiển thị tiêu đề phim
                    Label lblTitle = new Label()
                    {
                        Text = title,
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        Left = 120,
                        Top = 10,
                        Width = 300
                    };

                    // Tạo FlowLayoutPanel để chứa các nút suất chiếu
                    FlowLayoutPanel showTimesPanel = new FlowLayoutPanel()
                    {
                        Left = 120,
                        Top = 40,
                        Width = 1000, // Đủ rộng để chứa các nút
                        Height = 100,
                        AutoSize = true,
                        FlowDirection = FlowDirection.LeftToRight
                    };

                    // Thu thập tất cả các suất chiếu của phim này
                    foreach (var row in movie)
                    {
                        string showTime = Convert.ToDateTime(row["START_TIME"]).ToString("HH:mm");

                        // Tạo nút cho mỗi suất chiếu
                        Button showTimeButton = new Button()
                        {
                            Text = showTime,
                            Width = 80,
                            Height = 40,
                            BackColor = Color.LightBlue,
                            Tag = new { MovieId = movie.Key.Id, StartTime = row["START_TIME"] } // Lưu thông tin để sử dụng sau
                        };

                        // Thêm sự kiện nhấp chuột cho nút
                        showTimeButton.Click += (s, e) =>
                        {
                            var tag = (dynamic)showTimeButton.Tag;
                            int movieId = tag.MovieId;
                            DateTime startTime = Convert.ToDateTime(tag.StartTime);

                            // Truy vấn để lấy scheduleId
                            try
                            {
                                string scheduleQuery = @"
                            SELECT ID 
                            FROM SCHEDULE 
                            WHERE MOVIE_ID = @movieId 
                            AND START_TIME = @startTime";

                                var scheduleCommand = new System.Data.SqlClient.SqlCommand(scheduleQuery, db.Sqlcon);
                                scheduleCommand.Parameters.AddWithValue("@movieId", movieId);
                                scheduleCommand.Parameters.AddWithValue("@startTime", startTime);
                                object scheduleIdResult = scheduleCommand.ExecuteScalar();

                                if (scheduleIdResult != null)
                                {
                                    int scheduleId = Convert.ToInt32(scheduleIdResult);

                                    // Mở form Booking_Ticket với MemberId từ UserSession
                                    Booking_Ticket bookingForm = new Booking_Ticket(scheduleId, UserSession.MemberId);
                                    bookingForm.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show("Không tìm thấy suất chiếu. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Lỗi khi lấy scheduleId: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        };

                        showTimesPanel.Controls.Add(showTimeButton);
                    }

                    // Thêm các thành phần vào moviePanel
                    moviePanel.Controls.Add(poster);
                    moviePanel.Controls.Add(lblTitle);
                    moviePanel.Controls.Add(showTimesPanel);

                    // Thêm moviePanel vào panelMovies
                    panelMovies.Controls.Add(moviePanel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải phim: " + ex.Message);
            }
        }
    }
}