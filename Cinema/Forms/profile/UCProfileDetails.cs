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
        private bool isSaving = false;

        public UCProfileDetails(ProfileForm profileForm)
        {
            InitializeComponent();
            this.ProfileForm = profileForm;

            if (UserSession.IsLoggedIn)
            {
                txtFullName.Text = UserSession.FullName;
                txtEmail.Text = UserSession.Email;
                txtPhone.Text = UserSession.Phone;
                dtpDoB.Value = UserSession.Dob ?? DateTime.Now;

                // Lock the email input field
                txtEmail.ReadOnly = true;

                // Display rank and discount message
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
                MessageBox.Show("User not logged in. Please log in to view your profile.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProfileForm.Close();
            }

            // Set up event handlers (assuming these are also in designer file, remove if duplicated)
            btnSave.Click += btnSave_Click;
            btnChangePassword.Click += btnChangePassword_Click;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isSaving) return; // Prevent duplicate execution
            isSaving = true;

            try
            {
                // Check if any fields have been edited
                bool isFullNameChanged = !txtFullName.Text.Equals(UserSession.FullName);
                bool isPhoneChanged = !txtPhone.Text.Equals(UserSession.Phone);
                bool isDoBChanged = dtpDoB.Value != (UserSession.Dob ?? DateTime.Now);

                if (!isFullNameChanged && !isPhoneChanged && !isDoBChanged)
                {
                    MessageBox.Show("No changes detected. Please update at least one field to save.", "Information",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Validate input fields
                if (!ValidateInputs())
                {
                    return; // Stop if validation fails
                }

                // If phone number is changed, check if it already exists in the database
                if (isPhoneChanged)
                {
                    if (IsPhoneNumberExists(txtPhone.Text))
                    {
                        MessageBox.Show("This phone number is already registered with another account. Please use a different phone number.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Update the database
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

                    // Ensure the connection is open
                    if (dataAccess.Sqlcon.State != System.Data.ConnectionState.Open)
                    {
                        dataAccess.Sqlcon.Open();
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Debug info
                    // MessageBox.Show($"Rows affected: {rowsAffected}\nEmail: {UserSession.Email}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Your information has been updated successfully!", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Update the local properties
                        UserSession.FullName = txtFullName.Text;
                        UserSession.Phone = txtPhone.Text;
                        UserSession.Dob = dtpDoB.Value;
                    }
                    else
                    {
                        MessageBox.Show($"Failed to update the information in the database. Email: {UserSession.Email}",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating information: {ex.Message}\nStack: {ex.StackTrace}", "Exception",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isSaving = false; // Reset flag to allow future saves
                if (dataAccess.Sqlcon.State == System.Data.ConnectionState.Open)
                {
                    dataAccess.Sqlcon.Close(); // Close connection if it was opened
                }
            }
        }

        // Validate input fields
        private bool ValidateInputs()
        {
            // Validate Full Name
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Full Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate Phone Number
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Phone Number cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate phone number format (e.g., 10 digits, only numbers)
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Phone Number must be a 10-digit number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate Date of Birth (cannot be in the future)
            DateTime currentDate = DateTime.Now;
            if (dtpDoB.Value > currentDate)
            {
                MessageBox.Show("Date of Birth cannot be in the future.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int minimumAge = 13;
            if (dtpDoB.Value > currentDate.AddYears(-minimumAge))
            {
                MessageBox.Show($"You must be at least {minimumAge} years old to register.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Check if the phone number already exists in the database
        private bool IsPhoneNumberExists(string phoneNumber)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM THEATER_MEM WHERE PHONE = @phone AND EMAIL != @email";
                using (SqlCommand cmd = new SqlCommand(query, dataAccess.Sqlcon))
                {
                    cmd.Parameters.AddWithValue("@phone", phoneNumber);
                    cmd.Parameters.AddWithValue("@email", UserSession.Email);

                    if (dataAccess.Sqlcon.State != System.Data.ConnectionState.Open)
                    {
                        dataAccess.Sqlcon.Open();
                    }

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // Return true if the phone number exists for a different email
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking phone number: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Assume it doesn't exist to avoid blocking the update in case of an error
            }
            finally
            {
                if (dataAccess.Sqlcon.State == System.Data.ConnectionState.Open)
                {
                    dataAccess.Sqlcon.Close();
                }
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            // Hide the current UCProfileDetails control
            this.Visible = false;

            // Pass the correct ProfileForm instance
            ProfileForm.AddUserControl(new UCChangePass(ProfileForm));
        }
    }
}