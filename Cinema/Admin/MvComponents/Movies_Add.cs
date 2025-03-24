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
            DialogResult result = MessageBox.Show("Are you sure you want to add this movie?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string movieName = MvName.Text.Trim();
                string movieDescription = MvDes.Text.Trim();
                string director = MvDir.Text.Trim();
                string genre = MvGen.Text.Trim();
                string movieCast = MvCas.Text.Trim();
                DateTime releaseDate = MvDate.Value;
                int runningTime;
                bool isNumeric = int.TryParse(MvRtime.Text.Trim(), out runningTime);
                string moviePoster = MvPos.Text.Trim(); // Lấy đường dẫn ảnh

                if (string.IsNullOrEmpty(movieName) || string.IsNullOrEmpty(movieDescription) || string.IsNullOrEmpty(director) ||
                    string.IsNullOrEmpty(genre) || string.IsNullOrEmpty(movieCast) || !isNumeric || string.IsNullOrEmpty(moviePoster))
                {
                    MessageBox.Show("Please fill in all required fields, including movie poster!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = $"INSERT INTO movie (movie_name, director, movie_cast, genre, release_date, running_time, movie_description, poster) " +
                               $"VALUES (N'{movieName}', N'{director}', N'{movieCast}', N'{genre}', '{releaseDate:yyyy-MM-dd}', {runningTime}, N'{movieDescription}', N'{moviePoster}')";

                try
                {
                    int rowsAffected = dataAccess.ExecuteDMLQuery(query);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Movie added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
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




        private void MvPos_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a movie poster";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string sourcePath = openFileDialog.FileName;

                    // **Sửa đường dẫn assetsFolderPath để về đúng thư mục gốc**
                    string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                    string assetsFolderPath = Path.Combine(projectDirectory, "assets", "poster");
                    Directory.CreateDirectory(assetsFolderPath); // Tạo thư mục nếu chưa có

                    string fileName = Path.GetFileName(sourcePath);
                    string destinationPath = Path.Combine(assetsFolderPath, fileName);

                    try
                    {
                        // Copy ảnh vào thư mục chính xác
                        if (!File.Exists(destinationPath))
                        {
                            File.Copy(sourcePath, destinationPath, true);
                        }

                        // Lưu đường dẫn cần insert vào database
                        string dbPath = $"assets/poster/{fileName}";
                        MvPos.Text = dbPath;

                        // Kiểm tra file đã được copy chưa
                        if (File.Exists(destinationPath))
                        {
                            guna2PictureBox1.Image = Image.FromFile(destinationPath);
                            guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                            MessageBox.Show($"Image copied successfully to: {destinationPath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                           
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error copying image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void Movies_Add_Load(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MvPos_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
