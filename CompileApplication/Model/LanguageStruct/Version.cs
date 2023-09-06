using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompileApplication.Model.LexemTypes;
using CompileApplication.Model.Tools;
using CompileApplication.Model.DeterministicTableElements;

namespace CompileApplication.Model.LanguageStruct
{
    public class Version
    {
        public string VersionName { get; }

        public ViewerList<Separator> Separators { get; }

        public ViewerList<Keyword> Keywords { get; }

        public ViewerList<Comment> Comments { get; }

        public ViewerList<OtherLexem> OtherLexems { get; }

        public Identificator IdentificatorMark { get; }

        public Number NumberMark { get; }

        public Literal LiteralMark { get; }

        public ViewerList<DeterministicState> SyntaxTable { get; }

        public Version(string version, ViewerList<Separator> separators,
            ViewerList<Keyword> keywords, ViewerList<Comment> comments,
            ViewerList<OtherLexem> otherLexems, Identificator identificator,
            Number number, Literal literal, ViewerList<DeterministicState> syntaxTable)
        {
            VersionName = version;
            Separators = separators;
            Keywords = keywords;
            Comments = comments;
            OtherLexems = otherLexems;
            IdentificatorMark = identificator;
            NumberMark = number;
            LiteralMark = literal;
            SyntaxTable = syntaxTable;
        }

        public void AddSyntaxState()
        {
            SyntaxTable.AddNewElement(new DeterministicState());
        }

        public void DeleteCurrentSyntaxState()
        {
            SyntaxTable.DeleteCurrentElement();
        }

        public void EditCurrentSyntaxStateIndex(int newIndex)
        {
            SyntaxTable.EditCurrentElementPosition(newIndex);
        }

        public DeterministicState GetCurrentSyntaxState()
        {
            return SyntaxTable.GetCurrentElement();
        }

        public int GetCurrentSyntaxStateIndex()
        {
            return SyntaxTable.CurrentIndex;
        }
    }
}