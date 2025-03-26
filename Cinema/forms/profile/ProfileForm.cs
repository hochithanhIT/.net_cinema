using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cinema.Forms.profile;
using Cinema.Forms.SignUp_SignIn;
using Cinema.homepage;

namespace Cinema
    {
        public partial class ProfileForm : Form
        {
            // Properties to store user data
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public DateTime DoB { get; set; } // Change to DateTime
            public string Spending { get; set; }
            public string RankName { get; set; }
            public decimal Discount { get; set; }

            public ProfileForm(string fullName, string email, string phone, DateTime dob, string spending, string rankName, decimal discount)
            {
                InitializeComponent();
                this.FullName = fullName;
                this.Email = email;
                this.Phone = phone;
                this.DoB = dob;
                this.Spending = spending;
                this.RankName = rankName;
                this.Discount = discount;

                // Load UCProfileDetails with user data
                this.AddUserControl(new UCProfileDetails(this, fullName, email, phone, dob, spending, rankName, discount));
            }
            public ProfileForm()
            {
                InitializeComponent();
            }

            // Method to add a UserControl to the panel
            public void AddUserControl(System.Windows.Forms.UserControl uc)
            {
                this.panelUC.Controls.Clear();
                this.panelUC.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }

            private void ProfileForm_Load(object sender, EventArgs e)
            {
                // Load UCProfileDetails with user data when the form loads
                if (!string.IsNullOrEmpty(FullName) && !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Phone))
                {
                    this.AddUserControl(new UCProfileDetails(this, FullName, Email, Phone, DoB, Spending, RankName, Discount));
                }
            }

            private void btnProfile_Click(object sender, EventArgs e)
            {
                // Load UCProfileDetails with user data
                this.AddUserControl(new UCProfileDetails(this, FullName, Email, Phone, DoB, Spending, RankName, Discount));
            }


            private void btnTransactionHistory_Click(object sender, EventArgs e)
            {
            // Load UCTicketHistory
            this.AddUserControl(new UCTicketHistory(this, FullName, Email, Phone, DoB, Spending, RankName, Discount));
        }

        private void Logout()
            {
                DialogResult result = MessageBox.Show("Would you like to log out of your account?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Ẩn form hiện tại
                    this.Hide();

                    // Mở form đăng ký (đăng nhập)
                    FormRegistration formReg = new FormRegistration();
                    formReg.Show();

                    // Đóng form hiện tại sau khi mở form đăng ký
                    this.Close();
                }
            }

            private void btnLogOut_Click(object sender, EventArgs e)
            {
                Logout();
            }

        private void btnHome_Click(object sender, EventArgs e)
        { 
            this.Hide();

            HomepageForm homepage = new HomepageForm(FullName, Email, Phone, DoB, Spending, RankName, Discount);
            homepage.Show();

            this.Close();
            
        }
    }
    }