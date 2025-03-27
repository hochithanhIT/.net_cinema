using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cinema.Forms.profile;
using Cinema.Forms.SignUp_SignIn;
using Cinema.homepage;

namespace Cinema
{
    public partial class ProfileForm : Form
    {
        public ProfileForm()
        {
            InitializeComponent();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            // Load UCProfileDetails với thông tin từ UserSession
            if (UserSession.IsLoggedIn)
            {
                this.AddUserControl(new UCProfileDetails(this));
            }
            else
            {
                MessageBox.Show("User not logged in. Please log in to view your profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // Method to add a UserControl to the panel
        public void AddUserControl(System.Windows.Forms.UserControl uc)
        {
            this.panelUC.Controls.Clear();
            this.panelUC.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            // Load UCProfileDetails với thông tin từ UserSession
            if (UserSession.IsLoggedIn)
            {
                //this.AddUserControl(new UCProfileDetails(
                //    this,
                //    UserSession.FullName,
                //    UserSession.Email,
                //    UserSession.Phone,
                //    UserSession.Dob ?? DateTime.Now,
                //    UserSession.Spending,
                //    UserSession.RankName,
                //    UserSession.Discount
                //));
                this.AddUserControl(new UCProfileDetails(this));
            }
        }


            private void btnTransactionHistory_Click(object sender, EventArgs e)
            {
            // Load UCTicketHistory
            // this.AddUserControl(new UCTicketHistory(this, Email, Phone));

// Load UCTicketHistory với thông tin từ UserSession
            if (UserSession.IsLoggedIn)
            {
                //this.AddUserControl(new UCTicketHistory(this, UserSession.Email, UserSession.Phone));
                this.AddUserControl(new UCTicketHistory(this));
            }
        }

        private void Logout()
            {
                DialogResult result = MessageBox.Show("Would you like to log out of your account?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Xóa thông tin người dùng trong UserSession
                UserSession.ClearUser();

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

        private void btnHome_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"UserSession before opening Homepage: IsLoggedIn={UserSession.IsLoggedIn}, MemberId={UserSession.MemberId}, Email={UserSession.Email}");
                
            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("Please login to continue.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormRegistration loginForm = new FormRegistration();
                loginForm.Show();
                this.Close();
                return;
            }

            this.Hide();

            // Mở HomepageForm mà không cần truyền tham số
            HomepageForm homepage = new HomepageForm();
            homepage.Show();

            this.Close();
        }
    }
}