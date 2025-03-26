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
            this.label2 = new System.Windows.Forms.Label();
            this.lblShow = new System.Windows.Forms.LinkLabel();
            this.lblCome = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.flpMovies = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "HomepageForm";
            this.Text = "HomepageForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lblShow;
        private System.Windows.Forms.LinkLabel lblCome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flpMovies;
    }
}