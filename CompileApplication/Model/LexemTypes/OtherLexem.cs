using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileApplication.Model.LexemTypes
{
    public class OtherLexem : Lexem
    {
        public OtherLexem(string item) :
            base(item) { }

        public OtherLexem(string item, bool isEdit) :
            base(item, isEdit) { }

        public override LexemType Type()
        {
            return LexemType.OtherLexem;
        }

        public override string TypeName()
        {
            return "дополнительная лексема";
        }
    }
}