using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompileApplication.UserInterface.ModernControl;
using CompileApplication.Views;
using CompileApplication.Views.Enums;

namespace CompileApplication.UserInterface
{
    public partial class SyntaxLanguageSettingForm : Form, ISyntaxLanguageSettingView
    {
        private SyntaxLanguageSetting _status;

        public event Action SelectedLanguage;

        public event Action SelectedVersion;

        public event Action CloseSyntaxLanguageSetting;

        public event Action SelectedState;

        public SyntaxLanguageSetting Position
        {
            get { return _status; }
            set
            {
                FormElementControl(value);
            }
        }

        public List<string> Languages
        {
            set
            {
                CheckLanguageComboBox.Items.Clear();
                CheckLanguageComboBox.Items.AddRange(value.ToArray());
            }
        }

        public List<string> LanguageVersions
        {
            set
            {
                CheckLanguageVersionComboBox.Items.Clear();
                CheckLanguageVersionComboBox.Items.AddRange(value.ToArray());
            }
        }

        public string SelectLanguage
        {
            get
            {
                return (string)CheckLanguageComboBox.SelectedItem;
            }
        }

        public string SelectVersion
        {
            get
            {
                return (string)CheckLanguageVersionComboBox.SelectedItem;
            }
        }

        public int SelectLanguageIndex
        {
            get { return CheckLanguageComboBox.SelectedIndex; }
            set { CheckLanguageComboBox.SelectedIndex = value; }
        }

        public int SelectVersionIndex
        {
            get { return CheckLanguageVersionComboBox.SelectedIndex; }
            set { CheckLanguageVersionComboBox.SelectedIndex = value; }
        }

        public int SelectStateIndex
        {
            get { return CheckCurrentTableStateComboBox.SelectedIndex; }
            set { CheckCurrentTableStateComboBox.SelectedIndex = value; }
        }

        public SyntaxLanguageSettingForm()
        {
            InitializeComponent();
            UserDataGridViewsCustomer();
        }

        public void AddDetermenisticState()
        {
            CheckCurrentTableStateComboBox.Items.Add(
                CheckCurrentTableStateComboBox.Items.Count);
        }

        public void SetDetermenisticStateList(int determenisticStateCount)
        {
            CheckCurrentTableStateComboBox.Items.Clear();
            for (int index = 0; index < determenisticStateCount; index++)
            {
                AddDetermenisticState();
            }
        }

        public void ShowInterface()
        {
            Show();
        }

        public void CloseInterface()
        {
            Close();
        }

        public void UpdateViewEvents()
        {
            CheckLanguageComboBox.SelectedValueChanged += (sender, args) => SelectedLanguage();
            CheckLanguageVersionComboBox.SelectedValueChanged += (sender, args) => SelectedVersion();
            CheckCurrentTableStateComboBox.SelectedValueChanged += (sender, args) => SelectedState();
            CloseSyntaxLanguageSettingButton.Click += (sender, args) => CloseInterface();
            FormClosing += (sender, args) => CloseSyntaxLanguageSetting();
        }

        private void UserDataGridViewsCustomer()
        {
            ApplicationDataGridViewCustomer syntaxDeterministicTableCustomer =
                new ApplicationDataGridViewCustomer(SyntaxDeterministicTableDataGridView);
            syntaxDeterministicTableCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Последние элементы стека", "StackRowColumn", 235);
            syntaxDeterministicTableCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Вход", "EnterLexemRowColumn", 75);
            syntaxDeterministicTableCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Действие", "ActionRowColumn", 155);
            ApplicationDataGridViewCustomer stackListCustomer =
                new ApplicationDataGridViewCustomer(StackListDataGridView);
            stackListCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "№", "NumberRowColumn", 40);
            stackListCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Лексема стека", "StackLexemRowColumn", 134);
            ApplicationDataGridViewCustomer syntaxActionCustomer =
                new ApplicationDataGridViewCustomer(SyntaxActionDataGridView);
            syntaxActionCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "№", "NumberRowColumn", 30);
            syntaxActionCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Действие", "ActionRowColumn", 154);
            ApplicationDataGridViewCustomer otherLanguageLexemsCustomer =
                new ApplicationDataGridViewCustomer(OtherLanguageLexemsDataGridView);
            otherLanguageLexemsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "№", "NumberRowColumn", 39);
            otherLanguageLexemsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Лексема", "OtherLexemRowColumn", 130);
        }

        private void FormElementControl(SyntaxLanguageSetting position)
        {

        }
    }
}
