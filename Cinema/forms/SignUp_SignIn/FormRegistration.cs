using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public partial class FormRegistration: Form
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

        private void FormRegistration_Load(object sender, EventArgs e)
        {
            this.AddUserControl(new UCSignIn(this));
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            this.AddUserControl(new UCSignIn(this));
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.AddUserControl(new UCSignUp(this));
        }
    }
}
