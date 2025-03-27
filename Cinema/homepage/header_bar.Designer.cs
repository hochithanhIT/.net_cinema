namespace Cinema
{
    partial class header_bar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(header_bar));
            this.lblProfile = new System.Windows.Forms.LinkLabel();
            this.lblMem = new System.Windows.Forms.LinkLabel();
            this.lblPoli = new System.Windows.Forms.LinkLabel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSignOut = new System.Windows.Forms.LinkLabel();
            this.lblSchedule = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProfile
            // 
            this.lblProfile.ActiveLinkColor = System.Drawing.Color.ForestGreen;
            this.lblProfile.AutoSize = true;
            this.lblProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfile.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblProfile.LinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblProfile.Location = new System.Drawing.Point(1528, 24);
            this.lblProfile.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(109, 29);
            this.lblProfile.TabIndex = 0;
            this.lblProfile.TabStop = true;
            this.lblProfile.Text = "lblProfile";
            this.lblProfile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblProfile_LinkClicked);
            // 
            // lblMem
            // 
            this.lblMem.ActiveLinkColor = System.Drawing.Color.ForestGreen;
            this.lblMem.AutoSize = true;
            this.lblMem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMem.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblMem.LinkColor = System.Drawing.Color.Black;
            this.lblMem.Location = new System.Drawing.Point(525, 23);
            this.lblMem.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMem.Name = "lblMem";
            this.lblMem.Size = new System.Drawing.Size(148, 29);
            this.lblMem.TabIndex = 8;
            this.lblMem.TabStop = true;
            this.lblMem.Text = "Membership";
            // 
            // lblPoli
            // 
            this.lblPoli.ActiveLinkColor = System.Drawing.Color.ForestGreen;
            this.lblPoli.AutoSize = true;
            this.lblPoli.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoli.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblPoli.LinkColor = System.Drawing.Color.Black;
            this.lblPoli.Location = new System.Drawing.Point(368, 24);
            this.lblPoli.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPoli.Name = "lblPoli";
            this.lblPoli.Size = new System.Drawing.Size(99, 29);
            this.lblPoli.TabIndex = 7;
            this.lblPoli.TabStop = true;
            this.lblPoli.Text = "Policies";
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(18, 18);
            this.lblName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(232, 38);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Ticket Booking";
            this.lblName.Click += new System.EventHandler(this.lblName_Click);
            // 
            // lblSignOut
            // 
            this.lblSignOut.ActiveLinkColor = System.Drawing.Color.ForestGreen;
            this.lblSignOut.AutoSize = true;
            this.lblSignOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignOut.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblSignOut.LinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSignOut.Location = new System.Drawing.Point(1673, 24);
            this.lblSignOut.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSignOut.Name = "lblSignOut";
            this.lblSignOut.Size = new System.Drawing.Size(93, 29);
            this.lblSignOut.TabIndex = 9;
            this.lblSignOut.TabStop = true;
            this.lblSignOut.Text = "Log out";
            this.lblSignOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSignOut_LinkClicked);
            // 
            // lblSchedule
            // 
            this.lblSchedule.ActiveLinkColor = System.Drawing.Color.ForestGreen;
            this.lblSchedule.AutoSize = true;
            this.lblSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchedule.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblSchedule.LinkColor = System.Drawing.Color.Black;
            this.lblSchedule.Location = new System.Drawing.Point(718, 22);
            this.lblSchedule.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSchedule.Name = "lblSchedule";
            this.lblSchedule.Size = new System.Drawing.Size(115, 29);
            this.lblSchedule.TabIndex = 10;
            this.lblSchedule.TabStop = true;
            this.lblSchedule.Text = "Schedule";
            this.lblSchedule.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSchedule_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1652, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1496, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // header_bar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(180)))));
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblSchedule);
            this.Controls.Add(this.lblSignOut);
            this.Controls.Add(this.lblMem);
            this.Controls.Add(this.lblPoli);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblProfile);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "header_bar";
            this.Size = new System.Drawing.Size(1895, 72);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblProfile;
        private System.Windows.Forms.LinkLabel lblMem;
        private System.Windows.Forms.LinkLabel lblPoli;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.LinkLabel lblSignOut;
        private System.Windows.Forms.LinkLabel lblSchedule;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
