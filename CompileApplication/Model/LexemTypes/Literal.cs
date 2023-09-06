using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileApplication.Model.LexemTypes
{
    public class Literal : Lexem
    {
        public Literal(string item) :
            base(item) { }
        
        public Literal(string item, bool isEdit) :
            base(item, isEdit) { }

        public override LexemType Type()
        {
            return LexemType.Literal;
        }

        public override string TypeName()
        {
            return "литерал";
        }
    }
}