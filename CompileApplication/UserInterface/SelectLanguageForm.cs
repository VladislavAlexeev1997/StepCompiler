using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompileApplication.Views;

namespace CompileApplication.UserInterface
{
    public partial class SelectLanguageForm : Form, ISelectLanguageView
    {
        public event Action CheckLanguage;

        public event Action CheckVersion;

        public event Action SelectedLanguage;

        public SelectLanguageForm()
        {
            InitializeComponent();
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

        public bool IsLanguageSelect
        {
            set { CheckLanguageVersionComboBox.Enabled = value; }
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

        public bool IsVersionSelect
        {
            set { SelectLanguageButton.Enabled = value; }
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
            CheckLanguageComboBox.SelectedValueChanged += (sender, args) => CheckLanguage();
            CheckLanguageVersionComboBox.SelectedValueChanged += (sender, args) => CheckVersion();
            SelectLanguageButton.Click += (sender, args) => SelectedLanguage();
            CancelSelectLanguageButton.Click += (sender, args) => CloseInterface();
        }
    }
}