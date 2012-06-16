namespace EPU_Backoffice_Panels
{
    partial class kundenKontakteTab
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
            this.kundenTabControl = new System.Windows.Forms.TabControl();
            this.kundenTabCreate = new System.Windows.Forms.TabPage();
            this.kundeNeuMsgLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.newKundeResetButton = new System.Windows.Forms.Button();
            this.createKundeButton = new System.Windows.Forms.Button();
            this.createKontaktRadioButton = new System.Windows.Forms.RadioButton();
            this.createKundeRadioButton = new System.Windows.Forms.RadioButton();
            this.createKundeNachnameTextBlock = new System.Windows.Forms.TextBox();
            this.createKundeVornameTextBlock = new System.Windows.Forms.TextBox();
            this.kundenTabSearchChange = new System.Windows.Forms.TabPage();
            this.deleteKundeButton = new System.Windows.Forms.Button();
            this.searchKundeMsgLabel = new System.Windows.Forms.Label();
            this.searchKontaktRadioButton = new System.Windows.Forms.RadioButton();
            this.searchKundeRadioButton = new System.Windows.Forms.RadioButton();
            this.kundenSearchDataGridView = new System.Windows.Forms.DataGridView();
            this.kundenSuchenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.changeKundeButton = new System.Windows.Forms.Button();
            this.kundenSearchButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.searchKundeNachnameTextBlock = new System.Windows.Forms.TextBox();
            this.searchKundeVornameTextBlock = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nachname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kundenTabControl.SuspendLayout();
            this.kundenTabCreate.SuspendLayout();
            this.kundenTabSearchChange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kundenSearchDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kundenSuchenBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // kundenTabControl
            // 
            this.kundenTabControl.Controls.Add(this.kundenTabCreate);
            this.kundenTabControl.Controls.Add(this.kundenTabSearchChange);
            this.kundenTabControl.Location = new System.Drawing.Point(0, 0);
            this.kundenTabControl.Name = "kundenTabControl";
            this.kundenTabControl.SelectedIndex = 0;
            this.kundenTabControl.Size = new System.Drawing.Size(755, 259);
            this.kundenTabControl.TabIndex = 2;
            // 
            // kundenTabCreate
            // 
            this.kundenTabCreate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.kundenTabCreate.Controls.Add(this.kundeNeuMsgLabel);
            this.kundenTabCreate.Controls.Add(this.label2);
            this.kundenTabCreate.Controls.Add(this.label1);
            this.kundenTabCreate.Controls.Add(this.newKundeResetButton);
            this.kundenTabCreate.Controls.Add(this.createKundeButton);
            this.kundenTabCreate.Controls.Add(this.createKontaktRadioButton);
            this.kundenTabCreate.Controls.Add(this.createKundeRadioButton);
            this.kundenTabCreate.Controls.Add(this.createKundeNachnameTextBlock);
            this.kundenTabCreate.Controls.Add(this.createKundeVornameTextBlock);
            this.kundenTabCreate.Location = new System.Drawing.Point(4, 22);
            this.kundenTabCreate.Name = "kundenTabCreate";
            this.kundenTabCreate.Padding = new System.Windows.Forms.Padding(3);
            this.kundenTabCreate.Size = new System.Drawing.Size(747, 233);
            this.kundenTabCreate.TabIndex = 0;
            this.kundenTabCreate.Text = "Neu";
            // 
            // kundeNeuMsgLabel
            // 
            this.kundeNeuMsgLabel.AutoSize = true;
            this.kundeNeuMsgLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.kundeNeuMsgLabel.Location = new System.Drawing.Point(327, 100);
            this.kundeNeuMsgLabel.Name = "kundeNeuMsgLabel";
            this.kundeNeuMsgLabel.Size = new System.Drawing.Size(51, 13);
            this.kundeNeuMsgLabel.TabIndex = 11;
            this.kundeNeuMsgLabel.Text = "Errorlabel";
            this.kundeNeuMsgLabel.Visible = false;
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
            // newKundeResetButton
            // 
            this.newKundeResetButton.Location = new System.Drawing.Point(187, 124);
            this.newKundeResetButton.Name = "newKundeResetButton";
            this.newKundeResetButton.Size = new System.Drawing.Size(134, 23);
            this.newKundeResetButton.TabIndex = 5;
            this.newKundeResetButton.Text = "Felder zurücksetzen";
            this.newKundeResetButton.UseVisualStyleBackColor = true;
            this.newKundeResetButton.Click += new System.EventHandler(this.ResetCreateNewKunde);
            // 
            // createKundeButton
            // 
            this.createKundeButton.Location = new System.Drawing.Point(187, 95);
            this.createKundeButton.Name = "createKundeButton";
            this.createKundeButton.Size = new System.Drawing.Size(134, 23);
            this.createKundeButton.TabIndex = 4;
            this.createKundeButton.Text = "Speichern";
            this.createKundeButton.UseVisualStyleBackColor = true;
            this.createKundeButton.Click += new System.EventHandler(this.CreateKundeOrKontakt);
            // 
            // createKontaktRadioButton
            // 
            this.createKontaktRadioButton.AutoSize = true;
            this.createKontaktRadioButton.Location = new System.Drawing.Point(24, 124);
            this.createKontaktRadioButton.Name = "createKontaktRadioButton";
            this.createKontaktRadioButton.Size = new System.Drawing.Size(62, 17);
            this.createKontaktRadioButton.TabIndex = 3;
            this.createKontaktRadioButton.TabStop = true;
            this.createKontaktRadioButton.Text = "Kontakt";
            this.createKontaktRadioButton.UseVisualStyleBackColor = true;
            // 
            // createKundeRadioButton
            // 
            this.createKundeRadioButton.AutoSize = true;
            this.createKundeRadioButton.Checked = true;
            this.createKundeRadioButton.Location = new System.Drawing.Point(24, 101);
            this.createKundeRadioButton.Name = "createKundeRadioButton";
            this.createKundeRadioButton.Size = new System.Drawing.Size(56, 17);
            this.createKundeRadioButton.TabIndex = 2;
            this.createKundeRadioButton.TabStop = true;
            this.createKundeRadioButton.Text = "Kunde";
            this.createKundeRadioButton.UseVisualStyleBackColor = true;
            // 
            // createKundeNachnameTextBlock
            // 
            this.createKundeNachnameTextBlock.Location = new System.Drawing.Point(24, 52);
            this.createKundeNachnameTextBlock.Name = "createKundeNachnameTextBlock";
            this.createKundeNachnameTextBlock.Size = new System.Drawing.Size(297, 20);
            this.createKundeNachnameTextBlock.TabIndex = 1;
            // 
            // createKundeVornameTextBlock
            // 
            this.createKundeVornameTextBlock.Location = new System.Drawing.Point(24, 26);
            this.createKundeVornameTextBlock.Name = "createKundeVornameTextBlock";
            this.createKundeVornameTextBlock.Size = new System.Drawing.Size(297, 20);
            this.createKundeVornameTextBlock.TabIndex = 0;
            // 
            // kundenTabSearchChange
            // 
            this.kundenTabSearchChange.BackColor = System.Drawing.Color.WhiteSmoke;
            this.kundenTabSearchChange.Controls.Add(this.deleteKundeButton);
            this.kundenTabSearchChange.Controls.Add(this.searchKundeMsgLabel);
            this.kundenTabSearchChange.Controls.Add(this.searchKontaktRadioButton);
            this.kundenTabSearchChange.Controls.Add(this.searchKundeRadioButton);
            this.kundenTabSearchChange.Controls.Add(this.kundenSearchDataGridView);
            this.kundenTabSearchChange.Controls.Add(this.changeKundeButton);
            this.kundenTabSearchChange.Controls.Add(this.kundenSearchButton);
            this.kundenTabSearchChange.Controls.Add(this.label4);
            this.kundenTabSearchChange.Controls.Add(this.label3);
            this.kundenTabSearchChange.Controls.Add(this.searchKundeNachnameTextBlock);
            this.kundenTabSearchChange.Controls.Add(this.searchKundeVornameTextBlock);
            this.kundenTabSearchChange.Location = new System.Drawing.Point(4, 22);
            this.kundenTabSearchChange.Name = "kundenTabSearchChange";
            this.kundenTabSearchChange.Padding = new System.Windows.Forms.Padding(3);
            this.kundenTabSearchChange.Size = new System.Drawing.Size(747, 233);
            this.kundenTabSearchChange.TabIndex = 1;
            this.kundenTabSearchChange.Text = "Suchen und Ändern";
            // 
            // deleteKundeButton
            // 
            this.deleteKundeButton.Location = new System.Drawing.Point(81, 141);
            this.deleteKundeButton.Name = "deleteKundeButton";
            this.deleteKundeButton.Size = new System.Drawing.Size(97, 23);
            this.deleteKundeButton.TabIndex = 15;
            this.deleteKundeButton.Text = "Löschen";
            this.deleteKundeButton.UseVisualStyleBackColor = true;
            this.deleteKundeButton.Click += new System.EventHandler(this.ChangeKundeOrKontakt);
            // 
            // searchKundeMsgLabel
            // 
            this.searchKundeMsgLabel.AutoSize = true;
            this.searchKundeMsgLabel.ForeColor = System.Drawing.Color.Red;
            this.searchKundeMsgLabel.Location = new System.Drawing.Point(163, 74);
            this.searchKundeMsgLabel.Name = "searchKundeMsgLabel";
            this.searchKundeMsgLabel.Size = new System.Drawing.Size(50, 13);
            this.searchKundeMsgLabel.TabIndex = 14;
            this.searchKundeMsgLabel.Text = "Message";
            this.searchKundeMsgLabel.Visible = false;
            // 
            // searchKontaktRadioButton
            // 
            this.searchKontaktRadioButton.AutoSize = true;
            this.searchKontaktRadioButton.Location = new System.Drawing.Point(95, 78);
            this.searchKontaktRadioButton.Name = "searchKontaktRadioButton";
            this.searchKontaktRadioButton.Size = new System.Drawing.Size(62, 17);
            this.searchKontaktRadioButton.TabIndex = 8;
            this.searchKontaktRadioButton.TabStop = true;
            this.searchKontaktRadioButton.Text = "Kontakt";
            this.searchKontaktRadioButton.UseVisualStyleBackColor = true;
            this.searchKontaktRadioButton.Click += new System.EventHandler(this.SearchKundenOrKontakte);
            // 
            // searchKundeRadioButton
            // 
            this.searchKundeRadioButton.AutoSize = true;
            this.searchKundeRadioButton.Checked = true;
            this.searchKundeRadioButton.Location = new System.Drawing.Point(24, 78);
            this.searchKundeRadioButton.Name = "searchKundeRadioButton";
            this.searchKundeRadioButton.Size = new System.Drawing.Size(56, 17);
            this.searchKundeRadioButton.TabIndex = 7;
            this.searchKundeRadioButton.TabStop = true;
            this.searchKundeRadioButton.Text = "Kunde";
            this.searchKundeRadioButton.UseVisualStyleBackColor = true;
            this.searchKundeRadioButton.Click += new System.EventHandler(this.SearchKundenOrKontakte);
            // 
            // kundenSearchDataGridView
            // 
            this.kundenSearchDataGridView.AllowUserToAddRows = false;
            this.kundenSearchDataGridView.AllowUserToDeleteRows = false;
            this.kundenSearchDataGridView.AutoGenerateColumns = false;
            this.kundenSearchDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.kundenSearchDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kundenSearchDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Vorname,
            this.Nachname,
            this.Type});
            this.kundenSearchDataGridView.DataSource = this.kundenSuchenBindingSource;
            this.kundenSearchDataGridView.Location = new System.Drawing.Point(366, 25);
            this.kundenSearchDataGridView.MultiSelect = false;
            this.kundenSearchDataGridView.Name = "kundenSearchDataGridView";
            this.kundenSearchDataGridView.ReadOnly = true;
            this.kundenSearchDataGridView.Size = new System.Drawing.Size(363, 183);
            this.kundenSearchDataGridView.TabIndex = 6;
            // 
            // changeKundeButton
            // 
            this.changeKundeButton.Location = new System.Drawing.Point(141, 112);
            this.changeKundeButton.Name = "changeKundeButton";
            this.changeKundeButton.Size = new System.Drawing.Size(97, 23);
            this.changeKundeButton.TabIndex = 5;
            this.changeKundeButton.Text = "Ändern";
            this.changeKundeButton.UseVisualStyleBackColor = true;
            this.changeKundeButton.Click += new System.EventHandler(this.ChangeKundeOrKontakt);
            // 
            // kundenSearchButton
            // 
            this.kundenSearchButton.Location = new System.Drawing.Point(24, 112);
            this.kundenSearchButton.Name = "kundenSearchButton";
            this.kundenSearchButton.Size = new System.Drawing.Size(101, 23);
            this.kundenSearchButton.TabIndex = 4;
            this.kundenSearchButton.Text = "Suchen";
            this.kundenSearchButton.UseVisualStyleBackColor = true;
            this.kundenSearchButton.Click += new System.EventHandler(this.SearchKundenOrKontakte);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vorname";
            // 
            // searchKundeNachnameTextBlock
            // 
            this.searchKundeNachnameTextBlock.Location = new System.Drawing.Point(24, 52);
            this.searchKundeNachnameTextBlock.Name = "searchKundeNachnameTextBlock";
            this.searchKundeNachnameTextBlock.Size = new System.Drawing.Size(214, 20);
            this.searchKundeNachnameTextBlock.TabIndex = 1;
            // 
            // searchKundeVornameTextBlock
            // 
            this.searchKundeVornameTextBlock.Location = new System.Drawing.Point(24, 26);
            this.searchKundeVornameTextBlock.Name = "searchKundeVornameTextBlock";
            this.searchKundeVornameTextBlock.Size = new System.Drawing.Size(214, 20);
            this.searchKundeVornameTextBlock.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MaxInputLength = 327;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Vorname
            // 
            this.Vorname.DataPropertyName = "Vorname";
            this.Vorname.HeaderText = "Vorname";
            this.Vorname.Name = "Vorname";
            this.Vorname.ReadOnly = true;
            // 
            // Nachname
            // 
            this.Nachname.DataPropertyName = "NachnameFirmenname";
            this.Nachname.HeaderText = "Nachname / Firmenname";
            this.Nachname.Name = "Nachname";
            this.Nachname.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Visible = false;
            // 
            // kundenKontakteTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kundenTabControl);
            this.Name = "kundenKontakteTab";
            this.Size = new System.Drawing.Size(755, 259);
            this.kundenTabControl.ResumeLayout(false);
            this.kundenTabCreate.ResumeLayout(false);
            this.kundenTabCreate.PerformLayout();
            this.kundenTabSearchChange.ResumeLayout(false);
            this.kundenTabSearchChange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kundenSearchDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kundenSuchenBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl kundenTabControl;
        private System.Windows.Forms.TabPage kundenTabCreate;
        private System.Windows.Forms.Label kundeNeuMsgLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button newKundeResetButton;
        private System.Windows.Forms.Button createKundeButton;
        private System.Windows.Forms.RadioButton createKontaktRadioButton;
        private System.Windows.Forms.RadioButton createKundeRadioButton;
        private System.Windows.Forms.TextBox createKundeNachnameTextBlock;
        private System.Windows.Forms.TextBox createKundeVornameTextBlock;
        private System.Windows.Forms.TabPage kundenTabSearchChange;
        private System.Windows.Forms.Button deleteKundeButton;
        private System.Windows.Forms.Label searchKundeMsgLabel;
        private System.Windows.Forms.RadioButton searchKontaktRadioButton;
        private System.Windows.Forms.RadioButton searchKundeRadioButton;
        private System.Windows.Forms.DataGridView kundenSearchDataGridView;
        private System.Windows.Forms.Button changeKundeButton;
        private System.Windows.Forms.Button kundenSearchButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox searchKundeNachnameTextBlock;
        private System.Windows.Forms.TextBox searchKundeVornameTextBlock;
        private System.Windows.Forms.BindingSource kundenSuchenBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nachname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
    }
}
