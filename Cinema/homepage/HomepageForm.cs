using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Cinema.Forms.profile;
using Cinema.Forms.SignUp_SignIn;

namespace Cinema.homepage
{
    public partial class HomepageForm : Form
    {
        private DataAccess dataAccess = new DataAccess();
        private header_bar headerBar;
        private Panel contentPanel;

        public HomepageForm()
        {
            InitializeComponent();

            // Khởi tạo và thêm header_bar vào form
            headerBar = new header_bar();
            headerBar.Dock = DockStyle.Top;
            this.Controls.Add(headerBar);

            // Thêm contentPanel để hiển thị UserControl
            contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, headerBar.Height),
                Size = new Size(this.ClientSize.Width, this.ClientSize.Height - headerBar.Height)
            };
            this.Controls.Add(contentPanel);

            // Kết nối database
            try
            {
                dataAccess = new DataAccess();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect to database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            Console.WriteLine($"UserSession in HomepageForm: IsLoggedIn={UserSession.IsLoggedIn}, MemberId={UserSession.MemberId}, Email={UserSession.Email}");

            LoadMovies(true);
        }

        private void LoadMovies(bool showShowingMovies)
        {
            flpMovies.Controls.Clear();

            try
            {
                string query = "SELECT id, movie_name, poster, release_date, isDeleted FROM movie WHERE isDeleted = 0";
                DataTable dt = dataAccess.ExecuteQueryTable(query);

                List<Movie> movies = new List<Movie>();
                foreach (DataRow row in dt.Rows)
                {
                    movies.Add(new Movie
                    {
                        id = Convert.ToInt32(row["id"]),
                        movie_name = row["movie_name"].ToString(),
                        poster = row["poster"]?.ToString() ?? string.Empty,
                        release_date = Convert.ToDateTime(row["release_date"]),
                    });
                }

                var filteredMovies = showShowingMovies
                    ? movies.Where(m => m.IsShowing).ToList()
                    : movies.Where(m => !m.IsShowing).ToList();

                foreach (var movie in filteredMovies)
                {
                    MovieControl movieControl = new MovieControl(movie);
                    flpMovies.Controls.Add(movieControl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading movies: {ex.Message}\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Phương thức để hiển thị UserControl
        public void ShowUserControl(UserControl userControl)
        {
            contentPanel.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(userControl);
            flpMovies.Visible = false; // Ẩn danh sách phim khi hiển thị UserControl
            lblMovie.Visible = false;
            lblName.Visible = false;
            lblShow.Visible = false;
            lblCome.Visible = false;
        }

        // Phương thức để lấy ProfileForm (dùng trong UCPolicies và UCMembership)
        public ProfileForm GetProfileForm()
        {
            return new ProfileForm(); // Trả về một instance mới của ProfileForm
        }
    }
}