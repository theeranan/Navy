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
    public partial class TransactionView : UserControl
    {
        #region Fields

        private List<RTCTransaction> rtcTransaction;

        #endregion

        #region Constructors

        public TransactionView()
        {
            InitializeComponent();
        }

        public TransactionView(string navyid)
        {
            InitializeComponent();

            rtcTransaction = Function.GetRTCRespository().GetSelectedTransaction(navyid);

            InitialTransaction();
        }

        public TransactionView(List<RTCTransaction> rtcTransaction)
        {
            InitializeComponent();

            this.rtcTransaction = rtcTransaction;

            InitialTransaction();
        }

        #endregion

        #region Methods

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

        #endregion
    }
}
