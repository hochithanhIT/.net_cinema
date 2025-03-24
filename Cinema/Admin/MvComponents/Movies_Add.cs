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

namespace Cinema.Admin.Components
{
    public partial class Movies_Add : Form
    {   
        private DataAccess dataAccess = new DataAccess();

        public Movies_Add()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Show confirmation dialog
            DialogResult result = MessageBox.Show("Are you sure you want to add this movie?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Retrieve data from textboxes
                string movieName = MvName.Text.Trim();
                string movieDescription = MvDes.Text.Trim();
                string director = MvDir.Text.Trim();
                string genre = MvGen.Text.Trim();
                string movieCast = MvCas.Text.Trim();
                DateTime releaseDate = MvDate.Value;
                int runningTime;
                bool isNumeric = int.TryParse(MvRtime.Text.Trim(), out runningTime);
                string poster = MvPos.Text.Trim();

                // Validate input data
                if (string.IsNullOrEmpty(movieName) || string.IsNullOrEmpty(movieDescription) || string.IsNullOrEmpty(director) ||
                    string.IsNullOrEmpty(genre) || string.IsNullOrEmpty(movieCast) || !isNumeric || string.IsNullOrEmpty(poster))
                {
                    MessageBox.Show("Please fill in all required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create INSERT query
                string query = $"INSERT INTO movie (movie_name, director, movie_cast, genre, release_date, running_time, movie_description, poster) " +
                               $"VALUES (N'{movieName}', N'{director}', N'{movieCast}', N'{genre}', '{releaseDate:yyyy-MM-dd}', {runningTime}, N'{movieDescription}', N'{poster}')";

                try
                {
                    // Execute INSERT using DataAccess
                    int rowsAffected = dataAccess.ExecuteDMLQuery(query);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Movie added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Close form after successful addition
                    }
                    else
                    {
                        MessageBox.Show("Failed to add movie!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
