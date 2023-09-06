using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileApplication.Model.LexemTypes
{
    public class NonLexem : Lexem
    {
        public NonLexem(string item) :
            base(item) { }

        public override LexemType Type()
        {
            return LexemType.NonLexem;
        }

        public override string TypeName()
        {
            return "неопределенная лексема";
        }
    }
}