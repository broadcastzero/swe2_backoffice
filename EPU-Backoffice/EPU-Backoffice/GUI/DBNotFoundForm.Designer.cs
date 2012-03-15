namespace EPUBackoffice.GUI
{
    partial class DBNotFoundForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.createButton = new System.Windows.Forms.Button();
            this.chooseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "No existing database has been specified!\r\n\r\nWhat would you like to do?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(38, 87);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(125, 23);
            this.createButton.TabIndex = 1;
            this.createButton.Text = "Create new database";
            this.createButton.UseVisualStyleBackColor = true;
            // 
            // chooseButton
            // 
            this.chooseButton.Location = new System.Drawing.Point(212, 87);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(125, 23);
            this.chooseButton.TabIndex = 2;
            this.chooseButton.Text = "Choose existing DB";
            this.chooseButton.UseVisualStyleBackColor = true;
            // 
            // DBNotFoundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 132);
            this.Controls.Add(this.chooseButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.label1);
            this.Name = "DBNotFoundForm";
            this.Text = "Backoffice 1.0 - No database found";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button chooseButton;
    }
}