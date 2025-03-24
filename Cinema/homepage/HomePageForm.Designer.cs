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
            this.lblMem = new System.Windows.Forms.LinkLabel();
            this.lblPoli = new System.Windows.Forms.LinkLabel();
            this.lblPromo = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
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
            this.panel1.Controls.Add(this.lblMem);
            this.panel1.Controls.Add(this.lblPoli);
            this.panel1.Controls.Add(this.lblPromo);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1787, 68);
            this.panel1.TabIndex = 0;
            // 
            // lblMem
            // 
            this.lblMem.AutoSize = true;
            this.lblMem.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblMem.LinkColor = System.Drawing.Color.Black;
            this.lblMem.Location = new System.Drawing.Point(695, 25);
            this.lblMem.Name = "lblMem";
            this.lblMem.Size = new System.Drawing.Size(132, 26);
            this.lblMem.TabIndex = 4;
            this.lblMem.TabStop = true;
            this.lblMem.Text = "Membership";
            // 
            // lblPoli
            // 
            this.lblPoli.AutoSize = true;
            this.lblPoli.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblPoli.LinkColor = System.Drawing.Color.Black;
            this.lblPoli.Location = new System.Drawing.Point(543, 25);
            this.lblPoli.Name = "lblPoli";
            this.lblPoli.Size = new System.Drawing.Size(88, 26);
            this.lblPoli.TabIndex = 3;
            this.lblPoli.TabStop = true;
            this.lblPoli.Text = "Policies";
            // 
            // lblPromo
            // 
            this.lblPromo.AutoSize = true;
            this.lblPromo.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblPromo.LinkColor = System.Drawing.Color.Black;
            this.lblPromo.Location = new System.Drawing.Point(362, 25);
            this.lblPromo.Name = "lblPromo";
            this.lblPromo.Size = new System.Drawing.Size(123, 26);
            this.lblPromo.TabIndex = 2;
            this.lblPromo.TabStop = true;
            this.lblPromo.Text = "Promotions";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(1627, 23);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(65, 26);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Login";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
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
            this.label2.Location = new System.Drawing.Point(753, 96);
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
            this.lblShow.Location = new System.Drawing.Point(424, 265);
            this.lblShow.Name = "lblShow";
            this.lblShow.Size = new System.Drawing.Size(142, 26);
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
            this.lblCome.Location = new System.Drawing.Point(655, 265);
            this.lblCome.Name = "lblCome";
            this.lblCome.Size = new System.Drawing.Size(145, 26);
            this.lblCome.TabIndex = 7;
            this.lblCome.TabStop = true;
            this.lblCome.Text = "Coming Soon";
            this.lblCome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCome_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(183, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 36);
            this.label3.TabIndex = 5;
            this.label3.Text = "| Movies";
            // 
            // flpMovies
            // 
            this.flpMovies.AutoScroll = true;
            this.flpMovies.Location = new System.Drawing.Point(201, 370);
            this.flpMovies.Name = "flpMovies";
            this.flpMovies.Size = new System.Drawing.Size(1371, 564);
            this.flpMovies.TabIndex = 9;
            // 
            // HomepageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1787, 946);
            this.Controls.Add(this.flpMovies);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCome);
            this.Controls.Add(this.lblShow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "HomepageForm";
            this.Text = "HomepageForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lblMem;
        private System.Windows.Forms.LinkLabel lblPoli;
        private System.Windows.Forms.LinkLabel lblPromo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lblShow;
        private System.Windows.Forms.LinkLabel lblCome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flpMovies;
    }
}