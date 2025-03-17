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
    public partial class Form1 : Form
    {
        private DataAccess dataAccess = new DataAccess();

        public Form1()
        {
            InitializeComponent();
            UpdateLinkLabel();
            LoadNowShowingMovies();
        }

        private void UpdateLinkLabel()
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

        private void LoadNowShowingMovies()
        {
            string sql = "SELECT * FROM Movie WHERE release_day <= GETDATE()";
            DataTable dt = dataAccess.ExecuteQueryTable(sql);
            dataGridView1.DataSource = dt;
        }

        private void LoadComingSoonMovies()
        {
            string sql = "SELECT * FROM Movie WHERE release_day > GETDATE()";
            DataTable dt = dataAccess.ExecuteQueryTable(sql);
            dataGridView1.DataSource = dt;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Session.IsLoggedIn)
            {
                Form2 form2 = new Form2();
                this.Hide();
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    UpdateLinkLabel();
                    this.Show();
                }
            }
            else
            {
                Form3 form3 = new Form3();
                this.Hide();
                form3.ShowDialog();
                this.Show();
            }
        }

        private void linkLabelNowShowing_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadNowShowingMovies();
        }

        private void linkLabelComingSoon_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadComingSoonMovies();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadNowShowingMovies();
        }
    }

    public static class Session
    {
        public static bool IsLoggedIn { get; set; } = false;
        public static string UserName { get; set; } = string.Empty;
    }
}
