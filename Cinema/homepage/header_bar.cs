using System;
using System.Windows.Forms;
using Cinema.Forms.SignUp_SignIn;
using Cinema.homepage;
using Cinema.Forms;

namespace Cinema
{
    public partial class header_bar : UserControl
    {
        public header_bar()
        {
            InitializeComponent();

            // Hiển thị tên người dùng từ UserSession
            if (UserSession.IsLoggedIn && !string.IsNullOrEmpty(UserSession.FullName))
            {
                lblProfile.Text = UserSession.FullName;
            }
            else
            {
                lblProfile.Text = "Guest";
            }
        }

        private void lblProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (UserSession.IsLoggedIn)
            {
                //ProfileForm profileForm = new ProfileForm(UserSession.FullName, UserSession.Email, UserSession.Phone, UserSession.Dob, UserSession.Spending, UserSession.RankName, UserSession.Discount);
                ProfileForm profileForm = new ProfileForm();
                profileForm.Show();

                Form currentForm = this.FindForm();
                if (currentForm != null)
                {
                    currentForm.Close();
                }
            }
            else
            {
                MessageBox.Show("Please log in to view your profile.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormRegistration loginForm = new FormRegistration();
                loginForm.Show();
                Form currentForm = this.FindForm();
                if (currentForm != null)
                {
                    currentForm.Close();
                }
            }
        }

        private void lblSchedule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form currentForm = this.FindForm();

            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("Please log in to view the schedule.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormRegistration loginForm = new FormRegistration();
                loginForm.Show();
                if (currentForm != null)
                {
                    currentForm.Close();
                }
                return;
            }

            Movie_Schedule movieScheduleForm = new Movie_Schedule();
            movieScheduleForm.Show();

            if (currentForm != null)
            {
                currentForm.Close();
            }
        }

        private void lblSignOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to log out of your account?", "Yes",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Xóa thông tin người dùng khi đăng xuất
                UserSession.ClearUser();

                this.Hide();

                FormRegistration formReg = new FormRegistration();
                formReg.Show();

                Form currentForm = this.FindForm();
                if (currentForm != null)
                {
                    currentForm.Close();
                }
            }
        }

        private void lblName_Click(object sender, EventArgs e)
        {
            HomepageForm homepageForm = new HomepageForm();
            homepageForm.Show();

            Form currentForm = this.FindForm();
            if (currentForm != null)
            {
                currentForm.Close();
            }
        }
    }
}