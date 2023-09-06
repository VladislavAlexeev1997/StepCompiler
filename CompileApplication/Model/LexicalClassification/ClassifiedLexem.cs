using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompileApplication.Model.LexemTypes;

namespace CompileApplication.Model.LexicalClassification
{
    public class ClassifiedLexem
    {
        public int ClassNumber { get; set; }

        public int LexemNumber { get; set; }

        public Lexem Lexem { get; set; }

        public ClassifiedLexem(int classNumber, int lexemNumber, Lexem lexem)
        {
            ClassNumber = classNumber;
            LexemNumber = lexemNumber;
            Lexem = lexem;
        }
    }
}