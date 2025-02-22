﻿using System;
using System.Collections.Generic;
using System.Management;

namespace ToolSolution.Addins.Port
{
    class PortDetect
    {
        /// <summary>
        /// hardware枚举
        /// </summary>
        public enum HardwareEnum
        {
            // 硬件
            Win32_Processor, // CPU 处理器
            Win32_PhysicalMemory, // 物理内存条
            Win32_Keyboard, // 键盘
            Win32_PointingDevice, // 点输入设备，包括鼠标。
            Win32_FloppyDrive, // 软盘驱动器
            Win32_DiskDrive, // 硬盘驱动器
            Win32_CDROMDrive, // 光盘驱动器
            Win32_BaseBoard, // 主板
            Win32_BIOS, // BIOS 芯片
            Win32_ParallelPort, // 并口
            Win32_SerialPort, // 串口
            Win32_SerialPortConfiguration, // 串口配置
            Win32_SoundDevice, // 多媒体设置，一般指声卡。
            Win32_SystemSlot, // 主板插槽 (ISA & PCI & AGP)
            Win32_USBController, // USB 控制器
            Win32_NetworkAdapter, // 网络适配器
            Win32_NetworkAdapterConfiguration, // 网络适配器设置
            Win32_Printer, // 打印机
            Win32_PrinterConfiguration, // 打印机设置
            Win32_PrintJob, // 打印机任务
            Win32_TCPIPPrinterPort, // 打印机端口
            Win32_POTSModem, // MODEM
            Win32_POTSModemToSerialPort, // MODEM 端口
            Win32_DesktopMonitor, // 显示器
            Win32_DisplayConfiguration, // 显卡
            Win32_DisplayControllerConfiguration, // 显卡设置
            Win32_VideoController, // 显卡细节。
            Win32_VideoSettings, // 显卡支持的显示模式。

            // 操作系统
            Win32_TimeZone, // 时区
            Win32_SystemDriver, // 驱动程序
            Win32_DiskPartition, // 磁盘分区
            Win32_LogicalDisk, // 逻辑磁盘
            Win32_LogicalDiskToPartition, // 逻辑磁盘所在分区及始末位置。
            Win32_LogicalMemoryConfiguration, // 逻辑内存配置
            Win32_PageFile, // 系统页文件信息
            Win32_PageFileSetting, // 页文件设置
            Win32_BootConfiguration, // 系统启动配置
            Win32_ComputerSystem, // 计算机信息简要
            Win32_OperatingSystem, // 操作系统信息
            Win32_StartupCommand, // 系统自动启动程序
            Win32_Service, // 系统安装的服务
            Win32_Group, // 系统管理组
            Win32_GroupUser, // 系统组帐号
            Win32_UserAccount, // 用户帐号
            Win32_Process, // 系统进程
            Win32_Thread, // 系统线程
            Win32_Share, // 共享
            Win32_NetworkClient, // 已安装的网络客户端
            Win32_NetworkProtocol, // 已安装的网络协议
            Win32_PnPEntity,//all device
        }

        /// <summary>
        /// 检查端口是否存在
        /// </summary>
        /// <param name="bAppear">检查手机在位或不在位</param>
        /// <param name="iDut">i</param>
        /// <returns></returns>
        public bool GetPort(bool bAppear, int iDut)
        {
            if (bAppear)
            {
                while (true)
                {
                    if (EunmPort(iDut)) return true;
                }
            }
            else
            {
                while (true)
                {
                    if (!EunmPort(iDut)) return true;
                }
            }
        }

        /// <summary>
        /// 比对硬件信息
        /// </summary>
        /// <param name="iDut">i</param>
        /// <returns></returns>
        private bool EunmPort(int iDut)
        {
            string[] devArray = GetHardwareInfo(HardwareEnum.Win32_PnPEntity, "Name");

            if (devArray == null)
            {
                return false;
            }

            string sComPort = "COM" + iDut.ToString();
            foreach (string sName in devArray)
            {
                if (sName.IndexOf("DIAG") != -1 && sName.IndexOf(sComPort) != -1) return true;
            }
            return false;
        }

        /// <summary>
        /// 遍历查找硬件
        /// </summary>
        /// <param name="hardType">硬件名称</param>
        /// <param name="propKey">Key</param>
        /// <returns></returns>
        private static string[] GetHardwareInfo(HardwareEnum hardType, string propKey)
        {
            List<string> strs = new List<string>();
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM " + hardType);
                //var hardInfos = searcher.Get();
                foreach (ManagementObject hardInfo in searcher.Get())
                {
                    if (hardInfo.Properties[propKey].Value != null)
                    {
                        string str = hardInfo.Properties[propKey].Value.ToString();
                        strs.Add(str);
                    }
                }
                return strs.ToArray();
            }
            catch
            {
                //MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
            }
        }
    }
}
