using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompileApplication.Views.Enums;
using CompileApplication.Model.LexicalScanner;
using CompileApplication.Model.LexicalClassification;
using CompileApplication.Model.LexemTypes;

namespace CompileApplication.Views
{
    public delegate void OpenSelectLanguageView(ISelectLanguageView openView);

    public delegate void OpenLanguageSettingView(ILanguageSettingView openView);

    public delegate void OpenSyntaxLanguageSettingView(ISyntaxLanguageSettingView openView);

    public interface ICompilationApplicationView : IView
    {
        CodeAnalyzer Position { get; set; }

        CodeAnalyzer NowAnalyzerStep { get; set; }

        string CurrentLanguage { get; set; }

        string CurrentVersion { get; set; }

        int CurrentScannerLexemIndex { get; set; }

        int CurrentErrorScannerLexemIndex { get; set; }

        int CurrentKeywordIndex { get; set; }

        int CurrentSeparatorIndex { get; set; }

        int CurrentIdentificatorIndex { get; set; }

        int CurrentLiteralAndNumberIndex { get; set; }

        int CurrentClassifiedLexemIndex { get; set; }

        string[] ProgramCode { get; }

        string ProgramCodeText { get; set; }

        string ProgramCodeLineNumbers { set; }

        string AnalyzeType { set; }

        string AnalyzeTypeStep { set; }

        void ProgramCodeMasked(string mask, Color color);

        string OpenCodeFileName();

        void HideInterface();

        void AddScanningLexem(CodeLexem addLexem);

        void ScanningLexemButtonControl(NavigatorButtonControl navigator);

        void AddErrorScanningLexem(CodeLexem addLexem);

        void ErrorScanningLexemButtonControl(NavigatorButtonControl navigator);

        void UpdateKeywordLexems(List<Keyword> Keywords);

        void UpdateSeparatorLexems(List<Separator> Separators);

        void UpdateIdentificatorLexems(List<Identificator> Identificators);

        void UpdateLiteralAndNumberLexems(List<Lexem> Literals);

        void UpdateClassifiedLexems(List<ClassifiedLexem> ClassifiedLexems);

        void ClassifiedLexemButtonControl(NavigatorButtonControl navigator);

        void NullSelectedClassifedLexem();

        void WarningMessage(string message, string name);

        bool QuestionMessage(string message, string name);

        event Action ProgramCodeEnterText;

        event Action ProgramCodeTextChanged;

        event Action ProgramCodeLeaveText;

        event Action StartCodeAnalyzer;

        event Action ClassifiedLexemCode;

        event Action BackToLexemScanningCode;

        event Action ClearProgramCode;

        event Action LoadCodeFile;

        event Action CancelAnalyze;

        event Action SelectedCurrentScannerLexem;

        event Action FirstScannerLexem;

        event Action PreviousScannerLexem;

        event Action NextScannerLexem;

        event Action LastScannerLexem;

        event Action SelectedCurrentErrorScannerLexem;

        event Action FirstErrorScannerLexem;

        event Action PreviousErrorScannerLexem;

        event Action NextErrorScannerLexem;

        event Action LastErrorScannerLexem;

        event Action SelectedCurrentClassifiedLexem;

        event Action FirstClassifiedLexem;

        event Action PreviousClassifiedLexem;

        event Action NextClassifiedLexem;

        event Action LastClassifiedLexem;

        event OpenSelectLanguageView OpenSelectLanguageView;

        event OpenLanguageSettingView OpenLanguageSettingView;

        event OpenSyntaxLanguageSettingView OpenSyntaxLanguageSettingView;
    }
}