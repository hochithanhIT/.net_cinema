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

namespace Cinema.Admin.Components
{
    public partial class Movies_Edit : Form
    {
        private DataAccess dataAccess = new DataAccess();
        public int MovieId { get; private set; }

        public Movies_Edit()
        {
            InitializeComponent();
        }

        private void Movies_Edit_Load(object sender, EventArgs e)
        {

        }

        public void SetMovieData(int id, string name, string description, string director,
                         string genre, string cast, DateTime releaseDate, string runningTime, string poster)
        {
            // Lưu ID phim để sử dụng sau này
            this.MovieId = id;

            MvName.Text = name;
            MvDes.Text = description;
            MvDir.Text = director;
            MvGen.Text = genre;
            MvCas.Text = cast;
            MvDate.Value = releaseDate;
            MvRtime.Text = runningTime;
            MvPos.Text = poster;

            // Hiển thị ảnh poster
            if (!string.IsNullOrEmpty(poster))
            {
                string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string fullPosterPath = Path.Combine(projectDirectory, poster.Replace("/", "\\"));

                if (File.Exists(fullPosterPath))
                {
                    guna2PictureBox1.Image = Image.FromFile(fullPosterPath);
                    guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    guna2PictureBox1.Image = null; // Nếu không có ảnh, để trống
                }
            }
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string name = MvName.Text.Trim();
            string description = MvDes.Text.Trim();
            string director = MvDir.Text.Trim();
            string genre = MvGen.Text.Trim();
            string cast = MvCas.Text.Trim();
            DateTime releaseDate = MvDate.Value;
            string runningTime = MvRtime.Text.Trim();
            string poster = MvPos.Text.Trim(); // Current image path

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) ||
                string.IsNullOrEmpty(director) || string.IsNullOrEmpty(genre) ||
                string.IsNullOrEmpty(cast) || string.IsNullOrEmpty(runningTime))
            {
                MessageBox.Show("Please fill in all the required fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 🔹 Get movie ID based on the current name
               

                // 🔹 Handle image update if changed
                string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string assetsFolderPath = Path.Combine(projectDirectory, "assets", "poster");
                Directory.CreateDirectory(assetsFolderPath); // Create directory if not exists

                if (!string.IsNullOrEmpty(poster) && File.Exists(poster))
                {
                    string fileName = $"{this.MovieId}_{Path.GetFileName(poster)}";

                    string destinationPath = Path.Combine(assetsFolderPath, fileName);

                    // 🔹 Release the old image before overwriting
                    if (guna2PictureBox1.Image != null)
                    {
                        guna2PictureBox1.Image.Dispose();
                        guna2PictureBox1.Image = null;
                    }

                    File.Copy(poster, destinationPath, true); // Overwrite the file

                    // 🔹 Update the new path in the database
                    poster = $"assets/poster/{fileName}";
                }

                // 🔹 SQL UPDATE statement (now includes movie_name)
                string query = $"UPDATE movie SET " +
                 $"movie_name = N'{name}', " +
                 $"movie_description = N'{description}', " +
                 $"director = N'{director}', " +
                 $"genre = N'{genre}', " +
                 $"movie_cast = N'{cast}', " +
                 $"release_date = '{releaseDate:yyyy-MM-dd}', " +
                 $"running_time = '{runningTime}', " +
                 $"poster = N'{poster}' " +
                 $"WHERE id = {this.MovieId}";  // Sử dụng MovieId đã lưu


                int result = dataAccess.ExecuteDMLQuery(query);

                if (result > 0)
                {
                    MessageBox.Show("Movie updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Close the form after a successful update
                }
                else
                {
                    MessageBox.Show("Movie update failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving the image or updating data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                    // Định nghĩa thư mục assets
                    string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                    string assetsFolderPath = Path.Combine(projectDirectory, "assets", "poster");
                    Directory.CreateDirectory(assetsFolderPath); // Tạo thư mục nếu chưa có

                    string fileName = Path.GetFileName(sourcePath);
                    string destinationPath = Path.Combine(assetsFolderPath, fileName);

                    try
                    {
                        // **Giải phóng ảnh cũ trong PictureBox**
                        if (guna2PictureBox1.Image != null)
                        {
                            guna2PictureBox1.Image.Dispose();
                            guna2PictureBox1.Image = null;
                        }

                        // **Sao chép ảnh mới vào thư mục poster**
                        byte[] imageBytes = File.ReadAllBytes(sourcePath); // Đọc file vào bộ nhớ
                        File.WriteAllBytes(destinationPath, imageBytes); // Ghi file mới

                        // **Load ảnh vào PictureBox từ MemoryStream**
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            guna2PictureBox1.Image = Image.FromStream(ms);
                        }
                        guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                        // **Lưu đường dẫn vào TextBox**
                        MvPos.Text = $"assets/poster/{fileName}";

                        MessageBox.Show($"Image copied successfully to: {destinationPath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error copying image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
