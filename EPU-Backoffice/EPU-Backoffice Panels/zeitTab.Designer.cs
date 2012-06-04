namespace EPU_Backoffice_Panels
{
    partial class zeitTab
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
            this.zeitaufzeichnungDataGridView = new System.Windows.Forms.DataGridView();
            this.label39 = new System.Windows.Forms.Label();
            this.zeiterfassungStundensatzTextBox = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.zeiterfassungDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.zeiterfassungCombobox = new System.Windows.Forms.ComboBox();
            this.zeiterfassungSubmitButton = new System.Windows.Forms.Button();
            this.zeiterfassungHoursTextbox = new System.Windows.Forms.TextBox();
            this.zeiterfassungMsgLabel = new System.Windows.Forms.Label();
            this.zeiterfassungBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjektID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stunden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bezeichnung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stundensatz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.zeitaufzeichnungDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zeiterfassungBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // zeitaufzeichnungDataGridView
            // 
            this.zeitaufzeichnungDataGridView.AutoGenerateColumns = false;
            this.zeitaufzeichnungDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zeitaufzeichnungDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ProjektID,
            this.Stunden,
            this.Bezeichnung,
            this.Stundensatz});
            this.zeitaufzeichnungDataGridView.DataSource = this.zeiterfassungBindingSource;
            this.zeitaufzeichnungDataGridView.Location = new System.Drawing.Point(361, 39);
            this.zeitaufzeichnungDataGridView.Name = "zeitaufzeichnungDataGridView";
            this.zeitaufzeichnungDataGridView.Size = new System.Drawing.Size(363, 183);
            this.zeitaufzeichnungDataGridView.TabIndex = 29;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(237, 118);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(73, 13);
            this.label39.TabIndex = 28;
            this.label39.Text = "Stundensatz *";
            // 
            // zeiterfassungStundensatzTextBox
            // 
            this.zeiterfassungStundensatzTextBox.Location = new System.Drawing.Point(31, 115);
            this.zeiterfassungStundensatzTextBox.Name = "zeiterfassungStundensatzTextBox";
            this.zeiterfassungStundensatzTextBox.Size = new System.Drawing.Size(200, 20);
            this.zeiterfassungStundensatzTextBox.TabIndex = 27;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(237, 92);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(79, 13);
            this.label31.TabIndex = 26;
            this.label31.Text = "Beschreibung *";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(237, 66);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(43, 13);
            this.label30.TabIndex = 25;
            this.label30.Text = "Dauer *";
            // 
            // zeiterfassungDescriptionTextBox
            // 
            this.zeiterfassungDescriptionTextBox.Location = new System.Drawing.Point(31, 89);
            this.zeiterfassungDescriptionTextBox.Name = "zeiterfassungDescriptionTextBox";
            this.zeiterfassungDescriptionTextBox.Size = new System.Drawing.Size(200, 20);
            this.zeiterfassungDescriptionTextBox.TabIndex = 22;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(237, 39);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 13);
            this.label29.TabIndex = 24;
            this.label29.Text = "Projekttitel *";
            // 
            // zeiterfassungCombobox
            // 
            this.zeiterfassungCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.zeiterfassungCombobox.FormattingEnabled = true;
            this.zeiterfassungCombobox.Location = new System.Drawing.Point(31, 36);
            this.zeiterfassungCombobox.Name = "zeiterfassungCombobox";
            this.zeiterfassungCombobox.Size = new System.Drawing.Size(200, 21);
            this.zeiterfassungCombobox.TabIndex = 20;
            this.zeiterfassungCombobox.DropDown += new System.EventHandler(this.zeiterfassungCombobox_DropDown);
            // 
            // zeiterfassungSubmitButton
            // 
            this.zeiterfassungSubmitButton.Location = new System.Drawing.Point(31, 141);
            this.zeiterfassungSubmitButton.Name = "zeiterfassungSubmitButton";
            this.zeiterfassungSubmitButton.Size = new System.Drawing.Size(200, 23);
            this.zeiterfassungSubmitButton.TabIndex = 23;
            this.zeiterfassungSubmitButton.Text = "Hinzufügen";
            this.zeiterfassungSubmitButton.UseVisualStyleBackColor = true;
            this.zeiterfassungSubmitButton.Click += new System.EventHandler(this.CreateZeiterfassung);
            // 
            // zeiterfassungHoursTextbox
            // 
            this.zeiterfassungHoursTextbox.Location = new System.Drawing.Point(31, 63);
            this.zeiterfassungHoursTextbox.Name = "zeiterfassungHoursTextbox";
            this.zeiterfassungHoursTextbox.Size = new System.Drawing.Size(200, 20);
            this.zeiterfassungHoursTextbox.TabIndex = 21;
            // 
            // zeiterfassungMsgLabel
            // 
            this.zeiterfassungMsgLabel.AutoSize = true;
            this.zeiterfassungMsgLabel.Location = new System.Drawing.Point(237, 146);
            this.zeiterfassungMsgLabel.Name = "zeiterfassungMsgLabel";
            this.zeiterfassungMsgLabel.Size = new System.Drawing.Size(55, 13);
            this.zeiterfassungMsgLabel.TabIndex = 30;
            this.zeiterfassungMsgLabel.Text = "ErrorLabel";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ZeitaufzeichnunsgID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // ProjektID
            // 
            this.ProjektID.DataPropertyName = "ProjektID";
            this.ProjektID.HeaderText = "ProjektID";
            this.ProjektID.Name = "ProjektID";
            this.ProjektID.Visible = false;
            // 
            // Stunden
            // 
            this.Stunden.DataPropertyName = "Stunden";
            this.Stunden.HeaderText = "Dauer";
            this.Stunden.Name = "Stunden";
            // 
            // Bezeichnung
            // 
            this.Bezeichnung.DataPropertyName = "Bezeichnung";
            this.Bezeichnung.HeaderText = "Beschreibung";
            this.Bezeichnung.Name = "Bezeichnung";
            // 
            // Stundensatz
            // 
            this.Stundensatz.DataPropertyName = "Stundensatz";
            this.Stundensatz.HeaderText = "Strundensatz";
            this.Stundensatz.Name = "Stundensatz";
            // 
            // zeitTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.zeiterfassungMsgLabel);
            this.Controls.Add(this.zeitaufzeichnungDataGridView);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.zeiterfassungStundensatzTextBox);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.zeiterfassungDescriptionTextBox);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.zeiterfassungCombobox);
            this.Controls.Add(this.zeiterfassungSubmitButton);
            this.Controls.Add(this.zeiterfassungHoursTextbox);
            this.Name = "zeitTab";
            this.Size = new System.Drawing.Size(755, 259);
            ((System.ComponentModel.ISupportInitialize)(this.zeitaufzeichnungDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zeiterfassungBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView zeitaufzeichnungDataGridView;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox zeiterfassungStundensatzTextBox;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox zeiterfassungDescriptionTextBox;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox zeiterfassungCombobox;
        private System.Windows.Forms.Button zeiterfassungSubmitButton;
        private System.Windows.Forms.TextBox zeiterfassungHoursTextbox;
        private System.Windows.Forms.Label zeiterfassungMsgLabel;
        private System.Windows.Forms.BindingSource zeiterfassungBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjektID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stunden;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bezeichnung;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stundensatz;
    }
}
