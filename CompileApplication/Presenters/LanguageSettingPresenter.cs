using System.Collections.Generic;
using System.Drawing;
using CompileApplication.Views;
using CompileApplication.Views.Enums;
using CompileApplication.Model.LanguageStruct;
using CompileApplication.Model.LexemTypes;
using CompileApplication.Model.Tools;

namespace CompileApplication.Presenters
{
    public class LanguageSettingPresenter : Presenter<ILanguageSettingView>
    {
        private const string DEFAULT_LANGUAGE_NAME_CONST = "--язык компиляции--";

        private const string DEFAULT_VERSION_NAME_CONST = "--версия--";

        private const string DEFAULT_LANGUAGE_TEXT_CONST = "Язык";

        private const string DEFAULT_VERSION_TEXT_CONST = "0.0.0";

        private const string DEFAULT_LEXEM_ITEM_CONST = "Лексема";

        private const string DEFAULT_LEXEM_COMMENT_CONST = "Комментарий к лексеме";

        private readonly Color DEFAULT_COLOR_TEXT = SystemColors.ControlDark;

        private readonly Color COLOR_TEXT = SystemColors.WindowText;

        private ICompilationApplicationView MainView;

        private Languages LanguagesData;

        public LanguageSettingPresenter(ILanguageSettingView languageSettingView,
            ICompilationApplicationView mainView) : base(languageSettingView)
        {
            MainView = mainView;
            LanguagesData = new Languages();
            InitializeViewEvents();
            InitializeView();
        }

        private void InitializeViewEvents()
        {
            View.AddNewLanguageEnterText += () => AddNewLanguageEnterText();
            View.AddNewLanguageLeaveText += () => AddNewLanguageLeaveText();
            View.AddNewLanguage += () => AddNewLanguage();
            View.ClearAddLanguageControl += () => ClearAddLanguageControl();
            View.SelectedLanguage += () => SelectedLanguage();
            View.DeleteSelectLanguage += () => DeleteSelectLanguage();
            View.AddNewVersionEnterText += () => AddNewVersionEnterText();
            View.AddNewVersionLeaveText += () => AddNewVersionLeaveText();
            View.AddNewVersion += () => AddNewVersion();
            View.ClearAddVersionControl += () => ClearAddVersionControl();
            View.SelectedVersion += () => SelectedVersion();
            View.DeleteSelectVersion += () => DeleteSelectVersion();
            View.AddNewLexemItemEnterText += () => AddNewLexemItemEnterText();
            View.AddNewLexemCommentEnterText += () => AddNewLexemCommentEnterText();
            View.AddNewLexemItemLeaveText += () => AddNewLexemItemLeaveText();
            View.AddNewLexemCommentLeaveText += () => AddNewLexemCommentLeaveText();
            View.AddNewLexem += () => AddNewLexem();
            View.ClearAddLexemControl += () => ClearAddLexemControl();
            View.SelectedCurrentSeparator += () => SelectedCurrentSeparator();
            View.FirstSeparator += () => FirstSeparator();
            View.PreviousSeparator += () => PreviousSeparator();
            View.NextSeparator += () => NextSeparator();
            View.LastSeparator += () => LastSeparator();
            View.EditCurrentSeparator += () => EditCurrentSeparator();
            View.SaveEditCurrentSeparator += () => SaveEditCurrentSeparator();
            View.CancelEditCurrentSeparator += () => BreakEditCurrentSeparator();
            View.DeleteCurrentSeparator += () => DeleteCurrentSeparator();
            View.SelectedCurrentKeyword += () => SelectedCurrentKeyword();
            View.FirstKeyword += () => FirstKeyword();
            View.PreviousKeyword += () => PreviousKeyword();
            View.NextKeyword += () => NextKeyword();
            View.LastKeyword += () => LastKeyword();
            View.EditCurrentKeyword += () => EditCurrentKeyword();
            View.SaveEditCurrentKeyword += () => SaveEditCurrentKeyword();
            View.CancelEditCurrentKeyword += () => BreakEditCurrentKeyword();
            View.DeleteCurrentKeyword += () => DeleteCurrentKeyword();
            View.SelectedCurrentComment += () => SelectedCurrentComment();
            View.FirstComment += () => FirstComment();
            View.PreviousComment += () => PreviousComment();
            View.NextComment += () => NextComment();
            View.LastComment += () => LastComment();
            View.EditCurrentComment += () => EditCurrentComment();
            View.SaveEditCurrentComment += () => SaveEditCurrentComment();
            View.CancelEditCurrentComment += () => BreakEditCurrentComment();
            View.DeleteCurrentComment += () => DeleteCurrentComment();
            View.CloseLanguageSetting += () => CloseLanguageSetting();
            View.UpdateViewEvents();
        }

        private void InitializeView()
        {
            UpdateLanguageList();
            View.SelectLanguageIndex = 0;
            View.AddLanguageMasked(DEFAULT_LANGUAGE_TEXT_CONST, DEFAULT_COLOR_TEXT);
            View.AddVersionMasked(DEFAULT_VERSION_TEXT_CONST, DEFAULT_COLOR_TEXT);
            View.AddLexemType = LexemType.Default;
            View.AddLexemItemMasked(DEFAULT_LEXEM_ITEM_CONST, DEFAULT_COLOR_TEXT);
            View.AddLexemCommentMasked(DEFAULT_LEXEM_COMMENT_CONST, DEFAULT_COLOR_TEXT);
            View.Position = LanguageSetting.OpenSetting;
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

        private void UpdateSeparatorList()
        {
            ViewerList<Separator> separators =
                LanguagesData.CurrentLanguage.CurrentVersion.Separators;
            View.SetSeparatorList(separators.ToList());
            if (separators.Count > 0)
            {
                View.CurrentSeparatorIndex = separators.CurrentIndex;
                View.CurrentSeparatorMasked(separators.GetCurrentElement(), COLOR_TEXT);
            }
            else
            {
                View.SeparatorButtonControl(NavigatorButtonControl.NonControl, true);
                View.CurrentSeparatorMasked(new Separator(DEFAULT_LEXEM_ITEM_CONST,
                    DEFAULT_LEXEM_COMMENT_CONST), DEFAULT_COLOR_TEXT);
            }
        }

        private void UpdateKeywordList()
        {
            ViewerList<Keyword> keywords =
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
            }
        }

        private void UpdateCommentList()
        {
            ViewerList<Comment> comments =
                LanguagesData.CurrentLanguage.CurrentVersion.Comments;
            View.SetCommentList(comments.ToList());
            if (comments.Count > 0)
            {
                View.CurrentCommentIndex = comments.CurrentIndex;
                View.CurrentCommentMasked(comments.GetCurrentElement(), COLOR_TEXT);
            }
            else
            {
                View.CommentButtonControl(NavigatorButtonControl.NonControl, true);
                View.CurrentCommentMasked(new Comment(DEFAULT_LEXEM_ITEM_CONST,
                    DEFAULT_LEXEM_COMMENT_CONST), DEFAULT_COLOR_TEXT);
            }
        }

        private void AddNewLanguageEnterText()
        {
            if (View.AddLanguage == DEFAULT_LANGUAGE_TEXT_CONST)
            {
                View.AddLanguageMasked("", COLOR_TEXT);
            }
        }

        private void AddNewLanguageLeaveText()
        {
            if (View.AddLanguage == "" || 
                View.AddLanguage == DEFAULT_LANGUAGE_TEXT_CONST)
            {
                ClearAddLanguageControl();
            }
        }

        private void AddNewLanguage()
        {
            if (View.AddLanguage == DEFAULT_LANGUAGE_TEXT_CONST)
            {
                View.WarningMessage(
                    "Введите язык программирования для добавления его в систему",
                    "Ошибка добавления языка программирования");
            }
            else if (LanguagesData.AddLanguage(View.AddLanguage))
            {
                UpdateLanguageList();
                View.SelectLanguageIndex = LanguagesData.LanguageNames.Count;
                View.InformationMessage("Язык программирования '"+
                    View.AddLanguage + "' был успешно добавлен в систему",
                    "Добавление языка программирования");
                ClearAddLanguageControl();
            }
            else
            {
                View.WarningMessage("Язык программирования '"
                    + View.AddLanguage + "' уже существует в системе",
                    "Ошибка добавления языка программирования");
            }
        }

        private void ClearAddLanguageControl()
        {
            View.AddLanguageMasked(DEFAULT_LANGUAGE_TEXT_CONST, DEFAULT_COLOR_TEXT);
        }

        private void SelectedLanguage()
        {
            if (View.SelectLanguage != DEFAULT_LANGUAGE_NAME_CONST)
            {
                LanguagesData.SetCurrentLanguageIndex(View.SelectLanguageIndex - 1);
                View.Position = LanguageSetting.SelectLanguage;
            }
            else
            {
                View.Position = LanguageSetting.OpenSetting;
            }
            UpdateVersionList();
            View.SelectVersionIndex = 0;
        }

        private void DeleteSelectLanguage()
        {
            bool deleteRequest = View.QuestionMessage(
                "Вы действительно хотите удалить язык программирования '" +
                    LanguagesData.CurrentLanguage.LanguageName + "'?",
                "Запрос на удаление языка программирования");
            if (deleteRequest)
            {
                LanguagesData.DeleteCurrentLanguage();
                UpdateLanguageList();
                View.SelectLanguageIndex = 0;
            }
        }

        private void AddNewVersionEnterText()
        {
            if (View.AddVersion == DEFAULT_VERSION_TEXT_CONST)
            {
                View.AddVersionMasked("", COLOR_TEXT);
            }
        }

        private void AddNewVersionLeaveText()
        {
            if (View.AddVersion == "" ||
                View.AddVersion == DEFAULT_VERSION_TEXT_CONST)
            {
                ClearAddVersionControl();
            }
        }

        private void AddNewVersion()
        {
            if (View.AddVersion == DEFAULT_VERSION_TEXT_CONST)
            {
                View.WarningMessage(
                    "Введите версию языка программирования '" + 
                    LanguagesData.CurrentLanguage.LanguageName + "' для добавления ее в систему", 
                    "Ошибка добавления версии языка программирования");
            }
            else if (LanguagesData.CurrentLanguage.AddLanguageVersion(View.AddVersion))
            {
                UpdateVersionList();
                View.SelectVersionIndex = LanguagesData.CurrentLanguage.VersionNames.Count;
                View.InformationMessage("Версия '" + View.AddVersion + "' языка программирования '" + 
                    LanguagesData.CurrentLanguage.LanguageName + "' была успешно добавлена в систему",
                    "Добавление версии языка программирования");
                ClearAddVersionControl();
            }
            else
            {
                View.WarningMessage("Версия '" + View.AddVersion + "' языка программирования '"
                    + LanguagesData.CurrentLanguage.LanguageName + "' уже существует в системе",
                    "Ошибка добавления версии языка программирования");
            }
        }

        private void ClearAddVersionControl()
        {
            View.AddVersionMasked(DEFAULT_VERSION_TEXT_CONST, DEFAULT_COLOR_TEXT);
        }

        private void SelectedVersion()
        {
            if (View.SelectVersion != DEFAULT_VERSION_NAME_CONST)
            {
                if (View.SelectVersionIndex != 1)
                {
                    View.Position = LanguageSetting.SelectVersion;
                }
                else
                {
                    View.Position = LanguageSetting.SelectAllVersion;
                }
                LanguagesData.CurrentLanguage.SetCurrentVersionIndex(View.SelectVersionIndex - 1);
                UpdateSeparatorList();
                UpdateKeywordList();
                UpdateCommentList();
            }
            else
            {
                if (View.Position == LanguageSetting.SelectVersion)
                {
                    View.Position = LanguageSetting.SelectLanguage;
                }
                View.CurrentSeparatorMasked(new Separator(DEFAULT_LEXEM_ITEM_CONST,
                    DEFAULT_LEXEM_COMMENT_CONST), DEFAULT_COLOR_TEXT);
                View.CurrentKeywordMasked(new Keyword(DEFAULT_LEXEM_ITEM_CONST,
                    DEFAULT_LEXEM_COMMENT_CONST), DEFAULT_COLOR_TEXT);
                View.CurrentCommentMasked(new Comment(DEFAULT_LEXEM_ITEM_CONST,
                    DEFAULT_LEXEM_COMMENT_CONST), DEFAULT_COLOR_TEXT);
            }
        }

        private void DeleteSelectVersion()
        {
            bool deleteRequest = View.QuestionMessage(
                "Вы действительно хотите удалить версию '" + 
                LanguagesData.CurrentLanguage.CurrentVersion.VersionName + 
                "' языка программирования '" + LanguagesData.CurrentLanguage.LanguageName + "'?",
                "Запрос на удаление версии языка программирования");
            if (deleteRequest)
            {
                LanguagesData.CurrentLanguage.DeleteCurrentLanguageVersion();
                UpdateVersionList();
                View.SelectVersionIndex = 0;
            }
        }

        private void AddNewLexemItemEnterText()
        {
            if (View.AddLexemItem == DEFAULT_LEXEM_ITEM_CONST)
            {
                View.AddLexemItemMasked("", COLOR_TEXT);
            }
        }

        private void AddNewLexemCommentEnterText()
        {
            if (View.AddLexemComment == DEFAULT_LEXEM_COMMENT_CONST)
            {
                View.AddLexemCommentMasked("", COLOR_TEXT);
            }
        }

        private void AddNewLexemItemLeaveText()
        {
            if (View.AddLexemItem == "" ||
                View.AddLexemItem == DEFAULT_LEXEM_ITEM_CONST)
            {
                View.AddLexemItemMasked(DEFAULT_LEXEM_ITEM_CONST, DEFAULT_COLOR_TEXT);
            }
        }

        private void AddNewLexemCommentLeaveText()
        {
            if (View.AddLexemComment == "" ||
                View.AddLexemComment == DEFAULT_LEXEM_COMMENT_CONST)
            {
                View.AddLexemCommentMasked(DEFAULT_LEXEM_COMMENT_CONST, DEFAULT_COLOR_TEXT);
            }
        }

        private void AddNewLexem()
        {
            if (View.AddLexemType == LexemType.Default)
            {
                View.WarningMessage(
                    "Выберите тип лексемы для добавления ее в систему",
                    "Ошибка добавления лексемы версии языка программирования");
            }
            else if (View.AddLexemItem == DEFAULT_LEXEM_ITEM_CONST)
            {
                View.WarningMessage(
                    "Введите лексему для добавления ее в систему",
                    "Ошибка добавления лексемы версии языка программирования");
            }
            else if (View.AddLexemComment == DEFAULT_LEXEM_COMMENT_CONST)
            {
                View.WarningMessage(
                    "Введите комментарий к лексеме для добавления ее в систему",
                    "Ошибка добавления лексемы версии языка программирования");
            }
            else
            {
                switch (View.AddLexemType)
                {
                    case LexemType.Separator:
                        AddNewSeparator();
                        break;
                    case LexemType.Keyword:
                        AddNewKeyword();
                        break;
                    default:
                        AddNewComment();
                        break;
                }
            }
        }

        private void ClearAddLexemControl()
        {
            View.AddLexemType = LexemType.Default;
            View.AddLexemItemMasked(DEFAULT_LEXEM_ITEM_CONST, DEFAULT_COLOR_TEXT);
            View.AddLexemCommentMasked(DEFAULT_LEXEM_COMMENT_CONST, DEFAULT_COLOR_TEXT);
        }

        private void AddNewSeparator()
        {
            Separator addSeparator = 
                new Separator(View.AddLexemItem, View.AddLexemComment);
            if (LanguagesData.CurrentLanguage.AddCurrentVersionSeparator(addSeparator))
            {
                ViewerList<Separator> separators = 
                    LanguagesData.CurrentLanguage.CurrentVersion.Separators;
                if (separators.Count > 1)
                {
                    View.AddSeparator(addSeparator);
                    View.CurrentSeparatorIndex = separators.CurrentIndex;
                }
                else
                {
                    UpdateSeparatorList();
                }
                View.InformationMessage("Разделитель '" + View.AddLexemItem + "' языка программирования '" +
                    LanguagesData.CurrentLanguage.LanguageName + "' был успешно добавлен в систему",
                    "Добавление нового разделителя языка программирования");
                ClearAddLexemControl();
            }
            else
            {
                View.WarningMessage("Разделитель '" + View.AddLexemItem + "' языка программирования '" +
                    LanguagesData.CurrentLanguage.LanguageName + "' уже существует в системе",
                    "Ошибка добавления разделителя версии языка программирования");
            }
        }

        private void SelectedCurrentSeparator()
        {
            if (View.Position == LanguageSetting.SelectVersion ||
                    View.Position == LanguageSetting.SelectAllVersion)
            {
                ViewerList<Separator> separators =
                    LanguagesData.CurrentLanguage.CurrentVersion.Separators;
                if (separators.Count != 0)
                {
                    View.CurrentSeparator = separators.GetCurrentElement();
                    if (separators.Count == 1)
                    {
                        View.SeparatorButtonControl(NavigatorButtonControl.OneNode,
                            separators.GetCurrentElement().IsEdit);
                    }
                    else
                    {
                        if (separators.CurrentIndex == 0)
                        {
                            View.SeparatorButtonControl(NavigatorButtonControl.First,
                                separators.GetCurrentElement().IsEdit);
                        }
                        else if (separators.CurrentIndex == separators.Count - 1)
                        {
                            View.SeparatorButtonControl(NavigatorButtonControl.Last,
                                separators.GetCurrentElement().IsEdit);
                        }
                        else
                        {
                            View.SeparatorButtonControl(NavigatorButtonControl.Middle,
                                separators.GetCurrentElement().IsEdit);
                        }
                    }
                }
                else
                {
                    View.CurrentSeparator = new Separator(DEFAULT_LEXEM_ITEM_CONST,
                        DEFAULT_LEXEM_COMMENT_CONST);
                    View.SeparatorButtonControl(NavigatorButtonControl.NonControl, true);
                }
            }
            else
            {
                View.CurrentSeparator = new Separator(DEFAULT_LEXEM_ITEM_CONST,
                    DEFAULT_LEXEM_COMMENT_CONST);
                View.SeparatorButtonControl(NavigatorButtonControl.NonControl, true);
            }
        }

        private void FirstSeparator()
        {
            if (LanguagesData.CurrentLanguage.CurrentVersion.Separators.IsFirstElement())
            {
                View.CurrentSeparatorIndex =
                    LanguagesData.CurrentLanguage.CurrentVersion.Separators.CurrentIndex;
            }
        }

        private void PreviousSeparator()
        {
            if (LanguagesData.CurrentLanguage.CurrentVersion.Separators.IsPreviousElement())
            {
                View.CurrentSeparatorIndex = 
                    LanguagesData.CurrentLanguage.CurrentVersion.Separators.CurrentIndex;
            }
        }

        private void NextSeparator()
        {
            if (LanguagesData.CurrentLanguage.CurrentVersion.Separators.IsNextElement())
            {
                View.CurrentSeparatorIndex = 
                    LanguagesData.CurrentLanguage.CurrentVersion.Separators.CurrentIndex;
            }
        }

        private void LastSeparator()
        {
            if (LanguagesData.CurrentLanguage.CurrentVersion.Separators.IsLastElement())
            {
                View.CurrentSeparatorIndex =
                    LanguagesData.CurrentLanguage.CurrentVersion.Separators.CurrentIndex;
            }
        }

        private void EditCurrentSeparator()
        {
            View.EditSeparator = 
                LanguagesData.CurrentLanguage.CurrentVersion.Separators.GetCurrentElement();
            View.IsVisibleEditSeparator = true;
            View.Position = LanguageSetting.EditSeparator;
        }

        private void SaveEditCurrentSeparator()
        {
            Separator changeSeparator = View.EditSeparator;
            if (changeSeparator.Item == "")
            {
                View.WarningMessage(
                    "Разделитель не может принимать пустое знаение",
                    "Ошибка изменения разделителя");
            }
            else
            {
                if (LanguagesData.CurrentLanguage.EditCurrentVersionSeparator(changeSeparator))
                {
                    View.UpdateEditTableCurrentSeparator(changeSeparator);
                    BreakEditCurrentSeparator();
                }
                else
                {
                    View.WarningMessage("Разделитель '" + changeSeparator.Item + "' языка программирования '" +
                        LanguagesData.CurrentLanguage.LanguageName + "' уже существует в системе",
                        "Ошибка изменения разделителя");
                }
            }
        }

        private void BreakEditCurrentSeparator()
        {
            if (View.SelectVersion != "Общая версия")
            {
                View.Position = LanguageSetting.SelectVersion;
            }
            else
            {
                View.Position = LanguageSetting.SelectAllVersion;
            }
            View.CurrentSeparator = 
                LanguagesData.CurrentLanguage.CurrentVersion.Separators.GetCurrentElement();
            View.CurrentSeparatorIndex =
                LanguagesData.CurrentLanguage.CurrentVersion.Separators.CurrentIndex;
            SelectedCurrentSeparator();
            SelectedCurrentKeyword();
            SelectedCurrentComment();
            View.IsVisibleEditSeparator = false;
        }

        private void DeleteCurrentSeparator()
        {
            Separator selectSeparator =
                LanguagesData.CurrentLanguage.CurrentVersion.Separators.GetCurrentElement();
            bool deleteRequest = View.QuestionMessage(
                "Вы действительно хотите удалить выбранный разделитель '" +
                 selectSeparator.Item + "'?", "Запрос на удаление разделителя");
            if (deleteRequest)
            {
                LanguagesData.CurrentLanguage.DeleteCurrentVersionSeparator();
                UpdateSeparatorList();
            }
        }

        private void AddNewKeyword()
        {
            Keyword addKeyword =
                new Keyword(View.AddLexemItem, View.AddLexemComment);
            if (LanguagesData.CurrentLanguage.AddCurrentVersionKeyword(addKeyword))
            {
                ViewerList<Keyword> keywords =
                    LanguagesData.CurrentLanguage.CurrentVersion.Keywords;
                if (keywords.Count > 1)
                {
                    View.AddKeyword(addKeyword);
                    View.CurrentKeywordIndex = keywords.CurrentIndex;
                }
                else
                {
                    UpdateKeywordList();
                }
                View.InformationMessage("Ключевое слово '" + View.AddLexemItem + "' языка программирования '" +
                    LanguagesData.CurrentLanguage.LanguageName + "' было успешно добавлено в систему",
                    "Добавление нового ключевого слова языка программирования");
                ClearAddLexemControl();
            }
            else
            {
                View.WarningMessage("Ключевое слово '" + View.AddLexemItem + "' языка программирования '" +
                    LanguagesData.CurrentLanguage.LanguageName + "' уже существует в системе",
                    "Ошибка добавления ключевого слова версии языка программирования");
            }
        }

        private void SelectedCurrentKeyword()
        {
            if (View.Position == LanguageSetting.SelectVersion ||
                    View.Position == LanguageSetting.SelectAllVersion)
            {
                ViewerList<Keyword> keywords =
                    LanguagesData.CurrentLanguage.CurrentVersion.Keywords;
                if (keywords.Count != 0)
                {
                    View.CurrentKeyword = keywords.GetCurrentElement();
                    if (keywords.Count == 1)
                    {
                        View.KeywordButtonControl(NavigatorButtonControl.OneNode,
                            keywords.GetCurrentElement().IsEdit);
                    }
                    else
                    {
                        if (keywords.CurrentIndex == 0)
                        {
                            View.KeywordButtonControl(NavigatorButtonControl.First,
                                keywords.GetCurrentElement().IsEdit);
                        }
                        else if (keywords.CurrentIndex == keywords.Count - 1)
                        {
                            View.KeywordButtonControl(NavigatorButtonControl.Last,
                                keywords.GetCurrentElement().IsEdit);
                        }
                        else
                        {
                            View.KeywordButtonControl(NavigatorButtonControl.Middle,
                                keywords.GetCurrentElement().IsEdit);
                        }
                    }
                }
                else
                {
                    View.CurrentKeyword = new Keyword(DEFAULT_LEXEM_ITEM_CONST,
                        DEFAULT_LEXEM_COMMENT_CONST);
                    View.KeywordButtonControl(NavigatorButtonControl.NonControl, true);
                }
            }
            else
            {
                View.CurrentKeyword = new Keyword(DEFAULT_LEXEM_ITEM_CONST,
                    DEFAULT_LEXEM_COMMENT_CONST);
                View.KeywordButtonControl(NavigatorButtonControl.NonControl, true);
            }
        }

        private void FirstKeyword()
        {
            if (LanguagesData.CurrentLanguage.CurrentVersion.Keywords.IsFirstElement())
            {
                View.CurrentKeywordIndex =
                    LanguagesData.CurrentLanguage.CurrentVersion.Keywords.CurrentIndex;
            }
        }

        private void PreviousKeyword()
        {
            if (LanguagesData.CurrentLanguage.CurrentVersion.Keywords.IsPreviousElement())
            {
                View.CurrentKeywordIndex = 
                    LanguagesData.CurrentLanguage.CurrentVersion.Keywords.CurrentIndex;
            }
        }

        private void NextKeyword()
        {
            if (LanguagesData.CurrentLanguage.CurrentVersion.Keywords.IsNextElement())
            {
                View.CurrentKeywordIndex = 
                    LanguagesData.CurrentLanguage.CurrentVersion.Keywords.CurrentIndex;
            }
        }

        private void LastKeyword()
        {
            if (LanguagesData.CurrentLanguage.CurrentVersion.Keywords.IsLastElement())
            {
                View.CurrentKeywordIndex =
                    LanguagesData.CurrentLanguage.CurrentVersion.Keywords.CurrentIndex;
            }
        }

        private void EditCurrentKeyword()
        {
            View.EditKeyword =
                LanguagesData.CurrentLanguage.CurrentVersion.Keywords.GetCurrentElement();
            View.IsVisibleEditKeyword = true;
            View.Position = LanguageSetting.EditKeyword;
        }

        private void SaveEditCurrentKeyword()
        {
            Keyword changeKeyword = View.EditKeyword;
            if (changeKeyword.Item == "")
            {
                View.WarningMessage(
                    "Ключевое слово не может принимать пустое знаение",
                    "Ошибка изменения ключевого слова");
            }
            else
            {
                if (LanguagesData.CurrentLanguage.EditCurrentVersionKeyword(changeKeyword))
                {
                    View.UpdateEditTableCurrentKeyword(changeKeyword);
                    BreakEditCurrentKeyword();
                }
                else
                {
                    View.WarningMessage("Ключевое слово '" + changeKeyword.Item + "' языка программирования '" +
                        LanguagesData.CurrentLanguage.LanguageName + "' уже существует в системе",
                        "Ошибка изменения ключевого слова");
                }
            }
        }

        private void BreakEditCurrentKeyword()
        {
            if (View.SelectVersion != "Общая версия")
            {
                View.Position = LanguageSetting.SelectVersion;
            }
            else
            {
                View.Position = LanguageSetting.SelectAllVersion;
            }
            View.CurrentKeyword =
                LanguagesData.CurrentLanguage.CurrentVersion.Keywords.GetCurrentElement();
            View.CurrentKeywordIndex =
                LanguagesData.CurrentLanguage.CurrentVersion.Keywords.CurrentIndex;
            SelectedCurrentSeparator();
            SelectedCurrentKeyword();
            SelectedCurrentComment();
            View.IsVisibleEditKeyword = false;
        }

        private void DeleteCurrentKeyword()
        {
            Keyword selectKeyword =
                LanguagesData.CurrentLanguage.CurrentVersion.Keywords.GetCurrentElement();
            bool deleteRequest = View.QuestionMessage(
                "Вы действительно хотите удалить выбранное ключевое слово '" +
                 selectKeyword.Item + "'?", "Запрос на удаление ключевого слова");
            if (deleteRequest)
            {
                LanguagesData.CurrentLanguage.DeleteCurrentVersionKeyword();
                UpdateKeywordList();
            }
        }

        private void AddNewComment()
        {
            Comment addComment =
                new Comment(View.AddLexemItem, View.AddLexemComment);
            if (LanguagesData.CurrentLanguage.AddCurrentVersionComment(addComment))
            {
                ViewerList<Comment> comments =
                    LanguagesData.CurrentLanguage.CurrentVersion.Comments;
                if (comments.Count > 1)
                {
                    View.AddComment(addComment);
                    View.CurrentCommentIndex = comments.CurrentIndex;
                }
                else
                {
                    UpdateCommentList();
                }
                View.InformationMessage("Лексема для комментария '" + View.AddLexemItem + "' языка программирования '" +
                    LanguagesData.CurrentLanguage.LanguageName + "' была успешно добавлена в систему",
                    "Добавление новой лексемы для комментария языка программирования");
                ClearAddLexemControl();
            }
            else
            {
                View.WarningMessage("Лексема для комментария '" + View.AddLexemItem + "' языка программирования '" +
                    LanguagesData.CurrentLanguage.LanguageName + "' уже существует в системе",
                    "Ошибка добавления лексемы для комментария версии языка программирования");
            }
        }

        private void SelectedCurrentComment()
        {
            if (View.Position == LanguageSetting.SelectVersion ||
                    View.Position == LanguageSetting.SelectAllVersion)
            {
                ViewerList<Comment> comments =
                    LanguagesData.CurrentLanguage.CurrentVersion.Comments;
                if (comments.Count != 0)
                {
                    View.CurrentComment = comments.GetCurrentElement();
                    if (comments.Count == 1)
                    {
                        View.CommentButtonControl(NavigatorButtonControl.OneNode,
                            comments.GetCurrentElement().IsEdit);
                    }
                    else
                    {
                        if (comments.CurrentIndex == 0)
                        {
                            View.CommentButtonControl(NavigatorButtonControl.First,
                                comments.GetCurrentElement().IsEdit);
                        }
                        else if (comments.CurrentIndex == comments.Count - 1)
                        {
                            View.CommentButtonControl(NavigatorButtonControl.Last,
                                comments.GetCurrentElement().IsEdit);
                        }
                        else
                        {
                            View.CommentButtonControl(NavigatorButtonControl.Middle,
                                comments.GetCurrentElement().IsEdit);
                        }
                    }
                }
                else
                {
                    View.CurrentComment = new Comment(DEFAULT_LEXEM_ITEM_CONST,
                        DEFAULT_LEXEM_COMMENT_CONST);
                    View.CommentButtonControl(NavigatorButtonControl.NonControl, true);
                }
            }
            else
            {
                View.CurrentComment = new Comment(DEFAULT_LEXEM_ITEM_CONST,
                    DEFAULT_LEXEM_COMMENT_CONST);
                View.CommentButtonControl(NavigatorButtonControl.NonControl, true);
            }
        }

        private void FirstComment()
        {
            if (LanguagesData.CurrentLanguage.CurrentVersion.Comments.IsFirstElement())
            {
                View.CurrentCommentIndex =
                    LanguagesData.CurrentLanguage.CurrentVersion.Comments.CurrentIndex;
            }
        }

        private void PreviousComment()
        {
            if (LanguagesData.CurrentLanguage.CurrentVersion.Comments.IsPreviousElement())
            {
                View.CurrentCommentIndex = 
                    LanguagesData.CurrentLanguage.CurrentVersion.Comments.CurrentIndex;
            }
        }

        private void NextComment()
        {
            if (LanguagesData.CurrentLanguage.CurrentVersion.Comments.IsNextElement())
            {
                View.CurrentCommentIndex =
                    LanguagesData.CurrentLanguage.CurrentVersion.Comments.CurrentIndex;
            }
        }

        private void LastComment()
        {
            if (LanguagesData.CurrentLanguage.CurrentVersion.Comments.IsLastElement())
            {
                View.CurrentCommentIndex =
                    LanguagesData.CurrentLanguage.CurrentVersion.Comments.CurrentIndex;
            }
        }

        private void EditCurrentComment()
        {
            View.EditComment =
                LanguagesData.CurrentLanguage.CurrentVersion.Comments.GetCurrentElement();
            View.IsVisibleEditComment = true;
            View.Position = LanguageSetting.EditComment;
        }

        private void SaveEditCurrentComment()
        {
            Comment changeComment = View.EditComment;
            if (changeComment.Item == "")
            {
                View.WarningMessage(
                    "Лексема для комментариев не может принимать пустое знаение",
                    "Ошибка изменения лексемы для комментариев");
            }
            else
            {
                if (LanguagesData.CurrentLanguage.EditCurrentVersionComment(changeComment))
                {
                    View.UpdateEditTableCurrentComment(changeComment);
                    BreakEditCurrentComment();
                }
                else
                {
                    View.WarningMessage(
                        "Лексема для комментариев '" + changeComment.Item + "' языка программирования '" + 
                        LanguagesData.CurrentLanguage.LanguageName + "' уже существует в системе",
                        "Ошибка изменения лексемы для комментариев");
                }
            }
        }

        private void BreakEditCurrentComment()
        {
            if (View.SelectVersion != "Общая версия")
            {
                View.Position = LanguageSetting.SelectVersion;
            }
            else
            {
                View.Position = LanguageSetting.SelectAllVersion;
            }
            View.CurrentComment =
                LanguagesData.CurrentLanguage.CurrentVersion.Comments.GetCurrentElement();
            View.CurrentCommentIndex =
                LanguagesData.CurrentLanguage.CurrentVersion.Comments.CurrentIndex;
            SelectedCurrentSeparator();
            SelectedCurrentKeyword();
            SelectedCurrentComment();
            View.IsVisibleEditComment = false;
        }

        private void DeleteCurrentComment()
        {
            Comment selectComment =
                LanguagesData.CurrentLanguage.CurrentVersion.Comments.GetCurrentElement();
            bool deleteRequest = View.QuestionMessage(
                "Вы действительно хотите удалить выбранную лексему для комментариев '" +
                 selectComment.Item + "'?", "Запрос на удаление лексемы для комментариев");
            if (deleteRequest)
            {
                LanguagesData.CurrentLanguage.DeleteCurrentVersionComment();
                UpdateCommentList();
            }
        }

        private void CloseLanguageSetting()
        {
            MainView.ShowInterface();
        }
    }
}