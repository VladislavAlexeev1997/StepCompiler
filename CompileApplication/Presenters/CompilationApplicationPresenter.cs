using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using CompileApplication.Views;
using CompileApplication.Views.Enums;
using CompileApplication.Model.LexicalScanner;
using CompileApplication.Model.LexicalClassification;
using CompileApplication.Model.LexemTypes;

namespace CompileApplication.Presenters
{
    public class CompilationApplicationPresenter : Presenter<ICompilationApplicationView>
    {
        private const string DEFAULT_CURRENT_LANGUAGE = "язык не выбран";

        private const string DEFAULT_CURRENT_VERSION = "версия языка не выбрана";

        private const string DEFAULT_CODE_CONST = "Введите код программы";

        private const string LEXICAL_ANALYZES = "Лексический анализатор";

        private const string LEXICAL_ANALYZES_SCANNER = "Сканер кода программы";

        private const string LEXICAL_ANALYZES_CLASSIFIED = "Классификация лексем";

        private const string PARCER_ANALYZES = "Синтаксический анализатор";

        private readonly Color DEFAULT_COLOR_TEXT = SystemColors.ControlDark;

        private readonly Color COLOR_TEXT = SystemColors.WindowText;

        private List<CodeLexem> ScannerLexems;

        private int ErrorScannerLexemCount;

        private LexemClassifier LexemClassifier;

        public CompilationApplicationPresenter(ICompilationApplicationView compilationApplicationView) : 
            base(compilationApplicationView)
        {
            ScannerLexems = new List<CodeLexem>();
            LexemClassifier = new LexemClassifier();
            InitializeViewEvents();
            InitializeView();
        }

        private void InitializeViewEvents()
        {
            View.ProgramCodeEnterText += () => ProgramCodeEnterText();
            View.ProgramCodeTextChanged += () => ProgramCodeTextChanged();
            View.ProgramCodeLeaveText += () => ProgramCodeLeaveText();
            View.ClearProgramCode += () => ClearProgramCode();
            View.LoadCodeFile += () => LoadCodeFile();
            View.StartCodeAnalyzer += () => LexemScanningCode();
            View.ClassifiedLexemCode += () => ClassifiedLexemCode();
            View.BackToLexemScanningCode += () => BackToLexemScanningCode();
            View.OpenSelectLanguageView += (openView) => OpenSelectLanguageView(openView);
            View.OpenLanguageSettingView += (openView) => OpenSettingLanguageView(openView);
            View.OpenSyntaxLanguageSettingView += (openView) => OpenSyntaxLanguageSettingView(openView);
            View.SelectedCurrentScannerLexem += () => SelectedCurrentScannerLexem();
            View.FirstScannerLexem += () => FirstScannerLexem();
            View.PreviousScannerLexem += () => PreviousScannerLexem();
            View.NextScannerLexem += () => NextScannerLexem();
            View.LastScannerLexem += () => LastScannerLexem();
            View.SelectedCurrentErrorScannerLexem += () => SelectedCurrentErrorScannerLexem();
            View.FirstErrorScannerLexem += () => FirstErrorScannerLexem();
            View.PreviousErrorScannerLexem += () => PreviousErrorScannerLexem();
            View.NextErrorScannerLexem += () => NextErrorScannerLexem();
            View.LastErrorScannerLexem += () => LastErrorScannerLexem();
            View.SelectedCurrentClassifiedLexem += () => SelectedCurrentClassifiedLexem();
            View.FirstClassifiedLexem += () => FirstClassifiedLexem();
            View.PreviousClassifiedLexem += () => PreviousClassifiedLexem();
            View.NextClassifiedLexem += () => NextClassifiedLexem();
            View.LastClassifiedLexem += () => LastClassifiedLexem();
            View.CancelAnalyze += () => CancelAnalyze();
            View.UpdateViewEvents();
        }

        private void InitializeView()
        {
            View.ProgramCodeMasked(DEFAULT_CODE_CONST, DEFAULT_COLOR_TEXT);
            NullSettingLanguageParameter();
            ErrorScannerLexemCount = 0;
            View.ScanningLexemButtonControl(NavigatorButtonControl.NonControl);
            View.ErrorScanningLexemButtonControl(NavigatorButtonControl.NonControl);
            View.ClassifiedLexemButtonControl(NavigatorButtonControl.NonControl);
            View.Position = CodeAnalyzer.StartPosition;
            View.NowAnalyzerStep = View.Position;
        }

        private void NullSettingLanguageParameter()
        {
            View.CurrentLanguage = DEFAULT_CURRENT_LANGUAGE;
            View.CurrentVersion = DEFAULT_CURRENT_VERSION;
        }

        private void ProgramCodeEnterText()
        {
            if (View.ProgramCodeText == DEFAULT_CODE_CONST)
            {
                View.ProgramCodeMasked("", COLOR_TEXT);
            }
        }

        private void ProgramCodeTextChanged()
        {
            var numberedLines = View.ProgramCodeText
                .Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None)
                .Select((line, index) => (index + 1))
                .ToArray();
            var result = string.Join(Environment.NewLine, numberedLines);
            View.ProgramCodeLineNumbers = result;
        }

        private void ProgramCodeLeaveText()
        {
            if (View.ProgramCodeText == "" ||
                View.ProgramCodeText == DEFAULT_CODE_CONST)
            {
                ClearProgramCode();
            }
        }

        private void ClearProgramCode()
        {
            View.ProgramCodeMasked(DEFAULT_CODE_CONST, DEFAULT_COLOR_TEXT);
        }

        private void LoadCodeFile()
        {
            string fileName = View.OpenCodeFileName();
            if (fileName != "")
            {
                View.ProgramCodeMasked("", COLOR_TEXT);
                View.ProgramCodeText = File.ReadAllText(fileName);
            }
        }

        private void OpenSelectLanguageView(ISelectLanguageView openView)
        {
            SelectLanguagePresenter selectLanguagePresenter =
                new SelectLanguagePresenter(openView, View);
            selectLanguagePresenter.Run();
        }

        private void OpenSettingLanguageView(ILanguageSettingView openView)
        {
            View.HideInterface();
            NullSettingLanguageParameter();
            LanguageSettingPresenter languageSettingPresenter =
                new LanguageSettingPresenter(openView, View);
            languageSettingPresenter.Run();
        }

        private void OpenSyntaxLanguageSettingView(ISyntaxLanguageSettingView openView)
        {
            View.HideInterface();
            NullSettingLanguageParameter();
            SyntaxLanguageSettingPresenter syntaxLanguageSettingPresenter =
                new SyntaxLanguageSettingPresenter(openView, View);
            syntaxLanguageSettingPresenter.Run();
        }

        private void LexemScanningCode()
        {
            if (View.CurrentLanguage == DEFAULT_CURRENT_LANGUAGE)
            {
                View.WarningMessage(
                    "Для начала анализа программного кода необходимо " +
                    "выбрать язык компиляции и его версию. При необходимости " +
                    "создать новый язык компиляции или изменить существующий, " +
                    "в меню 'Параметры' нажмите 'Настройка языков компиляции'",
                    "Ошибка анализа программного кода");
            }
            else if (View.ProgramCodeText == DEFAULT_CODE_CONST ||
                View.ProgramCodeText == "")
            {
                View.WarningMessage(
                    "Для начала анализа программного кода необходимо " +
                    "ввести код программы",
                    "Ошибка анализа программного кода");
            }
            else
            {
                LexemScanner LexemScanner = new LexemScanner(View.ProgramCode, 
                    View.CurrentLanguage, View.CurrentVersion);
                ScannerLexems = LexemScanner.CodeLexemScanner(out ErrorScannerLexemCount);
                foreach (CodeLexem scannerLexem in ScannerLexems)
                {
                    View.AddScanningLexem(scannerLexem);
                    if (scannerLexem.Lexem is NonLexem)
                    {
                        View.AddErrorScanningLexem(scannerLexem);
                    }
                }
                if (ErrorScannerLexemCount > 0)
                {
                    View.Position = CodeAnalyzer.CodeScanner;
                    View.CurrentErrorScannerLexemIndex = 0;
                }
                else
                {
                    View.Position = CodeAnalyzer.SuccsessCodeScanner;
                }
                View.NowAnalyzerStep = View.Position;
                View.CurrentScannerLexemIndex = 0;
                View.AnalyzeType = LEXICAL_ANALYZES;
                View.AnalyzeTypeStep = LEXICAL_ANALYZES_SCANNER;
            }
        }

        private void ClassifiedLexemCode()
        {
            if (View.NowAnalyzerStep == CodeAnalyzer.SuccsessCodeScanner)
            {
                LexemClassifier = new LexemClassifier(
                    View.CurrentLanguage, View.CurrentVersion);
                LexemClassifier.ClassifiedCodeLexems(ScannerLexems);
                View.UpdateKeywordLexems(LexemClassifier.Keywords);
                if (LexemClassifier.Keywords.Count > 0)
                {
                    View.CurrentKeywordIndex = 0;
                }
                View.UpdateSeparatorLexems(LexemClassifier.Separators);
                if (LexemClassifier.Separators.Count > 0)
                {
                    View.CurrentSeparatorIndex = 0;
                }
                View.UpdateIdentificatorLexems(LexemClassifier.Identificators);
                if (LexemClassifier.Identificators.Count > 0)
                {
                    View.CurrentIdentificatorIndex = 0;
                }
                View.UpdateLiteralAndNumberLexems(LexemClassifier.LiteralsAndNumbers);
                if (LexemClassifier.LiteralsAndNumbers.Count > 0)
                {
                    View.CurrentLiteralAndNumberIndex = 0;
                }
                View.NullSelectedClassifedLexem();
                View.UpdateClassifiedLexems(LexemClassifier.ClassifiedLexems);
                if (LexemClassifier.ClassifiedLexems.Count > 0)
                {
                    View.CurrentClassifiedLexemIndex = 0;
                }
                View.Position = CodeAnalyzer.LexemClassification;
                View.NowAnalyzerStep = View.Position;
            }
            else
            {
                View.Position = CodeAnalyzer.LexemClassification;
            }
            View.AnalyzeType = LEXICAL_ANALYZES;
            View.AnalyzeTypeStep = LEXICAL_ANALYZES_CLASSIFIED;
        }

        private void BackToLexemScanningCode()
        {
            View.Position = CodeAnalyzer.SuccsessCodeScanner;
            View.AnalyzeType = LEXICAL_ANALYZES;
            View.AnalyzeTypeStep = LEXICAL_ANALYZES_SCANNER;
        }

        private void SelectedCurrentScannerLexem()
        {
            if (ScannerLexems.Count != 0)
            {
                if (ScannerLexems.Count == 1)
                {
                    View.ScanningLexemButtonControl(NavigatorButtonControl.OneNode);
                }
                else
                {
                    if (View.CurrentScannerLexemIndex == 0)
                    {
                        View.ScanningLexemButtonControl(NavigatorButtonControl.First);
                    }
                    else if (View.CurrentScannerLexemIndex == ScannerLexems.Count - 1)
                    {
                        View.ScanningLexemButtonControl(NavigatorButtonControl.Last);
                    }
                    else
                    {
                        View.ScanningLexemButtonControl(NavigatorButtonControl.Middle);
                    }
                }
            }
            else
            {
                View.ScanningLexemButtonControl(NavigatorButtonControl.NonControl);
            }
        }

        private void FirstScannerLexem()
        {
            View.CurrentScannerLexemIndex = 0;
        }

        private void PreviousScannerLexem()
        {
            if (View.CurrentScannerLexemIndex > 0)
            {
                View.CurrentScannerLexemIndex -= 1;
            }
        }

        private void NextScannerLexem()
        {
            if (View.CurrentScannerLexemIndex < ScannerLexems.Count - 1)
            {
                View.CurrentScannerLexemIndex += 1;
            }
        }

        private void LastScannerLexem()
        {
            View.CurrentScannerLexemIndex = ScannerLexems.Count - 1;
        }

        private void SelectedCurrentErrorScannerLexem()
        {
            if (ErrorScannerLexemCount != 0)
            {
                if (ErrorScannerLexemCount == 1)
                {
                    View.ErrorScanningLexemButtonControl(NavigatorButtonControl.OneNode);
                }
                else
                {
                    if (View.CurrentErrorScannerLexemIndex == 0)
                    {
                        View.ErrorScanningLexemButtonControl(NavigatorButtonControl.First);
                    }
                    else if (View.CurrentErrorScannerLexemIndex == ErrorScannerLexemCount - 1)
                    {
                        View.ErrorScanningLexemButtonControl(NavigatorButtonControl.Last);
                    }
                    else
                    {
                        View.ErrorScanningLexemButtonControl(NavigatorButtonControl.Middle);
                    }
                }
            }
            else
            {
                View.ErrorScanningLexemButtonControl(NavigatorButtonControl.NonControl);
            }
        }

        private void FirstErrorScannerLexem()
        {
            View.CurrentErrorScannerLexemIndex = 0;
        }

        private void PreviousErrorScannerLexem()
        {
            if (View.CurrentErrorScannerLexemIndex > 0)
            {
                View.CurrentErrorScannerLexemIndex -=1;
            }
        }

        private void NextErrorScannerLexem()
        {
            if (View.CurrentErrorScannerLexemIndex < ErrorScannerLexemCount - 1)
            {
                View.CurrentErrorScannerLexemIndex += 1;
            }
        }

        private void LastErrorScannerLexem()
        {
            View.CurrentErrorScannerLexemIndex = ErrorScannerLexemCount - 1;
        }

        private void SelectedCurrentClassifiedLexem()
        {
            if (LexemClassifier.ClassifiedLexems.Count != 0)
            {
                if (LexemClassifier.ClassifiedLexems.Count == 1)
                {
                    View.ClassifiedLexemButtonControl(NavigatorButtonControl.OneNode);
                }
                else
                {
                    if (View.CurrentClassifiedLexemIndex == 0)
                    {
                        View.ClassifiedLexemButtonControl(NavigatorButtonControl.First);
                    }
                    else if (View.CurrentClassifiedLexemIndex == 
                        LexemClassifier.ClassifiedLexems.Count - 1)
                    {
                        View.ClassifiedLexemButtonControl(NavigatorButtonControl.Last);
                    }
                    else
                    {
                        View.ClassifiedLexemButtonControl(NavigatorButtonControl.Middle);
                    }
                }
                SelectClassifiedElement();
            }
            else
            {
                View.ClassifiedLexemButtonControl(NavigatorButtonControl.NonControl);
            }
        }

        private void SelectClassifiedElement()
        {
            View.NullSelectedClassifedLexem();
            ClassifiedLexem currentClassifiedLexem = 
                LexemClassifier.ClassifiedLexems[View.CurrentClassifiedLexemIndex];
            int currentClassLexem = currentClassifiedLexem.LexemNumber - 1;
            switch (currentClassifiedLexem.ClassNumber)
            {
                case 1:
                    View.CurrentKeywordIndex = currentClassLexem;
                    break;
                case 2:
                    View.CurrentSeparatorIndex = currentClassLexem;
                    break;
                case 3:
                    View.CurrentIdentificatorIndex = currentClassLexem;
                    break;
                default:
                    View.CurrentLiteralAndNumberIndex = currentClassLexem;
                    break;
            }
        }

        private void FirstClassifiedLexem()
        {
            View.CurrentClassifiedLexemIndex = 0;
        }

        private void PreviousClassifiedLexem()
        {
            if (View.CurrentClassifiedLexemIndex > 0)
            {
                View.CurrentClassifiedLexemIndex -= 1;
            }
        }

        private void NextClassifiedLexem()
        {
            if (View.CurrentClassifiedLexemIndex < LexemClassifier.ClassifiedLexems.Count - 1)
            {
                View.CurrentClassifiedLexemIndex += 1;
            }
        }

        private void LastClassifiedLexem()
        {
            View.CurrentClassifiedLexemIndex = LexemClassifier.ClassifiedLexems.Count - 1;
        }

        private void CancelAnalyze()
        {
            bool cancelResult = View.QuestionMessage(
                "Вы действительно хотите завершить пошаговую компиляцию кода?",
                "Запрос на отмену пошаговую компиляцию кода");
            if (cancelResult)
            {
                ScannerLexems.Clear();
                View.CurrentScannerLexemIndex = -1;
                ErrorScannerLexemCount = 0;
                View.CurrentErrorScannerLexemIndex = -1;
                LexemClassifier.Clear();
                View.CurrentClassifiedLexemIndex = -1;
                View.Position = CodeAnalyzer.StartPosition;
                View.NowAnalyzerStep = View.Position;
            }
        }
    }
}