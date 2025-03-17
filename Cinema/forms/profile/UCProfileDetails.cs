using System;
using System.Windows.Forms;

namespace Cinema.forms.profile
{
    public partial class UCProfileDetails : UserControl
    {
        private ProfileForm ProfileForm;
        private string FullName { get; set; }
        private string Email { get; set; }
        private string Phone { get; set; }
        private DateTime DoB { get; set; } // Change to DateTime
        private string Spending { get; set; }

        public UCProfileDetails(ProfileForm profileForm, string fullName, string email, string phone, DateTime dob, string spending)
        {
            InitializeComponent();
            this.ProfileForm = profileForm;
            this.FullName = fullName;
            this.Email = email;
            this.Phone = phone;
            this.DoB = dob; // Assign DateTime value
            this.Spending = spending;

            // Display user information
            txtFullName.Text = $"{fullName}";
            txtEmail.Text = $"{email}";
            txtPhone.Text = $"{phone}";
            dtpDoB.Value = dob; // Set DateTimePicker value
            txtSpending.Text = $"{spending}";
        }

        // Default constructor (optional, for backward compatibility)
        public UCProfileDetails(ProfileForm profileForm)
        {
            InitializeComponent();
            this.ProfileForm = profileForm;
        }
    }
}