using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Addins.Config;
using Addins.Port;
using Addins.Adb;
using ProjectOne;

namespace Addins
{
    public class Interface
    {
        readonly ConfigParser m_con = new ConfigParser(Application.StartupPath + "\\Main.ini");
        PortDetect m_port = new PortDetect();
        FormLog formLog = new FormLog();

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
        public string GetProjet()
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

        /// <summary>
        /// 获取ComNum
        /// </summary>
        /// <param name="iDut"></param>
        /// <returns></returns>
        public int GetComPort(int iDut)
        {
            return m_con.GetDutPara(Application.StartupPath + "\\Dut.ini", iDut).iComNum;
        }

        /// <summary>
        /// 获取DevcieID
        /// </summary>
        /// <param name="iDut"></param>
        /// <returns></returns>
        public string GetDeviceID(int iDut)
        {
            return m_con.GetDutPara(Application.StartupPath + "\\Dut.ini", iDut).sDeviceID;
        }
    }
}
