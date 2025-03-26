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
        private FormRegistration FormRegistration;
        private DataAccess dataAccess = new DataAccess();

        private string FullName { get; set; }
        private string Email { get; set; }
        private string Phone { get; set; }
        private DateTime DoB { get; set; } // Change to DateTime
        private string Spending { get; set; }

        public string RankName { get; set; }
        public decimal Discount { get; set; }

        public UCProfileDetails(ProfileForm profileForm)
        {
            InitializeComponent();
            this.ProfileForm = profileForm;
        }

        public UCProfileDetails(ProfileForm profileForm, string fullName, string email, string phone, DateTime dob, string spending, string rankName, decimal discount)
        {
            InitializeComponent();
            this.ProfileForm = profileForm;
            this.FullName = fullName;
            this.Email = email;
            this.Phone = phone;
            this.DoB = dob;
            this.Spending = spending;
            this.RankName = rankName;
            this.Discount = discount;

            // Display user information
            txtFullName.Text = $"{fullName}";
            txtEmail.Text = $"{email}";
            txtPhone.Text = $"{phone}";
            dtpDoB.Value = dob;

            // Lock the email input field
            txtEmail.ReadOnly = true;

            // Set up event handlers
            btnSave.Click += btnSave_Click;
            btnChangePassword.Click += btnChangePassword_Click;

            // Display rank and discount message
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if any fields have been edited correctly
                bool isFullNameChanged = !txtFullName.Text.Equals(FullName);
                bool isPhoneChanged = !txtPhone.Text.Equals(Phone);
                bool isDoBChanged = dtpDoB.Value != DoB;

                if (isFullNameChanged || isPhoneChanged || isDoBChanged)
                {
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
                        cmd.Parameters.AddWithValue("@originalEmail", Email);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Your information has been updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Update the local properties
                            FullName = txtFullName.Text;
                            Phone = txtPhone.Text;
                            DoB = dtpDoB.Value;

                            return; // Stop further execution
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
            // Hide the current UCProfileDetails control
            this.Visible = false;

            // Pass the correct ProfileForm instance
            ProfileForm.AddUserControl(new UCChangePass(ProfileForm, FormRegistration));
        }
    }
}