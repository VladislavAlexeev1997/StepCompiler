using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CompileApplication.Views;
using CompileApplication.Views.Enums;
using CompileApplication.UserInterface.ModernControl;
using CompileApplication.Model.LexicalScanner;
using CompileApplication.Model.LexemTypes;
using CompileApplication.Model.LexicalClassification;

namespace CompileApplication.UserInterface
{
    public partial class CompilationApplicationForm : Form, ICompilationApplicationView
    {
        private CodeAnalyzer _status;

        [DllImport("user32.dll")]
        public static extern int GetScrollPos(IntPtr handle, int barPosition);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr handle, uint message,
            IntPtr wParam, IntPtr lParam);

        public event Action ProgramCodeEnterText;

        public event Action ProgramCodeTextChanged;

        public event Action ProgramCodeLeaveText;

        public event Action StartCodeAnalyzer;

        public event Action ClassifiedLexemCode;

        public event Action BackToLexemScanningCode;

        public event Action ClearProgramCode;

        public event Action LoadCodeFile;

        public event Action CancelAnalyze;

        public event Action SelectedCurrentScannerLexem;

        public event Action FirstScannerLexem;

        public event Action PreviousScannerLexem;

        public event Action NextScannerLexem;

        public event Action LastScannerLexem;

        public event Action SelectedCurrentErrorScannerLexem;

        public event Action FirstErrorScannerLexem;

        public event Action PreviousErrorScannerLexem;

        public event Action NextErrorScannerLexem;

        public event Action LastErrorScannerLexem;

        public event Action SelectedCurrentClassifiedLexem;

        public event Action FirstClassifiedLexem;

        public event Action PreviousClassifiedLexem;

        public event Action NextClassifiedLexem;

        public event Action LastClassifiedLexem;

        public event OpenSelectLanguageView OpenSelectLanguageView;

        public event OpenLanguageSettingView OpenLanguageSettingView;

        public event OpenSyntaxLanguageSettingView OpenSyntaxLanguageSettingView;

        public CompilationApplicationForm()
        {
            InitializeComponent();
            UserDataGridViewsCustomer();
        }

        public CodeAnalyzer Position
        {
            get { return _status; }
            set { FormElementControl(value); }
        }

        public CodeAnalyzer NowAnalyzerStep { get; set; }

        public string CurrentLanguage
        {
            get { return SelectLanguageToolStripLabel.Text; }
            set { SelectLanguageToolStripLabel.Text = value; }
        }

        public string CurrentVersion
        {
            get { return SelectVersionToolStripLabel.Text; }
            set { SelectVersionToolStripLabel.Text = value; }
        }

        public string[] ProgramCode
        {
            get { return EnterCodeRichTextBox.Lines; }
        }

        public string ProgramCodeText
        {
            get { return EnterCodeRichTextBox.Text; }
            set { EnterCodeRichTextBox.Text = value; }
        }

        public string ProgramCodeLineNumbers
        {
            set { LineCodeNumberRichTextBox.Text = value; }
        }

        public string AnalyzeType
        {
            set { AnalyzerTypeToolStripLabel.Text = value; }
        }

        public string AnalyzeTypeStep
        {
            set { AnalyzerTypeStepToolStripLabel.Text = value; }
        }

        public int CurrentScannerLexemIndex
        {
            get { return ScanningLexemsDataGridView.CurrentRow.Index; }
            set
            {
                if (value >= 0)
                {
                    ScanningLexemsDataGridView.CurrentCell =
                        ScanningLexemsDataGridView.Rows[value].Cells[0];
                }
                SelectScanningLexemDataNumberLabel.Text = 
                    Convert.ToString(value + 1);
            }
        }

        public int CurrentErrorScannerLexemIndex
        {
            get { return ErrorLexemsDataGridView.CurrentRow.Index; }
            set
            {
                if (value >= 0)
                {
                    ErrorLexemsDataGridView.CurrentCell =
                        ErrorLexemsDataGridView.Rows[value].Cells[0];
                }
                SelectErrorLexemDataNumberLabel.Text =
                    Convert.ToString(value + 1);
            }
        }

        public int CurrentKeywordIndex
        {
            get { return KeywordsDataGridView.CurrentRow.Index; }
            set
            {
                KeywordsDataGridView.CurrentCell =
                    KeywordsDataGridView.Rows[value].Cells[0];
            }
        }

        public int CurrentSeparatorIndex
        {
            get { return SeparatorsDataGridView.CurrentRow.Index; }
            set
            {
                SeparatorsDataGridView.CurrentCell =
                    SeparatorsDataGridView.Rows[value].Cells[0];
            }
        }

        public int CurrentIdentificatorIndex
        {
            get { return IdentificatorsDataGridView.CurrentRow.Index; }
            set
            {
                IdentificatorsDataGridView.CurrentCell =
                    IdentificatorsDataGridView.Rows[value].Cells[0];
            }
        }

        public int CurrentLiteralAndNumberIndex
        {
            get { return LiteralsAndNumbersDataGridView.CurrentRow.Index; }
            set
            {
                LiteralsAndNumbersDataGridView.CurrentCell =
                    LiteralsAndNumbersDataGridView.Rows[value].Cells[0];
            }
        }

        public int CurrentClassifiedLexemIndex
        {
            get { return LexemClassificationDataGridView.CurrentRow.Index; }
            set
            {
                if (value >= 0)
                {
                    LexemClassificationDataGridView.CurrentCell =
                        LexemClassificationDataGridView.Rows[value].Cells[0];
                }
                SelectClassifiedLexemLabel.Text =
                    Convert.ToString(value + 1);
            }
        }

        public void ProgramCodeMasked(string mask, Color color)
        {
            EnterCodeRichTextBox.Text = mask;
            EnterCodeRichTextBox.ForeColor = color;
        }

        public string OpenCodeFileName()
        {
            OpenFileDialog openCodeFileDialog = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "Текстовый файл (*.txt)|*.txt",
                RestoreDirectory = true
            };
            DialogResult open = openCodeFileDialog.ShowDialog();
            if (open == DialogResult.OK)
            {
                return openCodeFileDialog.FileName;
            }
            else
            {
                return "";
            }
        }

        public void AddScanningLexem(CodeLexem addLexem)
        {
            ScanningLexemsDataGridView.Rows.Add(
                ScanningLexemsDataGridView.Rows.Count + 1,
                addLexem.Lexem.Item, addLexem.Lexem.TypeName(),
                addLexem.StartPosition.Line + 1,
                addLexem.StartPosition.CharNumber + 1);
        }

        public void ScanningLexemButtonControl(NavigatorButtonControl navigator)
        {
            LexemButtonControl(
                navigator, FirstScanningLexemDataButton, PreviousScanningLexemDataButton, 
                NextScanningLexemDataButton, LastScanningLexemDataButton);
        }

        public void AddErrorScanningLexem(CodeLexem addLexem)
        {
            ErrorLexemsDataGridView.Rows.Add(
                ErrorLexemsDataGridView.Rows.Count + 1,
                addLexem.Lexem.Item, addLexem.StartPosition.Line + 1,
                addLexem.StartPosition.CharNumber + 1);
        }

        public void ErrorScanningLexemButtonControl(NavigatorButtonControl navigator)
        {
            LexemButtonControl(
                navigator, FirstErrorLexemDataButton, PreviousErrorLexemDataButton,
                NextErrorLexemDataButton, LastErrorLexemDataButton);
        }

        public void UpdateKeywordLexems(List<Keyword> Keywords)
        {
            KeywordsDataGridView.Rows.Clear();
            foreach (Keyword keyword in Keywords)
            {
                KeywordsDataGridView.Rows.Add(KeywordsDataGridView.Rows.Count + 1,
                    keyword.Item);
            }
        }

        public void UpdateSeparatorLexems(List<Separator> Separators)
        {
            SeparatorsDataGridView.Rows.Clear();
            foreach (Separator separator in Separators)
            {
                SeparatorsDataGridView.Rows.Add(SeparatorsDataGridView.Rows.Count + 1,
                    separator.Item);
            }
        }

        public void UpdateIdentificatorLexems(List<Identificator> Identificators)
        {
            IdentificatorsDataGridView.Rows.Clear();
            foreach (Identificator identificator in Identificators)
            {
                IdentificatorsDataGridView.Rows.Add(IdentificatorsDataGridView.Rows.Count + 1,
                    identificator.Item);
            }
        }

        public void UpdateLiteralAndNumberLexems(List<Lexem> Literals)
        {
            LiteralsAndNumbersDataGridView.Rows.Clear();
            foreach (Lexem literal in Literals)
            {
                LiteralsAndNumbersDataGridView.Rows.Add(LiteralsAndNumbersDataGridView.Rows.Count + 1,
                    literal.Item);
            }
        }

        public void UpdateClassifiedLexems(List<ClassifiedLexem> ClassifiedLexems)
        {
            LexemClassificationDataGridView.Rows.Clear();
            foreach (ClassifiedLexem classifiedLexem in ClassifiedLexems)
            {
                LexemClassificationDataGridView.Rows.Add(LexemClassificationDataGridView.Rows.Count + 1,
                    classifiedLexem.Lexem.Item, classifiedLexem.ClassNumber, 
                    classifiedLexem.LexemNumber, classifiedLexem.Lexem.TypeName());
            }
        }

        public void ClassifiedLexemButtonControl(NavigatorButtonControl navigator)
        {
            LexemButtonControl(
                navigator, FirstClassifiedLexemButton, PreviousClassifiedLexemButton,
                NextClassifiedLexemButton, LastClassifiedLexemButton);
        }

        public void NullSelectedClassifedLexem()
        {
            KeywordsDataGridView.CurrentCell = null;
            SeparatorsDataGridView.CurrentCell = null;
            IdentificatorsDataGridView.CurrentCell = null;
            LiteralsAndNumbersDataGridView.CurrentCell = null;
        }

        public void ShowInterface()
        {
            Show();
        }

        public void HideInterface()
        {
            Hide();
        }

        public void CloseInterface()
        {
            Close();
        }

        public void UpdateViewEvents()
        {
            OpenCodeFileToolStripMenuItem.Click += (sender, args) =>
                LoadCodeFile();
            ExitToolStripMenuItem.Click += (sender, args) => CloseInterface();
            CheckLanguageToolStripMenuItem.Click += (sender, args) =>
                OpenSelectLanguageView(new SelectLanguageForm());
            SettingLanguageToolStripMenuItem.Click += (sender, args) => 
                OpenLanguageSettingView(new LanguageSettingForm());
            ParserMethodSettingToolStripMenuItem.Click += (sender, args) =>
                OpenSyntaxLanguageSettingView(new SyntaxLanguageSettingForm());
            StartCodeAnalyzisToolStripMenuItem.Click += (sender, args) => StartCodeAnalyzer();
            CancelCompilationToolStripMenuItem.Click += (sender, args) => CancelAnalyze();
            EnterCodeRichTextBox.Enter += (sender, args) => ProgramCodeEnterText();
            EnterCodeRichTextBox.TextChanged += (sender, args) => ProgramCodeTextChanged();
            EnterCodeRichTextBox.Leave += (sender, args) => ProgramCodeLeaveText();
            OpenCodeFileButton.Click += (sender, args) => LoadCodeFile();
            ClearCodeButton.Click += (sender, args) => ClearProgramCode();
            StartCodeAnalyzerButton.Click += (sender, args) => StartCodeAnalyzer();
            NextLexicalAnalyzerStepButton.Click += (sender, args) => ClassifiedLexemCode();
            PreviousScannerLexemsButton.Click += (sender, args) => BackToLexemScanningCode();
            ScanningLexemsDataGridView.CurrentCellChanged += (sender, args) => SelectedCurrentScannerLexem();
            FirstScanningLexemDataButton.Click += (sender, arg) => FirstScannerLexem();
            PreviousScanningLexemDataButton.Click += (sender, arg) => PreviousScannerLexem();
            NextScanningLexemDataButton.Click += (sender, arg) => NextScannerLexem();
            LastScanningLexemDataButton.Click += (sender, arg) => LastScannerLexem();
            ErrorLexemsDataGridView.CurrentCellChanged += (sender, args) => SelectedCurrentErrorScannerLexem();
            FirstErrorLexemDataButton.Click += (sender, arg) => FirstErrorScannerLexem();
            PreviousErrorLexemDataButton.Click += (sender, arg) => PreviousErrorScannerLexem();
            NextErrorLexemDataButton.Click += (sender, arg) => NextErrorScannerLexem();
            LastErrorLexemDataButton.Click += (sender, arg) => LastErrorScannerLexem();
            LexemClassificationDataGridView.CurrentCellChanged += (sender, args) => SelectedCurrentClassifiedLexem();
            FirstClassifiedLexemButton.Click += (sender, arg) => FirstClassifiedLexem();
            PreviousClassifiedLexemButton.Click += (sender, arg) => PreviousClassifiedLexem();
            NextClassifiedLexemButton.Click += (sender, arg) => NextClassifiedLexem();
            LastClassifiedLexemButton.Click += (sender, arg) => LastClassifiedLexem();
            CancelLexicalScannerCodeAnalyzerButton.Click += (sender, args) => CancelAnalyze();
            CancelClassificationLexemsButton.Click += (sender, args) => CancelAnalyze();
        }

        public void WarningMessage(string message, string name)
        {
            MessageBox.Show(message, name, MessageBoxButtons.OK, 
                MessageBoxIcon.Warning);
        }

        public bool QuestionMessage(string message, string name)
        {
            DialogResult request = MessageBox.Show(message, 
                name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return request == DialogResult.Yes;
        }

        private void UserDataGridViewsCustomer()
        {
            ApplicationDataGridViewCustomer scanningLexemsCustomer =
                new ApplicationDataGridViewCustomer(ScanningLexemsDataGridView);
            scanningLexemsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "№", "NumberRowColumn", 40);
            scanningLexemsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Обнаруженная лексема", "LexemRowColumn", 185);
            scanningLexemsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Тип лексемы", "LexemTypeRowColumn", 135);
            scanningLexemsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Строка", "LineNumRowColumn", 50);
            scanningLexemsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Символ", "SymbolLineNumColumn", 55);
            ApplicationDataGridViewCustomer errorLexemsCustomer =
                new ApplicationDataGridViewCustomer(ErrorLexemsDataGridView);
            errorLexemsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "№", "NumberRowColumn", 40);
            errorLexemsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Лексема", "LexemRowColumn", 175);
            errorLexemsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Строка", "LineNumRowColumn", 50);
            errorLexemsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Символ", "SymbolNumColumn", 50);
            ApplicationDataGridViewCustomer keywordsCustomer =
                new ApplicationDataGridViewCustomer(KeywordsDataGridView);
            keywordsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "№", "NumberRowColumn", 32);
            keywordsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Лексема", "LexemRowColumn", 76);
            ApplicationDataGridViewCustomer separatorsCustomer =
                new ApplicationDataGridViewCustomer(SeparatorsDataGridView);
            separatorsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "№", "NumberRowColumn", 32);
            separatorsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Лексема", "LexemRowColumn", 60);
            ApplicationDataGridViewCustomer identificatorsCustomer =
                new ApplicationDataGridViewCustomer(IdentificatorsDataGridView);
            identificatorsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "№", "NumberRowColumn", 32);
            identificatorsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Лексема", "LexemRowColumn", 76);
            ApplicationDataGridViewCustomer literalsCustomer =
                new ApplicationDataGridViewCustomer(LiteralsAndNumbersDataGridView);
            literalsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "№", "NumberRowColumn", 32);
            literalsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Лексема", "LexemRowColumn", 76);
            ApplicationDataGridViewCustomer lexemClassificatonCustomer =
                new ApplicationDataGridViewCustomer(LexemClassificationDataGridView);
            lexemClassificatonCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "№", "NumberRowColumn", 30);
            lexemClassificatonCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Лексема", "LexemRowColumn", 150);
            lexemClassificatonCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Класс", "ClassColumn", 40);
            lexemClassificatonCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "№ лексемы", "ClassNumColumn", 30);
            lexemClassificatonCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Тип", "LexemTypeColumn", 110);
            ApplicationDataGridViewCustomer stackListCustomer =
                new ApplicationDataGridViewCustomer(StackListDataGridView);
            stackListCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "№", "NumberRowColumn", 30);
            stackListCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Лексема стека", "LexemRowColumn", 114);
            ApplicationDataGridViewCustomer syntaxActionCustomer =
                new ApplicationDataGridViewCustomer(SyntaxActionDataGridView);
            syntaxActionCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "№", "NumberRowColumn", 30);
            syntaxActionCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Действие", "LexemRowColumn", 139);
            // <
            ApplicationDataGridViewCustomer dataGridView1Customer =
                new ApplicationDataGridViewCustomer(dataGridView1);
            dataGridView1Customer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "№", "NumberRowColumn", 30);
            dataGridView1Customer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Стек (посл. эл.)", "LexemRowColumn", 110);
            dataGridView1Customer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Вход", "ClassColumn", 100);
            dataGridView1Customer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Т. с.", "ClassNumColumn", 40);
            dataGridView1Customer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Действия", "LexemTypeColumn", 150);
            dataGridView1Customer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "С. с.", "LexemTypeColumn", 40);
            ApplicationDataGridViewCustomer dataGridView2Customer =
                new ApplicationDataGridViewCustomer(dataGridView2);
            dataGridView2Customer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "№", "NumberRowColumn", 30);
            dataGridView2Customer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Описание ошибки", "LexemRowColumn", 223);
            dataGridView2Customer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Строка", "LineNumRowColumn", 50);
            dataGridView2Customer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Символ", "SymbolNumColumn", 50);
            // >
        }

        private void FormElementControl(CodeAnalyzer position)
        {
            _status = position;
            bool isOpenCompilate = position == CodeAnalyzer.StartPosition;
            bool isLexemScanner = position == CodeAnalyzer.CodeScanner;
            bool isSuccsesLexemScanner = position == CodeAnalyzer.SuccsessCodeScanner;
            bool isLexemClassification = position == CodeAnalyzer.LexemClassification;
            OpenCodeFileToolStripMenuItem.Enabled = isOpenCompilate;
            CheckLanguageToolStripMenuItem.Enabled = isOpenCompilate;
            SettingLanguageToolStripMenuItem.Enabled = isOpenCompilate;
            ParserMethodSettingToolStripMenuItem.Enabled = isOpenCompilate;
            StartCodeAnalyzisToolStripMenuItem.Enabled = isOpenCompilate;
            CancelCompilationToolStripMenuItem.Enabled = !isOpenCompilate;
            EnterCodeRichTextBox.ReadOnly = !isOpenCompilate;
            OpenCodeFileButton.Enabled = isOpenCompilate;
            ClearCodeButton.Enabled = isOpenCompilate;
            StartCodeAnalyzerButton.Enabled = isOpenCompilate;
            SecondToolStripSeparator.Visible = !isOpenCompilate;
            AnalyzerTypeToolStripLabel.Visible = !isOpenCompilate;
            ThirdToolStripSeparator.Visible = !isOpenCompilate;
            AnalyzerTypeStepToolStripLabel.Visible = !isOpenCompilate;
            LexicalScannerResultGroupBox.Visible = 
                isOpenCompilate || isLexemScanner || isSuccsesLexemScanner;
            LexicalClassificationResultGroupBox.Visible = isLexemClassification;
            NextLexicalAnalyzerStepButton.Enabled = !isOpenCompilate && !isLexemScanner;
            CancelLexicalScannerCodeAnalyzerButton.Enabled = !isOpenCompilate;
            if (isOpenCompilate)
            {
                ScanningLexemsDataGridView.Rows.Clear();
                ErrorLexemsDataGridView.Rows.Clear();
                KeywordsDataGridView.Rows.Clear();
                SeparatorsDataGridView.Rows.Clear();
                IdentificatorsDataGridView.Rows.Clear();
                LiteralsAndNumbersDataGridView.Rows.Clear();
                LexemClassificationDataGridView.Rows.Clear();
            }
            AllScanningLexemNumberLabel.Text = 
                Convert.ToString(ScanningLexemsDataGridView.Rows.Count);
            AllErrorLexemCountItemLabel.Text =
                Convert.ToString(ErrorLexemsDataGridView.Rows.Count);
            AllErrorLexemNumberLabel.Text =
                Convert.ToString(ErrorLexemsDataGridView.Rows.Count);
            AllClassifiedLexemNumberLabel.Text =
                Convert.ToString(LexemClassificationDataGridView.Rows.Count);
        }

        private void LexemButtonControl(NavigatorButtonControl navigator, Button first,
            Button previous, Button next, Button last)
        {
            bool isNotNoneElement = navigator != NavigatorButtonControl.NonControl;
            bool isNotFirstElement = isNotNoneElement &&
                (navigator != NavigatorButtonControl.OneNode) &&
                (navigator != NavigatorButtonControl.First);
            bool isNotLastElement = isNotNoneElement &&
                (navigator != NavigatorButtonControl.OneNode) &&
                (navigator != NavigatorButtonControl.Last);
            first.Enabled = isNotFirstElement;
            previous.Enabled = isNotFirstElement;
            next.Enabled = isNotLastElement;
            last.Enabled = isNotLastElement;
        }

        private void EnterCodeRichTextBox_VScroll(object sender, EventArgs e)
        {
            int barPosition = GetScrollPos(EnterCodeRichTextBox.Handle, 1);
            barPosition <<= 16;
            uint wParam = 4 | (uint)barPosition;
            SendMessage(LineCodeNumberRichTextBox.Handle, (uint)0x0115, 
                new IntPtr(wParam), new IntPtr(0));
        }

        private void CompilationApplicationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Position != CodeAnalyzer.StartPosition)
            {
                bool exitRequest = QuestionMessage(
                    "Вы действительно хотите отменить пошаговую компиляцию " +
                    "программного кода и завершить работу в приложении?",
                    "Запрос на выход с программы");
                if (exitRequest)
                {
                    Application.ExitThread();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                Application.ExitThread();
            }
        }

        // <

        private void NextParserAnalyzeCodeButton_Click(object sender, EventArgs e)
        {
            LexemClassificationGroupBox.Visible = false;
            SyntaxAnalyisResultGroupBox.Visible = true;
            AnalyzerTypeToolStripLabel.Text = "Синтаксический анализатор";
            ThirdToolStripSeparator.Visible = false;
            AnalyzerTypeStepToolStripLabel.Visible = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            label2.Text = "1";
            label1.Text = "128";
            dataGridView1.Rows.Add("1", "", "program", "0", "сдвиг", "0");
            dataGridView1.Rows.Add("2", "program", "<идент>", "0", "переход", "3");
            dataGridView1.Rows.Add("3", "program", "<идент>", "3", "сдвиг, переход", "5");
            dataGridView1.Rows.Add("4", "<идент>", ";", "5", "сдвиг, переход", "10");
            dataGridView1.Rows.Add("5", ";", "var", "10", "приведение (-3) к <объяв_прог>", "0");
            dataGridView1.Rows.Add("6", "<объяв_прог>", "var", "0", "переход", "2");
            dataGridView1.Rows.Add("7", "<объяв_прог>", "var", "2", "сдвиг, переход", "4");
            dataGridView1.Rows.Add("8", "var", "<идент>", "4", "сдвиг, переход", "9");
            dataGridView1.Rows.Add("125", "<тело>", "", "11", "приведение (-4) к <прог>", "0");
            dataGridView1.Rows.Add("126", "<прог>", "", "0", "переход", "1");
            dataGridView1.Rows.Add("127", "<прог>", "", "1", "приведение (-1) к S", "0");
            dataGridView1.Rows.Add("128", "S", "", "0", "конец разбора", "-");
            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
            FirstStackItemButton.Enabled = false;
            PreviousStackItemButton.Enabled = false;
            NextStackItemButton.Enabled = false;
            LastStackItemButton.Enabled = false;
            SyntaxActionDataGridView.Rows.Add("1", "сдвиг");
            FirstActionButton.Enabled = false;
            PreviousActionButton.Enabled = false;
            NextActionButton.Enabled = false;
            LastActionButton.Enabled = false;
            label12.Text = "program";
            label9.Text = "0";
            label10.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index == 0)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[1].Cells[0];
                label2.Text = "2";
                button2.Enabled = true;
                button4.Enabled = true;
                StackListDataGridView.Rows.Clear();
                StackListDataGridView.Rows.Add("1", "program");
                FirstStackItemButton.Enabled = false;
                PreviousStackItemButton.Enabled = false;
                NextStackItemButton.Enabled = false;
                LastStackItemButton.Enabled = false;
                SyntaxActionDataGridView.Rows.Clear();
                SyntaxActionDataGridView.Rows.Add("1", "переход в 3");
                FirstActionButton.Enabled = false;
                PreviousActionButton.Enabled = false;
                NextActionButton.Enabled = false;
                LastActionButton.Enabled = false;
                label12.Text = "<идент>";
                label9.Text = "0";
                label10.Text = "3";
            }
            else if (dataGridView1.CurrentRow.Index == 1)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[2].Cells[0];
                label2.Text = "3";
                StackListDataGridView.Rows.Clear();
                StackListDataGridView.Rows.Add("1", "program");
                FirstStackItemButton.Enabled = false;
                PreviousStackItemButton.Enabled = false;
                NextStackItemButton.Enabled = false;
                LastStackItemButton.Enabled = false;
                SyntaxActionDataGridView.Rows.Clear();
                SyntaxActionDataGridView.Rows.Add("1", "сдвиг");
                SyntaxActionDataGridView.Rows.Add("2", "переход в 5");
                FirstActionButton.Enabled = false;
                PreviousActionButton.Enabled = false;
                NextActionButton.Enabled = true;
                LastActionButton.Enabled = true;
                label12.Text = "<идент>";
                label9.Text = "3";
                label10.Text = "5";
            }
            else if (dataGridView1.CurrentRow.Index == 2)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[3].Cells[0];
                label2.Text = "4";
                StackListDataGridView.Rows.Clear();
                StackListDataGridView.Rows.Add("1", "program");
                StackListDataGridView.Rows.Add("2", "<идент>");
                FirstStackItemButton.Enabled = false;
                PreviousStackItemButton.Enabled = false;
                NextStackItemButton.Enabled = true;
                LastStackItemButton.Enabled = true;
                SyntaxActionDataGridView.Rows.Clear();
                SyntaxActionDataGridView.Rows.Add("1", "сдвиг");
                SyntaxActionDataGridView.Rows.Add("2", "переход в 10");
                FirstActionButton.Enabled = false;
                PreviousActionButton.Enabled = false;
                NextActionButton.Enabled = true;
                LastActionButton.Enabled = true;
                label12.Text = ";";
                label9.Text = "5";
                label10.Text = "10";
            }
            else if (dataGridView1.CurrentRow.Index == 3)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[4].Cells[0];
                label2.Text = "5";
                StackListDataGridView.Rows.Clear();
                StackListDataGridView.Rows.Add("1", "program");
                StackListDataGridView.Rows.Add("2", "<идент>");
                StackListDataGridView.Rows.Add("3", ";");
                FirstStackItemButton.Enabled = false;
                PreviousStackItemButton.Enabled = false;
                NextStackItemButton.Enabled = true;
                LastStackItemButton.Enabled = true;
                SyntaxActionDataGridView.Rows.Clear();
                SyntaxActionDataGridView.Rows.Add("1", "приведение (-3) к <объяв_прог>");
                FirstActionButton.Enabled = false;
                PreviousActionButton.Enabled = false;
                NextActionButton.Enabled = false;
                LastActionButton.Enabled = false;
                label12.Text = "var";
                label9.Text = "10";
                label10.Text = "0";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = dataGridView1.Rows[11].Cells[0];
            label2.Text = "128";
            button1.Enabled = false;
            button3.Enabled = false;
            StackListDataGridView.Rows.Clear();
            StackListDataGridView.Rows.Add("1", "S");
            FirstStackItemButton.Enabled = false;
            PreviousStackItemButton.Enabled = false;
            NextStackItemButton.Enabled = false;
            LastStackItemButton.Enabled = false;
            SyntaxActionDataGridView.Rows.Clear();
            SyntaxActionDataGridView.Rows.Add("1", "конец разбора");
            FirstActionButton.Enabled = false;
            PreviousActionButton.Enabled = false;
            NextActionButton.Enabled = false;
            LastActionButton.Enabled = false;
            label12.Text = "";
            label9.Text = "0";
            label10.Text = "-";
        }

        private void NextStackItemButton_Click(object sender, EventArgs e)
        {
            if (StackListDataGridView.CurrentRow.Index < StackListDataGridView.Rows.Count - 2)
            {
                FirstStackItemButton.Enabled = true;
                PreviousStackItemButton.Enabled = true;
                NextStackItemButton.Enabled = true;
                LastStackItemButton.Enabled = true;
            }
            else
            {
                FirstStackItemButton.Enabled = true;
                PreviousStackItemButton.Enabled = true;
                NextStackItemButton.Enabled = false;
                LastStackItemButton.Enabled = false;
            }
            StackListDataGridView.CurrentCell = StackListDataGridView.Rows[StackListDataGridView.CurrentRow.Index + 1].Cells[0];
        }

        // >
    }
}