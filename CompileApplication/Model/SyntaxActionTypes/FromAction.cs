using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompileApplication.Model.LexemTypes;

namespace CompileApplication.Model.SyntaxActionTypes
{
    public class FromAction : IAction
    {
        public int FromLexemCount { get; set; }

        public Lexem ToLexem { get; set; }

        public FromAction(int fromLexemCount,
            Lexem toLexem)
        {
            FromLexemCount = fromLexemCount;
            ToLexem = toLexem;
        }

        public ActionType Type()
        {
            return ActionType.From;
        }

        public string ActionText()
        {
            return "приведение (-" + FromLexemCount.ToString() +
                ") к " + ToLexem.Item;
        }

        public bool EquateTo(IAction otherAction)
        {
            if (otherAction.Type() == ActionType.From)
            {
                return ((FromAction)otherAction).FromLexemCount == this.FromLexemCount &&
                    ((FromAction)otherAction).ToLexem.Item == this.ToLexem.Item &&
                    ((FromAction)otherAction).ToLexem.IsEdit == this.ToLexem.IsEdit;
            }
            else
            {
                return false;
            }
        }
    }
}