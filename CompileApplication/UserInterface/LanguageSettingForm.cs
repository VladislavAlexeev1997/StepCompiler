using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CompileApplication.Model.LexemTypes;
using CompileApplication.Views;
using CompileApplication.Views.Enums;
using CompileApplication.UserInterface.ModernControl;

namespace CompileApplication.UserInterface
{
    public partial class LanguageSettingForm : Form, ILanguageSettingView
    {
        private LanguageSetting _status;

        public event Action AddNewLanguageEnterText;

        public event Action AddNewLanguageLeaveText;

        public event Action AddNewLanguage;

        public event Action SelectedLanguage;

        public event Action ClearAddLanguageControl;

        public event Action DeleteSelectLanguage;

        public event Action AddNewVersionEnterText;

        public event Action AddNewVersionLeaveText;

        public event Action AddNewVersion;

        public event Action ClearAddVersionControl;

        public event Action SelectedVersion;

        public event Action DeleteSelectVersion;

        public event Action AddNewLexemItemEnterText;

        public event Action AddNewLexemCommentEnterText;

        public event Action AddNewLexemItemLeaveText;

        public event Action AddNewLexemCommentLeaveText;

        public event Action AddNewLexem;

        public event Action ClearAddLexemControl;

        public event Action SelectedCurrentSeparator;

        public event Action FirstSeparator;

        public event Action PreviousSeparator;

        public event Action NextSeparator;

        public event Action LastSeparator;

        public event Action EditCurrentSeparator;

        public event Action SaveEditCurrentSeparator;

        public event Action CancelEditCurrentSeparator;

        public event Action DeleteCurrentSeparator;

        public event Action SelectedCurrentKeyword;

        public event Action FirstKeyword;

        public event Action PreviousKeyword;

        public event Action NextKeyword;

        public event Action LastKeyword;

        public event Action EditCurrentKeyword;

        public event Action SaveEditCurrentKeyword;

        public event Action CancelEditCurrentKeyword;

        public event Action DeleteCurrentKeyword;

        public event Action SelectedCurrentComment;

        public event Action FirstComment;

        public event Action PreviousComment;

        public event Action NextComment;

        public event Action LastComment;

        public event Action EditCurrentComment;

        public event Action SaveEditCurrentComment;

        public event Action CancelEditCurrentComment;

        public event Action DeleteCurrentComment;

        public event Action CloseLanguageSetting;

        public LanguageSettingForm()
        {
            InitializeComponent();
            UserDataGridViewsCustomer();
        }

        public LanguageSetting Position
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

        public string SelectLanguage
        {
            get { return (string)CheckLanguageComboBox.SelectedItem; }
        }

        public int SelectLanguageIndex
        {
            get { return CheckLanguageComboBox.SelectedIndex; }
            set { CheckLanguageComboBox.SelectedIndex = value; }
        }

        public List<string> LanguageVersions
        {
            set
            {
                CheckLanguageVersionComboBox.Items.Clear();
                CheckLanguageVersionComboBox.Items.AddRange(value.ToArray());
            }
        }

        public string SelectVersion
        {
            get { return (string)CheckLanguageVersionComboBox.SelectedItem; }
        }

        public int SelectVersionIndex
        {
            get { return CheckLanguageVersionComboBox.SelectedIndex; }
            set { CheckLanguageVersionComboBox.SelectedIndex = value; }
        }

        public string AddLanguage
        {
            get { return AddLanguageNameTextBox.Text; }
            set { AddLanguageNameTextBox.Text = value; }
        }

        public string AddVersion
        {
            get { return AddLanguageVersionTypeTextBox.Text; }
            set { AddLanguageVersionTypeTextBox.Text = value; }
        }

        public LexemType AddLexemType
        {
            get { return (LexemType)AddLanguageLexemTypeComboBox.SelectedIndex; }
            set { AddLanguageLexemTypeComboBox.SelectedIndex = (int)value; }
        }

        public string AddLexemItem
        {
            get { return AddLanguageLexemNameTextBox.Text; }
            set { AddLanguageLexemNameTextBox.Text = value; }
        }

        public string AddLexemComment
        {
            get { return AddLanguageLexemCommentTextBox.Text; }
            set { AddLanguageLexemCommentTextBox.Text = value; }
        }

        public Separator CurrentSeparator
        {
            set
            {
                ViewSeparatorLabel.Text = value.Item;
                ViewSeparatorCommentLabel.Text = value.Commentary;
            }
        }

        public int CurrentSeparatorIndex
        {
            private get { return LanguageSeparatorsDataGridView.CurrentRow.Index; }
            set
            {
                LanguageSeparatorsDataGridView.CurrentCell =
                    LanguageSeparatorsDataGridView.Rows[value].Cells[0];
            }
        }

        public Separator EditSeparator
        {
            get
            {
                return new Separator(EnterSeparatorTextBox.Text,
                    EnterSeparatorCommentTextBox.Text);
            }
            set
            {
                EnterSeparatorTextBox.Text = value.Item;
                EnterSeparatorCommentTextBox.Text = value.Commentary;
            }
        }

        public bool IsVisibleEditSeparator
        {
            set
            {
                ViewSeparatorLabel.Visible = !value;
                ViewSeparatorCommentLabel.Visible = !value;
                EnterSeparatorTextBox.Visible = value;
                EnterSeparatorCommentTextBox.Visible = value;
            }
        }

        public Keyword CurrentKeyword
        {
            set
            {
                ViewKeyWordLabel.Text = value.Item;
                ViewKeyWordCommentLabel.Text = value.Commentary;
            }
        }

        public int CurrentKeywordIndex
        {
            private get { return LanguageKeyWordsDataGridView.CurrentRow.Index; }
            set
            {
                LanguageKeyWordsDataGridView.CurrentCell =
                    LanguageKeyWordsDataGridView.Rows[value].Cells[0];
            }
        }

        public Keyword EditKeyword
        {
            get
            {
                return new Keyword(EnterKeyWordTextBox.Text,
                    EnterKeyWordCommentTextBox.Text);
            }
            set
            {
                EnterKeyWordTextBox.Text = value.Item;
                EnterKeyWordCommentTextBox.Text = value.Commentary;
            }
        }

        public bool IsVisibleEditKeyword
        {
            set
            {
                ViewKeyWordLabel.Visible = !value;
                ViewKeyWordCommentLabel.Visible = !value;
                EnterKeyWordTextBox.Visible = value;
                EnterKeyWordCommentTextBox.Visible = value;
            }
        }

        public Comment CurrentComment
        {
            set
            {
                ViewCommLexemLabel.Text = value.Item;
                ViewCommLexemCommentLabel.Text = value.Commentary;
            }
        }

        public int CurrentCommentIndex
        {
            private get { return LanguageCommLexemsDataGridView.CurrentRow.Index; }
            set
            {
                LanguageCommLexemsDataGridView.CurrentCell =
                    LanguageCommLexemsDataGridView.Rows[value].Cells[0];
            }
        }

        public Comment EditComment
        {
            get
            {
                return new Comment(EnterCommLexemTextBox.Text,
                    EnterCommLexemCommentTextBox.Text);
            }
            set
            {
                EnterCommLexemTextBox.Text = value.Item;
                EnterCommLexemCommentTextBox.Text = value.Commentary;
            }
        }

        public bool IsVisibleEditComment
        {
            set
            {
                ViewCommLexemLabel.Visible = !value;
                ViewCommLexemCommentLabel.Visible = !value;
                EnterCommLexemTextBox.Visible = value;
                EnterCommLexemCommentTextBox.Visible = value;
            }
        }

        public void AddLanguageMasked(string mask, Color color)
        {
            AddLanguageNameTextBox.Text = mask;
            AddLanguageNameTextBox.ForeColor = color;
        }

        public void AddVersionMasked(string mask, Color color)
        {
            AddLanguageVersionTypeTextBox.Text = mask;
            AddLanguageVersionTypeTextBox.ForeColor = color;
        }

        public void AddLexemItemMasked(string mask, Color color)
        {
            AddLanguageLexemNameTextBox.Text = mask;
            AddLanguageLexemNameTextBox.ForeColor = color;
        }

        public void AddLexemCommentMasked(string mask, Color color)
        {
            AddLanguageLexemCommentTextBox.Text = mask;
            AddLanguageLexemCommentTextBox.ForeColor = color;
        }

        public void AddSeparator(Separator separator)
        {
            LanguageSeparatorsDataGridView.Rows.Add(
                LanguageSeparatorsDataGridView.Rows.Count + 1,
                separator.Item);
        }

        public void SetSeparatorList(List<Separator> separators)
        {
            LanguageSeparatorsDataGridView.Rows.Clear();
            foreach(Separator separator in separators)
            {
                AddSeparator(separator);
            }
        }

        public void SeparatorButtonControl(NavigatorButtonControl navigator, bool isEdit)
        {
            LexemButtonControl(navigator, isEdit, FirstSeparatorDataButton,
                PreviousSeparatorDataButton, NextSeparatorDataButton, LastSeparatorDataButton,
                EditSeparatorDataButton, DeleteSeparatorDataButton, CurrentLanguageSeparatorNonEditLabel);
        }

        public void CurrentSeparatorMasked(Separator mask, Color color)
        {
            ViewSeparatorLabel.Text = mask.Item;
            ViewSeparatorLabel.ForeColor = color;
            ViewSeparatorCommentLabel.Text = mask.Commentary;
            ViewSeparatorCommentLabel.ForeColor = color;
        }

        public void UpdateEditTableCurrentSeparator(Separator separator)
        {
            LanguageSeparatorsDataGridView.Rows[CurrentSeparatorIndex].Cells[1].Value = 
                separator.Item;
        }

        public void AddKeyword(Keyword keyword)
        {
            LanguageKeyWordsDataGridView.Rows.Add(
                LanguageKeyWordsDataGridView.Rows.Count + 1,
                keyword.Item);
        }

        public void SetKeywordList(List<Keyword> keywords)
        {
            LanguageKeyWordsDataGridView.Rows.Clear();
            foreach (Keyword keyword in keywords)
            {
                AddKeyword(keyword);
            }
        }

        public void KeywordButtonControl(NavigatorButtonControl navigator, bool isEdit)
        {
            LexemButtonControl(navigator, isEdit, FirstKeyWordDataButton,
                PreviousKeyWordDataButton, NextKeyWordDataButton, LastKeyWordDataButton,
                EditKeyWordDataButton, DeleteKeyWordDataButton, CurrentLanguageKeyWordNonEditLabel);
        }

        public void CurrentKeywordMasked(Keyword mask, Color color)
        {
            ViewKeyWordLabel.Text = mask.Item;
            ViewKeyWordLabel.ForeColor = color;
            ViewKeyWordCommentLabel.Text = mask.Commentary;
            ViewKeyWordCommentLabel.ForeColor = color;
        }

        public void UpdateEditTableCurrentKeyword(Keyword keyword)
        {
            LanguageKeyWordsDataGridView.Rows[CurrentKeywordIndex].Cells[1].Value =
                keyword.Item;
        }

        public void AddComment(Comment comment)
        {
            LanguageCommLexemsDataGridView.Rows.Add(
                LanguageCommLexemsDataGridView.Rows.Count + 1,
                comment.Item);
        }

        public void SetCommentList(List<Comment> comments)
        {
            LanguageCommLexemsDataGridView.Rows.Clear();
            foreach (Comment comment in comments)
            {
                AddComment(comment);
            }
        }

        public void CommentButtonControl(NavigatorButtonControl navigator, bool isEdit)
        {
            LexemButtonControl(navigator, isEdit, FirstCommLexemDataButton, 
                PreviousCommLexemDataButton, NextCommLexemDataButton, LastCommLexemDataButton,
                EditCommLexemDataButton, DeleteCommLexemDataButton, CurrentLanguageCommentNonEditLabel);
        }

        public void CurrentCommentMasked(Comment mask, Color color)
        {
            ViewCommLexemLabel.Text = mask.Item;
            ViewCommLexemLabel.ForeColor = color;
            ViewCommLexemCommentLabel.Text = mask.Commentary;
            ViewCommLexemCommentLabel.ForeColor = color;
        }

        public void UpdateEditTableCurrentComment(Comment comment)
        {
            LanguageCommLexemsDataGridView.Rows[CurrentCommentIndex].Cells[1].Value =
                comment.Item;
        }

        public void InformationMessage(string message, string name)
        {
            MessageBox.Show(message, name, MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        public void WarningMessage(string message, string name)
        {
            MessageBox.Show(message, name, MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        public bool QuestionMessage(string message, string name)
        {
            DialogResult result = MessageBox.Show(message, name,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
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
            AddLanguageNameTextBox.Enter += (sender, args) => AddNewLanguageEnterText();
            AddLanguageNameTextBox.Leave += (sender, args) => AddNewLanguageLeaveText();
            AddLanguageButton.Click += (sender, args) => AddNewLanguage();
            ClearAddLanguageControlButton.Click += (sender, args) => ClearAddLanguageControl();
            CheckLanguageComboBox.SelectedValueChanged += (sender, args) => SelectedLanguage();
            DeleteLanguageButton.Click += (sender, args) => DeleteSelectLanguage();
            AddLanguageVersionTypeTextBox.Enter += (sender, args) => AddNewVersionEnterText();
            AddLanguageVersionTypeTextBox.Leave += (sender, args) => AddNewVersionLeaveText();
            AddLanguageVersionButton.Click += (sender, args) => AddNewVersion();
            ClearAddLanguageVersionButton.Click += (ender, args) => ClearAddVersionControl();
            CheckLanguageVersionComboBox.SelectedValueChanged += (sender, args) => SelectedVersion();
            DeleteLanguageVersionButton.Click += (sender, args) => DeleteSelectVersion();
            AddLanguageLexemNameTextBox.Enter += (sender, args) => AddNewLexemItemEnterText();
            AddLanguageLexemCommentTextBox.Enter += (sender, args) => AddNewLexemCommentEnterText();
            AddLanguageLexemNameTextBox.Leave += (sender, args) => AddNewLexemItemLeaveText();
            AddLanguageLexemCommentTextBox.Leave += (sender, args) => AddNewLexemCommentLeaveText();
            AddLanguageLexemButton.Click += (sender, args) => AddNewLexem();
            ClearAddLanguageLexemButton.Click += (sender, args) => ClearAddLexemControl();
            LanguageSeparatorsDataGridView.CurrentCellChanged += (sender, args) => SelectedCurrentSeparator();
            FirstSeparatorDataButton.Click += (sender, args) => FirstSeparator();
            PreviousSeparatorDataButton.Click += (sender, args) => PreviousSeparator();
            NextSeparatorDataButton.Click += (sender, args) => NextSeparator();
            LastSeparatorDataButton.Click += (sender, args) => LastSeparator();
            EditSeparatorDataButton.Click += (sender, args) => EditCurrentSeparator();
            SaveEditSeparatorDataButton.Click += (sender, args) => SaveEditCurrentSeparator();
            CancelEditSeparatorDataButton.Click += (sender, args) => CancelEditCurrentSeparator();
            DeleteSeparatorDataButton.Click += (sender, args) => DeleteCurrentSeparator();
            LanguageKeyWordsDataGridView.CurrentCellChanged += (sender, args) => SelectedCurrentKeyword();
            FirstKeyWordDataButton.Click += (sender, args) => FirstKeyword();
            PreviousKeyWordDataButton.Click += (sender, args) => PreviousKeyword();
            NextKeyWordDataButton.Click += (sender, args) => NextKeyword();
            LastKeyWordDataButton.Click += (sender, args) => LastKeyword();
            EditKeyWordDataButton.Click += (sender, args) => EditCurrentKeyword();
            SaveEditKeyWordDataButton.Click += (sender, args) => SaveEditCurrentKeyword();
            CancelEditKeyWordDataButton.Click += (sender, args) => CancelEditCurrentKeyword();
            DeleteKeyWordDataButton.Click += (sender, args) => DeleteCurrentKeyword();
            LanguageCommLexemsDataGridView.CurrentCellChanged += (sender, args) => SelectedCurrentComment();
            FirstCommLexemDataButton.Click += (sender, args) => FirstComment();
            PreviousCommLexemDataButton.Click += (sender, args) => PreviousComment();
            NextCommLexemDataButton.Click += (sender, args) => NextComment();
            LastCommLexemDataButton.Click += (sender, args) => LastComment();
            EditCommLexemDataButton.Click += (sender, args) => EditCurrentComment();
            SaveEditCommLexemDataButton.Click += (sender, args) => SaveEditCurrentComment();
            CancelEditCommLexemDataButton.Click += (sender, args) => CancelEditCurrentComment();
            DeleteCommLexemDataButton.Click += (sender, args) => DeleteCurrentComment();
            CloseLanguageSettingButton.Click += (sender, args) => CloseInterface();
            FormClosing += (sender, args) => CloseLanguageSetting();
        }

        private void UserDataGridViewsCustomer()
        {
            ApplicationDataGridViewCustomer languageSeparatorsCustomer =
                new ApplicationDataGridViewCustomer(LanguageSeparatorsDataGridView);
            languageSeparatorsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "№","NumberRowColumn", 40);
            languageSeparatorsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Лексема", "LexemRowColumn", 68);
            ApplicationDataGridViewCustomer languageKeyWordsCustomer =
                new ApplicationDataGridViewCustomer(LanguageKeyWordsDataGridView);
            languageKeyWordsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "№", "NumberRowColumn", 40);
            languageKeyWordsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Лексема", "LexemRowColumn", 94);
            ApplicationDataGridViewCustomer languageCommLexemsCustomer =
                new ApplicationDataGridViewCustomer(LanguageCommLexemsDataGridView);
            languageCommLexemsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "№", "NumberRowColumn", 40);
            languageCommLexemsCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Лексема", "LexemRowColumn", 94);
        }

        private void FormElementControl(LanguageSetting position)
        {
            _status = position;
            bool isEditSeparator = position == LanguageSetting.EditSeparator;
            bool isEditKeyword = position == LanguageSetting.EditKeyword;
            bool isEditComment = position == LanguageSetting.EditComment;
            bool isNotEditLexems = !isEditSeparator && !isEditKeyword && !isEditComment;
            bool isSelectedLanguage = isNotEditLexems && (position != LanguageSetting.OpenSetting);
            bool isSelectedVersion = isSelectedLanguage && (position != LanguageSetting.SelectLanguage);
            bool isClearLexemLists = (position == LanguageSetting.OpenSetting) ||
                (position == LanguageSetting.SelectLanguage);
            CheckLanguageComboBox.Enabled = isNotEditLexems;
            DeleteLanguageButton.Enabled = isSelectedLanguage;
            CheckLanguageVersionComboBox.Enabled = isSelectedLanguage;
            DeleteLanguageVersionButton.Enabled = isSelectedVersion &&
                (position != LanguageSetting.SelectAllVersion);
            AddLanguageButton.Enabled = isNotEditLexems;
            AddLanguageVersionButton.Enabled = isSelectedLanguage;
            AddLanguageLexemButton.Enabled = isSelectedVersion;
            FirstSeparatorDataButton.Enabled = isSelectedVersion;
            PreviousSeparatorDataButton.Enabled = isSelectedVersion;
            NextSeparatorDataButton.Enabled = isSelectedVersion;
            LastSeparatorDataButton.Enabled = isSelectedVersion;
            EditSeparatorDataButton.Enabled = isSelectedVersion;
            SaveEditSeparatorDataButton.Enabled = isEditSeparator;
            CancelEditSeparatorDataButton.Enabled = isEditSeparator;
            DeleteSeparatorDataButton.Enabled = isSelectedVersion;
            FirstKeyWordDataButton.Enabled = isSelectedVersion;
            PreviousKeyWordDataButton.Enabled = isSelectedVersion;
            NextKeyWordDataButton.Enabled = isSelectedVersion;
            LastKeyWordDataButton.Enabled = isSelectedVersion;
            EditKeyWordDataButton.Enabled = isSelectedVersion;
            SaveEditKeyWordDataButton.Enabled = isEditKeyword;
            CancelEditKeyWordDataButton.Enabled = isEditKeyword;
            DeleteKeyWordDataButton.Enabled = isSelectedVersion;
            FirstCommLexemDataButton.Enabled = isSelectedVersion;
            PreviousCommLexemDataButton.Enabled = isSelectedVersion;
            NextCommLexemDataButton.Enabled = isSelectedVersion;
            LastCommLexemDataButton.Enabled = isSelectedVersion;
            EditCommLexemDataButton.Enabled = isSelectedVersion;
            SaveEditCommLexemDataButton.Enabled = isEditComment;
            CancelEditCommLexemDataButton.Enabled = isEditComment;
            DeleteCommLexemDataButton.Enabled = isSelectedVersion;
            if (isClearLexemLists)
            {
                LanguageSeparatorsDataGridView.Rows.Clear();
                LanguageKeyWordsDataGridView.Rows.Clear();
                LanguageCommLexemsDataGridView.Rows.Clear();
            }
            CloseLanguageSettingButton.Enabled = isNotEditLexems;
            CurrentLanguageSeparatorNonEditLabel.Visible = false;
            CurrentLanguageKeyWordNonEditLabel.Visible = false;
            CurrentLanguageCommentNonEditLabel.Visible = false;
        }

        private void LexemButtonControl(NavigatorButtonControl navigator, bool isEdit,
            Button first, Button previous, Button next, Button last, 
            Button edit, Button delete, Label nonEdit)
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
            edit.Enabled = isNotNoneElement;
            delete.Enabled = isNotNoneElement;
            nonEdit.Visible = !isEdit;
        }

        private void AddLanguageNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string pattern = @"[0-9]|[A-Za-z]|[А-Яа-я]|[#+/*-.\s\b]";
            if (!(Regex.Match(e.KeyChar.ToString(), pattern).Success))
            {
                e.Handled = true;
            }
        }

        private void AddLanguageVersionTypeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string pattern = @"[0-9]|[A-Za-z]|[А-Яа-я]|[-/.\s\b]";
            if (!(Regex.Match(e.KeyChar.ToString(), pattern).Success))
            {
                e.Handled = true;
            }
        }

        private void EnterLexem_KeyPress(object sender, KeyPressEventArgs e)
        {
            string pattern = @"[0-9]|[\s\t\r\n]";
            if (Regex.Match(e.KeyChar.ToString(), pattern).Success)
            {
                e.Handled = true;
            }
        }

        private void EnterLexemComment_KeyPress(object sender, KeyPressEventArgs e)
        {
            string pattern = @"[0-9]|[А-Яа-я]|[-(),!?:.\s\b]";
            if (!(Regex.Match(e.KeyChar.ToString(), pattern).Success))
            {
                e.Handled = true;
            }
        }
    }
}