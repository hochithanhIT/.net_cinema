﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cinema.Forms.profile;
using Cinema.Forms.SignUp_SignIn;
using Cinema.homepage;

namespace Cinema.homepage
{
    public partial class HomepageForm : Form
    {
        private DataAccess dataAccess = new DataAccess();
        private string FullName { get; set; }
        private string Email { get; set; }
        private string Phone { get; set; }
        private DateTime DoB { get; set; }
        private string Spending { get; set; }
        private string RankName { get; set; }
        private decimal Discount { get; set; }

        public HomepageForm(string fullName, string email, string phone, DateTime dob, string spending, string rankName, decimal discount)
        {
            InitializeComponent();
            this.FullName = fullName;
            this.Email = email;
            this.Phone = phone;
            this.DoB = dob;
            this.Spending = spending;
            this.RankName = rankName;
            this.Discount = discount;

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

            if (!string.IsNullOrEmpty(this.FullName))
            {
                lblProfile.Text = this.FullName;
            }
            else
            {
                lblProfile.Text = "Guest";
            }

            LoadMovies(true);
        }

        private void LoadMovies(bool showShowingMovies)
        {
            flpMovies.Controls.Clear();

            try
            {
                string query = "SELECT id, movie_name, poster, release_date, isDeleted FROM movie WHERE isDeleted = 0"; // Only select non-deleted movies
                DataTable dt = dataAccess.ExecuteQueryTable(query);

                List<Movie> movies = new List<Movie>();
                foreach (DataRow row in dt.Rows)
                {
                    // No need to check isDeleted here since we filtered in SQL query
                    movies.Add(new Movie
                    {
                        id = Convert.ToInt32(row["id"]),
                        movie_name = row["movie_name"].ToString(),
                        poster = row["poster"]?.ToString() ?? string.Empty,
                        release_date = Convert.ToDateTime(row["release_date"]),
                    });
                }

                // Filter based on showing status (now only works with non-deleted movies)
                var filteredMovies = showShowingMovies
                    ? movies.Where(m => m.IsShowing).ToList()
                    : movies.Where(m => !m.IsShowing).ToList();

                foreach (var movie in filteredMovies)
                {
                    MovieControl movieControl = new MovieControl(
                        movie,
                        this.FullName,
                        this.Email,
                        this.Phone,
                        this.DoB,
                        this.Spending,
                        this.RankName,
                        this.Discount
                    );
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

        private void lblProfile_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.FullName))
            {
                // Mở ProfileForm và truyền thông tin người dùng
                ProfileForm profileForm = new ProfileForm(this.FullName, this.Email, this.Phone, this.DoB, this.Spending, this.RankName, this.Discount);
                profileForm.Show();

                // Đóng HomepageForm hiện tại
                this.Close();
            }
            else
            {
                MessageBox.Show("Please log in to view your profile.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormRegistration loginForm = new FormRegistration();
                loginForm.Show();
                this.Close();
            }
        }
    }
}
