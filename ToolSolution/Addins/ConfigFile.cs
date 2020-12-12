using System;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ToolSolution.Addins.Config
{
	public class ConfigFile
	{
        private readonly string sFilePath;//文件路径

        [DllImport("kernel32.dll")]
		private static extern int GetPrivateProfileInt(
			string lpAppName,
			string lpKeyName,
			int nDefault,
			string lpFilePath
			);

		[DllImport("kernel32.dll")]
		private static extern int GetPrivateProfileString(
			string lpAppName,
			string lpKeyName,
			string lpDefault,
			StringBuilder lpReturnedString,
			int nSize,
			string lpFilePath
			);

		[DllImport("kernel32.dll")]
		private static extern bool WritePrivateProfileString(
			string lpAppName,
			string lpKeyName,
			string lpDefault,
			string lpFilePath
			);

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="FilePath">config文件路径</param>
		public ConfigFile(string FilePath)
		{
			this.sFilePath = FilePath;
			try 
			{
				if (!File.Exists(this.sFilePath))
				{
					throw new Exception(this.sFilePath + "not exist!");
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
        /// 构造函数
        /// </summary>
		public ConfigFile()
		{ }

		/// <summary>
		/// 读int的值
		/// </summary>
		/// <param name="section">节</param>
		/// <param name="name">Key</param>
		/// <param name="def">默认值</param>
		/// <returns></returns>
		public int ReadInt(string section, string name, int def)
		{
			return GetPrivateProfileInt(section, name, def, this.sFilePath);
		}
		
		/// <summary>
		/// 读String的值
		/// </summary>
		/// <param name="section">节</param>
		/// <param name="name">Key</param>
		/// <param name="def">默认值</param>
		/// <returns></returns>
		public string ReadString(string section, string name, string def)
		{
			StringBuilder vRetSb = new StringBuilder(2048);
			GetPrivateProfileString(section, name, def, vRetSb, 2048, this.sFilePath);
			return vRetSb.ToString();
		}

		/// <summary>
		/// 写String的值
		/// </summary>
		/// <param name="section">节</param>
		/// <param name="name">Key</param>
		/// <param name="def">默认值</param>
		/// <returns></returns>
		public bool WriteString(string section, string name, string def)
		{
			return WritePrivateProfileString(section, name, def, this.sFilePath);
		}
	}

	public class MainConfig
	{
		public string sProject;
		public string sStation;
		public int iDutNum;
		public bool bScan;

		public string LogPath;

		public int MesOn;
	}

	public class DutConfig
	{
		public int iComNum;
		public string sDeviceID;
	}

	public class ConfigParser
	{
		private readonly MainConfig m_mainConfig = new MainConfig();
		private readonly DutConfig m_dutConfig = new DutConfig();

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="sMainPath">main.ini文件路径</param>
		/// <param name="sDutPath">dut.ini文件路径</param>
		/// <param name="iDut">i</param>
		public ConfigParser(string sMainPath)
		{
			ConfigFile m_Mainini = new ConfigFile(sMainPath);
			//Main UI
			m_mainConfig.sProject = m_Mainini.ReadString("UI","Project","Jason");
			m_mainConfig.sStation = m_Mainini.ReadString("UI", "Station", "Test");
			m_mainConfig.iDutNum = m_Mainini.ReadInt("UI","DutNum",1);
			m_mainConfig.bScan = m_Mainini.ReadInt("UI", "ScanEnable", 1) == 1;

			//Main Test
			m_mainConfig.LogPath = m_Mainini.ReadString("TEST", "LogPath", "D:\\TestLog");

			//Main Mes
			m_mainConfig.MesOn = m_Mainini.ReadInt("MES", "MesOn", 1);
		}

		/// <summary>
		/// 获取main.ini文件参数
		/// </summary>
		/// <returns></returns>
		public MainConfig GetMainPara()
		{
			return m_mainConfig;
		}

		/// <summary>
		/// 获取Dut.ini文件数据
		/// </summary>
		/// <param name="sDutPath"></param>
		/// <param name="iDut"></param>
		/// <returns></returns>
		public DutConfig GetDutPara(string sDutPath, int iDut)
		{
			ConfigFile m_Dutini = new ConfigFile(sDutPath);
			//Dut
			string sDut = "DUT" + (iDut + 1).ToString();
			m_dutConfig.iComNum = m_Dutini.ReadInt(sDut, "ComNum", 1);
			m_dutConfig.sDeviceID = m_Dutini.ReadString(sDut, "DeviceID", "");

			return m_dutConfig;
		}
	}
}

