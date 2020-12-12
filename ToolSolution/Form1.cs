using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Addins;
using Addins.Adb;
using Addins.NFC;

namespace ToolSolution
{
    public partial class Form1 : Form
    {
        FormLog m_formlog = new FormLog();
        Interface m_intface = new Interface();

        public string Version = "V1.0.0";
        public int iNowDut;
        public int TimeCount = 0;

        public Label[] labels = new Label[4];
        public Label[] labelpasss = new Label[4];
        public Label[] labelfails = new Label[4];
        public Label[] labelbsns = new Label[4];
        public ListView[] listViews = new ListView[4];
        public string[] BSN = new string[4];
        public int[] iPass = new int[4];
        public int[] iFail = new int[4];
        public DateTime[] dateTimes = new DateTime[4];
        public DateTime[] beginTimes = new DateTime[4];
        public DateTime[] endTimes = new DateTime[4];

        //NFC
        public bool bOnlyOne = false;
        public bool bTest1 = false;
        public bool bTest2 = false;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitUI();

            if (m_intface.GetStation()=="NFC")
            {
                for (int i = 0; i < m_intface.GetDutNum(); i++)
                {
                    switch (i)
                    {
                        case 0:
                            iNowDut = 0;
                            Thread Test1 = new Thread(new ThreadStart(NFCTest1));
                            Test1.Start();
                            Thread.Sleep(100);
                            break;
                        case 1:
                            iNowDut = 1;
                            Thread Test2 = new Thread(new ThreadStart(NFCTest2));
                            Test2.Start();
                            Thread.Sleep(100);
                            break;
                        default:
                            throw new Exception("The max Dut number is 2");
                    }
                }
            }
            else
            {
                for (int i = 0; i < m_intface.GetDutNum(); i++)
                {
                    iNowDut = i;
                    Thread Test = new Thread(new ThreadStart(MainTest));
                    Test.Start();
                    Thread.Sleep(100);
                }
            }
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            m_formlog.sLogPath = m_intface.GetLogPath();
            m_formlog.sProject = m_intface.GetProject();
            m_formlog.sStation = m_intface.GetStation();
            m_formlog.iMesStatus = m_intface.GetMesStatus();
            m_formlog.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_formlog.Close();
            Thread.Sleep(1000);
            if (m_intface.GetStation() == "NFC")
            {
                for (int i = 0; i < m_intface.GetDutNum(); i++)
                {
                    switch (i)
                    {
                        case 0:
                            iNowDut = 0;
                            Thread Test1 = new Thread(new ThreadStart(NFCTest1));
                            Test1.Abort();
                            Thread.Sleep(100);
                            break;
                        case 1:
                            iNowDut = 1;
                            Thread Test2 = new Thread(new ThreadStart(NFCTest2));
                            Test2.Abort();
                            Thread.Sleep(100);
                            break;
                        default:
                            throw new Exception("The max Dut number is 2");
                    }
                }
            }
            else
            {
                for (int i = 0; i < m_intface.GetDutNum(); i++)
                {
                    iNowDut = i;
                    Thread Test = new Thread(new ThreadStart(MainTest));
                    Test.Abort();
                    Thread.Sleep(100);
                }
            }

            Environment.Exit(0);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < m_intface.GetDutNum(); i++)
            {
                int width = listViews[i].ClientRectangle.Width;
                listViews[i].Columns[0].Width = (int)(width * 0.08);
                listViews[i].Columns[1].Width = (int)(width * 0.25);
                listViews[i].Columns[2].Width = (int)(width * 0.15);
                listViews[i].Columns[3].Width = (int)(width * 0.15);
                listViews[i].Columns[4].Width = (int)(width * 0.15);
                listViews[i].Columns[5].Width = (int)(width * 0.12);
                listViews[i].Columns[6].Width = (int)(width * 0.1);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeCount += 1;
            labelTime.Text = TimeCount.ToString();
        }

        /// <summary>
        /// 初始化UI
        /// </summary>
        private void InitUI()
        {
            try 
            {
                this.Text = m_intface.GetProject() + "_" + m_intface.GetStation() + "_" + Version;
                this.tableLayoutPanel2.ColumnCount = m_intface.GetDutNum();
                this.labelMes.Text = (m_intface.GetMesStatus() == 1 ? "ONLINE" : "OFFLINE");
                this.labelMes.BackColor = (m_intface.GetMesStatus() == 1 ? Color.GreenYellow : Color.Red);

                this.timer1.Enabled = true;
                this.timer1.Interval = 1000;
                this.timer1.Start();

                dateTimes[0] = dateTimes[1] = dateTimes[2] = dateTimes[3] = DateTime.Now;
                beginTimes[0] = beginTimes[1] = beginTimes[2] = beginTimes[3] = DateTime.Now;
                endTimes[0] = endTimes[1] = endTimes[2] = endTimes[3] = DateTime.Now;

                labels[0] = this.statuslabel1;
                labels[1] = this.statuslabel2;
                labels[2] = this.statuslabel3;
                labels[3] = this.statuslabel4;

                labelbsns[0] = this.labelBsn1;
                labelbsns[1] = this.labelBsn2;
                labelbsns[2] = this.labelBsn3;
                labelbsns[3] = this.labelBsn4;

                labelpasss[0] = this.labelpass1;
                labelpasss[1] = this.labelpass2;
                labelpasss[2] = this.labelpass3;
                labelpasss[3] = this.labelpass4;
                iPass[0] = iPass[1] = iPass[2] = iPass[3] = 0;

                labelfails[0] = this.labelfail1;
                labelfails[1] = this.labelfail2;
                labelfails[2] = this.labelfail3;
                labelfails[3] = this.labelfail4;
                iFail[0] = iFail[1] = iFail[2] = iFail[3] = 0;

                listViews[0] = this.listView1;
                listViews[1] = this.listView2;
                listViews[2] = this.listView3;
                listViews[3] = this.listView4;

                for (int i = 0; i < m_intface.GetDutNum(); i++)
                {
                    switch (i)
                    {
                        case 0:
                            break;
                        case 1:
                            this.tableLayoutPanel12.Visible = true;
                            break;
                        case 2:
                            this.tableLayoutPanel13.Visible = true;
                            break;
                        case 3:
                            this.tableLayoutPanel14.Visible = true;
                            break;
                        default:
                            throw new Exception("The max Dut number is 4");
                    }
                }

                for (int i = 0; i < m_intface.GetDutNum(); i++)
                {
                    InitListView(listViews[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 初始化ListView
        /// </summary>
        /// <param name="listV"></param>
        private void InitListView(ListView listV)
        {
            listV.Items.Clear();
            listV.View = View.Details;

            int width = listV.ClientRectangle.Width;

            listV.Columns.Add("Index", (int)(width * 0.08), HorizontalAlignment.Left);
            listV.Columns.Add("TestItem", (int)(width * 0.25), HorizontalAlignment.Left);
            listV.Columns.Add("Value", (int)(width * 0.15), HorizontalAlignment.Left);
            listV.Columns.Add("Up", (int)(width * 0.15), HorizontalAlignment.Left);
            listV.Columns.Add("Low", (int)(width * 0.15), HorizontalAlignment.Left);
            listV.Columns.Add("Result", (int)(width * 0.12), HorizontalAlignment.Left);
            listV.Columns.Add("Time", (int)(width * 0.1),HorizontalAlignment.Left);
        }

        /// <summary>
        /// 增加ListView子项
        /// </summary>
        /// <param name="listV"></param>
        /// <param name="sTestItem"></param>
        /// <param name="sValue"></param>
        /// <param name="sUp"></param>
        /// <param name="sLow"></param>
        /// <param name="bResult"></param>
        private void InsertListView(ListView listV, string sTestItem, string sValue, string sUp, string sLow, bool bResult, string sTime)
        {
            listV.BeginUpdate();

            ListViewItem listVItem = new ListViewItem();
            listVItem.Text = (listV.Items.Count + 1).ToString();
            listVItem.SubItems.Add(sTestItem);
            listVItem.SubItems.Add(sValue);
            listVItem.SubItems.Add(sUp);
            listVItem.SubItems.Add(sLow);
            listVItem.SubItems.Add(bResult == true ? "P" : "F");
            listVItem.SubItems.Add(sTime);

            listV.Items.Add(listVItem);
            listV.EnsureVisible(listV.Items.Count - 1);
            listV.EndUpdate();
        }

        /// <summary>
        /// 测试开始控件操作
        /// </summary>
        /// <param name="i"></param>
        private void TestBegin(int i)
        {
            listViews[i].Items.Clear();
            m_formlog.listViews[i].Items.Clear();
            labels[i].Text = "RUN";
            labels[i].BackColor = Color.Yellow;
            beginTimes[i] = dateTimes[i] = DateTime.Now;
        }

        /// <summary>
        /// 测试Pass控件操作
        /// </summary>
        /// <param name="i"></param>
        private void TestPassEnd(int i)
        {
            labels[i].Text = "PASS";
            labels[i].BackColor = Color.Green;
            iPass[i] += 1;
            labelpasss[i].Text = iPass[i].ToString();
            endTimes[i] = DateTime.Now;
            string sTestTime = ((double)(endTimes[i] - beginTimes[i]).TotalMilliseconds / 1000).ToString("f2");
            InsertListView(listViews[i], "TestTime", sTestTime, "-", "-", true, "-");
        }

        /// <summary>
        /// 测试Fail控件操作
        /// </summary>
        /// <param name="i"></param>
        private void TestFailEnd(int i)
        {
            labels[i].Text = "FAIL";
            labels[i].BackColor = Color.Red;
            iFail[i] += 1;
            labelfails[i].Text = iFail[i].ToString();
            endTimes[i] = DateTime.Now;
            string sTestTime = ((double)(endTimes[i] - beginTimes[i]).TotalMilliseconds / 1000).ToString("f2");
            InsertListView(listViews[i], "TestTime", sTestTime, "-", "-", true, "-");
        }

        /// <summary>
        /// 测试结束控件操作
        /// </summary>
        /// <param name="i"></param>
        private void TestFinal(int i)
        {
            labels[i].Text = "WAIT";
            labels[i].BackColor = Color.Gray;
        }

        /// <summary>
        /// 测试主函数模板
        /// </summary>
        public void MainTest()
        {
            int i = iNowDut;
            bool bResult = true;
            try
            {
                KillProcess("adb");
                m_intface.DetectPort(true, m_intface.GetComPort(i));
                TestBegin(i);

                DevcieInit(i);//设备初始化
                InsertListView(listViews[i], "InitDevice", "-", "-", "-", true, GetTestTime(i));

                BSN[i] = GetPhoneBSN(i);
                if (BSN[i] == "")
                {
                    InsertListView(listViews[i], "GetPhoneBSN", BSN[i], "-", "-", false, GetTestTime(i));
                    throw new Exception("Get BSN Fail!");
                }
                InsertListView(listViews[i], "GetPhoneBSN", BSN[i], "-", "-", true, GetTestTime(i));

                //Final
                TestPassEnd(i);
            }
            catch (Exception ex)
            {
                TestFailEnd(i);
                bResult = false;
                m_formlog.InsertListView(i, ex.Message);
            }
            finally
            {
                SaveLog(i, bResult);
                m_intface.DetectPort(false, m_intface.GetComPort(i));
                TestFinal(i);
                iNowDut = i;
                Thread Test = new Thread(new ThreadStart(MainTest));
                Test.Start();
            }
        }

        /// <summary>
        /// NFC1
        /// </summary>
        public void NFCTest1()
        {
            int i = iNowDut;
            bool bResult = true;
            bOnlyOne = false;
            try
            {
                bOnlyOne = false;
                m_intface.DetectPort(true, m_intface.GetComPort(i));
                TestBegin(i);

                DevcieInit(i);//设备初始化
                InsertListView(listViews[i], "InitDevice", "-", "-", "-", true, GetTestTime(i));

                BSN[i] = GetPhoneBSN(i);
                if (BSN[i] == "")
                {
                    InsertListView(listViews[i], "GetPhoneBSN", BSN[i], "-", "-", false, GetTestTime(i));
                    throw new Exception("Get BSN Fail!");
                }
                InsertListView(listViews[i], "GetPhoneBSN", BSN[i], "-", "-", true, GetTestTime(i));

                if (!CloseNFC(i))
                {
                    InsertListView(listViews[i], "CloseNFC", "-", "-", "-", false, GetTestTime(i));
                    throw new Exception("Close NFC Fail!");
                }
                InsertListView(listViews[i], "CloseNFC", "1", "-", "-", true, GetTestTime(i));

                NFCSimulation(i);
                InsertListView(listViews[i], "NFCSimulation", "1", "-", "-", true, GetTestTime(i));
                Thread.Sleep(500);

                if (!NFCD8Test(i))
                {
                    InsertListView(listViews[i], "NFCD8Test", "-", "-", "-", false, GetTestTime(i));
                    throw new Exception("NFC D8 Test Fail!");
                }
                InsertListView(listViews[i], "NFCD8Test", "1", "-", "-", true, GetTestTime(i));

                bTest1 = true;
                while (true)
                {
                    if (m_intface.GetDutNum()==1 || bOnlyOne == true || (bTest1&&bTest2))
                    {
                        break;
                    }
                    Thread.Sleep(10);
                }
                bTest1 = false;

                if (!NFCReset(i))
                {
                    InsertListView(listViews[i], "NFCReset", "-", "-", "-", false, GetTestTime(i));
                    throw new Exception("NFC Reset Fail!");
                }
                InsertListView(listViews[i], "NFCReset", "1", "-", "-", true, GetTestTime(i));

                if (!NFCCardRead(i))
                {
                    InsertListView(listViews[i], "NFCCardRead", "-", "-", "-", false, GetTestTime(i));
                    throw new Exception("NFC Card Read Fail!");
                }
                InsertListView(listViews[i], "NFCCardRead", "1", "-", "-", true, GetTestTime(i));

                bTest1 = true;
                while (true)
                {
                    if (m_intface.GetDutNum() == 1 || bOnlyOne == true || (bTest1 && bTest2))
                    {
                        break;
                    }
                    Thread.Sleep(10);
                }
                bTest1 = false;

                //Final
                TestPassEnd(i);
            }
            catch (Exception ex)
            {
                TestFailEnd(i);
                bResult = false;
                bOnlyOne = true;
                m_formlog.InsertListView(i, ex.Message);
            }
            finally
            {
                SaveLog(i, bResult);
                m_intface.DetectPort(false, m_intface.GetComPort(i));
                TestFinal(i);
                iNowDut = i;
                Thread Test = new Thread(new ThreadStart(NFCTest1));
                Test.Start();
            }
        }

        /// <summary>
        /// NFC2
        /// </summary>
        public void NFCTest2()
        {
            int i = iNowDut;
            bool bResult = true;
            bOnlyOne = false;
            try
            {
                m_intface.DetectPort(true, m_intface.GetComPort(i));
                TestBegin(i);

                DevcieInit(i);//设备初始化
                InsertListView(listViews[i], "InitDevice", "-", "-", "-", true, GetTestTime(i));
                Thread.Sleep(200);

                BSN[i] = GetPhoneBSN(i);
                if (BSN[i] == "")
                {
                    InsertListView(listViews[i], "GetPhoneBSN", BSN[i], "-", "-", false, GetTestTime(i));
                    throw new Exception("Get BSN Fail!");
                }
                InsertListView(listViews[i], "GetPhoneBSN", BSN[i], "-", "-", true, GetTestTime(i));

                if (!CloseNFC(i))
                {
                    InsertListView(listViews[i], "CloseNFC", "-", "-", "-", false, GetTestTime(i));
                    throw new Exception("Close NFC Fail!");
                }
                InsertListView(listViews[i], "CloseNFC", "1", "-", "-", true, GetTestTime(i));

                if (!NFCReset(i))
                {
                    InsertListView(listViews[i], "NFCReset", "-", "-", "-", false, GetTestTime(i));
                    throw new Exception("NFC Reset Fail!");
                }
                InsertListView(listViews[i], "NFCReset", "1", "-", "-", true, GetTestTime(i));

                if (!NFCCardRead(i))
                {
                    InsertListView(listViews[i], "NFCCardRead", "-", "-", "-", false, GetTestTime(i));
                    throw new Exception("NFC Card Read Fail!");
                }
                InsertListView(listViews[i], "NFCCardRead", "1", "-", "-", true, GetTestTime(i));

                bTest2 = true;
                while (true)
                {
                    if (m_intface.GetDutNum() == 1 || bOnlyOne == true || (bTest1 && bTest2))
                    {
                        break;
                    }
                    Thread.Sleep(10);
                }
                bTest2 = false;

                NFCSimulation(i);
                InsertListView(listViews[i], "NFCSimulation", "1", "-", "-", true, GetTestTime(i));
                Thread.Sleep(500);

                if (!NFCD8Test(i))
                {
                    InsertListView(listViews[i], "NFCD8Test", "-", "-", "-", false, GetTestTime(i));
                    throw new Exception("NFC D8 Test Fail!");
                }
                InsertListView(listViews[i], "NFCD8Test", "1", "-", "-", true, GetTestTime(i));

                bTest2 = true;
                while (true)
                {
                    if (m_intface.GetDutNum() == 1 || bOnlyOne == true || (bTest1 && bTest2))
                    {
                        break;
                    }
                    Thread.Sleep(10);
                }
                bTest2 = false;

                //Final
                TestPassEnd(i);
            }
            catch (Exception ex)
            {
                TestFailEnd(i);
                bResult = false;
                bOnlyOne = true;
                m_formlog.InsertListView(i, ex.Message);
            }
            finally
            {
                SaveLog(i, bResult);
                m_intface.DetectPort(false, m_intface.GetComPort(i));
                TestFinal(i);
                iNowDut = i;
                Thread Test = new Thread(new ThreadStart(NFCTest2));
                Test.Start();
            }
        }

        /// <summary>
        /// 保存log
        /// </summary>
        /// <param name="iDut">i</param>
        /// <param name="bResult"></param>
        private void SaveLog(int iDut, bool bResult)
        {
            string strLogPath = m_intface.GetLogPath() + 
                @"\DUT" + (iDut + 1).ToString() + 
                @"\" + m_intface.GetProject() + 
                @"\" + m_intface.GetStation() + 
                @"\" + DateTime.Now.ToString("M") + 
                @"\" + (m_intface.GetMesStatus() == 1? "Online" : "Offline") +
                @"\" + (bResult == true ? "Pass" : "Fail");

            string strReportFileName = (m_intface.GetMesStatus() == 1 ? "Online" : "Offline") +
                "_Report_" + BSN[iDut] + "_" + DateTime.Now.ToString("G").Replace(":","-").Replace("/","-") + 
                "_" + (bResult == true ? "Pass" : "Fail") + ".txt";

            string strDebugFileName = (m_intface.GetMesStatus() == 1 ? "Online" : "Offline") +
                "_Debug_" + BSN[iDut] + "_" + DateTime.Now.ToString("G").Replace(":","-").Replace("/", "-") +
                "_" + (bResult == true ? "Pass" : "Fail") + ".txt";

            string strReportLogPath = strLogPath + @"\Report\" + strReportFileName;
            string strDebugLogPath = strLogPath + @"\Debug\" + strDebugFileName;

            if (!File.Exists(strReportLogPath))
            {
                Directory.CreateDirectory(strLogPath + @"\Report");
                FileStream fs = new FileStream(strReportLogPath, FileMode.Create, FileAccess.Write);
                File.SetAttributes(strReportLogPath, FileAttributes.Normal);
                StreamWriter sw = new StreamWriter(fs);
                for (int i = 0; i < listViews[iDut].Items.Count; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("TEST_ITEM_" + String.Format("{0:00}",(i + 1)) + "=");
                    for (int j = 1; j < listViews[iDut].Items[i].SubItems.Count - 1; j++)
                    {
                        if (j == 1)
                        {
                            sb.Append(listViews[iDut].Items[i].SubItems[j].Text).Append("^").Append(listViews[iDut].Items[i].SubItems[j].Text).Append("^");
                        }
                        else if (j == listViews[iDut].Items[i].SubItems.Count - 2)
                        {
                            sb.Append(listViews[iDut].Items[i].SubItems[j].Text).Append("^").Append("1");
                        }
                        else
                        { 
                            sb.Append(listViews[iDut].Items[i].SubItems[j].Text).Append("^");
                        }
                    }
                    sw.WriteLine(sb);
                }
                StringBuilder sb1 = new StringBuilder();
                sb1.Append("IS_PASSED=" + (bResult == true ? "1" : "0"));
                sw.WriteLine(sb1);
                sw.Flush();
                sw.Close();
                fs.Close();
            }

            if (!File.Exists(strDebugLogPath))
            {
                Directory.CreateDirectory(strLogPath + "\\Debug");
                FileStream fs = new FileStream(strDebugLogPath, FileMode.Create, FileAccess.Write);
                File.SetAttributes(strDebugLogPath, FileAttributes.Normal);
                StreamWriter sw = new StreamWriter(fs);
                for (int i = 0; i < m_formlog.listViews[iDut].Items.Count; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int j = 1; j < m_formlog.listViews[iDut].Items[i].SubItems.Count; j++)
                    {
                        sb.Append(m_formlog.listViews[iDut].Items[i].SubItems[j].Text).Append("  ");
                    }
                    sw.WriteLine(sb);
                }
                sw.Flush();
                sw.Close();
                fs.Close();
            }
        }

        /// <summary>
        /// 关闭进程
        /// </summary>
        /// <param name="processName"></param>
        private void KillProcess(string processName)
        {
            try
            {
                System.Diagnostics.Process[] allProc = System.Diagnostics.Process.GetProcesses();
                foreach (System.Diagnostics.Process thisProc in allProc)
                {
                    if (thisProc.ProcessName.Contains(processName))
                    {
                        thisProc.Kill();
                        thisProc.WaitForExit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 获取测试时间
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private string GetTestTime(int i)
        {
            DateTime dateTime = DateTime.Now;
            TimeSpan timeSpan = dateTime - dateTimes[i];
            dateTimes[i] = dateTime;
            string sTestTime = ((double)timeSpan.TotalMilliseconds / 1000).ToString("f2");
            return sTestTime;
        }

        /// <summary>
        /// adb通用接口
        /// </summary>
        /// <param name="i">i</param>
        /// <param name="sCmd">命令</param>
        /// <param name="sResp">返回</param>
        /// <param name="bOutput"></param>
        private void ADBCommon(int i, string sCmd, out string sResp, bool bOutput = true)
        {
            ADBHelper m_adb = new ADBHelper();
            if (m_intface.GetDutNum() > 1)
            {
                sCmd = string.Format("-s {0} {1}", m_intface.GetDeviceID(i), sCmd);
            }
            m_adb.ADBCommend(sCmd, out sResp, bOutput);
            m_formlog.InsertListView(i, "adb " + sCmd);
            m_formlog.InsertListView(i, sResp);
        }

        /// <summary>
        /// DeviceInit
        /// </summary>
        /// <param name="i"></param>
        private void DevcieInit(int i)
        {
            ADBCommon(i, "devices", out string sResp);
            ADBCommon(i, "root", out sResp);
            ADBCommon(i, "remount", out sResp);
        }

        /// <summary>
        /// 读取BSN
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private string GetPhoneBSN(int i)
        {
            string BSN;
            for (int j=0; j<50; j++)
            {
                ADBCommon(i, "shell bs_nvops rd 2497 0 12", out BSN);
                if (BSN != "\r\n" && BSN.Length >= 12)
                {
                    BSN = BSN.Substring((BSN.Length - 14), 12);
                    this.labelbsns[i].Text = BSN;
                    return BSN;
                }
                Thread.Sleep(100);
            }
            return "";
        }

        /// <summary>
        /// CloseNFC
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private bool CloseNFC(int i)
        {
            for (int j=0; j<5; j++)
            {
                ADBCommon(i, "shell \"mi-factory-tool -f /vendor/etc/factory_cmd_config/connectivity.xml -i \\\"NFC Disable\\\" \"", out string sResp);
                if (sResp.Replace("\r\n","") == "1")
                {
                    return true;
                }
                Thread.Sleep(100);
            }
            return false;
        }

        /// <summary>
        /// NFCSimulation
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private void NFCSimulation(int i)
        {
            ADBCommon(i, "shell \"mi-factory-tool -f /vendor/etc/factory_cmd_config/connectivity.xml -i \\\"NFC Simulation\\\" \"", out _, false);
        }

        /// <summary>
        /// NFC Reset
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private bool NFCReset(int i)
        {
            for (int j = 0; j < 5; j++)
            {
                ADBCommon(i, "shell \"mi-factory-tool -f /vendor/etc/factory_cmd_config/connectivity.xml -i \\\"NFC Reset\\\" \"", out string sResp);
                if (sResp.IndexOf("chr_succeed") != -1)
                {
                    return true;
                }
                Thread.Sleep(100);
            }
            return false;
        }

        /// <summary>
        /// NFC Card Read
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private bool NFCCardRead(int i)
        {
            for (int j = 0; j < 5; j++)
            {
                ADBCommon(i, "shell \"mi-factory-tool -f /vendor/etc/factory_cmd_config/connectivity.xml -i \\\"NFC Card Read\\\" \"", out string sResp);
                if (sResp.IndexOf("cui succeed") != -1)
                {
                    return true;
                }
                Thread.Sleep(100);
            }
            return false;
        }

        /// <summary>
        /// NFC D8 Test
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private bool NFCD8Test(int i)
        {
            NFCHelper m_nfc = new NFCHelper();
            uint NfcHandle;
            int j;
            for (j=0; j < 5; j++)
            {
                NfcHandle = m_nfc.BS_dc_init(100, 11500);
                if (NfcHandle <= 0)
                {
                    m_formlog.InsertListView(i, "D8_Init fail!");
                    Thread.Sleep(100);
                }
                else
                {
                    m_formlog.InsertListView(i, "D8_Init suc!");
                    break;
                }
            }
            if (j == 5)
            {
                m_formlog.InsertListView(i, "NFC_D8_Test fail!");
                return false;
            }

            for (j = 0; j < 10; j++)
            {
                if (m_nfc.BS_dc_test() != 1)
                {
                    m_formlog.InsertListView(i, "D8_Test fail!");
                    Thread.Sleep(1000);
                }
                else
                {
                    m_formlog.InsertListView(i, "D8_Test suc!");
                    return true;
                }
            }
            m_formlog.InsertListView(i, "NFC_D8_Test fail!");
            return false;
        }
    }
}
