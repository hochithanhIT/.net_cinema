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

namespace Cinema
{
    public partial class MovieControl : UserControl
    {
        private Movie _movie;
        public MovieControl(Movie movie)
        {
            InitializeComponent();
            _movie = movie;
            SetupUI();
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
    }
}
