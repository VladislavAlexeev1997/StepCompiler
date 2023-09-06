using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileApplication.Views
{
    public interface ISelectLanguageView : IView
    {
        List<string> Languages { set; }

        string SelectLanguage { get; }

        int SelectLanguageIndex { get; set; }

        bool IsLanguageSelect { set; }

        List<string> LanguageVersions { set; }

        string SelectVersion { get; }

        int SelectVersionIndex { get; set; }

        bool IsVersionSelect { set; }

        event Action CheckLanguage;

        event Action CheckVersion;

        event Action SelectedLanguage;
    }
}
