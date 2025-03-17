namespace Cinema
{
    partial class ProfileForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnTransactionHistory = new System.Windows.Forms.Button();
            this.btnMemberRank = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.panelUC = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btnLogOut);
            this.panelMenu.Controls.Add(this.btnTransactionHistory);
            this.panelMenu.Controls.Add(this.btnMemberRank);
            this.panelMenu.Controls.Add(this.btnProfile);
            this.panelMenu.Controls.Add(this.btnHome);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(385, 1175);
            this.panelMenu.TabIndex = 0;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogOut.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOut.Location = new System.Drawing.Point(0, 652);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Padding = new System.Windows.Forms.Padding(21, 0, 0, 0);
            this.btnLogOut.Size = new System.Drawing.Size(385, 163);
            this.btnLogOut.TabIndex = 5;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnTransactionHistory
            // 
            this.btnTransactionHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTransactionHistory.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnTransactionHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactionHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransactionHistory.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTransactionHistory.Location = new System.Drawing.Point(0, 489);
            this.btnTransactionHistory.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnTransactionHistory.Name = "btnTransactionHistory";
            this.btnTransactionHistory.Padding = new System.Windows.Forms.Padding(21, 0, 0, 0);
            this.btnTransactionHistory.Size = new System.Drawing.Size(385, 163);
            this.btnTransactionHistory.TabIndex = 4;
            this.btnTransactionHistory.Text = "Ticket History";
            this.btnTransactionHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransactionHistory.UseVisualStyleBackColor = true;
            this.btnTransactionHistory.Click += new System.EventHandler(this.btnTransactionHistory_Click);
            // 
            // btnMemberRank
            // 
            this.btnMemberRank.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMemberRank.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnMemberRank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemberRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemberRank.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMemberRank.Location = new System.Drawing.Point(0, 326);
            this.btnMemberRank.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnMemberRank.Name = "btnMemberRank";
            this.btnMemberRank.Padding = new System.Windows.Forms.Padding(21, 0, 0, 0);
            this.btnMemberRank.Size = new System.Drawing.Size(385, 163);
            this.btnMemberRank.TabIndex = 3;
            this.btnMemberRank.Text = "Member Rank";
            this.btnMemberRank.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMemberRank.UseVisualStyleBackColor = true;
            this.btnMemberRank.Click += new System.EventHandler(this.btnMemberRank_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProfile.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnProfile.Location = new System.Drawing.Point(0, 163);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Padding = new System.Windows.Forms.Padding(21, 0, 0, 0);
            this.btnProfile.Size = new System.Drawing.Size(385, 163);
            this.btnProfile.TabIndex = 2;
            this.btnProfile.Text = "Profile Details";
            this.btnProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(21, 0, 0, 0);
            this.btnHome.Size = new System.Drawing.Size(385, 163);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // panelUC
            // 
            this.panelUC.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelUC.Location = new System.Drawing.Point(209, 0);
            this.panelUC.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelUC.Name = "panelUC";
            this.panelUC.Size = new System.Drawing.Size(1715, 1175);
            this.panelUC.TabIndex = 1;
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1924, 1175);
            this.Controls.Add(this.panelUC);
            this.Controls.Add(this.panelMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Profile";
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnTransactionHistory;
        private System.Windows.Forms.Button btnMemberRank;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Panel panelUC;
    }
}