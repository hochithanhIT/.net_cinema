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
        private DataAccess dataAccess = new DataAccess();

        public MovieControl(Movie movie)
        {
            InitializeComponent();
            _movie = movie;

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
        }

        private void MovieControl_Click(object sender, EventArgs e)
        {
            // Mở form Movie_Detail
            var movieDetailForm = new Movie_Detail(_movie.id);
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