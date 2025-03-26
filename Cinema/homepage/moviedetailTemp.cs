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
using Cinema.homepage;

namespace Cinema.homepage
{
    public partial class moviedetailTemp : Form
    {
        private DataAccess dataAccess = new DataAccess();
        private int movieId;
        private string userFullName;
        private string userEmail;
        private string userPhone;
        private DateTime userDoB;
        private string userSpending;
        private string userRankName;
        private decimal userDiscount;

        public moviedetailTemp(int movieId, string fullName, string email, string phone, DateTime dob, string spending, string rankName, decimal discount)
        {
            InitializeComponent();
            this.movieId = movieId;
            this.userFullName = fullName;
            this.userEmail = email;
            this.userPhone = phone;
            this.userDoB = dob;
            this.userSpending = spending;
            this.userRankName = rankName;
            this.userDiscount = discount;

            // Initialize header_bar and pass user information
            //header_bar headerBar = new header_bar(this.userFullName, this.userEmail, this.userPhone, this.userDoB, this.userSpending, this.userRankName, this.userDiscount);
            //this.Controls.Add(headerBar); // Add the header to the form dynamically if not already in the designer

            LoadMovieDetails();
        }

        private void LoadMovieDetails()
        {
            try
            {
                string query = "SELECT movie_name, poster, release_date, movie_description, genre FROM movie WHERE id = @movieId";
                using (SqlCommand cmd = new SqlCommand(query, dataAccess.Sqlcon))
                {
                    cmd.Parameters.AddWithValue("@movieId", movieId);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count == 1)
                        {
                            DataRow row = dt.Rows[0];
                            lblMovieName.Text = row["movie_name"].ToString();
                            lblReleaseDate.Text = $"Release Date: {Convert.ToDateTime(row["release_date"]).ToString("dd/MM/yyyy")}";
                            lblDescription.Text = $"Description: {row["movie_description"].ToString()}"; // Sửa "description" thành "movie_description"
                            lblGenre.Text = $"Genre: {row["genre"].ToString()}";
                            //lblDuration.Text = $"Duration: {row["duration"].ToString()} minutes";

                            // Load poster if available
                            string posterPath = row["poster"]?.ToString();
                            if (!string.IsNullOrEmpty(posterPath) && System.IO.File.Exists(posterPath))
                            {
                                pbPoster.Image = Image.FromFile(posterPath);
                                pbPoster.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                            else
                            {
                                pbPoster.Image = null; // Hoặc đặt một hình ảnh mặc định
                            }
                        }
                        else
                        {
                            MessageBox.Show("Movie not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading movie details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        //private void btnBack_Click(object sender, EventArgs e)
        //{
        //    // Quay lại HomepageForm
        //    HomepageForm homepageForm = new HomepageForm(userFullName, userEmail, userPhone, userDoB, userSpending, userRankName, userDiscount);
        //    homepageForm.Show();
        //    this.Close();
        //}

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            // Quay lại HomepageForm
            HomepageForm homepageForm = new HomepageForm(userFullName, userEmail, userPhone, userDoB, userSpending, userRankName, userDiscount);
            homepageForm.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Quay lại HomepageForm
            HomepageForm homepageForm = new HomepageForm(userFullName, userEmail, userPhone, userDoB, userSpending, userRankName, userDiscount);
            homepageForm.Show();
            this.Close();
        }
    }
}