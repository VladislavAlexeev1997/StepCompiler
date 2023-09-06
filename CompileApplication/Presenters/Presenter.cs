using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompileApplication.Views;

namespace CompileApplication.Presenters
{
    public abstract class Presenter<ViewType>
        where ViewType : IView
    {
        protected ViewType View { get; private set; }

        protected Presenter(ViewType view)
        {
            View = view;
        }

        public void Run()
        {
            View.ShowInterface();
        }
    }
}
