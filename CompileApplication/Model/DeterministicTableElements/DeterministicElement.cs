using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompileApplication.Model.LexemTypes;
using CompileApplication.Model.Tools;
using CompileApplication.Model.SyntaxActionTypes;

namespace CompileApplication.Model.DeterministicTableElements
{
    public class DeterministicElement
    {
        public ViewerList<Lexem> Stack { get; }

        public Lexem EnterLexem { get; set; }

        public ViewerList<IAction> Actions { get; }

        public bool IsEdit { get; set; }

        public DeterministicElement()
        {
            Stack = new ViewerList<Lexem>();
            EnterLexem = new Lexem("");
            Actions = new ViewerList<IAction>();
            IsEdit = true;
        }

        public DeterministicElement(ViewerList<Lexem> stack,
            Lexem enterLexem, ViewerList<IAction> actions)
        {
            Stack = stack;
            EnterLexem = enterLexem;
            Actions = actions;
            IsEdit = true;
        }

        public DeterministicElement(ViewerList<Lexem> stack, Lexem enterLexem,
            ViewerList<IAction> actions, bool isEdit)
        {
            Stack = stack;
            EnterLexem = enterLexem;
            Actions = actions;
            IsEdit = isEdit;
        }

        public void AddStackLexem(Lexem addStackLexem)
        {
            Stack.AddNewElement(addStackLexem);
        }

        public void AddAction(IAction addAction)
        {
            Actions.AddNewElement(addAction);
        }

        public void DeleteCurrentStackLexem()
        {
            Stack.DeleteCurrentElement();
        }

        public void DeleteCurrentAction()
        {
            Actions.DeleteCurrentElement();
        }

        public Lexem GetCurrentStackLexem()
        {
            return Stack.GetCurrentElement();
        }

        public IAction GetCurrentAction()
        {
            return Actions.GetCurrentElement();
        }

        public int GetCurrentStackLexemIndex()
        {
            return Stack.CurrentIndex;
        }

        public int GetCurrentActionIndex()
        {
            return Actions.CurrentIndex;
        }

        public void SetCurrentStackLexem(Lexem changeStackLexem)
        {
            Stack.SetCurrentElement(changeStackLexem);
        }

        public void SetCurrentAction(IAction changeAction)
        {
            Actions.SetCurrentElement(changeAction);
        }
    }
}