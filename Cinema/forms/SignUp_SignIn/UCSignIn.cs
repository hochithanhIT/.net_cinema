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
using Cinema.forms.Admin;
using Cinema.forms.Customer;

namespace Cinema.forms.SignUp_SignIn
{
    public partial class UCSignIn : UserControl
    {
        private FormRegistration formRegistration;
        private ProfileForm profileForm = new ProfileForm();
        private DataAccess dataAccess = new DataAccess();

        public UCSignIn(FormRegistration formRegistration)
        {
            InitializeComponent();
            this.formRegistration = formRegistration;
            this.txtPassword.UseSystemPasswordChar = true;
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
            this.txtEmailOrPhone.Clear();
            this.txtPassword.Clear();
            this.checkboxShowPassword.Checked = false;
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
        private (string RankName, decimal Discount) GetUserRankAndDiscount(string emailOrPhone)
        {
            string rankName = "No Rank";
            decimal discount = 0.0m;

            try
            {
                // Query to get user spending
                string query = "SELECT SPENDING FROM THEATER_MEM WHERE EMAIL = @emailOrPhone OR PHONE = @emailOrPhone";
                using (SqlCommand cmd = new SqlCommand(query, dataAccess.Sqlcon))
                {
                    cmd.Parameters.AddWithValue("@emailOrPhone", emailOrPhone);

                    // Execute the query to get the user's spending
                    int spending = Convert.ToInt32(cmd.ExecuteScalar());

                    // Determine the rank based on spending
                    if (spending == 0 || spending < 1000000)
                    {
                        // Get the rank and discount for threshold = 0
                        query = "SELECT RANK_NAME, DISCOUNT FROM MEMBER_RANK WHERE THRESHOLD = 0";
                    }
                    else if (spending == 1000000 || spending < 3000000)
                    {
                        // Get the rank and discount for threshold = 1000000
                        query = "SELECT RANK_NAME, DISCOUNT FROM MEMBER_RANK WHERE THRESHOLD = 1000000";
                    }
                    else if (spending == 3000000 || spending < 10000000)
                    {
                        // Get the rank and discount for threshold = 3000000
                        query = "SELECT RANK_NAME, DISCOUNT FROM MEMBER_RANK WHERE THRESHOLD = 3000000";
                    }
                    else if (spending >= 10000000)
                    {
                        // Get the rank and discount for threshold = 10000000
                        query = "SELECT RANK_NAME, DISCOUNT FROM MEMBER_RANK WHERE THRESHOLD = 10000000";
                    }
                    else
                    {
                        MessageBox.Show("There is something wrong with your member rank. Please contact Admin for help!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    using (SqlCommand rankCmd = new SqlCommand(query, dataAccess.Sqlcon))
                    {
                        if (spending != 0 && spending >= 1000000)
                        {
                            rankCmd.Parameters.AddWithValue("@spending", spending);
                        }

                        using (SqlDataReader reader = rankCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                rankName = reader["RANK_NAME"].ToString();
                                discount = Convert.ToDecimal(reader["DISCOUNT"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving rank: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return (rankName, discount);
        }
        private void SignIn(string emailOrPhone, string password)
        {
            if (!this.IsValidToSignIn())
            {
                MessageBox.Show("Please fill in all fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate email or phone
            if (!IsValidEmail(emailOrPhone) && !IsValidPhoneNumber(emailOrPhone))
            {
                MessageBox.Show("Invalid email or phone number format.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Must enter at least 8 characters before checking
            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string query = "SELECT PASS, FULL_NAME, EMAIL, PHONE, BIRTHDATE, SPENDING, MEM_ROLE FROM THEATER_MEM WHERE EMAIL = @emailOrphone OR PHONE = @emailOrphone";
                SqlCommand cmd = new SqlCommand(query, dataAccess.Sqlcon);
                cmd.Parameters.AddWithValue("@emailOrphone", emailOrPhone);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    string hashedPassword = dt.Rows[0]["PASS"].ToString();
                    string fullName = dt.Rows[0]["FULL_NAME"].ToString();
                    string email = dt.Rows[0]["EMAIL"].ToString();
                    string phone = dt.Rows[0]["PHONE"].ToString();
                    DateTime dob = Convert.ToDateTime(dt.Rows[0]["BIRTHDATE"]);
                    int spending = Convert.ToInt32(dt.Rows[0]["SPENDING"]);
                    int role = Convert.ToInt32(dt.Rows[0]["MEM_ROLE"]);

                    // Verify password
                    if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
                    {
                        MessageBox.Show($"Welcome {fullName}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ClearAllFields();
                        Form nextForm;

                        if (role == 0)
                        {
                            nextForm = new AdminForm();
                        }
                        else // Nếu role khác 0, mở form khách hàng
                        {

                            nextForm = new CustomerForm();
                        }

                        // Get user rank and discount based on spending
                        var (rankName, discount) = GetUserRankAndDiscount(emailOrPhone);
                        nextForm.Show();
                        //// Pass user data to ProfileForm
                        //ProfileForm profileForm = new ProfileForm(fullName, email, phone, dob, spending.ToString(), rankName, discount);
                        //profileForm.Show();

                        // Close the login form
                        Form parentForm = this.FindForm();
                        parentForm.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearAllFields();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string emailOrphone = txtEmailOrPhone.Text.Trim();
            string password = txtPassword.Text.Trim();
            this.SignIn(emailOrphone, password);
        }

        private void lbSignUp_Click(object sender, EventArgs e)
        {
            this.formRegistration.AddUserControl(new UCSignUp(this.formRegistration));
        }

        private void checkboxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkboxShowPassword.Checked)
            {
                this.txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                this.txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}