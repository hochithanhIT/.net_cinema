namespace Cinema.homepage
{
    partial class HomepageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblProfile = new System.Windows.Forms.LinkLabel();
            this.lblMem = new System.Windows.Forms.LinkLabel();
            this.lblPoli = new System.Windows.Forms.LinkLabel();
            this.lblPromo = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblShow = new System.Windows.Forms.LinkLabel();
            this.lblCome = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.flpMovies = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(180)))));
            this.panel1.Controls.Add(this.lblProfile);
            this.panel1.Controls.Add(this.lblMem);
            this.panel1.Controls.Add(this.lblPoli);
            this.panel1.Controls.Add(this.lblPromo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 76);
            this.panel1.TabIndex = 0;
            // 
            // lblProfile
            // 
            this.lblProfile.ActiveLinkColor = System.Drawing.Color.ForestGreen;
            this.lblProfile.AutoSize = true;
            this.lblProfile.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblProfile.LinkColor = System.Drawing.Color.Black;
            this.lblProfile.Location = new System.Drawing.Point(1707, 27);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(123, 29);
            this.lblProfile.TabIndex = 5;
            this.lblProfile.TabStop = true;
            this.lblProfile.Text = "linkLabel1";
            this.lblProfile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblProfile_LinkClicked_1);
            // 
            // lblMem
            // 
            this.lblMem.AutoSize = true;
            this.lblMem.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblMem.LinkColor = System.Drawing.Color.Black;
            this.lblMem.Location = new System.Drawing.Point(748, 28);
            this.lblMem.Name = "lblMem";
            this.lblMem.Size = new System.Drawing.Size(148, 29);
            this.lblMem.TabIndex = 4;
            this.lblMem.TabStop = true;
            this.lblMem.Text = "Membership";
            // 
            // lblPoli
            // 
            this.lblPoli.AutoSize = true;
            this.lblPoli.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblPoli.LinkColor = System.Drawing.Color.Black;
            this.lblPoli.Location = new System.Drawing.Point(585, 28);
            this.lblPoli.Name = "lblPoli";
            this.lblPoli.Size = new System.Drawing.Size(99, 29);
            this.lblPoli.TabIndex = 3;
            this.lblPoli.TabStop = true;
            this.lblPoli.Text = "Policies";
            // 
            // lblPromo
            // 
            this.lblPromo.AutoSize = true;
            this.lblPromo.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblPromo.LinkColor = System.Drawing.Color.Black;
            this.lblPromo.Location = new System.Drawing.Point(390, 28);
            this.lblPromo.Name = "lblPromo";
            this.lblPromo.Size = new System.Drawing.Size(136, 29);
            this.lblPromo.TabIndex = 2;
            this.lblPromo.TabStop = true;
            this.lblPromo.Text = "Promotions";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ticket Booking";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(811, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 51);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ticket Booking";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblShow
            // 
            this.lblShow.ActiveLinkColor = System.Drawing.Color.DimGray;
            this.lblShow.AutoSize = true;
            this.lblShow.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblShow.LinkColor = System.Drawing.Color.Black;
            this.lblShow.Location = new System.Drawing.Point(457, 247);
            this.lblShow.Name = "lblShow";
            this.lblShow.Size = new System.Drawing.Size(158, 29);
            this.lblShow.TabIndex = 6;
            this.lblShow.TabStop = true;
            this.lblShow.Text = "Showing now";
            this.lblShow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblShow_LinkClicked);
            // 
            // lblCome
            // 
            this.lblCome.ActiveLinkColor = System.Drawing.Color.DimGray;
            this.lblCome.AutoSize = true;
            this.lblCome.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblCome.LinkColor = System.Drawing.Color.Black;
            this.lblCome.Location = new System.Drawing.Point(705, 247);
            this.lblCome.Name = "lblCome";
            this.lblCome.Size = new System.Drawing.Size(160, 29);
            this.lblCome.TabIndex = 7;
            this.lblCome.TabStop = true;
            this.lblCome.Text = "Coming Soon";
            this.lblCome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCome_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(197, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 36);
            this.label3.TabIndex = 5;
            this.label3.Text = "| Movies";
            // 
            // flpMovies
            // 
            this.flpMovies.AutoScroll = true;
            this.flpMovies.Location = new System.Drawing.Point(216, 364);
            this.flpMovies.Name = "flpMovies";
            this.flpMovies.Size = new System.Drawing.Size(1476, 629);
            this.flpMovies.TabIndex = 9;
            // 
            // HomepageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.flpMovies);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCome);
            this.Controls.Add(this.lblShow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "HomepageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomepageForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lblMem;
        private System.Windows.Forms.LinkLabel lblPoli;
        private System.Windows.Forms.LinkLabel lblPromo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lblShow;
        private System.Windows.Forms.LinkLabel lblCome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flpMovies;
        private System.Windows.Forms.LinkLabel lblProfile;
    }
}