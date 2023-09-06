using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompileApplication.Model.LexemTypes;

namespace CompileApplication.Model.LexicalScanner
{
    public class CodeLexem
    {
        public TextCharPosition StartPosition { get; }

        public Lexem Lexem { get; }

        public CodeLexem(TextCharPosition startPosition, Lexem lexem)
        {
            StartPosition = startPosition;
            Lexem = lexem;
        }
    }
}