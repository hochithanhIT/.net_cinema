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
                ForeColor = Color.FromArgb(0, 120, 215),
                AutoSize = true,
                Anchor = AnchorStyles.None
            };
            lblMainTitle.Location = new Point(
                (this.Width - lblMainTitle.Width) / 2,
                20
            );
            this.Controls.Add(lblMainTitle);

            // Policy content container
            Panel contentPanel = new Panel
            {
                Size = new Size(700, 500),
                Location = new Point(50, 80),
                AutoScroll = true,
                BackColor = Color.White
            };

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
                // Section title
                Label lblSection = new Label
                {
                    Text = sections[i],
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    ForeColor = Color.FromArgb(50, 50, 50),
                    AutoSize = true,
                    Location = new Point((contentPanel.Width - TextRenderer.MeasureText(sections[i],
                        new Font("Segoe UI", 14, FontStyle.Bold)).Width) / 2, yPos)
                };
                contentPanel.Controls.Add(lblSection);
                yPos += 40;

                // Policy items
                foreach (string policy in policies[i])
                {
                    Label lblPolicy = new Label
                    {
                        Text = policy,
                        Font = new Font("Segoe UI", 11),
                        ForeColor = Color.FromArgb(70, 70, 70),
                        AutoSize = true,
                        Location = new Point((contentPanel.Width - TextRenderer.MeasureText(policy,
                            new Font("Segoe UI", 11)).Width) / 2, yPos)
                    };
                    contentPanel.Controls.Add(lblPolicy);
                    yPos += 30;
                }

                // Separator (except after last section)
                if (i < sections.Length - 1)
                {
                    Panel separator = new Panel
                    {
                        Size = new Size(500, 1),
                        BackColor = Color.FromArgb(230, 230, 230),
                        Location = new Point((contentPanel.Width - 500) / 2, yPos + 10)
                    };
                    contentPanel.Controls.Add(separator);
                    yPos += 30;
                }
            }

            this.Controls.Add(contentPanel);
        }
    }
}
