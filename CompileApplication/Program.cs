using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompileApplication.Presenters;
using CompileApplication.UserInterface;

namespace CompileApplication
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            CompilationApplicationPresenter startPresenter =
                new CompilationApplicationPresenter(new CompilationApplicationForm());
            startPresenter.Run();

            Application.Run();
        }
    }
}
