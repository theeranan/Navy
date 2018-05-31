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

        #endregion

        #region Constructors

        public RTCTransactionView()
        {
            InitializeComponent();
        }

        public RTCTransactionView(string navyid)
        {
            InitializeComponent();

            transactionView = new TransactionView(navyid);
            transactionView.Dock = DockStyle.Fill;
            splitContainer.Panel1.Controls.Add(transactionView);

            punishmentView = new PunishmentView(navyid);
            punishmentView.Dock = DockStyle.Fill;
            splitContainer.Panel2.Controls.Add(punishmentView);

        }

        #endregion


    }
}
