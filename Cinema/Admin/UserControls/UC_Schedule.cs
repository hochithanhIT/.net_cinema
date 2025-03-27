using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cinema.Admin.Components;
using Cinema.Admin.TheaterComponents;
using System.Data.SqlClient;
using Cinema.Admin.UserControls;
using Cinema.Admin.SchedulesComponents;


namespace Cinema.Admin.UserControls
{
    public partial class UC_Schedule : UserControl
    {
        private DataAccess dataAccess = new DataAccess();
        public UC_Schedule()
        {
            InitializeComponent();
            UpdateMovieAndTheaterData(FDate.Value);
        }
        
        private void FDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateMovieAndTheaterData(FDate.Value);
        }

        private void UpdateMovieAndTheaterData(DateTime selectedDate)
        {
            string query = $@"
        SELECT DISTINCT m.id, m.movie_name
        FROM schedule s
        JOIN movie m ON s.movie_id = m.id
        WHERE CAST(s.start_time AS DATE) = '{selectedDate:yyyy-MM-dd}'";

            DataTable moviesByDate = dataAccess.ExecuteQueryTable(query);

            FMovie.DataSource = moviesByDate.Rows.Count > 0 ? moviesByDate : null;
            if (moviesByDate.Rows.Count == 0)
            {
                FMovie.DataSource = null;
                FTheater.DataSource = null;
                return;
            }

            FMovie.DisplayMember = "movie_name";
            FMovie.ValueMember = "id";
            FMovie.SelectedIndex = -1;

            string query2 = $@"
        SELECT DISTINCT t.id, t.theater_name
        FROM schedule s
        JOIN theater t ON s.theater_id = t.id
        WHERE CAST(s.start_time AS DATE) = '{selectedDate:yyyy-MM-dd}'";

            DataTable screensByDate = dataAccess.ExecuteQueryTable(query2);

            FTheater.DataSource = screensByDate.Rows.Count > 0 ? screensByDate : null;
            if (screensByDate.Rows.Count == 0)
            {
                FMovie.DataSource = null;
                FTheater.DataSource = null;
                return;
            }

            FTheater.DisplayMember = "theater_name";
            FTheater.ValueMember = "id";
            FTheater.SelectedIndex = -1;

            const int maxAllowedWidth = 800;
            using (Graphics g = FMovie.CreateGraphics())
            {
                int maxItemWidth = FMovie.Items.Cast<DataRowView>()
                    .Max(item => (int)g.MeasureString(item["movie_name"].ToString(), FMovie.Font).Width + 50);

                FMovie.DropDownWidth = maxItemWidth > maxAllowedWidth ? maxItemWidth : Math.Max(FMovie.Width, maxItemWidth);
            }
        }

        private void FMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FMovie.DataSource == null)
            {
                return;
            }
            try
            {
                int selectedMovieID;
                if (FMovie.SelectedItem is DataRowView rowView)
                {
                    selectedMovieID = Convert.ToInt32(rowView["id"]);
                }
                else
                {
                    selectedMovieID = Convert.ToInt32(FMovie.SelectedValue);
                }
                if (FDate.Value == null)
                {
                    MessageBox.Show("Vui lòng chọn ngày hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DateTime selectedDate = FDate.Value;
                string query = $@"
                    SELECT DISTINCT
                        t.ID AS TheaterId,
                        t.theater_name AS TheaterName
                    FROM SCHEDULE s
                    JOIN THEATER t ON s.THEATER_ID = t.ID
                    WHERE CONVERT(DATE, s.START_TIME) = '{selectedDate:yyyy-MM-dd}'
                    AND s.MOVIE_ID = '{selectedMovieID}'
                    ORDER BY t.ID;";

                DataTable screensByMovie = dataAccess.ExecuteQueryTable(query);

                if (screensByMovie.Rows.Count == 0)
                {
                    FTheater.DataSource = null;
                    return;
                }

                FTheater.DataSource = screensByMovie;
                FTheater.DisplayMember = "TheaterName";
                FTheater.ValueMember = "TheaterId";
                FTheater.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải phòng chiếu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void check_Click(object sender, EventArgs e)
        {
            try
            {
                if (FDate.Value == null)
                {
                    MessageBox.Show("Vui lòng chọn ngày hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DateTime selectedDate = FDate.Value;
                string movieId = FMovie.SelectedValue?.ToString();
                string theaterId = FTheater.SelectedValue?.ToString();

                string query = $@"
                    SELECT 
                        s.id AS [Schedule id],
                        t.theater_name AS [Screen name],
                        m.movie_name AS [Movie name], 
                        FORMAT(s.start_time, 'HH:mm') AS [Start time], 
                        FORMAT(s.end_time, 'HH:mm') AS [End time]
                    FROM SCHEDULE s
                    JOIN MOVIE m ON s.MOVIE_ID = m.ID
                    JOIN THEATER t on s.THEATER_ID = t.ID
                    WHERE 
                        (@movieId IS NULL OR s.MOVIE_ID = @movieId)
                        AND (@theaterId IS NULL OR s.THEATER_ID = @theaterId)
                        AND (@selectedDate IS NULL OR CAST(s.START_TIME AS DATE) = @selectedDate)";


                SqlParameter[] parameters = {
                    new SqlParameter("@movieId", (object)movieId ?? DBNull.Value),
                    new SqlParameter("@theaterId", (object)theaterId ?? DBNull.Value),
                    new SqlParameter("@selectedDate", (object)selectedDate.Date ?? DBNull.Value)
                };
                                
                DataTable selectedSchedule = dataAccess.ExecuteQueryWithParams(query, parameters);
                if (selectedSchedule.Rows.Count > 0)
                {
                    dataGridView1.DataSource = null;

                    dataGridView1.DataSource = selectedSchedule;
                    dataGridView1.Visible = true;

                    dataGridView1.Columns["Schedule id"].Width = 75;
                    dataGridView1.Columns["Screen name"].Width = 125;

                    dataGridView1.Columns["Movie name"].Width = 372;

                    dataGridView1.Columns["Start time"].Width = 125;

                    dataGridView1.Columns["End time"].Width = 125;

                    int rowHeight = dataGridView1.RowTemplate.Height;
                    int headerHeight = dataGridView1.ColumnHeadersHeight;
                    int totalHeight = (selectedSchedule.Rows.Count * rowHeight) + headerHeight;

                    int maxHeight = this.Height - dataGridView1.Top - 50;
                    dataGridView1.Height = Math.Min(totalHeight, maxHeight);

                }
                else
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.Visible = false;
                    MessageBox.Show("Không có suất chiếu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi truy vấn suất chiếu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ResetFil_Click(object sender, EventArgs e)
        {
            try
            {
                FMovie.DataSource = null;
                FMovie.Refresh();

                FTheater.DataSource = null;
                FTheater.Refresh();

                dataGridView1.Visible = false;

                FDate.Value = DateTime.Today;
                UpdateMovieAndTheaterData(FDate.Value);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đặt lại bộ lọc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FTheater_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {            
            if (e.RowIndex >= 0) // Kiểm tra hàng hợp lệ
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (row.DataBoundItem is DataRowView drv && drv.Row["Schedule id"] != DBNull.Value)
                {
                    int scheduleId = Convert.ToInt32(drv.Row["Schedule id"]); // Lấy scheduleId
                    Schedule_Edit scheduleEditForm = new Schedule_Edit(scheduleId); // Truyền sang Schedule_Edit
                    scheduleEditForm.FormClosed += (s, args) => check_Click(sender, e); // Cập nhật lại danh sách sau khi đóng
                    scheduleEditForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Schedule ID trong hàng đã chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Schedule_Add scheduleAddForm = new Schedule_Add();
            scheduleAddForm.FormClosed += (s, args) => ResetFil_Click(s, args);
            scheduleAddForm.ShowDialog();
        }
    }
}
