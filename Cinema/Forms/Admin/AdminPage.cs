using Cinema.Admin.UserControls;
using Cinema.Forms.SignUp_SignIn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Cinema.Admin
{
    public partial class AdminPage : Form
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void addUserControl (UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UC_Schedule uc = new UC_Schedule();
            addUserControl(uc);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            UC_Movies uc = new UC_Movies();
            addUserControl (uc);

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            UC_Schedule uc = new UC_Schedule();
            addUserControl(uc);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            UC_Theaters uc = new UC_Theaters();
            addUserControl(uc);
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            UC_Members uc = new UC_Members();
            addUserControl(uc);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to log out of your account?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Xóa thông tin người dùng khi đăng xuất
                UserSession.ClearUser();

                this.Hide();

                FormRegistration formReg = new FormRegistration();
                formReg.Show();

                Form currentForm = this.FindForm();
                if (currentForm != null)
                {
                    currentForm.Close();
                }
            }
        }
    }
}
