using System.Windows.Forms;
using System;

namespace FlowchartUtility
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Starting point of the Flowchart Utility execution
            Application.Run(new FlowchartUtility());
        }
    }
}