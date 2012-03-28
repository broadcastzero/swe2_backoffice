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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.homeButton = new System.Windows.Forms.Button();
            this.kundenKontakteButton = new System.Windows.Forms.Button();
            this.rechnungsverwaltungButton = new System.Windows.Forms.Button();
            this.angeboteButton = new System.Windows.Forms.Button();
            this.zeiterfassungButton = new System.Windows.Forms.Button();
            this.reportsButton = new System.Windows.Forms.Button();
            this.beendenButton = new System.Windows.Forms.Button();
            this.projektverwaltungButton = new System.Windows.Forms.Button();
            this.mainTab = new TablessControl();
            this.homeTab = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kundenKontakteTab = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.kundenTabCreate = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bu_kundenNeuReset = new System.Windows.Forms.Button();
            this.bu_kundenNeuSave = new System.Windows.Forms.Button();
            this.ra_kundenNeuKontakt = new System.Windows.Forms.RadioButton();
            this.ra_kundenNeuKunde = new System.Windows.Forms.RadioButton();
            this.tb_kundenNeuNachname = new System.Windows.Forms.TextBox();
            this.tb_kundenNeuVorname = new System.Windows.Forms.TextBox();
            this.kundenTabSearchChange = new System.Windows.Forms.TabPage();
            this.rechnungsTab = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.rechnungAusgangTab = new System.Windows.Forms.TabPage();
            this.rechnungEingangTab = new System.Windows.Forms.TabPage();
            this.rechnungDruckenTab = new System.Windows.Forms.TabPage();
            this.rechnungUmsatzTab = new System.Windows.Forms.TabPage();
            this.angeboteTab = new System.Windows.Forms.TabPage();
            this.zeitTab = new System.Windows.Forms.TabPage();
            this.reportTab = new System.Windows.Forms.TabPage();
            this.tb_kundenSearchVorname = new System.Windows.Forms.TextBox();
            this.tb_kundenSearchNachname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bu_kundenSearchSuchen = new System.Windows.Forms.Button();
            this.bu_kundenSearchAendern = new System.Windows.Forms.Button();
            this.dg_kundenSearch = new System.Windows.Forms.DataGridView();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.projektTab = new System.Windows.Forms.TabPage();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl5 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabControl6 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.mainTab.SuspendLayout();
            this.homeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.kundenKontakteTab.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.kundenTabCreate.SuspendLayout();
            this.kundenTabSearchChange.SuspendLayout();
            this.rechnungsTab.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.angeboteTab.SuspendLayout();
            this.zeitTab.SuspendLayout();
            this.reportTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_kundenSearch)).BeginInit();
            this.tabControl3.SuspendLayout();
            this.projektTab.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabControl5.SuspendLayout();
            this.tabControl6.SuspendLayout();
            this.SuspendLayout();
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
            // mainTab
            // 
            this.mainTab.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.mainTab.Controls.Add(this.homeTab);
            this.mainTab.Controls.Add(this.kundenKontakteTab);
            this.mainTab.Controls.Add(this.rechnungsTab);
            this.mainTab.Controls.Add(this.angeboteTab);
            this.mainTab.Controls.Add(this.projektTab);
            this.mainTab.Controls.Add(this.zeitTab);
            this.mainTab.Controls.Add(this.reportTab);
            this.mainTab.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mainTab.ItemSize = new System.Drawing.Size(5, 15);
            this.mainTab.Location = new System.Drawing.Point(144, -1);
            this.mainTab.Multiline = true;
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(789, 263);
            this.mainTab.TabIndex = 16;
            // 
            // homeTab
            // 
            this.homeTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.homeTab.Controls.Add(this.pictureBox1);
            this.homeTab.Location = new System.Drawing.Point(34, 4);
            this.homeTab.Name = "homeTab";
            this.homeTab.Padding = new System.Windows.Forms.Padding(3);
            this.homeTab.Size = new System.Drawing.Size(751, 255);
            this.homeTab.TabIndex = 2;
            this.homeTab.Text = "1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(52, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(264, 149);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // kundenKontakteTab
            // 
            this.kundenKontakteTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.kundenKontakteTab.Controls.Add(this.tabControl1);
            this.kundenKontakteTab.Location = new System.Drawing.Point(34, 4);
            this.kundenKontakteTab.Name = "kundenKontakteTab";
            this.kundenKontakteTab.Padding = new System.Windows.Forms.Padding(3);
            this.kundenKontakteTab.Size = new System.Drawing.Size(751, 255);
            this.kundenKontakteTab.TabIndex = 1;
            this.kundenKontakteTab.Text = "2";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.kundenTabCreate);
            this.tabControl1.Controls.Add(this.kundenTabSearchChange);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(779, 259);
            this.tabControl1.TabIndex = 0;
            // 
            // kundenTabCreate
            // 
            this.kundenTabCreate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.kundenTabCreate.Controls.Add(this.label2);
            this.kundenTabCreate.Controls.Add(this.label1);
            this.kundenTabCreate.Controls.Add(this.bu_kundenNeuReset);
            this.kundenTabCreate.Controls.Add(this.bu_kundenNeuSave);
            this.kundenTabCreate.Controls.Add(this.ra_kundenNeuKontakt);
            this.kundenTabCreate.Controls.Add(this.ra_kundenNeuKunde);
            this.kundenTabCreate.Controls.Add(this.tb_kundenNeuNachname);
            this.kundenTabCreate.Controls.Add(this.tb_kundenNeuVorname);
            this.kundenTabCreate.Location = new System.Drawing.Point(4, 22);
            this.kundenTabCreate.Name = "kundenTabCreate";
            this.kundenTabCreate.Padding = new System.Windows.Forms.Padding(3);
            this.kundenTabCreate.Size = new System.Drawing.Size(771, 233);
            this.kundenTabCreate.TabIndex = 0;
            this.kundenTabCreate.Text = "Neu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nachname / Firma*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(327, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Vorname";
            // 
            // bu_kundenNeuReset
            // 
            this.bu_kundenNeuReset.Location = new System.Drawing.Point(187, 124);
            this.bu_kundenNeuReset.Name = "bu_kundenNeuReset";
            this.bu_kundenNeuReset.Size = new System.Drawing.Size(134, 23);
            this.bu_kundenNeuReset.TabIndex = 5;
            this.bu_kundenNeuReset.Text = "Felder zurücksetzen";
            this.bu_kundenNeuReset.UseVisualStyleBackColor = true;
            this.bu_kundenNeuReset.Click += new System.EventHandler(this.bu_kundenNeuReset_Click);
            // 
            // bu_kundenNeuSave
            // 
            this.bu_kundenNeuSave.Location = new System.Drawing.Point(187, 95);
            this.bu_kundenNeuSave.Name = "bu_kundenNeuSave";
            this.bu_kundenNeuSave.Size = new System.Drawing.Size(134, 23);
            this.bu_kundenNeuSave.TabIndex = 4;
            this.bu_kundenNeuSave.Text = "Speichern";
            this.bu_kundenNeuSave.UseVisualStyleBackColor = true;
            this.bu_kundenNeuSave.Click += new System.EventHandler(this.bu_kundenNeuSave_Click);
            // 
            // ra_kundenNeuKontakt
            // 
            this.ra_kundenNeuKontakt.AutoSize = true;
            this.ra_kundenNeuKontakt.Location = new System.Drawing.Point(24, 124);
            this.ra_kundenNeuKontakt.Name = "ra_kundenNeuKontakt";
            this.ra_kundenNeuKontakt.Size = new System.Drawing.Size(62, 17);
            this.ra_kundenNeuKontakt.TabIndex = 3;
            this.ra_kundenNeuKontakt.TabStop = true;
            this.ra_kundenNeuKontakt.Text = "Kontakt";
            this.ra_kundenNeuKontakt.UseVisualStyleBackColor = true;
            // 
            // ra_kundenNeuKunde
            // 
            this.ra_kundenNeuKunde.AutoSize = true;
            this.ra_kundenNeuKunde.Location = new System.Drawing.Point(24, 101);
            this.ra_kundenNeuKunde.Name = "ra_kundenNeuKunde";
            this.ra_kundenNeuKunde.Size = new System.Drawing.Size(56, 17);
            this.ra_kundenNeuKunde.TabIndex = 2;
            this.ra_kundenNeuKunde.TabStop = true;
            this.ra_kundenNeuKunde.Text = "Kunde";
            this.ra_kundenNeuKunde.UseVisualStyleBackColor = true;
            this.ra_kundenNeuKunde.CheckedChanged += new System.EventHandler(this.ra_kundenNeuKunde_CheckedChanged);
            // 
            // tb_kundenNeuNachname
            // 
            this.tb_kundenNeuNachname.Location = new System.Drawing.Point(24, 52);
            this.tb_kundenNeuNachname.Name = "tb_kundenNeuNachname";
            this.tb_kundenNeuNachname.Size = new System.Drawing.Size(297, 20);
            this.tb_kundenNeuNachname.TabIndex = 1;
            this.tb_kundenNeuNachname.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // tb_kundenNeuVorname
            // 
            this.tb_kundenNeuVorname.Location = new System.Drawing.Point(24, 26);
            this.tb_kundenNeuVorname.Name = "tb_kundenNeuVorname";
            this.tb_kundenNeuVorname.Size = new System.Drawing.Size(297, 20);
            this.tb_kundenNeuVorname.TabIndex = 0;
            // 
            // kundenTabSearchChange
            // 
            this.kundenTabSearchChange.BackColor = System.Drawing.Color.WhiteSmoke;
            this.kundenTabSearchChange.Controls.Add(this.dg_kundenSearch);
            this.kundenTabSearchChange.Controls.Add(this.bu_kundenSearchAendern);
            this.kundenTabSearchChange.Controls.Add(this.bu_kundenSearchSuchen);
            this.kundenTabSearchChange.Controls.Add(this.label4);
            this.kundenTabSearchChange.Controls.Add(this.label3);
            this.kundenTabSearchChange.Controls.Add(this.tb_kundenSearchNachname);
            this.kundenTabSearchChange.Controls.Add(this.tb_kundenSearchVorname);
            this.kundenTabSearchChange.Location = new System.Drawing.Point(4, 22);
            this.kundenTabSearchChange.Name = "kundenTabSearchChange";
            this.kundenTabSearchChange.Padding = new System.Windows.Forms.Padding(3);
            this.kundenTabSearchChange.Size = new System.Drawing.Size(771, 233);
            this.kundenTabSearchChange.TabIndex = 1;
            this.kundenTabSearchChange.Text = "Suchen und Ändern";
            // 
            // rechnungsTab
            // 
            this.rechnungsTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rechnungsTab.Controls.Add(this.tabControl2);
            this.rechnungsTab.Location = new System.Drawing.Point(19, 4);
            this.rechnungsTab.Name = "rechnungsTab";
            this.rechnungsTab.Padding = new System.Windows.Forms.Padding(3);
            this.rechnungsTab.Size = new System.Drawing.Size(766, 255);
            this.rechnungsTab.TabIndex = 3;
            this.rechnungsTab.Text = "3";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.rechnungAusgangTab);
            this.tabControl2.Controls.Add(this.rechnungEingangTab);
            this.tabControl2.Controls.Add(this.rechnungDruckenTab);
            this.tabControl2.Controls.Add(this.rechnungUmsatzTab);
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(779, 259);
            this.tabControl2.TabIndex = 0;
            // 
            // rechnungAusgangTab
            // 
            this.rechnungAusgangTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rechnungAusgangTab.Location = new System.Drawing.Point(4, 22);
            this.rechnungAusgangTab.Name = "rechnungAusgangTab";
            this.rechnungAusgangTab.Padding = new System.Windows.Forms.Padding(3);
            this.rechnungAusgangTab.Size = new System.Drawing.Size(771, 233);
            this.rechnungAusgangTab.TabIndex = 0;
            this.rechnungAusgangTab.Text = "Ausgangsrechnung";
            // 
            // rechnungEingangTab
            // 
            this.rechnungEingangTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rechnungEingangTab.Location = new System.Drawing.Point(4, 22);
            this.rechnungEingangTab.Name = "rechnungEingangTab";
            this.rechnungEingangTab.Padding = new System.Windows.Forms.Padding(3);
            this.rechnungEingangTab.Size = new System.Drawing.Size(771, 233);
            this.rechnungEingangTab.TabIndex = 1;
            this.rechnungEingangTab.Text = "Eingangsrechnung";
            // 
            // rechnungDruckenTab
            // 
            this.rechnungDruckenTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rechnungDruckenTab.Location = new System.Drawing.Point(4, 22);
            this.rechnungDruckenTab.Name = "rechnungDruckenTab";
            this.rechnungDruckenTab.Padding = new System.Windows.Forms.Padding(3);
            this.rechnungDruckenTab.Size = new System.Drawing.Size(771, 233);
            this.rechnungDruckenTab.TabIndex = 2;
            this.rechnungDruckenTab.Text = "Drucken";
            // 
            // rechnungUmsatzTab
            // 
            this.rechnungUmsatzTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rechnungUmsatzTab.Location = new System.Drawing.Point(4, 22);
            this.rechnungUmsatzTab.Name = "rechnungUmsatzTab";
            this.rechnungUmsatzTab.Padding = new System.Windows.Forms.Padding(3);
            this.rechnungUmsatzTab.Size = new System.Drawing.Size(771, 233);
            this.rechnungUmsatzTab.TabIndex = 3;
            this.rechnungUmsatzTab.Text = "Umsätze";
            // 
            // angeboteTab
            // 
            this.angeboteTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.angeboteTab.Controls.Add(this.tabControl3);
            this.angeboteTab.Location = new System.Drawing.Point(19, 4);
            this.angeboteTab.Name = "angeboteTab";
            this.angeboteTab.Padding = new System.Windows.Forms.Padding(3);
            this.angeboteTab.Size = new System.Drawing.Size(766, 255);
            this.angeboteTab.TabIndex = 4;
            this.angeboteTab.Text = "4";
            // 
            // zeitTab
            // 
            this.zeitTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.zeitTab.Controls.Add(this.tabControl5);
            this.zeitTab.Location = new System.Drawing.Point(34, 4);
            this.zeitTab.Name = "zeitTab";
            this.zeitTab.Padding = new System.Windows.Forms.Padding(3);
            this.zeitTab.Size = new System.Drawing.Size(751, 255);
            this.zeitTab.TabIndex = 6;
            this.zeitTab.Text = "6";
            // 
            // reportTab
            // 
            this.reportTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.reportTab.Controls.Add(this.tabControl6);
            this.reportTab.Location = new System.Drawing.Point(34, 4);
            this.reportTab.Name = "reportTab";
            this.reportTab.Padding = new System.Windows.Forms.Padding(3);
            this.reportTab.Size = new System.Drawing.Size(751, 255);
            this.reportTab.TabIndex = 7;
            this.reportTab.Text = "7";
            // 
            // tb_kundenSearchVorname
            // 
            this.tb_kundenSearchVorname.Location = new System.Drawing.Point(24, 26);
            this.tb_kundenSearchVorname.Name = "tb_kundenSearchVorname";
            this.tb_kundenSearchVorname.Size = new System.Drawing.Size(214, 20);
            this.tb_kundenSearchVorname.TabIndex = 0;
            // 
            // tb_kundenSearchNachname
            // 
            this.tb_kundenSearchNachname.Location = new System.Drawing.Point(24, 52);
            this.tb_kundenSearchNachname.Name = "tb_kundenSearchNachname";
            this.tb_kundenSearchNachname.Size = new System.Drawing.Size(214, 20);
            this.tb_kundenSearchNachname.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vorname";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nachname / Firma*";
            // 
            // bu_kundenSearchSuchen
            // 
            this.bu_kundenSearchSuchen.Location = new System.Drawing.Point(24, 101);
            this.bu_kundenSearchSuchen.Name = "bu_kundenSearchSuchen";
            this.bu_kundenSearchSuchen.Size = new System.Drawing.Size(101, 23);
            this.bu_kundenSearchSuchen.TabIndex = 4;
            this.bu_kundenSearchSuchen.Text = "Suchen";
            this.bu_kundenSearchSuchen.UseVisualStyleBackColor = true;
            // 
            // bu_kundenSearchAendern
            // 
            this.bu_kundenSearchAendern.Location = new System.Drawing.Point(141, 101);
            this.bu_kundenSearchAendern.Name = "bu_kundenSearchAendern";
            this.bu_kundenSearchAendern.Size = new System.Drawing.Size(97, 23);
            this.bu_kundenSearchAendern.TabIndex = 5;
            this.bu_kundenSearchAendern.Text = "Ändern";
            this.bu_kundenSearchAendern.UseVisualStyleBackColor = true;
            this.bu_kundenSearchAendern.Click += new System.EventHandler(this.bu_kundenSearchAendern_Click);
            // 
            // dg_kundenSearch
            // 
            this.dg_kundenSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_kundenSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_kundenSearch.Location = new System.Drawing.Point(383, 25);
            this.dg_kundenSearch.Name = "dg_kundenSearch";
            this.dg_kundenSearch.Size = new System.Drawing.Size(346, 183);
            this.dg_kundenSearch.TabIndex = 6;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage1);
            this.tabControl3.Controls.Add(this.tabPage2);
            this.tabControl3.Location = new System.Drawing.Point(142, 94);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(200, 100);
            this.tabControl3.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(192, 74);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // projektTab
            // 
            this.projektTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.projektTab.Controls.Add(this.tabControl4);
            this.projektTab.Location = new System.Drawing.Point(34, 4);
            this.projektTab.Name = "projektTab";
            this.projektTab.Padding = new System.Windows.Forms.Padding(3);
            this.projektTab.Size = new System.Drawing.Size(751, 255);
            this.projektTab.TabIndex = 5;
            this.projektTab.Text = "5";
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage3);
            this.tabControl4.Controls.Add(this.tabPage4);
            this.tabControl4.Location = new System.Drawing.Point(203, 125);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(200, 100);
            this.tabControl4.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(192, 74);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(192, 74);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabControl5
            // 
            this.tabControl5.Controls.Add(this.tabPage5);
            this.tabControl5.Controls.Add(this.tabPage6);
            this.tabControl5.Location = new System.Drawing.Point(132, 68);
            this.tabControl5.Name = "tabControl5";
            this.tabControl5.SelectedIndex = 0;
            this.tabControl5.Size = new System.Drawing.Size(200, 100);
            this.tabControl5.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(192, 74);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(192, 74);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabControl6
            // 
            this.tabControl6.Controls.Add(this.tabPage7);
            this.tabControl6.Controls.Add(this.tabPage8);
            this.tabControl6.Location = new System.Drawing.Point(137, 103);
            this.tabControl6.Name = "tabControl6";
            this.tabControl6.SelectedIndex = 0;
            this.tabControl6.Size = new System.Drawing.Size(200, 100);
            this.tabControl6.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(192, 74);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "tabPage7";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(192, 74);
            this.tabPage8.TabIndex = 1;
            this.tabPage8.Text = "tabPage8";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 262);
            this.Controls.Add(this.beendenButton);
            this.Controls.Add(this.reportsButton);
            this.Controls.Add(this.zeiterfassungButton);
            this.Controls.Add(this.projektverwaltungButton);
            this.Controls.Add(this.angeboteButton);
            this.Controls.Add(this.rechnungsverwaltungButton);
            this.Controls.Add(this.kundenKontakteButton);
            this.Controls.Add(this.homeButton);
            this.Controls.Add(this.mainTab);
            this.Name = "HomeForm";
            this.Text = "EPU Backoffice 1.0";
            this.mainTab.ResumeLayout(false);
            this.homeTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.kundenKontakteTab.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.kundenTabCreate.ResumeLayout(false);
            this.kundenTabCreate.PerformLayout();
            this.kundenTabSearchChange.ResumeLayout(false);
            this.kundenTabSearchChange.PerformLayout();
            this.rechnungsTab.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.angeboteTab.ResumeLayout(false);
            this.zeitTab.ResumeLayout(false);
            this.reportTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_kundenSearch)).EndInit();
            this.tabControl3.ResumeLayout(false);
            this.projektTab.ResumeLayout(false);
            this.tabControl4.ResumeLayout(false);
            this.tabControl5.ResumeLayout(false);
            this.tabControl6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.TabPage reportTab;
        private TablessControl mainTab;
        private System.Windows.Forms.TabPage homeTab;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage kundenKontakteTab;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage kundenTabCreate;
        private System.Windows.Forms.TabPage kundenTabSearchChange;
        private System.Windows.Forms.TabPage rechnungsTab;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage rechnungAusgangTab;
        private System.Windows.Forms.TabPage rechnungEingangTab;
        private System.Windows.Forms.TabPage rechnungDruckenTab;
        private System.Windows.Forms.TabPage rechnungUmsatzTab;
        private System.Windows.Forms.TabPage angeboteTab;
        private System.Windows.Forms.TabPage zeitTab;
        private System.Windows.Forms.Button kundenKontakteButton;
        private System.Windows.Forms.Button rechnungsverwaltungButton;
        private System.Windows.Forms.Button angeboteButton;
        private System.Windows.Forms.Button zeiterfassungButton;
        private System.Windows.Forms.Button reportsButton;
        private System.Windows.Forms.Button beendenButton;
        private System.Windows.Forms.Button projektverwaltungButton;
        private System.Windows.Forms.Button bu_kundenNeuReset;
        private System.Windows.Forms.Button bu_kundenNeuSave;
        private System.Windows.Forms.RadioButton ra_kundenNeuKontakt;
        private System.Windows.Forms.RadioButton ra_kundenNeuKunde;
        private System.Windows.Forms.TextBox tb_kundenNeuNachname;
        private System.Windows.Forms.TextBox tb_kundenNeuVorname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dg_kundenSearch;
        private System.Windows.Forms.Button bu_kundenSearchAendern;
        private System.Windows.Forms.Button bu_kundenSearchSuchen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_kundenSearchNachname;
        private System.Windows.Forms.TextBox tb_kundenSearchVorname;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage projektTab;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabControl tabControl5;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabControl tabControl6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;





    }
}