using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileApplication.Model.LexemTypes
{
    public enum LexemType
    {
        Default,
        Separator,
        Keyword,
        Comment,
        Identificator,
        Number,
        Literal,
        OtherLexem,
        NonLexem
    }
}
