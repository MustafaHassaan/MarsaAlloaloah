using MarsaAlloaloah.Forms.Boats;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsaAlloaloah
{
    static class Program
    {
        private static Thread thread;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            thread = new Thread(BusyWorkThread);
            thread.IsBackground = false;
            thread.Start();

            //Application.Run(new frmLogin());
            Process[] pname = Process.GetProcessesByName("MarsaAlloaloah");
            if (pname.Length > 1)
            {
                MessageBox.Show("البرنامج يعمل بالفعل");
            }
            else
            {
                Application.Run(new frmLogin());
            }

            //if (System.Windows.Forms.Application.MessageLoop)
            //{
            //    // WinForms app
            //    System.Windows.Forms.Application.Exit();
            //}
            //else
            //{
            //    // Console app
            //    System.Environment.Exit(1);
            //}
        }

        /// <summary>
        /// When IsBackground is false it will keep your program open till the thread completes, 
        /// if you set IsBackground to true the thread will not keep the program open. Things like BackgroundWoker, 
        /// ThreadPool, and Task all internally use a thread with IsBackground set to true.
        /// </summary>
        public static void BusyWorkThread()
        {
            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
