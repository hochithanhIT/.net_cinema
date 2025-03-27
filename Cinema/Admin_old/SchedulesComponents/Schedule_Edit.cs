using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Admin.SchedulesComponents
{
    public partial class Schedule_Edit : Form
    {
        private DataAccess dataAccess = new DataAccess();
        private int scheduleId; // Biến instance lưu scheduleId

        public Schedule_Edit(int scheduleId)
        {
            InitializeComponent();
            this.scheduleId = scheduleId; // Lưu scheduleId vào biến instance
        }

        private void Schedule_Edit_Load(object sender, EventArgs e)
        {
            try
            {
                string theaterQuery = "SELECT id, theater_name FROM THEATER";
                DataTable theaters = dataAccess.ExecuteQueryTable(theaterQuery);
                if (theaters.Rows.Count > 0)
                {
                    FTheater.DataSource = theaters;
                    FTheater.DisplayMember = "theater_name";
                    FTheater.ValueMember = "id";
                }

                // Load danh sách phim (FMovie)
                DataTable movies = LoadMovies(sender,e);
                if (movies.Rows.Count > 0)
                {
                    FMovie.DataSource = movies;
                    FMovie.DisplayMember = "Movie Name";
                    FMovie.ValueMember = "Movie ID";
                }

                // Load thông tin lịch chiếu hiện tại dựa trên scheduleId
                string scheduleQuery = @"
                    SELECT 
                        s.theater_id,
                        t.theater_name,
                        s.movie_id,
                        m.movie_name,
                        s.start_time,
                        s.end_time
                    FROM SCHEDULE s
                    JOIN THEATER t ON s.theater_id = t.id
                    JOIN movie m ON s.movie_id = m.id
                    WHERE s.id = @scheduleId";
                SqlParameter[] scheduleParams = { new SqlParameter("@scheduleId", scheduleId) };
                DataTable scheduleData = dataAccess.ExecuteQueryWithParams(scheduleQuery, scheduleParams);

                if (scheduleData.Rows.Count > 0)
                {
                    DataRow row = scheduleData.Rows[0];
                    string theaterId = row["theater_id"].ToString();
                    string movieId = row["movie_id"].ToString();
                    DateTime startTime = Convert.ToDateTime(row["start_time"]);
                    DateTime endTime = Convert.ToDateTime(row["end_time"]);

                    // Gán giá trị cho các control
                    FTheater.SelectedValue = theaterId;
                    FMovie.SelectedValue = movieId;
                    FDate.Value = startTime.Date;
                    maskedTextBox2.Text = startTime.ToString("HH:mm");
                    maskedTextBox1.Text = endTime.ToString("HH:mm");

                    // Ẩn DataGridView ban đầu
                    dataGridView1.Visible = false;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy lịch chiếu với ID đã cho.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu lịch chiếu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void FTheater_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FMovie_SelectedIndexChanged(object sender, EventArgs e)
        {

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

                // Truy vấn lịch chiếu hiện có, loại trừ lịch đang chỉnh sửa
                string query = @"
            SELECT DISTINCT
                FORMAT(s.start_time, 'HH:mm') AS [Start time],
                FORMAT(s.end_time, 'HH:mm') AS [End time]
            FROM SCHEDULE s
            JOIN THEATER t ON s.THEATER_ID = t.ID
            WHERE 
                s.THEATER_ID = @theaterId
                AND CAST(s.START_TIME AS DATE) = @selectedDate
                AND s.id != @scheduleId";

                SqlParameter[] parameters = {
            new SqlParameter("@theaterId", theaterId),
            new SqlParameter("@selectedDate", selectedDate.Date),
            new SqlParameter("@scheduleId", scheduleId)
        };

                DataTable occupiedSchedules = dataAccess.ExecuteQueryWithParams(query, parameters);

                // Truy vấn thông tin lịch chiếu hiện tại
                string currentScheduleQuery = @"
            SELECT
                FORMAT(s.start_time, 'HH:mm') AS [Start time],
                FORMAT(s.end_time, 'HH:mm') AS [End time]
            FROM SCHEDULE s
            WHERE s.id = @scheduleId";
                SqlParameter[] currentParams = { new SqlParameter("@scheduleId", scheduleId) };
                DataTable currentSchedule = dataAccess.ExecuteQueryWithParams(currentScheduleQuery, currentParams);

                TimeSpan? currentStart = null;
                TimeSpan? currentEnd = null;
                if (currentSchedule.Rows.Count > 0)
                {
                    currentStart = TimeSpan.Parse(currentSchedule.Rows[0]["Start time"].ToString());
                    currentEnd = TimeSpan.Parse(currentSchedule.Rows[0]["End time"].ToString());
                }

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

                // Thêm thời gian của lịch hiện tại vào danh sách khoảng trống
                if (currentStart.HasValue && currentEnd.HasValue)
                {
                    availableSlots.Add((currentStart.Value, currentEnd.Value));
                }

                if (forbiddenSlots.Count == 0)
                {
                    // Trường hợp không có lịch chiếu khác: Trả về toàn bộ thời gian từ 07:00 đến 23:00 trừ lịch hiện tại
                    if (!currentStart.HasValue) // Nếu không có lịch hiện tại
                    {
                        availableSlots.Add((dayStart, dayEnd));
                    }
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
                }

                // Gộp các khoảng trống liên tiếp
                if (availableSlots.Count > 0)
                {
                    availableSlots = availableSlots.OrderBy(slot => slot.Start).ToList();
                    var mergedSlots = new List<(TimeSpan Start, TimeSpan End)>();
                    var currentSlot = availableSlots[0];

                    for (int i = 1; i < availableSlots.Count; i++)
                    {
                        var nextSlot = availableSlots[i];
                        if (nextSlot.Start <= currentSlot.End + gap)
                        {
                            currentSlot = (currentSlot.Start, nextSlot.End > currentSlot.End ? nextSlot.End : currentSlot.End);
                        }
                        else
                        {
                            mergedSlots.Add(currentSlot);
                            currentSlot = nextSlot;
                        }
                    }
                    mergedSlots.Add(currentSlot);
                    availableSlots = mergedSlots;
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

        private void ResetFil_Click(object sender, EventArgs e)
        {
            try
            {
                Schedule_Edit_Load(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đặt lại bộ lọc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private DataTable LoadMovies(object sender, EventArgs e)
        {
            string query = @"
                    SELECT
                        id AS [Movie ID],
                        movie_name AS [Movie name]
                    FROM movie WHERE isDeleted = 0";

            DataTable result = dataAccess.ExecuteQueryTable(query);

            return result ?? new DataTable();
        }

        private void maskedTextBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maskedTextBox2.Text) || !maskedTextBox2.MaskFull)
            {
                maskedTextBox2.Text = string.Empty;
                return;
            }

            try
            {
                // Lấy movieId
                string movieId = null;
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
                if (string.IsNullOrEmpty(movieId))
                {
                    MessageBox.Show("Vui lòng chọn phim trước khi nhập thời gian!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy theaterId
                string theaterId = null;
                if (FTheater.DataSource != null)
                {
                    if (FTheater.SelectedValue is DataRowView theaterRowView)
                    {
                        theaterId = theaterRowView["id"].ToString();
                    }
                    else
                    {
                        theaterId = FTheater.SelectedValue?.ToString();
                    }
                }
                if (string.IsNullOrEmpty(theaterId))
                {
                    MessageBox.Show("Vui lòng chọn rạp trước khi nhập thời gian!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra thời gian nhập vào
                if (!maskedTextBox2.MaskFull || !TimeSpan.TryParse(maskedTextBox2.Text, out TimeSpan startTime))
                {
                    MessageBox.Show("Thời gian nhập không hợp lệ hoặc chưa đầy đủ! Vui lòng nhập theo định dạng HH:mm (ví dụ: 14:30).",
                                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    maskedTextBox2.Clear();
                    maskedTextBox1.Clear();
                    return;
                }

                // Kiểm tra giá trị thời gian hợp lệ (giờ từ 0-23, phút từ 0-59)
                if (startTime.Hours < 0 || startTime.Hours > 23 || startTime.Minutes < 0 || startTime.Minutes > 59)
                {
                    MessageBox.Show("Thời gian không hợp lệ! Giờ phải từ 00 đến 23, phút phải từ 00 đến 59.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    maskedTextBox2.Clear();
                    maskedTextBox1.Clear();
                    return;
                }

                // Lấy thời lượng phim
                string query2 = "SELECT DISTINCT running_time FROM movie WHERE id = @movieId AND isDeleted = 0";
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

                // Tính thời gian kết thúc
                TimeSpan endTime = startTime.Add(TimeSpan.FromMinutes(duration));
                DateTime selectedDate = FDate.Value;
                DateTime startDateTime = selectedDate.Date.Add(startTime);
                DateTime endDateTime = selectedDate.Date.Add(endTime);

                // Định nghĩa giới hạn thời gian
                TimeSpan dayStart = TimeSpan.FromHours(7); // 07:00
                TimeSpan dayEnd = TimeSpan.FromHours(23);  // 23:00

                // Kiểm tra thời gian bắt đầu và kết thúc trong khoảng 07:00 - 23:00
                if (startTime < dayStart)
                {
                    MessageBox.Show("Thời gian bắt đầu phải từ 07:00 trở đi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    maskedTextBox2.Clear();
                    maskedTextBox1.Clear();
                    return;
                }

                if (endTime > dayEnd)
                {
                    MessageBox.Show("Thời gian kết thúc không được vượt quá 23:00!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    maskedTextBox2.Clear();
                    maskedTextBox1.Clear();
                    return;
                }

                // Truy vấn lịch chiếu hiện có, loại trừ lịch đang chỉnh sửa
                string query = @"
            SELECT DISTINCT
                FORMAT(s.start_time, 'HH:mm') AS [Start time],
                FORMAT(s.end_time, 'HH:mm') AS [End time]
            FROM SCHEDULE s
            JOIN THEATER t ON s.THEATER_ID = t.ID
            WHERE 
                s.THEATER_ID = @theaterId
                AND CAST(s.START_TIME AS DATE) = @selectedDate
                AND s.id != @scheduleId";
                SqlParameter[] parameters = {
            new SqlParameter("@theaterId", theaterId),
            new SqlParameter("@selectedDate", selectedDate.Date),
            new SqlParameter("@scheduleId", scheduleId)
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

                // Kiểm tra xung đột
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
                    MessageBox.Show("Thời gian nhập vào trùng với một lịch chiếu hiện có (bao gồm khoảng giải lao 30 phút trước và sau)! Vui lòng chọn thời gian khác.",
                                   "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    maskedTextBox2.Clear();
                    maskedTextBox1.Clear();
                    return;
                }

                // Nếu không có xung đột, gán thời gian kết thúc
                maskedTextBox1.Text = endTime.ToString(@"hh\:mm");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra thời gian: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox2.Clear();
                maskedTextBox1.Clear();
            }
        }

        private void maskedTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                maskedTextBox2_Leave(sender, e);
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
                    !maskedTextBox2.MaskFull || !maskedTextBox1.MaskFull)
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

                // Truy vấn lịch chiếu hiện có, loại trừ lịch đang chỉnh sửa
                string query = @"
            SELECT DISTINCT
                FORMAT(s.start_time, 'HH:mm') AS [Start time],
                FORMAT(s.end_time, 'HH:mm') AS [End time]
            FROM SCHEDULE s
            JOIN THEATER t ON s.THEATER_ID = t.ID
            WHERE 
                s.THEATER_ID = @theaterId
                AND CAST(s.START_TIME AS DATE) = @selectedDate
                AND s.id != @scheduleId";

                SqlParameter[] parameters = {
            new SqlParameter("@theaterId", theaterId),
            new SqlParameter("@selectedDate", selectedDate.Date),
            new SqlParameter("@scheduleId", scheduleId)
        };

                DataTable occupiedSchedules = dataAccess.ExecuteQueryWithParams(query, parameters);

                // Debug: Kiểm tra xem lịch hiện tại có bị lọc ra không
                if (occupiedSchedules.Rows.Count > 0)
                {
                    foreach (DataRow row in occupiedSchedules.Rows)
                    {
                        string start = row["Start time"].ToString();
                        string end = row["End time"].ToString();
                        // Nếu cần debug, uncomment dòng dưới để xem danh sách lịch bị cấm
                        // MessageBox.Show($"Occupied: {start} - {end}");
                    }
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
                        ForbiddenStart = selectedDate.Date.Add(slot.Start).AddMinutes(-30),
                        ForbiddenEnd = slot.End > slot.Start
                            ? selectedDate.Date.Add(slot.End).AddMinutes(30)
                            : selectedDate.Date.Add(slot.End).AddMinutes(30).AddDays(1)
                    })
                    .OrderBy(slot => slot.ForbiddenStart)
                    .ToList();

                // Debug: Kiểm tra forbiddenSlots
                if (forbiddenSlots.Any())
                {
                    foreach (var slot in forbiddenSlots)
                    {
                        // Nếu cần debug, uncomment dòng dưới để xem khoảng cấm
                        // MessageBox.Show($"Forbidden: {slot.ForbiddenStart} - {slot.ForbiddenEnd}");
                    }
                }

                // Kiểm tra xung đột
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
                    ResetFil_Click(sender, e);
                    MessageBox.Show("Lịch chiếu mới trùng với một lịch chiếu hiện có (bao gồm khoảng giải lao 30 phút trước và sau)! Vui lòng chọn thời gian khác.",
                                   "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Nếu không có xung đột, thực hiện UPDATE
                string updateQuery = @"
            UPDATE SCHEDULE 
            SET MOVIE_ID = @movieId, 
                THEATER_ID = @theaterId, 
                START_TIME = @startTime, 
                END_TIME = @endTime 
            WHERE id = @scheduleId";

                SqlParameter[] updateParameters = {
            new SqlParameter("@movieId", movieId),
            new SqlParameter("@theaterId", theaterId),
            new SqlParameter("@startTime", startDateTime),
            new SqlParameter("@endTime", endDateTime),
            new SqlParameter("@scheduleId", scheduleId)
        };

                int rowsAffected = dataAccess.ExecuteDMLQueryWithParams(updateQuery, updateParameters);

                // Kiểm tra kết quả
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Sửa lịch chiếu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form sau khi cập nhật thành công
                }
                else
                {
                    MessageBox.Show("Không thể sửa lịch chiếu. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa lịch chiếu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}