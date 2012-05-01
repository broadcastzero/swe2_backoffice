namespace EPU_Backoffice
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
            this.TableControl = new EPU_Backoffice.TablessControl();
            this.homeTab = new System.Windows.Forms.TabPage();
            this.homeTabInner = new EPU_Backoffice_Panels.homeTab();
            this.kundenKontakteTab = new System.Windows.Forms.TabPage();
            this.kundenKontakteTabInner = new EPU_Backoffice_Panels.kundenKontakteTab();
            this.rechnungsTab = new System.Windows.Forms.TabPage();
            this.rechnungsTab1 = new EPU_Backoffice_Panels.rechnungsTab();
            this.angeboteTab = new System.Windows.Forms.TabPage();
            this.angeboteTab1 = new EPU_Backoffice_Panels.angeboteTab();
            this.projektTab = new System.Windows.Forms.TabPage();
            this.projektTabInner = new EPU_Backoffice_Panels.projektTab();
            this.zeitTab = new System.Windows.Forms.TabPage();
            this.zeitTabInner = new EPU_Backoffice_Panels.zeitTab();
            this.reportTab = new System.Windows.Forms.TabPage();
            this.reportTab1 = new EPU_Backoffice_Panels.reportTab();
            this.TableControl.SuspendLayout();
            this.homeTab.SuspendLayout();
            this.kundenKontakteTab.SuspendLayout();
            this.rechnungsTab.SuspendLayout();
            this.angeboteTab.SuspendLayout();
            this.projektTab.SuspendLayout();
            this.zeitTab.SuspendLayout();
            this.reportTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // beendenButton
            // 
            this.beendenButton.Location = new System.Drawing.Point(12, 215);
            this.beendenButton.Name = "beendenButton";
            this.beendenButton.Size = new System.Drawing.Size(126, 23);
            this.beendenButton.TabIndex = 23;
            this.beendenButton.Text = "Beenden";
            this.beendenButton.UseVisualStyleBackColor = true;
            this.beendenButton.Click += new System.EventHandler(this.ShowExitMessageBox);
            // 
            // reportsButton
            // 
            this.reportsButton.Location = new System.Drawing.Point(12, 186);
            this.reportsButton.Name = "reportsButton";
            this.reportsButton.Size = new System.Drawing.Size(126, 23);
            this.reportsButton.TabIndex = 22;
            this.reportsButton.Text = "Reports";
            this.reportsButton.UseVisualStyleBackColor = true;
            this.reportsButton.Visible = false;
            this.reportsButton.Click += new System.EventHandler(this.SelectReportsTab);
            // 
            // zeiterfassungButton
            // 
            this.zeiterfassungButton.Location = new System.Drawing.Point(12, 157);
            this.zeiterfassungButton.Name = "zeiterfassungButton";
            this.zeiterfassungButton.Size = new System.Drawing.Size(126, 23);
            this.zeiterfassungButton.TabIndex = 21;
            this.zeiterfassungButton.Text = "Zeiterfassung";
            this.zeiterfassungButton.UseVisualStyleBackColor = true;
            this.zeiterfassungButton.Click += new System.EventHandler(this.SelectZeiterfassungTab);
            // 
            // projektverwaltungButton
            // 
            this.projektverwaltungButton.Location = new System.Drawing.Point(12, 128);
            this.projektverwaltungButton.Name = "projektverwaltungButton";
            this.projektverwaltungButton.Size = new System.Drawing.Size(126, 23);
            this.projektverwaltungButton.TabIndex = 20;
            this.projektverwaltungButton.Text = "Projektverwaltung";
            this.projektverwaltungButton.UseVisualStyleBackColor = true;
            this.projektverwaltungButton.Click += new System.EventHandler(this.SelectProjektverwaltungTab);
            // 
            // angeboteButton
            // 
            this.angeboteButton.Location = new System.Drawing.Point(12, 99);
            this.angeboteButton.Name = "angeboteButton";
            this.angeboteButton.Size = new System.Drawing.Size(126, 23);
            this.angeboteButton.TabIndex = 19;
            this.angeboteButton.Text = "Angebote";
            this.angeboteButton.UseVisualStyleBackColor = true;
            this.angeboteButton.Click += new System.EventHandler(this.SelectAngeboteTab);
            // 
            // rechnungsverwaltungButton
            // 
            this.rechnungsverwaltungButton.Location = new System.Drawing.Point(12, 70);
            this.rechnungsverwaltungButton.Name = "rechnungsverwaltungButton";
            this.rechnungsverwaltungButton.Size = new System.Drawing.Size(126, 23);
            this.rechnungsverwaltungButton.TabIndex = 18;
            this.rechnungsverwaltungButton.Text = "Rechnungsverwaltung";
            this.rechnungsverwaltungButton.UseVisualStyleBackColor = true;
            this.rechnungsverwaltungButton.Click += new System.EventHandler(this.SelectRechnungsverwaltungTab);
            // 
            // kundenKontakteButton
            // 
            this.kundenKontakteButton.AccessibleName = "";
            this.kundenKontakteButton.Location = new System.Drawing.Point(12, 41);
            this.kundenKontakteButton.Name = "kundenKontakteButton";
            this.kundenKontakteButton.Size = new System.Drawing.Size(126, 23);
            this.kundenKontakteButton.TabIndex = 17;
            this.kundenKontakteButton.Text = "Kunden und Kontakte";
            this.kundenKontakteButton.UseVisualStyleBackColor = true;
            this.kundenKontakteButton.Click += new System.EventHandler(this.SelectKundenKontakteTab);
            // 
            // homeButton
            // 
            this.homeButton.Location = new System.Drawing.Point(12, 12);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(126, 23);
            this.homeButton.TabIndex = 16;
            this.homeButton.Text = "Home";
            this.homeButton.UseVisualStyleBackColor = true;
            this.homeButton.Click += new System.EventHandler(this.SelectHomeTab);
            // 
            // TableControl
            // 
            this.TableControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.TableControl.Controls.Add(this.homeTab);
            this.TableControl.Controls.Add(this.kundenKontakteTab);
            this.TableControl.Controls.Add(this.rechnungsTab);
            this.TableControl.Controls.Add(this.angeboteTab);
            this.TableControl.Controls.Add(this.projektTab);
            this.TableControl.Controls.Add(this.zeitTab);
            this.TableControl.Controls.Add(this.reportTab);
            this.TableControl.Location = new System.Drawing.Point(144, -1);
            this.TableControl.Multiline = true;
            this.TableControl.Name = "TableControl";
            this.TableControl.SelectedIndex = 0;
            this.TableControl.Size = new System.Drawing.Size(794, 264);
            this.TableControl.TabIndex = 24;
            // 
            // homeTab
            // 
            this.homeTab.Controls.Add(this.homeTabInner);
            this.homeTab.Location = new System.Drawing.Point(42, 4);
            this.homeTab.Name = "homeTab";
            this.homeTab.Padding = new System.Windows.Forms.Padding(3);
            this.homeTab.Size = new System.Drawing.Size(748, 256);
            this.homeTab.TabIndex = 0;
            this.homeTab.Text = "Home";
            this.homeTab.UseVisualStyleBackColor = true;
            // 
            // homeTabInner
            // 
            this.homeTabInner.Location = new System.Drawing.Point(-2, -7);
            this.homeTabInner.Name = "homeTabInner";
            this.homeTabInner.Size = new System.Drawing.Size(755, 269);
            this.homeTabInner.TabIndex = 0;
            // 
            // kundenKontakteTab
            // 
            this.kundenKontakteTab.Controls.Add(this.kundenKontakteTabInner);
            this.kundenKontakteTab.Location = new System.Drawing.Point(42, 4);
            this.kundenKontakteTab.Name = "kundenKontakteTab";
            this.kundenKontakteTab.Padding = new System.Windows.Forms.Padding(3);
            this.kundenKontakteTab.Size = new System.Drawing.Size(748, 256);
            this.kundenKontakteTab.TabIndex = 1;
            this.kundenKontakteTab.Text = "Kunden";
            this.kundenKontakteTab.UseVisualStyleBackColor = true;
            // 
            // kundenKontakteTabInner
            // 
            this.kundenKontakteTabInner.Location = new System.Drawing.Point(-2, -1);
            this.kundenKontakteTabInner.Name = "kundenKontakteTabInner";
            this.kundenKontakteTabInner.Size = new System.Drawing.Size(755, 259);
            this.kundenKontakteTabInner.TabIndex = 0;
            // 
            // rechnungsTab
            // 
            this.rechnungsTab.Controls.Add(this.rechnungsTab1);
            this.rechnungsTab.Location = new System.Drawing.Point(42, 4);
            this.rechnungsTab.Name = "rechnungsTab";
            this.rechnungsTab.Size = new System.Drawing.Size(748, 256);
            this.rechnungsTab.TabIndex = 2;
            this.rechnungsTab.Text = "Rechnung";
            this.rechnungsTab.UseVisualStyleBackColor = true;
            // 
            // rechnungsTab1
            // 
            this.rechnungsTab1.Location = new System.Drawing.Point(-3, 1);
            this.rechnungsTab1.Name = "rechnungsTab1";
            this.rechnungsTab1.Size = new System.Drawing.Size(755, 259);
            this.rechnungsTab1.TabIndex = 0;
            // 
            // angeboteTab
            // 
            this.angeboteTab.Controls.Add(this.angeboteTab1);
            this.angeboteTab.Location = new System.Drawing.Point(42, 4);
            this.angeboteTab.Name = "angeboteTab";
            this.angeboteTab.Size = new System.Drawing.Size(748, 256);
            this.angeboteTab.TabIndex = 3;
            this.angeboteTab.Text = "Angebote";
            this.angeboteTab.UseVisualStyleBackColor = true;
            // 
            // angeboteTab1
            // 
            this.angeboteTab1.Location = new System.Drawing.Point(-3, 0);
            this.angeboteTab1.Name = "angeboteTab1";
            this.angeboteTab1.Size = new System.Drawing.Size(755, 259);
            this.angeboteTab1.TabIndex = 0;
            // 
            // projektTab
            // 
            this.projektTab.Controls.Add(this.projektTabInner);
            this.projektTab.Location = new System.Drawing.Point(42, 4);
            this.projektTab.Name = "projektTab";
            this.projektTab.Size = new System.Drawing.Size(748, 256);
            this.projektTab.TabIndex = 4;
            this.projektTab.Text = "Projekt";
            this.projektTab.UseVisualStyleBackColor = true;
            // 
            // projektTabInner
            // 
            this.projektTabInner.Location = new System.Drawing.Point(0, -3);
            this.projektTabInner.Name = "projektTabInner";
            this.projektTabInner.Size = new System.Drawing.Size(755, 259);
            this.projektTabInner.TabIndex = 0;
            // 
            // zeitTab
            // 
            this.zeitTab.Controls.Add(this.zeitTabInner);
            this.zeitTab.Location = new System.Drawing.Point(42, 4);
            this.zeitTab.Name = "zeitTab";
            this.zeitTab.Size = new System.Drawing.Size(748, 256);
            this.zeitTab.TabIndex = 5;
            this.zeitTab.Text = "Zeit";
            this.zeitTab.UseVisualStyleBackColor = true;
            // 
            // zeitTabInner
            // 
            this.zeitTabInner.Location = new System.Drawing.Point(3, -3);
            this.zeitTabInner.Name = "zeitTabInner";
            this.zeitTabInner.Size = new System.Drawing.Size(755, 259);
            this.zeitTabInner.TabIndex = 0;
            // 
            // reportTab
            // 
            this.reportTab.Controls.Add(this.reportTab1);
            this.reportTab.Location = new System.Drawing.Point(42, 4);
            this.reportTab.Name = "reportTab";
            this.reportTab.Size = new System.Drawing.Size(748, 256);
            this.reportTab.TabIndex = 6;
            this.reportTab.Text = "Report";
            this.reportTab.UseVisualStyleBackColor = true;
            // 
            // reportTab1
            // 
            this.reportTab1.Location = new System.Drawing.Point(3, 1);
            this.reportTab1.Name = "reportTab1";
            this.reportTab1.Size = new System.Drawing.Size(755, 259);
            this.reportTab1.TabIndex = 0;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 262);
            this.Controls.Add(this.TableControl);
            this.Controls.Add(this.beendenButton);
            this.Controls.Add(this.reportsButton);
            this.Controls.Add(this.zeiterfassungButton);
            this.Controls.Add(this.projektverwaltungButton);
            this.Controls.Add(this.angeboteButton);
            this.Controls.Add(this.rechnungsverwaltungButton);
            this.Controls.Add(this.kundenKontakteButton);
            this.Controls.Add(this.homeButton);
            this.Name = "HomeForm";
            this.Text = "Form1";
            this.VisibleChanged += new System.EventHandler(this.ShowDatabaseInfo);
            this.TableControl.ResumeLayout(false);
            this.homeTab.ResumeLayout(false);
            this.kundenKontakteTab.ResumeLayout(false);
            this.rechnungsTab.ResumeLayout(false);
            this.angeboteTab.ResumeLayout(false);
            this.projektTab.ResumeLayout(false);
            this.zeitTab.ResumeLayout(false);
            this.reportTab.ResumeLayout(false);
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
        private TablessControl TableControl;
        private System.Windows.Forms.TabPage homeTab;
        private System.Windows.Forms.TabPage kundenKontakteTab;
        private System.Windows.Forms.TabPage rechnungsTab;
        private System.Windows.Forms.TabPage angeboteTab;
        private System.Windows.Forms.TabPage projektTab;
        private System.Windows.Forms.TabPage zeitTab;
        private System.Windows.Forms.TabPage reportTab;
        private EPU_Backoffice_Panels.homeTab homeTabInner;
        private EPU_Backoffice_Panels.kundenKontakteTab kundenKontakteTabInner;
        private EPU_Backoffice_Panels.rechnungsTab rechnungsTab1;
        private EPU_Backoffice_Panels.angeboteTab angeboteTab1;
        private EPU_Backoffice_Panels.projektTab projektTabInner;
        private EPU_Backoffice_Panels.zeitTab zeitTabInner;
        private EPU_Backoffice_Panels.reportTab reportTab1;
    }
}