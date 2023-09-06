using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompileApplication.Model.Tools;

namespace CompileApplication.Model.DeterministicTableElements
{
    public class DeterministicState
    {
        public ViewerList<DeterministicElement> StateElements { get; }

        public bool IsEdit { get; set; }

        public DeterministicState()
        {
            StateElements = new ViewerList<DeterministicElement>();
            IsEdit = true;
        }

        public DeterministicState(ViewerList<DeterministicElement> stateElements)
        {
            StateElements = stateElements;
            IsEdit = true;
        }

        public DeterministicState(ViewerList<DeterministicElement> stateElements,
            bool isEdit)
        {
            StateElements = stateElements;
            IsEdit = isEdit;
        }

        public void AddStateElement()
        {
            StateElements.AddNewElement(new DeterministicElement());
        }

        public void DeleteCurrentStateElement()
        {
            StateElements.DeleteCurrentElement();
        }

        public DeterministicElement GetCurrentStateElement()
        {
            return StateElements.GetCurrentElement();
        }

        public int GetCurrentStateElementIndex()
        {
            return StateElements.CurrentIndex;
        }
    }
}