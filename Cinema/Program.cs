using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    static class Program
    {
        // Import API để bật DPI Awareness
        [DllImport("shcore.dll")]
        private static extern int SetProcessDpiAwareness(int awareness);

        [STAThread]
        static void Main()
        {
            try
            {
                // Bật chế độ DPI cao (PerMonitorV2)
                SetProcessDpiAwareness(2);
            }
            catch (Exception)
            {
                // Nếu không hỗ trợ, bỏ qua lỗi
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Cinema.Admin.AdminPage());
        }
    }
}
