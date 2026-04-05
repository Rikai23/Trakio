namespace Trakio
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel_Menu = new System.Windows.Forms.Panel();
            this.btn_Games = new System.Windows.Forms.Button();
            this.btn_Check = new System.Windows.Forms.Button();
            this.btn_Show = new System.Windows.Forms.Button();
            this.btn_Anime = new System.Windows.Forms.Button();
            this.btn_Cartoons = new System.Windows.Forms.Button();
            this.btn_Series = new System.Windows.Forms.Button();
            this.btn_Movies = new System.Windows.Forms.Button();
            this.panel_logo = new System.Windows.Forms.Panel();
            this.btn_Home = new System.Windows.Forms.PictureBox();
            this.panel_TitleBar = new System.Windows.Forms.Panel();
            this.lbl_StatusEthernet = new System.Windows.Forms.Label();
            this.panel_StatusEthernet = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_FullScreen = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.PictureBox();
            this.panel_Content = new System.Windows.Forms.Panel();
            this.panel_Shadow = new System.Windows.Forms.Panel();
            this.btn_My = new System.Windows.Forms.Button();
            this.panel_Menu.SuspendLayout();
            this.panel_logo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Home)).BeginInit();
            this.panel_TitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Exit)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Menu
            // 
            this.panel_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panel_Menu.Controls.Add(this.btn_My);
            this.panel_Menu.Controls.Add(this.btn_Games);
            this.panel_Menu.Controls.Add(this.btn_Check);
            this.panel_Menu.Controls.Add(this.btn_Show);
            this.panel_Menu.Controls.Add(this.btn_Anime);
            this.panel_Menu.Controls.Add(this.btn_Cartoons);
            this.panel_Menu.Controls.Add(this.btn_Series);
            this.panel_Menu.Controls.Add(this.btn_Movies);
            this.panel_Menu.Controls.Add(this.panel_logo);
            this.panel_Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Menu.Location = new System.Drawing.Point(0, 0);
            this.panel_Menu.Name = "panel_Menu";
            this.panel_Menu.Size = new System.Drawing.Size(220, 741);
            this.panel_Menu.TabIndex = 0;
            // 
            // btn_Games
            // 
            this.btn_Games.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Games.FlatAppearance.BorderSize = 0;
            this.btn_Games.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Games.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Games.ForeColor = System.Drawing.Color.White;
            this.btn_Games.Location = new System.Drawing.Point(0, 440);
            this.btn_Games.Name = "btn_Games";
            this.btn_Games.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_Games.Size = new System.Drawing.Size(220, 60);
            this.btn_Games.TabIndex = 7;
            this.btn_Games.Tag = "5";
            this.btn_Games.Text = "Игры";
            this.btn_Games.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Games.UseVisualStyleBackColor = true;
            this.btn_Games.Click += new System.EventHandler(this.btn_OpenCat_Click);
            // 
            // btn_Check
            // 
            this.btn_Check.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Check.FlatAppearance.BorderSize = 0;
            this.btn_Check.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Check.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Check.ForeColor = System.Drawing.Color.White;
            this.btn_Check.Location = new System.Drawing.Point(0, 681);
            this.btn_Check.Name = "btn_Check";
            this.btn_Check.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_Check.Size = new System.Drawing.Size(220, 60);
            this.btn_Check.TabIndex = 6;
            this.btn_Check.Tag = "7";
            this.btn_Check.Text = "Просмотр";
            this.btn_Check.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Check.UseVisualStyleBackColor = true;
            this.btn_Check.Click += new System.EventHandler(this.btn_OpenCat_Click);
            // 
            // btn_Show
            // 
            this.btn_Show.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Show.FlatAppearance.BorderSize = 0;
            this.btn_Show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Show.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Show.ForeColor = System.Drawing.Color.White;
            this.btn_Show.Location = new System.Drawing.Point(0, 380);
            this.btn_Show.Name = "btn_Show";
            this.btn_Show.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_Show.Size = new System.Drawing.Size(220, 60);
            this.btn_Show.TabIndex = 5;
            this.btn_Show.Tag = "4";
            this.btn_Show.Text = "Шоу";
            this.btn_Show.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Show.UseVisualStyleBackColor = true;
            this.btn_Show.Click += new System.EventHandler(this.btn_OpenCat_Click);
            // 
            // btn_Anime
            // 
            this.btn_Anime.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Anime.FlatAppearance.BorderSize = 0;
            this.btn_Anime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Anime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Anime.ForeColor = System.Drawing.Color.White;
            this.btn_Anime.Location = new System.Drawing.Point(0, 320);
            this.btn_Anime.Name = "btn_Anime";
            this.btn_Anime.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_Anime.Size = new System.Drawing.Size(220, 60);
            this.btn_Anime.TabIndex = 4;
            this.btn_Anime.Tag = "3";
            this.btn_Anime.Text = "Аниме";
            this.btn_Anime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Anime.UseVisualStyleBackColor = true;
            this.btn_Anime.Click += new System.EventHandler(this.btn_OpenCat_Click);
            // 
            // btn_Cartoons
            // 
            this.btn_Cartoons.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Cartoons.FlatAppearance.BorderSize = 0;
            this.btn_Cartoons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cartoons.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Cartoons.ForeColor = System.Drawing.Color.White;
            this.btn_Cartoons.Location = new System.Drawing.Point(0, 260);
            this.btn_Cartoons.Name = "btn_Cartoons";
            this.btn_Cartoons.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_Cartoons.Size = new System.Drawing.Size(220, 60);
            this.btn_Cartoons.TabIndex = 3;
            this.btn_Cartoons.Tag = "2";
            this.btn_Cartoons.Text = "Мультфильмы";
            this.btn_Cartoons.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cartoons.UseVisualStyleBackColor = true;
            this.btn_Cartoons.Click += new System.EventHandler(this.btn_OpenCat_Click);
            // 
            // btn_Series
            // 
            this.btn_Series.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Series.FlatAppearance.BorderSize = 0;
            this.btn_Series.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Series.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Series.ForeColor = System.Drawing.Color.White;
            this.btn_Series.Location = new System.Drawing.Point(0, 200);
            this.btn_Series.Name = "btn_Series";
            this.btn_Series.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_Series.Size = new System.Drawing.Size(220, 60);
            this.btn_Series.TabIndex = 2;
            this.btn_Series.Tag = "1";
            this.btn_Series.Text = "Сериалы";
            this.btn_Series.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Series.UseVisualStyleBackColor = true;
            this.btn_Series.Click += new System.EventHandler(this.btn_OpenCat_Click);
            // 
            // btn_Movies
            // 
            this.btn_Movies.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Movies.FlatAppearance.BorderSize = 0;
            this.btn_Movies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Movies.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Movies.ForeColor = System.Drawing.Color.White;
            this.btn_Movies.Location = new System.Drawing.Point(0, 140);
            this.btn_Movies.Name = "btn_Movies";
            this.btn_Movies.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_Movies.Size = new System.Drawing.Size(220, 60);
            this.btn_Movies.TabIndex = 1;
            this.btn_Movies.Tag = "0";
            this.btn_Movies.Text = "Фильмы";
            this.btn_Movies.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Movies.UseVisualStyleBackColor = true;
            this.btn_Movies.Click += new System.EventHandler(this.btn_OpenCat_Click);
            // 
            // panel_logo
            // 
            this.panel_logo.Controls.Add(this.btn_Home);
            this.panel_logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_logo.Location = new System.Drawing.Point(0, 0);
            this.panel_logo.Name = "panel_logo";
            this.panel_logo.Size = new System.Drawing.Size(220, 140);
            this.panel_logo.TabIndex = 0;
            // 
            // btn_Home
            // 
            this.btn_Home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Home.Image = global::Trakio.Properties.Resources.Trakio_logo1;
            this.btn_Home.Location = new System.Drawing.Point(0, 27);
            this.btn_Home.Name = "btn_Home";
            this.btn_Home.Size = new System.Drawing.Size(217, 84);
            this.btn_Home.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_Home.TabIndex = 0;
            this.btn_Home.TabStop = false;
            this.btn_Home.Click += new System.EventHandler(this.btn_Home_Click);
            // 
            // panel_TitleBar
            // 
            this.panel_TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.panel_TitleBar.Controls.Add(this.lbl_StatusEthernet);
            this.panel_TitleBar.Controls.Add(this.panel_StatusEthernet);
            this.panel_TitleBar.Controls.Add(this.lbl_FullScreen);
            this.panel_TitleBar.Controls.Add(this.btn_Exit);
            this.panel_TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_TitleBar.Location = new System.Drawing.Point(220, 0);
            this.panel_TitleBar.Name = "panel_TitleBar";
            this.panel_TitleBar.Size = new System.Drawing.Size(1164, 75);
            this.panel_TitleBar.TabIndex = 1;
            this.panel_TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_TitleBar_MouseDown);
            // 
            // lbl_StatusEthernet
            // 
            this.lbl_StatusEthernet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_StatusEthernet.AutoSize = true;
            this.lbl_StatusEthernet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_StatusEthernet.ForeColor = System.Drawing.Color.White;
            this.lbl_StatusEthernet.Location = new System.Drawing.Point(901, 10);
            this.lbl_StatusEthernet.Name = "lbl_StatusEthernet";
            this.lbl_StatusEthernet.Size = new System.Drawing.Size(174, 18);
            this.lbl_StatusEthernet.TabIndex = 4;
            this.lbl_StatusEthernet.Text = "Проверка соединения...";
            // 
            // panel_StatusEthernet
            // 
            this.panel_StatusEthernet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_StatusEthernet.Location = new System.Drawing.Point(879, 12);
            this.panel_StatusEthernet.Name = "panel_StatusEthernet";
            this.panel_StatusEthernet.Size = new System.Drawing.Size(16, 16);
            this.panel_StatusEthernet.TabIndex = 3;
            // 
            // lbl_FullScreen
            // 
            this.lbl_FullScreen.AutoSize = true;
            this.lbl_FullScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_FullScreen.ForeColor = System.Drawing.Color.White;
            this.lbl_FullScreen.Location = new System.Drawing.Point(6, 30);
            this.lbl_FullScreen.Name = "lbl_FullScreen";
            this.lbl_FullScreen.Size = new System.Drawing.Size(107, 18);
            this.lbl_FullScreen.TabIndex = 1;
            this.lbl_FullScreen.Text = "Во весь экран";
            // 
            // btn_Exit
            // 
            this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Exit.Image = global::Trakio.Properties.Resources.Trakio_exit;
            this.btn_Exit.Location = new System.Drawing.Point(1081, 10);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(71, 57);
            this.btn_Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_Exit.TabIndex = 0;
            this.btn_Exit.TabStop = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // panel_Content
            // 
            this.panel_Content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panel_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Content.Location = new System.Drawing.Point(220, 84);
            this.panel_Content.Name = "panel_Content";
            this.panel_Content.Size = new System.Drawing.Size(1164, 657);
            this.panel_Content.TabIndex = 3;
            // 
            // panel_Shadow
            // 
            this.panel_Shadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(58)))));
            this.panel_Shadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Shadow.Location = new System.Drawing.Point(220, 75);
            this.panel_Shadow.Name = "panel_Shadow";
            this.panel_Shadow.Size = new System.Drawing.Size(1164, 9);
            this.panel_Shadow.TabIndex = 2;
            // 
            // btn_My
            // 
            this.btn_My.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_My.FlatAppearance.BorderSize = 0;
            this.btn_My.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_My.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_My.ForeColor = System.Drawing.Color.White;
            this.btn_My.Location = new System.Drawing.Point(0, 500);
            this.btn_My.Name = "btn_My";
            this.btn_My.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_My.Size = new System.Drawing.Size(220, 60);
            this.btn_My.TabIndex = 8;
            this.btn_My.Tag = "6";
            this.btn_My.Text = "Свое";
            this.btn_My.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_My.UseVisualStyleBackColor = true;
            this.btn_My.Click += new System.EventHandler(this.btn_OpenCat_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 741);
            this.Controls.Add(this.panel_Content);
            this.Controls.Add(this.panel_Shadow);
            this.Controls.Add(this.panel_TitleBar);
            this.Controls.Add(this.panel_Menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trakio";
            this.panel_Menu.ResumeLayout(false);
            this.panel_logo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Home)).EndInit();
            this.panel_TitleBar.ResumeLayout(false);
            this.panel_TitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Exit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Menu;
        private System.Windows.Forms.Button btn_Movies;
        private System.Windows.Forms.Panel panel_logo;
        private System.Windows.Forms.Button btn_Check;
        private System.Windows.Forms.Button btn_Show;
        private System.Windows.Forms.Button btn_Anime;
        private System.Windows.Forms.Button btn_Cartoons;
        private System.Windows.Forms.Button btn_Series;
        private System.Windows.Forms.PictureBox btn_Home;
        private System.Windows.Forms.Panel panel_TitleBar;
        private System.Windows.Forms.PictureBox btn_Exit;
        private System.Windows.Forms.Label lbl_FullScreen;
        private System.Windows.Forms.Panel panel_Content;
        private System.Windows.Forms.Panel panel_Shadow;
        private System.Windows.Forms.Label lbl_StatusEthernet;
        private System.Windows.Forms.FlowLayoutPanel panel_StatusEthernet;
        private System.Windows.Forms.Button btn_Games;
        private System.Windows.Forms.Button btn_My;
    }
}