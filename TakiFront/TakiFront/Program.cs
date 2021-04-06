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
        public static Dictionary<int, Form> formsMap = new Dictionary<int, Form>();
        public static int formsCounter = 1;


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
            Application.Restart();
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

        public static void addFormToMap(int index, Form form)
        {
            
            formsMap[index] = form;
        }


        public static void formCloseMap()
        {
            while(formsMap.Keys.Count > 0)
            {
                formsMap.Keys.ElementAt(formsMap.Keys.Count - 1);
                
            }
        }
    }
}
