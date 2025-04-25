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
            this.SuspendLayout();
            // 
            // panelDateSelector
            // 
            this.panelDateSelector.AutoScroll = true;
            this.panelDateSelector.Location = new System.Drawing.Point(343, 210);
            this.panelDateSelector.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.panelDateSelector.Name = "panelDateSelector";
            this.panelDateSelector.Size = new System.Drawing.Size(1255, 59);
            this.panelDateSelector.TabIndex = 1;
            // 
            // panelMovies
            // 
            this.panelMovies.AutoScroll = true;
            this.panelMovies.Location = new System.Drawing.Point(343, 333);
            this.panelMovies.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.panelMovies.Name = "panelMovies";
            this.panelMovies.Size = new System.Drawing.Size(1255, 689);
            this.panelMovies.TabIndex = 2;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(894, 101);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(195, 46);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Schedule";
            // 
            // Movie_Schedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.panelMovies);
            this.Controls.Add(this.panelDateSelector);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.Name = "Movie_Schedule";
            this.Text = "Movie Schedule";
            this.Load += new System.EventHandler(this.MovieSchedule_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.FlowLayoutPanel panelDateSelector;
        private System.Windows.Forms.FlowLayoutPanel panelMovies;
    }
}