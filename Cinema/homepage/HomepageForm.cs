using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.homepage
{
    public partial class HomepageForm : Form
    {
        private DataAccess dataAccess = new DataAccess();
        public HomepageForm()
        {
            InitializeComponent();
            try
            {
                dataAccess = new DataAccess();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect to database: {ex.Message}");
                this.Close();
                return;
            }
            //SetupUI();
            LoadMovies(true);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Session.IsLoggedIn)
            {
                linkLabel1.Text = $"Hello, {Session.UserName}";
            }
            else
            {
                linkLabel1.Text = "Login";
            }
        }


        private void LoadMovies(bool showShowingMovies)
        {
            flpMovies.Controls.Clear(); // Xóa danh sách phim hiện tại

            try
            {
                // Truy vấn lấy tất cả phim từ cơ sở dữ liệu
                string query = "SELECT id, movie_name, poster, release_date FROM movie";
                DataTable dt = dataAccess.ExecuteQueryTable(query);

                List<Movie> movies = new List<Movie>();
                foreach (DataRow row in dt.Rows)
                {
                    movies.Add(new Movie
                    {
                        id = Convert.ToInt32(row["id"]),
                        movie_name = row["movie_name"].ToString(),
                        poster = row["poster"]?.ToString(),
                        release_date = Convert.ToDateTime(row["release_date"])
                    });
                }

                // Lọc phim theo trạng thái
                var filteredMovies = showShowingMovies
                    ? movies.Where(m => m.IsShowing).ToList()
                    : movies.Where(m => !m.IsShowing).ToList();

                // Hiển thị từng phim bằng UserControl
                foreach (var movie in filteredMovies)
                {
                    MovieControl movieControl = new MovieControl(movie);
                    flpMovies.Controls.Add(movieControl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading movies: {ex.Message}");
            }
        }

        private void lblShow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadMovies(true);
        }

        private void lblCome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadMovies(false);
        }
    }

    public static class Session
    {
        public static bool IsLoggedIn { get; set; } = false;
        public static string UserName { get; set; } = string.Empty;
    }
}
