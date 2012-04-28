namespace EPUBackoffice.Gui.Panel
{
    partial class RechnungsTab
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
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.rechnungDruckenTab = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
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
            this.rechnungsTabControl.TabIndex = 1;
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
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "*null*";
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
            this.rechnungEingangTab.Controls.Add(this.label13);
            this.rechnungEingangTab.Controls.Add(this.label12);
            this.rechnungEingangTab.Controls.Add(this.label11);
            this.rechnungEingangTab.Controls.Add(this.label10);
            this.rechnungEingangTab.Controls.Add(this.label9);
            this.rechnungEingangTab.Controls.Add(this.label8);
            this.rechnungEingangTab.Controls.Add(this.button3);
            this.rechnungEingangTab.Controls.Add(this.button2);
            this.rechnungEingangTab.Controls.Add(this.comboBox2);
            this.rechnungEingangTab.Controls.Add(this.dateTimePicker1);
            this.rechnungEingangTab.Controls.Add(this.textBox5);
            this.rechnungEingangTab.Controls.Add(this.textBox4);
            this.rechnungEingangTab.Controls.Add(this.textBox3);
            this.rechnungEingangTab.Controls.Add(this.textBox2);
            this.rechnungEingangTab.Controls.Add(this.dataGridView2);
            this.rechnungEingangTab.Location = new System.Drawing.Point(4, 22);
            this.rechnungEingangTab.Name = "rechnungEingangTab";
            this.rechnungEingangTab.Padding = new System.Windows.Forms.Padding(3);
            this.rechnungEingangTab.Size = new System.Drawing.Size(771, 233);
            this.rechnungEingangTab.TabIndex = 1;
            this.rechnungEingangTab.Text = "Eingangsrechnung";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(228, 150);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Kategorie";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(228, 121);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Betrag";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(228, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "bezeichnung";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(228, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Rechnungsdatum";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(228, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Nachname / Firma*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(228, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Vorname";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(22, 203);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Rechnung abschließen";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 174);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Buchungszeile hinzufügen";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(22, 147);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(200, 21);
            this.comboBox2.TabIndex = 13;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(22, 66);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 12;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(22, 118);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(200, 20);
            this.textBox5.TabIndex = 11;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(22, 40);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(200, 20);
            this.textBox4.TabIndex = 10;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(22, 92);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(200, 20);
            this.textBox3.TabIndex = 9;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(22, 14);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(200, 20);
            this.textBox2.TabIndex = 8;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(383, 25);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(346, 183);
            this.dataGridView2.TabIndex = 0;
            // 
            // rechnungDruckenTab
            // 
            this.rechnungDruckenTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rechnungDruckenTab.Controls.Add(this.label15);
            this.rechnungDruckenTab.Controls.Add(this.comboBox3);
            this.rechnungDruckenTab.Controls.Add(this.button1);
            this.rechnungDruckenTab.Controls.Add(this.radioButton2);
            this.rechnungDruckenTab.Controls.Add(this.radioButton1);
            this.rechnungDruckenTab.Controls.Add(this.label14);
            this.rechnungDruckenTab.Controls.Add(this.comboBox1);
            this.rechnungDruckenTab.Controls.Add(this.button5);
            this.rechnungDruckenTab.Controls.Add(this.button4);
            this.rechnungDruckenTab.Controls.Add(this.dataGridView3);
            this.rechnungDruckenTab.Location = new System.Drawing.Point(4, 22);
            this.rechnungDruckenTab.Name = "rechnungDruckenTab";
            this.rechnungDruckenTab.Padding = new System.Windows.Forms.Padding(3);
            this.rechnungDruckenTab.Size = new System.Drawing.Size(771, 233);
            this.rechnungDruckenTab.TabIndex = 2;
            this.rechnungDruckenTab.Text = "Drucken";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(146, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "Zeitraum";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(19, 52);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 21;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Suchen";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(215, 51);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(117, 17);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Ausgangsrechnung";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(215, 28);
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(19, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(75, 159);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(200, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "Rechnung drucken";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(75, 130);
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
            this.rechnungUmsatzTab.Size = new System.Drawing.Size(771, 233);
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
            // RechnungsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rechnungsTabControl);
            this.Name = "RechnungsTab";
            this.Size = new System.Drawing.Size(755, 259);
            this.rechnungsTabControl.ResumeLayout(false);
            this.rechnungAusgangTab.ResumeLayout(false);
            this.rechnungAusgangTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ausgangsrechnungDataGridView)).EndInit();
            this.unpaidBalancePanel.ResumeLayout(false);
            this.unpaidBalancePanel.PerformLayout();
            this.rechnungEingangTab.ResumeLayout(false);
            this.rechnungEingangTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
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
        private System.Windows.Forms.TabPage rechnungEingangTab;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage rechnungDruckenTab;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBox1;
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
    }
}
