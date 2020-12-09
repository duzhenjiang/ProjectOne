using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Addins.Config;

namespace Addins
{
    public class Interface
    {
        readonly ConfigParser m_con = new ConfigParser(Application.StartupPath + "\\Main.ini");

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
    }
}
