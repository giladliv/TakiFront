using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TakiFront
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1("girado"));
            Application.Run(new ConnectForm());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            AddLog((Exception)e.ExceptionObject);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            //AddLog(e.Exception);
            MessageBox.Show(e.Exception.Message);
        }

        static void AddLog(Exception exception)
        {
            try
            {
                //using (StreamWriter sw = new StreamWriter(@"d:\tmp\app.log", true))
                //{
                //    sw.WriteLine(exception.ToString());
                //}
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
