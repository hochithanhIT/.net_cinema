using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Cinema.Admin.Components;


namespace Cinema.Admin.UserControls
{
    public partial class UC_Movies : UserControl
    {
        private DataAccess dataAccess;
        private List<DataRow> allMovies = new List<DataRow>(); // Lưu toàn bộ dữ liệu phim

        public UC_Movies()
        {
            InitializeComponent();
            dataAccess = new DataAccess();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UC_Movies_Load(object sender, EventArgs e)
        {
            LoadMovies();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadMovies()
        {
            DataAccess dataAccess = new DataAccess();
            string query = "SELECT id, movie_name, poster FROM movie WHERE isDeleted = 0";

            DataTable dt = dataAccess.ExecuteQueryTable(query);

            allMovies = dt.AsEnumerable().ToList(); // Lưu danh sách phim gốc

            DisplayMovies(allMovies); // Gọi hàm hiển thị phim
        }

        private void DisplayMovies(List<DataRow> movies)
        {
            flowLayoutPanelMovies.Controls.Clear(); // Xóa danh sách cũ

            foreach (DataRow row in movies)
            {
                Panel moviePanel = new Panel()
                {
                    Width = 180,
                    Height = 340, // Giữ nguyên kích thước
                    Margin = new Padding(12, 35, 12, 35),
                    BackColor = Color.White
                };

                // Bo tròn panel
                int radius = 6;
                GraphicsPath path = new GraphicsPath();
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(moviePanel.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(moviePanel.Width - radius, moviePanel.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, moviePanel.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();
                moviePanel.Region = new Region(path);

                // Poster phim
                PictureBox picBox = new PictureBox()
                {
                    Width = 160,
                    Height = 220,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = GetImageFromDatabase(row["poster"]),
                    Location = new Point(10, 10),
                    BackColor = Color.Black
                };

                // Bo tròn ảnh
                int imgRadius = 20;
                GraphicsPath imgPath = new GraphicsPath();
                imgPath.AddArc(0, 0, imgRadius, imgRadius, 180, 90);
                imgPath.AddArc(picBox.Width - imgRadius, 0, imgRadius, imgRadius, 270, 90);
                imgPath.AddArc(picBox.Width - imgRadius, picBox.Height - imgRadius, imgRadius, imgRadius, 0, 90);
                imgPath.AddArc(0, picBox.Height - imgRadius, imgRadius, imgRadius, 90, 90);
                imgPath.CloseFigure();
                picBox.Region = new Region(imgPath);

                // Tên phim
                Label lblTitle = new Label()
                {
                    Text = row["movie_name"].ToString(),
                    Width = 160,
                    Height = 70, // Tăng chiều cao để chứa nhiều dòng hơn
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 9, FontStyle.Bold),
                    Location = new Point(10, 230),
                    ForeColor = Color.Black
                };

                // Panel chứa nút
                Panel buttonPanel = new Panel()
                {
                    Width = 160,
                    Height = 40,
                    Location = new Point(10, 300),
                    BackColor = Color.Transparent
                };

                // Nút Edit
                Button btnEdit = new Button()
                {
                    Text = "Edit",
                    Width = 75,
                    Height = 30,
                    Location = new Point(0, 5),
                    BackColor = Color.LightBlue,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Arial", 8, FontStyle.Bold)
                };

                btnEdit.FlatAppearance.BorderSize = 0;
                btnEdit.FlatAppearance.MouseDownBackColor = Color.LightBlue;
                btnEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(210, 237, 241);

                // Bo tròn nút Edit
                int btnRadius = 10;
                GraphicsPath btnPath = new GraphicsPath();
                btnPath.AddArc(0, 0, btnRadius, btnRadius, 180, 90);
                btnPath.AddArc(btnEdit.Width - btnRadius, 0, btnRadius, btnRadius, 270, 90);
                btnPath.AddArc(btnEdit.Width - btnRadius, btnEdit.Height - btnRadius, btnRadius, btnRadius, 0, 90);
                btnPath.AddArc(0, btnEdit.Height - btnRadius, btnRadius, btnRadius, 90, 90);
                btnPath.CloseFigure();
                btnEdit.Region = new Region(btnPath);

                btnEdit.Click += (sender, e) => EditMovie(Convert.ToInt32(row["id"]));




                // Nút Delete
                Button btnDelete = new Button()
                {
                    Text = "Delete",
                    Width = 75,
                    Height = 30,
                    Location = new Point(85, 5),
                    BackColor = Color.LightCoral,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Arial", 8, FontStyle.Bold)
                };

                btnDelete.FlatAppearance.BorderSize = 0;
                btnDelete.FlatAppearance.MouseDownBackColor = Color.LightCoral;
                btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 180, 180);

                // Bo tròn nút Delete
                GraphicsPath btnPathDelete = new GraphicsPath();
                btnPathDelete.AddArc(0, 0, btnRadius, btnRadius, 180, 90);
                btnPathDelete.AddArc(btnDelete.Width - btnRadius, 0, btnRadius, btnRadius, 270, 90);
                btnPathDelete.AddArc(btnDelete.Width - btnRadius, btnDelete.Height - btnRadius, btnRadius, btnRadius, 0, 90);
                btnPathDelete.AddArc(0, btnDelete.Height - btnRadius, btnRadius, btnRadius, 90, 90);
                btnPathDelete.CloseFigure();
                btnDelete.Region = new Region(btnPathDelete);

                btnDelete.Click += (sender, e) => DeleteMovie(Convert.ToInt32(row["id"]));

                buttonPanel.Controls.Add(btnEdit);
                buttonPanel.Controls.Add(btnDelete);

                moviePanel.Controls.Add(picBox);
                moviePanel.Controls.Add(lblTitle);
                moviePanel.Controls.Add(buttonPanel);

                flowLayoutPanelMovies.Controls.Add(moviePanel);
            }
        }

        private void EditMovie(int id)  // Sửa kiểu dữ liệu từ string → int
        {
            string query = $"SELECT id, movie_name, movie_description, director, genre, movie_cast, release_date, running_time, poster FROM movie WHERE id = {id}";
            DataTable dt = dataAccess.ExecuteQueryTable(query);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy phim với ID này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRow row = dt.Rows[0];

            // Kiểm tra xem cột 'id' có tồn tại không
            if (!dt.Columns.Contains("id"))
            {
                MessageBox.Show("Lỗi dữ liệu: Cột 'id' không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Khởi tạo form chỉnh sửa và truyền dữ liệu vào
            Movies_Edit editForm = new Movies_Edit();
            editForm.SetMovieData(
                Convert.ToInt32(row["id"]),
                row["movie_name"].ToString(),
                row["movie_description"].ToString(),
                row["director"].ToString(),
                row["genre"].ToString(),
                row["movie_cast"].ToString(),
                Convert.ToDateTime(row["release_date"]),
                row["running_time"].ToString(),
                row["poster"].ToString()
            );

            editForm.StartPosition = FormStartPosition.Manual;
            editForm.Location = new Point(650, 130);
            editForm.FormClosed += (s, args) => LoadMovies();
            editForm.ShowDialog();
        }





        // Hàm xử lý sự kiện khi nhấn Delete
        private void DeleteMovie(int movieId)
        {
            DialogResult result = MessageBox.Show($"Are you sure you want to delete this movie??",
                                                  "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = $"UPDATE movie SET isDeleted = 1 WHERE id = {movieId}";
                    int rowsAffected = dataAccess.ExecuteDMLQuery(query);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Movie has been hidden successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMovies();
                    }
                    else
                    {
                        MessageBox.Show("Failed to hide movie!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private Image GetImageFromDatabase(object imageData)
        {
            if (imageData == DBNull.Value || imageData == null)
                return null;

            if (imageData is string imagePath) // Nếu là đường dẫn ảnh
            {
                // Lấy thư mục gốc của project (đi lên từ bin\Debug về thư mục cha chứa Cinema)
                string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\Cinema\"));
                string fullPath = Path.Combine(projectRoot, imagePath);

                if (File.Exists(fullPath))
                {
                    try
                    {
                        using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            return Image.FromStream(fs);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error when uploading images: " + ex.Message);
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("No Image was found: " + fullPath);
                    return null;
                }
            }

            if (imageData is byte[] imgBytes) // Nếu là dữ liệu nhị phân
            {
                using (MemoryStream ms = new MemoryStream(imgBytes))
                {
                    return Image.FromStream(ms);
                }
            }

            return null;
        }


        private void flowLayoutPanelMovies_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Movies_Add moviesAddForm = new Movies_Add();
            moviesAddForm.StartPosition = FormStartPosition.Manual;  // Chế độ định vị thủ công
            moviesAddForm.Location = new Point(650, 130);  // Đặt vị trí hiển thị (X=500, Y=200)
                                                           // Đăng ký sự kiện khi form Movies_Add đóng
            moviesAddForm.FormClosed += (s, args) => LoadMovies();

            moviesAddForm.ShowDialog();  // Hiển thị Form dưới dạng Dialog
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SearchMovies_TextChanged(object sender, EventArgs e)
        {
            string keyword = SearchMovies.Text.Trim().ToLower(); // Lấy từ khóa tìm kiếm

            var filteredMovies = allMovies
                .Where(row => row["movie_name"].ToString().ToLower().Contains(keyword))
                .ToList();

            DisplayMovies(filteredMovies); // Hiển thị danh sách phim đã lọc
        }

    }
}
