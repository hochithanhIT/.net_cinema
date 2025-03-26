using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cinema.homepage;

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

        public MovieControl(Movie movie, string fullName = null, string email = null, string phone = null, DateTime? dob = null, string spending = null, string rankName = null, decimal discount = 0)
        {
            InitializeComponent();
            _movie = movie;
            _fullName = fullName;
            _email = email;
            _phone = phone;
            _dob = dob ?? DateTime.Now;
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
            // Mở form moviedetailTemp và truyền thông tin phim cùng thông tin người dùng
            var movieDetailForm = new moviedetailTemp(
                _movie.id,
                _fullName,
                _email,
                _phone,
                _dob,
                _spending,
                _rankName,
                _discount
            );
            movieDetailForm.Show();

            // Đóng HomepageForm
            Form homepageForm = this.FindForm();
            if (homepageForm != null)
            {
                homepageForm.Close();
            }
        }
    }
}