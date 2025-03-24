using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    public static class UserSession
    {
        public static bool IsLoggedIn { get; set; } = false;
        public static string Username { get; set; } = string.Empty;
    }
}
