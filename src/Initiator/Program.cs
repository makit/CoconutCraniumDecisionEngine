using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace makit.TheCoconutCraniumDecisionEngine.Initiator
{
    static class Program
    {
        static FormAppLoader loader;
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            loader = new FormAppLoader();
            Application.Run(loader);
        }
    }
}
