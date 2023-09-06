using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompileApplication.Views.Enums;

namespace CompileApplication.Views
{
    public interface ISyntaxLanguageSettingView : IView
    {
        SyntaxLanguageSetting Position { get; set; }

        List<string> Languages { set; }

        List<string> LanguageVersions { set; }

        string SelectLanguage { get; }

        string SelectVersion { get; }

        int SelectLanguageIndex { get; set; }

        int SelectVersionIndex { get; set; }

        int SelectStateIndex { get; set; }

        void AddDetermenisticState();

        void SetDetermenisticStateList(int determenisticStateCount);

        event Action SelectedLanguage;

        event Action SelectedVersion;

        event Action SelectedState;

        event Action CloseSyntaxLanguageSetting;
    }
}
