using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using ToolSolution.Addins;
using ADBHelper;
using SerialHelper;

namespace ToolSolution
{
    public partial class Form1 : Form
    {
        readonly FormLog m_formlog = new FormLog();
        readonly Interface m_intface = new Interface();
        readonly FormScan m_formscan = new FormScan();
        readonly Mutex mutex = new Mutex();

        /// <summary>
        /// 工站枚举
        /// </summary>
        public enum Station
        {
            //单板
            ED,
            MBT,
            CAL1,
            CAL2,
            RFT1,
            RFT2,
            WIFIBT,
            BLMMI,
            //整机
            IDLE,
            ALEAK1,
            ALEAK2,
            RUSPCT1,
            MT,
            CamCal,
            DCam,
            CamDis,
            Cam1,
            Cam2,
            PRET,
            ANT1,
            ANT2,
            AEC,
            NFC,
            RUNIN,
            MT2,
            RUSPCT2,
            RAUD,
            OLEDT,
            KEY,
            PDL,
            MMI2,
            CQR,
        }

        public string Version = "V1.0.3";
        public int iNowDut;
        public int TimeCount = 0;
        public string ScanText;

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
        public bool bTest1 = false;
        public bool bTest2 = false;
        public bool bMove = false;
        public bool bReset = false;

        //SCAN
        public string sText;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitUI();

            m_intface.MesInit();

            InitLog();

            if (m_intface.GetStation() == "NFC")
            {
                for (int i = 0; i < m_intface.GetDutNum(); i++)
                {
                    switch (i)
                    {
                        case 0:
                            iNowDut = 0;
                            Thread Test1 = new Thread(new ThreadStart(NFCTest1))
                            {
                                IsBackground = true
                            };
                            Test1.Start();
                            Thread.Sleep(100);
                            break;
                        case 1:
                            iNowDut = 1;
                            Thread Test2 = new Thread(new ThreadStart(NFCTest2))
                            {
                                IsBackground = true
                            };
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
                    Thread Test = new Thread(new ThreadStart(MainTest))
                    {
                        IsBackground = true
                    };
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
            //KillProcess("adb");
            //Thread.Sleep(1000);
            //if (m_intface.GetStation() == "NFC")
            //{
            //    for (int i = 0; i < m_intface.GetDutNum(); i++)
            //    {
            //        switch (i)
            //        {
            //            case 0:
            //                iNowDut = 0;
            //                Thread Test1 = new Thread(new ThreadStart(NFCTest1));
            //                Test1.Abort();
            //                Thread.Sleep(100);
            //                break;
            //            case 1:
            //                iNowDut = 1;
            //                Thread Test2 = new Thread(new ThreadStart(NFCTest2));
            //                Test2.Abort();
            //                Thread.Sleep(100);
            //                break;
            //            default:
            //                throw new Exception("The max Dut number is 2");
            //        }
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < m_intface.GetDutNum(); i++)
            //    {
            //        iNowDut = i;
            //        Thread Test = new Thread(new ThreadStart(MainTest));
            //        Test.Abort();
            //        Thread.Sleep(100);
            //    }
            //}

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

        private void Timer1_Tick(object sender, EventArgs e)
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
        /// Init log路径
        /// </summary>
        private void InitLog()
        {
            try
            {
                Directory.CreateDirectory(m_intface.GetLogPath());
                Directory.Exists(m_intface.GetLogPath());
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

            listV.Columns.Add("Index", (int)(width * 0.07), HorizontalAlignment.Left);
            listV.Columns.Add("TestItem", (int)(width * 0.20), HorizontalAlignment.Left);
            listV.Columns.Add("Value", (int)(width * 0.35), HorizontalAlignment.Left);
            listV.Columns.Add("Up", (int)(width * 0.10), HorizontalAlignment.Left);
            listV.Columns.Add("Low", (int)(width * 0.10), HorizontalAlignment.Left);
            listV.Columns.Add("Result", (int)(width * 0.08), HorizontalAlignment.Left);
            listV.Columns.Add("Time", (int)(width * 0.1), HorizontalAlignment.Left);
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

            ListViewItem listVItem = new ListViewItem
            {
                Text = (listV.Items.Count + 1).ToString()
            };
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
        /// 测试扫描操作
        /// </summary>
        private void TestScan()
        {
            if (m_intface.GetScanEnable() && m_intface.GetDutNum() == 1)
            {
                MethodInvoker methodInvoker = new MethodInvoker(OpenScanForm);
                BeginInvoke(methodInvoker);

                while (true)
                {
                    if (m_formscan.textBoxScan.Text != null && m_formscan.textBoxScan.Text.Replace(" ", "").Length == 12)
                    {
                        ScanText = m_formscan.textBoxScan.Text;
                        break;
                    }
                }

                HideScanForm();
            }
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
            //labels[i].Text = "WAIT";
            //labels[i].BackColor = Color.Gray;
            labelbsns[i].Text = "";
            //KillProcess("adb");
        }

        /// <summary>
        /// 测试主函数模板
        /// </summary>
        public void MainTest()
        {
            int i = iNowDut;
        BEGIN:
            KillProcess("adb");
            bool bResult = true;
            bool bMesCheckRes = false;
            try
            {
                TestScan();
                m_intface.DetectPort(true, m_intface.GetComPort(i));
                TestBegin(i);

                m_intface.GetQlibHandle(i);
                m_intface.ConnectPhone(i);

                DevcieInit(i);//设备初始化
                InsertListView(listViews[i], "InitDevice", "P", "-", "-", true, GetTestTime(i));

                BSN[i] = GetPhoneBSN(i);
                if (BSN[i] == "")
                {
                    InsertListView(listViews[i], "GetPhoneBSN", BSN[i], "-", "-", false, GetTestTime(i));
                    throw new Exception("Get BSN Fail!");
                }
                InsertListView(listViews[i], "GetPhoneBSN", BSN[i], "-", "-", true, GetTestTime(i));

                if (!ReadFlagOperate(i, (int)Station.NFC))
                {
                    InsertListView(listViews[i], "ReadAECFlag", "-", "-", "-", false, GetTestTime(i));
                    throw new Exception("Read AEC Flag Fail!");
                }
                InsertListView(listViews[i], "ReadAECFlag", "P", "-", "-", true, GetTestTime(i));

                bMesCheckRes = m_intface.MesCheck(i, BSN[i], out string errMessage);
                if (!bMesCheckRes)
                {
                    InsertListView(listViews[i], "MesCheck", errMessage, "-", "-", false, GetTestTime(i));
                    m_formlog.InsertListView(i, errMessage);
                    throw new Exception("Mes Check Fail!");
                }
                InsertListView(listViews[i], "MesCheck", "P", "-", "-", true, GetTestTime(i));

                if (!WriteFlagOperate(i, (int)Station.NFC))
                {
                    InsertListView(listViews[i], "WriteNFCFlag", "-", "-", "-", false, GetTestTime(i));
                    throw new Exception("Write NFC Flag Fail!");
                }
                InsertListView(listViews[i], "WriteNFCFlag", "P", "-", "-", true, GetTestTime(i));
                //Final
                bResult = ResultUpdate(i, bMesCheckRes, bResult);
                if (bResult)
                {
                    TestPassEnd(i);
                }
                else
                {
                    TestFailEnd(i);
                }
            }
            catch (Exception ex)
            {
                bResult = false;
                ResultUpdate(i, bMesCheckRes, bResult);
                TestFailEnd(i);
                m_formlog.InsertListView(i, ex.Message);
            }
            finally
            {
                SaveLog(i, bResult);
                ADBReboot(i);
                m_intface.DetectPort(false, m_intface.GetComPort(i));
                TestFinal(i);
            }
            goto BEGIN;
        }

        /// <summary>
        /// NFC1
        /// </summary>
        public void NFCTest1()
        {
            int i = iNowDut;
        BEGIN:
            bool bResult = true;
            bool bMesCheckRes = false;
            bTest1 = false;
            //KillProcess("adb");
            if (mutex.WaitOne())
            {
                bMove = false;
                bReset = false;
                mutex.ReleaseMutex();
            }
            try
            {
                //m_intface.DetectPort(true, m_intface.GetComPort(i));
                DetectDevice(true, i);
                TestBegin(i);

                //DevcieInit(i);//设备初始化
                //InsertListView(listViews[i], "InitDevice", "-", "-", "-", true, GetTestTime(i));

                BSN[i] = GetPhoneBSN(i);
                if (BSN[i] == "")
                {
                    InsertListView(listViews[i], "GetPhoneBSN", BSN[i], "-", "-", false, GetTestTime(i));
                    throw new Exception("Get BSN Fail!");
                }
                InsertListView(listViews[i], "GetPhoneBSN", BSN[i], "-", "-", true, GetTestTime(i));

                if (!ReadFlagOperate(i, (int)Station.NFC))
                {
                    InsertListView(listViews[i], "ReadAECFlag", "-", "-", "-", false, GetTestTime(i));
                    throw new Exception("Read AEC Flag Fail!");
                }
                InsertListView(listViews[i], "ReadAECFlag", "P", "-", "-", true, GetTestTime(i));

                bMesCheckRes = m_intface.MesCheck(i, BSN[i], out string errMessage);
                if (!bMesCheckRes)
                {
                    InsertListView(listViews[i], "MesCheck", errMessage, "-", "-", false, GetTestTime(i));
                    m_formlog.InsertListView(i, errMessage);
                    throw new Exception("Mes Check Fail!");
                }
                InsertListView(listViews[i], "MesCheck", "P", "-", "-", true, GetTestTime(i));

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
                Thread.Sleep(1000);
                if (mutex.WaitOne())
                {
                    int count = 0;
                    while (!bMove)
                    {
                        if (m_intface.GetDutNum() == 1 || (bTest1 && bTest2) || count == 1000)
                        {
                            SerNFCMove(i);
                            bMove = true;
                            break;
                        }
                        Thread.Sleep(10);
                        count++;
                    }
                    mutex.ReleaseMutex();
                }
                bTest1 = false;
                Thread.Sleep(3000);
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

                if (!WriteFlagOperate(i, (int)Station.NFC))
                {
                    InsertListView(listViews[i], "WriteNFCFlag", "-", "-", "-", false, GetTestTime(i));
                    throw new Exception("Write NFC Flag Fail!");
                }
                InsertListView(listViews[i], "WriteNFCFlag", "P", "-", "-", true, GetTestTime(i));

                bTest1 = true;
                Thread.Sleep(1000);
                if (mutex.WaitOne())
                {
                    int count = 0;
                    while (!bReset)
                    {
                        if (m_intface.GetDutNum() == 1 || (bTest1 && bTest2) || count == 1000)
                        {
                            SerNFCReset(i);
                            bReset = true;
                            break;
                        }
                        Thread.Sleep(10);
                        count++;
                    }
                    mutex.ReleaseMutex();
                }
                bTest1 = false;

                //Final
                bResult = ResultUpdate(i, bMesCheckRes, bResult);
                if (bResult)
                {
                    TestPassEnd(i);
                }
                else
                {
                    TestFailEnd(i);
                }
            }
            catch (Exception ex)
            {
                bResult = false;
                ResultUpdate(i, bMesCheckRes, bResult);
                TestFailEnd(i);
                bTest1 = true;
                m_formlog.InsertListView(i, ex.Message);
            }
            finally
            {
                SaveLog(i, bResult);
                //m_intface.DetectPort(false, m_intface.GetComPort(i));
                DetectDevice(false, i);
                TestFinal(i);
            }
            goto BEGIN;
        }

        /// <summary>
        /// NFC2
        /// </summary>
        public void NFCTest2()
        {
            int i = iNowDut;
        BEGIN:
            bool bResult = true;
            bool bMesCheckRes = false;
            bTest2 = false;
            //KillProcess("adb");
            if (mutex.WaitOne())
            {
                bMove = false;
                bReset = false;
                mutex.ReleaseMutex();
            }
            try
            {
                //m_intface.DetectPort(true, m_intface.GetComPort(i));
                DetectDevice(true, i);
                TestBegin(i);

                //DevcieInit(i);//设备初始化
                //InsertListView(listViews[i], "InitDevice", "-", "-", "-", true, GetTestTime(i));
                Thread.Sleep(200);

                BSN[i] = GetPhoneBSN(i);
                if (BSN[i] == "")
                {
                    InsertListView(listViews[i], "GetPhoneBSN", BSN[i], "-", "-", false, GetTestTime(i));
                    throw new Exception("Get BSN Fail!");
                }
                InsertListView(listViews[i], "GetPhoneBSN", BSN[i], "-", "-", true, GetTestTime(i));

                if (!ReadFlagOperate(i, (int)Station.NFC))
                {
                    InsertListView(listViews[i], "ReadAECFlag", "-", "-", "-", false, GetTestTime(i));
                    throw new Exception("Read AEC Flag Fail!");
                }
                InsertListView(listViews[i], "ReadAECFlag", "P", "-", "-", true, GetTestTime(i));

                bMesCheckRes = m_intface.MesCheck(i, BSN[i], out string errMessage);
                if (!bMesCheckRes)
                {
                    InsertListView(listViews[i], "MesCheck", errMessage, "-", "-", false, GetTestTime(i));
                    m_formlog.InsertListView(i, errMessage);
                    throw new Exception("Mes Check Fail!");
                }
                InsertListView(listViews[i], "MesCheck", "P", "-", "-", true, GetTestTime(i));

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
                Thread.Sleep(1000);
                if (mutex.WaitOne())
                {
                    int count = 0;
                    while (!bMove)
                    {
                        if (m_intface.GetDutNum() == 1 || (bTest1 && bTest2) || count == 1000)
                        {
                            SerNFCMove(i);
                            bMove = true;
                            break;
                        }
                        Thread.Sleep(10);
                        count++;
                    }
                    mutex.ReleaseMutex();
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

                if (!WriteFlagOperate(i, (int)Station.NFC))
                {
                    InsertListView(listViews[i], "WriteNFCFlag", "-", "-", "-", false, GetTestTime(i));
                    throw new Exception("Write NFC Flag Fail!");
                }
                InsertListView(listViews[i], "WriteNFCFlag", "P", "-", "-", true, GetTestTime(i));

                bTest2 = true;
                Thread.Sleep(1000);
                if (mutex.WaitOne())
                {
                    int count = 0;
                    while (!bReset)
                    {
                        if (m_intface.GetDutNum() == 1 || (bTest1 && bTest2) || count == 1000)
                        {
                            SerNFCReset(i);
                            bReset = true;
                            break;
                        }
                        Thread.Sleep(10);
                        count++;
                    }
                    mutex.ReleaseMutex();
                }
                bTest2 = false;
                Thread.Sleep(1500);

                //Final
                bResult = ResultUpdate(i, bMesCheckRes, bResult);
                if (bResult)
                {
                    TestPassEnd(i);
                }
                else
                {
                    TestFailEnd(i);
                }
            }
            catch (Exception ex)
            {
                bResult = false;
                ResultUpdate(i, bMesCheckRes, bResult);
                TestFailEnd(i);
                bTest2 = true;
                m_formlog.InsertListView(i, ex.Message);
            }
            finally
            {
                SaveLog(i, bResult);
                //m_intface.DetectPort(false, m_intface.GetComPort(i));
                DetectDevice(false, i);
                TestFinal(i);
            }
            goto BEGIN;
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
                @"\" + (m_intface.GetMesStatus() == 1 ? "Online" : "Offline") +
                @"\" + (bResult == true ? "Pass" : "Fail");

            string strReportFileName = (m_intface.GetMesStatus() == 1 ? "Online" : "Offline") +
                "_Report_" + BSN[iDut] + "_" + DateTime.Now.ToString("G").Replace(":", "-").Replace("/", "-") +
                "_" + (bResult == true ? "Pass" : "Fail") + ".txt";

            string strDebugFileName = (m_intface.GetMesStatus() == 1 ? "Online" : "Offline") +
                "_Debug_" + BSN[iDut] + "_" + DateTime.Now.ToString("G").Replace(":", "-").Replace("/", "-") +
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
                    sb.Append("TEST_ITEM_" + String.Format("{0:00}", (i + 1)) + "=");
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
        /// 测试结果上传
        /// </summary>
        /// <param name="iDut">i</param>
        /// <param name="bCheck">MesCheck测试结果</param>
        /// <param name="bResult">测试结果</param>
        private bool ResultUpdate(int iDut, bool bCheck, bool bResult)
        {
            if (m_intface.GetMesStatus() == 1 && bCheck)
            {
                string strMesLogPath = m_intface.GetResultPathName(iDut);
                if (!File.Exists(strMesLogPath))
                {
                    FileStream fs = new FileStream(strMesLogPath, FileMode.Create, FileAccess.Write);
                    File.SetAttributes(strMesLogPath, FileAttributes.Normal);
                    StreamWriter sw = new StreamWriter(fs);
                    for (int i = 0; i < listViews[iDut].Items.Count; i++)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("TEST_ITEM_" + String.Format("{0:00}", (i + 1)) + "=");
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
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
                if (!m_intface.MesUpdate(iDut, bResult, out string errMessage))
                {
                    InsertListView(listViews[iDut], "MesUpdate", errMessage, "-", "-", false, GetTestTime(iDut));
                    m_formlog.InsertListView(iDut, errMessage);
                    return false;
                }
                else
                {
                    InsertListView(listViews[iDut], "MesUpdate", "P", "-", "-", true, GetTestTime(iDut));
                    return true;
                }
            }
            return true;
        }

        /// <summary>
        /// 打开输入窗体
        /// </summary>
        private void OpenScanForm()
        {
            m_formscan.Show();
        }

        /// <summary>
        /// 关闭输入窗体
        /// </summary>
        private void HideScanForm()
        {
            m_formscan.Hide();
            m_formscan.textBoxScan.Text = null;
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
        public void ADBCommon(int i, string sCmd, out string sResp, bool bOutput = true)
        {
            //m_intface.ADBInterface(i, sCmd, out sResp, bOutput);
            ADB m_adb = new ADB();
            if (m_intface.GetDutNum() > 1)
            {
                sCmd = string.Format("-s {0} {1}", m_intface.GetDeviceID(i), sCmd);
            }
            m_adb.ADBCommend(i, sCmd, out sResp, bOutput);
            m_formlog.InsertListView(i, "adb " + sCmd);
            m_formlog.InsertListView(i, sResp);
        }

        /// <summary>
        /// adb通用接口不打印log
        /// </summary>
        /// <param name="i">i</param>
        /// <param name="sCmd">命令</param>
        /// <param name="sResp">返回</param>
        /// <param name="bOutput"></param>
        public void ADBCommonNoLog(int i, string sCmd, out string sResp, bool bOutput = true)
        {
            //m_intface.ADBInterface(i, sCmd, out sResp, bOutput);
            ADB m_adb = new ADB();
            if (m_intface.GetDutNum() > 1)
            {
                sCmd = string.Format("-s {0} {1}", m_intface.GetDeviceID(i), sCmd);
            }
            m_adb.ADBCommend(i, sCmd, out sResp, bOutput);
        }

        /// <summary>
        /// DeviceInit
        /// </summary>
        /// <param name="i"></param>
        private void DevcieInit(int i)
        {
            ADBCommon(i, "devices", out _);
            ADBCommon(i, "root", out _);
            ADBCommon(i, "remount", out _);
        }

        /// <summary>
        /// 检查设备在位
        /// </summary>
        /// <param name="bApper"></param>
        /// <param name="i"></param>
        private void DetectDevice(bool bApper, int i)
        {
            while (true)
            {
                ADBCommonNoLog(i, "devices", out string sResp);
                if (bApper)
                {
                    if (sResp.Contains(m_intface.GetDeviceID(i))) break;
                }
                else
                {
                    if (!sResp.Contains(m_intface.GetDeviceID(i))) break;
                }
            }
        }

        /// <summary>
        /// 读取BSN
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private string GetPhoneBSN(int i)
        {
            for (int j = 0; j < 50; j++)
            {
                ADBCommon(i, "shell bs_nvops rd 2497 0 12", out string BSN);
                if (BSN != "\r\n" && BSN.Length >= 12)
                {
                    BSN = BSN.Substring((BSN.Length - 14), 12);
                    this.labelbsns[i].Text = BSN;
                    return BSN;
                }
                Thread.Sleep(1000);
            }
            this.labelbsns[i].Text = "XXXXXXXXXXXX";
            return "";
        }

        /// <summary>
        /// 读标志位
        /// </summary>
        /// <param name="i"></param>
        /// <param name="iStation">工位</param>
        /// <returns></returns>
        private bool ReadFlagOperate(int i, int iStation)
        {
            string sCmd = "shell bs_nvops rd 2498 " + (iStation - 1).ToString() + " 1";
            for (int j = 0; j < 5; j++)
            {
                if (m_intface.GetFlagType() == "1" || m_intface.GetFlagType().ToUpper() == "R")
                {
                    ADBCommon(i, sCmd, out string sResp);
                    if (sResp != "\r\n")
                    {
                        int pos = sResp.IndexOf("the data is");
                        if (sResp.Substring(pos + 12, 1).IndexOf("P") != -1)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 写标志位
        /// </summary>
        /// <param name="i"></param>
        /// <param name="iStation">工位</param>
        /// <param name="bResult">测试结果</param>
        /// <returns></returns>
        private bool WriteFlagOperate(int i, int iStation)
        {
            string sCmd1 = "shell bs_nvops wt 2498 " + (iStation).ToString() + " P";
            string sCmd2 = "shell bs_nvops rd 2498 " + (iStation).ToString() + " 1";
            for (int j = 0; j < 5; j++)
            {
                if (m_intface.GetFlagType() == "1" || m_intface.GetFlagType().ToUpper() == "W")
                {
                    ADBCommon(i, sCmd1, out _);
                    ADBCommon(i, sCmd2, out string sResp);
                    if (sResp != "\r\n")
                    {
                        int pos = sResp.IndexOf("the data is");
                        if (sResp.Substring(pos + 12, 1).IndexOf("P") != -1)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// CloseNFC
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private bool CloseNFC(int i)
        {
            for (int j = 0; j < 5; j++)
            {
                ADBCommon(i, "shell \"mi-factory-tool -f /vendor/etc/factory_cmd_config/connectivity.xml -i \\\"NFC Disable\\\" \"", out string sResp);
                if (sResp.Replace("\r\n", "") == "1")
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
        /// DUT重启
        /// </summary>
        /// <param name="i"></param>
        private void ADBReboot(int i)
        {
            ADBCommon(i, "reboot", out _);
        }

        /// <summary>
        /// Serial通用接口
        /// </summary>
        /// <param name="i">i</param>
        /// <param name="bCmd">命令</param>
        /// <param name="sResp">返回</param>
        public void SerialCommon(int i, byte[] bCmd, out string sResp)
        {
            Serial m_serial = new Serial();
            //sResp = m_intface.SerialInterface(bCmd);
            sResp = Encoding.Default.GetString(m_serial.SerialCommend(m_intface.GetSerialPort(), bCmd));
            m_formlog.InsertListView(i, Encoding.Default.GetString(bCmd));
            m_formlog.InsertListView(i, sResp);
        }

        /// <summary>
        /// NFC转向
        /// </summary>
        /// <param name="i">i</param>
        /// <returns></returns>
        private bool SerNFCMove(int i)
        {
            byte[] bCmd = { 0x53, 0x02, 0x00, 0x55 };
            SerialCommon(i, bCmd, out _);
            return true;
        }

        /// <summary>
        /// NFC转向
        /// </summary>
        /// <param name="i">i</param>
        /// <returns></returns>
        private bool SerNFCReset(int i)
        {
            byte[] bCmd = { 0x53, 0x0A, 0x00, 0x00 };
            SerialCommon(i, bCmd, out _);
            return true;
        }

        /// <summary>
        /// NFC D8 Test
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private bool NFCD8Test(int i)
        {
            uint NfcHandle = 0;
            int j;
            for (j = 0; j < 5; j++)
            {
                NfcHandle = m_intface.NFC_Init();
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
                if (m_intface.NFC_Test(NfcHandle) != 1)
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
