using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Addins;

namespace ProjectOne
{
    public partial class Form1 : Form
    {
        Interface m_intface = new Interface();

        public string Version = "V1.0";
        public int iNowDut;

        public Label[] label = new Label[4]; 
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitUI();

            for (int i = 0; i < m_intface.GetDutNum(); i++)
            {
                iNowDut = i;
                Thread Test = new Thread(new ThreadStart(MainTest));
                Test.Start();
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 初始化UI
        /// </summary>
        private void InitUI()
        {
            try 
            {
                this.Text = m_intface.GetProjet() + "_" + m_intface.GetStation() + "_" + Version;
                this.tableLayoutPanel2.ColumnCount = m_intface.GetDutNum();

                label[0] = this.statuslabel1;
                label[1] = this.statuslabel2;
                label[2] = this.statuslabel3;
                label[3] = this.statuslabel4;

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void MainTest()
        {
            try
            {
                int i = iNowDut;
                label[i].Text = "RUN";
                label[i].BackColor = Color.Yellow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            { }
        }
    }
}
