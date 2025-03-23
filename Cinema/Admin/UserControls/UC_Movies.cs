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
            string query = "SELECT movie_name, poster FROM movie";
            DataTable dt = dataAccess.ExecuteQueryTable(query);

            flowLayoutPanelMovies.Controls.Clear(); // Xóa dữ liệu cũ

            foreach (DataRow row in dt.Rows)
            {
                Panel moviePanel = new Panel()
                {
                    Width = 180,
                    Height = 340, // Tăng chiều cao để có đủ khoảng trống
                    Margin = new Padding(12, 35, 12, 35), // Tăng khoảng cách giữa các hàng
                    BackColor = Color.White
                };

                // Bo tròn nhẹ (góc 6px)
                int radius = 6;
                GraphicsPath path = new GraphicsPath();
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(moviePanel.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(moviePanel.Width - radius, moviePanel.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, moviePanel.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();
                moviePanel.Region = new Region(path);

                PictureBox picBox = new PictureBox()
                {
                    Width = 160,
                    Height = 220,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = GetImageFromDatabase(row["poster"]),
                    Location = new Point(10, 10),
                    BackColor = Color.Black
                };

                // Bo tròn nhẹ hình ảnh
                int imgRadius = 20;
                GraphicsPath imgPath = new GraphicsPath();
                imgPath.AddArc(0, 0, imgRadius, imgRadius, 180, 90);
                imgPath.AddArc(picBox.Width - imgRadius, 0, imgRadius, imgRadius, 270, 90);
                imgPath.AddArc(picBox.Width - imgRadius, picBox.Height - imgRadius, imgRadius, imgRadius, 0, 90);
                imgPath.AddArc(0, picBox.Height - imgRadius, imgRadius, imgRadius, 90, 90);
                imgPath.CloseFigure();
                picBox.Region = new Region(imgPath);

                Label lblTitle = new Label()
                {
                    Text = row["movie_name"].ToString(),
                    Width = 160,
                    Height = 70, // Tăng chiều cao để chứa nhiều dòng hơn
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 9, FontStyle.Bold), // Giữ nguyên font nhưng tăng cỡ chữ
                    Location = new Point(10, 230),
                    BackColor = Color.Transparent,
                    ForeColor = Color.Black
                };

                lblTitle.MaximumSize = new Size(160, 70);
                lblTitle.AutoEllipsis = false;
                lblTitle.Padding = new Padding(2);
                lblTitle.UseCompatibleTextRendering = true;

                // Tăng khoảng cách giữa tên phim và nút bằng Panel chứa nút
                Panel buttonPanel = new Panel()
                {
                    Width = 160,
                    Height = 40,
                    Location = new Point(10, 300), // Đẩy nút xuống thấp hơn
                    BackColor = Color.Transparent
                };

                Button btnEdit = new Button()
                {
                    Text = "Edit",
                    Width = 75,
                    Height = 30,
                    Location = new Point(0, 5),
                    BackColor = Color.LightBlue,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Arial", 8, FontStyle.Bold) // Giữ font nhưng tăng size chữ
                };

                btnEdit.FlatAppearance.BorderSize = 0;
                btnEdit.FlatAppearance.MouseDownBackColor = Color.LightBlue;
                btnEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(210, 237, 241); // Màu nhạt hơn khi hover
                btnEdit.FlatAppearance.BorderColor = Color.LightBlue;

                GraphicsPath btnPath = new GraphicsPath();
                int btnRadius = 10;

                btnPath.AddArc(0, 0, btnRadius, btnRadius, 180, 90);
                btnPath.AddArc(btnEdit.Width - btnRadius, 0, btnRadius, btnRadius, 270, 90);
                btnPath.AddArc(btnEdit.Width - btnRadius, btnEdit.Height - btnRadius, btnRadius, btnRadius, 0, 90);
                btnPath.AddArc(0, btnEdit.Height - btnRadius, btnRadius, btnRadius, 90, 90);
                btnPath.CloseFigure();

                btnEdit.Region = new Region(btnPath);
                btnEdit.MouseEnter += (s, e) => btnEdit.BackColor = Color.FromArgb(180, 220, 255); // Màu nhạt hơn LightBlue
                btnEdit.MouseLeave += (s, e) => btnEdit.BackColor = Color.LightBlue; // Màu ban đầu


                btnEdit.Click += (sender, e) => EditMovie(row["movie_name"].ToString());

                Button btnDelete = new Button()
                {
                    Text = "Delete",
                    Width = 75,
                    Height = 30,
                    Location = new Point(85, 5), // Đẩy nút xuống thấp hơn
                    BackColor = Color.LightCoral,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Arial", 8, FontStyle.Bold)
                };

                btnDelete.FlatAppearance.BorderSize = 0;
                btnDelete.FlatAppearance.MouseDownBackColor = Color.LightCoral;
                btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 180, 180); // Màu nhạt hơn khi hover

                btnDelete.FlatAppearance.BorderColor = Color.LightCoral;

                // Bo tròn nút Delete
                GraphicsPath btnPathDelete = new GraphicsPath();
                int btnRadiusDelete = 10;

                btnPathDelete.AddArc(0, 0, btnRadiusDelete, btnRadiusDelete, 180, 90);
                btnPathDelete.AddArc(btnDelete.Width - btnRadiusDelete, 0, btnRadiusDelete, btnRadiusDelete, 270, 90);
                btnPathDelete.AddArc(btnDelete.Width - btnRadiusDelete, btnDelete.Height - btnRadiusDelete, btnRadiusDelete, btnRadiusDelete, 0, 90);
                btnPathDelete.AddArc(0, btnDelete.Height - btnRadiusDelete, btnRadiusDelete, btnRadiusDelete, 90, 90);
                btnPathDelete.CloseFigure();

                btnDelete.Region = new Region(btnPathDelete);

                btnDelete.Click += (sender, e) => DeleteMovie(row["movie_name"].ToString());

                buttonPanel.Controls.Add(btnEdit);
                buttonPanel.Controls.Add(btnDelete);

                moviePanel.Controls.Add(picBox);
                moviePanel.Controls.Add(lblTitle);
                moviePanel.Controls.Add(buttonPanel);

                flowLayoutPanelMovies.Controls.Add(moviePanel);
            }
        }



        private void EditMovie(string movieName)
        {
            // Lấy thông tin phim từ database
            string query = $"SELECT * FROM movie WHERE movie_name = N'{movieName}'";
            DataTable dt = dataAccess.ExecuteQueryTable(query);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                // Khởi tạo form chỉnh sửa và truyền dữ liệu vào
                Movies_Edit editForm = new Movies_Edit();
                editForm.SetMovieData(
                    row["movie_name"].ToString(),
                    row["movie_description"].ToString(),
                    row["director"].ToString(),
                    row["genre"].ToString(),
                    row["movie_cast"].ToString(),
                    Convert.ToDateTime(row["release_date"]),
                    row["running_time"].ToString(),
                    row["poster"].ToString()
                );

                // Hiển thị form chỉnh sửa dưới dạng Dialog
                editForm.StartPosition = FormStartPosition.Manual;
                editForm.Location = new Point(650, 130);
                editForm.FormClosed += (s, args) => LoadMovies(); // Reload danh sách sau khi đóng form
                editForm.ShowDialog();
            }
        }

        // Hàm xử lý sự kiện khi nhấn Delete
        private void DeleteMovie(string movieName)
        {
            // Show confirmation dialog
            DialogResult result = MessageBox.Show($"Are you sure you want to delete the movie: {movieName}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Execute DELETE query
                    string query = $"DELETE FROM movie WHERE movie_name = N'{movieName}'";
                    int rowsAffected = dataAccess.ExecuteDMLQuery(query);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Movie deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reload the movie list
                        LoadMovies();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete movie!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    return Image.FromFile(fullPath);
                else
                {
                    Console.WriteLine("Không tìm thấy ảnh: " + fullPath);
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
    }
}
