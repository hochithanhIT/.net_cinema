using System;
using System.Drawing;
using System.Windows.Forms;
using Cinema.Forms.SignUp_SignIn;

namespace Cinema.homepage
{
    public partial class UCMembership : UserControl
    {
        private ProfileForm ProfileForm;

        public UCMembership(ProfileForm profileForm)
        {
            InitializeComponent();
            this.ProfileForm = profileForm;
            SetupUI();
        }

        private void SetupUI()
        {
            // Main control setup
            this.Size = new Size(800, 600);
            this.BackColor = Color.White;
            this.Padding = new Padding(20);

            // Main title - "Membership" (bên dưới header bar)
            Label lblMainTitle = new Label
            {
                Text = "MEMBERSHIP",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 120, 215), // Màu xanh dương giống giao diện
                AutoSize = true
            };
            // Căn giữa tiêu đề chính
            lblMainTitle.Location = new Point(
                (this.ClientSize.Width - lblMainTitle.Width) / 2,
                60
            );
            this.Controls.Add(lblMainTitle);

            // Current membership status
            Panel statusPanel = new Panel
            {
                Size = new Size(600, 60), // Thu hẹp chiều rộng để căn giữa
                BackColor = Color.FromArgb(240, 248, 255),
                BorderStyle = BorderStyle.FixedSingle
            };
            // Căn giữa statusPanel
            statusPanel.Location = new Point(
                (this.ClientSize.Width - statusPanel.Width) / 2,
                100
            );

            Label lblStatus = new Label
            {
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 50, 50),
                AutoSize = true,
                Location = new Point(20, 20)
            };

            if (UserSession.IsLoggedIn)
            {
                lblStatus.Text = $"Your Current Membership: {UserSession.RankName} ({UserSession.Discount:P0} Discount)";
            }
            else
            {
                lblStatus.Text = "Please log in to view your membership status";
            }

            statusPanel.Controls.Add(lblStatus);
            this.Controls.Add(statusPanel);

            // Membership benefits content
            Panel contentPanel = new Panel
            {
                Size = new Size(1000, 400), // Thu hẹp chiều rộng để căn giữa
                AutoScroll = true,
                BackColor = Color.White
            };
            // Căn giữa contentPanel
            contentPanel.Location = new Point(
                (this.ClientSize.Width - contentPanel.Width) / 2,
                150
            );

            string[] benefits = new string[]
            {
                "1. BRONZE TIER (0-1,000,000 VND spending):",
                "• 5% discount on all tickets",
                "• Access to standard screenings",
                "",
                "2. SILVER TIER (1,000,000-3,000,000 VND spending):",
                "• 10% discount on tickets",
                "• Priority booking for special events",
                "",
                "3. GOLD TIER (3,000,000-10,000,000 VND spending):",
                "• 15% discount on tickets and snacks",
                "• Free upgrades to premium seats (when available)",
                "",
                "4. PLATINUM TIER (10,000,000+ VND spending):",
                "• 20% discount on all purchases",
                "• Exclusive invites to premieres",
                "• Personal concierge service"
            };

            int yPos = 20;
            foreach (string line in benefits)
            {
                Label lblLine = new Label
                {
                    Text = line,
                    Font = new Font("Segoe UI", line.StartsWith("•") ? 10 : 11,
                                 line.StartsWith("•") ? FontStyle.Regular : FontStyle.Bold),
                    ForeColor = Color.FromArgb(70, 70, 70),
                    AutoSize = true,
                    Location = new Point(20, yPos) // Căn trái trong contentPanel
                };
                contentPanel.Controls.Add(lblLine);
                yPos += 25;
            }

            // Upgrade notice
            Label lblUpgrade = new Label
            {
                Text = "Upgrade your membership by booking more tickets!",
                Font = new Font("Segoe UI", 11, FontStyle.Italic),
                ForeColor = Color.FromArgb(0, 120, 215),
                AutoSize = true
            };
            // Căn giữa lblUpgrade
            lblUpgrade.Location = new Point(
                (this.ClientSize.Width - lblUpgrade.Width) / 2,
                560
            );

            this.Controls.Add(contentPanel);
            this.Controls.Add(lblUpgrade);

            // Đảm bảo các thành phần luôn căn giữa khi form thay đổi kích thước
            this.SizeChanged += (s, e) =>
            {
                lblMainTitle.Location = new Point(
                    (this.ClientSize.Width - lblMainTitle.Width) / 2,
                    20
                );
                statusPanel.Location = new Point(
                    (this.ClientSize.Width - statusPanel.Width) / 2,
                    80
                );
                contentPanel.Location = new Point(
                    (this.ClientSize.Width - contentPanel.Width) / 2,
                    150
                );
                lblUpgrade.Location = new Point(
                    (this.ClientSize.Width - lblUpgrade.Width) / 2,
                    560
                );
            };
        }
    }
}