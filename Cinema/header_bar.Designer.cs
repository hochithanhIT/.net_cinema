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
            this.lblProfile = new System.Windows.Forms.LinkLabel();
            this.lblMem = new System.Windows.Forms.LinkLabel();
            this.lblPoli = new System.Windows.Forms.LinkLabel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSignOut = new System.Windows.Forms.LinkLabel();
            this.lblSchedule = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblProfile
            // 
            this.lblProfile.AutoSize = true;
            this.lblProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfile.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblProfile.LinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblProfile.Location = new System.Drawing.Point(873, 11);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(109, 29);
            this.lblProfile.TabIndex = 0;
            this.lblProfile.TabStop = true;
            this.lblProfile.Text = "lblProfile";
            this.lblProfile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblProfile_LinkClicked);
            // 
            // lblMem
            // 
            this.lblMem.AutoSize = true;
            this.lblMem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMem.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblMem.LinkColor = System.Drawing.Color.Black;
            this.lblMem.Location = new System.Drawing.Point(300, 10);
            this.lblMem.Name = "lblMem";
            this.lblMem.Size = new System.Drawing.Size(148, 29);
            this.lblMem.TabIndex = 8;
            this.lblMem.TabStop = true;
            this.lblMem.Text = "Membership";
            // 
            // lblPoli
            // 
            this.lblPoli.AutoSize = true;
            this.lblPoli.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoli.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblPoli.LinkColor = System.Drawing.Color.Black;
            this.lblPoli.Location = new System.Drawing.Point(210, 10);
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
            this.lblName.Location = new System.Drawing.Point(10, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(232, 38);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Ticket Booking";
            this.lblName.Click += new System.EventHandler(this.lblName_Click);
            // 
            // lblSignOut
            // 
            this.lblSignOut.AutoSize = true;
            this.lblSignOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignOut.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblSignOut.LinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSignOut.Location = new System.Drawing.Point(956, 11);
            this.lblSignOut.Name = "lblSignOut";
            this.lblSignOut.Size = new System.Drawing.Size(93, 29);
            this.lblSignOut.TabIndex = 9;
            this.lblSignOut.TabStop = true;
            this.lblSignOut.Text = "Log out";
            this.lblSignOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSignOut_LinkClicked);
            // 
            // lblSchedule
            // 
            this.lblSchedule.AutoSize = true;
            this.lblSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchedule.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblSchedule.LinkColor = System.Drawing.Color.Black;
            this.lblSchedule.Location = new System.Drawing.Point(410, 10);
            this.lblSchedule.Name = "lblSchedule";
            this.lblSchedule.Size = new System.Drawing.Size(115, 29);
            this.lblSchedule.TabIndex = 10;
            this.lblSchedule.TabStop = true;
            this.lblSchedule.Text = "Schedule";
            this.lblSchedule.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSchedule_LinkClicked);
            // 
            // header_bar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(180)))));
            this.Controls.Add(this.lblSchedule);
            this.Controls.Add(this.lblSignOut);
            this.Controls.Add(this.lblMem);
            this.Controls.Add(this.lblPoli);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblProfile);
            this.Name = "header_bar";
            this.Size = new System.Drawing.Size(1083, 40);
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
    }
}
