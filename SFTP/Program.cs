using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.Threading;


namespace SFTP
{
     class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

  
        static void Main()
        {
            using (System.Threading.Mutex mutex = new System.Threading.Mutex(false, "Global\\" + appGuid))
            {
                if(!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("App Already Running!", "NILE Agent", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    // var thread = new Thread(FormApp);
                    // thread.Name = "MainThread";
                    // thread.Start();
                    FormApp();
                }

                // Application.Exit();
            }

        }
        private static readonly string appGuid = "f8441a77-6129-46bb-8694-4f93ba297089";
        private static void FormApp()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSFTPMain());
        }


    }
}
