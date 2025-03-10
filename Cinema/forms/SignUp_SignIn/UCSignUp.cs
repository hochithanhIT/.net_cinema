using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using System.Text.RegularExpressions;

namespace Cinema
{
    public partial class UCSignUp: UserControl
    {
        private FormRegistration formRegistration;
        private DataAccess dataAccess = new DataAccess();
        public UCSignUp(FormRegistration formRegistration)
        {
            InitializeComponent();
            this.formRegistration = formRegistration;
            this.txtPassword.UseSystemPasswordChar = true;
        }

        // Kiểm tra số điện thoại (10 chữ số)
        public static bool IsValidPhoneNumber(string phone)
        {
            return Regex.IsMatch(phone, @"^\d{10}$");
        }

        // Kiểm tra email (phải có @ và định dạng đúng)
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private void ClearAllFields()
        {
            this.txtFullName.Clear();
            this.txtEmail.Clear();
            this.txtPhone.Clear();
            this.txtPassword.Clear();
            this.cbShowPassword.Checked = false;
        }

        private void SignUp(string fullName, string phone, string email, DateTime birthDate, string password)
        {
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidEmail(txtEmail.Text.Trim())){
                MessageBox.Show("Your email is unvalid", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!IsValidPhoneNumber(txtPhone.Text.Trim()))
            {
                MessageBox.Show("Your phone number is unvalid", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Hash mật khẩu bằng BCrypt
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                // Câu lệnh SQL chèn dữ liệu vào bảng THEATER_MEM
                string sql = $@"
                INSERT INTO THEATER_MEM (FULL_NAME, PHONE, EMAIL, BIRTHDATE, PASS) 
                VALUES (N'{fullName}', '{phone}', '{email}', '{birthDate:yyyy-MM-dd}', '{hashedPassword}')";

                // Thực thi truy vấn
                int result = this.dataAccess.ExecuteDMLQuery(sql);

                if (result > 0)
                {
                    MessageBox.Show("Sign up successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ClearAllFields();
                }
                else
                {
                    MessageBox.Show("Sign up failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "SignUp() Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    private void lblLogIn_Click(object sender, EventArgs e)
        {
            this.formRegistration.AddUserControl(new UCSignIn(this.formRegistration));
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearAllFields();
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbShowPassword.Checked)
            {
                this.txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                this.txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các ô nhập liệu
            string fullName = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            DateTime birthDate = dtpDoB.Value;
            string password = txtPassword.Text.Trim();

            // Gọi phương thức SignUp với dữ liệu từ người dùng
            this.SignUp(fullName, phone, email, birthDate, password);
        }

    }
}
