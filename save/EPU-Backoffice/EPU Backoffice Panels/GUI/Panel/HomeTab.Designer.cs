namespace EPUBackofficePanels.Gui.Panel
{
    partial class HomeTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeTab));
            this.currentlyOpenedDbPanel = new System.Windows.Forms.Panel();
            this.homeCurrentDBLabel = new System.Windows.Forms.Label();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.homeOpenNewDbButton = new System.Windows.Forms.Button();
            this.la_homeTextCurrent = new System.Windows.Forms.Label();
            this.currentlyOpenedDbPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // currentlyOpenedDbPanel
            // 
            this.currentlyOpenedDbPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.currentlyOpenedDbPanel.Controls.Add(this.homeCurrentDBLabel);
            this.currentlyOpenedDbPanel.Location = new System.Drawing.Point(506, 86);
            this.currentlyOpenedDbPanel.Name = "currentlyOpenedDbPanel";
            this.currentlyOpenedDbPanel.Size = new System.Drawing.Size(234, 23);
            this.currentlyOpenedDbPanel.TabIndex = 8;
            // 
            // homeCurrentDBLabel
            // 
            this.homeCurrentDBLabel.AccessibleName = "homeCurrentDBLabel";
            this.homeCurrentDBLabel.AutoSize = true;
            this.homeCurrentDBLabel.Location = new System.Drawing.Point(3, 3);
            this.homeCurrentDBLabel.Name = "homeCurrentDBLabel";
            this.homeCurrentDBLabel.Size = new System.Drawing.Size(31, 13);
            this.homeCurrentDBLabel.TabIndex = 3;
            this.homeCurrentDBLabel.Text = "*null*";
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(48, 57);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(264, 149);
            this.logoPictureBox.TabIndex = 5;
            this.logoPictureBox.TabStop = false;
            // 
            // homeOpenNewDbButton
            // 
            this.homeOpenNewDbButton.Location = new System.Drawing.Point(514, 115);
            this.homeOpenNewDbButton.Name = "homeOpenNewDbButton";
            this.homeOpenNewDbButton.Size = new System.Drawing.Size(193, 23);
            this.homeOpenNewDbButton.TabIndex = 7;
            this.homeOpenNewDbButton.Text = "Datenbank auswählen";
            this.homeOpenNewDbButton.UseVisualStyleBackColor = true;
            this.homeOpenNewDbButton.Click += new System.EventHandler(this.homeOpenNewDbButton_Click);
            // 
            // la_homeTextCurrent
            // 
            this.la_homeTextCurrent.AutoSize = true;
            this.la_homeTextCurrent.Location = new System.Drawing.Point(353, 91);
            this.la_homeTextCurrent.Name = "la_homeTextCurrent";
            this.la_homeTextCurrent.Size = new System.Drawing.Size(147, 13);
            this.la_homeTextCurrent.TabIndex = 6;
            this.la_homeTextCurrent.Text = "Derzeit geöffnete Datenbank:";
            // 
            // HomeTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.currentlyOpenedDbPanel);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.homeOpenNewDbButton);
            this.Controls.Add(this.la_homeTextCurrent);
            this.Name = "HomeTab";
            this.Size = new System.Drawing.Size(755, 259);
            this.currentlyOpenedDbPanel.ResumeLayout(false);
            this.currentlyOpenedDbPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel currentlyOpenedDbPanel;
        private System.Windows.Forms.Label homeCurrentDBLabel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Button homeOpenNewDbButton;
        private System.Windows.Forms.Label la_homeTextCurrent;
    }
}
