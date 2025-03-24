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
    public partial class header_bar : UserControl
    {
        public header_bar()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Session.IsLoggedIn)
            {
                linkLabel1.Text = $"Hello, {Session.UserName}";
            }
            else
            {
                linkLabel1.Text = "Login";
            }
        }
    }

    public static class Session
    {
        public static bool IsLoggedIn { get; set; } = false;
        public static string UserName { get; set; } = string.Empty;
    }
}
