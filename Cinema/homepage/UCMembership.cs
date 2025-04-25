using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cinema.Forms.profile;
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

            // Title label
            Label lblTitle = new Label
            {
                Text = "MEMBERSHIP BENEFITS",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 120, 215),
                AutoSize = true,
                Location = new Point(20, 20)
            };
            this.Controls.Add(lblTitle);

            // Current membership status
            Panel statusPanel = new Panel
            {
                Size = new Size(760, 60),
                Location = new Point(20, 70),
                BackColor = Color.FromArgb(240, 248, 255),
                BorderStyle = BorderStyle.FixedSingle
            };

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
                Size = new Size(760, 400),
                Location = new Point(20, 150),
                AutoScroll = true
            };

            string[] benefits = new string[]
            {
                "1. BRONZE TIER (0-1,000,000 VND spending):",
                "   • 5% discount on all tickets",
                "   • Access to standard screenings",
                "",
                "2. SILVER TIER (1,000,000-3,000,000 VND spending):",
                "   • 10% discount on tickets",
                "   • Priority booking for special events",
                "",
                "3. GOLD TIER (3,000,000-10,000,000 VND spending):",
                "   • 15% discount on tickets and snacks",
                "   • Free upgrades to premium seats (when available)",
                "",
                "4. PLATINUM TIER (10,000,000+ VND spending):",
                "   • 20% discount on all purchases",
                "   • Exclusive invites to premieres",
                "   • Personal concierge service"
            };

            int yPos = 20;
            foreach (string line in benefits)
            {
                Label lblLine = new Label
                {
                    Text = line,
                    Font = new Font("Segoe UI", line.StartsWith(" ") ? 10 : 11,
                                 line.StartsWith(" ") ? FontStyle.Regular : FontStyle.Bold),
                    ForeColor = Color.FromArgb(70, 70, 70),
                    AutoSize = true,
                    Location = new Point(20, yPos)
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
                AutoSize = true,
                Location = new Point(20, yPos + 20)
            };
            contentPanel.Controls.Add(lblUpgrade);

            this.Controls.Add(contentPanel);
        }
    }
}

