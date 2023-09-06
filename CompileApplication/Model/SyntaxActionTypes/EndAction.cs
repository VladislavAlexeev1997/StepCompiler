using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileApplication.Model.SyntaxActionTypes
{
    public class EndAction : IAction
    {
        public ActionType Type()
        {
            return ActionType.End;
        }

        public string ActionText()
        {
            return "конец разбора";
        }

        public bool EquateTo(IAction otherAction)
        {
            return otherAction.Type() == ActionType.End;
        }
    }
}