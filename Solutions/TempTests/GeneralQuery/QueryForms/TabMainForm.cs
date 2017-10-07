using System;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace WitsWay.TempTests.GeneralQuery.QueryForms
{
    public partial class TabMainForm : DevExpress.XtraBars.TabForm
    {
        public TabMainForm()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GridWithFilterUc frm = new GridWithFilterUc();
            _tabFormControl.Pages[0].ContentContainer.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            _tabFormControl.Pages[0].Visible = true;
            _tabFormControl.Pages[0].ContentContainer.Padding = new Padding(50, 0, 0, 0);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var showInTitle = _tabFormControl.ShowTabsInTitleBar == ShowTabsInTitleBar.True;
            _tabFormControl.ShowTabsInTitleBar = showInTitle ? ShowTabsInTitleBar.False : ShowTabsInTitleBar.True;
            this.OnResize(new EventArgs());
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            var visible = navigationPane1.Visible;
            navigationPane1.Visible = !visible;
            _tabFormControl.Pages[0].ContentContainer.Padding = new Padding(visible ? 0 : 50, 0, 0, 0);
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommandFullscreen();
        }

        private void CommandFullscreen()
        {
            this.SuspendLayout();
            bool isFull = this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.None;
            if (!isFull)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                //this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            else
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                //this.WindowState = FormWindowState.Normal;
            }
            this.OnResize(new EventArgs());
            this.ResumeLayout();
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            _tabFormControl.SelectedPage = tabFormPage1;
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            _tabFormControl.SelectedPage = tabFormPage2;
        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            _tabFormControl.SelectedPage = tabFormPage3;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FrmAboutApp.ShowAbout(this);
        }
    }
}


//1、实现窗体全屏显示

//方法：在全屏方法中进行如下操作

//this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

//this.WindowState = System.Windows.Forms.FormWindowState.Maximized;



//2、实现窗体内某控件的全屏显示

//方法：例如要将richtextbox控件全屏显示，操作如下（this是当前窗体）

//this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
//this.WindowState=FormWindowState.Maximized;
//Rectangle ret = Screen.GetWorkingArea(this);

//this.richTextBox2.ClientSize = new Size(ret.Width, ret.Height);
//this.richTextBox2.Dock = DockStyle.Fill;
//this.richTextBox2.BringToFront();



//3、退出全屏，恢复原貌

//方法：前提是先定义一个类成员变量，用于保存要全屏控件的原始尺寸（Size）,然后在构造函数内将其初始化为控件原始尺寸

//在退出全屏方法内，操作如下

//this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
//this.WindowState = FormWindowState.Normal;
//this.richTextBox2.ClientSize = primarySize;//primarySize即是控件的原始尺寸
//this.richTextBox2.Dock = DockStyle.None;