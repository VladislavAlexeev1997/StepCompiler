using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileApplication.Model.LexemTypes
{
    public class Comment : Lexem
    {
        public string Commentary { get; set; }

        public Comment(string item, string commentary) :
            base(item)
        {
            Commentary = commentary;
        }

        public Comment(string item, string commentary, bool isEdit) :
            base(item, isEdit)
        {
            Commentary = commentary;
        }

        public override LexemType Type()
        {
            return LexemType.Comment;
        }

        public override string TypeName()
        {
            return "лексема для комментариев";
        }

        public override bool Equals(object obj)
        {
            return Item == ((Comment)obj).Item &&
                Commentary == ((Comment)obj).Commentary;
        }

        public override int GetHashCode()
        {
            return Item.GetHashCode() + Commentary.GetHashCode() +
                IsEdit.GetHashCode();
        }
    }
}