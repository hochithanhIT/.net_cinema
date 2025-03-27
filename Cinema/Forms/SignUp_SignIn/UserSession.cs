using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Forms.SignUp_SignIn
{
    public static class UserSession
    {   
        public static int MemberId { get; set; } = -1; // Mặc định là -1 nếu chưa đăng nhập
        public static string FullName { get; set; }
        public static string Email { get; set; }
        public static string Phone { get; set; }
        public static DateTime? Dob { get; set; }
        public static string Spending { get; set; }
        public static string RankName { get; set; }
        public static decimal Discount { get; set; }
        public static int Role { get; set; } = -1;

        // Phương thức để thiết lập thông tin người dùng sau khi đăng nhập
        public static void SetUser(int memberId, string fullName, string email, string phone, DateTime? dob, string spending, string rankName, decimal discount, int role)
        {
            MemberId = memberId;
            FullName = fullName;
            Email = email;
            Phone = phone;
            Dob = dob;
            Spending = spending;
            RankName = rankName;
            Discount = discount;
            Role = role;
        }

        // Phương thức để xóa thông tin người dùng khi đăng xuất
        public static void ClearUser()
        {
            MemberId = -1;
            FullName = null;
            Email = null;
            Phone = null;
            Dob = null;
            Spending = null;
            RankName = null;
            Discount = 0;
            Role = -1;
        }

        // Kiểm tra xem người dùng đã đăng nhập hay chưa
        public static bool IsLoggedIn => MemberId != -1;
    }
}
