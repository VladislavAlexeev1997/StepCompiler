using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileApplication.Model.LexemTypes
{
    public class Lexem
    {
        public string Item { get; set; }

        public bool IsEdit { get; set; }

        public Lexem(string item)
        {
            Item = item;
            IsEdit = true;
        }

        public Lexem(string item, bool isEdit)
        {
            Item = item;
            IsEdit = isEdit;
        }

        public virtual LexemType Type()
        {
            return LexemType.Default;
        }

        public virtual string TypeName()
        {
            return "лексема";
        }

        public override bool Equals(object obj)
        {
            return Item == ((Lexem)obj).Item;
        }

        public override int GetHashCode()
        {
            return Item.GetHashCode() +
                IsEdit.GetHashCode();
        }
    }
}