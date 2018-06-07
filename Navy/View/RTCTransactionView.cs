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
    public partial class RTCTransactionView : UserControl
    {
        #region Fields
        private TransactionView transactionView;
        private PunishmentView punishmentView;
        private List<RTCTransaction> rtcTransaction;
        private List<RTCPunishment> rtcPunishment;
        #endregion

        #region Constructors

        public RTCTransactionView()
        {
            InitializeComponent();
        }

        public RTCTransactionView(string navyid)
        {
            InitializeComponent();

            /*transactionView = new TransactionView(navyid);
            transactionView.Dock = DockStyle.Fill;
            splitContainer.Panel1.Controls.Add(transactionView);*/
            rtcTransaction = Function.GetRTCRespository().GetSelectedTransaction(navyid);
            InitialTransaction();
            rtcPunishment = Function.GetRTCRespository().GetSelectedPunishment(navyid);
            InitialPunishment();
            /*punishmentView = new PunishmentView(navyid);
            punishmentView.Dock = DockStyle.Fill;
            splitContainer.Panel2.Controls.Add(punishmentView);*/
        }

        #endregion
        

        private void InitialTransaction()
        {
            for (int i = 1; i <= rtcTransaction.Count; i++)
            {
                tbPanelTrans.RowCount += 1;

                Label lblRefNo = new Label();
                Label lblStatus = new Label();
                Label lblStart = new Label();
                Label lblEnd = new Label();
                Label lblTotal = new Label();
                Label lblFlag = new Label();

                tbPanelTrans.Controls.Add(lblRefNo, 0, i + 1);
                tbPanelTrans.Controls.Add(lblStatus, 1, i + 1);
                tbPanelTrans.Controls.Add(lblStart, 2, i + 1);
                tbPanelTrans.Controls.Add(lblEnd, 3, i + 1);
                tbPanelTrans.Controls.Add(lblTotal, 4, i + 1);
                tbPanelTrans.Controls.Add(lblFlag, 5, i + 1);

                string total = rtcTransaction[i - 1].inyear.ToString();
                total += " ปี ";
                total += rtcTransaction[i - 1].inmonth.ToString();
                total += " เดือน ";
                total += rtcTransaction[i - 1].inday.ToString();
                total += " วัน";

                lblRefNo.Text = rtcTransaction[i - 1].refno;
                lblStatus.Text = rtcTransaction[i - 1].stitle;
                lblStart.Text = rtcTransaction[i - 1].start_date;
                lblEnd.Text = rtcTransaction[i - 1].end_date;
                lblTotal.Text = total;
                lblFlag.Text = rtcTransaction[i - 1].flag + "/" + rtcTransaction[i - 1].num;
            }
        }

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
    }
}
