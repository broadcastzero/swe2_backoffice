namespace EPU_Backoffice_Panels
{
    partial class rechnungsTab
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
            this.components = new System.ComponentModel.Container();
            this.ausgangsrechnungBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buchungszeilenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rechnungUmsatzTab = new System.Windows.Forms.TabPage();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker5 = new System.Windows.Forms.DateTimePicker();
            this.button6 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.umsaetzeMsgLabel = new System.Windows.Forms.Label();
            this.rechnungEingangTab = new System.Windows.Forms.TabPage();
            this.eingangsrechnungDataGridView = new System.Windows.Forms.DataGridView();
            this.Buchungsdatum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BetragNetto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BetragUST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KategorieID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Beschreibung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eingangsrechnungBetragTextBox = new System.Windows.Forms.TextBox();
            this.kategorieComboBox = new System.Windows.Forms.ComboBox();
            this.addBuchungszeileButton = new System.Windows.Forms.Button();
            this.finishAccountButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.eingangsrechnungMsgLabel = new System.Windows.Forms.Label();
            this.eingangsrechnungBezeichnungTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.eingangsrechnungDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.existingKontakteComboBox = new System.Windows.Forms.ComboBox();
            this.buchungszeileBezeichnungTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.resetEingangsrechnungButton = new System.Windows.Forms.Button();
            this.rechnungAusgangTab = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.createRechnungButton = new System.Windows.Forms.Button();
            this.rechnungstitelTextBox = new System.Windows.Forms.TextBox();
            this.ausgangsrechnungDataGridView = new System.Windows.Forms.DataGridView();
            this.Stundensatz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stunden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bezeichnung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjektID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZeitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projekteComboBox = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.unpaidBalanceTextBox = new System.Windows.Forms.TextBox();
            this.ausgangsrechnungMsgLabel = new System.Windows.Forms.Label();
            this.rechnungsTabControl = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.ausgangsrechnungBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buchungszeilenBindingSource)).BeginInit();
            this.rechnungUmsatzTab.SuspendLayout();
            this.rechnungEingangTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eingangsrechnungDataGridView)).BeginInit();
            this.rechnungAusgangTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ausgangsrechnungDataGridView)).BeginInit();
            this.rechnungsTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // rechnungUmsatzTab
            // 
            this.rechnungUmsatzTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rechnungUmsatzTab.Controls.Add(this.umsaetzeMsgLabel);
            this.rechnungUmsatzTab.Controls.Add(this.label19);
            this.rechnungUmsatzTab.Controls.Add(this.label18);
            this.rechnungUmsatzTab.Controls.Add(this.button6);
            this.rechnungUmsatzTab.Controls.Add(this.dateTimePicker5);
            this.rechnungUmsatzTab.Controls.Add(this.dateTimePicker4);
            this.rechnungUmsatzTab.Location = new System.Drawing.Point(4, 22);
            this.rechnungUmsatzTab.Name = "rechnungUmsatzTab";
            this.rechnungUmsatzTab.Padding = new System.Windows.Forms.Padding(3);
            this.rechnungUmsatzTab.Size = new System.Drawing.Size(747, 233);
            this.rechnungUmsatzTab.TabIndex = 3;
            this.rechnungUmsatzTab.Text = "Umsätze";
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.Location = new System.Drawing.Point(19, 14);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker4.TabIndex = 0;
            // 
            // dateTimePicker5
            // 
            this.dateTimePicker5.Location = new System.Drawing.Point(19, 40);
            this.dateTimePicker5.Name = "dateTimePicker5";
            this.dateTimePicker5.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker5.TabIndex = 1;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(19, 73);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(200, 23);
            this.button6.TabIndex = 2;
            this.button6.Text = "Als PDF anzeigen";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.ShowUmsaetze);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(225, 20);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(26, 13);
            this.label18.TabIndex = 6;
            this.label18.Text = "Von";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(225, 43);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(21, 13);
            this.label19.TabIndex = 7;
            this.label19.Text = "Bis";
            // 
            // umsaetzeMsgLabel
            // 
            this.umsaetzeMsgLabel.AutoSize = true;
            this.umsaetzeMsgLabel.Location = new System.Drawing.Point(16, 108);
            this.umsaetzeMsgLabel.Name = "umsaetzeMsgLabel";
            this.umsaetzeMsgLabel.Size = new System.Drawing.Size(76, 13);
            this.umsaetzeMsgLabel.TabIndex = 25;
            this.umsaetzeMsgLabel.Text = "MessageLabel";
            this.umsaetzeMsgLabel.Visible = false;
            // 
            // rechnungEingangTab
            // 
            this.rechnungEingangTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rechnungEingangTab.Controls.Add(this.resetEingangsrechnungButton);
            this.rechnungEingangTab.Controls.Add(this.label2);
            this.rechnungEingangTab.Controls.Add(this.buchungszeileBezeichnungTextBox);
            this.rechnungEingangTab.Controls.Add(this.eingangsrechnungBezeichnungTextBox);
            this.rechnungEingangTab.Controls.Add(this.eingangsrechnungBetragTextBox);
            this.rechnungEingangTab.Controls.Add(this.existingKontakteComboBox);
            this.rechnungEingangTab.Controls.Add(this.label1);
            this.rechnungEingangTab.Controls.Add(this.eingangsrechnungDatePicker);
            this.rechnungEingangTab.Controls.Add(this.label10);
            this.rechnungEingangTab.Controls.Add(this.label11);
            this.rechnungEingangTab.Controls.Add(this.eingangsrechnungMsgLabel);
            this.rechnungEingangTab.Controls.Add(this.label13);
            this.rechnungEingangTab.Controls.Add(this.label12);
            this.rechnungEingangTab.Controls.Add(this.finishAccountButton);
            this.rechnungEingangTab.Controls.Add(this.addBuchungszeileButton);
            this.rechnungEingangTab.Controls.Add(this.kategorieComboBox);
            this.rechnungEingangTab.Controls.Add(this.eingangsrechnungDataGridView);
            this.rechnungEingangTab.Location = new System.Drawing.Point(4, 22);
            this.rechnungEingangTab.Name = "rechnungEingangTab";
            this.rechnungEingangTab.Padding = new System.Windows.Forms.Padding(3);
            this.rechnungEingangTab.Size = new System.Drawing.Size(747, 233);
            this.rechnungEingangTab.TabIndex = 1;
            this.rechnungEingangTab.Text = "Eingangsrechnung";
            // 
            // eingangsrechnungDataGridView
            // 
            this.eingangsrechnungDataGridView.AllowUserToAddRows = false;
            this.eingangsrechnungDataGridView.AllowUserToDeleteRows = false;
            this.eingangsrechnungDataGridView.AutoGenerateColumns = false;
            this.eingangsrechnungDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eingangsrechnungDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Beschreibung,
            this.KategorieID,
            this.BetragUST,
            this.BetragNetto,
            this.Buchungsdatum});
            this.eingangsrechnungDataGridView.DataSource = this.buchungszeilenBindingSource;
            this.eingangsrechnungDataGridView.Location = new System.Drawing.Point(383, 25);
            this.eingangsrechnungDataGridView.Name = "eingangsrechnungDataGridView";
            this.eingangsrechnungDataGridView.Size = new System.Drawing.Size(346, 183);
            this.eingangsrechnungDataGridView.TabIndex = 0;
            // 
            // Buchungsdatum
            // 
            this.Buchungsdatum.DataPropertyName = "Buchungsdatum";
            this.Buchungsdatum.HeaderText = "Buchungsdatum";
            this.Buchungsdatum.Name = "Buchungsdatum";
            // 
            // BetragNetto
            // 
            this.BetragNetto.DataPropertyName = "BetragNetto";
            this.BetragNetto.HeaderText = "BetragNetto";
            this.BetragNetto.Name = "BetragNetto";
            // 
            // BetragUST
            // 
            this.BetragUST.DataPropertyName = "BetragUST";
            this.BetragUST.HeaderText = "BetragUST";
            this.BetragUST.Name = "BetragUST";
            this.BetragUST.Visible = false;
            // 
            // KategorieID
            // 
            this.KategorieID.DataPropertyName = "KategorieID";
            this.KategorieID.HeaderText = "KategorieID";
            this.KategorieID.Name = "KategorieID";
            // 
            // Beschreibung
            // 
            this.Beschreibung.DataPropertyName = "Bezeichnung";
            this.Beschreibung.HeaderText = "Bezeichnung";
            this.Beschreibung.Name = "Beschreibung";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // eingangsrechnungBetragTextBox
            // 
            this.eingangsrechnungBetragTextBox.Location = new System.Drawing.Point(22, 118);
            this.eingangsrechnungBetragTextBox.Name = "eingangsrechnungBetragTextBox";
            this.eingangsrechnungBetragTextBox.Size = new System.Drawing.Size(200, 20);
            this.eingangsrechnungBetragTextBox.TabIndex = 11;
            // 
            // kategorieComboBox
            // 
            this.kategorieComboBox.FormattingEnabled = true;
            this.kategorieComboBox.Items.AddRange(new object[] {
            "Kategorie1",
            "Kategorie2",
            "Kategorie3"});
            this.kategorieComboBox.Location = new System.Drawing.Point(22, 147);
            this.kategorieComboBox.Name = "kategorieComboBox";
            this.kategorieComboBox.Size = new System.Drawing.Size(200, 21);
            this.kategorieComboBox.TabIndex = 13;
            // 
            // addBuchungszeileButton
            // 
            this.addBuchungszeileButton.Location = new System.Drawing.Point(7, 174);
            this.addBuchungszeileButton.Name = "addBuchungszeileButton";
            this.addBuchungszeileButton.Size = new System.Drawing.Size(150, 23);
            this.addBuchungszeileButton.TabIndex = 14;
            this.addBuchungszeileButton.Text = "Buchungszeile hinzufügen";
            this.addBuchungszeileButton.UseVisualStyleBackColor = true;
            this.addBuchungszeileButton.Click += new System.EventHandler(this.AddBuchungszeile);
            // 
            // finishAccountButton
            // 
            this.finishAccountButton.Location = new System.Drawing.Point(6, 204);
            this.finishAccountButton.Name = "finishAccountButton";
            this.finishAccountButton.Size = new System.Drawing.Size(151, 23);
            this.finishAccountButton.TabIndex = 15;
            this.finishAccountButton.Text = "Rechnung abschließen";
            this.finishAccountButton.UseVisualStyleBackColor = true;
            this.finishAccountButton.Click += new System.EventHandler(this.FinishAccount);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(228, 121);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Betrag*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(228, 150);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Kategorie*";
            // 
            // eingangsrechnungMsgLabel
            // 
            this.eingangsrechnungMsgLabel.AutoSize = true;
            this.eingangsrechnungMsgLabel.Location = new System.Drawing.Point(228, 184);
            this.eingangsrechnungMsgLabel.Name = "eingangsrechnungMsgLabel";
            this.eingangsrechnungMsgLabel.Size = new System.Drawing.Size(76, 13);
            this.eingangsrechnungMsgLabel.TabIndex = 24;
            this.eingangsrechnungMsgLabel.Text = "MessageLabel";
            this.eingangsrechnungMsgLabel.Visible = false;
            // 
            // eingangsrechnungBezeichnungTextBox
            // 
            this.eingangsrechnungBezeichnungTextBox.Location = new System.Drawing.Point(22, 67);
            this.eingangsrechnungBezeichnungTextBox.Name = "eingangsrechnungBezeichnungTextBox";
            this.eingangsrechnungBezeichnungTextBox.Size = new System.Drawing.Size(200, 20);
            this.eingangsrechnungBezeichnungTextBox.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(227, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Bez. Eingangsrechnung*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(227, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Rechnungsdatum*";
            // 
            // eingangsrechnungDatePicker
            // 
            this.eingangsrechnungDatePicker.Location = new System.Drawing.Point(22, 37);
            this.eingangsrechnungDatePicker.Name = "eingangsrechnungDatePicker";
            this.eingangsrechnungDatePicker.Size = new System.Drawing.Size(200, 20);
            this.eingangsrechnungDatePicker.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Kontakt*";
            // 
            // existingKontakteComboBox
            // 
            this.existingKontakteComboBox.FormattingEnabled = true;
            this.existingKontakteComboBox.Location = new System.Drawing.Point(22, 6);
            this.existingKontakteComboBox.Name = "existingKontakteComboBox";
            this.existingKontakteComboBox.Size = new System.Drawing.Size(200, 21);
            this.existingKontakteComboBox.TabIndex = 30;
            this.existingKontakteComboBox.DropDown += new System.EventHandler(this.BindFromExistingKontakte);
            // 
            // buchungszeileBezeichnungTextBox
            // 
            this.buchungszeileBezeichnungTextBox.Location = new System.Drawing.Point(22, 92);
            this.buchungszeileBezeichnungTextBox.Name = "buchungszeileBezeichnungTextBox";
            this.buchungszeileBezeichnungTextBox.Size = new System.Drawing.Size(200, 20);
            this.buchungszeileBezeichnungTextBox.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Bez. Buchungszeile*";
            // 
            // resetEingangsrechnungButton
            // 
            this.resetEingangsrechnungButton.Location = new System.Drawing.Point(163, 174);
            this.resetEingangsrechnungButton.Name = "resetEingangsrechnungButton";
            this.resetEingangsrechnungButton.Size = new System.Drawing.Size(59, 23);
            this.resetEingangsrechnungButton.TabIndex = 34;
            this.resetEingangsrechnungButton.Text = "Reset";
            this.resetEingangsrechnungButton.UseVisualStyleBackColor = true;
            this.resetEingangsrechnungButton.Click += new System.EventHandler(this.ResetEingangsrechnung);
            // 
            // rechnungAusgangTab
            // 
            this.rechnungAusgangTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rechnungAusgangTab.Controls.Add(this.ausgangsrechnungMsgLabel);
            this.rechnungAusgangTab.Controls.Add(this.unpaidBalanceTextBox);
            this.rechnungAusgangTab.Controls.Add(this.rechnungstitelTextBox);
            this.rechnungAusgangTab.Controls.Add(this.label35);
            this.rechnungAusgangTab.Controls.Add(this.projekteComboBox);
            this.rechnungAusgangTab.Controls.Add(this.ausgangsrechnungDataGridView);
            this.rechnungAusgangTab.Controls.Add(this.createRechnungButton);
            this.rechnungAusgangTab.Controls.Add(this.label7);
            this.rechnungAusgangTab.Controls.Add(this.label5);
            this.rechnungAusgangTab.Location = new System.Drawing.Point(4, 22);
            this.rechnungAusgangTab.Name = "rechnungAusgangTab";
            this.rechnungAusgangTab.Padding = new System.Windows.Forms.Padding(3);
            this.rechnungAusgangTab.Size = new System.Drawing.Size(747, 233);
            this.rechnungAusgangTab.TabIndex = 0;
            this.rechnungAusgangTab.Text = "Ausgangsrechnung";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Offener Rechnungsbetrag:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Rechnungstitel: ";
            // 
            // createRechnungButton
            // 
            this.createRechnungButton.Location = new System.Drawing.Point(66, 116);
            this.createRechnungButton.Name = "createRechnungButton";
            this.createRechnungButton.Size = new System.Drawing.Size(190, 23);
            this.createRechnungButton.TabIndex = 3;
            this.createRechnungButton.Text = "Rechnung erstellen";
            this.createRechnungButton.UseVisualStyleBackColor = true;
            this.createRechnungButton.Click += new System.EventHandler(this.CreateAusgangsrechnung);
            // 
            // rechnungstitelTextBox
            // 
            this.rechnungstitelTextBox.Location = new System.Drawing.Point(156, 72);
            this.rechnungstitelTextBox.Name = "rechnungstitelTextBox";
            this.rechnungstitelTextBox.Size = new System.Drawing.Size(209, 20);
            this.rechnungstitelTextBox.TabIndex = 4;
            // 
            // ausgangsrechnungDataGridView
            // 
            this.ausgangsrechnungDataGridView.AllowUserToAddRows = false;
            this.ausgangsrechnungDataGridView.AllowUserToDeleteRows = false;
            this.ausgangsrechnungDataGridView.AutoGenerateColumns = false;
            this.ausgangsrechnungDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ausgangsrechnungDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ausgangsrechnungDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ZeitID,
            this.ProjektID,
            this.Bezeichnung,
            this.Stunden,
            this.Stundensatz});
            this.ausgangsrechnungDataGridView.DataSource = this.ausgangsrechnungBindingSource;
            this.ausgangsrechnungDataGridView.Location = new System.Drawing.Point(383, 25);
            this.ausgangsrechnungDataGridView.Name = "ausgangsrechnungDataGridView";
            this.ausgangsrechnungDataGridView.Size = new System.Drawing.Size(346, 183);
            this.ausgangsrechnungDataGridView.TabIndex = 6;
            // 
            // Stundensatz
            // 
            this.Stundensatz.DataPropertyName = "Stundensatz";
            this.Stundensatz.HeaderText = "Stundensatz";
            this.Stundensatz.Name = "Stundensatz";
            // 
            // Stunden
            // 
            this.Stunden.DataPropertyName = "Stunden";
            this.Stunden.HeaderText = "Stunden";
            this.Stunden.Name = "Stunden";
            // 
            // Bezeichnung
            // 
            this.Bezeichnung.DataPropertyName = "Bezeichnung";
            this.Bezeichnung.HeaderText = "Bezeichung";
            this.Bezeichnung.Name = "Bezeichnung";
            // 
            // ProjektID
            // 
            this.ProjektID.DataPropertyName = "ProjektID";
            this.ProjektID.HeaderText = "ProjektID";
            this.ProjektID.Name = "ProjektID";
            this.ProjektID.Visible = false;
            // 
            // ZeitID
            // 
            this.ZeitID.DataPropertyName = "ID";
            this.ZeitID.HeaderText = "ID";
            this.ZeitID.Name = "ZeitID";
            this.ZeitID.Visible = false;
            // 
            // projekteComboBox
            // 
            this.projekteComboBox.FormattingEnabled = true;
            this.projekteComboBox.Location = new System.Drawing.Point(20, 16);
            this.projekteComboBox.Name = "projekteComboBox";
            this.projekteComboBox.Size = new System.Drawing.Size(121, 21);
            this.projekteComboBox.TabIndex = 7;
            this.projekteComboBox.DropDown += new System.EventHandler(this.ausgangsrechnungComboBox_DropDown);
            this.projekteComboBox.SelectedIndexChanged += new System.EventHandler(this.BindFromExistingZeitaufzeichnungen);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(147, 19);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(81, 13);
            this.label35.TabIndex = 8;
            this.label35.Text = "Offene Projekte";
            // 
            // unpaidBalanceTextBox
            // 
            this.unpaidBalanceTextBox.Enabled = false;
            this.unpaidBalanceTextBox.Location = new System.Drawing.Point(156, 45);
            this.unpaidBalanceTextBox.Name = "unpaidBalanceTextBox";
            this.unpaidBalanceTextBox.Size = new System.Drawing.Size(209, 20);
            this.unpaidBalanceTextBox.TabIndex = 9;
            // 
            // ausgangsrechnungMsgLabel
            // 
            this.ausgangsrechnungMsgLabel.AutoSize = true;
            this.ausgangsrechnungMsgLabel.Location = new System.Drawing.Point(17, 160);
            this.ausgangsrechnungMsgLabel.Name = "ausgangsrechnungMsgLabel";
            this.ausgangsrechnungMsgLabel.Size = new System.Drawing.Size(76, 13);
            this.ausgangsrechnungMsgLabel.TabIndex = 25;
            this.ausgangsrechnungMsgLabel.Text = "MessageLabel";
            this.ausgangsrechnungMsgLabel.Visible = false;
            // 
            // rechnungsTabControl
            // 
            this.rechnungsTabControl.Controls.Add(this.rechnungAusgangTab);
            this.rechnungsTabControl.Controls.Add(this.rechnungEingangTab);
            this.rechnungsTabControl.Controls.Add(this.rechnungUmsatzTab);
            this.rechnungsTabControl.Location = new System.Drawing.Point(1, 0);
            this.rechnungsTabControl.Name = "rechnungsTabControl";
            this.rechnungsTabControl.SelectedIndex = 0;
            this.rechnungsTabControl.Size = new System.Drawing.Size(755, 259);
            this.rechnungsTabControl.TabIndex = 2;
            // 
            // rechnungsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rechnungsTabControl);
            this.Name = "rechnungsTab";
            this.Size = new System.Drawing.Size(755, 259);
            ((System.ComponentModel.ISupportInitialize)(this.ausgangsrechnungBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buchungszeilenBindingSource)).EndInit();
            this.rechnungUmsatzTab.ResumeLayout(false);
            this.rechnungUmsatzTab.PerformLayout();
            this.rechnungEingangTab.ResumeLayout(false);
            this.rechnungEingangTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eingangsrechnungDataGridView)).EndInit();
            this.rechnungAusgangTab.ResumeLayout(false);
            this.rechnungAusgangTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ausgangsrechnungDataGridView)).EndInit();
            this.rechnungsTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource buchungszeilenBindingSource;
        private System.Windows.Forms.BindingSource ausgangsrechnungBindingSource;
        private System.Windows.Forms.TabPage rechnungUmsatzTab;
        private System.Windows.Forms.Label umsaetzeMsgLabel;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DateTimePicker dateTimePicker5;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.TabPage rechnungEingangTab;
        private System.Windows.Forms.Button resetEingangsrechnungButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox buchungszeileBezeichnungTextBox;
        private System.Windows.Forms.TextBox eingangsrechnungBezeichnungTextBox;
        private System.Windows.Forms.TextBox eingangsrechnungBetragTextBox;
        private System.Windows.Forms.ComboBox existingKontakteComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker eingangsrechnungDatePicker;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label eingangsrechnungMsgLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button finishAccountButton;
        private System.Windows.Forms.Button addBuchungszeileButton;
        private System.Windows.Forms.ComboBox kategorieComboBox;
        private System.Windows.Forms.DataGridView eingangsrechnungDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Beschreibung;
        private System.Windows.Forms.DataGridViewTextBoxColumn KategorieID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BetragUST;
        private System.Windows.Forms.DataGridViewTextBoxColumn BetragNetto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Buchungsdatum;
        private System.Windows.Forms.TabPage rechnungAusgangTab;
        private System.Windows.Forms.Label ausgangsrechnungMsgLabel;
        private System.Windows.Forms.TextBox unpaidBalanceTextBox;
        private System.Windows.Forms.TextBox rechnungstitelTextBox;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox projekteComboBox;
        private System.Windows.Forms.DataGridView ausgangsrechnungDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZeitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjektID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bezeichnung;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stunden;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stundensatz;
        private System.Windows.Forms.Button createRechnungButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl rechnungsTabControl;
    }
}
