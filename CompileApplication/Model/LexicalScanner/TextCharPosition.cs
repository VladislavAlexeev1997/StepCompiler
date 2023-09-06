using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileApplication.Model.LexicalScanner
{
    public class TextCharPosition
    {
        public int Line { get; set; }

        public int CharNumber { get; set; }

        public TextCharPosition(int line, int charNumber)
        {
            Line = line;
            CharNumber = charNumber;
        }
    }
}