// Developer Express Code Central Example:
// How to get the list of available reports, export to PDF and display a report preview in a Windows Forms application
// 
// The sample demonstrates how to use the Report Server WCF API in a Windows Forms
// application.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E5062

// Developer Express Code Central Example:
// How to connect to a Report Server from a Windows Forms application
// 
// The sample demonstrates how to use the Report Server WCF API in a Windows Forms
// application.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E5062

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportServerWinFormsClientDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
