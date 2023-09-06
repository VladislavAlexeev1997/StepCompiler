using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileApplication.Model.LexemTypes
{
    public class Keyword : Lexem
    {
        public string Commentary { get; set; }

        public Keyword(string item, string commentary) :
            base(item)
        {
            Commentary = commentary;
        }

        public Keyword(string item, string commentary, bool isEdit) :
            base(item, isEdit)
        {
            Commentary = commentary;
        }

        public override LexemType Type()
        {
            return LexemType.Keyword;
        }

        public override string TypeName()
        {
            return "ключевое слово";
        }

        public override bool Equals(object obj)
        {
            return Item == ((Keyword)obj).Item &&
                Commentary == ((Keyword)obj).Commentary;
        }

        public override int GetHashCode()
        {
            return Item.GetHashCode() + Commentary.GetHashCode() +
                IsEdit.GetHashCode();
        }
    }
}