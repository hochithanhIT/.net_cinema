using System;
using System.Drawing;
using System.Windows.Forms;
using Cinema.Forms.profile;

namespace Cinema.homepage
{
    public partial class UCPolicies : UserControl
    {
        private ProfileForm ProfileForm;

        public UCPolicies(ProfileForm profileForm)
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

            // Main title - "Our Policies"
            Label lblMainTitle = new Label
            {
                Text = "OUR POLICIES",
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

            // Policy content container
            Panel contentPanel = new Panel
            {
                Size = new Size(500, 500), // Thu hẹp chiều rộng để dễ căn giữa
                AutoScroll = true,
                BackColor = Color.White
            };
            // Căn giữa contentPanel trong form
            contentPanel.Location = new Point(
                (this.ClientSize.Width - contentPanel.Width) / 2,
                100
            );

            // Policy sections
            string[] sections = new string[]
            {
                "TICKET PURCHASE",
                "ARRIVAL & ADMISSION",
                "FOOD & BEVERAGES",
                "THEATER ETIQUETTE"
            };

            string[][] policies = new string[][]
            {
                new string[] {
                    "• All ticket sales are final",
                    "• No refunds or exchanges unless the show is canceled",
                    "• Valid ID required for student/senior discounts"
                },
                new string[] {
                    "• Please arrive at least 15 minutes before showtime",
                    "• Latecomers may not be admitted",
                    "• Tickets must be presented for scanning"
                },
                new string[] {
                    "• Outside food and drinks are prohibited",
                    "• Concessions available in lobby",
                    "• No alcohol permitted"
                },
                new string[] {
                    "• Silence mobile devices during the movie",
                    "• No talking during the performance",
                    "• Disruptive behavior may result in removal"
                }
            };

            int yPos = 20;
            for (int i = 0; i < sections.Length; i++)
            {
                // Section title (căn trái)
                Label lblSection = new Label
                {
                    Text = sections[i],
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    ForeColor = Color.FromArgb(50, 50, 50),
                    AutoSize = true,
                    Location = new Point(20, yPos) // Căn trái trong contentPanel
                };
                contentPanel.Controls.Add(lblSection);
                yPos += 40;

                // Policy items (căn trái)
                foreach (string policy in policies[i])
                {
                    Label lblPolicy = new Label
                    {
                        Text = policy,
                        Font = new Font("Segoe UI", 11),
                        ForeColor = Color.FromArgb(70, 70, 70),
                        AutoSize = true,
                        Location = new Point(20, yPos) // Căn trái trong contentPanel
                    };
                    contentPanel.Controls.Add(lblPolicy);
                    yPos += 30;
                }

                // Separator (căn giữa trong contentPanel)
                if (i < sections.Length - 1)
                {
                    Panel separator = new Panel
                    {
                        Size = new Size(460, 1),
                        BackColor = Color.FromArgb(230, 230, 230),
                        Location = new Point(20, yPos + 10) // Căn trái nhưng chiều dài gần bằng contentPanel
                    };
                    contentPanel.Controls.Add(separator);
                    yPos += 30;
                }
            }

            this.Controls.Add(contentPanel);

            //// Đảm bảo tiêu đề chính luôn căn giữa khi form thay đổi kích thước
            //this.SizeChanged += (s, e) =>
            //{
            //    lblMainTitle.Location = new Point(
            //        (this.ClientSize.Width - lblMainTitle.Width) / 2,
            //        20
            //    );
            //    contentPanel.Location = new Point(
            //        (this.ClientSize.Width - contentPanel.Width) / 2,
            //        80
            //    );
            //};
        }
    }
}