using System;
using System.Net;
using System.Threading;

namespace WitsWay.TempTests.GeneralQuery
{
    public partial class BackstageViewForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public BackstageViewForm()
        {
            InitializeComponent();
        }

        private void XtraForm2_Load(object sender, EventArgs e)
        {
            //var response = GetResponse();
            //var stream = response.GetResponseStream();
            //if (stream != null)
            //{
            //    var obj = Image.FromStream(stream);
            //    var edit = this.pictureEdit1;
            //    edit.Image = obj;
            //}
        }
        
        private WebResponse GetResponse()
        {
            
            var imagePath = "http://localhost:1409/bbimagehandler.ashx?File=Winter.jpg&width=500";
            var request = System.Net.WebRequest.Create(imagePath);
            var task = request.GetResponse();//.GetResponse().GetResponseStream();
            Thread.Sleep(3000);
            return task;
        }

        private void backstageViewButtonItem3_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {

        }
    }
}