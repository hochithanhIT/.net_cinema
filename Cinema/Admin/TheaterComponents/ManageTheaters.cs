using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.Admin.TheaterComponents
{
    public partial class ManageTheaters : Form
    {
        private DataAccess dataAccess = new DataAccess();
        public ManageTheaters()
        {
            
            InitializeComponent();
        }

        private void ManageTheaters_Load(object sender, EventArgs e)
        {
            LoadTheaters();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeleteTheaBut.Enabled = listBox1.SelectedIndex != -1;
        }

        private void LoadTheaters()
        {
            try
            {
                // Truy vấn danh sách rạp từ bảng `theater`
                string query = "SELECT id, theater_name FROM theater";
                DataTable theaters = dataAccess.ExecuteQueryTable(query);

                // Xóa danh sách cũ
                listBox1.Items.Clear();

                // Thêm dữ liệu vào listBox1
                foreach (DataRow row in theaters.Rows)
                {
                    listBox1.Items.Add(new TheaterItem
                    {
                        TheaterID = Convert.ToInt32(row["id"]),
                        TheaterName = row["theater_name"].ToString()
                    });
                }

                // Hiển thị tên rạp thay vì object
                listBox1.DisplayMember = "TheaterName";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách rạp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class TheaterItem
        {
            public int TheaterID { get; set; }
            public string TheaterName { get; set; }

            public override string ToString()
            {
                return TheaterName; // Hiển thị tên rạp trong listBox
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }
    }
}
