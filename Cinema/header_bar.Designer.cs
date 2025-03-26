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
            this.lblPromo = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSignOut = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblProfile
            // 
            this.lblProfile.AutoSize = true;
            this.lblProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfile.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblProfile.LinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblProfile.Location = new System.Drawing.Point(867, 26);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(109, 29);
            this.lblProfile.TabIndex = 0;
            this.lblProfile.TabStop = true;
            this.lblProfile.Text = "lblProfile";
            // 
            // lblMem
            // 
            this.lblMem.AutoSize = true;
            this.lblMem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMem.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblMem.LinkColor = System.Drawing.Color.Black;
            this.lblMem.Location = new System.Drawing.Point(628, 26);
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
            this.lblPoli.Location = new System.Drawing.Point(493, 26);
            this.lblPoli.Name = "lblPoli";
            this.lblPoli.Size = new System.Drawing.Size(99, 29);
            this.lblPoli.TabIndex = 7;
            this.lblPoli.TabStop = true;
            this.lblPoli.Text = "Policies";
            // 
            // lblPromo
            // 
            this.lblPromo.AutoSize = true;
            this.lblPromo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPromo.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblPromo.LinkColor = System.Drawing.Color.Black;
            this.lblPromo.Location = new System.Drawing.Point(299, 26);
            this.lblPromo.Name = "lblPromo";
            this.lblPromo.Size = new System.Drawing.Size(136, 29);
            this.lblPromo.TabIndex = 6;
            this.lblPromo.TabStop = true;
            this.lblPromo.Text = "Promotions";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 38);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ticket Booking";
            // 
            // lblSignOut
            // 
            this.lblSignOut.AutoSize = true;
            this.lblSignOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignOut.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblSignOut.LinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSignOut.Location = new System.Drawing.Point(1040, 30);
            this.lblSignOut.Name = "lblSignOut";
            this.lblSignOut.Size = new System.Drawing.Size(93, 29);
            this.lblSignOut.TabIndex = 9;
            this.lblSignOut.TabStop = true;
            this.lblSignOut.Text = "Log out";
            // 
            // header_bar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(180)))));
            this.Controls.Add(this.lblSignOut);
            this.Controls.Add(this.lblMem);
            this.Controls.Add(this.lblPoli);
            this.Controls.Add(this.lblPromo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblProfile);
            this.Name = "header_bar";
            this.Size = new System.Drawing.Size(1523, 59);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblProfile;
        private System.Windows.Forms.LinkLabel lblMem;
        private System.Windows.Forms.LinkLabel lblPoli;
        private System.Windows.Forms.LinkLabel lblPromo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lblSignOut;
    }
}
