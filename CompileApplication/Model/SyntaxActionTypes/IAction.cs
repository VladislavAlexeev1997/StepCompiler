using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileApplication.Model.SyntaxActionTypes
{
    public interface IAction
    {
        ActionType Type();

        string ActionText();

        bool EquateTo(IAction otherAction);
    }
}