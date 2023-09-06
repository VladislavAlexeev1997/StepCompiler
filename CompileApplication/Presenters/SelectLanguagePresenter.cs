using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompileApplication.Views;
using CompileApplication.Model.LanguageStruct;

namespace CompileApplication.Presenters
{
    public class SelectLanguagePresenter : Presenter<ISelectLanguageView>
    {
        private const string DEFAULT_LANGUAGE_NAME_CONST = "--язык компиляции--";

        private const string DEFAULT_VERSION_NAME_CONST = "--версия--";

        private readonly ICompilationApplicationView MainView;

        private Languages LanguagesData;

        public SelectLanguagePresenter(ISelectLanguageView selectLanguageView,
            ICompilationApplicationView mainView) : base(selectLanguageView)
        {
            MainView = mainView;
            LanguagesData = new Languages();
            InitializeViewEvents();
            InitializeView();
        }

        private void InitializeViewEvents()
        {
            View.CheckLanguage += () => CheckedLanguage();
            View.CheckVersion += () => CheckedVersion();
            View.SelectedLanguage += () => SelectedLanguage();
            View.UpdateViewEvents();
        }

        private void InitializeView()
        {
            UpdateLanguageList();
            View.SelectLanguageIndex = 0;
        }

        private void UpdateLanguageList()
        {
            List<string> languages = new List<string> { DEFAULT_LANGUAGE_NAME_CONST };
            languages.AddRange(LanguagesData.LanguageNames);
            View.Languages = languages;
        }

        private void UpdateVersionList()
        {
            List<string> versions = new List<string> { DEFAULT_VERSION_NAME_CONST };
            if (View.SelectLanguage != DEFAULT_LANGUAGE_NAME_CONST)
            {
                versions.AddRange(LanguagesData.CurrentLanguage.VersionNames);
            }
            View.LanguageVersions = versions;
        }

        private void CheckedLanguage()
        {
            if (View.SelectLanguage != DEFAULT_LANGUAGE_NAME_CONST)
            {
                LanguagesData.SetCurrentLanguageIndex(View.SelectLanguageIndex - 1);
                View.IsLanguageSelect = true;
            }
            else
            {
                View.IsLanguageSelect = false;
            }
            UpdateVersionList();
            View.SelectVersionIndex = 0;
        }

        private void CheckedVersion()
        {
            if (View.SelectVersion != DEFAULT_VERSION_NAME_CONST)
            {
                LanguagesData.CurrentLanguage.SetCurrentVersionIndex(View.SelectVersionIndex - 1);
                View.IsVersionSelect = true;
            }
            else
            {
                View.IsVersionSelect = false;
            }
        }

        private void SelectedLanguage()
        {
            MainView.CurrentLanguage = View.SelectLanguage;
            MainView.CurrentVersion = View.SelectVersion;
            View.CloseInterface();
        }
    }
}