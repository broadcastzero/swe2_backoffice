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
            this.rechnungsTabControl = new System.Windows.Forms.TabControl();
            this.rechnungAusgangTab = new System.Windows.Forms.TabPage();
            this.label35 = new System.Windows.Forms.Label();
            this.ausgangsrechnungComboBox = new System.Windows.Forms.ComboBox();
            this.ausgangsrechnungDataGridView = new System.Windows.Forms.DataGridView();
            this.unpaidBalancePanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.rechnungstitelTextBox = new System.Windows.Forms.TextBox();
            this.createRechnungButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rechnungEingangTab = new System.Windows.Forms.TabPage();
            this.resetEingangsrechnungButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buchungszeileBezeichnungTextBox = new System.Windows.Forms.TextBox();
            this.existingKontakteComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.eingangsrechnungDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.eingangsrechnungBezeichnungTextBox = new System.Windows.Forms.TextBox();
            this.eingangsrechnungMsgLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.finishAccountButton = new System.Windows.Forms.Button();
            this.addBuchungszeileButton = new System.Windows.Forms.Button();
            this.kategorieComboBox = new System.Windows.Forms.ComboBox();
            this.eingangsrechnungBetragTextBox = new System.Windows.Forms.TextBox();
            this.eingangsrechnungDataGridView = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Beschreibung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KategorieID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BetragUST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BetragNetto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Buchungsdatum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buchungszeilenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rechnungDruckenTab = new System.Windows.Forms.TabPage();
            this.druckenTabUntilLabel = new System.Windows.Forms.Label();
            this.druckenTabUntilDatePicker = new System.Windows.Forms.DateTimePicker();
            this.druckenTabFromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.druckenTabFromLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.existingKundenComboBox = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.rechnungUmsatzTab = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.dateTimePicker5 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.rechnungsTabControl.SuspendLayout();
            this.rechnungAusgangTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ausgangsrechnungDataGridView)).BeginInit();
            this.unpaidBalancePanel.SuspendLayout();
            this.rechnungEingangTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eingangsrechnungDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buchungszeilenBindingSource)).BeginInit();
            this.rechnungDruckenTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.rechnungUmsatzTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // rechnungsTabControl
            // 
            this.rechnungsTabControl.Controls.Add(this.rechnungAusgangTab);
            this.rechnungsTabControl.Controls.Add(this.rechnungEingangTab);
            this.rechnungsTabControl.Controls.Add(this.rechnungDruckenTab);
            this.rechnungsTabControl.Controls.Add(this.rechnungUmsatzTab);
            this.rechnungsTabControl.Location = new System.Drawing.Point(1, 0);
            this.rechnungsTabControl.Name = "rechnungsTabControl";
            this.rechnungsTabControl.SelectedIndex = 0;
            this.rechnungsTabControl.Size = new System.Drawing.Size(755, 259);
            this.rechnungsTabControl.TabIndex = 2;
            // 
            // rechnungAusgangTab
            // 
            this.rechnungAusgangTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rechnungAusgangTab.Controls.Add(this.label35);
            this.rechnungAusgangTab.Controls.Add(this.ausgangsrechnungComboBox);
            this.rechnungAusgangTab.Controls.Add(this.ausgangsrechnungDataGridView);
            this.rechnungAusgangTab.Controls.Add(this.unpaidBalancePanel);
            this.rechnungAusgangTab.Controls.Add(this.rechnungstitelTextBox);
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
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(147, 19);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(81, 13);
            this.label35.TabIndex = 8;
            this.label35.Text = "Offene Projekte";
            // 
            // ausgangsrechnungComboBox
            // 
            this.ausgangsrechnungComboBox.FormattingEnabled = true;
            this.ausgangsrechnungComboBox.Location = new System.Drawing.Point(20, 16);
            this.ausgangsrechnungComboBox.Name = "ausgangsrechnungComboBox";
            this.ausgangsrechnungComboBox.Size = new System.Drawing.Size(121, 21);
            this.ausgangsrechnungComboBox.TabIndex = 7;
            this.ausgangsrechnungComboBox.DropDown += new System.EventHandler(this.ausgangsrechnungComboBox_DropDown);
            // 
            // ausgangsrechnungDataGridView
            // 
            this.ausgangsrechnungDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ausgangsrechnungDataGridView.Location = new System.Drawing.Point(383, 25);
            this.ausgangsrechnungDataGridView.Name = "ausgangsrechnungDataGridView";
            this.ausgangsrechnungDataGridView.Size = new System.Drawing.Size(346, 183);
            this.ausgangsrechnungDataGridView.TabIndex = 6;
            // 
            // unpaidBalancePanel
            // 
            this.unpaidBalancePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.unpaidBalancePanel.Controls.Add(this.label6);
            this.unpaidBalancePanel.Location = new System.Drawing.Point(156, 43);
            this.unpaidBalancePanel.Name = "unpaidBalancePanel";
            this.unpaidBalancePanel.Size = new System.Drawing.Size(209, 23);
            this.unpaidBalancePanel.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "0";
            // 
            // rechnungstitelTextBox
            // 
            this.rechnungstitelTextBox.Location = new System.Drawing.Point(156, 72);
            this.rechnungstitelTextBox.Name = "rechnungstitelTextBox";
            this.rechnungstitelTextBox.Size = new System.Drawing.Size(209, 20);
            this.rechnungstitelTextBox.TabIndex = 4;
            // 
            // createRechnungButton
            // 
            this.createRechnungButton.Location = new System.Drawing.Point(66, 116);
            this.createRechnungButton.Name = "createRechnungButton";
            this.createRechnungButton.Size = new System.Drawing.Size(190, 23);
            this.createRechnungButton.TabIndex = 3;
            this.createRechnungButton.Text = "Rechnung erstellen";
            this.createRechnungButton.UseVisualStyleBackColor = true;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Offener Rechnungsbetrag:";
            // 
            // rechnungEingangTab
            // 
            this.rechnungEingangTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rechnungEingangTab.Controls.Add(this.resetEingangsrechnungButton);
            this.rechnungEingangTab.Controls.Add(this.label2);
            this.rechnungEingangTab.Controls.Add(this.buchungszeileBezeichnungTextBox);
            this.rechnungEingangTab.Controls.Add(this.existingKontakteComboBox);
            this.rechnungEingangTab.Controls.Add(this.label1);
            this.rechnungEingangTab.Controls.Add(this.eingangsrechnungDatePicker);
            this.rechnungEingangTab.Controls.Add(this.label10);
            this.rechnungEingangTab.Controls.Add(this.label11);
            this.rechnungEingangTab.Controls.Add(this.eingangsrechnungBezeichnungTextBox);
            this.rechnungEingangTab.Controls.Add(this.eingangsrechnungMsgLabel);
            this.rechnungEingangTab.Controls.Add(this.label13);
            this.rechnungEingangTab.Controls.Add(this.label12);
            this.rechnungEingangTab.Controls.Add(this.finishAccountButton);
            this.rechnungEingangTab.Controls.Add(this.addBuchungszeileButton);
            this.rechnungEingangTab.Controls.Add(this.kategorieComboBox);
            this.rechnungEingangTab.Controls.Add(this.eingangsrechnungBetragTextBox);
            this.rechnungEingangTab.Controls.Add(this.eingangsrechnungDataGridView);
            this.rechnungEingangTab.Location = new System.Drawing.Point(4, 22);
            this.rechnungEingangTab.Name = "rechnungEingangTab";
            this.rechnungEingangTab.Padding = new System.Windows.Forms.Padding(3);
            this.rechnungEingangTab.Size = new System.Drawing.Size(747, 233);
            this.rechnungEingangTab.TabIndex = 1;
            this.rechnungEingangTab.Text = "Eingangsrechnung";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Bez. Buchungszeile*";
            // 
            // buchungszeileBezeichnungTextBox
            // 
            this.buchungszeileBezeichnungTextBox.Location = new System.Drawing.Point(22, 92);
            this.buchungszeileBezeichnungTextBox.Name = "buchungszeileBezeichnungTextBox";
            this.buchungszeileBezeichnungTextBox.Size = new System.Drawing.Size(200, 20);
            this.buchungszeileBezeichnungTextBox.TabIndex = 32;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Kontakt*";
            // 
            // eingangsrechnungDatePicker
            // 
            this.eingangsrechnungDatePicker.Location = new System.Drawing.Point(22, 37);
            this.eingangsrechnungDatePicker.Name = "eingangsrechnungDatePicker";
            this.eingangsrechnungDatePicker.Size = new System.Drawing.Size(200, 20);
            this.eingangsrechnungDatePicker.TabIndex = 27;
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(227, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Bez. Eingangsrechnung*";
            // 
            // eingangsrechnungBezeichnungTextBox
            // 
            this.eingangsrechnungBezeichnungTextBox.Location = new System.Drawing.Point(22, 67);
            this.eingangsrechnungBezeichnungTextBox.Name = "eingangsrechnungBezeichnungTextBox";
            this.eingangsrechnungBezeichnungTextBox.Size = new System.Drawing.Size(200, 20);
            this.eingangsrechnungBezeichnungTextBox.TabIndex = 26;
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(228, 150);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Kategorie*";
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
            // eingangsrechnungBetragTextBox
            // 
            this.eingangsrechnungBetragTextBox.Location = new System.Drawing.Point(22, 118);
            this.eingangsrechnungBetragTextBox.Name = "eingangsrechnungBetragTextBox";
            this.eingangsrechnungBetragTextBox.Size = new System.Drawing.Size(200, 20);
            this.eingangsrechnungBetragTextBox.TabIndex = 11;
            // 
            // eingangsrechnungDataGridView
            // 
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
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // Beschreibung
            // 
            this.Beschreibung.DataPropertyName = "Beschreibung";
            this.Beschreibung.HeaderText = "Beschreibung";
            this.Beschreibung.Name = "Beschreibung";
            // 
            // KategorieID
            // 
            this.KategorieID.DataPropertyName = "KategorieID";
            this.KategorieID.HeaderText = "KategorieID";
            this.KategorieID.Name = "KategorieID";
            // 
            // BetragUST
            // 
            this.BetragUST.DataPropertyName = "BetragUST";
            this.BetragUST.HeaderText = "BetragUST";
            this.BetragUST.Name = "BetragUST";
            this.BetragUST.Visible = false;
            // 
            // BetragNetto
            // 
            this.BetragNetto.DataPropertyName = "BetragNetto";
            this.BetragNetto.HeaderText = "BetragNetto";
            this.BetragNetto.Name = "BetragNetto";
            // 
            // Buchungsdatum
            // 
            this.Buchungsdatum.DataPropertyName = "Buchungsdatum";
            this.Buchungsdatum.HeaderText = "Buchungsdatum";
            this.Buchungsdatum.Name = "Buchungsdatum";
            // 
            // rechnungDruckenTab
            // 
            this.rechnungDruckenTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rechnungDruckenTab.Controls.Add(this.druckenTabUntilLabel);
            this.rechnungDruckenTab.Controls.Add(this.druckenTabUntilDatePicker);
            this.rechnungDruckenTab.Controls.Add(this.druckenTabFromDatePicker);
            this.rechnungDruckenTab.Controls.Add(this.druckenTabFromLabel);
            this.rechnungDruckenTab.Controls.Add(this.button1);
            this.rechnungDruckenTab.Controls.Add(this.radioButton2);
            this.rechnungDruckenTab.Controls.Add(this.radioButton1);
            this.rechnungDruckenTab.Controls.Add(this.label14);
            this.rechnungDruckenTab.Controls.Add(this.existingKundenComboBox);
            this.rechnungDruckenTab.Controls.Add(this.button5);
            this.rechnungDruckenTab.Controls.Add(this.button4);
            this.rechnungDruckenTab.Controls.Add(this.dataGridView3);
            this.rechnungDruckenTab.Location = new System.Drawing.Point(4, 22);
            this.rechnungDruckenTab.Name = "rechnungDruckenTab";
            this.rechnungDruckenTab.Padding = new System.Windows.Forms.Padding(3);
            this.rechnungDruckenTab.Size = new System.Drawing.Size(747, 233);
            this.rechnungDruckenTab.TabIndex = 2;
            this.rechnungDruckenTab.Text = "Drucken";
            // 
            // druckenTabUntilLabel
            // 
            this.druckenTabUntilLabel.AutoSize = true;
            this.druckenTabUntilLabel.Location = new System.Drawing.Point(225, 85);
            this.druckenTabUntilLabel.Name = "druckenTabUntilLabel";
            this.druckenTabUntilLabel.Size = new System.Drawing.Size(21, 13);
            this.druckenTabUntilLabel.TabIndex = 25;
            this.druckenTabUntilLabel.Text = "Bis";
            // 
            // druckenTabUntilDatePicker
            // 
            this.druckenTabUntilDatePicker.Location = new System.Drawing.Point(19, 78);
            this.druckenTabUntilDatePicker.Name = "druckenTabUntilDatePicker";
            this.druckenTabUntilDatePicker.Size = new System.Drawing.Size(200, 20);
            this.druckenTabUntilDatePicker.TabIndex = 24;
            // 
            // druckenTabFromDatePicker
            // 
            this.druckenTabFromDatePicker.Location = new System.Drawing.Point(19, 52);
            this.druckenTabFromDatePicker.Name = "druckenTabFromDatePicker";
            this.druckenTabFromDatePicker.Size = new System.Drawing.Size(200, 20);
            this.druckenTabFromDatePicker.TabIndex = 23;
            // 
            // druckenTabFromLabel
            // 
            this.druckenTabFromLabel.AutoSize = true;
            this.druckenTabFromLabel.Location = new System.Drawing.Point(225, 59);
            this.druckenTabFromLabel.Name = "druckenTabFromLabel";
            this.druckenTabFromLabel.Size = new System.Drawing.Size(26, 13);
            this.druckenTabFromLabel.TabIndex = 22;
            this.druckenTabFromLabel.Text = "Von";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Suchen";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(19, 133);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(117, 17);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.Text = "Ausgangsrechnung";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(19, 110);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(114, 17);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Eingangsrechnung";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(146, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Kunde";
            // 
            // existingKundenComboBox
            // 
            this.existingKundenComboBox.FormattingEnabled = true;
            this.existingKundenComboBox.Location = new System.Drawing.Point(19, 25);
            this.existingKundenComboBox.Name = "existingKundenComboBox";
            this.existingKundenComboBox.Size = new System.Drawing.Size(121, 21);
            this.existingKundenComboBox.TabIndex = 9;
            this.existingKundenComboBox.DropDown += new System.EventHandler(this.BindToExistingKundenComboBox);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(177, 185);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(200, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "Rechnung drucken";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(177, 156);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(200, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Als PDF anzeigen";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(383, 25);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(346, 183);
            this.dataGridView3.TabIndex = 0;
            // 
            // rechnungUmsatzTab
            // 
            this.rechnungUmsatzTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rechnungUmsatzTab.Controls.Add(this.label19);
            this.rechnungUmsatzTab.Controls.Add(this.label18);
            this.rechnungUmsatzTab.Controls.Add(this.checkBox4);
            this.rechnungUmsatzTab.Controls.Add(this.checkBox3);
            this.rechnungUmsatzTab.Controls.Add(this.button7);
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
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(225, 43);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(21, 13);
            this.label19.TabIndex = 7;
            this.label19.Text = "Bis";
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
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(19, 88);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(68, 17);
            this.checkBox4.TabIndex = 5;
            this.checkBox4.Text = "Ausgang";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(19, 66);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(65, 17);
            this.checkBox3.TabIndex = 4;
            this.checkBox3.Text = "Eingang";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(19, 142);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(200, 23);
            this.button7.TabIndex = 3;
            this.button7.Text = "Bericht drucken";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(19, 111);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(200, 23);
            this.button6.TabIndex = 2;
            this.button6.Text = "Als PDF anzeigen";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker5
            // 
            this.dateTimePicker5.Location = new System.Drawing.Point(19, 40);
            this.dateTimePicker5.Name = "dateTimePicker5";
            this.dateTimePicker5.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker5.TabIndex = 1;
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.Location = new System.Drawing.Point(19, 14);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker4.TabIndex = 0;
            // 
            // rechnungsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rechnungsTabControl);
            this.Name = "rechnungsTab";
            this.Size = new System.Drawing.Size(755, 259);
            this.rechnungsTabControl.ResumeLayout(false);
            this.rechnungAusgangTab.ResumeLayout(false);
            this.rechnungAusgangTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ausgangsrechnungDataGridView)).EndInit();
            this.unpaidBalancePanel.ResumeLayout(false);
            this.unpaidBalancePanel.PerformLayout();
            this.rechnungEingangTab.ResumeLayout(false);
            this.rechnungEingangTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eingangsrechnungDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buchungszeilenBindingSource)).EndInit();
            this.rechnungDruckenTab.ResumeLayout(false);
            this.rechnungDruckenTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.rechnungUmsatzTab.ResumeLayout(false);
            this.rechnungUmsatzTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl rechnungsTabControl;
        private System.Windows.Forms.TabPage rechnungAusgangTab;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox ausgangsrechnungComboBox;
        private System.Windows.Forms.DataGridView ausgangsrechnungDataGridView;
        private System.Windows.Forms.Panel unpaidBalancePanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox rechnungstitelTextBox;
        private System.Windows.Forms.Button createRechnungButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage rechnungDruckenTab;
        private System.Windows.Forms.Label druckenTabFromLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox existingKundenComboBox;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.TabPage rechnungUmsatzTab;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DateTimePicker dateTimePicker5;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.TabPage rechnungEingangTab;
        private System.Windows.Forms.Label eingangsrechnungMsgLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button finishAccountButton;
        private System.Windows.Forms.Button addBuchungszeileButton;
        private System.Windows.Forms.ComboBox kategorieComboBox;
        private System.Windows.Forms.TextBox eingangsrechnungBetragTextBox;
        private System.Windows.Forms.DataGridView eingangsrechnungDataGridView;
        private System.Windows.Forms.Label druckenTabUntilLabel;
        private System.Windows.Forms.DateTimePicker druckenTabUntilDatePicker;
        private System.Windows.Forms.DateTimePicker druckenTabFromDatePicker;
        private System.Windows.Forms.ComboBox existingKontakteComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker eingangsrechnungDatePicker;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox eingangsrechnungBezeichnungTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox buchungszeileBezeichnungTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Beschreibung;
        private System.Windows.Forms.DataGridViewTextBoxColumn KategorieID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BetragUST;
        private System.Windows.Forms.DataGridViewTextBoxColumn BetragNetto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Buchungsdatum;
        private System.Windows.Forms.BindingSource buchungszeilenBindingSource;
        private System.Windows.Forms.Button resetEingangsrechnungButton;
    }
}
