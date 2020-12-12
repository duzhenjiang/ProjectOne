using System;
using System.Windows.Forms;

namespace ToolSolution
{
    public partial class FormLog : Form
    {
        public ListView[] listViews = new ListView[4];
        public string sLogPath;
        public string sProject;
        public string sStation;
        public int iMesStatus;
        public FormLog()
        {
            InitializeComponent();
            listViews[0] = this.listView1;
            listViews[1] = this.listView2;
            listViews[2] = this.listView3;
            listViews[3] = this.listView4;
            for (int i = 0; i<4; i++)
            {
                InitListView(i);
            }
        }

        private void tabControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string sDut = this.tabControl1.SelectedTab.Text;
            string strLogPath = sLogPath +
                @"\" + sDut +
                @"\" + sProject +
                @"\" + sStation +
                @"\" + DateTime.Now.ToString("M") +
                @"\" + (iMesStatus == 1 ? "Online" : "Offline");
            System.Diagnostics.Process.Start("explorer.exe", strLogPath);
        }

        /// <summary>
        /// 初始化ListView
        /// </summary>
        /// <param name="listV"></param>
        private void InitListView(int iDut)
        {
            listViews[iDut].Items.Clear();
            listViews[iDut].View = View.Details;

            int width = listViews[iDut].ClientRectangle.Width;

            listViews[iDut].Columns.Add("Index", 45, HorizontalAlignment.Left);
            listViews[iDut].Columns.Add("Date", 155, HorizontalAlignment.Left);
            listViews[iDut].Columns.Add("Msg", (int)(width - 205), HorizontalAlignment.Left);
        }

        /// <summary>
        /// 增加ListView子项
        /// </summary>
        /// <param name="iDut"></param>
        /// <param name="Msg"></param>
        public void InsertListView(int iDut, string Msg)
        {
            listViews[iDut].BeginUpdate();

            ListViewItem listVItem = new ListViewItem
            {
                Text = (listViews[iDut].Items.Count + 1).ToString()
            };
            listVItem.SubItems.Add(DateTime.Now.ToString("G") + " " + DateTime.Now.ToString("fff"));
            listVItem.SubItems.Add(Msg);

            listViews[iDut].Items.Add(listVItem);
            listViews[iDut].EnsureVisible(listViews[iDut].Items.Count - 1);
            listViews[iDut].EndUpdate();
        }
    }
}
