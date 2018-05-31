using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Navy.View;
using Navy.Core;

namespace Navy
{
    public partial class ChangeMemberCodeForm : Form
    {
        #region Fields
        
        private MemberCodeView memberCodeView;
        private MemberCode5View memberCode5View;
        private MemberCodeHistoryView memberCodeHistoryView;
        private string navyid;
        private TableMember selectedMember;

        Parameters.ChangeMemberCode changeParam;
        

        #endregion

        #region Constructors

        public ChangeMemberCodeForm()
        {
            InitializeComponent();
        }

        public ChangeMemberCodeForm(string navyid)
        {
            InitializeComponent();
            this.navyid = navyid;
            InitialForm();
        }

        #endregion

        #region Events

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            bool isSuccess;

            changeParam.navyid = navyid;
            changeParam.membercode = memberCodeView.GetMemberCode();
            changeParam.membercode5 = memberCode5View.GetMembercode5();
            changeParam.link = memberCode5View.GetLink();
            changeParam.date_start = date_start.Value;

            isSuccess = Function.GetRTCRespository().ChangeMemberCode(changeParam);

            if (isSuccess)
            {
                MessageBox.Show("ย้ายสังกัดเรียบร้อย");
                memberCodeHistoryView.RefreshGridView();
            }
            else
            {
                MessageBox.Show("ไม่สามารถบันทึกข้อมูลได้");
            }
        }

        private void ChangeMemberCodeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        #endregion

        #region Methods

        private void InitialForm()
        {
            InitialControl();

            InitialValue();

        }

        private void InitialControl()
        {
            memberCode5View = new MemberCode5View();
            memberCodeView = new MemberCodeView();

            tableLayout.Controls.Add(memberCodeView, 1, 1);
            tableLayout.Controls.Add(memberCode5View, 1, 2);

            memberCodeHistoryView = new MemberCodeHistoryView(navyid);
            memberCodeHistoryView.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(memberCodeHistoryView);
        }

        private void InitialValue()
        {
            selectedMember = new TableMember();
            selectedMember = Function.GetRTCRespository().GetSelectedMember(navyid);

            memberCodeView.SetMemberCode(selectedMember.membercode);
            memberCode5View.SetMemberCode5(selectedMember.membercode5);
            memberCode5View.SetLink(selectedMember.link);

            lblName.Text = selectedMember.name + "  " + selectedMember.sname;

        }

        #endregion


    }
}
