using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.forms.SignUp_SignIn
{
    public partial class FormRegistration : Form
    {
        public FormRegistration()
        {
            InitializeComponent();
        }

        public void AddUserControl(System.Windows.Forms.UserControl uc)
        {
            this.panelContainer.Controls.Clear();
            this.panelContainer.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            this.AddUserControl(new UCSignIn(this));
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.AddUserControl(new UCSignUp(this));
        }

        private void FormRegistration_Load_1(object sender, EventArgs e)
        {
            this.AddUserControl(new UCSignIn(this));
        }

        private void btnSignIn_MouseEnter(object sender, EventArgs e)
        {
            btnSignIn.BackColor = Color.White;
            btnSignIn.ForeColor = Color.Black;
        }

        private void btnSignIn_MouseLeave(object sender, EventArgs e)
        {
            btnSignIn.BackColor = Color.Black;
            btnSignIn.ForeColor = Color.White;
        }

        private void btnSignUp_MouseEnter(object sender, EventArgs e)
        {
            btnSignUp.BackColor = Color.WhiteSmoke;
            btnSignUp.ForeColor = Color.Black;
        }

        private void btnSignUp_MouseLeave(object sender, EventArgs e)
        {
            btnSignUp.BackColor = Color.Black;
            btnSignUp.ForeColor = Color.WhiteSmoke;
        }
    }
}