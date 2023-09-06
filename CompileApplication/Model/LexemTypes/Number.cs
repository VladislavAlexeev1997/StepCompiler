using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileApplication.Model.LexemTypes
{
    public class Number : Lexem
    {
        public Number(string item) :
            base(item) { }

        public Number(string item, bool isEdit) :
            base(item, isEdit) { }

        public override LexemType Type()
        {
            return LexemType.Number;
        }

        public override string TypeName()
        {
            return "число";
        }
    }
}