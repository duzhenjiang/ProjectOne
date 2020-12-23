using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace ADBHelper
{
    public class ADB
    {
        /// <summary>
        /// 发送adb指令
        /// </summary>
        /// <param name="sCmd">adb指令</param>
        /// <param name="sResp">返回值</param>
        public void ADBCommend(int i, string sCmd, out string sResp, bool bOutput = true)
        {
            string sCmdexe = "";
            switch (i)
            {
                case 0:
                    sCmdexe = Application.StartupPath + "\\DUT1\\adb\\adb.exe";
                    break;
                case 1:
                    sCmdexe = Application.StartupPath + "\\DUT2\\adb\\adb.exe";
                    break;
                case 2:
                    sCmdexe = Application.StartupPath + "\\DUT3\\adb\\adb.exe";
                    break;
                case 3:
                    sCmdexe = Application.StartupPath + "\\DUT4\\adb\\adb.exe";
                    break;
                default:
                    MessageBox.Show("unknown Dut number!");
                    break;
            }

            Process p = new Process();
            p.StartInfo.FileName = sCmdexe;
            p.StartInfo.Arguments = sCmd;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = bOutput;
            p.StartInfo.RedirectStandardOutput = bOutput;
            p.StartInfo.RedirectStandardError = bOutput;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.CreateNoWindow = true;
            if (bOutput)
            {
                p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            }
            p.Start();
            if (bOutput)
            {
                sResp = p.StandardError.ReadToEnd() + p.StandardOutput.ReadToEnd();
                p.WaitForExit();
            }
            else
            {
                sResp = "No wait Resp";
            }
            p.Close();
        }
    }
}
