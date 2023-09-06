namespace CompileApplication.UserInterface
{
    partial class SelectLexemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectLexemForm));
            this.OtherLexemTypeLabel = new System.Windows.Forms.Label();
            this.OtherLexemTypeComboBox = new System.Windows.Forms.ComboBox();
            this.NextStackItemButton = new System.Windows.Forms.Button();
            this.StackListDataGridView = new System.Windows.Forms.DataGridView();
            this.PreviousStackItemButton = new System.Windows.Forms.Button();
            this.LastStackItemButton = new System.Windows.Forms.Button();
            this.FirstStackItemButton = new System.Windows.Forms.Button();
            this.CancelEditOtherLexemDataButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StackListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // OtherLexemTypeLabel
            // 
            this.OtherLexemTypeLabel.AutoSize = true;
            this.OtherLexemTypeLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OtherLexemTypeLabel.Location = new System.Drawing.Point(5, 10);
            this.OtherLexemTypeLabel.Name = "OtherLexemTypeLabel";
            this.OtherLexemTypeLabel.Size = new System.Drawing.Size(87, 15);
            this.OtherLexemTypeLabel.TabIndex = 130;
            this.OtherLexemTypeLabel.Text = "Тип лексемы:";
            // 
            // OtherLexemTypeComboBox
            // 
            this.OtherLexemTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OtherLexemTypeComboBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OtherLexemTypeComboBox.FormattingEnabled = true;
            this.OtherLexemTypeComboBox.Location = new System.Drawing.Point(94, 7);
            this.OtherLexemTypeComboBox.Name = "OtherLexemTypeComboBox";
            this.OtherLexemTypeComboBox.Size = new System.Drawing.Size(162, 23);
            this.OtherLexemTypeComboBox.TabIndex = 131;
            this.OtherLexemTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.OtherLexemTypeComboBox_SelectedIndexChanged);
            // 
            // NextStackItemButton
            // 
            this.NextStackItemButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NextStackItemButton.Image = global::CompileApplication.Properties.Resources.next;
            this.NextStackItemButton.Location = new System.Drawing.Point(103, 243);
            this.NextStackItemButton.Name = "NextStackItemButton";
            this.NextStackItemButton.Size = new System.Drawing.Size(25, 23);
            this.NextStackItemButton.TabIndex = 133;
            this.NextStackItemButton.UseVisualStyleBackColor = true;
            // 
            // StackListDataGridView
            // 
            this.StackListDataGridView.Location = new System.Drawing.Point(12, 36);
            this.StackListDataGridView.Name = "StackListDataGridView";
            this.StackListDataGridView.Size = new System.Drawing.Size(175, 202);
            this.StackListDataGridView.TabIndex = 132;
            // 
            // PreviousStackItemButton
            // 
            this.PreviousStackItemButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PreviousStackItemButton.Image = global::CompileApplication.Properties.Resources.previous;
            this.PreviousStackItemButton.Location = new System.Drawing.Point(69, 243);
            this.PreviousStackItemButton.Name = "PreviousStackItemButton";
            this.PreviousStackItemButton.Size = new System.Drawing.Size(25, 23);
            this.PreviousStackItemButton.TabIndex = 134;
            this.PreviousStackItemButton.UseVisualStyleBackColor = true;
            // 
            // LastStackItemButton
            // 
            this.LastStackItemButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastStackItemButton.Image = global::CompileApplication.Properties.Resources.last;
            this.LastStackItemButton.Location = new System.Drawing.Point(137, 243);
            this.LastStackItemButton.Name = "LastStackItemButton";
            this.LastStackItemButton.Size = new System.Drawing.Size(31, 23);
            this.LastStackItemButton.TabIndex = 135;
            this.LastStackItemButton.UseVisualStyleBackColor = true;
            // 
            // FirstStackItemButton
            // 
            this.FirstStackItemButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstStackItemButton.Image = global::CompileApplication.Properties.Resources.first;
            this.FirstStackItemButton.Location = new System.Drawing.Point(30, 243);
            this.FirstStackItemButton.Name = "FirstStackItemButton";
            this.FirstStackItemButton.Size = new System.Drawing.Size(31, 23);
            this.FirstStackItemButton.TabIndex = 136;
            this.FirstStackItemButton.UseVisualStyleBackColor = true;
            // 
            // CancelEditOtherLexemDataButton
            // 
            this.CancelEditOtherLexemDataButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelEditOtherLexemDataButton.Location = new System.Drawing.Point(193, 65);
            this.CancelEditOtherLexemDataButton.Name = "CancelEditOtherLexemDataButton";
            this.CancelEditOtherLexemDataButton.Size = new System.Drawing.Size(63, 23);
            this.CancelEditOtherLexemDataButton.TabIndex = 137;
            this.CancelEditOtherLexemDataButton.Text = "Отмена";
            this.CancelEditOtherLexemDataButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(193, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 23);
            this.button1.TabIndex = 138;
            this.button1.Text = "Выбрать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SelectLexemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 276);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CancelEditOtherLexemDataButton);
            this.Controls.Add(this.NextStackItemButton);
            this.Controls.Add(this.StackListDataGridView);
            this.Controls.Add(this.PreviousStackItemButton);
            this.Controls.Add(this.LastStackItemButton);
            this.Controls.Add(this.FirstStackItemButton);
            this.Controls.Add(this.OtherLexemTypeLabel);
            this.Controls.Add(this.OtherLexemTypeComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectLexemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбрать лексему";
            ((System.ComponentModel.ISupportInitialize)(this.StackListDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label OtherLexemTypeLabel;
        private System.Windows.Forms.ComboBox OtherLexemTypeComboBox;
        private System.Windows.Forms.Button NextStackItemButton;
        private System.Windows.Forms.DataGridView StackListDataGridView;
        private System.Windows.Forms.Button PreviousStackItemButton;
        private System.Windows.Forms.Button LastStackItemButton;
        private System.Windows.Forms.Button FirstStackItemButton;
        private System.Windows.Forms.Button CancelEditOtherLexemDataButton;
        private System.Windows.Forms.Button button1;
    }
}