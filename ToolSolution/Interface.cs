using System;
using System.Windows.Forms;

using ToolSolution.Addins.Config;
using ToolSolution.Addins.Port;
using ToolSolution.Addins.Adb;
using ToolSolution.Addins.NFC;

namespace ToolSolution.Addins
{
    public class Interface
    {
        readonly ConfigParser m_con = new ConfigParser(Application.StartupPath + "\\Config\\Main.ini");
        readonly PortDetect m_port = new PortDetect();
        readonly ADBHelper m_adb = new ADBHelper();
        readonly NFCHelper m_nfc = new NFCHelper();

        /////Port/////

        /// <summary>
        /// 搜索端口
        /// </summary>
        /// <param name="bApper">在位状态</param>
        /// <param name="iDut">i</param>
        /// <returns></returns>
        public bool DetectPort(bool bApper, int iDut)
        {
            m_port.GetPort(bApper, iDut);
            return true;
        }

        /////Config/////

        /// <summary>
        /// 获取DutNum
        /// </summary>
        /// <returns></returns>
        public int GetDutNum()
        {
            return m_con.GetMainPara().iDutNum;
        }

        /// <summary>
        /// 获取Project
        /// </summary>
        /// <returns></returns>
        public string GetProject()
        {
            return m_con.GetMainPara().sProject;
        }

        /// <summary>
        /// 获取Station
        /// </summary>
        /// <returns></returns>
        public string GetStation()
        {
            return m_con.GetMainPara().sStation;
        }

        /// <summary>
        /// 获取log路径
        /// </summary>
        /// <returns></returns>
        public string GetLogPath()
        {
            return m_con.GetMainPara().LogPath;
        }

        /// <summary>
        /// 获取MesStatus
        /// </summary>
        /// <returns></returns>
        public int GetMesStatus()
        {
            return m_con.GetMainPara().MesOn;
        }

        public bool GetScanEnable()
        {
            return m_con.GetMainPara().bScan;
        }

        /// <summary>
        /// 获取ComNum
        /// </summary>
        /// <param name="iDut"></param>
        /// <returns></returns>
        public int GetComPort(int iDut)
        {
            return m_con.GetDutPara(Application.StartupPath + "\\Config\\Dut.ini", iDut).iComNum;
        }

        /// <summary>
        /// 获取DevcieID
        /// </summary>
        /// <param name="iDut"></param>
        /// <returns></returns>
        public string GetDeviceID(int iDut)
        {
            return m_con.GetDutPara(Application.StartupPath + "\\Config\\Dut.ini", iDut).sDeviceID;
        }

        /////ADB/////

        /// <summary>
        /// adb接口
        /// </summary>
        /// <param name="i">i</param>
        /// <param name="sCmd">命令</param>
        /// <param name="sResp">返回</param>
        /// <param name="bOutput"></param>
        public void ADBInterface(int i, string sCmd, out string sResp, bool bOutput = true)
        {
            if (GetDutNum() > 1)
            {
                sCmd = string.Format("-s {0} {1}", GetDeviceID(i), sCmd);
            }
            m_adb.ADBCommend(sCmd, out sResp, bOutput);
        }

        /////NFC/////
        
        /// <summary>
        /// NFC INIT
        /// </summary>
        /// <returns>句柄</returns>
        public uint NFC_Init()
        {
            return m_nfc.BS_dc_init(100, 11500);
        }

        /// <summary>
        /// NFC TEST
        /// </summary>
        /// <param name="Handle">句柄</param>
        /// <returns></returns>
        public int NFC_Test(uint Handle)
        {
            return m_nfc.BS_dc_test(Handle);
        }
    }
}
