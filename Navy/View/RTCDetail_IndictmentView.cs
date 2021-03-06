﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Navy.Core;
using System.Configuration;

namespace Navy.View
{
    public partial class RTCDetail_IndictmentView : UserControl
    {
        RTCDetails _rtcDetails;
        public RTCDetail_IndictmentView()
        {
            InitializeComponent();
        }
        public RTCDetail_IndictmentView(RTCDetails rtcDetails)
        {
            InitializeComponent();
            _rtcDetails = rtcDetails;
            SetDetailsText(rtcDetails);
            SetPhotoMember(rtcDetails);
            SetRTBStyle(txtDetails);
        }


        private void SetDetailsText(RTCDetails rtcDetails)
        {
            txtDetails.Text = txtDetails.Text.Replace("@firstname", rtcDetails.name);
            txtDetails.Text = txtDetails.Text.Replace("@sname", rtcDetails.sname);
            txtDetails.Text = txtDetails.Text.Replace("@oldyearin", rtcDetails.oldyearin);
            txtDetails.Text = txtDetails.Text.Replace("@yearin", rtcDetails.yearin);
            txtDetails.Text = txtDetails.Text.Replace("@sign", rtcDetails.sign);
            txtDetails.Text = txtDetails.Text.Replace("@id8", rtcDetails.id8);
            txtDetails.Text = txtDetails.Text.Replace("@id10", rtcDetails.id);
            txtDetails.Text = txtDetails.Text.Replace("@id13", rtcDetails.id13);
            txtDetails.Text = txtDetails.Text.Replace("@birthdate", rtcDetails.birthdate);
            txtDetails.Text = txtDetails.Text.Replace("@mark", rtcDetails.mark);
            txtDetails.Text = txtDetails.Text.Replace("@blood", rtcDetails.blood);
            txtDetails.Text = txtDetails.Text.Replace("@address", rtcDetails.address_all);
            txtDetails.Text = txtDetails.Text.Replace("@religion", rtcDetails.religion);
            txtDetails.Text = txtDetails.Text.Replace("@height", rtcDetails.height);
            txtDetails.Text = txtDetails.Text.Replace("@occupation", rtcDetails.occname);

            txtDetails.Text = txtDetails.Text.Replace("@telephone", rtcDetails.telephone);
            txtDetails.Text = txtDetails.Text.Replace("@father", rtcDetails.father);
            txtDetails.Text = txtDetails.Text.Replace("@fsname", rtcDetails.fsname);
            txtDetails.Text = txtDetails.Text.Replace("@mother", rtcDetails.mother);
            txtDetails.Text = txtDetails.Text.Replace("@msname", rtcDetails.msname);

            txtDetails.Text = txtDetails.Text.Replace("@ftelephone", rtcDetails.ftelephone);
            txtDetails.Text = txtDetails.Text.Replace("@mtelephone", rtcDetails.mtelephone);
            txtDetails.Text = txtDetails.Text.Replace("@ptelephone", rtcDetails.ptelephone);

            txtDetails.Text = txtDetails.Text.Replace("@educ", rtcDetails.educ);
            txtDetails.Text = txtDetails.Text.Replace("@width", rtcDetails.width);

            txtDetails.Text = txtDetails.Text.Replace("@skill", rtcDetails.skill);
            txtDetails.Text = txtDetails.Text.Replace("@regdate", rtcDetails.regdate);
            txtDetails.Text = txtDetails.Text.Replace("@repdate", rtcDetails.repdate);
            txtDetails.Text = txtDetails.Text.Replace("@unitname", rtcDetails.unitname);
            txtDetails.Text = txtDetails.Text.Replace("@start", rtcDetails.start);
            txtDetails.Text = txtDetails.Text.Replace("@a1", rtcDetails.a1);
            txtDetails.Text = txtDetails.Text.Replace("@a2", rtcDetails.a2);
            txtDetails.Text = txtDetails.Text.Replace("@groupname", rtcDetails.groupname);

            txtDetails.Text = txtDetails.Text.Replace("@namecode5", rtcDetails.namecode5);
            txtDetails.Text = txtDetails.Text.Replace("@link", rtcDetails.link);
            txtDetails.Text = txtDetails.Text.Replace("@estdate", rtcDetails.estdate);
            txtDetails.Text = txtDetails.Text.Replace("@extend", rtcDetails.extend == 0 ? "" : "(เลื่อนกำหนดปลด)");
            txtDetails.Text = txtDetails.Text.Replace("@IS_REQUEST", rtcDetails.IS_REQUEST == "000" ? "" : "ร้องขอ");

        }

        private void SetPhotoMember(RTCDetails rtcDetails)
        {
            string path;
            string yearin = "";
            yearin = rtcDetails.yearin.Replace("/", ".");

            path = ConfigurationManager.AppSettings["PhotoPath"].ToString() + "/" + yearin + "/" + rtcDetails.navyid + ".jpg";
            photoMember.ImageLocation = path;

        }

        private void SetRTBStyle(RichTextBox rtb)
        {
            string[] str = rtb.Text.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            rtb.Rtf = "";
            for (int i = 0; i < str.Length; i++)
            {
                rtb.DeselectAll();
                if (str[i][0].ToString() == "#")
                {
                    rtb.SelectionFont = new Font(rtb.SelectionFont, FontStyle.Regular);
                    rtb.SelectionColor = Color.DarkBlue;
                    str[i] = str[i].ToString().Remove(0, 1);
                }
                else
                {
                    rtb.SelectionFont = new Font(rtb.SelectionFont, FontStyle.Regular);
                    rtb.SelectionColor = Color.Black;
                }

                rtb.AppendText(str[i]);
            }
        }

        private void linkLabel1_MouseLeave(object sender, EventArgs e)
        {
            linkLabel1.Text = "NAVYID";
        }

        private void linkLabel1_MouseHover(object sender, EventArgs e)
        {
            linkLabel1.Text = _rtcDetails.navyid;
        }
    }
}
