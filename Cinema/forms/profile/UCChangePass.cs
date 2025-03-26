//using System;
//using System.Data.SqlClient;
//using System.Windows.Forms;
//using Cinema.Forms.SignUp_SignIn;

//namespace Cinema.Forms.profile
//{
//    public partial class UCChangePass : UserControl
//    {
//        private ProfileForm ProfileForm;
//        private DataAccess dataAccess = new DataAccess();
//        private FormRegistration FormRegistration;
//        // Updated Constructor to accept ProfileForm
//        public UCChangePass(ProfileForm profileForm, FormRegistration formRegistration)
//        {
//            InitializeComponent();
//            this.ProfileForm = profileForm; // Assign the ProfileForm object
//            this.FormRegistration = formRegistration;
//            this.txtCurrentPassword.UseSystemPasswordChar = true;
//            this.txtNewPassword.UseSystemPasswordChar = true;
//            this.txtConfirmPassword.UseSystemPasswordChar = true;
//        }

//        private void btnSave_Click(object sender, EventArgs e)
//        {
//            string currentPassword = txtCurrentPassword.Text;
//            string newPassword = txtNewPassword.Text;
//            string confirmPassword = txtConfirmPassword.Text;

//            // Must enter at least 8 characters
//            if (currentPassword.Length < 8)
//            {
//                MessageBox.Show("Your current password must be at least 8 characters long", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }
//            if (newPassword.Length < 8)
//            {
//                MessageBox.Show("New password must be at least 8 characters long", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            if (newPassword != confirmPassword)
//            {
//                MessageBox.Show("New password and confirm password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            // Ensure ProfileForm is not null before accessing its properties
//            if (ProfileForm == null)
//            {
//                MessageBox.Show("ProfileForm is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            try
//            {
//                // Retrieve the current hashed password from the database using email
//                string query = "SELECT PASS FROM THEATER_MEM WHERE EMAIL = @Email";
//                using (SqlCommand cmd = new SqlCommand(query, dataAccess.Sqlcon))
//                {
//                    cmd.Parameters.AddWithValue("@Email", ProfileForm.Email);

//                    string hashedPassword = cmd.ExecuteScalar()?.ToString();

//                    // Check if the current password is correct
//                    if (hashedPassword != null && BCrypt.Net.BCrypt.Verify(currentPassword, hashedPassword))
//                    {
//                        // Ensure new password is not the same as the current one
//                        if (BCrypt.Net.BCrypt.Verify(newPassword, hashedPassword))
//                        {
//                            MessageBox.Show("New password cannot be the same as the current password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                            return;
//                        }

//                        // Update the password in the database
//                        string updateQuery = "UPDATE THEATER_MEM SET PASS = @NewPassword WHERE EMAIL = @Email";
//                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, dataAccess.Sqlcon))
//                        {
//                            updateCmd.Parameters.AddWithValue("@NewPassword", BCrypt.Net.BCrypt.HashPassword(newPassword));
//                            updateCmd.Parameters.AddWithValue("@Email", ProfileForm.Email);

//                            int rowsAffected = updateCmd.ExecuteNonQuery();

//                            if (rowsAffected > 0)
//                            {
//                                MessageBox.Show("Your password has been updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

//                                // Return to the profile details screen
//                                //ProfileForm.AddUserControl(new UCProfileDetails(ProfileForm, ProfileForm.FullName, ProfileForm.Email, ProfileForm.Phone, ProfileForm.DoB, ProfileForm.Spending, ProfileForm.RankName, ProfileForm.Discount));
//                                // Log out by closing the current ProfileForm and navigating to the Login screen
//                                ProfileForm.Close();  // Close the profile form

//                                // Show the login form
//                                FormRegistration formRegistration = new FormRegistration();
//                                formRegistration.Show();
//                            }
//                            else
//                            {
//                                MessageBox.Show("Failed to update password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                            }
//                        }
//                    }
//                    else
//                    {
//                        MessageBox.Show("Current password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error changing password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void btnCancel_Click(object sender, EventArgs e)
//        {
//            if (ProfileForm != null)
//            {
//                // Hide the current UCChangePass control
//                this.Visible = false;

//                // Display the UCProfileDetails control
//                UCProfileDetails ucProfileDetails = new UCProfileDetails(ProfileForm, ProfileForm.FullName, ProfileForm.Email, ProfileForm.Phone, ProfileForm.DoB, ProfileForm.Spending, ProfileForm.RankName, ProfileForm.Discount);
//                ProfileForm.AddUserControl(ucProfileDetails);
//            }
//            else
//            {
//                MessageBox.Show("ProfileForm is null. Cannot navigate back.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
//        {
//            if (this.cbShowPassword.Checked)
//            {
//                this.txtCurrentPassword.UseSystemPasswordChar = false;
//                this.txtNewPassword.UseSystemPasswordChar = false;
//                this.txtConfirmPassword.UseSystemPasswordChar = false;
//            }
//            else
//            {
//                this.txtCurrentPassword.UseSystemPasswordChar = true;
//                this.txtNewPassword.UseSystemPasswordChar = true;
//                this.txtConfirmPassword.UseSystemPasswordChar = true;
//            }
//        }
//    }
//}

using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Cinema.Forms.SignUp_SignIn;

namespace Cinema.Forms.profile
{
    public partial class UCChangePass : UserControl
    {
        private ProfileForm ProfileForm;
        private DataAccess dataAccess = new DataAccess();

        // Constructor chỉ cần ProfileForm
        public UCChangePass(ProfileForm profileForm)
        {
            InitializeComponent();
            this.ProfileForm = profileForm;
            this.txtCurrentPassword.UseSystemPasswordChar = true;
            this.txtNewPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Kiểm tra độ dài mật khẩu
            if (currentPassword.Length < 8)
            {
                MessageBox.Show("Your current password must be at least 8 characters long", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (newPassword.Length < 8)
            {
                MessageBox.Show("New password must be at least 8 characters long", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New password and confirm password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra người dùng đã đăng nhập
            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("User not logged in. Please log in to change your password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Lấy mật khẩu đã mã hóa từ database bằng email từ UserSession
                string query = "SELECT PASS FROM THEATER_MEM WHERE EMAIL = @Email";
                using (SqlCommand cmd = new SqlCommand(query, dataAccess.Sqlcon))
                {
                    cmd.Parameters.AddWithValue("@Email", UserSession.Email);

                    string hashedPassword = cmd.ExecuteScalar()?.ToString();

                    // Kiểm tra mật khẩu hiện tại
                    if (hashedPassword != null && BCrypt.Net.BCrypt.Verify(currentPassword, hashedPassword))
                    {
                        // Đảm bảo mật khẩu mới không trùng với mật khẩu hiện tại
                        if (BCrypt.Net.BCrypt.Verify(newPassword, hashedPassword))
                        {
                            MessageBox.Show("New password cannot be the same as the current password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Cập nhật mật khẩu trong database
                        string updateQuery = "UPDATE THEATER_MEM SET PASS = @NewPassword WHERE EMAIL = @Email";
                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, dataAccess.Sqlcon))
                        {
                            updateCmd.Parameters.AddWithValue("@NewPassword", BCrypt.Net.BCrypt.HashPassword(newPassword));
                            updateCmd.Parameters.AddWithValue("@Email", UserSession.Email);

                            int rowsAffected = updateCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Your password has been updated successfully! Please log in again.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Đăng xuất: xóa UserSession và chuyển về màn hình đăng nhập
                                UserSession.ClearUser();
                                ProfileForm.Close();

                                // Mở form đăng nhập
                                FormRegistration formRegistration = new FormRegistration();
                                formRegistration.Show();
                            }
                            else
                            {
                                MessageBox.Show("Failed to update password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Current password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error changing password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ProfileForm != null)
            {
                // Ẩn UCChangePass
                this.Visible = false;

                // Hiển thị UCProfileDetails với thông tin từ UserSession
                UCProfileDetails ucProfileDetails = new UCProfileDetails(ProfileForm);
                ProfileForm.AddUserControl(ucProfileDetails);
            }
            else
            {
                MessageBox.Show("ProfileForm is null. Cannot navigate back.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbShowPassword.Checked)
            {
                this.txtCurrentPassword.UseSystemPasswordChar = false;
                this.txtNewPassword.UseSystemPasswordChar = false;
                this.txtConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                this.txtCurrentPassword.UseSystemPasswordChar = true;
                this.txtNewPassword.UseSystemPasswordChar = true;
                this.txtConfirmPassword.UseSystemPasswordChar = true;
            }
        }
    }
}