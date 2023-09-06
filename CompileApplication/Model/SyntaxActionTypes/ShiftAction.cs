using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileApplication.Model.SyntaxActionTypes
{
    public class ShiftAction : IAction
    {
        public ActionType Type()
        {
            return ActionType.Shift;
        }

        public string ActionText()
        {
            return "сдвиг";
        }

        public bool EquateTo(IAction otherAction)
        {
            return otherAction.Type() == ActionType.Shift;
        }
    }
}