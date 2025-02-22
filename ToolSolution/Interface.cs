﻿using System.Windows.Forms;
using System.Text;

using ToolSolution.Addins.Config;
using ToolSolution.Addins.Port;

using NFCHelper;
using MesHelper;
using ADBHelper;
using QLIBHelper;
using SerialHelper;

namespace ToolSolution.Addins
{
    public class Interface
    {
        readonly ConfigParser m_con = new ConfigParser(Application.StartupPath + "\\Main.ini");
        readonly PortDetect m_port = new PortDetect();
        readonly NFC m_nfc = new NFC();
        readonly Mes m_mes = new Mes();
        readonly QLIB m_qlib = new QLIB();
        readonly Serial m_serial = new Serial();

        #region Port
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
        #endregion

        #region QLIB

        /// <summary>
        /// 连接手机
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool ConnectPhone(int i)
        {
            return m_qlib.IsPhoneConnected(i);
        }
        #endregion

        #region Config
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
        /// 获取Flag
        /// </summary>
        /// <returns></returns>
        public string GetFlagType()
        {
            return m_con.GetMainPara().sFlagType;
        }

        /// <summary>
        /// 获取设备端口
        /// </summary>
        /// <returns></returns>
        public string GetSerialPort()
        {
            return m_con.GetMainPara().SerialPort;
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
        /// 获取Scan信息
        /// </summary>
        /// <returns></returns>
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
        #endregion

        #region MES
        /// <summary>
        /// MesInit
        /// </summary>
        public void MesInit()
        {
            if (GetMesStatus() == 1)
            {
                m_mes.MesInit();
            }
        }

        /// <summary>
        /// MesCheck
        /// </summary>
        /// <param name="i">i</param>
        /// <param name="sParams"></param>
        /// <param name="errMessage">错误信息</param>
        /// <returns></returns>
        public bool MesCheck(int i, string sParams, out string errMessage)
        {
            if (GetMesStatus() == 1)
            {
                return m_mes.MesCheck(i, sParams, out errMessage);
            }
            errMessage = "";
            return true;
        }

        public bool MesUpdate(int i, bool bResult, out string errMessage)
        {
            return m_mes.MesUpdate(i, bResult, out errMessage);
        }

        /// <summary>
        /// 获取测试结果文件路径
        /// </summary>
        /// <returns></returns>
        public string GetResultPathName(int i)
        {
            return m_mes.m_szResultFileName[i];
        }
        #endregion

        #region ADB
        /// <summary>
        /// adb接口
        /// </summary>
        /// <param name="i">i</param>
        /// <param name="sCmd">命令</param>
        /// <param name="sResp">返回</param>
        /// <param name="bOutput"></param>
        public void ADBInterface(int i, string sCmd, out string sResp, bool bOutput = true)
        {
            ADB m_adb = new ADB();
            if (GetDutNum() > 1)
            {
                sCmd = string.Format("-s {0} {1}", GetDeviceID(i), sCmd);
            }
            m_adb.ADBCommend(i, sCmd, out sResp, bOutput);
        }
        #endregion

        #region NFC
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
        #endregion

        #region Serial
        /// <summary>
        /// 串口测试函数
        /// </summary>
        /// <param name="bCmd">命令</param>
        /// <returns></returns>
        public string SerialInterface(byte[] bCmd)
        {
            return Encoding.Default.GetString(m_serial.SerialCommend(GetSerialPort(), bCmd));
        }
        #endregion
    }
}