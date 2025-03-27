using System;
using System.Data;
using System.Data.SqlClient;

namespace Cinema
{
    // Lớp DataAccess để quản lý kết nối và thao tác với cơ sở dữ liệu SQL Server
    internal class DataAccess
    {
        // Biến SqlConnection dùng để quản lý kết nối đến cơ sở dữ liệu
        private SqlConnection sqlcon;
        public SqlConnection Sqlcon
        {
            get { return this.sqlcon; }
            set { this.sqlcon = value; }
        }

        // Biến SqlCommand dùng để thực thi các câu lệnh SQL
        private SqlCommand sqlcom;
        public SqlCommand Sqlcom
        {
            get { return this.sqlcom; }
            set { this.sqlcom = value; }
        }

        // Biến SqlDataAdapter giúp lấy dữ liệu từ database và đổ vào DataSet
        private SqlDataAdapter sda;
        public SqlDataAdapter Sda
        {
            get { return this.sda; }
            set { this.sda = value; }
        }

        // Biến DataSet để lưu trữ dữ liệu lấy từ database
        private DataSet ds;
        public DataSet Ds
        {
            get { return this.ds; }
            set { this.ds = value; }
        }

        // Constructor của lớp, khởi tạo kết nối đến cơ sở dữ liệu
        public DataAccess()
        {
            // Chuỗi kết nối đến SQL Server (Data Source, Database, User ID, Password)
            this.Sqlcon = new SqlConnection(@"Data Source=DESKTOP-JM80VME;Initial Catalog=Cinema;User ID=sa;Password=root;Encrypt=False;TrustServerCertificate=True");

            // Mở kết nối đến database
            Sqlcon.Open();
        }

        // Phương thức nội bộ để tạo SqlCommand với câu lệnh SQL truyền vào
        private void QueryText(string query)
        {
            this.Sqlcom = new SqlCommand(query, this.Sqlcon);
        }

        // Phương thức thực thi truy vấn SELECT và trả về DataSet chứa dữ liệu
        public DataSet ExecuteQuery(string sql)
        {
            this.Sqlcom = new SqlCommand(sql, this.Sqlcon); // Có thể gọi QueryText(sql)
            this.Sda = new SqlDataAdapter(this.Sqlcom);
            this.Ds = new DataSet();
            this.Sda.Fill(this.Ds); // Đổ dữ liệu từ database vào DataSet
            return Ds;
        }

        // Phương thức thực thi truy vấn SELECT và trả về DataTable chứa dữ liệu
        public DataTable ExecuteQueryTable(string sql)
        {
            this.Sqlcom = new SqlCommand(sql, this.Sqlcon); // Có thể gọi QueryText(sql)
            this.Sda = new SqlDataAdapter(this.Sqlcom);
            this.Ds = new DataSet();
            this.Sda.Fill(this.Ds); // Đổ dữ liệu vào DataSet
            return Ds.Tables[0]; // Trả về bảng đầu tiên trong DataSet
        }

        // Phương thức thực thi các câu lệnh INSERT, UPDATE, DELETE (DML)
        public int ExecuteDMLQuery(string sql)
        {
            this.Sqlcom = new SqlCommand(sql, this.Sqlcon); // Có thể gọi QueryText(sql)
            int u = this.Sqlcom.ExecuteNonQuery(); // Thực thi lệnh DML và trả về số dòng bị ảnh hưởng
            return u;
        }

        // Phương thức thực thi truy vấn với tham số
        public DataTable ExecuteQueryWithParams(string sql, SqlParameter[] parameters)
        {
            using (SqlCommand cmd = new SqlCommand(sql, this.Sqlcon))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters); // Thêm các tham số vào truy vấn

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public int ExecuteDMLQueryWithParams(string sql, SqlParameter[] parameters)
        {
            using (SqlCommand cmd = new SqlCommand(sql, this.Sqlcon))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters); // Thêm các tham số vào truy vấn

                int rowsAffected = cmd.ExecuteNonQuery(); // Thực thi lệnh DML và trả về số dòng bị ảnh hưởng
                return rowsAffected;
            }
        }

    }
}