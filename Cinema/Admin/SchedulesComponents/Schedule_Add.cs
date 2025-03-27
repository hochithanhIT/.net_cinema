using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;


namespace Cinema.Admin.SchedulesComponents
{
    public partial class Schedule_Add: Form
    {
        private DataAccess dataAccess = new DataAccess();

        public Schedule_Add()
        {
            InitializeComponent();
        }

        private void Schedule_Add_Load(object sender, EventArgs e)
        {
            try
            {
                string query = @"Select * from THEATER";
                DataTable screen = dataAccess.ExecuteQueryTable(query);
                if (screen.Rows.Count > 0) {
                    FTheater.DataSource = null;
                    FTheater.DataSource = screen;
                    FTheater.DisplayMember = "theater_name";
                    FTheater.ValueMember = "id";
                    FTheater.SelectedIndex = 0;
                }
                dataGridView1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải rạp:{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
              
        private void FTheater_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable movies = LoadMovies(sender, e);
                
                if (movies.Rows.Count > 0)
                {
                    FMovie.DataSource = movies;
                    FMovie.DisplayMember = "Movie Name";
                    FMovie.ValueMember = "Movie ID";
                    FMovie.SelectedIndex = 0;

                    const int maxAllowedWidth = 450;
                    using (Graphics g = FMovie.CreateGraphics())
                    {
                        int maxItemWidth = FMovie.Items.Cast<DataRowView>()
                            .Max(item => (int)g.MeasureString(item["Movie Name"].ToString(), FMovie.Font).Width + 50);

                        FMovie.DropDownWidth = maxItemWidth > maxAllowedWidth ? maxItemWidth : Math.Max(FMovie.Width, maxItemWidth);
                    }
                }
                else
                {
                    FMovie.DataSource = null;
                }

            } catch (Exception ex) {
                MessageBox.Show($"Lỗi khi load phim theo rạp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FMovie.DataSource = null;
            }
            
        }

        private void FMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private DataTable LoadMovies(object sender, EventArgs e)
        {
            string theaterId;
            if (FTheater.SelectedValue != null)
            {
                if (FTheater.SelectedValue is DataRowView rowView)
                {
                    theaterId = rowView["id"].ToString(); 
                }
                else
                {
                    theaterId = FTheater.SelectedValue.ToString();
                }
            }
            else
            {
                theaterId = null; 
            }
            DateTime selectedDate = FDate.Value;

            string query = @"
                    SELECT
                        id AS [Movie ID],
                        movie_name AS [Movie name]
                    FROM movie";

            DataTable result = dataAccess.ExecuteQueryTable(query);

            return result ?? new DataTable();
        }
      
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (FMovie.DataSource == null || FMovie.SelectedIndex == -1 || FTheater.DataSource == null || FTheater.SelectedIndex == -1 || FDate.Value == null)
                {
                    MessageBox.Show($"Vui lòng điền toàn bộ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                DateTime selectedDate = FDate.Value;

                // Xử lý SelectedValue
                string movieId;
                if (FMovie.SelectedValue is DataRowView movieRowView)
                {
                    movieId = movieRowView["Movie ID"].ToString();
                }
                else
                {
                    movieId = FMovie.SelectedValue?.ToString();
                }

                string theaterId;
                if (FTheater.SelectedValue is DataRowView theaterRowView)
                {
                    theaterId = theaterRowView["id"].ToString();
                }
                else
                {
                    theaterId = FTheater.SelectedValue?.ToString();
                }

                // Truy vấn lịch chiếu
                string query = $@"
                    SELECT DISTINCT
                        FORMAT(s.start_time, 'HH:mm') AS [Start time],
                        FORMAT(s.end_time, 'HH:mm') AS [End time]
                    FROM SCHEDULE s
                    JOIN THEATER t on s.THEATER_ID = t.ID
                    WHERE 
                        (@theaterId IS NULL OR s.THEATER_ID = @theaterId)
                        AND (@selectedDate IS NULL OR CAST(s.START_TIME AS DATE) = @selectedDate)";

                SqlParameter[] parameters = {
                new SqlParameter("@theaterId", (object)theaterId ?? DBNull.Value),
                new SqlParameter("@selectedDate", (object)selectedDate.Date ?? DBNull.Value)};

                DataTable occupiedSchedules = dataAccess.ExecuteQueryWithParams(query, parameters);

                // Lấy duration
                string query2 = "SELECT DISTINCT running_time FROM movie WHERE id = @movieId";
                SqlParameter[] parameters2 = { new SqlParameter("@movieId", movieId) };
                DataTable durationTable = dataAccess.ExecuteQueryWithParams(query2, parameters2);

                int duration;
                if (durationTable.Rows.Count > 0)
                {
                    duration = Convert.ToInt32(durationTable.Rows[0]["running_time"]);
                }
                else
                {
                    throw new Exception("Không tìm thấy thời lượng phim cho movieId đã chọn.");
                }

                // Tính khoảng cấm
                var forbiddenSlots = occupiedSchedules.AsEnumerable()
                    .Select(row => new
                    {
                        Start = TimeSpan.Parse(row.Field<string>("Start time")),
                        End = TimeSpan.Parse(row.Field<string>("End time")),
                    })
                    .Select(slot => new
                    {
                        ForbiddenStart = slot.Start - TimeSpan.FromMinutes(30),
                        ForbiddenEnd = slot.End + TimeSpan.FromMinutes(30),
                    })
                    .OrderBy(slot => slot.ForbiddenStart)
                    .ToList();

                // Tìm khoảng trống
                TimeSpan dayStart = TimeSpan.FromHours(7);
                TimeSpan dayEnd = TimeSpan.FromHours(23);
                TimeSpan durationSpan = TimeSpan.FromMinutes(duration);
                TimeSpan gap = TimeSpan.FromMinutes(30); // Khoảng cách giữa các khoảng trống
                TimeSpan currentTime = dayStart;

                var availableSlots = new List<(TimeSpan Start, TimeSpan End)>();

                if (forbiddenSlots.Count == 0)
                {
                    // Trường hợp không có lịch chiếu: Trả về một khoảng trống lớn từ 07:00 đến 23:00
                    availableSlots.Add((dayStart, dayEnd));
                }
                else
                {
                    // Trường hợp có lịch chiếu: Tìm tất cả khoảng trống
                    foreach (var slot in forbiddenSlots)
                    {
                        while (currentTime + durationSpan <= slot.ForbiddenStart)
                        {
                            availableSlots.Add((currentTime, currentTime + durationSpan));
                            currentTime += durationSpan + gap;
                        }
                        currentTime = slot.ForbiddenEnd > currentTime ? slot.ForbiddenEnd : currentTime;
                    }
                    // Kiểm tra khoảng trống cuối ngày
                    while (currentTime + durationSpan <= dayEnd)
                    {
                        availableSlots.Add((currentTime, currentTime + durationSpan));
                        currentTime += durationSpan + gap;
                    }

                    // Gộp các khoảng trống liên tiếp
                    if (availableSlots.Count > 0)
                    {
                        var mergedSlots = new List<(TimeSpan Start, TimeSpan End)>();
                        var currentSlot = availableSlots[0];

                        for (int i = 1; i < availableSlots.Count; i++)
                        {
                            var nextSlot = availableSlots[i];
                            // Nếu khoảng trống tiếp theo bắt đầu ngay sau khoảng trống hiện tại (cách 30 phút)
                            if (nextSlot.Start == currentSlot.End + gap)
                            {
                                currentSlot = (currentSlot.Start, nextSlot.End); // Gộp khoảng trống
                            }
                            else
                            {
                                mergedSlots.Add(currentSlot); // Thêm khoảng trống hiện tại vào danh sách
                                currentSlot = nextSlot; // Chuyển sang khoảng trống tiếp theo
                            }
                        }
                        mergedSlots.Add(currentSlot); // Thêm khoảng trống cuối cùng
                        availableSlots = mergedSlots; // Cập nhật danh sách
                    }
                }

                // Tạo DataTable kết quả
                DataTable result = new DataTable();
                result.Columns.Add("Start time", typeof(string));
                result.Columns.Add("End time", typeof(string));

                availableSlots.ForEach(slot =>
                    result.Rows.Add(slot.Start.ToString(@"hh\:mm"), slot.End.ToString(@"hh\:mm")));

                dataGridView1.DataSource = result;
                dataGridView1.Visible = true;

                dataGridView1.Columns["Start time"].Width = 123;
                dataGridView1.Columns["End time"].Width = 123;

                int rowHeight = dataGridView1.RowTemplate.Height;
                int headerHeight = dataGridView1.ColumnHeadersHeight;
                int totalHeight = (result.Rows.Count * rowHeight) + headerHeight;

                int maxHeight = 246;
                dataGridView1.Height = Math.Min(totalHeight, maxHeight);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load thời gian trống: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable movies = LoadMovies(sender, e);

                if (movies.Rows.Count > 0)
                {
                    FMovie.DataSource = movies;
                    FMovie.DisplayMember = "Movie Name";
                    FMovie.ValueMember = "Movie ID";
                    FMovie.SelectedIndex = 0;

                    const int maxAllowedWidth = 450;
                    using (Graphics g = FMovie.CreateGraphics())
                    {
                        int maxItemWidth = FMovie.Items.Cast<DataRowView>()
                            .Max(item => (int)g.MeasureString(item["Movie Name"].ToString(), FMovie.Font).Width + 50);

                        FMovie.DropDownWidth = maxItemWidth > maxAllowedWidth ? maxItemWidth : Math.Max(FMovie.Width, maxItemWidth);
                    }
                }
                else
                {
                    FMovie.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load phim theo rạp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FMovie.DataSource = null;
            }
        }

        private void ResetFil_Click(object sender, EventArgs e)
        {
            try
            {
                LoadMovies(sender, e);

                FTheater.SelectedIndex = 0;

                dataGridView1.Visible = false;

                FDate.Value = DateTime.Today;

                maskedTextBox1.Clear();
                maskedTextBox2.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đặt lại bộ lọc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                // Kiểm tra các giá trị đầu vào
                if (FMovie.DataSource == null || FMovie.SelectedIndex == -1 ||
                    FTheater.DataSource == null || FTheater.SelectedIndex == -1 ||
                    FDate.Value == null ||
                    string.IsNullOrWhiteSpace(maskedTextBox2.Text) || maskedTextBox2.Text.Contains("_") ||
                    string.IsNullOrWhiteSpace(maskedTextBox1.Text) || maskedTextBox1.Text.Contains("_"))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin (phim, rạp, ngày, thời gian bắt đầu và kết thúc)!",
                                   "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy movieId
                string movieId;
                if (FMovie.SelectedValue is DataRowView movieRowView)
                {
                    movieId = movieRowView["Movie ID"].ToString();
                }
                else
                {
                    movieId = FMovie.SelectedValue?.ToString();
                }

                // Lấy theaterId
                string theaterId;
                if (FTheater.SelectedValue is DataRowView theaterRowView)
                {
                    theaterId = theaterRowView["id"].ToString();
                }
                else
                {
                    theaterId = FTheater.SelectedValue?.ToString();
                }

                // Lấy ngày từ FDate
                DateTime selectedDate = FDate.Value;

                // Lấy startTime và endTime từ maskedTextBox
                if (!TimeSpan.TryParse(maskedTextBox2.Text, out TimeSpan startTime) ||
                    !TimeSpan.TryParse(maskedTextBox1.Text, out TimeSpan endTime))
                {
                    MessageBox.Show("Thời gian không hợp lệ! Vui lòng nhập theo định dạng HH:mm (ví dụ: 14:30).",
                                   "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra thời gian hợp lệ
                if (startTime.Hours < 0 || startTime.Hours > 23 || startTime.Minutes < 0 || startTime.Minutes > 59 ||
                    endTime.Hours < 0 || endTime.Hours > 23 || endTime.Minutes < 0 || endTime.Minutes > 59)
                {
                    MessageBox.Show("Thời gian không hợp lệ! Giờ phải từ 00 đến 23, phút phải từ 00 đến 59.",
                                   "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kết hợp ngày và thời gian để tạo DateTime
                DateTime startDateTime = selectedDate.Date.Add(startTime);
                DateTime endDateTime = selectedDate.Date.Add(endTime);

                // Kiểm tra nếu endTime nhỏ hơn startTime (có thể là ngày hôm sau)
                if (endDateTime < startDateTime)
                {
                    endDateTime = endDateTime.AddDays(1);
                }

                // Truy vấn lịch chiếu hiện có
                string query = @"
            SELECT DISTINCT
                FORMAT(s.start_time, 'HH:mm') AS [Start time],
                FORMAT(s.end_time, 'HH:mm') AS [End time]
            FROM SCHEDULE s
            JOIN THEATER t on s.THEATER_ID = t.ID
            WHERE 
                (@theaterId IS NULL OR s.THEATER_ID = @theaterId)
                AND (@selectedDate IS NULL OR CAST(s.START_TIME AS DATE) = @selectedDate)";

                SqlParameter[] parameters = {
            new SqlParameter("@theaterId", (object)theaterId ?? DBNull.Value),
            new SqlParameter("@selectedDate", (object)selectedDate.Date ?? DBNull.Value)
        };

                DataTable occupiedSchedules = dataAccess.ExecuteQueryWithParams(query, parameters);

                // Tính khoảng cấm
                var forbiddenSlots = occupiedSchedules.AsEnumerable()
                    .Select(row => new
                    {
                        Start = TimeSpan.Parse(row.Field<string>("Start time")),
                        End = TimeSpan.Parse(row.Field<string>("End time")),
                    })
                    .Select(slot => new
                    {
                        ForbiddenStart = selectedDate.Date.Add(slot.Start).AddMinutes(-30),
                        ForbiddenEnd = slot.End > slot.Start
                            ? selectedDate.Date.Add(slot.End).AddMinutes(30)
                            : selectedDate.Date.Add(slot.End).AddMinutes(30).AddDays(1)
                    })
                    .OrderBy(slot => slot.ForbiddenStart)
                    .ToList();

                // Kiểm tra lịch chiếu mới có nằm trong khoảng cấm không
                bool isConflict = false;
                foreach (var slot in forbiddenSlots)
                {
                    if (startDateTime < slot.ForbiddenEnd && endDateTime > slot.ForbiddenStart)
                    {
                        isConflict = true;
                        break;
                    }
                }

                if (isConflict)
                {
                    ResetFil_Click(sender,e);
                    MessageBox.Show("Lịch chiếu mới trùng với một lịch chiếu hiện có (bao gồm khoảng giải lao 30 phút trước và sau)! Vui lòng chọn thời gian khác.",
                                   "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Nếu không có xung đột, thực hiện INSERT
                string insertQuery = @"
                    INSERT INTO SCHEDULE (MOVIE_ID, THEATER_ID, START_TIME, END_TIME)
                    VALUES (@movieId, @theaterId, @startTime, @endTime)";

                SqlParameter[] insertParameters = {
                new SqlParameter("@movieId", movieId),
                new SqlParameter("@theaterId", theaterId),
                new SqlParameter("@startTime", startDateTime),
                new SqlParameter("@endTime", endDateTime)
        };

                int rowsAffected = dataAccess.ExecuteDMLQueryWithParams(insertQuery, insertParameters);

                // Kiểm tra kết quả
                if (rowsAffected > 0) // Sửa lại điều kiện kiểm tra
                {
                    MessageBox.Show("Thêm lịch chiếu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset form sau khi thêm thành công
                    ResetFil_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Không thể thêm lịch chiếu. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm lịch chiếu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        

        private void maskedTextBox2_Leave(object sender, EventArgs e)
        {
            string movieId = null;
            if (string.IsNullOrEmpty(maskedTextBox2.Text)) { return; }
            try
            {
                if (FMovie.DataSource != null)
                {
                    if (FMovie.SelectedValue is DataRowView movieRowView)
                    {
                        movieId = movieRowView["Movie ID"].ToString();
                    }
                    else
                    {
                        movieId = FMovie.SelectedValue?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
            }
            if (string.IsNullOrEmpty(movieId))
            {
                MessageBox.Show("Vui lòng chọn phim trước khi nhập thời gian!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query2 = "SELECT DISTINCT running_time FROM movie WHERE id = @movieId";
            SqlParameter[] parameters2 = { new SqlParameter("@movieId", movieId) };
            DataTable durationTable = dataAccess.ExecuteQueryWithParams(query2, parameters2);

            int duration;
            if (durationTable.Rows.Count > 0)
            {
                duration = Convert.ToInt32(durationTable.Rows[0]["running_time"]);
            }
            else
            {
                throw new Exception("Không tìm thấy thời lượng phim cho movieId đã chọn.");
            }
            if (string.IsNullOrWhiteSpace(maskedTextBox2.Text) || maskedTextBox2.Text.Contains("_"))
            {
                MessageBox.Show("Vui lòng nhập thời gian hợp lệ (HH:mm)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!TimeSpan.TryParse(maskedTextBox2.Text, out TimeSpan startTime))
            {
                MessageBox.Show("Thời gian nhập không hợp lệ! Vui lòng nhập theo định dạng HH:mm (ví dụ: 14:30).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra giá trị thời gian hợp lệ (giờ từ 0-23, phút từ 0-59)
            if (startTime.Hours < 0 || startTime.Hours > 23 || startTime.Minutes < 0 || startTime.Minutes > 59)
            {
                MessageBox.Show("Thời gian không hợp lệ! Giờ phải từ 00 đến 23, phút phải từ 00 đến 59.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            startTime = TimeSpan.Parse(maskedTextBox2.Text);
            TimeSpan endTime = startTime.Add(TimeSpan.FromMinutes(duration));
            maskedTextBox1.Text = endTime.ToString(@"hh\:mm");
        }

        private void maskedTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                maskedTextBox2_Leave(sender, e);
            }
        }
    }
}
