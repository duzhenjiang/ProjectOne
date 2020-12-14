using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text;

namespace ToolSolution.Addins.Mes
{
    class MesHelper
    {
        readonly string kWIPHandleFileName = "C:\\eBook_Test\\Handle.txt";
        readonly string[] kWIPNOFileName = new string[4];
        readonly string[] kWIPInfoFileName = new string[4];
        readonly string[] kRESInfoFileName = new string[4];
        public string[] m_szResultFileName = new string[4];
        public string[] m_iWIPID = new string[4];
        readonly string[] m_szWIPNo = new string[4];

        int m_hMonitorProcessHandle = 0;

        public List<string> testLogItems = new List<string>();

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(int hWnd, int msg, int wParam, int lParam);

        /// <summary>
        /// mes Init
        /// </summary>
        public void MesInit()
        {
            try 
            {
                string szTmpBuf = "";
                GetEqualString(kWIPHandleFileName, "Handle", ref szTmpBuf);
                if (szTmpBuf != "")
                {
                    m_hMonitorProcessHandle = Convert.ToInt32(szTmpBuf);
                }

                kWIPNOFileName[0] = "C:\\eBook_Test\\1_WIP.txt";
                kWIPNOFileName[1] = "C:\\eBook_Test\\2_WIP.txt";
                kWIPNOFileName[2] = "C:\\eBook_Test\\3_WIP.txt";
                kWIPNOFileName[3] = "C:\\eBook_Test\\4_WIP.txt";

                kWIPInfoFileName[0] = "C:\\eBook_Test\\1_WIP_INFO.txt";
                kWIPInfoFileName[1] = "C:\\eBook_Test\\2_WIP_INFO.txt";
                kWIPInfoFileName[2] = "C:\\eBook_Test\\3_WIP_INFO.txt";
                kWIPInfoFileName[3] = "C:\\eBook_Test\\4_WIP_INFO.txt";

                kRESInfoFileName[0] = "C:\\eBook_Test\\1_RES_INFO.txt";
                kRESInfoFileName[1] = "C:\\eBook_Test\\2_RES_INFO.txt";
                kRESInfoFileName[2] = "C:\\eBook_Test\\3_RES_INFO.txt";
                kRESInfoFileName[3] = "C:\\eBook_Test\\4_RES_INFO.txt";

                if (m_hMonitorProcessHandle == 0) throw new Exception("FIH Init Fail");
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Mes检查途程
        /// </summary>
        /// <param name="i">i</param>
        /// <param name="sParams"></param>
        public bool MesCheck(int i, string sParams, out string errMessage)
        {
            errMessage = "";
            FileStream fs = new FileStream(kWIPNOFileName[i], FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write("WIP_NO=" + sParams);
            sw.Flush();
            sw.Close();
            fs.Close();

            //Send message to notify monitor process
            SendMessage(m_hMonitorProcessHandle, 0x0802, 0, 1);

            //Wait for N_WIP_INFO.txt creation by monitor process
            bool bWIPInfoFileExisted = false;
            int retryTime = 10;
            for (int retryCount = 0; retryCount < retryTime; retryCount++)
            {
                if (File.Exists(kWIPInfoFileName[i]))
                {
                    bWIPInfoFileExisted = true;
                    break;
                }
                else
                    Thread.Sleep(1000);
            }
            if (!bWIPInfoFileExisted)
            {
                errMessage = "FIH WIP_INFO.txt NOT EXIST";
                return false;
            }

            //Read information from N_WIP_INFO.txt if exists
            string szTmpBuf = "";
            GetEqualString(kWIPInfoFileName[i], "PERMISSION", ref szTmpBuf);
            bool m_bPermisson = szTmpBuf.Contains("TRUE");
            if (!m_bPermisson)
            {
                errMessage = "MesCheck FAIL: " + szTmpBuf;
                return false;
            }

            szTmpBuf = "";
            GetEqualString(kWIPInfoFileName[i], "WIP_ID", ref szTmpBuf);
            m_iWIPID[i] = szTmpBuf;
            m_szResultFileName[i] = string.Format("C:\\eBook_Test\\{0}.txt", m_iWIPID);

            //Save verified SN
            m_szWIPNo[i] = sParams;

            //Remove N_WIP_INFO.txt
            if (File.GetAttributes(kWIPInfoFileName[i]).ToString().IndexOf("ReadOnly") != -1)
                File.SetAttributes(kWIPInfoFileName[i], FileAttributes.Normal);
            File.Delete(kWIPInfoFileName[i]);
            return true;
        }

        /// <summary>
        /// MesUpdate
        /// </summary>
        /// <param name="i">i</param>
        /// <param name="bResult">测试结果</param>
        /// <param name="errMessage">错误信息</param>
        /// <returns></returns>
        public bool MesUpdate(int i, bool bResult, out string errMessage)
        {
            errMessage = "";
            for (int j = 0; j < 5; j++)
            {
                if (File.Exists(m_szResultFileName[i]))
                {
                    break;
                }
                if (j == 4)
                {
                    errMessage = string.Format("{0} not create", m_szResultFileName[i]);
                    return false;
                }
                Thread.Sleep(1000);
            }

            FileStream fs = new FileStream(m_szResultFileName[i], FileMode.Append, FileAccess.Write, FileShare.None);
            StreamWriter sw = new StreamWriter(fs);
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("WIP_ID={0}", m_iWIPID[i])).Append("\r\n")
                .Append(string.Format("WIP_NO={0}", m_szWIPNo[i])).Append("\r\n")
                .Append(string.Format("IS_PASSED={0}", bResult ? 1 : 0));
            sw.WriteLine(sb);

            sw.Flush();
            sw.Close();
            fs.Close();

            //Send message to notify monitor process
            SendMessage(m_hMonitorProcessHandle, 0x0800, int.Parse(m_iWIPID[i]), bResult ? 1 : 0);

            //Wait for WIP_ID.txt deletion
            bool bWIPIDFileNotExisted = false;
            int retryTime = 10;
            for (int retryCount = 0; retryCount < retryTime; retryCount++)
            {
                if (!File.Exists(m_szResultFileName[i]))
                {
                    bWIPIDFileNotExisted = true;
                    break;
                }
                else
                    Thread.Sleep(1000);
            }

            if (!bWIPIDFileNotExisted)
            {
                errMessage = "DELETE SYNC FILE FAIL";
                return false;
            } 

            //Wait for N_RES_INFO.txt, delete it after read it.
            for (int retryCount = 0; retryCount < retryTime; retryCount++)
            {
                if (File.Exists(kRESInfoFileName[i]))
                {
                    //Read information from N_RES_INFO.txt
                    string szTmpBuf = "";
                    GetEqualString(kRESInfoFileName[i], "PERMISSION", ref szTmpBuf);
                    bool m_bPermisson = szTmpBuf.Contains("TRUE");
                    if (!m_bPermisson)
                    {
                        errMessage = "MesUpdate FAIL: " + szTmpBuf;
                        return false;
                    }

                    //Remove N_RES_INFO.txt
                    if (File.GetAttributes(kRESInfoFileName[i]).ToString().IndexOf("ReadOnly") != -1)
                        File.SetAttributes(kRESInfoFileName[i], FileAttributes.Normal);
                    File.Delete(kRESInfoFileName[i]);
                    break;
                }
                else
                    Thread.Sleep(1000);
                if (retryCount == retryTime - 1)
                {
                    errMessage = "RES_INFO.txt is not exist!";
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 获取对应值
        /// </summary>
        /// <param name="szFileName">文件路径</param>
        /// <param name="szKeyName">Key</param>
        /// <param name="szReturnedString">Value</param>
        static void GetEqualString(string szFileName, string szKeyName, ref string szReturnedString)
        {
            try
            {
                if (File.Exists(szFileName))
                {
                    StreamReader sr = File.OpenText(szFileName);
                    string nextLine;
                    bool bIsKeyFound = false;
                    while ((nextLine = sr.ReadLine()) != null)
                    {
                        if (nextLine.Contains(szKeyName))
                        {
                            bIsKeyFound = true;
                            string[] sArray = nextLine.Split('=');
                            szReturnedString = sArray[1];
                        }
                    }
                    sr.Close();
                    if (bIsKeyFound == false) throw new Exception("FIH GetEqualString Fail");
                }
                else
                    throw new Exception("FIH Handle.txt not exist");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
