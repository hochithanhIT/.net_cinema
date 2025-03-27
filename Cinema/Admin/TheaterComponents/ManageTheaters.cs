using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.Admin.TheaterComponents
{
    public partial class ManageTheaters : Form
    {
        private DataAccess dataAccess = new DataAccess();
        public ManageTheaters()
        {
            
            InitializeComponent();
        }

        private void ManageTheaters_Load(object sender, EventArgs e)
        {
            LoadTheaters();
        }

        private void LoadTheaters()
        {
            try
            {
                string query = "SELECT id, theater_name FROM theater";
                DataTable theaters = dataAccess.ExecuteQueryTable(query);

                listBox1.Items.Clear();
                foreach (DataRow row in theaters.Rows)
                {
                    listBox1.Items.Add(new TheaterItem
                    {
                        TheaterID = Convert.ToInt32(row["id"]),
                        TheaterName = row["theater_name"].ToString()
                    });
                }

                listBox1.DisplayMember = "TheaterName";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading theaters: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private class TheaterItem
        {
            public int TheaterID { get; set; }
            public string TheaterName { get; set; }

            public override string ToString()
            {
                return TheaterName; // Hiển thị tên rạp trong listBox
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
        
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị hộp thoại xác nhận
                DialogResult confirmResult = MessageBox.Show(
                    "Are you sure you want to create a new theater?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                // Nếu người dùng không nhấn "Yes" thì dừng lại
                if (confirmResult != DialogResult.Yes)
                    return;

                // Insert new theater and get its ID
                string insertTheaterQuery = "INSERT INTO theater (theater_name, isDeleted) VALUES ('', 0); SELECT SCOPE_IDENTITY();";
                DataTable resultTable = dataAccess.ExecuteQueryTable(insertTheaterQuery);

                if (resultTable.Rows.Count > 0)
                {
                    int newTheaterId = Convert.ToInt32(resultTable.Rows[0][0]);

                    // Update theater name to "Screen <ID>"
                    string updateNameQuery = $"UPDATE theater SET theater_name = 'Screen {newTheaterId}' WHERE id = {newTheaterId}";
                    dataAccess.ExecuteDMLQuery(updateNameQuery);

                    // Insert seats for the new theater
                    string insertSeatsQuery = $@"
                INSERT INTO SEAT (THEATER_ID, SEAT_CODE)
                SELECT {newTheaterId}, CONCAT(R.Letter, FORMAT(C.Number, '00'))
                FROM (VALUES ('A'), ('B'), ('C'), ('D'), ('E'), ('F'), ('G'), ('H')) AS R(Letter)
                CROSS JOIN (VALUES (1), (2), (3), (4), (5), (6), (7), (8), (9), (10), (11), (12)) AS C(Number);";

                    dataAccess.ExecuteDMLQuery(insertSeatsQuery);

                    MessageBox.Show("Theater created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTheaters(); // Reload the theater list
                }
                else
                {
                    MessageBox.Show("Failed to create theater!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
