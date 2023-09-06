using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompileApplication.Model.LexicalScanner;
using CompileApplication.Model.LexemTypes;
using CompileApplication.Model.LanguageStruct;
using CompileApplication.Model.Tools;

namespace CompileApplication.Model.LexicalClassification
{
    public class LexemClassifier
    {
        public List<Keyword> Keywords { get; private set; }

        public List<Separator> Separators { get; private set; }

        public List<Identificator> Identificators { get; private set; }

        public List<Lexem> LiteralsAndNumbers { get; private set; }

        public List<ClassifiedLexem> ClassifiedLexems { get; private set; }

        public LexemClassifier()
        {
            Clear();
        }

        public LexemClassifier(string language, string version)
        {
            LanguageData data = new LanguageData();
            Version CurrentVersion = data.LanguageVersion(language, version);
            Keywords = CurrentVersion.Keywords.ToList();
            Separators = CurrentVersion.Separators.ToList();
            Identificators = new List<Identificator>();
            LiteralsAndNumbers = new List<Lexem>();
            ClassifiedLexems = new List<ClassifiedLexem>();
        }

        public void ClassifiedCodeLexems(List<CodeLexem> codeLexems)
        {
            int lexemNumber;
            foreach (CodeLexem codeLexem in codeLexems)
            {
                if (codeLexem.Lexem is Keyword)
                {
                    lexemNumber = Keywords.IndexOf((Keyword)codeLexem.Lexem) + 1;
                    ClassifiedLexems.Add(
                        new ClassifiedLexem(1, lexemNumber, codeLexem.Lexem));
                }
                else if (codeLexem.Lexem is Separator)
                {
                    lexemNumber = Separators.IndexOf((Separator)codeLexem.Lexem) + 1;
                    ClassifiedLexems.Add(
                        new ClassifiedLexem(2, lexemNumber, codeLexem.Lexem));
                }
                else if (codeLexem.Lexem is Identificator)
                {
                    if (!Identificators.Contains((Identificator)codeLexem.Lexem))
                    {
                        Identificators.Add((Identificator)codeLexem.Lexem);
                    }
                    lexemNumber = Identificators.IndexOf((Identificator)codeLexem.Lexem) + 1;
                    ClassifiedLexems.Add(
                        new ClassifiedLexem(3, lexemNumber, codeLexem.Lexem));
                }
                else if (codeLexem.Lexem is Number || codeLexem.Lexem is Literal)
                {
                    if (!LiteralsAndNumbers.Contains(codeLexem.Lexem))
                    {
                        LiteralsAndNumbers.Add(codeLexem.Lexem);
                    }
                    lexemNumber = LiteralsAndNumbers.IndexOf(codeLexem.Lexem) + 1;
                    ClassifiedLexems.Add(
                        new ClassifiedLexem(4, lexemNumber, codeLexem.Lexem));
                }
            }
        }

        public void Clear()
        {
            Keywords = new List<Keyword>();
            Separators = new List<Separator>();
            Identificators = new List<Identificator>();
            LiteralsAndNumbers = new List<Lexem>();
            ClassifiedLexems = new List<ClassifiedLexem>();
        }
    }
}