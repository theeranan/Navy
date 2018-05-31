using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Navy.Data.DataTemplate;
using Navy.Core;

namespace Navy.View
{
    public partial class PunishmentView : UserControl
    {
        #region Fields
        private List<RTCPunishment> rtcPunishment;
        #endregion

        #region Constructors
        public PunishmentView()
        {
            InitializeComponent();
        }

        public PunishmentView(string navyid)
        {
            InitializeComponent();

            rtcPunishment = Function.GetRTCRespository().GetSelectedPunishment(navyid);

            InitialPunishment();
        }
        #endregion

        #region Methods

        private void InitialPunishment()
        {
            tbPanelPunish.SetColumnSpan(lblPunish, 6);
            for (int i = 1; i <= rtcPunishment.Count; i++)
            {
                tbPanelPunish.RowCount += 1;

                Label lblRefNo = new Label();
                Label lblStatus = new Label();
                Label lblStart = new Label();
                Label lblEnd = new Label();
                Label lblTotal = new Label();
                Label lblFlag = new Label();

                tbPanelPunish.Controls.Add(lblRefNo, 0, i + 1);
                tbPanelPunish.Controls.Add(lblStatus, 1, i + 1);
                tbPanelPunish.Controls.Add(lblStart, 2, i + 1);
                tbPanelPunish.Controls.Add(lblEnd, 3, i + 1);
                tbPanelPunish.Controls.Add(lblTotal, 4, i + 1);
                tbPanelPunish.Controls.Add(lblFlag, 5, i + 1);

                string total = rtcPunishment[i - 1].inyear;
                total += " ปี ";
                total += rtcPunishment[i - 1].inmonth;
                total += " เดือน ";
                total += rtcPunishment[i - 1].inday;
                total += " วัน";

                lblRefNo.Text = rtcPunishment[i - 1].refno;
                lblStatus.Text = rtcPunishment[i - 1].title;
                lblStart.Text = rtcPunishment[i - 1].start_date;
                lblEnd.Text = rtcPunishment[i - 1].end_date;
                lblTotal.Text = total;
                lblFlag.Text = rtcPunishment[i - 1].flag + "/" + rtcPunishment[i - 1].num;

            }
        }

        #endregion
    }

}
