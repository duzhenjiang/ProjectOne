using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ToolSolution.Addins.Adb
{
    class ADBHelper
    {
        /// <summary>
        /// 发送adb指令
        /// </summary>
        /// <param name="sCmd">adb指令</param>
        /// <param name="sResp">返回值</param>
        public void ADBCommend(string sCmd, out string sResp, bool bOutput = true)
        {
            string sCmdexe = Application.StartupPath + "\\adb\\adb.exe";

            Process p = new Process();
            p.StartInfo.FileName = sCmdexe;
            p.StartInfo.Arguments = sCmd;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = bOutput;
            p.StartInfo.RedirectStandardOutput = bOutput;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            if (bOutput)
            {
                sResp = p.StandardOutput.ReadToEnd();
            }
            else 
            {
                sResp = "No wait Resp";
            }
            p.Close();
        }
    }
}
