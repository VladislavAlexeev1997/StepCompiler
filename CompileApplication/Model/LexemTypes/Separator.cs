using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileApplication.Model.LexemTypes
{
    public class Separator : Lexem
    {
        public string Commentary { get; set; }

        public Separator(string item, string commentary) :
            base(item)
        {
            Commentary = commentary;
        }

        public Separator(string item, string commentary, bool isEdit) :
            base(item, isEdit)
        {
            Commentary = commentary;
        }

        public override LexemType Type()
        {
            return LexemType.Separator;
        }

        public override string TypeName()
        {
            return "разделитель";
        }

        public override bool Equals(object obj)
        {
            return Item == ((Separator)obj).Item &&
                Commentary == ((Separator)obj).Commentary;
        }

        public override int GetHashCode()
        {
            return Item.GetHashCode() + Commentary.GetHashCode() +
                IsEdit.GetHashCode();
        }
    }
}
