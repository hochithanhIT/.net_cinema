using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.Forms {
    public partial class Movie_Detail : Form {
        public Movie_Detail() {
            InitializeComponent();
        }

        private void Movie_Detail_Load(object sender, EventArgs e) {

        }

        private void Booking_Button_MouseEnter(object sender, EventArgs e) {
            Booking_Button.BackColor = Color.FromArgb(116, 198, 157);
            Booking_Button.ForeColor = Color.White;
        }

        private void Booking_Button_MouseLeave(object sender, EventArgs e) {
            Booking_Button.BackColor = Color.FromArgb(148, 213, 180);
            Booking_Button.ForeColor = Color.SeaGreen;
        }
    }
}
