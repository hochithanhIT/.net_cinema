using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.Forms {
    public partial class Movie_Detail : Form {

        private int movieId;

        public Movie_Detail(int movieId = 1) {
            InitializeComponent();
            this.movieId = movieId;
        }

        private void Movie_Detail_Load(object sender, EventArgs e) {
            Load_Movie_Detail();
        }

        private void Load_Movie_Detail() {
            try {
                DataAccess dataAccess = new DataAccess();

                string movieQuery = $"SELECT * FROM MOVIE WHERE id = {movieId}";
                DataTable movieTable = dataAccess.ExecuteQueryTable(movieQuery);

                if (movieTable.Rows.Count > 0) {
                    DataRow movieRow = movieTable.Rows[0];

                    // Gán dữ liệu từ database vào các thành phần giao diện
                    Movie_Name.Text = movieRow["movie_name"].ToString();
                    Movie_Content.Text = movieRow["movie_description"].ToString();
                    Director_Content.Text = movieRow["director"].ToString();
                    Actor_Content.Text = movieRow["movie_cast"].ToString();
                    Genre_Content.Text = movieRow["genre"].ToString();
                    Screening_Content.Text = Convert.ToDateTime(movieRow["release_date"]).ToString("dd/MM/yyyy");
                    Duration_Content.Text = movieRow["running_time"].ToString() + " minutes";

                    // Điều chỉnh chiều cao của Actor_Content dựa trên nội dung
                    Actor_Content.Height = Actor_Content.GetPreferredSize(new Size(Actor_Content.Width, 0)).Height;
                    // Điều chỉnh chiều cao của Movie_Content dựa trên nội dung
                    Movie_Content.Height = Movie_Content.GetPreferredSize(new Size(Movie_Content.Width, 0)).Height;

                    // Tải và hiển thị poster
                    string posterPath = movieRow["poster"].ToString();
                    if (!string.IsNullOrEmpty(posterPath) && System.IO.File.Exists(posterPath)) {
                        Console.WriteLine(posterPath);
                        Poster.Image = Image.FromFile(posterPath);
                    }
                    else {
                        Poster.Image = null; // Nếu không tìm thấy file poster, để trống
                    }

                    UpdateScrollBar();
                }
                else {
                    MessageBox.Show("Movies information not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close(); // Đóng form nếu không tìm thấy phim
                    return;
                }

                // Truy vấn thông tin xếp hạng độ tuổi từ bảng is_rated và RATED
                string ratedQuery = @"
                    SELECT R.rated_description 
                    FROM is_rated IR 
                    JOIN RATED R ON R.id = IR.rated_id 
                    WHERE IR.movie_id = " + movieId;

                DataTable ratedTable = dataAccess.ExecuteQueryTable(ratedQuery);

                if (ratedTable.Rows.Count > 0) {
                    Rated_Content.Text = ratedTable.Rows[0]["rated_description"].ToString();
                }
                else {
                    Rated_Content.Text = "Rated information not found!";
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Error when fetching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateScrollBar() {
            // Tìm thành phần cuối cùng dựa trên vị trí Y
            Control lastControl = null;
            int maxBottom = 0;

            foreach (Control control in panel_Body.Controls) {
                int controlBottom = control.Location.Y + control.Height;
                if (controlBottom > maxBottom) {
                    maxBottom = controlBottom;
                    lastControl = control;
                }
            }

            // Tính tổng chiều cao dựa trên thành phần cuối cùng
            int totalHeight = maxBottom + 10; // Thêm khoảng cách cuối

            // So sánh với chiều cao của MainPanel
            if (totalHeight > panel_Body.ClientSize.Height) {
                // Nếu tổng chiều cao vượt quá chiều cao của MainPanel, bật thanh cuộn
                panel_Body.AutoScrollMinSize = new Size(panel_Body.ClientSize.Width - 18, totalHeight);
            }
            else {
                // Nếu không vượt quá, tắt thanh cuộn
                panel_Body.AutoScrollMinSize = new Size(0, 0);
            }
        }

        private void Booking_Button_MouseEnter(object sender, EventArgs e) {
            Booking_Button.BackColor = Color.FromArgb(116, 198, 157);
            Booking_Button.ForeColor = Color.White;
        }

        private void Booking_Button_MouseLeave(object sender, EventArgs e) {
            Booking_Button.BackColor = Color.FromArgb(148, 213, 180);
            Booking_Button.ForeColor = Color.SeaGreen;
        }

    }
}
