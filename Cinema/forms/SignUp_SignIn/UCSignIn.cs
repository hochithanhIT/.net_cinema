using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Cinema
{
    public partial class UCSignIn: UserControl
    {
        private FormRegistration formRegistration;
        private DataAccess dataAccess = new DataAccess();
        public UCSignIn(FormRegistration formRegistration)
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
            this.txtEmailOrPhone.Clear();
            this.txtPassword.Clear();
            this.cbShowPassword.Checked = false;
        }

        private bool IsValidToSignIn()
        {
            if (
                string.IsNullOrEmpty(this.txtEmailOrPhone.Text) ||
                string.IsNullOrEmpty(this.txtPassword.Text)
            )
            {
                return false;
            }
            return true;
        }

        private void SignIn(string emailOrPhone, string password)
        {
            if (!this.IsValidToSignIn())
            {
                MessageBox.Show("Please fill in all fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem emailOrPhone nhập vào có hợp lệ không
            if (!IsValidEmail(emailOrPhone) && !IsValidPhoneNumber(emailOrPhone))
            {
                MessageBox.Show("Invalid email or phone number format.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Truy vấn lấy mật khẩu băm từ database
                string query = "SELECT PASS, FULL_NAME FROM THEATER_MEM WHERE EMAIL = @emailOrphone OR PHONE = @emailOrphone";
                SqlCommand cmd = new SqlCommand(query, dataAccess.Sqlcon);
                cmd.Parameters.AddWithValue("@emailOrphone", emailOrPhone);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    string hashedPassword = dt.Rows[0]["PASS"].ToString();
                    string fullName = dt.Rows[0]["FULL_NAME"].ToString();

                    // So sánh mật khẩu với bcrypt
                    if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
                    {
                        MessageBox.Show($"Welcome {fullName}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ClearAllFields();
                    }
                    else
                    {
                        MessageBox.Show("Invalid email/phone or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Account not found.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SignIn() Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void lblSignUp_Click(object sender, EventArgs e)
        {
            this.formRegistration.AddUserControl(new UCSignUp(this.formRegistration));
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearAllFields();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các ô nhập liệu
            string emailOrphone = txtEmailOrPhone.Text.Trim();
            string password = txtPassword.Text.Trim();
            this.SignIn(emailOrphone, password);
        }
    }
}
