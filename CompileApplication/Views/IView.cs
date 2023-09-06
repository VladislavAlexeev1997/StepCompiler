using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileApplication.Views
{
    public interface IView
    {
        void ShowInterface();

        void CloseInterface();

        void UpdateViewEvents();
    }
}
