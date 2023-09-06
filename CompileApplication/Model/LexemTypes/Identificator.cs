using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileApplication.Model.LexemTypes
{
    public class Identificator : Lexem
    {
        public Identificator(string item) :
            base(item) { }

        public Identificator(string item, bool isEdit) :
            base(item, isEdit) { }

        public override LexemType Type()
        {
            return LexemType.Identificator;
        }

        public override string TypeName()
        {
            return "идентификатор";
        }
    }
}