namespace EPU_Backoffice_Panels
{
    partial class projektTab
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
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.projektErstellenTab = new System.Windows.Forms.TabPage();
            this.projektNeuMsgLabel = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.projektErstellenAngebotCombobox = new System.Windows.Forms.ComboBox();
            this.projektNeuSpeichernButton = new System.Windows.Forms.Button();
            this.projektNeuProjekttitelTextbox = new System.Windows.Forms.TextBox();
            this.projektNeuStartdatumDatepicker = new System.Windows.Forms.DateTimePicker();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.projektSuchenTab = new System.Windows.Forms.TabPage();
            this.projektSuchenMessageLabel = new System.Windows.Forms.Label();
            this.projektSuchenDeleteButton = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.projektSuchenPrintButton = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.projektSuchenBisDatepicker = new System.Windows.Forms.DateTimePicker();
            this.projektSuchenVonDatepicker = new System.Windows.Forms.DateTimePicker();
            this.projektSuchenKundeCombobox = new System.Windows.Forms.ComboBox();
            this.projektSuchenChangeButton = new System.Windows.Forms.Button();
            this.projektSuchenSearchButton = new System.Windows.Forms.Button();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.projektSearchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AngebotID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Projektname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Projektstart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl4.SuspendLayout();
            this.projektErstellenTab.SuspendLayout();
            this.projektSuchenTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projektSearchBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.projektErstellenTab);
            this.tabControl4.Controls.Add(this.projektSuchenTab);
            this.tabControl4.Location = new System.Drawing.Point(0, 1);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(755, 259);
            this.tabControl4.TabIndex = 2;
            // 
            // projektErstellenTab
            // 
            this.projektErstellenTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.projektErstellenTab.Controls.Add(this.projektNeuMsgLabel);
            this.projektErstellenTab.Controls.Add(this.label25);
            this.projektErstellenTab.Controls.Add(this.projektErstellenAngebotCombobox);
            this.projektErstellenTab.Controls.Add(this.projektNeuSpeichernButton);
            this.projektErstellenTab.Controls.Add(this.projektNeuProjekttitelTextbox);
            this.projektErstellenTab.Controls.Add(this.projektNeuStartdatumDatepicker);
            this.projektErstellenTab.Controls.Add(this.label38);
            this.projektErstellenTab.Controls.Add(this.label37);
            this.projektErstellenTab.Location = new System.Drawing.Point(4, 22);
            this.projektErstellenTab.Name = "projektErstellenTab";
            this.projektErstellenTab.Padding = new System.Windows.Forms.Padding(3);
            this.projektErstellenTab.Size = new System.Drawing.Size(747, 233);
            this.projektErstellenTab.TabIndex = 0;
            this.projektErstellenTab.Text = "Erstellen";
            // 
            // projektNeuMsgLabel
            // 
            this.projektNeuMsgLabel.AutoSize = true;
            this.projektNeuMsgLabel.ForeColor = System.Drawing.Color.Red;
            this.projektNeuMsgLabel.Location = new System.Drawing.Point(13, 120);
            this.projektNeuMsgLabel.Name = "projektNeuMsgLabel";
            this.projektNeuMsgLabel.Size = new System.Drawing.Size(27, 13);
            this.projektNeuMsgLabel.TabIndex = 15;
            this.projektNeuMsgLabel.Text = "Msg";
            this.projektNeuMsgLabel.Visible = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(222, 44);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(54, 13);
            this.label25.TabIndex = 7;
            this.label25.Text = "Angebot *";
            // 
            // projektErstellenAngebotCombobox
            // 
            this.projektErstellenAngebotCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.projektErstellenAngebotCombobox.FormattingEnabled = true;
            this.projektErstellenAngebotCombobox.Location = new System.Drawing.Point(16, 41);
            this.projektErstellenAngebotCombobox.Name = "projektErstellenAngebotCombobox";
            this.projektErstellenAngebotCombobox.Size = new System.Drawing.Size(200, 21);
            this.projektErstellenAngebotCombobox.TabIndex = 6;
            this.projektErstellenAngebotCombobox.DropDown += new System.EventHandler(this.BindFromExistingAngeboteToComboBox);
            // 
            // projektNeuSpeichernButton
            // 
            this.projektNeuSpeichernButton.Location = new System.Drawing.Point(16, 94);
            this.projektNeuSpeichernButton.Name = "projektNeuSpeichernButton";
            this.projektNeuSpeichernButton.Size = new System.Drawing.Size(200, 23);
            this.projektNeuSpeichernButton.TabIndex = 4;
            this.projektNeuSpeichernButton.Text = "Speichern";
            this.projektNeuSpeichernButton.UseVisualStyleBackColor = true;
            this.projektNeuSpeichernButton.Click += new System.EventHandler(this.CreateProjekt);
            // 
            // projektNeuProjekttitelTextbox
            // 
            this.projektNeuProjekttitelTextbox.Location = new System.Drawing.Point(16, 17);
            this.projektNeuProjekttitelTextbox.Name = "projektNeuProjekttitelTextbox";
            this.projektNeuProjekttitelTextbox.Size = new System.Drawing.Size(200, 20);
            this.projektNeuProjekttitelTextbox.TabIndex = 3;
            // 
            // projektNeuStartdatumDatepicker
            // 
            this.projektNeuStartdatumDatepicker.Location = new System.Drawing.Point(16, 68);
            this.projektNeuStartdatumDatepicker.Name = "projektNeuStartdatumDatepicker";
            this.projektNeuStartdatumDatepicker.Size = new System.Drawing.Size(200, 20);
            this.projektNeuStartdatumDatepicker.TabIndex = 2;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(222, 74);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(65, 13);
            this.label38.TabIndex = 1;
            this.label38.Text = "Startdatum *";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(222, 20);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(63, 13);
            this.label37.TabIndex = 0;
            this.label37.Text = "Projekttitel *";
            // 
            // projektSuchenTab
            // 
            this.projektSuchenTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.projektSuchenTab.Controls.Add(this.projektSuchenMessageLabel);
            this.projektSuchenTab.Controls.Add(this.projektSuchenDeleteButton);
            this.projektSuchenTab.Controls.Add(this.label34);
            this.projektSuchenTab.Controls.Add(this.projektSuchenPrintButton);
            this.projektSuchenTab.Controls.Add(this.label28);
            this.projektSuchenTab.Controls.Add(this.label27);
            this.projektSuchenTab.Controls.Add(this.projektSuchenBisDatepicker);
            this.projektSuchenTab.Controls.Add(this.projektSuchenVonDatepicker);
            this.projektSuchenTab.Controls.Add(this.projektSuchenKundeCombobox);
            this.projektSuchenTab.Controls.Add(this.projektSuchenChangeButton);
            this.projektSuchenTab.Controls.Add(this.projektSuchenSearchButton);
            this.projektSuchenTab.Controls.Add(this.dataGridView4);
            this.projektSuchenTab.Location = new System.Drawing.Point(4, 22);
            this.projektSuchenTab.Name = "projektSuchenTab";
            this.projektSuchenTab.Padding = new System.Windows.Forms.Padding(3);
            this.projektSuchenTab.Size = new System.Drawing.Size(747, 233);
            this.projektSuchenTab.TabIndex = 1;
            this.projektSuchenTab.Text = "Suchen";
            // 
            // projektSuchenMessageLabel
            // 
            this.projektSuchenMessageLabel.AutoSize = true;
            this.projektSuchenMessageLabel.Location = new System.Drawing.Point(225, 125);
            this.projektSuchenMessageLabel.Name = "projektSuchenMessageLabel";
            this.projektSuchenMessageLabel.Size = new System.Drawing.Size(76, 13);
            this.projektSuchenMessageLabel.TabIndex = 16;
            this.projektSuchenMessageLabel.Text = "MessageLabel";
            // 
            // projektSuchenDeleteButton
            // 
            this.projektSuchenDeleteButton.Location = new System.Drawing.Point(120, 178);
            this.projektSuchenDeleteButton.Name = "projektSuchenDeleteButton";
            this.projektSuchenDeleteButton.Size = new System.Drawing.Size(95, 23);
            this.projektSuchenDeleteButton.TabIndex = 15;
            this.projektSuchenDeleteButton.Text = "Löschen";
            this.projektSuchenDeleteButton.UseVisualStyleBackColor = true;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(225, 24);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(38, 13);
            this.label34.TabIndex = 14;
            this.label34.Text = "Kunde";
            // 
            // projektSuchenPrintButton
            // 
            this.projektSuchenPrintButton.Location = new System.Drawing.Point(15, 149);
            this.projektSuchenPrintButton.Name = "projektSuchenPrintButton";
            this.projektSuchenPrintButton.Size = new System.Drawing.Size(200, 23);
            this.projektSuchenPrintButton.TabIndex = 13;
            this.projektSuchenPrintButton.Text = "Drucken";
            this.projektSuchenPrintButton.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(221, 100);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(21, 13);
            this.label28.TabIndex = 12;
            this.label28.Text = "Bis";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(221, 74);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(26, 13);
            this.label27.TabIndex = 11;
            this.label27.Text = "Von";
            // 
            // projektSuchenBisDatepicker
            // 
            this.projektSuchenBisDatepicker.Location = new System.Drawing.Point(15, 94);
            this.projektSuchenBisDatepicker.Name = "projektSuchenBisDatepicker";
            this.projektSuchenBisDatepicker.Size = new System.Drawing.Size(200, 20);
            this.projektSuchenBisDatepicker.TabIndex = 10;
            // 
            // projektSuchenVonDatepicker
            // 
            this.projektSuchenVonDatepicker.Location = new System.Drawing.Point(15, 68);
            this.projektSuchenVonDatepicker.Name = "projektSuchenVonDatepicker";
            this.projektSuchenVonDatepicker.Size = new System.Drawing.Size(200, 20);
            this.projektSuchenVonDatepicker.TabIndex = 9;
            // 
            // projektSuchenKundeCombobox
            // 
            this.projektSuchenKundeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.projektSuchenKundeCombobox.FormattingEnabled = true;
            this.projektSuchenKundeCombobox.Location = new System.Drawing.Point(15, 16);
            this.projektSuchenKundeCombobox.Name = "projektSuchenKundeCombobox";
            this.projektSuchenKundeCombobox.Size = new System.Drawing.Size(200, 21);
            this.projektSuchenKundeCombobox.TabIndex = 5;
            this.projektSuchenKundeCombobox.DropDown += new System.EventHandler(this.projektSuchenKundeCombobox_DropDown);
            // 
            // projektSuchenChangeButton
            // 
            this.projektSuchenChangeButton.Location = new System.Drawing.Point(15, 178);
            this.projektSuchenChangeButton.Name = "projektSuchenChangeButton";
            this.projektSuchenChangeButton.Size = new System.Drawing.Size(99, 23);
            this.projektSuchenChangeButton.TabIndex = 2;
            this.projektSuchenChangeButton.Text = "Ändern";
            this.projektSuchenChangeButton.UseVisualStyleBackColor = true;
            // 
            // projektSuchenSearchButton
            // 
            this.projektSuchenSearchButton.Location = new System.Drawing.Point(15, 120);
            this.projektSuchenSearchButton.Name = "projektSuchenSearchButton";
            this.projektSuchenSearchButton.Size = new System.Drawing.Size(200, 23);
            this.projektSuchenSearchButton.TabIndex = 1;
            this.projektSuchenSearchButton.Text = "Suchen";
            this.projektSuchenSearchButton.UseVisualStyleBackColor = true;
            this.projektSuchenSearchButton.Click += new System.EventHandler(this.projektSuchenSearchButton_Click);
            // 
            // dataGridView4
            // 
            this.dataGridView4.AutoGenerateColumns = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.AngebotID,
            this.Projektname,
            this.Projektstart});
            this.dataGridView4.DataSource = this.projektSearchBindingSource;
            this.dataGridView4.Location = new System.Drawing.Point(366, 25);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(363, 183);
            this.dataGridView4.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // AngebotID
            // 
            this.AngebotID.DataPropertyName = "AngebotID";
            this.AngebotID.HeaderText = "Angebot";
            this.AngebotID.Name = "AngebotID";
            this.AngebotID.Visible = false;
            // 
            // Projektname
            // 
            this.Projektname.DataPropertyName = "Projektname";
            this.Projektname.HeaderText = "Name";
            this.Projektname.Name = "Projektname";
            // 
            // Projektstart
            // 
            this.Projektstart.DataPropertyName = "Projektstart";
            this.Projektstart.HeaderText = "Startdatum";
            this.Projektstart.Name = "Projektstart";
            // 
            // projektTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl4);
            this.Name = "projektTab";
            this.Size = new System.Drawing.Size(755, 259);
            this.tabControl4.ResumeLayout(false);
            this.projektErstellenTab.ResumeLayout(false);
            this.projektErstellenTab.PerformLayout();
            this.projektSuchenTab.ResumeLayout(false);
            this.projektSuchenTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projektSearchBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage projektErstellenTab;
        private System.Windows.Forms.Label projektNeuMsgLabel;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox projektErstellenAngebotCombobox;
        private System.Windows.Forms.Button projektNeuSpeichernButton;
        private System.Windows.Forms.TextBox projektNeuProjekttitelTextbox;
        private System.Windows.Forms.DateTimePicker projektNeuStartdatumDatepicker;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TabPage projektSuchenTab;
        private System.Windows.Forms.Button projektSuchenDeleteButton;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button projektSuchenPrintButton;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.DateTimePicker projektSuchenBisDatepicker;
        private System.Windows.Forms.DateTimePicker projektSuchenVonDatepicker;
        private System.Windows.Forms.ComboBox projektSuchenKundeCombobox;
        private System.Windows.Forms.Button projektSuchenChangeButton;
        private System.Windows.Forms.Button projektSuchenSearchButton;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Label projektSuchenMessageLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AngebotID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Projektname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Projektstart;
        private System.Windows.Forms.BindingSource projektSearchBindingSource;
    }
}
