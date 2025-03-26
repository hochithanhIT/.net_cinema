using Cinema.Admin.MemberComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.Admin.UserControls
{
    public partial class UC_Members : UserControl
    {

        private DataAccess dataAccess = new DataAccess(); // Khởi tạo DataAccess
        public UC_Members()
        {
            InitializeComponent();
            LoadMembers();
        }

        private void LoadMembers(string searchText = "")
        {
            try
            {
                // Truy vấn danh sách thành viên từ database
                string query = "SELECT ID, FULL_NAME, PHONE FROM THEATER_MEM WHERE MEM_ROLE = 1;";
                DataTable members = dataAccess.ExecuteQueryTable(query);

                // Xóa các control cũ trong flowLayoutPanel1
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel1.AutoScroll = true;
                flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
                flowLayoutPanel1.WrapContents = false;
                flowLayoutPanel1.Padding = new Padding(10);

                // Duyệt danh sách members và tạo UI cho từng người
                foreach (DataRow row in members.Rows)
                {
                    int memberId = Convert.ToInt32(row["ID"]);
                    string fullName = row["FULL_NAME"].ToString();
                    string phone = row["PHONE"].ToString();

                    // Nếu có searchText, chỉ hiển thị members phù hợp
                    if (!string.IsNullOrEmpty(searchText) &&
                        !fullName.ToLower().Contains(searchText) &&
                        !phone.ToLower().Contains(searchText))
                    {
                        continue;
                    }

                    // Tạo panel chứa thông tin member (bo góc, giảm chiều rộng)
                    Panel panel = new Panel
                    {
                        Size = new Size((int)(flowLayoutPanel1.Width * 0.8), 70), // Giảm chiều rộng box (~80% width)
                        BackColor = Color.FromArgb(240, 240, 240), // Màu nền xám nhạt
                        Padding = new Padding(15),
                        Margin = new Padding(10, 12, 10, 12) // Tăng khoảng cách giữa các members
                    };
                    panel.Region = new Region(new System.Drawing.Drawing2D.GraphicsPath());
                    using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        int radius = 40; // Bo góc 10px
                        path.AddArc(0, 0, radius, radius, 180, 90);
                        path.AddArc(panel.Width - radius, 0, radius, radius, 270, 90);
                        path.AddArc(panel.Width - radius, panel.Height - radius, radius, radius, 0, 90);
                        path.AddArc(0, panel.Height - radius, radius, radius, 90, 90);
                        path.CloseFigure();
                        panel.Region = new Region(path);
                    }

                    // Tạo label hiển thị tên
                    Label nameLabel = new Label
                    {
                        Text = fullName,
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        AutoSize = true,
                        Location = new Point(15, 25)
                    };

                    // Tạo label hiển thị số điện thoại
                    Label phoneLabel = new Label
                    {
                        Text = phone,
                        Font = new Font("Arial", 10, FontStyle.Regular),
                        AutoSize = true,
                        Location = new Point(300, 25)
                    };

                    // Tạo nút "View Info" (bo góc, tăng khoảng cách, căn phải)
                    Button infoButton = new Button
                    {
                        Text = "View Info",
                        Size = new Size(140, 40), // Tăng kích thước
                        Location = new Point(panel.Width - 160, 15), // Dịch xa hơn về bên phải
                        BackColor = Color.Black,
                        ForeColor = Color.White,
                        Font = new Font("Arial", 8, FontStyle.Bold),
                        FlatStyle = FlatStyle.Flat
                    };
                    infoButton.FlatAppearance.BorderSize = 0;
                    infoButton.Region = new Region(new System.Drawing.Drawing2D.GraphicsPath());
                    using (var btnPath = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        int btnRadius = 30;
                        btnPath.AddArc(0, 0, btnRadius, btnRadius, 180, 90);
                        btnPath.AddArc(infoButton.Width - btnRadius, 0, btnRadius, btnRadius, 270, 90);
                        btnPath.AddArc(infoButton.Width - btnRadius, infoButton.Height - btnRadius, btnRadius, btnRadius, 0, 90);
                        btnPath.AddArc(0, infoButton.Height - btnRadius, btnRadius, btnRadius, 90, 90);
                        btnPath.CloseFigure();
                        infoButton.Region = new Region(btnPath);
                    }

                    infoButton.Click += (sender, e) => ShowMemberDetails(memberId);


                    // Thêm các control vào panel
                    panel.Controls.Add(nameLabel);
                    panel.Controls.Add(phoneLabel);
                    panel.Controls.Add(infoButton);

                    // Thêm panel vào FlowLayoutPanel
                    flowLayoutPanel1.Controls.Add(panel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading members: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void ShowMemberDetails(int memberId)
        {
            try
            {
                // Truy vấn thông tin thành viên theo ID
                string query = $"SELECT FULL_NAME, EMAIL, PHONE, BIRTHDATE, SPENDING FROM THEATER_MEM WHERE ID = {memberId};";
                DataTable memberData = dataAccess.ExecuteQueryTable(query);

                if (memberData.Rows.Count > 0)
                {
                    DataRow row = memberData.Rows[0];

                    string fullName = row["FULL_NAME"].ToString();
                    string email = row["EMAIL"].ToString();
                    string phone = row["PHONE"].ToString();
                    DateTime bdate = Convert.ToDateTime(row["BIRTHDATE"]);
                    string birthDateFormatted = bdate.ToString("dd/MM/yyyy"); // Hiển thị ngày tháng năm
                    decimal totalSpend = Convert.ToDecimal(row["SPENDING"]);

                    // Mở form MemInfo và truyền dữ liệu
                    MemInfo memInfoForm = new MemInfo();
                    memInfoForm.NameTextBox.Text = fullName;
                    memInfoForm.EmailTextBox.Text = email;
                    memInfoForm.PhoneTextBox.Text = phone;
                    memInfoForm.BDTextBox.Text = birthDateFormatted;
                    memInfoForm.SpendTextBox.Text = totalSpend.ToString("N0"); // Hiển thị số có dấu phẩy

                    memInfoForm.ShowDialog(); // Hiển thị form
                }
                else
                {
                    MessageBox.Show("Member not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading member details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SearchMem_TextChanged(object sender, EventArgs e)
        {
            string searchText = SearchMem.Text.Trim().ToLower();
            LoadMembers(searchText);
        }

    }
}
