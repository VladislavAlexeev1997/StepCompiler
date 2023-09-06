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
// <
using CompileApplication.Model.LanguageStruct;
using CompileApplication.Model.Tools;
using CompileApplication.Model.LexemTypes;
using CompileApplication.Model.DeterministicTableElements;
using CompileApplication.Model.SyntaxActionTypes;
//>

namespace CompileApplication.UserInterface
{
    public partial class SelectLexemForm : Form
    {
        // <
        Model.LanguageStruct.Version CurrentVersion;

        SyntaxLanguageSettingForm ParentForm;
        // >

        public SelectLexemForm(string nameForm, SyntaxLanguageSettingForm parent)
        {
            InitializeComponent();
            UserDataGridViewsCustomer();
            // <
            Text = nameForm;
            ParentForm = parent;
            CurrentVersion = new Model.LanguageStruct.Version("Общая версия",
                new ViewerList<Separator>(new List<Separator>() {
                    new Separator(":=", ""), new Separator(";", ""), new Separator(":", ""),
                    new Separator(",", ""), new Separator("\"", ""), new Separator("(", ""),
                    new Separator(")", ""), new Separator("<", ""), new Separator(".", "")}),
                new ViewerList<Keyword>(new List<Keyword>() {
                    new Keyword("program", ""), new Keyword("var", ""), new Keyword("string", ""),
                    new Keyword("integer", ""), new Keyword("begin", ""), new Keyword("readln", ""),
                    new Keyword("if", ""), new Keyword("then", ""), new Keyword("writeln", ""),
                    new Keyword("else", ""), new Keyword("end", "")}),
                new ViewerList<Comment>(),
                new ViewerList<OtherLexem>(new List<OtherLexem>() {
                    new OtherLexem("S", false), new OtherLexem("ε", false)}),
                new Identificator("<идент>", false), new Number("<число>", false), new Literal("<литерал>", false),
                new ViewerList<DeterministicState>(new List<DeterministicState>() {
                    new DeterministicState(new ViewerList<DeterministicElement>(new List<DeterministicElement>(){
                        new DeterministicElement(new ViewerList<Lexem>(new List<Lexem>() {
                            new OtherLexem("S")}), null, new ViewerList<IAction>(new List<IAction>() {
                            new EndAction()}), false),
                        new DeterministicElement(new ViewerList<Lexem>(new List<Lexem>() {
                            new OtherLexem("ε")}), null, new ViewerList<IAction>(new List<IAction>() {
                            new ShiftAction()}), false)}), false)})
                );
            OtherLexemTypeComboBox.Items.AddRange(new string[] { "--тип лексемы--", "разделитель", "ключевое слово", "дополнительная",
                "идентификатор", "литерал", "число"});
            OtherLexemTypeComboBox.SelectedIndex = 0;
            // >
        }

        private void UserDataGridViewsCustomer()
        {
            ApplicationDataGridViewCustomer stackListCustomer =
                new ApplicationDataGridViewCustomer(StackListDataGridView);
            stackListCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "№", "NumberRowColumn", 40);
            stackListCustomer.AddDataGridViewColumn(
                new DataGridViewTextBoxColumn(), "Лексема", "StackLexemRowColumn", 134);
        }

        // <

        private void OtherLexemTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OtherLexemTypeComboBox.SelectedIndex == 0)
            {
                FirstStackItemButton.Enabled = false;
                PreviousStackItemButton.Enabled = false;
                NextStackItemButton.Enabled = false;
                LastStackItemButton.Enabled = false;
                button1.Enabled = false;
            }
            else if (OtherLexemTypeComboBox.SelectedIndex == 4)
            {
                FirstStackItemButton.Enabled = false;
                PreviousStackItemButton.Enabled = false;
                NextStackItemButton.Enabled = false;
                LastStackItemButton.Enabled = false;
                button1.Enabled = true;
                StackListDataGridView.Rows.Add(1, "<идент>");
            }
            else if (OtherLexemTypeComboBox.SelectedIndex == 2)
            {
                FirstStackItemButton.Enabled = false;
                PreviousStackItemButton.Enabled = false;
                NextStackItemButton.Enabled = true;
                LastStackItemButton.Enabled = true;
                button1.Enabled = true;
                foreach(Keyword k in CurrentVersion.Keywords.ToList())
                {
                    StackListDataGridView.Rows.Add(StackListDataGridView.Rows.Count + 1, k.Item);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Text == "Выбрать лексему для стека")
            {
                ParentForm.StackListDataGridView.Rows.Add(ParentForm.StackListDataGridView.Rows.Count + 1,
                    StackListDataGridView.CurrentRow.Cells[1].Value);
                ParentForm.EditStackItemButton.Enabled = true;
                ParentForm.DeleteStackItemButton.Enabled = true;
            }
            else
            {
                ParentForm.EnterLexemLabel.Text = StackListDataGridView.CurrentRow.Cells[1].Value.ToString();
                ParentForm.DeleteEnterLexemButton.Enabled = true;
            }
            Close();
        }

        // >
    }
}