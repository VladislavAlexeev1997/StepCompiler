using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileApplication.Model.SyntaxActionTypes
{
    public class PassingAction : IAction
    {
        public int ToState { get; set; }

        public PassingAction(int toState)
        {
            ToState = toState;
        }

        public ActionType Type()
        {
            return ActionType.Passing;
        }

        public string ActionText()
        {
            return "переход в " + ToState.ToString();
        }

        public bool EquateTo(IAction otherAction)
        {
            if (otherAction.Type() == ActionType.Passing)
            {
                return ((PassingAction)otherAction).ToState == this.ToState;
            }
            else
            {
                return false;
            }
        }
    }
}