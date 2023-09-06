namespace CompileApplication.UserInterface
{
    partial class SelectLanguageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectLanguageForm));
            this.CheckLanguageVersionLabel = new System.Windows.Forms.Label();
            this.CheckLanguageVersionComboBox = new System.Windows.Forms.ComboBox();
            this.CheckLanguageLabel = new System.Windows.Forms.Label();
            this.CheckLanguageComboBox = new System.Windows.Forms.ComboBox();
            this.SelectInfotmationLabel = new System.Windows.Forms.Label();
            this.SelectLanguageButton = new System.Windows.Forms.Button();
            this.CancelSelectLanguageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CheckLanguageVersionLabel
            // 
            this.CheckLanguageVersionLabel.AutoSize = true;
            this.CheckLanguageVersionLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckLanguageVersionLabel.Location = new System.Drawing.Point(35, 79);
            this.CheckLanguageVersionLabel.Name = "CheckLanguageVersionLabel";
            this.CheckLanguageVersionLabel.Size = new System.Drawing.Size(85, 15);
            this.CheckLanguageVersionLabel.TabIndex = 6;
            this.CheckLanguageVersionLabel.Text = "Версия языка:";
            // 
            // CheckLanguageVersionComboBox
            // 
            this.CheckLanguageVersionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CheckLanguageVersionComboBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckLanguageVersionComboBox.FormattingEnabled = true;
            this.CheckLanguageVersionComboBox.Location = new System.Drawing.Point(131, 76);
            this.CheckLanguageVersionComboBox.Name = "CheckLanguageVersionComboBox";
            this.CheckLanguageVersionComboBox.Size = new System.Drawing.Size(135, 23);
            this.CheckLanguageVersionComboBox.TabIndex = 7;
            // 
            // CheckLanguageLabel
            // 
            this.CheckLanguageLabel.AutoSize = true;
            this.CheckLanguageLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckLanguageLabel.Location = new System.Drawing.Point(10, 48);
            this.CheckLanguageLabel.Name = "CheckLanguageLabel";
            this.CheckLanguageLabel.Size = new System.Drawing.Size(110, 15);
            this.CheckLanguageLabel.TabIndex = 4;
            this.CheckLanguageLabel.Text = "Язык компиляции:";
            // 
            // CheckLanguageComboBox
            // 
            this.CheckLanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CheckLanguageComboBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckLanguageComboBox.FormattingEnabled = true;
            this.CheckLanguageComboBox.Location = new System.Drawing.Point(131, 44);
            this.CheckLanguageComboBox.Name = "CheckLanguageComboBox";
            this.CheckLanguageComboBox.Size = new System.Drawing.Size(135, 23);
            this.CheckLanguageComboBox.TabIndex = 5;
            // 
            // SelectInfotmationLabel
            // 
            this.SelectInfotmationLabel.AutoSize = true;
            this.SelectInfotmationLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectInfotmationLabel.Location = new System.Drawing.Point(13, 8);
            this.SelectInfotmationLabel.Name = "SelectInfotmationLabel";
            this.SelectInfotmationLabel.Size = new System.Drawing.Size(251, 30);
            this.SelectInfotmationLabel.TabIndex = 8;
            this.SelectInfotmationLabel.Text = "Выберите язык компиляции и его версию, \r\nчтобы начать работу компилятора";
            this.SelectInfotmationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectLanguageButton
            // 
            this.SelectLanguageButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectLanguageButton.Location = new System.Drawing.Point(9, 108);
            this.SelectLanguageButton.Name = "SelectLanguageButton";
            this.SelectLanguageButton.Size = new System.Drawing.Size(97, 23);
            this.SelectLanguageButton.TabIndex = 9;
            this.SelectLanguageButton.Text = "Выбрать язык";
            this.SelectLanguageButton.UseVisualStyleBackColor = true;
            // 
            // CancelSelectLanguageButton
            // 
            this.CancelSelectLanguageButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelSelectLanguageButton.Location = new System.Drawing.Point(197, 108);
            this.CancelSelectLanguageButton.Name = "CancelSelectLanguageButton";
            this.CancelSelectLanguageButton.Size = new System.Drawing.Size(69, 23);
            this.CancelSelectLanguageButton.TabIndex = 10;
            this.CancelSelectLanguageButton.Text = "Отмена";
            this.CancelSelectLanguageButton.UseVisualStyleBackColor = true;
            // 
            // SelectLanguageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 139);
            this.Controls.Add(this.CancelSelectLanguageButton);
            this.Controls.Add(this.SelectLanguageButton);
            this.Controls.Add(this.SelectInfotmationLabel);
            this.Controls.Add(this.CheckLanguageVersionLabel);
            this.Controls.Add(this.CheckLanguageVersionComboBox);
            this.Controls.Add(this.CheckLanguageLabel);
            this.Controls.Add(this.CheckLanguageComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectLanguageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбрать язык компиляции";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CheckLanguageVersionLabel;
        private System.Windows.Forms.ComboBox CheckLanguageVersionComboBox;
        private System.Windows.Forms.Label CheckLanguageLabel;
        private System.Windows.Forms.ComboBox CheckLanguageComboBox;
        private System.Windows.Forms.Label SelectInfotmationLabel;
        private System.Windows.Forms.Button SelectLanguageButton;
        private System.Windows.Forms.Button CancelSelectLanguageButton;
    }
}