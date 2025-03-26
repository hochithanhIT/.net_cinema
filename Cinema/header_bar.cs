//using System;
//using System.Windows.Forms;
//using Cinema.Forms.SignUp_SignIn;
//using Cinema.homepage;
//using Cinema.Forms;

//namespace Cinema
//{
//    public partial class header_bar : UserControl
//    {
//        private string _fullName;
//        private string _email;
//        private string _phone;
//        private DateTime _dob;
//        private string _spending;
//        private string _rankName;
//        private decimal _discount;
//        private int _memberId;

//        public header_bar(string fullName = null, string email = null, string phone = null, DateTime? dob = null, string spending = null, string rankName = null, decimal discount = 0, int memberId = -1)
//        {
//            InitializeComponent();
//            _fullName = fullName;
//            _email = email;
//            _phone = phone;
//            _dob = dob ?? DateTime.Now;
//            _spending = spending;
//            _rankName = rankName;
//            _discount = discount;
//            _memberId = memberId;

//            if (!string.IsNullOrEmpty(this._fullName))
//            {
//                lblProfile.Text = this._fullName;
//            }
//            else
//            {
//                lblProfile.Text = "Guest";
//            }
//        }

//        private void lblProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
//        {
//            if (!string.IsNullOrEmpty(this._fullName))
//            {
//                // Mở ProfileForm và truyền thông tin người dùng
//                ProfileForm profileForm = new ProfileForm(this._fullName, this._email, this._phone, this._dob, this._spending, this._rankName, this._discount);
//                profileForm.Show();

//                // Đóng HomepageForm hiện tại
//                Form currentForm = this.FindForm();
//                if (currentForm != null)
//                {
//                    currentForm.Close();
//                }
//            }
//            else
//            {
//                MessageBox.Show("Please log in to view your profile.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                FormRegistration loginForm = new FormRegistration();
//                loginForm.Show();
//                Form currentForm = this.FindForm();
//                if (currentForm != null)
//                {
//                    currentForm.Close();
//                }
//            }
//        }

//        private void lblSchedule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
//        {
//            // Chuyển đến trang Movie_Schedule
//            Movie_Schedule movieScheduleForm = new Movie_Schedule(_memberId);
//            movieScheduleForm.Show();

//            // Đóng form hiện tại
//            Form currentForm = this.FindForm();
//            if (currentForm != null)
//            {
//                currentForm.Close();
//            }
//        }

//        private void lblSignOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
//        {

//            DialogResult result = MessageBox.Show("Would you like to log out of your account?", "Yes",
//                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

//            if (result == DialogResult.Yes)
//            {
//                // Ẩn form hiện tại
//                this.Hide();

//                // Mở form đăng ký (đăng nhập)
//                FormRegistration formReg = new FormRegistration();
//                formReg.Show();

//                // Đóng form hiện tại sau khi mở form đăng ký
//                Form currentForm = this.FindForm();
//                if (currentForm != null)
//                {
//                    currentForm.Close();
//                }
//            }

//        }

//        private void lblName_Click(object sender, EventArgs e)
//        {
//            // Chuyển về trang chủ (HomepageForm)
//            HomepageForm homepageForm = new HomepageForm(this._fullName, this._email, this._phone, this._dob, this._spending, this._rankName, this._discount);
//            homepageForm.Show();

//            // Đóng form hiện tại
//            Form currentForm = this.FindForm();
//            if (currentForm != null)
//            {
//                currentForm.Close();
//            }
//        }
//    }
//}

//using System;
//using System.Windows.Forms;
//using Cinema.Forms.SignUp_SignIn;
//using Cinema.homepage;
//using Cinema.Forms;

//namespace Cinema
//{
//    public partial class header_bar : UserControl
//    {
//        private string _fullName;
//        private string _email;
//        private string _phone;
//        private DateTime _dob;
//        private string _spending;
//        private string _rankName;
//        private decimal _discount;
//        private int _memberId;

//        public header_bar(string fullName = null, string email = null, string phone = null, DateTime? dob = null, string spending = null, string rankName = null, decimal discount = 0, int memberId = -1)
//        {
//            InitializeComponent();
//            _fullName = fullName;
//            _email = email;
//            _phone = phone;
//            _dob = dob ?? DateTime.Now;
//            _spending = spending;
//            _rankName = rankName;
//            _discount = discount;
//            _memberId = memberId;

//            if (!string.IsNullOrEmpty(this._fullName))
//            {
//                lblProfile.Text = this._fullName;
//            }
//            else
//            {
//                lblProfile.Text = "Guest";
//            }
//        }

//        private void lblProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
//        {
//            if (!string.IsNullOrEmpty(this._fullName))
//            {
//                ProfileForm profileForm = new ProfileForm(this._fullName, this._email, this._phone, this._dob, this._spending, this._rankName, this._discount);
//                profileForm.Show();

//                Form currentForm = this.FindForm();
//                if (currentForm != null)
//                {
//                    currentForm.Close();
//                }
//            }
//            else
//            {
//                MessageBox.Show("Please log in to view your profile.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                FormRegistration loginForm = new FormRegistration();
//                loginForm.Show();
//                Form currentForm = this.FindForm();
//                if (currentForm != null)
//                {
//                    currentForm.Close();
//                }
//            }
//        }

//        private void lblSchedule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
//        {
//            Form currentForm = this.FindForm();

//            // Debug: Kiểm tra giá trị của _memberId
//            // MessageBox.Show($"Member ID: {_memberId}", "Debug");

//            if (_memberId == -1)
//            {
//                MessageBox.Show("Please log in to view the schedule.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                FormRegistration loginForm = new FormRegistration();
//                loginForm.Show();
//                if (currentForm != null)
//                {
//                    currentForm.Close();
//                }
//                return;
//            }

//            Movie_Schedule movieScheduleForm = new Movie_Schedule(_memberId, _fullName, _email, _phone, _dob, _spending, _rankName, _discount);
//            movieScheduleForm.Show();

//            if (currentForm != null)
//            {
//                currentForm.Close();
//            }
//        }

//        private void lblSignOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
//        {
//            DialogResult result = MessageBox.Show("Would you like to log out of your account?", "Yes",
//                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

//            if (result == DialogResult.Yes)
//            {
//                this.Hide();

//                FormRegistration formReg = new FormRegistration();
//                formReg.Show();

//                Form currentForm = this.FindForm();
//                if (currentForm != null)
//                {
//                    currentForm.Close();
//                }
//            }
//        }

//        private void lblName_Click(object sender, EventArgs e)
//        {
//            HomepageForm homepageForm = new HomepageForm(this._fullName, this._email, this._phone, this._dob, this._spending, this._rankName, this._discount, this._memberId);
//            homepageForm.Show();

//            Form currentForm = this.FindForm();
//            if (currentForm != null)
//            {
//                currentForm.Close();
//            }
//        }
//    }
//}

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