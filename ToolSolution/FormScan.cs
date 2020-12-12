using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ToolSolution
{
    public partial class FormScan : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow(); //获得本窗体的句柄
        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);//设置此窗体为活动窗体
        //定义变量,句柄类型
        public IntPtr Handle1;

        public FormScan()
        {
            InitializeComponent();
            TopMost = true;
        }

        private void textBoxScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //iNowDut = 0;
                //sText = this.textBoxScan.Text;
                //Thread Test = new Thread(new ThreadStart(MainTest));
                //Test.Start();
                //Hide();
                //Thread.Sleep(100);
            }
        }

        private void FormScan_Load(object sender, EventArgs e)
        {
            Focus();
            textBoxScan.Focus();
        }
    }
}
