using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.Admin.Components
{
    public partial class Movies_Edit : Form
    {
        private DataAccess dataAccess = new DataAccess();
        public Movies_Edit()
        {
            InitializeComponent();
        }

        private void Movies_Edit_Load(object sender, EventArgs e)
        {

        }

        public void SetMovieData(string name, string description, string director, string genre, string cast, DateTime releaseDate, string runningTime, string poster)
        {
            MvName.Text = name;
            MvDes.Text = description;
            MvDir.Text = director;
            MvGen.Text = genre;
            MvCas.Text = cast;
            MvDate.Value = releaseDate;
            MvRtime.Text = runningTime;
            MvPos.Text = poster;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các input fields
            string name = MvName.Text.Trim();
            string description = MvDes.Text.Trim();
            string director = MvDir.Text.Trim();
            string genre = MvGen.Text.Trim();
            string cast = MvCas.Text.Trim();
            DateTime releaseDate = MvDate.Value;
            string runningTime = MvRtime.Text.Trim();
            string poster = MvPos.Text.Trim();

            // Kiểm tra dữ liệu có hợp lệ không
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) ||
                string.IsNullOrEmpty(director) || string.IsNullOrEmpty(genre) ||
                string.IsNullOrEmpty(cast) || string.IsNullOrEmpty(runningTime) || string.IsNullOrEmpty(poster))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo câu lệnh SQL UPDATE
            string query = $"UPDATE movie SET " +
                           $"movie_description = N'{description}', " +
                           $"director = N'{director}', " +
                           $"genre = N'{genre}', " +
                           $"movie_cast = N'{cast}', " +
                           $"release_date = '{releaseDate:yyyy-MM-dd}', " +
                           $"running_time = '{runningTime}', " +
                           $"poster = N'{poster}' " +
                           $"WHERE movie_name = N'{name}'";

            // Thực hiện cập nhật dữ liệu
            int result = dataAccess.ExecuteDMLQuery(query);


            if (result > 0)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form sau khi cập nhật thành công
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
