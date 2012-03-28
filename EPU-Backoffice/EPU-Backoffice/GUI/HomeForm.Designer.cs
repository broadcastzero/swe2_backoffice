namespace EPUBackoffice.Gui
{
    partial class HomeForm
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
            this.beendenButton = new System.Windows.Forms.Button();
            this.reportsButton = new System.Windows.Forms.Button();
            this.zeiterfassungButton = new System.Windows.Forms.Button();
            this.projektverwaltungButton = new System.Windows.Forms.Button();
            this.angeboteButton = new System.Windows.Forms.Button();
            this.rechnungsverwaltungButton = new System.Windows.Forms.Button();
            this.kundenKontakteButton = new System.Windows.Forms.Button();
            this.homeButton = new System.Windows.Forms.Button();
            this.panelKunden = new System.Windows.Forms.Panel();
            this.tabKundenKontakte = new System.Windows.Forms.TabControl();
            this.kundenCreateTab = new System.Windows.Forms.TabPage();
            this.kundenSearchTab = new System.Windows.Forms.TabPage();
            this.panelKunden.SuspendLayout();
            this.tabKundenKontakte.SuspendLayout();
            this.SuspendLayout();
            // 
            // beendenButton
            // 
            this.beendenButton.Location = new System.Drawing.Point(12, 213);
            this.beendenButton.Name = "beendenButton";
            this.beendenButton.Size = new System.Drawing.Size(126, 23);
            this.beendenButton.TabIndex = 15;
            this.beendenButton.Text = "Beenden";
            this.beendenButton.UseVisualStyleBackColor = true;
            this.beendenButton.Click += new System.EventHandler(this.beendenButton_Click);
            // 
            // reportsButton
            // 
            this.reportsButton.Location = new System.Drawing.Point(12, 184);
            this.reportsButton.Name = "reportsButton";
            this.reportsButton.Size = new System.Drawing.Size(126, 23);
            this.reportsButton.TabIndex = 14;
            this.reportsButton.Text = "Reports";
            this.reportsButton.UseVisualStyleBackColor = true;
            this.reportsButton.Click += new System.EventHandler(this.reportsButton_Click);
            // 
            // zeiterfassungButton
            // 
            this.zeiterfassungButton.Location = new System.Drawing.Point(12, 155);
            this.zeiterfassungButton.Name = "zeiterfassungButton";
            this.zeiterfassungButton.Size = new System.Drawing.Size(126, 23);
            this.zeiterfassungButton.TabIndex = 13;
            this.zeiterfassungButton.Text = "Zeiterfassung";
            this.zeiterfassungButton.UseVisualStyleBackColor = true;
            this.zeiterfassungButton.Click += new System.EventHandler(this.zeiterfassungButton_Click);
            // 
            // projektverwaltungButton
            // 
            this.projektverwaltungButton.Location = new System.Drawing.Point(12, 126);
            this.projektverwaltungButton.Name = "projektverwaltungButton";
            this.projektverwaltungButton.Size = new System.Drawing.Size(126, 23);
            this.projektverwaltungButton.TabIndex = 12;
            this.projektverwaltungButton.Text = "Projektverwaltung";
            this.projektverwaltungButton.UseVisualStyleBackColor = true;
            this.projektverwaltungButton.Click += new System.EventHandler(this.projektverwaltungButton_Click);
            // 
            // angeboteButton
            // 
            this.angeboteButton.Location = new System.Drawing.Point(12, 97);
            this.angeboteButton.Name = "angeboteButton";
            this.angeboteButton.Size = new System.Drawing.Size(126, 23);
            this.angeboteButton.TabIndex = 11;
            this.angeboteButton.Text = "Angebote";
            this.angeboteButton.UseVisualStyleBackColor = true;
            this.angeboteButton.Click += new System.EventHandler(this.angeboteButton_Click);
            // 
            // rechnungsverwaltungButton
            // 
            this.rechnungsverwaltungButton.Location = new System.Drawing.Point(12, 68);
            this.rechnungsverwaltungButton.Name = "rechnungsverwaltungButton";
            this.rechnungsverwaltungButton.Size = new System.Drawing.Size(126, 23);
            this.rechnungsverwaltungButton.TabIndex = 10;
            this.rechnungsverwaltungButton.Text = "Rechnungsverwaltung";
            this.rechnungsverwaltungButton.UseVisualStyleBackColor = true;
            this.rechnungsverwaltungButton.Click += new System.EventHandler(this.rechnungsverwaltungButton_Click);
            // 
            // kundenKontakteButton
            // 
            this.kundenKontakteButton.AccessibleName = "";
            this.kundenKontakteButton.Location = new System.Drawing.Point(12, 39);
            this.kundenKontakteButton.Name = "kundenKontakteButton";
            this.kundenKontakteButton.Size = new System.Drawing.Size(126, 23);
            this.kundenKontakteButton.TabIndex = 9;
            this.kundenKontakteButton.Text = "Kunden und Kontakte";
            this.kundenKontakteButton.UseVisualStyleBackColor = true;
            this.kundenKontakteButton.Click += new System.EventHandler(this.kundenKontakteButton_Click);
            // 
            // homeButton
            // 
            this.homeButton.Location = new System.Drawing.Point(12, 10);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(126, 23);
            this.homeButton.TabIndex = 8;
            this.homeButton.Text = "Home";
            this.homeButton.UseVisualStyleBackColor = true;
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // panelKunden
            // 
            this.panelKunden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKunden.Controls.Add(this.tabKundenKontakte);
            this.panelKunden.Location = new System.Drawing.Point(152, 12);
            this.panelKunden.Name = "panelKunden";
            this.panelKunden.Size = new System.Drawing.Size(770, 238);
            this.panelKunden.TabIndex = 16;
            this.panelKunden.Visible = false;
            // 
            // tabKundenKontakte
            // 
            this.tabKundenKontakte.Controls.Add(this.kundenCreateTab);
            this.tabKundenKontakte.Controls.Add(this.kundenSearchTab);
            this.tabKundenKontakte.Location = new System.Drawing.Point(-1, -1);
            this.tabKundenKontakte.Name = "tabKundenKontakte";
            this.tabKundenKontakte.SelectedIndex = 0;
            this.tabKundenKontakte.Size = new System.Drawing.Size(770, 238);
            this.tabKundenKontakte.TabIndex = 0;
            this.tabKundenKontakte.Click += new System.EventHandler(this.kundenSearchTab_Click);
            // 
            // kundenCreateTab
            // 
            this.kundenCreateTab.Location = new System.Drawing.Point(4, 22);
            this.kundenCreateTab.Name = "kundenCreateTab";
            this.kundenCreateTab.Padding = new System.Windows.Forms.Padding(3);
            this.kundenCreateTab.Size = new System.Drawing.Size(762, 212);
            this.kundenCreateTab.TabIndex = 0;
            this.kundenCreateTab.Text = "Neu";
            this.kundenCreateTab.UseVisualStyleBackColor = true;
            this.kundenCreateTab.Click += new System.EventHandler(this.kundenCreateTab_Click);
            // 
            // kundenSearchTab
            // 
            this.kundenSearchTab.Location = new System.Drawing.Point(4, 22);
            this.kundenSearchTab.Name = "kundenSearchTab";
            this.kundenSearchTab.Padding = new System.Windows.Forms.Padding(3);
            this.kundenSearchTab.Size = new System.Drawing.Size(762, 212);
            this.kundenSearchTab.TabIndex = 1;
            this.kundenSearchTab.Text = "Suchen & Aendern";
            this.kundenSearchTab.UseVisualStyleBackColor = true;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 262);
            this.Controls.Add(this.panelKunden);
            this.Controls.Add(this.beendenButton);
            this.Controls.Add(this.reportsButton);
            this.Controls.Add(this.zeiterfassungButton);
            this.Controls.Add(this.projektverwaltungButton);
            this.Controls.Add(this.angeboteButton);
            this.Controls.Add(this.rechnungsverwaltungButton);
            this.Controls.Add(this.kundenKontakteButton);
            this.Controls.Add(this.homeButton);
            this.Name = "HomeForm";
            this.Text = "EPU Backoffice 1.0";
            this.panelKunden.ResumeLayout(false);
            this.tabKundenKontakte.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button beendenButton;
        private System.Windows.Forms.Button reportsButton;
        private System.Windows.Forms.Button zeiterfassungButton;
        private System.Windows.Forms.Button projektverwaltungButton;
        private System.Windows.Forms.Button angeboteButton;
        private System.Windows.Forms.Button rechnungsverwaltungButton;
        private System.Windows.Forms.Button kundenKontakteButton;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Panel panelKunden;
        private System.Windows.Forms.TabControl tabKundenKontakte;
        private System.Windows.Forms.TabPage kundenCreateTab;
        private System.Windows.Forms.TabPage kundenSearchTab;



    }
}