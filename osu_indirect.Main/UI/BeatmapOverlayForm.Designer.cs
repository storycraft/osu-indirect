using System.Drawing;

namespace osu_indirect.Main.UI
{
    partial class BeatmapOverlayForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.browserButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.buttonPanel3 = new System.Windows.Forms.Panel();
            this.buttonPanel2 = new System.Windows.Forms.Panel();
            this.buttonPanel1 = new System.Windows.Forms.Panel();
            this.idText = new System.Windows.Forms.Label();
            this.titleText = new System.Windows.Forms.Label();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.overlayPanel = new System.Windows.Forms.Panel();
            this.menuPanel.SuspendLayout();
            this.buttonPanel3.SuspendLayout();
            this.buttonPanel2.SuspendLayout();
            this.buttonPanel1.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.overlayPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(245)))), ((int)(((byte)(124)))), ((int)(((byte)(0)))));
            this.cancelButton.FlatAppearance.BorderSize = 3;
            this.cancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(245)))), ((int)(((byte)(124)))), ((int)(((byte)(0)))));
            this.cancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("맑은 고딕 Semilight", 18F);
            this.cancelButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cancelButton.Location = new System.Drawing.Point(0, 8);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(10);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(1180, 75);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // browserButton
            // 
            this.browserButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(139)))), ((int)(((byte)(195)))), ((int)(((byte)(74)))));
            this.browserButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(104)))), ((int)(((byte)(159)))), ((int)(((byte)(56)))));
            this.browserButton.FlatAppearance.BorderSize = 3;
            this.browserButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(104)))), ((int)(((byte)(159)))), ((int)(((byte)(56)))));
            this.browserButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(139)))), ((int)(((byte)(195)))), ((int)(((byte)(74)))));
            this.browserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browserButton.Font = new System.Drawing.Font("맑은 고딕 Semilight", 18F);
            this.browserButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.browserButton.Location = new System.Drawing.Point(0, 8);
            this.browserButton.Margin = new System.Windows.Forms.Padding(10);
            this.browserButton.Name = "browserButton";
            this.browserButton.Size = new System.Drawing.Size(1180, 75);
            this.browserButton.TabIndex = 1;
            this.browserButton.Text = "Open with Browser";
            this.browserButton.UseVisualStyleBackColor = false;
            this.browserButton.Click += new System.EventHandler(this.browserButton_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(139)))), ((int)(((byte)(195)))), ((int)(((byte)(74)))));
            this.downloadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downloadButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(104)))), ((int)(((byte)(159)))), ((int)(((byte)(56)))));
            this.downloadButton.FlatAppearance.BorderSize = 3;
            this.downloadButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(104)))), ((int)(((byte)(159)))), ((int)(((byte)(56)))));
            this.downloadButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(139)))), ((int)(((byte)(195)))), ((int)(((byte)(74)))));
            this.downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadButton.Font = new System.Drawing.Font("맑은 고딕 Semilight", 18F);
            this.downloadButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.downloadButton.Location = new System.Drawing.Point(0, 8);
            this.downloadButton.Margin = new System.Windows.Forms.Padding(10);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(1180, 75);
            this.downloadButton.TabIndex = 2;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = false;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.Transparent;
            this.menuPanel.Controls.Add(this.buttonPanel3);
            this.menuPanel.Controls.Add(this.buttonPanel2);
            this.menuPanel.Controls.Add(this.buttonPanel1);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuPanel.Location = new System.Drawing.Point(0, 254);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Padding = new System.Windows.Forms.Padding(50, 0, 50, 100);
            this.menuPanel.Size = new System.Drawing.Size(1280, 466);
            this.menuPanel.TabIndex = 1;
            // 
            // buttonPanel3
            // 
            this.buttonPanel3.Controls.Add(this.downloadButton);
            this.buttonPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel3.Location = new System.Drawing.Point(50, 93);
            this.buttonPanel3.Name = "buttonPanel3";
            this.buttonPanel3.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.buttonPanel3.Size = new System.Drawing.Size(1180, 91);
            this.buttonPanel3.TabIndex = 3;
            // 
            // buttonPanel2
            // 
            this.buttonPanel2.Controls.Add(this.browserButton);
            this.buttonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel2.Location = new System.Drawing.Point(50, 184);
            this.buttonPanel2.Name = "buttonPanel2";
            this.buttonPanel2.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.buttonPanel2.Size = new System.Drawing.Size(1180, 91);
            this.buttonPanel2.TabIndex = 3;
            // 
            // buttonPanel1
            // 
            this.buttonPanel1.Controls.Add(this.cancelButton);
            this.buttonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel1.Location = new System.Drawing.Point(50, 275);
            this.buttonPanel1.Name = "buttonPanel1";
            this.buttonPanel1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.buttonPanel1.Size = new System.Drawing.Size(1180, 91);
            this.buttonPanel1.TabIndex = 3;
            // 
            // idText
            // 
            this.idText.AutoSize = true;
            this.idText.BackColor = System.Drawing.Color.Transparent;
            this.idText.Dock = System.Windows.Forms.DockStyle.Top;
            this.idText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idText.Font = new System.Drawing.Font("맑은 고딕 Semilight", 17.5F);
            this.idText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.idText.Location = new System.Drawing.Point(10, 10);
            this.idText.Name = "idText";
            this.idText.Size = new System.Drawing.Size(136, 32);
            this.idText.TabIndex = 2;
            this.idText.Text = "beatmap Id";
            this.idText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // titleText
            // 
            this.titleText.AutoEllipsis = true;
            this.titleText.AutoSize = true;
            this.titleText.BackColor = System.Drawing.Color.Transparent;
            this.titleText.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.titleText.Font = new System.Drawing.Font("맑은 고딕 Semilight", 38F);
            this.titleText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.titleText.Location = new System.Drawing.Point(10, 42);
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(333, 68);
            this.titleText.TabIndex = 2;
            this.titleText.Text = "Beatmap Title";
            this.titleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.titleText.Click += new System.EventHandler(this.titleText_Click);
            // 
            // infoPanel
            // 
            this.infoPanel.BackColor = System.Drawing.Color.Transparent;
            this.infoPanel.Controls.Add(this.titleText);
            this.infoPanel.Controls.Add(this.idText);
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoPanel.Location = new System.Drawing.Point(0, 0);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 20);
            this.infoPanel.Size = new System.Drawing.Size(1280, 255);
            this.infoPanel.TabIndex = 3;
            // 
            // overlayPanel
            // 
            this.overlayPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.overlayPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.overlayPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.overlayPanel.Controls.Add(this.menuPanel);
            this.overlayPanel.Controls.Add(this.infoPanel);
            this.overlayPanel.Location = new System.Drawing.Point(320, 180);
            this.overlayPanel.Name = "overlayPanel";
            this.overlayPanel.Size = new System.Drawing.Size(1280, 720);
            this.overlayPanel.TabIndex = 3;
            // 
            // BeatmapOverlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1980, 1080);
            this.Controls.Add(this.overlayPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BeatmapOverlayForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OverlayForm";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.Load += new System.EventHandler(this.OverlayForm_Load);
            this.menuPanel.ResumeLayout(false);
            this.buttonPanel3.ResumeLayout(false);
            this.buttonPanel2.ResumeLayout(false);
            this.buttonPanel1.ResumeLayout(false);
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.overlayPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button browserButton;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Label idText;
        private System.Windows.Forms.Label titleText;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Panel overlayPanel;
        private System.Windows.Forms.Panel buttonPanel3;
        private System.Windows.Forms.Panel buttonPanel2;
        private System.Windows.Forms.Panel buttonPanel1;
    }
}