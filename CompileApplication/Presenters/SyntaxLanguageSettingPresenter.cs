using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompileApplication.Views;
using CompileApplication.Views.Enums;
using CompileApplication.Model.LanguageStruct;

namespace CompileApplication.Presenters
{
    public class SyntaxLanguageSettingPresenter : Presenter<ISyntaxLanguageSettingView>
    {
        private const string DEFAULT_LANGUAGE_NAME_CONST = "--язык компиляции--";

        private const string DEFAULT_VERSION_NAME_CONST = "--версия--";

        private ICompilationApplicationView MainView;

        private Languages LanguagesData;

        public SyntaxLanguageSettingPresenter(ISyntaxLanguageSettingView syntaxLanguageSettingView,
            ICompilationApplicationView mainView) : base(syntaxLanguageSettingView)
        {
            MainView = mainView;
            LanguagesData = new Languages();
            InitializeViewEvents();
            InitializeView();
        }

        private void InitializeViewEvents()
        {
            View.SelectedLanguage += () => SelectedLanguage();
            View.SelectedVersion += () => SelectedVersion();
            View.CloseSyntaxLanguageSetting += () => CloseSyntaxLanguageSetting();
            View.SelectedState += () => SelectedState();
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

        private void UpdateDetermenisticStateList(bool isNewState)
        {
            View.SetDetermenisticStateList(
                LanguagesData.CurrentLanguage.CurrentVersion.SyntaxTable.Count);
            if (isNewState)
            {
                LanguagesData.CurrentLanguage.CurrentVersion.SyntaxTable.IsLastElement();
            }
            else
            {
                LanguagesData.CurrentLanguage.CurrentVersion.SyntaxTable.IsFirstElement();
            }
            View.SelectStateIndex = 
                LanguagesData.CurrentLanguage.CurrentVersion.SyntaxTable.CurrentIndex;
        }

        /* ViewerList<Keyword> keywords =
                 LanguagesData.CurrentLanguage.CurrentVersion.Keywords;
             View.SetKeywordList(keywords.ToList());
             if (keywords.Count > 0)
             {
                 View.CurrentKeywordIndex = keywords.CurrentIndex;
                 View.CurrentKeywordMasked(keywords.GetCurrentElement(), COLOR_TEXT);
             }
             else
             {
                 View.KeywordButtonControl(NavigatorButtonControl.NonControl, true);
                 View.CurrentKeywordMasked(new Keyword(DEFAULT_LEXEM_ITEM_CONST,
                     DEFAULT_LEXEM_COMMENT_CONST), DEFAULT_COLOR_TEXT);
             } */

        private void SelectedLanguage()
        {
            if (View.SelectLanguage != DEFAULT_LANGUAGE_NAME_CONST)
            {
                LanguagesData.SetCurrentLanguageIndex(View.SelectLanguageIndex - 1);
                View.Position = SyntaxLanguageSetting.SelectLanguage;
            }
            else
            {
                View.Position = SyntaxLanguageSetting.OpenSetting;
            }
            UpdateVersionList();
            View.SelectVersionIndex = 0;
        }

        private void SelectedVersion()
        {
            if (View.SelectVersion != DEFAULT_VERSION_NAME_CONST)
            {
                View.Position = SyntaxLanguageSetting.SelectVersion;
                LanguagesData.CurrentLanguage.SetCurrentVersionIndex(View.SelectVersionIndex - 1);
                UpdateDetermenisticStateList(false);
                /* UpdateSeparatorList();
                UpdateKeywordList();
                UpdateCommentList(); */
            }
            else
            {
                if (View.Position == SyntaxLanguageSetting.SelectVersion)
                {
                    View.Position = SyntaxLanguageSetting.SelectLanguage;
                }
                /*View.CurrentSeparatorMasked(new Separator(DEFAULT_LEXEM_ITEM_CONST,
                    DEFAULT_LEXEM_COMMENT_CONST), DEFAULT_COLOR_TEXT);
                View.CurrentKeywordMasked(new Keyword(DEFAULT_LEXEM_ITEM_CONST,
                    DEFAULT_LEXEM_COMMENT_CONST), DEFAULT_COLOR_TEXT);
                View.CurrentCommentMasked(new Comment(DEFAULT_LEXEM_ITEM_CONST,
                    DEFAULT_LEXEM_COMMENT_CONST), DEFAULT_COLOR_TEXT);*/
            }
        }

        private void SelectedState()
        {

        }

        private void CloseSyntaxLanguageSetting()
        {
            MainView.ShowInterface();
        }
    }
}
