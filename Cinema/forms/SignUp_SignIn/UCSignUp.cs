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
using System.Data.SqlClient;

namespace Cinema.Forms.SignUp_SignIn
{
    public partial class UCSignUp : UserControl
    {
        private FormRegistration formRegistration;
        private DataAccess dataAccess = new DataAccess();
        
        public UCSignUp(FormRegistration formRegistration)
        {
            InitializeComponent();
            this.formRegistration = formRegistration;
            this.Password.UseSystemPasswordChar = true;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
        }

        // Check phone number (10 digits) and start with 0
        public static bool IsValidPhoneNumber(string phone)
        {
            return Regex.IsMatch(phone, @"^0\d{9}$");
        }

        // Check email (must have @ and correct format)
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private void ClearAllFields()
        {
            this.FullName.Clear();
            this.Email.Clear();
            this.Phone.Clear();
            this.Password.Clear();
            this.txtConfirmPassword.Clear();
            this.checkboxShowPassword.Checked = false;
        }

        private bool CheckDuplicateEmailOrPhone(string email, string phone)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM THEATER_MEM WHERE EMAIL = @email OR PHONE = @phone";
                using (SqlCommand cmd = new SqlCommand(query, dataAccess.Sqlcon))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@phone", phone);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0; // return true if email or phone number are exist
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking duplicate email/phone: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // If there is an error, not let user register
            }
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

            if (!IsValidPhoneNumber(phone.Trim()))
            {
                MessageBox.Show("Your phone number is invalid", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidEmail(email.Trim()))
            {
                MessageBox.Show("Your email is invalid", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (birthDate.Date > DateTime.Today)
            {
                MessageBox.Show("Birthdate cannot be in the future", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Check password has at least 8 characters
            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CheckDuplicateEmailOrPhone(email, phone))
            {
                MessageBox.Show("Email or phone number already exists. Please use a different email or phone number.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Hash password with BCrypt
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                
                string sql = $@"INSERT INTO THEATER_MEM (FULL_NAME, PHONE, EMAIL, BIRTHDATE, PASS, SPENDING) VALUES (N'{fullName}', '{phone}', '{email}', '{birthDate:yyyy-MM-dd}', '{hashedPassword}', '0')";

                // Execute query
                int result = this.dataAccess.ExecuteDMLQuery(sql);

                if (result > 0)
                {
                    MessageBox.Show("Sign up successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ClearAllFields();
                    this.formRegistration.AddUserControl(new UCSignIn(this.formRegistration));
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearAllFields();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // Get data from input cells
            string fullName = FullName.Text.Trim();
            string phone = Phone.Text.Trim();
            string email = Email.Text.Trim();
            DateTime birthDate = dob.Value;
            string password = Password.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (password!=confirmPassword)
            {
                MessageBox.Show("Your password and confirm password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Call the SignUp method with data from the user
            this.SignUp(fullName, phone, email, birthDate, password);
        }

        private void lblSignIn_Click(object sender, EventArgs e)
        {
           this.formRegistration.AddUserControl(new UCSignIn(this.formRegistration));
        }

        private void checkboxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkboxShowPassword.Checked)
            {
                this.Password.UseSystemPasswordChar = false;
                this.txtConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                this.Password.UseSystemPasswordChar = true;
                this.txtConfirmPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
