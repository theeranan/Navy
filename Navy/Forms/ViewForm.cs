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
using System.Threading;

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
            if (panelDetail.Controls[0].ToString() != "Navy.View.RTCTransactionView")
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
            panelDetail.Controls.Add(rtcTransactionView);

        }

        #endregion
        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //rcore.ShowReportViewProfile(navyid);
            Graphics g1 = this.CreateGraphics();
            Image MyImage1 = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height, g1);
            Graphics g2 = Graphics.FromImage(MyImage1);
            IntPtr dc1 = g1.GetHdc();
            IntPtr dc2 = g2.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
            g1.ReleaseHdc(dc1);
            g2.ReleaseHdc(dc2);
            //linkStatus_LinkClicked(sender, e);
            
            Graphics g3 = this.CreateGraphics();
            Image MyImage2 = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height, g3);
            Graphics g4 = Graphics.FromImage(MyImage2);
            IntPtr dc3 = g3.GetHdc();
            IntPtr dc4 = g4.GetHdc();
            BitBlt(dc4, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc3, 0, 0, 13369376);
            g3.ReleaseHdc(dc3);
            g4.ReleaseHdc(dc4);
            int width = Math.Max(MyImage1.Width, MyImage2.Width);
            int height = MyImage1.Height + MyImage2.Height;
            
            Bitmap MyImage3 = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(MyImage3);

            g.Clear(Color.Black);
            g.DrawImage(MyImage1, new Point(0, 0));
            g.DrawImage(MyImage2, new Point(0, MyImage1.Height));
            g.Dispose();
            /*if(linkStatus.Text != "[ปกติ]")
            {
                MyImage3.Save(@"\PrintPage.jpg", ImageFormat.Jpeg);
            }
            else*/
            {
                MyImage1.Save(@"\PrintPage.jpg", ImageFormat.Jpeg);
            }
            MyImage1.Dispose();
            MyImage2.Dispose();
            MyImage3.Dispose();
            FileStream fileStream = new FileStream(@"\PrintPage.jpg", FileMode.Open, FileAccess.Read);
            StartPrint(fileStream, "Image");
            fileStream.Close();
            if (File.Exists(@"\PrintPage.jpg"))
            {
                File.Delete(@"\PrintPage.jpg");
            }
        }

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)

        {

            Image image = Image.FromStream(streamToPrint);
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
            Rectangle destRect = new Rectangle(x, y, width, height);
            e.Graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);

        }
        public void StartPrint(Stream streamToPrint, string streamType)

        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);

            PrintDialog printdlg = new PrintDialog();
            PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();
            this.streamToPrint = streamToPrint;
            
            // preview the assigned document or you can create a different previewButton for it
            printPrvDlg.Document = printDoc;
            printPrvDlg.ShowDialog(); // this shows the preview and then show the Printer Dlg below

            //printdlg.Document = printDoc;

            //if (printdlg.ShowDialog() == DialogResult.OK)
            //{
            //    printDoc.Print();
            //}
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
            string filePath    = @"\\192.168.0.1\d\TranscriptionForm\" + rtcDetails.yearin.Replace("/", ".") + '/' + rtcDetails.id13 + ".pdf";
            string filePathJPG = @"\\192.168.0.1\d\TranscriptionForm\" + rtcDetails.yearin.Replace("/", ".") + '/' + rtcDetails.id13 + ".jpg";    
            string filePathNavyID    = @"\\192.168.0.1\d\TranscriptionForm\" + rtcDetails.yearin.Replace("/", ".") + '/' + rtcDetails.navyid + ".pdf";
            string filePathJPGNavyID = @"\\192.168.0.1\d\TranscriptionForm\" + rtcDetails.yearin.Replace("/", ".") + '/' + rtcDetails.navyid + ".jpg";
            if (File.Exists(filePath)) //ถ้่า "เจอ" ชื่อไฟล์นั้น
            {
                OpenIDCardFile(filePath);
            }
            else if (File.Exists(filePathJPG))
            {
                OpenIDCardFile(filePathJPG);
            }
            else if (File.Exists(filePathNavyID))
            {
                OpenIDCardFile(filePathNavyID);
            }
            else if (File.Exists(filePathJPGNavyID))
            {
                OpenIDCardFile(filePathJPGNavyID);
            }
            else //เป็น ผลัดสมทบฝึก ให้หาจาก folder ของ oldyearin
            {
                if (rtcDetails.oldyearin == "" || rtcDetails.oldyearin == null)
                {
                    MessageBox.Show("ไม่พบไฟล์");
                }
                else
                {
                    filePath    = @"\\192.168.0.1\d\TranscriptionForm\" + rtcDetails.oldyearin.Replace("/", ".") + '/' + rtcDetails.id13 + ".pdf";
                    filePathJPG = @"\\192.168.0.1\d\TranscriptionForm\" + rtcDetails.oldyearin.Replace("/", ".") + '/' + rtcDetails.id13 + ".jpg";
                    filePathNavyID    = @"\\192.168.0.1\d\TranscriptionForm\" + rtcDetails.oldyearin.Replace("/", ".") + '/' + rtcDetails.navyid + ".pdf";
                    filePathJPGNavyID = @"\\192.168.0.1\d\TranscriptionForm\" + rtcDetails.oldyearin.Replace("/", ".") + '/' + rtcDetails.navyid + ".jpg";

                    if (File.Exists(filePath))
                    {
                        OpenIDCardFile(filePath);
                    }
                    else if (File.Exists(filePathJPG))
                    {
                        OpenIDCardFile(filePathJPG);
                    }
                    else if (File.Exists(filePathNavyID))
                    {
                        OpenIDCardFile(filePathNavyID);
                    }
                    else if (File.Exists(filePathJPGNavyID))
                    {
                        OpenIDCardFile(filePathJPGNavyID);
                    }
                    else
                    {
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
