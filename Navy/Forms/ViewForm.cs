using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Navy.Data;
using Navy.Core;
using Navy.Data.DataTemplate;
using System.Data.OleDb;
using System.IO;
using System.Globalization;
using Navy.View;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Drawing.Printing;

namespace Navy.Forms
{
    public partial class ViewForm : Form
    {
        ReportCoreLibrary rcore;
        private RTCDetailView rtcDetailView;
        private RTCTransactionView rtcTransactionView;

        private RTCDetails rtcDetails;
        private SearchPersonForm SearchPersonForm;
        private List<RTCTransaction> _rtcTransaction;
        private List<RTCPunishment> _rtcPunishment;
        private string navyid;
        private System.IO.Stream streamToPrint;
        string streamType;
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool BitBlt
(
    IntPtr hdcDest, // handle to destination DC
    int nXDest, // x-coord of destination upper-left corner
    int nYDest, // y-coord of destination upper-left corner
    int nWidth, // width of destination rectangle
    int nHeight, // height of destination rectangle
    IntPtr hdcSrc, // handle to source DC
    int nXSrc, // x-coordinate of source upper-left corner
    int nYSrc, // y-coordinate of source upper-left corner
    System.Int32 dwRop // raster operation code
);
        public ViewForm()
        {
            InitializeComponent();
            rcore = new ReportCoreLibrary();
            InitialForm();
        }

        public ViewForm(string navyid)
        {
            InitializeComponent();
      
            rcore = new ReportCoreLibrary();
            this.navyid = navyid;
            rtcDetails = Function.GetRTCRespository().GetSelectedDetail(navyid);

            InitialForm();
        }
        public ViewForm(RTCDetails rtcDetails, List<RTCTransaction> rtcTransaction, List<RTCPunishment> rtcPunishment)
        {
            InitializeComponent();

            this.rtcDetails = rtcDetails;
            this._rtcTransaction = rtcTransaction;
            this._rtcPunishment = rtcPunishment;

            InitialForm();
        }

        private void linkStatus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            //RTCMember.View.RTCDetailView
            if (panelDetail.Controls[0].ToString() == "Navy.View.RTCDetailView")
            {
                panelDetail.Controls.Clear();
                panelDetail.Controls.Add(rtcTransactionView);
            }
            else
            {
                panelDetail.Controls.Clear();
                panelDetail.Controls.Add(rtcDetailView);
            }
        }

        private void MemberDetailForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

       
        #region Methods

        public void InitialForm()
        {
            txtName.Text = "พลทหาร " + rtcDetails.name + "  " + rtcDetails.sname;
            linkStatus.Text = "[" + rtcDetails.stitle + "]";

            //Personnal Detail View
            rtcDetailView = new RTCDetailView(rtcDetails);
            rtcDetailView.Dock = DockStyle.Fill;

            //Transaction View
            rtcTransactionView = new RTCTransactionView(navyid);
            rtcTransactionView.Dock = DockStyle.Fill;


            panelDetail.Controls.Add(rtcDetailView);

        }

        #endregion

        private void linkStatus_LinkClicked(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //rcore.ShowReportViewProfile(navyid);
            Graphics g1 = this.CreateGraphics();

            Image MyImage = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height, g1);

            Graphics g2 = Graphics.FromImage(MyImage);

            IntPtr dc1 = g1.GetHdc();

            IntPtr dc2 = g2.GetHdc();

            BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);

            g1.ReleaseHdc(dc1);

            g2.ReleaseHdc(dc2);

            MyImage.Save(@"\PrintPage.jpg", ImageFormat.Jpeg);

            FileStream fileStream = new FileStream(@"\PrintPage.jpg", FileMode.Open, FileAccess.Read);

            StartPrint(fileStream, "Image");

            fileStream.Close();

            if (System.IO.File.Exists(@"\PrintPage.jpg"))

            {

                System.IO.File.Delete(@"\PrintPage.jpg");

            }
        }

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)

        {

            System.Drawing.Image image = Image.FromStream(streamToPrint);
            int x = e.MarginBounds.X;
            int y = e.MarginBounds.Y;
            int width = image.Width;
            int height = image.Height;
            if ((width / e.MarginBounds.Width) > (height / e.MarginBounds.Height))
            {
                width = e.MarginBounds.Width;
                height = image.Height * e.MarginBounds.Width / image.Width;
            }
            else
            {
                height = e.MarginBounds.Height;
                width = image.Width * e.MarginBounds.Height / image.Height;
            }
            System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(x, y, width, height);
            e.Graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, System.Drawing.GraphicsUnit.Pixel);
        }
        public void StartPrint(Stream streamToPrint, string streamType)

        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            PrintDialog PrintDialog1 = new PrintDialog();
            this.streamToPrint = streamToPrint;

    this.streamType = streamType;
            PrintDialog1.AllowSomePages = true;

            PrintDialog1.ShowHelp = true;

            PrintDialog1.Document = printDoc;

            DialogResult result = PrintDialog1.ShowDialog();

            if (result == DialogResult.OK)

            {

                printDoc.Print();

                //docToPrint.Print();

            }
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string yearin = rtcDetails.yearin.Replace("/", ".");

            string path = ConfigurationManager.AppSettings["PhotoPath"].ToString() + "/" + yearin + "/" + rtcDetails.navyid + ".jpg";
     
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath)){
            
                        try{
                            File.Copy(path, fbd.SelectedPath + @"\\" + rtcDetails.navyid + "." + rtcDetails.name + rtcDetails.PLATOON + string.Format("{0:00}", rtcDetails.PSEQ) + ".jpg", true);
                        }catch( Exception ex){
                
                             throw(ex);
                        }
                        MessageBox.Show("คัดลอกสำเร็จ");

            }
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            
        }

        //Load ID_card
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string filePath = @"\\192.168.0.1\d\TranscriptionForm\" + rtcDetails.yearin.Replace("/", ".") + '/' + rtcDetails.id13 + ".pdf";

            if (File.Exists(filePath))
            {
                OpenIDCardFile(filePath);
            }
            else
            {                
                if (rtcDetails.oldyearin == "" || rtcDetails.oldyearin == null)
                {                
                    MessageBox.Show("ไม่พบไฟล์");
                }
                else
                {
                    filePath = @"\\192.168.0.1\d\TranscriptionForm\" + rtcDetails.oldyearin.Replace("/", ".") + '/' + rtcDetails.id13 + ".pdf";
                    if (File.Exists(filePath))
                    {
                        OpenIDCardFile(filePath);
                    }
                    else {
                        MessageBox.Show("ไม่พบไฟล์");
                    }
                }

            }
        }

        private void OpenIDCardFile(string filePath) {
            Process p = new Process();
            ProcessStartInfo s = new ProcessStartInfo(filePath);
            p.StartInfo = s;
            p.Start();
        }
    }
}
