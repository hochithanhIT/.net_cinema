using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Cinema.Forms.SignUp_SignIn;

namespace Cinema.Forms.profile
{
    public partial class UCProfileDetails : UserControl
    {
        private ProfileForm ProfileForm;
        private DataAccess dataAccess = new DataAccess();

        public UCProfileDetails(ProfileForm profileForm)
        {
            InitializeComponent();
            this.ProfileForm = profileForm;

            // Hiển thị thông tin người dùng từ UserSession
            if (UserSession.IsLoggedIn)
            {
                txtFullName.Text = UserSession.FullName;
                txtEmail.Text = UserSession.Email;
                txtPhone.Text = UserSession.Phone;
                dtpDoB.Value = UserSession.Dob ?? DateTime.Now;

                // Lock the email input field
                txtEmail.ReadOnly = true;

                // Hiển thị thông tin rank và discount
                string rankName = UserSession.RankName;
                decimal discount = UserSession.Discount;

                if (rankName == "Bronze")
                {
                    lblMemRank.Text = $"Your current membership rank is {rankName} with {discount:P} discount! Book your movie tickets now to upgrade your rank and get more discounts.";
                }
                else if (rankName == "Silver" || rankName == "Gold")
                {
                    lblMemRank.Text = $"As a {rankName} member, you enjoy a {discount:P} discount on ticket bookings! Book your tickets now to upgrade your rank and unlock even bigger discounts!";
                }
                else
                {
                    lblMemRank.Text = $"As a {rankName} member, enjoy a stellar {discount:P} discount on ticket bookings! Book now and maximize your exclusive benefits!";
                }
            }
            else
            {
                MessageBox.Show("User not logged in. Please log in to view your profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProfileForm.Close();
            }

            // Set up event handlers
            btnSave.Click += btnSave_Click;
            btnChangePassword.Click += btnChangePassword_Click;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các trường đã thay đổi
                bool isFullNameChanged = !txtFullName.Text.Equals(UserSession.FullName);
                bool isPhoneChanged = !txtPhone.Text.Equals(UserSession.Phone);
                bool isDoBChanged = dtpDoB.Value != (UserSession.Dob ?? DateTime.Now);

                if (isFullNameChanged || isPhoneChanged || isDoBChanged)
                {
                    // Cập nhật database
                    string query = @"
                        UPDATE THEATER_MEM 
                        SET FULL_NAME = @fullName, 
                            PHONE = @phone, 
                            BIRTHDATE = @dob 
                        WHERE EMAIL = @originalEmail";

                    using (SqlCommand cmd = new SqlCommand(query, dataAccess.Sqlcon))
                    {
                        cmd.Parameters.AddWithValue("@fullName", txtFullName.Text);
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@dob", dtpDoB.Value);
                        cmd.Parameters.AddWithValue("@originalEmail", UserSession.Email);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Your information has been updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Cập nhật UserSession
                            UserSession.FullName = txtFullName.Text;
                            UserSession.Phone = txtPhone.Text;
                            UserSession.Dob = dtpDoB.Value;
                        }
                        else
                        {
                            MessageBox.Show("Failed to update the information in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating information: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            // Ẩn UCProfileDetails
            this.Visible = false;

            // Mở UCChangePass
            ProfileForm.AddUserControl(new UCChangePass(ProfileForm));
        }
    }
}