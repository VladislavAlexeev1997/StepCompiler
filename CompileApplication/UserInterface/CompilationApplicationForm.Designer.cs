namespace CompileApplication.UserInterface
{
    partial class CompilationApplicationForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompilationApplicationForm));
            this.FormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenCodeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FirstParametersToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.ParserMethodSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SecondParametersToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.StartCodeAnalyzisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CancelCompilationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BottomFormToolStrip = new System.Windows.Forms.ToolStrip();
            this.LanguageToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.SelectLanguageToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.FirstToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.VersionToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.SelectVersionToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.SecondToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.AnalyzerTypeToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.ThirdToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.AnalyzerTypeStepToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.EnterCodeRichTextBox = new System.Windows.Forms.RichTextBox();
            this.LineCodeNumberRichTextBox = new System.Windows.Forms.RichTextBox();
            this.ClearCodeButton = new System.Windows.Forms.Button();
            this.EnterCodeGroupBox = new System.Windows.Forms.GroupBox();
            this.StartCodeAnalyzerButton = new System.Windows.Forms.Button();
            this.OpenCodeFileButton = new System.Windows.Forms.Button();
            this.InformationToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.PreviousScannerLexemsButton = new System.Windows.Forms.Button();
            this.NextParserAnalyzeCodeButton = new System.Windows.Forms.Button();
            this.NextClassifiedLexemButton = new System.Windows.Forms.Button();
            this.PreviousClassifiedLexemButton = new System.Windows.Forms.Button();
            this.LastClassifiedLexemButton = new System.Windows.Forms.Button();
            this.FirstClassifiedLexemButton = new System.Windows.Forms.Button();
            this.NextLexicalAnalyzerStepButton = new System.Windows.Forms.Button();
            this.NextErrorLexemDataButton = new System.Windows.Forms.Button();
            this.PreviousErrorLexemDataButton = new System.Windows.Forms.Button();
            this.LastErrorLexemDataButton = new System.Windows.Forms.Button();
            this.FirstErrorLexemDataButton = new System.Windows.Forms.Button();
            this.NextScanningLexemDataButton = new System.Windows.Forms.Button();
            this.PreviousScanningLexemDataButton = new System.Windows.Forms.Button();
            this.LastScanningLexemDataButton = new System.Windows.Forms.Button();
            this.FirstScanningLexemDataButton = new System.Windows.Forms.Button();
            this.LexicalScannerResultGroupBox = new System.Windows.Forms.GroupBox();
            this.CancelLexicalScannerCodeAnalyzerButton = new System.Windows.Forms.Button();
            this.ErrorLexemsGroupBox = new System.Windows.Forms.GroupBox();
            this.AllErrorLexemCountItemLabel = new System.Windows.Forms.Label();
            this.AllErrorLexemCountLabel = new System.Windows.Forms.Label();
            this.AllErrorLexemNumberLabel = new System.Windows.Forms.Label();
            this.SelectErrorLexemDataNumberLabel = new System.Windows.Forms.Label();
            this.AllErrorLexemDataLabel = new System.Windows.Forms.Label();
            this.ErrorLexemsDataGridView = new System.Windows.Forms.DataGridView();
            this.ScanningLexemsGroupBox = new System.Windows.Forms.GroupBox();
            this.AllScanningLexemNumberLabel = new System.Windows.Forms.Label();
            this.SelectScanningLexemDataNumberLabel = new System.Windows.Forms.Label();
            this.AllScanningLexemDataLabel = new System.Windows.Forms.Label();
            this.ScanningLexemsDataGridView = new System.Windows.Forms.DataGridView();
            this.LexicalClassificationResultGroupBox = new System.Windows.Forms.GroupBox();
            this.LiteralsAndNumbersGroupBox = new System.Windows.Forms.GroupBox();
            this.LiteralsAndNumbersDataGridView = new System.Windows.Forms.DataGridView();
            this.IdetificatorsGroupBox = new System.Windows.Forms.GroupBox();
            this.IdentificatorsDataGridView = new System.Windows.Forms.DataGridView();
            this.SeparatorsGroupBox = new System.Windows.Forms.GroupBox();
            this.SeparatorsDataGridView = new System.Windows.Forms.DataGridView();
            this.CancelClassificationLexemsButton = new System.Windows.Forms.Button();
            this.LexemClassificationGroupBox = new System.Windows.Forms.GroupBox();
            this.AllClassifiedLexemNumberLabel = new System.Windows.Forms.Label();
            this.SelectClassifiedLexemLabel = new System.Windows.Forms.Label();
            this.AllClassifiedLexemLabel = new System.Windows.Forms.Label();
            this.LexemClassificationDataGridView = new System.Windows.Forms.DataGridView();
            this.KeywordsGroupBox = new System.Windows.Forms.GroupBox();
            this.KeywordsDataGridView = new System.Windows.Forms.DataGridView();
            this.SyntaxAnalyisResultGroupBox = new System.Windows.Forms.GroupBox();
            this.ShowLanguageStateTableButton = new System.Windows.Forms.Button();
            this.CancelSyntaxAnalysisButton = new System.Windows.Forms.Button();
            this.PreviousClassificationLexemsButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.StackListGroupBox = new System.Windows.Forms.GroupBox();
            this.NextStackItemButton = new System.Windows.Forms.Button();
            this.StackListDataGridView = new System.Windows.Forms.DataGridView();
            this.PreviousStackItemButton = new System.Windows.Forms.Button();
            this.LastStackItemButton = new System.Windows.Forms.Button();
            this.FirstStackItemButton = new System.Windows.Forms.Button();
            this.SyntaxActionGroupBox = new System.Windows.Forms.GroupBox();
            this.NextActionButton = new System.Windows.Forms.Button();
            this.SyntaxActionDataGridView = new System.Windows.Forms.DataGridView();
            this.PreviousActionButton = new System.Windows.Forms.Button();
            this.LastActionButton = new System.Windows.Forms.Button();
            this.FirstActionButton = new System.Windows.Forms.Button();
            this.EnterLexemGroupBox = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.FormMenuStrip.SuspendLayout();
            this.BottomFormToolStrip.SuspendLayout();
            this.EnterCodeGroupBox.SuspendLayout();
            this.LexicalScannerResultGroupBox.SuspendLayout();
            this.ErrorLexemsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorLexemsDataGridView)).BeginInit();
            this.ScanningLexemsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScanningLexemsDataGridView)).BeginInit();
            this.LexicalClassificationResultGroupBox.SuspendLayout();
            this.LiteralsAndNumbersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LiteralsAndNumbersDataGridView)).BeginInit();
            this.IdetificatorsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IdentificatorsDataGridView)).BeginInit();
            this.SeparatorsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeparatorsDataGridView)).BeginInit();
            this.LexemClassificationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LexemClassificationDataGridView)).BeginInit();
            this.KeywordsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KeywordsDataGridView)).BeginInit();
            this.SyntaxAnalyisResultGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.StackListGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StackListDataGridView)).BeginInit();
            this.SyntaxActionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SyntaxActionDataGridView)).BeginInit();
            this.EnterLexemGroupBox.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormMenuStrip
            // 
            this.FormMenuStrip.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ParametersToolStripMenuItem});
            this.FormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.FormMenuStrip.Name = "FormMenuStrip";
            this.FormMenuStrip.Size = new System.Drawing.Size(862, 24);
            this.FormMenuStrip.TabIndex = 0;
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenCodeFileToolStripMenuItem,
            this.FileToolStripSeparator,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // OpenCodeFileToolStripMenuItem
            // 
            this.OpenCodeFileToolStripMenuItem.Name = "OpenCodeFileToolStripMenuItem";
            this.OpenCodeFileToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.OpenCodeFileToolStripMenuItem.Text = "Открыть код программы";
            // 
            // FileToolStripSeparator
            // 
            this.FileToolStripSeparator.Name = "FileToolStripSeparator";
            this.FileToolStripSeparator.Size = new System.Drawing.Size(208, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.ExitToolStripMenuItem.Text = "Выйти";
            // 
            // ParametersToolStripMenuItem
            // 
            this.ParametersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CheckLanguageToolStripMenuItem,
            this.SettingLanguageToolStripMenuItem,
            this.FirstParametersToolStripSeparator,
            this.ParserMethodSettingToolStripMenuItem,
            this.SecondParametersToolStripSeparator,
            this.StartCodeAnalyzisToolStripMenuItem,
            this.CancelCompilationToolStripMenuItem});
            this.ParametersToolStripMenuItem.Name = "ParametersToolStripMenuItem";
            this.ParametersToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.ParametersToolStripMenuItem.Text = "Параметры";
            // 
            // CheckLanguageToolStripMenuItem
            // 
            this.CheckLanguageToolStripMenuItem.Name = "CheckLanguageToolStripMenuItem";
            this.CheckLanguageToolStripMenuItem.Size = new System.Drawing.Size(300, 22);
            this.CheckLanguageToolStripMenuItem.Text = "Язык компиляции";
            // 
            // SettingLanguageToolStripMenuItem
            // 
            this.SettingLanguageToolStripMenuItem.Name = "SettingLanguageToolStripMenuItem";
            this.SettingLanguageToolStripMenuItem.Size = new System.Drawing.Size(300, 22);
            this.SettingLanguageToolStripMenuItem.Text = "Настройка языков компиляции";
            // 
            // FirstParametersToolStripSeparator
            // 
            this.FirstParametersToolStripSeparator.Name = "FirstParametersToolStripSeparator";
            this.FirstParametersToolStripSeparator.Size = new System.Drawing.Size(297, 6);
            // 
            // ParserMethodSettingToolStripMenuItem
            // 
            this.ParserMethodSettingToolStripMenuItem.Name = "ParserMethodSettingToolStripMenuItem";
            this.ParserMethodSettingToolStripMenuItem.Size = new System.Drawing.Size(300, 22);
            this.ParserMethodSettingToolStripMenuItem.Text = "Настройка синтаксического анализатора";
            // 
            // SecondParametersToolStripSeparator
            // 
            this.SecondParametersToolStripSeparator.Name = "SecondParametersToolStripSeparator";
            this.SecondParametersToolStripSeparator.Size = new System.Drawing.Size(297, 6);
            // 
            // StartCodeAnalyzisToolStripMenuItem
            // 
            this.StartCodeAnalyzisToolStripMenuItem.Name = "StartCodeAnalyzisToolStripMenuItem";
            this.StartCodeAnalyzisToolStripMenuItem.Size = new System.Drawing.Size(300, 22);
            this.StartCodeAnalyzisToolStripMenuItem.Text = "Начать пошаговую компиляцию";
            // 
            // CancelCompilationToolStripMenuItem
            // 
            this.CancelCompilationToolStripMenuItem.Name = "CancelCompilationToolStripMenuItem";
            this.CancelCompilationToolStripMenuItem.Size = new System.Drawing.Size(300, 22);
            this.CancelCompilationToolStripMenuItem.Text = "Отменить пошаговую компиляцию";
            // 
            // BottomFormToolStrip
            // 
            this.BottomFormToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomFormToolStrip.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BottomFormToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LanguageToolStripLabel,
            this.SelectLanguageToolStripLabel,
            this.FirstToolStripSeparator,
            this.VersionToolStripLabel,
            this.SelectVersionToolStripLabel,
            this.SecondToolStripSeparator,
            this.AnalyzerTypeToolStripLabel,
            this.ThirdToolStripSeparator,
            this.AnalyzerTypeStepToolStripLabel});
            this.BottomFormToolStrip.Location = new System.Drawing.Point(0, 476);
            this.BottomFormToolStrip.Name = "BottomFormToolStrip";
            this.BottomFormToolStrip.Size = new System.Drawing.Size(862, 25);
            this.BottomFormToolStrip.TabIndex = 1;
            // 
            // LanguageToolStripLabel
            // 
            this.LanguageToolStripLabel.Name = "LanguageToolStripLabel";
            this.LanguageToolStripLabel.Size = new System.Drawing.Size(106, 22);
            this.LanguageToolStripLabel.Text = "Выбранный язык:";
            // 
            // SelectLanguageToolStripLabel
            // 
            this.SelectLanguageToolStripLabel.Name = "SelectLanguageToolStripLabel";
            this.SelectLanguageToolStripLabel.Size = new System.Drawing.Size(0, 22);
            // 
            // FirstToolStripSeparator
            // 
            this.FirstToolStripSeparator.Name = "FirstToolStripSeparator";
            this.FirstToolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // VersionToolStripLabel
            // 
            this.VersionToolStripLabel.Name = "VersionToolStripLabel";
            this.VersionToolStripLabel.Size = new System.Drawing.Size(114, 22);
            this.VersionToolStripLabel.Text = "Выбранная версия:";
            // 
            // SelectVersionToolStripLabel
            // 
            this.SelectVersionToolStripLabel.Name = "SelectVersionToolStripLabel";
            this.SelectVersionToolStripLabel.Size = new System.Drawing.Size(0, 22);
            // 
            // SecondToolStripSeparator
            // 
            this.SecondToolStripSeparator.Name = "SecondToolStripSeparator";
            this.SecondToolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // AnalyzerTypeToolStripLabel
            // 
            this.AnalyzerTypeToolStripLabel.Name = "AnalyzerTypeToolStripLabel";
            this.AnalyzerTypeToolStripLabel.Size = new System.Drawing.Size(145, 22);
            this.AnalyzerTypeToolStripLabel.Text = "Лексический анализатор";
            // 
            // ThirdToolStripSeparator
            // 
            this.ThirdToolStripSeparator.Name = "ThirdToolStripSeparator";
            this.ThirdToolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // AnalyzerTypeStepToolStripLabel
            // 
            this.AnalyzerTypeStepToolStripLabel.Name = "AnalyzerTypeStepToolStripLabel";
            this.AnalyzerTypeStepToolStripLabel.Size = new System.Drawing.Size(143, 22);
            this.AnalyzerTypeStepToolStripLabel.Text = "Сканер кода программы";
            // 
            // EnterCodeRichTextBox
            // 
            this.EnterCodeRichTextBox.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.EnterCodeRichTextBox.Location = new System.Drawing.Point(34, 19);
            this.EnterCodeRichTextBox.Name = "EnterCodeRichTextBox";
            this.EnterCodeRichTextBox.Size = new System.Drawing.Size(290, 386);
            this.EnterCodeRichTextBox.TabIndex = 0;
            this.EnterCodeRichTextBox.Text = "";
            this.EnterCodeRichTextBox.VScroll += new System.EventHandler(this.EnterCodeRichTextBox_VScroll);
            // 
            // LineCodeNumberRichTextBox
            // 
            this.LineCodeNumberRichTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.LineCodeNumberRichTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.LineCodeNumberRichTextBox.Enabled = false;
            this.LineCodeNumberRichTextBox.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.LineCodeNumberRichTextBox.ForeColor = System.Drawing.Color.DarkCyan;
            this.LineCodeNumberRichTextBox.Location = new System.Drawing.Point(11, 19);
            this.LineCodeNumberRichTextBox.Name = "LineCodeNumberRichTextBox";
            this.LineCodeNumberRichTextBox.ReadOnly = true;
            this.LineCodeNumberRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.LineCodeNumberRichTextBox.Size = new System.Drawing.Size(25, 386);
            this.LineCodeNumberRichTextBox.TabIndex = 3;
            this.LineCodeNumberRichTextBox.Text = "";
            // 
            // ClearCodeButton
            // 
            this.ClearCodeButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearCodeButton.Location = new System.Drawing.Point(39, 410);
            this.ClearCodeButton.Name = "ClearCodeButton";
            this.ClearCodeButton.Size = new System.Drawing.Size(142, 25);
            this.ClearCodeButton.TabIndex = 4;
            this.ClearCodeButton.Text = "Очистить поле с кодом";
            this.ClearCodeButton.UseVisualStyleBackColor = true;
            // 
            // EnterCodeGroupBox
            // 
            this.EnterCodeGroupBox.Controls.Add(this.StartCodeAnalyzerButton);
            this.EnterCodeGroupBox.Controls.Add(this.OpenCodeFileButton);
            this.EnterCodeGroupBox.Controls.Add(this.EnterCodeRichTextBox);
            this.EnterCodeGroupBox.Controls.Add(this.ClearCodeButton);
            this.EnterCodeGroupBox.Controls.Add(this.LineCodeNumberRichTextBox);
            this.EnterCodeGroupBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterCodeGroupBox.Location = new System.Drawing.Point(9, 23);
            this.EnterCodeGroupBox.Name = "EnterCodeGroupBox";
            this.EnterCodeGroupBox.Size = new System.Drawing.Size(334, 445);
            this.EnterCodeGroupBox.TabIndex = 5;
            this.EnterCodeGroupBox.TabStop = false;
            this.EnterCodeGroupBox.Text = "Анализируемый код программы";
            // 
            // StartCodeAnalyzerButton
            // 
            this.StartCodeAnalyzerButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartCodeAnalyzerButton.Location = new System.Drawing.Point(204, 410);
            this.StartCodeAnalyzerButton.Name = "StartCodeAnalyzerButton";
            this.StartCodeAnalyzerButton.Size = new System.Drawing.Size(120, 25);
            this.StartCodeAnalyzerButton.TabIndex = 44;
            this.StartCodeAnalyzerButton.Text = "Начать анализ кода";
            this.StartCodeAnalyzerButton.UseVisualStyleBackColor = true;
            // 
            // OpenCodeFileButton
            // 
            this.OpenCodeFileButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenCodeFileButton.Image = global::CompileApplication.Properties.Resources.open;
            this.OpenCodeFileButton.Location = new System.Drawing.Point(10, 410);
            this.OpenCodeFileButton.Name = "OpenCodeFileButton";
            this.OpenCodeFileButton.Size = new System.Drawing.Size(25, 25);
            this.OpenCodeFileButton.TabIndex = 43;
            this.InformationToolTip.SetToolTip(this.OpenCodeFileButton, "Открыть файл с кодом");
            this.OpenCodeFileButton.UseVisualStyleBackColor = true;
            // 
            // PreviousScannerLexemsButton
            // 
            this.PreviousScannerLexemsButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PreviousScannerLexemsButton.Image = global::CompileApplication.Properties.Resources.previous;
            this.PreviousScannerLexemsButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PreviousScannerLexemsButton.Location = new System.Drawing.Point(389, 333);
            this.PreviousScannerLexemsButton.Name = "PreviousScannerLexemsButton";
            this.PreviousScannerLexemsButton.Size = new System.Drawing.Size(115, 38);
            this.PreviousScannerLexemsButton.TabIndex = 17;
            this.PreviousScannerLexemsButton.Text = "Предыдущий шаг";
            this.PreviousScannerLexemsButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.InformationToolTip.SetToolTip(this.PreviousScannerLexemsButton, "Переход к сканеру кода");
            this.PreviousScannerLexemsButton.UseVisualStyleBackColor = true;
            // 
            // NextParserAnalyzeCodeButton
            // 
            this.NextParserAnalyzeCodeButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NextParserAnalyzeCodeButton.Image = global::CompileApplication.Properties.Resources.next;
            this.NextParserAnalyzeCodeButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.NextParserAnalyzeCodeButton.Location = new System.Drawing.Point(389, 373);
            this.NextParserAnalyzeCodeButton.Name = "NextParserAnalyzeCodeButton";
            this.NextParserAnalyzeCodeButton.Size = new System.Drawing.Size(115, 38);
            this.NextParserAnalyzeCodeButton.TabIndex = 13;
            this.NextParserAnalyzeCodeButton.Text = "Следующий шаг";
            this.NextParserAnalyzeCodeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.InformationToolTip.SetToolTip(this.NextParserAnalyzeCodeButton, "Переход к синтаксическому анализу кода");
            this.NextParserAnalyzeCodeButton.UseVisualStyleBackColor = true;
            this.NextParserAnalyzeCodeButton.Click += new System.EventHandler(this.NextParserAnalyzeCodeButton_Click);
            // 
            // NextClassifiedLexemButton
            // 
            this.NextClassifiedLexemButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NextClassifiedLexemButton.Image = global::CompileApplication.Properties.Resources.next;
            this.NextClassifiedLexemButton.Location = new System.Drawing.Point(238, 161);
            this.NextClassifiedLexemButton.Name = "NextClassifiedLexemButton";
            this.NextClassifiedLexemButton.Size = new System.Drawing.Size(25, 23);
            this.NextClassifiedLexemButton.TabIndex = 48;
            this.InformationToolTip.SetToolTip(this.NextClassifiedLexemButton, "Следующая запись");
            this.NextClassifiedLexemButton.UseVisualStyleBackColor = true;
            // 
            // PreviousClassifiedLexemButton
            // 
            this.PreviousClassifiedLexemButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PreviousClassifiedLexemButton.Image = global::CompileApplication.Properties.Resources.previous;
            this.PreviousClassifiedLexemButton.Location = new System.Drawing.Point(109, 161);
            this.PreviousClassifiedLexemButton.Name = "PreviousClassifiedLexemButton";
            this.PreviousClassifiedLexemButton.Size = new System.Drawing.Size(25, 23);
            this.PreviousClassifiedLexemButton.TabIndex = 49;
            this.InformationToolTip.SetToolTip(this.PreviousClassifiedLexemButton, "Предыдущая запись");
            this.PreviousClassifiedLexemButton.UseVisualStyleBackColor = true;
            // 
            // LastClassifiedLexemButton
            // 
            this.LastClassifiedLexemButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastClassifiedLexemButton.Image = global::CompileApplication.Properties.Resources.last;
            this.LastClassifiedLexemButton.Location = new System.Drawing.Point(268, 161);
            this.LastClassifiedLexemButton.Name = "LastClassifiedLexemButton";
            this.LastClassifiedLexemButton.Size = new System.Drawing.Size(31, 23);
            this.LastClassifiedLexemButton.TabIndex = 50;
            this.InformationToolTip.SetToolTip(this.LastClassifiedLexemButton, "Последняя запись");
            this.LastClassifiedLexemButton.UseVisualStyleBackColor = true;
            // 
            // FirstClassifiedLexemButton
            // 
            this.FirstClassifiedLexemButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstClassifiedLexemButton.Image = global::CompileApplication.Properties.Resources.first;
            this.FirstClassifiedLexemButton.Location = new System.Drawing.Point(72, 161);
            this.FirstClassifiedLexemButton.Name = "FirstClassifiedLexemButton";
            this.FirstClassifiedLexemButton.Size = new System.Drawing.Size(31, 23);
            this.FirstClassifiedLexemButton.TabIndex = 51;
            this.InformationToolTip.SetToolTip(this.FirstClassifiedLexemButton, "Первая запись");
            this.FirstClassifiedLexemButton.UseVisualStyleBackColor = true;
            // 
            // NextLexicalAnalyzerStepButton
            // 
            this.NextLexicalAnalyzerStepButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NextLexicalAnalyzerStepButton.Image = global::CompileApplication.Properties.Resources.next;
            this.NextLexicalAnalyzerStepButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.NextLexicalAnalyzerStepButton.Location = new System.Drawing.Point(382, 369);
            this.NextLexicalAnalyzerStepButton.Name = "NextLexicalAnalyzerStepButton";
            this.NextLexicalAnalyzerStepButton.Size = new System.Drawing.Size(109, 38);
            this.NextLexicalAnalyzerStepButton.TabIndex = 13;
            this.NextLexicalAnalyzerStepButton.Text = "Следующий шаг";
            this.NextLexicalAnalyzerStepButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.InformationToolTip.SetToolTip(this.NextLexicalAnalyzerStepButton, "Переход к классификации лексем");
            this.NextLexicalAnalyzerStepButton.UseVisualStyleBackColor = true;
            // 
            // NextErrorLexemDataButton
            // 
            this.NextErrorLexemDataButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NextErrorLexemDataButton.Image = global::CompileApplication.Properties.Resources.next;
            this.NextErrorLexemDataButton.Location = new System.Drawing.Point(224, 156);
            this.NextErrorLexemDataButton.Name = "NextErrorLexemDataButton";
            this.NextErrorLexemDataButton.Size = new System.Drawing.Size(25, 23);
            this.NextErrorLexemDataButton.TabIndex = 48;
            this.InformationToolTip.SetToolTip(this.NextErrorLexemDataButton, "Следующая запись");
            this.NextErrorLexemDataButton.UseVisualStyleBackColor = true;
            // 
            // PreviousErrorLexemDataButton
            // 
            this.PreviousErrorLexemDataButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PreviousErrorLexemDataButton.Image = global::CompileApplication.Properties.Resources.previous;
            this.PreviousErrorLexemDataButton.Location = new System.Drawing.Point(95, 156);
            this.PreviousErrorLexemDataButton.Name = "PreviousErrorLexemDataButton";
            this.PreviousErrorLexemDataButton.Size = new System.Drawing.Size(25, 23);
            this.PreviousErrorLexemDataButton.TabIndex = 49;
            this.InformationToolTip.SetToolTip(this.PreviousErrorLexemDataButton, "Предыдущая запись");
            this.PreviousErrorLexemDataButton.UseVisualStyleBackColor = true;
            // 
            // LastErrorLexemDataButton
            // 
            this.LastErrorLexemDataButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastErrorLexemDataButton.Image = global::CompileApplication.Properties.Resources.last;
            this.LastErrorLexemDataButton.Location = new System.Drawing.Point(254, 156);
            this.LastErrorLexemDataButton.Name = "LastErrorLexemDataButton";
            this.LastErrorLexemDataButton.Size = new System.Drawing.Size(31, 23);
            this.LastErrorLexemDataButton.TabIndex = 50;
            this.InformationToolTip.SetToolTip(this.LastErrorLexemDataButton, "Последняя запись");
            this.LastErrorLexemDataButton.UseVisualStyleBackColor = true;
            // 
            // FirstErrorLexemDataButton
            // 
            this.FirstErrorLexemDataButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstErrorLexemDataButton.Image = global::CompileApplication.Properties.Resources.first;
            this.FirstErrorLexemDataButton.Location = new System.Drawing.Point(58, 156);
            this.FirstErrorLexemDataButton.Name = "FirstErrorLexemDataButton";
            this.FirstErrorLexemDataButton.Size = new System.Drawing.Size(31, 23);
            this.FirstErrorLexemDataButton.TabIndex = 51;
            this.InformationToolTip.SetToolTip(this.FirstErrorLexemDataButton, "Первая запись");
            this.FirstErrorLexemDataButton.UseVisualStyleBackColor = true;
            // 
            // NextScanningLexemDataButton
            // 
            this.NextScanningLexemDataButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NextScanningLexemDataButton.Image = global::CompileApplication.Properties.Resources.next;
            this.NextScanningLexemDataButton.Location = new System.Drawing.Point(295, 203);
            this.NextScanningLexemDataButton.Name = "NextScanningLexemDataButton";
            this.NextScanningLexemDataButton.Size = new System.Drawing.Size(25, 23);
            this.NextScanningLexemDataButton.TabIndex = 48;
            this.InformationToolTip.SetToolTip(this.NextScanningLexemDataButton, "Следующая запись");
            this.NextScanningLexemDataButton.UseVisualStyleBackColor = true;
            // 
            // PreviousScanningLexemDataButton
            // 
            this.PreviousScanningLexemDataButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PreviousScanningLexemDataButton.Image = global::CompileApplication.Properties.Resources.previous;
            this.PreviousScanningLexemDataButton.Location = new System.Drawing.Point(167, 203);
            this.PreviousScanningLexemDataButton.Name = "PreviousScanningLexemDataButton";
            this.PreviousScanningLexemDataButton.Size = new System.Drawing.Size(25, 23);
            this.PreviousScanningLexemDataButton.TabIndex = 49;
            this.InformationToolTip.SetToolTip(this.PreviousScanningLexemDataButton, "Предыдущая запись");
            this.PreviousScanningLexemDataButton.UseVisualStyleBackColor = true;
            // 
            // LastScanningLexemDataButton
            // 
            this.LastScanningLexemDataButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastScanningLexemDataButton.Image = global::CompileApplication.Properties.Resources.last;
            this.LastScanningLexemDataButton.Location = new System.Drawing.Point(325, 203);
            this.LastScanningLexemDataButton.Name = "LastScanningLexemDataButton";
            this.LastScanningLexemDataButton.Size = new System.Drawing.Size(31, 23);
            this.LastScanningLexemDataButton.TabIndex = 50;
            this.InformationToolTip.SetToolTip(this.LastScanningLexemDataButton, "Последняя запись");
            this.LastScanningLexemDataButton.UseVisualStyleBackColor = true;
            // 
            // FirstScanningLexemDataButton
            // 
            this.FirstScanningLexemDataButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstScanningLexemDataButton.Image = global::CompileApplication.Properties.Resources.first;
            this.FirstScanningLexemDataButton.Location = new System.Drawing.Point(130, 203);
            this.FirstScanningLexemDataButton.Name = "FirstScanningLexemDataButton";
            this.FirstScanningLexemDataButton.Size = new System.Drawing.Size(31, 23);
            this.FirstScanningLexemDataButton.TabIndex = 51;
            this.InformationToolTip.SetToolTip(this.FirstScanningLexemDataButton, "Первая запись");
            this.FirstScanningLexemDataButton.UseVisualStyleBackColor = true;
            // 
            // LexicalScannerResultGroupBox
            // 
            this.LexicalScannerResultGroupBox.Controls.Add(this.NextLexicalAnalyzerStepButton);
            this.LexicalScannerResultGroupBox.Controls.Add(this.CancelLexicalScannerCodeAnalyzerButton);
            this.LexicalScannerResultGroupBox.Controls.Add(this.ErrorLexemsGroupBox);
            this.LexicalScannerResultGroupBox.Controls.Add(this.ScanningLexemsGroupBox);
            this.LexicalScannerResultGroupBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LexicalScannerResultGroupBox.Location = new System.Drawing.Point(349, 23);
            this.LexicalScannerResultGroupBox.Name = "LexicalScannerResultGroupBox";
            this.LexicalScannerResultGroupBox.Size = new System.Drawing.Size(507, 445);
            this.LexicalScannerResultGroupBox.TabIndex = 6;
            this.LexicalScannerResultGroupBox.TabStop = false;
            this.LexicalScannerResultGroupBox.Text = "Лексический анализатор. Сканер кода программы";
            // 
            // CancelLexicalScannerCodeAnalyzerButton
            // 
            this.CancelLexicalScannerCodeAnalyzerButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelLexicalScannerCodeAnalyzerButton.Location = new System.Drawing.Point(382, 410);
            this.CancelLexicalScannerCodeAnalyzerButton.Name = "CancelLexicalScannerCodeAnalyzerButton";
            this.CancelLexicalScannerCodeAnalyzerButton.Size = new System.Drawing.Size(109, 25);
            this.CancelLexicalScannerCodeAnalyzerButton.TabIndex = 12;
            this.CancelLexicalScannerCodeAnalyzerButton.Text = "Отменить анализ";
            this.CancelLexicalScannerCodeAnalyzerButton.UseVisualStyleBackColor = true;
            // 
            // ErrorLexemsGroupBox
            // 
            this.ErrorLexemsGroupBox.Controls.Add(this.AllErrorLexemCountItemLabel);
            this.ErrorLexemsGroupBox.Controls.Add(this.AllErrorLexemCountLabel);
            this.ErrorLexemsGroupBox.Controls.Add(this.AllErrorLexemNumberLabel);
            this.ErrorLexemsGroupBox.Controls.Add(this.SelectErrorLexemDataNumberLabel);
            this.ErrorLexemsGroupBox.Controls.Add(this.AllErrorLexemDataLabel);
            this.ErrorLexemsGroupBox.Controls.Add(this.NextErrorLexemDataButton);
            this.ErrorLexemsGroupBox.Controls.Add(this.PreviousErrorLexemDataButton);
            this.ErrorLexemsGroupBox.Controls.Add(this.LastErrorLexemDataButton);
            this.ErrorLexemsGroupBox.Controls.Add(this.FirstErrorLexemDataButton);
            this.ErrorLexemsGroupBox.Controls.Add(this.ErrorLexemsDataGridView);
            this.ErrorLexemsGroupBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ErrorLexemsGroupBox.Location = new System.Drawing.Point(6, 252);
            this.ErrorLexemsGroupBox.Name = "ErrorLexemsGroupBox";
            this.ErrorLexemsGroupBox.Size = new System.Drawing.Size(356, 187);
            this.ErrorLexemsGroupBox.TabIndex = 11;
            this.ErrorLexemsGroupBox.TabStop = false;
            this.ErrorLexemsGroupBox.Text = "Обнаруженные нераспознанные лексемы";
            // 
            // AllErrorLexemCountItemLabel
            // 
            this.AllErrorLexemCountItemLabel.BackColor = System.Drawing.SystemColors.Control;
            this.AllErrorLexemCountItemLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AllErrorLexemCountItemLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AllErrorLexemCountItemLabel.Location = new System.Drawing.Point(244, 20);
            this.AllErrorLexemCountItemLabel.Name = "AllErrorLexemCountItemLabel";
            this.AllErrorLexemCountItemLabel.Size = new System.Drawing.Size(34, 22);
            this.AllErrorLexemCountItemLabel.TabIndex = 59;
            this.AllErrorLexemCountItemLabel.Text = "0";
            this.AllErrorLexemCountItemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AllErrorLexemCountLabel
            // 
            this.AllErrorLexemCountLabel.AutoSize = true;
            this.AllErrorLexemCountLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AllErrorLexemCountLabel.Location = new System.Drawing.Point(62, 23);
            this.AllErrorLexemCountLabel.Name = "AllErrorLexemCountLabel";
            this.AllErrorLexemCountLabel.Size = new System.Drawing.Size(179, 15);
            this.AllErrorLexemCountLabel.TabIndex = 58;
            this.AllErrorLexemCountLabel.Text = "Всего нераспознанных лексем:";
            // 
            // AllErrorLexemNumberLabel
            // 
            this.AllErrorLexemNumberLabel.BackColor = System.Drawing.SystemColors.Control;
            this.AllErrorLexemNumberLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AllErrorLexemNumberLabel.Location = new System.Drawing.Point(184, 157);
            this.AllErrorLexemNumberLabel.Name = "AllErrorLexemNumberLabel";
            this.AllErrorLexemNumberLabel.Size = new System.Drawing.Size(34, 22);
            this.AllErrorLexemNumberLabel.TabIndex = 57;
            this.AllErrorLexemNumberLabel.Text = "0";
            this.AllErrorLexemNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectErrorLexemDataNumberLabel
            // 
            this.SelectErrorLexemDataNumberLabel.BackColor = System.Drawing.SystemColors.Control;
            this.SelectErrorLexemDataNumberLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SelectErrorLexemDataNumberLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectErrorLexemDataNumberLabel.Location = new System.Drawing.Point(127, 157);
            this.SelectErrorLexemDataNumberLabel.Name = "SelectErrorLexemDataNumberLabel";
            this.SelectErrorLexemDataNumberLabel.Size = new System.Drawing.Size(34, 22);
            this.SelectErrorLexemDataNumberLabel.TabIndex = 56;
            this.SelectErrorLexemDataNumberLabel.Text = "0";
            this.SelectErrorLexemDataNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AllErrorLexemDataLabel
            // 
            this.AllErrorLexemDataLabel.AutoSize = true;
            this.AllErrorLexemDataLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AllErrorLexemDataLabel.Location = new System.Drawing.Point(164, 161);
            this.AllErrorLexemDataLabel.Name = "AllErrorLexemDataLabel";
            this.AllErrorLexemDataLabel.Size = new System.Drawing.Size(19, 15);
            this.AllErrorLexemDataLabel.TabIndex = 55;
            this.AllErrorLexemDataLabel.Text = "из";
            // 
            // ErrorLexemsDataGridView
            // 
            this.ErrorLexemsDataGridView.Location = new System.Drawing.Point(11, 47);
            this.ErrorLexemsDataGridView.Name = "ErrorLexemsDataGridView";
            this.ErrorLexemsDataGridView.Size = new System.Drawing.Size(332, 102);
            this.ErrorLexemsDataGridView.TabIndex = 9;
            // 
            // ScanningLexemsGroupBox
            // 
            this.ScanningLexemsGroupBox.Controls.Add(this.AllScanningLexemNumberLabel);
            this.ScanningLexemsGroupBox.Controls.Add(this.SelectScanningLexemDataNumberLabel);
            this.ScanningLexemsGroupBox.Controls.Add(this.AllScanningLexemDataLabel);
            this.ScanningLexemsGroupBox.Controls.Add(this.NextScanningLexemDataButton);
            this.ScanningLexemsGroupBox.Controls.Add(this.PreviousScanningLexemDataButton);
            this.ScanningLexemsGroupBox.Controls.Add(this.LastScanningLexemDataButton);
            this.ScanningLexemsGroupBox.Controls.Add(this.FirstScanningLexemDataButton);
            this.ScanningLexemsGroupBox.Controls.Add(this.ScanningLexemsDataGridView);
            this.ScanningLexemsGroupBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScanningLexemsGroupBox.Location = new System.Drawing.Point(6, 16);
            this.ScanningLexemsGroupBox.Name = "ScanningLexemsGroupBox";
            this.ScanningLexemsGroupBox.Size = new System.Drawing.Size(495, 231);
            this.ScanningLexemsGroupBox.TabIndex = 10;
            this.ScanningLexemsGroupBox.TabStop = false;
            this.ScanningLexemsGroupBox.Text = "Обнаруженные лексемы";
            // 
            // AllScanningLexemNumberLabel
            // 
            this.AllScanningLexemNumberLabel.BackColor = System.Drawing.SystemColors.Control;
            this.AllScanningLexemNumberLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AllScanningLexemNumberLabel.Location = new System.Drawing.Point(255, 204);
            this.AllScanningLexemNumberLabel.Name = "AllScanningLexemNumberLabel";
            this.AllScanningLexemNumberLabel.Size = new System.Drawing.Size(34, 22);
            this.AllScanningLexemNumberLabel.TabIndex = 54;
            this.AllScanningLexemNumberLabel.Text = "0";
            this.AllScanningLexemNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectScanningLexemDataNumberLabel
            // 
            this.SelectScanningLexemDataNumberLabel.BackColor = System.Drawing.SystemColors.Control;
            this.SelectScanningLexemDataNumberLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SelectScanningLexemDataNumberLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectScanningLexemDataNumberLabel.Location = new System.Drawing.Point(198, 204);
            this.SelectScanningLexemDataNumberLabel.Name = "SelectScanningLexemDataNumberLabel";
            this.SelectScanningLexemDataNumberLabel.Size = new System.Drawing.Size(34, 22);
            this.SelectScanningLexemDataNumberLabel.TabIndex = 53;
            this.SelectScanningLexemDataNumberLabel.Text = "0";
            this.SelectScanningLexemDataNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AllScanningLexemDataLabel
            // 
            this.AllScanningLexemDataLabel.AutoSize = true;
            this.AllScanningLexemDataLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AllScanningLexemDataLabel.Location = new System.Drawing.Point(235, 208);
            this.AllScanningLexemDataLabel.Name = "AllScanningLexemDataLabel";
            this.AllScanningLexemDataLabel.Size = new System.Drawing.Size(19, 15);
            this.AllScanningLexemDataLabel.TabIndex = 52;
            this.AllScanningLexemDataLabel.Text = "из";
            // 
            // ScanningLexemsDataGridView
            // 
            this.ScanningLexemsDataGridView.Location = new System.Drawing.Point(12, 20);
            this.ScanningLexemsDataGridView.Name = "ScanningLexemsDataGridView";
            this.ScanningLexemsDataGridView.Size = new System.Drawing.Size(472, 180);
            this.ScanningLexemsDataGridView.TabIndex = 9;
            // 
            // LexicalClassificationResultGroupBox
            // 
            this.LexicalClassificationResultGroupBox.Controls.Add(this.SyntaxAnalyisResultGroupBox);
            this.LexicalClassificationResultGroupBox.Controls.Add(this.PreviousScannerLexemsButton);
            this.LexicalClassificationResultGroupBox.Controls.Add(this.LiteralsAndNumbersGroupBox);
            this.LexicalClassificationResultGroupBox.Controls.Add(this.IdetificatorsGroupBox);
            this.LexicalClassificationResultGroupBox.Controls.Add(this.SeparatorsGroupBox);
            this.LexicalClassificationResultGroupBox.Controls.Add(this.NextParserAnalyzeCodeButton);
            this.LexicalClassificationResultGroupBox.Controls.Add(this.CancelClassificationLexemsButton);
            this.LexicalClassificationResultGroupBox.Controls.Add(this.LexemClassificationGroupBox);
            this.LexicalClassificationResultGroupBox.Controls.Add(this.KeywordsGroupBox);
            this.LexicalClassificationResultGroupBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LexicalClassificationResultGroupBox.Location = new System.Drawing.Point(349, 23);
            this.LexicalClassificationResultGroupBox.Name = "LexicalClassificationResultGroupBox";
            this.LexicalClassificationResultGroupBox.Size = new System.Drawing.Size(507, 445);
            this.LexicalClassificationResultGroupBox.TabIndex = 7;
            this.LexicalClassificationResultGroupBox.TabStop = false;
            this.LexicalClassificationResultGroupBox.Text = "Лексический анализатор. Классификация лексем";
            this.LexicalClassificationResultGroupBox.Visible = false;
            // 
            // LiteralsAndNumbersGroupBox
            // 
            this.LiteralsAndNumbersGroupBox.Controls.Add(this.LiteralsAndNumbersDataGridView);
            this.LiteralsAndNumbersGroupBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LiteralsAndNumbersGroupBox.Location = new System.Drawing.Point(377, 16);
            this.LiteralsAndNumbersGroupBox.Name = "LiteralsAndNumbersGroupBox";
            this.LiteralsAndNumbersGroupBox.Size = new System.Drawing.Size(125, 231);
            this.LiteralsAndNumbersGroupBox.TabIndex = 16;
            this.LiteralsAndNumbersGroupBox.TabStop = false;
            this.LiteralsAndNumbersGroupBox.Text = "Литералы и числа";
            // 
            // LiteralsAndNumbersDataGridView
            // 
            this.LiteralsAndNumbersDataGridView.Location = new System.Drawing.Point(7, 19);
            this.LiteralsAndNumbersDataGridView.Name = "LiteralsAndNumbersDataGridView";
            this.LiteralsAndNumbersDataGridView.Size = new System.Drawing.Size(109, 202);
            this.LiteralsAndNumbersDataGridView.TabIndex = 55;
            // 
            // IdetificatorsGroupBox
            // 
            this.IdetificatorsGroupBox.Controls.Add(this.IdentificatorsDataGridView);
            this.IdetificatorsGroupBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IdetificatorsGroupBox.Location = new System.Drawing.Point(247, 16);
            this.IdetificatorsGroupBox.Name = "IdetificatorsGroupBox";
            this.IdetificatorsGroupBox.Size = new System.Drawing.Size(125, 231);
            this.IdetificatorsGroupBox.TabIndex = 15;
            this.IdetificatorsGroupBox.TabStop = false;
            this.IdetificatorsGroupBox.Text = "Идентификаторы";
            // 
            // IdentificatorsDataGridView
            // 
            this.IdentificatorsDataGridView.Location = new System.Drawing.Point(7, 19);
            this.IdentificatorsDataGridView.Name = "IdentificatorsDataGridView";
            this.IdentificatorsDataGridView.Size = new System.Drawing.Size(109, 202);
            this.IdentificatorsDataGridView.TabIndex = 55;
            // 
            // SeparatorsGroupBox
            // 
            this.SeparatorsGroupBox.Controls.Add(this.SeparatorsDataGridView);
            this.SeparatorsGroupBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SeparatorsGroupBox.Location = new System.Drawing.Point(134, 16);
            this.SeparatorsGroupBox.Name = "SeparatorsGroupBox";
            this.SeparatorsGroupBox.Size = new System.Drawing.Size(108, 231);
            this.SeparatorsGroupBox.TabIndex = 14;
            this.SeparatorsGroupBox.TabStop = false;
            this.SeparatorsGroupBox.Text = "Разделители";
            // 
            // SeparatorsDataGridView
            // 
            this.SeparatorsDataGridView.Location = new System.Drawing.Point(7, 19);
            this.SeparatorsDataGridView.Name = "SeparatorsDataGridView";
            this.SeparatorsDataGridView.Size = new System.Drawing.Size(93, 202);
            this.SeparatorsDataGridView.TabIndex = 55;
            // 
            // CancelClassificationLexemsButton
            // 
            this.CancelClassificationLexemsButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelClassificationLexemsButton.Location = new System.Drawing.Point(389, 413);
            this.CancelClassificationLexemsButton.Name = "CancelClassificationLexemsButton";
            this.CancelClassificationLexemsButton.Size = new System.Drawing.Size(115, 25);
            this.CancelClassificationLexemsButton.TabIndex = 12;
            this.CancelClassificationLexemsButton.Text = "Отменить анализ";
            this.CancelClassificationLexemsButton.UseVisualStyleBackColor = true;
            // 
            // LexemClassificationGroupBox
            // 
            this.LexemClassificationGroupBox.Controls.Add(this.AllClassifiedLexemNumberLabel);
            this.LexemClassificationGroupBox.Controls.Add(this.SelectClassifiedLexemLabel);
            this.LexemClassificationGroupBox.Controls.Add(this.AllClassifiedLexemLabel);
            this.LexemClassificationGroupBox.Controls.Add(this.NextClassifiedLexemButton);
            this.LexemClassificationGroupBox.Controls.Add(this.PreviousClassifiedLexemButton);
            this.LexemClassificationGroupBox.Controls.Add(this.LastClassifiedLexemButton);
            this.LexemClassificationGroupBox.Controls.Add(this.FirstClassifiedLexemButton);
            this.LexemClassificationGroupBox.Controls.Add(this.LexemClassificationDataGridView);
            this.LexemClassificationGroupBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LexemClassificationGroupBox.Location = new System.Drawing.Point(6, 250);
            this.LexemClassificationGroupBox.Name = "LexemClassificationGroupBox";
            this.LexemClassificationGroupBox.Size = new System.Drawing.Size(380, 189);
            this.LexemClassificationGroupBox.TabIndex = 11;
            this.LexemClassificationGroupBox.TabStop = false;
            this.LexemClassificationGroupBox.Text = "Классификация обнаруженных лексем";
            // 
            // AllClassifiedLexemNumberLabel
            // 
            this.AllClassifiedLexemNumberLabel.BackColor = System.Drawing.SystemColors.Control;
            this.AllClassifiedLexemNumberLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AllClassifiedLexemNumberLabel.Location = new System.Drawing.Point(198, 162);
            this.AllClassifiedLexemNumberLabel.Name = "AllClassifiedLexemNumberLabel";
            this.AllClassifiedLexemNumberLabel.Size = new System.Drawing.Size(34, 22);
            this.AllClassifiedLexemNumberLabel.TabIndex = 57;
            this.AllClassifiedLexemNumberLabel.Text = "0";
            this.AllClassifiedLexemNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectClassifiedLexemLabel
            // 
            this.SelectClassifiedLexemLabel.BackColor = System.Drawing.SystemColors.Control;
            this.SelectClassifiedLexemLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SelectClassifiedLexemLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectClassifiedLexemLabel.Location = new System.Drawing.Point(141, 162);
            this.SelectClassifiedLexemLabel.Name = "SelectClassifiedLexemLabel";
            this.SelectClassifiedLexemLabel.Size = new System.Drawing.Size(34, 22);
            this.SelectClassifiedLexemLabel.TabIndex = 56;
            this.SelectClassifiedLexemLabel.Text = "0";
            this.SelectClassifiedLexemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AllClassifiedLexemLabel
            // 
            this.AllClassifiedLexemLabel.AutoSize = true;
            this.AllClassifiedLexemLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AllClassifiedLexemLabel.Location = new System.Drawing.Point(178, 166);
            this.AllClassifiedLexemLabel.Name = "AllClassifiedLexemLabel";
            this.AllClassifiedLexemLabel.Size = new System.Drawing.Size(19, 15);
            this.AllClassifiedLexemLabel.TabIndex = 55;
            this.AllClassifiedLexemLabel.Text = "из";
            // 
            // LexemClassificationDataGridView
            // 
            this.LexemClassificationDataGridView.Location = new System.Drawing.Point(6, 16);
            this.LexemClassificationDataGridView.Name = "LexemClassificationDataGridView";
            this.LexemClassificationDataGridView.Size = new System.Drawing.Size(368, 142);
            this.LexemClassificationDataGridView.TabIndex = 9;
            // 
            // KeywordsGroupBox
            // 
            this.KeywordsGroupBox.Controls.Add(this.KeywordsDataGridView);
            this.KeywordsGroupBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeywordsGroupBox.Location = new System.Drawing.Point(4, 16);
            this.KeywordsGroupBox.Name = "KeywordsGroupBox";
            this.KeywordsGroupBox.Size = new System.Drawing.Size(125, 231);
            this.KeywordsGroupBox.TabIndex = 10;
            this.KeywordsGroupBox.TabStop = false;
            this.KeywordsGroupBox.Text = "Ключевые слова";
            // 
            // KeywordsDataGridView
            // 
            this.KeywordsDataGridView.Location = new System.Drawing.Point(7, 19);
            this.KeywordsDataGridView.Name = "KeywordsDataGridView";
            this.KeywordsDataGridView.Size = new System.Drawing.Size(109, 202);
            this.KeywordsDataGridView.TabIndex = 55;
            // 
            // SyntaxAnalyisResultGroupBox
            // 
            this.SyntaxAnalyisResultGroupBox.Controls.Add(this.groupBox3);
            this.SyntaxAnalyisResultGroupBox.Controls.Add(this.groupBox2);
            this.SyntaxAnalyisResultGroupBox.Controls.Add(this.groupBox1);
            this.SyntaxAnalyisResultGroupBox.Controls.Add(this.ShowLanguageStateTableButton);
            this.SyntaxAnalyisResultGroupBox.Controls.Add(this.PreviousClassificationLexemsButton);
            this.SyntaxAnalyisResultGroupBox.Controls.Add(this.CancelSyntaxAnalysisButton);
            this.SyntaxAnalyisResultGroupBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SyntaxAnalyisResultGroupBox.Location = new System.Drawing.Point(0, 0);
            this.SyntaxAnalyisResultGroupBox.Name = "SyntaxAnalyisResultGroupBox";
            this.SyntaxAnalyisResultGroupBox.Size = new System.Drawing.Size(507, 445);
            this.SyntaxAnalyisResultGroupBox.TabIndex = 8;
            this.SyntaxAnalyisResultGroupBox.TabStop = false;
            this.SyntaxAnalyisResultGroupBox.Text = "Синтаксический анализатор";
            this.SyntaxAnalyisResultGroupBox.Visible = false;
            // 
            // ShowLanguageStateTableButton
            // 
            this.ShowLanguageStateTableButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowLanguageStateTableButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ShowLanguageStateTableButton.Location = new System.Drawing.Point(389, 333);
            this.ShowLanguageStateTableButton.Name = "ShowLanguageStateTableButton";
            this.ShowLanguageStateTableButton.Size = new System.Drawing.Size(115, 38);
            this.ShowLanguageStateTableButton.TabIndex = 17;
            this.ShowLanguageStateTableButton.Text = "Показать таблицу состояний";
            this.ShowLanguageStateTableButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ShowLanguageStateTableButton.UseVisualStyleBackColor = true;
            // 
            // CancelSyntaxAnalysisButton
            // 
            this.CancelSyntaxAnalysisButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelSyntaxAnalysisButton.Location = new System.Drawing.Point(389, 413);
            this.CancelSyntaxAnalysisButton.Name = "CancelSyntaxAnalysisButton";
            this.CancelSyntaxAnalysisButton.Size = new System.Drawing.Size(115, 25);
            this.CancelSyntaxAnalysisButton.TabIndex = 12;
            this.CancelSyntaxAnalysisButton.Text = "Отменить анализ";
            this.CancelSyntaxAnalysisButton.UseVisualStyleBackColor = true;
            // 
            // PreviousClassificationLexemsButton
            // 
            this.PreviousClassificationLexemsButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PreviousClassificationLexemsButton.Image = global::CompileApplication.Properties.Resources.previous;
            this.PreviousClassificationLexemsButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PreviousClassificationLexemsButton.Location = new System.Drawing.Point(389, 373);
            this.PreviousClassificationLexemsButton.Name = "PreviousClassificationLexemsButton";
            this.PreviousClassificationLexemsButton.Size = new System.Drawing.Size(115, 38);
            this.PreviousClassificationLexemsButton.TabIndex = 13;
            this.PreviousClassificationLexemsButton.Text = "Предыдущий шаг";
            this.PreviousClassificationLexemsButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.InformationToolTip.SetToolTip(this.PreviousClassificationLexemsButton, "Переход к классификатору лексем");
            this.PreviousClassificationLexemsButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(6, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 151);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Результирующая таблица синтаксического анализа";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(255, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 22);
            this.label1.TabIndex = 54;
            this.label1.Text = "0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(198, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 22);
            this.label2.TabIndex = 53;
            this.label2.Text = "0";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(235, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 15);
            this.label3.TabIndex = 52;
            this.label3.Text = "из";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Image = global::CompileApplication.Properties.Resources.next;
            this.button1.Location = new System.Drawing.Point(295, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 23);
            this.button1.TabIndex = 48;
            this.InformationToolTip.SetToolTip(this.button1, "Следующая запись");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Image = global::CompileApplication.Properties.Resources.previous;
            this.button2.Location = new System.Drawing.Point(167, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 23);
            this.button2.TabIndex = 49;
            this.InformationToolTip.SetToolTip(this.button2, "Предыдущая запись");
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Image = global::CompileApplication.Properties.Resources.last;
            this.button3.Location = new System.Drawing.Point(325, 124);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(31, 23);
            this.button3.TabIndex = 50;
            this.InformationToolTip.SetToolTip(this.button3, "Последняя запись");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Image = global::CompileApplication.Properties.Resources.first;
            this.button4.Location = new System.Drawing.Point(130, 124);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(31, 23);
            this.button4.TabIndex = 51;
            this.InformationToolTip.SetToolTip(this.button4, "Первая запись");
            this.button4.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(9, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(478, 102);
            this.dataGridView1.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(8, 298);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 139);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Описание синтаксических ошибок кода";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(303, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 22);
            this.label4.TabIndex = 59;
            this.label4.Text = "0";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(27, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(274, 15);
            this.label5.TabIndex = 58;
            this.label5.Text = "Количество найденных синтаксических ошибок:";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(194, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 22);
            this.label6.TabIndex = 57;
            this.label6.Text = "0";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(137, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 22);
            this.label7.TabIndex = 56;
            this.label7.Text = "0";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(174, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 15);
            this.label8.TabIndex = 55;
            this.label8.Text = "из";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Image = global::CompileApplication.Properties.Resources.next;
            this.button5.Location = new System.Drawing.Point(234, 109);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 23);
            this.button5.TabIndex = 48;
            this.InformationToolTip.SetToolTip(this.button5, "Следующая запись");
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Image = global::CompileApplication.Properties.Resources.previous;
            this.button6.Location = new System.Drawing.Point(105, 109);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(25, 23);
            this.button6.TabIndex = 49;
            this.InformationToolTip.SetToolTip(this.button6, "Предыдущая запись");
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Image = global::CompileApplication.Properties.Resources.last;
            this.button7.Location = new System.Drawing.Point(264, 109);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(31, 23);
            this.button7.TabIndex = 50;
            this.InformationToolTip.SetToolTip(this.button7, "Последняя запись");
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.Image = global::CompileApplication.Properties.Resources.first;
            this.button8.Location = new System.Drawing.Point(68, 109);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(31, 23);
            this.button8.TabIndex = 51;
            this.InformationToolTip.SetToolTip(this.button8, "Первая запись");
            this.button8.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Location = new System.Drawing.Point(8, 43);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(356, 62);
            this.dataGridView2.TabIndex = 9;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.EnterLexemGroupBox);
            this.groupBox3.Controls.Add(this.SyntaxActionGroupBox);
            this.groupBox3.Controls.Add(this.StackListGroupBox);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(7, 166);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(495, 132);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Информация о текущем действии";
            // 
            // StackListGroupBox
            // 
            this.StackListGroupBox.Controls.Add(this.NextStackItemButton);
            this.StackListGroupBox.Controls.Add(this.StackListDataGridView);
            this.StackListGroupBox.Controls.Add(this.PreviousStackItemButton);
            this.StackListGroupBox.Controls.Add(this.LastStackItemButton);
            this.StackListGroupBox.Controls.Add(this.FirstStackItemButton);
            this.StackListGroupBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StackListGroupBox.Location = new System.Drawing.Point(8, 15);
            this.StackListGroupBox.Name = "StackListGroupBox";
            this.StackListGroupBox.Size = new System.Drawing.Size(155, 110);
            this.StackListGroupBox.TabIndex = 134;
            this.StackListGroupBox.TabStop = false;
            this.StackListGroupBox.Text = "Состав стека";
            // 
            // NextStackItemButton
            // 
            this.NextStackItemButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NextStackItemButton.Image = global::CompileApplication.Properties.Resources.next;
            this.NextStackItemButton.Location = new System.Drawing.Point(80, 83);
            this.NextStackItemButton.Name = "NextStackItemButton";
            this.NextStackItemButton.Size = new System.Drawing.Size(25, 23);
            this.NextStackItemButton.TabIndex = 49;
            this.InformationToolTip.SetToolTip(this.NextStackItemButton, "Следующий элемент стека");
            this.NextStackItemButton.UseVisualStyleBackColor = true;
            this.NextStackItemButton.Click += new System.EventHandler(this.NextStackItemButton_Click);
            // 
            // StackListDataGridView
            // 
            this.StackListDataGridView.Location = new System.Drawing.Point(5, 17);
            this.StackListDataGridView.Name = "StackListDataGridView";
            this.StackListDataGridView.Size = new System.Drawing.Size(145, 62);
            this.StackListDataGridView.TabIndex = 48;
            // 
            // PreviousStackItemButton
            // 
            this.PreviousStackItemButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PreviousStackItemButton.Image = global::CompileApplication.Properties.Resources.previous;
            this.PreviousStackItemButton.Location = new System.Drawing.Point(46, 83);
            this.PreviousStackItemButton.Name = "PreviousStackItemButton";
            this.PreviousStackItemButton.Size = new System.Drawing.Size(25, 23);
            this.PreviousStackItemButton.TabIndex = 50;
            this.InformationToolTip.SetToolTip(this.PreviousStackItemButton, "Предыдущий элемент стека");
            this.PreviousStackItemButton.UseVisualStyleBackColor = true;
            // 
            // LastStackItemButton
            // 
            this.LastStackItemButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastStackItemButton.Image = global::CompileApplication.Properties.Resources.last;
            this.LastStackItemButton.Location = new System.Drawing.Point(114, 83);
            this.LastStackItemButton.Name = "LastStackItemButton";
            this.LastStackItemButton.Size = new System.Drawing.Size(31, 23);
            this.LastStackItemButton.TabIndex = 51;
            this.InformationToolTip.SetToolTip(this.LastStackItemButton, "Последний элемент стека");
            this.LastStackItemButton.UseVisualStyleBackColor = true;
            // 
            // FirstStackItemButton
            // 
            this.FirstStackItemButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstStackItemButton.Image = global::CompileApplication.Properties.Resources.first;
            this.FirstStackItemButton.Location = new System.Drawing.Point(7, 83);
            this.FirstStackItemButton.Name = "FirstStackItemButton";
            this.FirstStackItemButton.Size = new System.Drawing.Size(31, 23);
            this.FirstStackItemButton.TabIndex = 52;
            this.InformationToolTip.SetToolTip(this.FirstStackItemButton, "Первый элемент стека");
            this.FirstStackItemButton.UseVisualStyleBackColor = true;
            // 
            // SyntaxActionGroupBox
            // 
            this.SyntaxActionGroupBox.Controls.Add(this.NextActionButton);
            this.SyntaxActionGroupBox.Controls.Add(this.SyntaxActionDataGridView);
            this.SyntaxActionGroupBox.Controls.Add(this.PreviousActionButton);
            this.SyntaxActionGroupBox.Controls.Add(this.LastActionButton);
            this.SyntaxActionGroupBox.Controls.Add(this.FirstActionButton);
            this.SyntaxActionGroupBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SyntaxActionGroupBox.Location = new System.Drawing.Point(167, 15);
            this.SyntaxActionGroupBox.Name = "SyntaxActionGroupBox";
            this.SyntaxActionGroupBox.Size = new System.Drawing.Size(182, 111);
            this.SyntaxActionGroupBox.TabIndex = 136;
            this.SyntaxActionGroupBox.TabStop = false;
            this.SyntaxActionGroupBox.Text = "Действия";
            // 
            // NextActionButton
            // 
            this.NextActionButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NextActionButton.Image = global::CompileApplication.Properties.Resources.next;
            this.NextActionButton.Location = new System.Drawing.Point(93, 82);
            this.NextActionButton.Name = "NextActionButton";
            this.NextActionButton.Size = new System.Drawing.Size(25, 23);
            this.NextActionButton.TabIndex = 49;
            this.InformationToolTip.SetToolTip(this.NextActionButton, "Следующее действие");
            this.NextActionButton.UseVisualStyleBackColor = true;
            // 
            // SyntaxActionDataGridView
            // 
            this.SyntaxActionDataGridView.Location = new System.Drawing.Point(6, 17);
            this.SyntaxActionDataGridView.Name = "SyntaxActionDataGridView";
            this.SyntaxActionDataGridView.Size = new System.Drawing.Size(170, 62);
            this.SyntaxActionDataGridView.TabIndex = 48;
            // 
            // PreviousActionButton
            // 
            this.PreviousActionButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PreviousActionButton.Image = global::CompileApplication.Properties.Resources.previous;
            this.PreviousActionButton.Location = new System.Drawing.Point(59, 82);
            this.PreviousActionButton.Name = "PreviousActionButton";
            this.PreviousActionButton.Size = new System.Drawing.Size(25, 23);
            this.PreviousActionButton.TabIndex = 50;
            this.InformationToolTip.SetToolTip(this.PreviousActionButton, "Предыдущее действие");
            this.PreviousActionButton.UseVisualStyleBackColor = true;
            // 
            // LastActionButton
            // 
            this.LastActionButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastActionButton.Image = global::CompileApplication.Properties.Resources.last;
            this.LastActionButton.Location = new System.Drawing.Point(127, 82);
            this.LastActionButton.Name = "LastActionButton";
            this.LastActionButton.Size = new System.Drawing.Size(31, 23);
            this.LastActionButton.TabIndex = 51;
            this.InformationToolTip.SetToolTip(this.LastActionButton, "Последнее действие");
            this.LastActionButton.UseVisualStyleBackColor = true;
            // 
            // FirstActionButton
            // 
            this.FirstActionButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstActionButton.Image = global::CompileApplication.Properties.Resources.first;
            this.FirstActionButton.Location = new System.Drawing.Point(20, 82);
            this.FirstActionButton.Name = "FirstActionButton";
            this.FirstActionButton.Size = new System.Drawing.Size(31, 23);
            this.FirstActionButton.TabIndex = 52;
            this.InformationToolTip.SetToolTip(this.FirstActionButton, "Первое действие");
            this.FirstActionButton.UseVisualStyleBackColor = true;
            // 
            // EnterLexemGroupBox
            // 
            this.EnterLexemGroupBox.Controls.Add(this.label12);
            this.EnterLexemGroupBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterLexemGroupBox.Location = new System.Drawing.Point(353, 15);
            this.EnterLexemGroupBox.Name = "EnterLexemGroupBox";
            this.EnterLexemGroupBox.Size = new System.Drawing.Size(137, 49);
            this.EnterLexemGroupBox.TabIndex = 135;
            this.EnterLexemGroupBox.TabStop = false;
            this.EnterLexemGroupBox.Text = "Лексема на входе";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label12.Location = new System.Drawing.Point(3, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 21);
            this.label12.TabIndex = 135;
            this.label12.Text = "Любая лексема";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(353, 63);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(137, 63);
            this.groupBox4.TabIndex = 137;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Номера состояний:";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label9.Location = new System.Drawing.Point(96, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 21);
            this.label9.TabIndex = 135;
            this.label9.Tag = "";
            this.label9.Text = "0";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label10.Location = new System.Drawing.Point(96, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 21);
            this.label10.TabIndex = 136;
            this.label10.Tag = "";
            this.label10.Text = "0";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(31, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 15);
            this.label11.TabIndex = 59;
            this.label11.Text = "Текущее:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(16, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 15);
            this.label13.TabIndex = 137;
            this.label13.Text = "Следующее:";
            // 
            // CompilationApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 501);
            this.Controls.Add(this.LexicalClassificationResultGroupBox);
            this.Controls.Add(this.LexicalScannerResultGroupBox);
            this.Controls.Add(this.EnterCodeGroupBox);
            this.Controls.Add(this.BottomFormToolStrip);
            this.Controls.Add(this.FormMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.FormMenuStrip;
            this.MaximizeBox = false;
            this.Name = "CompilationApplicationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Построение компилятора";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CompilationApplicationForm_FormClosing);
            this.FormMenuStrip.ResumeLayout(false);
            this.FormMenuStrip.PerformLayout();
            this.BottomFormToolStrip.ResumeLayout(false);
            this.BottomFormToolStrip.PerformLayout();
            this.EnterCodeGroupBox.ResumeLayout(false);
            this.LexicalScannerResultGroupBox.ResumeLayout(false);
            this.ErrorLexemsGroupBox.ResumeLayout(false);
            this.ErrorLexemsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorLexemsDataGridView)).EndInit();
            this.ScanningLexemsGroupBox.ResumeLayout(false);
            this.ScanningLexemsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScanningLexemsDataGridView)).EndInit();
            this.LexicalClassificationResultGroupBox.ResumeLayout(false);
            this.LiteralsAndNumbersGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LiteralsAndNumbersDataGridView)).EndInit();
            this.IdetificatorsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IdentificatorsDataGridView)).EndInit();
            this.SeparatorsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SeparatorsDataGridView)).EndInit();
            this.LexemClassificationGroupBox.ResumeLayout(false);
            this.LexemClassificationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LexemClassificationDataGridView)).EndInit();
            this.KeywordsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KeywordsDataGridView)).EndInit();
            this.SyntaxAnalyisResultGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.StackListGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StackListDataGridView)).EndInit();
            this.SyntaxActionGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SyntaxActionDataGridView)).EndInit();
            this.EnterLexemGroupBox.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip FormMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ParametersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CheckLanguageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingLanguageToolStripMenuItem;
        private System.Windows.Forms.ToolStrip BottomFormToolStrip;
        private System.Windows.Forms.ToolStripLabel SelectLanguageToolStripLabel;
        private System.Windows.Forms.ToolStripSeparator FirstToolStripSeparator;
        private System.Windows.Forms.ToolStripLabel SelectVersionToolStripLabel;
        private System.Windows.Forms.ToolStripSeparator SecondToolStripSeparator;
        private System.Windows.Forms.ToolStripLabel AnalyzerTypeToolStripLabel;
        private System.Windows.Forms.ToolStripSeparator ThirdToolStripSeparator;
        private System.Windows.Forms.ToolStripLabel AnalyzerTypeStepToolStripLabel;
        private System.Windows.Forms.RichTextBox EnterCodeRichTextBox;
        private System.Windows.Forms.RichTextBox LineCodeNumberRichTextBox;
        private System.Windows.Forms.Button ClearCodeButton;
        private System.Windows.Forms.GroupBox EnterCodeGroupBox;
        private System.Windows.Forms.ToolStripMenuItem OpenCodeFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator FileToolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator FirstParametersToolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem CancelCompilationToolStripMenuItem;
        private System.Windows.Forms.Button OpenCodeFileButton;
        private System.Windows.Forms.ToolTip InformationToolTip;
        private System.Windows.Forms.Button StartCodeAnalyzerButton;
        private System.Windows.Forms.ToolStripMenuItem StartCodeAnalyzisToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel LanguageToolStripLabel;
        private System.Windows.Forms.ToolStripLabel VersionToolStripLabel;
        private System.Windows.Forms.GroupBox LexicalScannerResultGroupBox;
        private System.Windows.Forms.DataGridView ScanningLexemsDataGridView;
        private System.Windows.Forms.GroupBox ScanningLexemsGroupBox;
        private System.Windows.Forms.Button NextScanningLexemDataButton;
        private System.Windows.Forms.Button PreviousScanningLexemDataButton;
        private System.Windows.Forms.Button LastScanningLexemDataButton;
        private System.Windows.Forms.Button FirstScanningLexemDataButton;
        private System.Windows.Forms.GroupBox ErrorLexemsGroupBox;
        private System.Windows.Forms.Button NextErrorLexemDataButton;
        private System.Windows.Forms.Button PreviousErrorLexemDataButton;
        private System.Windows.Forms.Button LastErrorLexemDataButton;
        private System.Windows.Forms.Button FirstErrorLexemDataButton;
        private System.Windows.Forms.DataGridView ErrorLexemsDataGridView;
        public System.Windows.Forms.Label SelectScanningLexemDataNumberLabel;
        private System.Windows.Forms.Label AllScanningLexemDataLabel;
        public System.Windows.Forms.Label SelectErrorLexemDataNumberLabel;
        private System.Windows.Forms.Label AllErrorLexemDataLabel;
        private System.Windows.Forms.Button NextLexicalAnalyzerStepButton;
        private System.Windows.Forms.Button CancelLexicalScannerCodeAnalyzerButton;
        public System.Windows.Forms.Label AllErrorLexemCountItemLabel;
        private System.Windows.Forms.Label AllErrorLexemCountLabel;
        private System.Windows.Forms.Label AllScanningLexemNumberLabel;
        private System.Windows.Forms.Label AllErrorLexemNumberLabel;
        private System.Windows.Forms.GroupBox LexicalClassificationResultGroupBox;
        private System.Windows.Forms.Button NextParserAnalyzeCodeButton;
        private System.Windows.Forms.Button CancelClassificationLexemsButton;
        private System.Windows.Forms.GroupBox LexemClassificationGroupBox;
        private System.Windows.Forms.Label AllClassifiedLexemNumberLabel;
        public System.Windows.Forms.Label SelectClassifiedLexemLabel;
        private System.Windows.Forms.Label AllClassifiedLexemLabel;
        private System.Windows.Forms.Button NextClassifiedLexemButton;
        private System.Windows.Forms.Button PreviousClassifiedLexemButton;
        private System.Windows.Forms.Button LastClassifiedLexemButton;
        private System.Windows.Forms.Button FirstClassifiedLexemButton;
        private System.Windows.Forms.DataGridView LexemClassificationDataGridView;
        private System.Windows.Forms.GroupBox KeywordsGroupBox;
        private System.Windows.Forms.GroupBox SeparatorsGroupBox;
        private System.Windows.Forms.DataGridView SeparatorsDataGridView;
        private System.Windows.Forms.DataGridView KeywordsDataGridView;
        private System.Windows.Forms.GroupBox LiteralsAndNumbersGroupBox;
        private System.Windows.Forms.DataGridView LiteralsAndNumbersDataGridView;
        private System.Windows.Forms.GroupBox IdetificatorsGroupBox;
        private System.Windows.Forms.DataGridView IdentificatorsDataGridView;
        private System.Windows.Forms.Button PreviousScannerLexemsButton;
        private System.Windows.Forms.ToolStripMenuItem ParserMethodSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator SecondParametersToolStripSeparator;
        private System.Windows.Forms.GroupBox SyntaxAnalyisResultGroupBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ShowLanguageStateTableButton;
        private System.Windows.Forms.Button PreviousClassificationLexemsButton;
        private System.Windows.Forms.Button CancelSyntaxAnalysisButton;
        private System.Windows.Forms.GroupBox StackListGroupBox;
        private System.Windows.Forms.Button NextStackItemButton;
        public System.Windows.Forms.DataGridView StackListDataGridView;
        private System.Windows.Forms.Button PreviousStackItemButton;
        private System.Windows.Forms.Button LastStackItemButton;
        private System.Windows.Forms.Button FirstStackItemButton;
        private System.Windows.Forms.GroupBox SyntaxActionGroupBox;
        private System.Windows.Forms.Button NextActionButton;
        private System.Windows.Forms.DataGridView SyntaxActionDataGridView;
        private System.Windows.Forms.Button PreviousActionButton;
        private System.Windows.Forms.Button LastActionButton;
        private System.Windows.Forms.Button FirstActionButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox EnterLexemGroupBox;
        public System.Windows.Forms.Label label12;
    }
}

