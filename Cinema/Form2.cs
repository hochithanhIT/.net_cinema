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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Mở Form1 khi click vào Button
            Form1 form1 = new Form1();
            form1.Show();

            Form ParentForm = this.FindForm();
            ParentForm.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
