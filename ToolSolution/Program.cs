using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolSolution
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            FindProcess("ToolSolution");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void FindProcess(string processName)
        {
            try
            {
                System.Diagnostics.Process[] allProc = System.Diagnostics.Process.GetProcessesByName(processName);
                if (allProc.Length > 1)
                {
                    throw new Exception("已运行一个程序！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
        }
    }
}
