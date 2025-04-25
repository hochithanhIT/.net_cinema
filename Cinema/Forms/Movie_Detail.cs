using Cinema.homepage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Cinema.Forms
{
    public partial class Movie_Detail : Form
    {
        private int movieId;
        private header_bar _headerBar;

        public Movie_Detail(int movieId)
        {
            InitializeComponent();
            this.movieId = movieId;

            // Khởi tạo và thêm header_bar vào form
            _headerBar = new header_bar();
            _headerBar.Dock = DockStyle.Top;
            this.Controls.Add(_headerBar);
        }

        private void Movie_Detail_Load(object sender, EventArgs e)
        {
            Load_Movie_Detail();
        }

        private void Load_Movie_Detail()
        {
            try
            {
                DataAccess dataAccess = new DataAccess();

                string movieQuery = $"SELECT * FROM MOVIE WHERE id = {movieId}";
                DataTable movieTable = dataAccess.ExecuteQueryTable(movieQuery);

                if (movieTable.Rows.Count > 0)
                {
                    DataRow movieRow = movieTable.Rows[0];

                    Movie_Name.Text = movieRow["movie_name"].ToString();
                    Movie_Content.Text = movieRow["movie_description"].ToString();
                    Director_Content.Text = movieRow["director"].ToString();
                    Actor_Content.Text = movieRow["movie_cast"].ToString();
                    Genre_Content.Text = movieRow["genre"].ToString();
                    Screening_Content.Text = Convert.ToDateTime(movieRow["release_date"]).ToString("dd/MM/yyyy");
                    Duration_Content.Text = movieRow["running_time"].ToString() + " minutes";

                    Actor_Content.Height = Actor_Content.GetPreferredSize(new Size(Actor_Content.Width, 0)).Height;
                    Movie_Content.Height = Movie_Content.GetPreferredSize(new Size(Movie_Content.Width, 0)).Height;

                    string posterPath = movieRow["poster"].ToString();
                    if (!string.IsNullOrEmpty(posterPath) && System.IO.File.Exists(posterPath))
                    {
                        Console.WriteLine(posterPath);
                        Poster.Image = Image.FromFile(posterPath);
                    }
                    else
                    {
                        Poster.Image = null;
                    }

                    UpdateScrollBar();
                }
                else
                {
                    MessageBox.Show("Movies information not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                string ratedQuery = @"
                    SELECT R.rated_description 
                    FROM is_rated IR 
                    JOIN RATED R ON R.id = IR.rated_id 
                    WHERE IR.movie_id = " + movieId;

                DataTable ratedTable = dataAccess.ExecuteQueryTable(ratedQuery);

                if (ratedTable.Rows.Count > 0)
                {
                    Rated_Content.Text = ratedTable.Rows[0]["rated_description"].ToString();
                }
                else
                {
                    Rated_Content.Text = "Rated information not found!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when fetching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateScrollBar()
        {
            Control lastControl = null;
            int maxBottom = 0;

            foreach (Control control in panel_Body.Controls)
            {
                int controlBottom = control.Location.Y + control.Height;
                if (controlBottom > maxBottom)
                {
                    maxBottom = controlBottom;
                    lastControl = control;
                }
            }

            int totalHeight = maxBottom + 10;

            if (totalHeight > panel_Body.ClientSize.Height)
            {
                panel_Body.AutoScrollMinSize = new Size(panel_Body.ClientSize.Width - 18, totalHeight);
            }
            else
            {
                panel_Body.AutoScrollMinSize = new Size(0, 0);
            }
        }

        private void Booking_Button_MouseEnter(object sender, EventArgs e)
        {
            Booking_Button.BackColor = Color.FromArgb(116, 198, 157);
            Booking_Button.ForeColor = Color.White;
        }

        private void Booking_Button_MouseLeave(object sender, EventArgs e)
        {
            Booking_Button.BackColor = Color.FromArgb(148, 213, 180);
            Booking_Button.ForeColor = Color.SeaGreen;
        }

        private void Booking_Button_Click(object sender, EventArgs e)
        {
            Movie_Schedule scheduleForm = new Movie_Schedule(movieId: movieId);
            scheduleForm.Show();
            Form currentForm = this.FindForm();
            if (currentForm != null)
            {
                currentForm.Close();
            }
        }
    }
}