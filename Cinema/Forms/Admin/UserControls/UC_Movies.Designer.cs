namespace Cinema.Admin.UserControls
{
    partial class UC_Movies
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
            this.label1 = new System.Windows.Forms.Label();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.flowLayoutPanelMovies = new System.Windows.Forms.FlowLayoutPanel();
            this.SearchMovies = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "Movies";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.AutoSizeHeightOnly = true;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(32, 436);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(252, 51);
            this.guna2HtmlLabel1.TabIndex = 9;
            this.guna2HtmlLabel1.Text = "Captain America: \r\nBrave New World";
            this.guna2HtmlLabel1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            this.guna2HtmlLabel1.Click += new System.EventHandler(this.guna2HtmlLabel1_Click);
            // 
            // flowLayoutPanelMovies
            // 
            this.flowLayoutPanelMovies.AutoScroll = true;
            this.flowLayoutPanelMovies.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelMovies.Location = new System.Drawing.Point(52, 118);
            this.flowLayoutPanelMovies.Name = "flowLayoutPanelMovies";
            this.flowLayoutPanelMovies.Size = new System.Drawing.Size(1305, 790);
            this.flowLayoutPanelMovies.TabIndex = 3;
            this.flowLayoutPanelMovies.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelMovies_Paint);
            // 
            // SearchMovies
            // 
            this.SearchMovies.BorderColor = System.Drawing.Color.White;
            this.SearchMovies.BorderRadius = 20;
            this.SearchMovies.BorderThickness = 0;
            this.SearchMovies.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SearchMovies.DefaultText = "";
            this.SearchMovies.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.SearchMovies.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.SearchMovies.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SearchMovies.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SearchMovies.FillColor = System.Drawing.Color.WhiteSmoke;
            this.SearchMovies.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SearchMovies.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.SearchMovies.ForeColor = System.Drawing.Color.Black;
            this.SearchMovies.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SearchMovies.IconRight = global::Cinema.Properties.Resources.gsearch;
            this.SearchMovies.IconRightOffset = new System.Drawing.Point(10, 0);
            this.SearchMovies.IconRightSize = new System.Drawing.Size(30, 30);
            this.SearchMovies.Location = new System.Drawing.Point(269, 27);
            this.SearchMovies.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SearchMovies.Name = "SearchMovies";
            this.SearchMovies.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.SearchMovies.PlaceholderText = "Enter movie name...";
            this.SearchMovies.SelectedText = "";
            this.SearchMovies.Size = new System.Drawing.Size(636, 55);
            this.SearchMovies.TabIndex = 5;
            this.SearchMovies.TextChanged += new System.EventHandler(this.SearchMovies_TextChanged);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 20;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Black;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Image = global::Cinema.Properties.Resources.plusico;
            this.guna2Button1.Location = new System.Drawing.Point(990, 24);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.PressedDepth = 60;
            this.guna2Button1.Size = new System.Drawing.Size(242, 58);
            this.guna2Button1.TabIndex = 4;
            this.guna2Button1.Text = "Add New Movies";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // UC_Movies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.SearchMovies);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.flowLayoutPanelMovies);
            this.Controls.Add(this.label1);
            this.Name = "UC_Movies";
            this.Size = new System.Drawing.Size(1360, 1024);
            this.Load += new System.EventHandler(this.UC_Movies_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMovies;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2TextBox SearchMovies;
    }
}
