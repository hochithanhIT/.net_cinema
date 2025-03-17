//using System;
//using System.Drawing;
//using System.Windows.Forms;
//using Cinema.forms.profile;

//namespace Cinema
//{
//    public partial class ProfileForm : Form
//    {
//        public ProfileForm()
//        {
//            InitializeComponent();
//        }

//        public void AddUserControl(System.Windows.Forms.UserControl uc)
//        {
//            this.panelUC.Controls.Clear();
//            this.panelUC.Controls.Add(uc);
//            uc.Dock = DockStyle.Fill;
//            uc.BringToFront();
//        }
//        private void ProfileForm_Load(object sender, EventArgs e)
//        {
//            this.AddUserControl(new UCProfileDetails(this));
//        }

//        private void BtnUpdate_Click(object sender, EventArgs e)
//        {
//            MessageBox.Show("Chức năng cập nhật thông tin sẽ được triển khai sau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//        }

//        private void btnProfile_Click(object sender, EventArgs e)
//        {
//            this.AddUserControl(new UCProfileDetails(this));
//        }

//        private void btnMemberRank_Click(object sender, EventArgs e)
//        {
//            this.AddUserControl(new UCMemberRank(this));
//        }

//        private void btnTransactionHistory_Click(object sender, EventArgs e)
//        {
//            this.AddUserControl(new UCTicketHistory(this));
//        }

//        private void Logout()
//        {
//            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận",
//                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

//            if (result == DialogResult.Yes)
//            {
//                // Ẩn form hiện tại
//                this.Hide();

//                // Mở form đăng ký (đăng nhập)
//                FormRegistration formReg = new FormRegistration();
//                formReg.Show();

//                // Đóng form hiện tại sau khi mở form đăng ký
//                this.Close();
//            }
//        }

//        private void btnLogOut_Click(object sender, EventArgs e)
//        {
//            Logout();
//        }

//    }
//}

using System;
using System.Drawing;
using System.Windows.Forms;
using Cinema.forms.profile;

namespace Cinema
{
    public partial class ProfileForm : Form
    {
        // Properties to store user data
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string DoB { get; set; }
        public string Spending { get; set; }

        // Constructor to accept user data
        public ProfileForm(string fullName, string email, string phone, string dob, string spending)
        {
            InitializeComponent();
            this.FullName = fullName;
            this.Email = email;
            this.Phone = phone;
            this.DoB = dob;
            this.Spending = spending;

            // Load UCProfileDetails with user data
            this.AddUserControl(new UCProfileDetails(this, fullName, email, phone, dob, spending));
        }

        // Default constructor (optional, for backward compatibility)
        public ProfileForm()
        {
            InitializeComponent();
        }

        // Method to add a UserControl to the panel
        public void AddUserControl(System.Windows.Forms.UserControl uc)
        {
            this.panelUC.Controls.Clear();
            this.panelUC.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            // Load UCProfileDetails with user data when the form loads
            if (!string.IsNullOrEmpty(FullName) && !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Phone))
            {
                this.AddUserControl(new UCProfileDetails(this, FullName, Email, Phone));
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng cập nhật thông tin sẽ được triển khai sau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            // Load UCProfileDetails with user data
            this.AddUserControl(new UCProfileDetails(this, FullName, Email, Phone));
        }

        private void btnMemberRank_Click(object sender, EventArgs e)
        {
            // Load UCMemberRank
            this.AddUserControl(new UCMemberRank(this));
        }

        private void btnTransactionHistory_Click(object sender, EventArgs e)
        {
            // Load UCTicketHistory
            this.AddUserControl(new UCTicketHistory(this));
        }

        private void Logout()
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Ẩn form hiện tại
                this.Hide();

                // Mở form đăng ký (đăng nhập)
                FormRegistration formReg = new FormRegistration();
                formReg.Show();

                // Đóng form hiện tại sau khi mở form đăng ký
                this.Close();
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Logout();
        }
    }
}