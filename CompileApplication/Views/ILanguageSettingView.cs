using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using CompileApplication.Model.LexemTypes;
using CompileApplication.Views.Enums;

namespace CompileApplication.Views
{
    public interface ILanguageSettingView : IView
    {
        LanguageSetting Position { get; set; }

        List<string> Languages { set; }

        string SelectLanguage { get; }

        int SelectLanguageIndex { get; set; }

        List<string> LanguageVersions { set; }

        string SelectVersion { get; }

        int SelectVersionIndex { get; set; }

        string AddLanguage { get; set; }

        string AddVersion { get; set; }

        LexemType AddLexemType { get; set; }

        string AddLexemItem { get; set; }

        string AddLexemComment { get; set; }

        Separator CurrentSeparator { set; }

        int CurrentSeparatorIndex { set; }

        Separator EditSeparator { get; set; }

        bool IsVisibleEditSeparator { set; }

        Keyword CurrentKeyword { set; }

        int CurrentKeywordIndex { set; }

        Keyword EditKeyword { get; set; }

        bool IsVisibleEditKeyword { set; }

        Comment CurrentComment { set; }

        int CurrentCommentIndex { set; }

        Comment EditComment { get; set; }

        bool IsVisibleEditComment { set; }

        void AddLanguageMasked(string mask, Color color);

        void AddVersionMasked(string mask, Color color);

        void AddLexemItemMasked(string mask, Color color);

        void AddLexemCommentMasked(string mask, Color color);

        void AddSeparator(Separator separator);

        void SetSeparatorList(List<Separator> separators);

        void SeparatorButtonControl(NavigatorButtonControl navigator, bool isEdit);

        void CurrentSeparatorMasked(Separator mask, Color color);

        void UpdateEditTableCurrentSeparator(Separator separator);

        void AddKeyword(Keyword keyword);

        void SetKeywordList(List<Keyword> keywords);

        void KeywordButtonControl(NavigatorButtonControl navigator, bool isEdit);

        void CurrentKeywordMasked(Keyword mask, Color color);

        void UpdateEditTableCurrentKeyword(Keyword keyword);

        void AddComment(Comment comment);

        void SetCommentList(List<Comment> comments);

        void CommentButtonControl(NavigatorButtonControl navigator, bool isEdit);

        void CurrentCommentMasked(Comment mask, Color color);

        void UpdateEditTableCurrentComment(Comment comment);

        void InformationMessage(string message, string name);

        void WarningMessage(string message, string name);

        bool QuestionMessage(string message, string name);

        event Action AddNewLanguageEnterText;

        event Action AddNewLanguageLeaveText;

        event Action AddNewLanguage;

        event Action SelectedLanguage;

        event Action ClearAddLanguageControl;

        event Action DeleteSelectLanguage;

        event Action AddNewVersionEnterText;

        event Action AddNewVersionLeaveText;

        event Action AddNewVersion;

        event Action ClearAddVersionControl;

        event Action SelectedVersion;

        event Action DeleteSelectVersion;

        event Action AddNewLexemItemEnterText;

        event Action AddNewLexemCommentEnterText;

        event Action AddNewLexemItemLeaveText;

        event Action AddNewLexemCommentLeaveText;

        event Action AddNewLexem;

        event Action ClearAddLexemControl;

        event Action SelectedCurrentSeparator;

        event Action FirstSeparator;

        event Action PreviousSeparator;

        event Action NextSeparator;

        event Action LastSeparator;

        event Action EditCurrentSeparator;

        event Action SaveEditCurrentSeparator;

        event Action CancelEditCurrentSeparator;

        event Action DeleteCurrentSeparator;

        event Action SelectedCurrentKeyword;

        event Action FirstKeyword;

        event Action PreviousKeyword;

        event Action NextKeyword;

        event Action LastKeyword;

        event Action EditCurrentKeyword;

        event Action SaveEditCurrentKeyword;

        event Action CancelEditCurrentKeyword;

        event Action DeleteCurrentKeyword;

        event Action SelectedCurrentComment;

        event Action FirstComment;

        event Action PreviousComment;

        event Action NextComment;

        event Action LastComment;

        event Action EditCurrentComment;

        event Action SaveEditCurrentComment;

        event Action CancelEditCurrentComment;

        event Action DeleteCurrentComment;

        event Action CloseLanguageSetting;
    }
}