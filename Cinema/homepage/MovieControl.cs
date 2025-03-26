//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace Cinema
//{
//    public partial class MovieControl : UserControl
//    {
//        private Movie _movie;
//        public MovieControl(Movie movie)
//        {
//            InitializeComponent();
//            _movie = movie;
//            SetupUI();
//        }
//        private void SetupUI()
//        {   
//            try
//            {
//                string fullPath = Path.Combine(Application.StartupPath, _movie.poster);
//                if (File.Exists(fullPath))
//                {
//                    picPoster.Image = Image.FromFile(fullPath);
//                }
//                else
//                {
//                    picPoster.Image = null;
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error loading poster: {ex.Message}");
//                picPoster.Image = null;
//            }
//            lblTitle.Text = _movie.movie_name;
//            //lblRelease.Text = $"Release: {_movie.release_date.ToShortDateString()}";

//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cinema.Forms;
using Cinema.homepage;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Cinema
{
    public partial class MovieControl : UserControl
    {
        private Movie _movie;
        // Thêm các thông tin người dùng để truyền vào moviedetailTemp
        private string _fullName;
        private string _email;
        private string _phone;
        private DateTime _dob;
        private string _spending;
        private string _rankName;
        private decimal _discount;
        private DataAccess dataAccess = new DataAccess();

        public MovieControl(Movie movie, string fullName = null, string email = null, string phone = null, DateTime? dob = null, string spending = null, string rankName = null, decimal discount = 0)
        {
            InitializeComponent();
            _movie = movie;
            _fullName = fullName;
            _email = email;
            _phone = phone;
            _dob = dob ?? DateTime.Now; // Nếu dob là null, gán giá trị mặc định
            _spending = spending;
            _rankName = rankName;
            _discount = discount;

            SetupUI();

            // Thêm sự kiện nhấp chuột vào toàn bộ UserControl
            this.Click += MovieControl_Click;
            // Đảm bảo các thành phần con (như PictureBox, Label) cũng kích hoạt sự kiện nhấp chuột
            foreach (Control control in this.Controls)
            {
                control.Click += MovieControl_Click;
            }
        }

        private void SetupUI()
        {
            try
            {
                string fullPath = Path.Combine(Application.StartupPath, _movie.poster);
                if (File.Exists(fullPath))
                {
                    picPoster.Image = Image.FromFile(fullPath);
                }
                else
                {
                    picPoster.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading poster: {ex.Message}");
                picPoster.Image = null;
            }
            lblTitle.Text = _movie.movie_name;
            //lblRelease.Text = $"Release: {_movie.release_date.ToShortDateString()}";
        }

        private void MovieControl_Click(object sender, EventArgs e)
        {
            // Get user ID based on email or phone
            string userIdQuery = "SELECT ID FROM THEATER_MEM WHERE EMAIL = @email OR PHONE = @phone";
            SqlCommand userIdCmd = new SqlCommand(userIdQuery, dataAccess.Sqlcon);
            userIdCmd.Parameters.AddWithValue("@email", _email);
            userIdCmd.Parameters.AddWithValue("@phone", _phone);

            object userIdResult = userIdCmd.ExecuteScalar();
            int userId = Convert.ToInt32(userIdResult);

            // Mở form moviedetailTemp và truyền thông tin phim cùng thông tin người dùng
            var movieDetailForm = new Movie_Detail(_movie.id, userId);
            movieDetailForm.Show();

            // Đóng HomepageForm (nếu cần)
            Form homepageForm = this.FindForm();
            if (homepageForm != null)
            {
                homepageForm.Close();
            }
        }
    }
}