using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excalibur.Framework;

namespace Excalibur.Project.Template
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new Bootstrapper<ShellViewModel>().Run();
        }
    }
}
