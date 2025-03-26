using System;
using System.Windows.Forms;
using Cinema.Forms.SignUp_SignIn;
using Cinema.homepage;

namespace Cinema
{
    public partial class header_bar : UserControl
    {
        private string _fullName;
        private string _email;
        private string _phone;
        private DateTime _dob;
        private string _spending;
        private string _rankName;
        private decimal _discount;
        public header_bar(string fullName = null, string email = null, string phone = null, DateTime? dob = null, string spending = null, string rankName = null, decimal discount = 0)
        {
            InitializeComponent();
            _fullName = fullName;
            _email = email;
            _phone = phone;
            _dob = dob ?? DateTime.Now; // Nếu dob là null, gán giá trị mặc định
            _spending = spending;
            _rankName = rankName;
            _discount = discount;

            //try
            //{
            //    dataAccess = new DataAccess();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Failed to connect to database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Close();
            //    return;
            //}

            if (!string.IsNullOrEmpty(this._fullName))
            {
                lblProfile.Text = this._fullName;
            }
            else
            {
                lblProfile.Text = "Guest";
            }
        }


        private void lblProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_fullName))
            {
                // Mở ProfileForm và truyền thông tin người dùng
                ProfileForm profileForm = new ProfileForm(_fullName, _email, _phone, _dob, _spending, _rankName, _discount);
                profileForm.Show();

                // Đóng form hiện tại (HomepageForm hoặc moviedetailTemp)
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

                // Đóng form hiện tại
                Form currentForm = this.FindForm();
                if (currentForm != null)
                {
                    currentForm.Close();
                }
            }
        }

        private void lblSignOut_Click(object sender, EventArgs e)
        {
            // Hiển thị thông báo đăng xuất
            MessageBox.Show("You have been signed out.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Mở form đăng nhập/đăng ký
            FormRegistration formReg = new FormRegistration();
            formReg.Show();

            // Đóng form hiện tại
            Form currentForm = this.FindForm();
            if (currentForm != null)
            {
                currentForm.Close();
            }
        }

    }
}
