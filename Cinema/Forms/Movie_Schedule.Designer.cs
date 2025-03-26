namespace Cinema.Forms {
    partial class Movie_Schedule {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent() {
            this.panelDateSelector = new System.Windows.Forms.FlowLayoutPanel();
            this.panelMovies = new System.Windows.Forms.FlowLayoutPanel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelDateSelector.SuspendLayout();
            this.panelMovies.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(150, 26);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Lịch Chiếu";
            // 
            // panelDateSelector
            // 
            this.panelDateSelector.AutoScroll = true;
            this.panelDateSelector.Location = new System.Drawing.Point(12, 50);
            this.panelDateSelector.Name = "panelDateSelector";
            this.panelDateSelector.Size = new System.Drawing.Size(1150, 50);
            this.panelDateSelector.TabIndex = 1;
            // 
            // panelMovies
            // 
            this.panelMovies.AutoScroll = true;
            this.panelMovies.Location = new System.Drawing.Point(12, 110);
            this.panelMovies.Name = "panelMovies";
            this.panelMovies.Size = new System.Drawing.Size(1150, 500);
            this.panelMovies.TabIndex = 2;
            // 
            // MovieSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.panelMovies);
            this.Controls.Add(this.panelDateSelector);
            this.Controls.Add(this.labelTitle);
            this.Name = "MovieSchedule";
            this.Text = "Movie Schedule";
            this.Load += new System.EventHandler(this.MovieSchedule_Load);
            this.panelDateSelector.ResumeLayout(false);
            this.panelMovies.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.FlowLayoutPanel panelDateSelector;
        private System.Windows.Forms.FlowLayoutPanel panelMovies;
    }
}