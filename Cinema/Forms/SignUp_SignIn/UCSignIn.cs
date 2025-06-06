﻿using System;
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
using Cinema.Admin;
using Cinema.homepage;

namespace Cinema.Forms.SignUp_SignIn
{
    public partial class UCSignIn : UserControl
    {
        private FormRegistration formRegistration;
        private DataAccess dataAccess = new DataAccess();

        public UCSignIn(FormRegistration formRegistration)
        {
            InitializeComponent();
            this.formRegistration = formRegistration;
            this.txtPassword.UseSystemPasswordChar = true;
        }

        public static bool IsValidPhoneNumber(string phone)
        {
            return Regex.IsMatch(phone, @"^0\d{9}$");
        }

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
            if (string.IsNullOrEmpty(this.txtEmailOrPhone.Text) || string.IsNullOrEmpty(this.txtPassword.Text))
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
                string query = "SELECT SPENDING FROM THEATER_MEM WHERE EMAIL = @emailOrPhone OR PHONE = @emailOrPhone";
                using (SqlCommand cmd = new SqlCommand(query, dataAccess.Sqlcon))
                {
                    cmd.Parameters.AddWithValue("@emailOrPhone", emailOrPhone);

                    object result = cmd.ExecuteScalar();
                    int spending = result != null ? Convert.ToInt32(result) : 0;

                    if (spending == 0 || spending < 1000000)
                    {
                        query = "SELECT RANK_NAME, DISCOUNT FROM MEMBER_RANK WHERE THRESHOLD = 0";
                    }
                    else if (spending >= 1000000 && spending < 3000000)
                    {
                        query = "SELECT RANK_NAME, DISCOUNT FROM MEMBER_RANK WHERE THRESHOLD = 1000000";
                    }
                    else if (spending >= 3000000 && spending < 10000000)
                    {
                        query = "SELECT RANK_NAME, DISCOUNT FROM MEMBER_RANK WHERE THRESHOLD = 3000000";
                    }
                    else if (spending >= 10000000)
                    {
                        query = "SELECT RANK_NAME, DISCOUNT FROM MEMBER_RANK WHERE THRESHOLD = 10000000";
                    }
                    else
                    {
                        MessageBox.Show("There is something wrong with your member rank. Please contact Admin for help!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return (rankName, discount);
                    }

                    using (SqlCommand rankCmd = new SqlCommand(query, dataAccess.Sqlcon))
                    {
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

            if (!IsValidEmail(emailOrPhone) && !IsValidPhoneNumber(emailOrPhone))
            {
                MessageBox.Show("Invalid email or phone number format.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string query = "SELECT ID, PASS, FULL_NAME, EMAIL, PHONE, BIRTHDATE, SPENDING, MEM_ROLE FROM THEATER_MEM WHERE EMAIL = @emailOrphone OR PHONE = @emailOrphone";
                using (SqlCommand cmd = new SqlCommand(query, dataAccess.Sqlcon))
                {
                    cmd.Parameters.AddWithValue("@emailOrphone", emailOrPhone);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count == 1)
                        {
                            DataRow row = dt.Rows[0];
                            int memberId = Convert.ToInt32(row["ID"]);
                            string hashedPassword = dt.Rows[0]["PASS"].ToString();
                            string fullName = dt.Rows[0]["FULL_NAME"]?.ToString() ?? "Unknown User";
                            string email = dt.Rows[0]["EMAIL"].ToString();
                            string phone = dt.Rows[0]["PHONE"].ToString();
                            DateTime dob = Convert.ToDateTime(dt.Rows[0]["BIRTHDATE"]);
                            int spending = Convert.ToInt32(dt.Rows[0]["SPENDING"]);
                            int role = Convert.ToInt32(dt.Rows[0]["MEM_ROLE"]);

                            if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
                            {
                                MessageBox.Show($"Welcome {fullName}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Lấy rankName và discount
                                var (rankName, discount) = GetUserRankAndDiscount(emailOrPhone);

                                //// Lưu thông tin người dùng vào UserSession
                                UserSession.SetUser(memberId, fullName, email, phone, dob, spending.ToString(), rankName, discount, role);

                                // Trong UCSignIn.SignIn, sau khi gọi UserSession.SetUser
                                Console.WriteLine($"UserSession after login: IsLoggedIn={UserSession.IsLoggedIn}, MemberId={UserSession.MemberId}, Email={UserSession.Email}");

                                this.ClearAllFields();
                                
                                Form nextForm;

                                if (role == 0)
                                {
                                    nextForm = new AdminPage();
                                }
                                else
                                {
                                    nextForm = new HomepageForm();
                                }

                                nextForm.Show();
                                Form parentForm = this.FindForm();
                                parentForm?.Hide();
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"SignIn() Error: {ex.Message}\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.txtPassword.UseSystemPasswordChar = !this.checkboxShowPassword.Checked;
        }
    }
}
