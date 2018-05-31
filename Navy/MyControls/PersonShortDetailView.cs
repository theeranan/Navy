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

namespace Navy.MyControls
{
    public partial class PersonShortDetailView : UserControl
    {
        #region Constructors

        public PersonShortDetailView()
        {
            InitializeComponent();
        }

        public PersonShortDetailView(Navy.Core.PersonRequest personShortDetailData)
        {
            InitializeComponent();
            InitialValue(personShortDetailData);
        }

        #endregion

        #region Methods
        public void InitialValue(Navy.Core.PersonRequest personShortDetailData)
        {
            labelname.Text = personShortDetailData.person.name;
            labelsname.Text = personShortDetailData.person.sname;
            labelid8.Text = personShortDetailData.person.id8;

            labelstatuscode.Text = String.IsNullOrWhiteSpace(Function.GetTextOrNull(personShortDetailData.person.statuscode, "")) ? "" : "(" + personShortDetailData.person.statuscode + ") " + personShortDetailData.person.stitle;
            labelpostname.Text = Function.GetTextOrNull(personShortDetailData.person.postname,"-");
            labelunit4.Text = Function.GetTextOrNull(personShortDetailData.person.unit4,"-");
            labelitem.Text = Function.GetTextOrNull(personShortDetailData.person.item,"-");

            labelpercent.Text = Function.GetTextOrNull(personShortDetailData.person.percent,"-");
            labeleducode.Text = Function.GetTextOrNull(personShortDetailData.person.educname,"-");

            labelskillcode.Text = Function.GetTextOrNull(personShortDetailData.person.skill,"-");
            labelcompany.Text = Function.GetTextOrNull(personShortDetailData.person.company,"-");;
            labelbatt.Text = Function.GetTextOrNull(personShortDetailData.person.batt,"-");;
            labelplatoon.Text = Function.GetTextOrNull(personShortDetailData.person.platoon,"-");;
            labelpseq.Text = Function.GetTextOrNull(personShortDetailData.person.pseq,"-");;
            labelyearin.Text = Function.GetTextOrNull(personShortDetailData.person.yearin, "-"); ;
            labeloldyearin.Text = Function.GetTextOrNull(personShortDetailData.person.oldyearin, "-");
            labelunit3.Text = Function.GetTextOrNull(personShortDetailData.person.unitname, "-"); ;
            labelunit1.Text = Function.GetTextOrNull(personShortDetailData.person.unit1,"-");
            labelunit2.Text = Function.GetTextOrNull(personShortDetailData.person.unit2, "-");
        }

        public void HideDataForLiteMode()
        {
            label17.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            labelunit3.Visible = false;
            labelpostname.Visible = false;
            labelunit4.Visible = false;
            labelitem.Visible = false;

            label18.Location = new Point(label18.Location.X, label17.Location.Y);
            labelunit1.Location = new Point(labelunit1.Location.X, label17.Location.Y);
            label19.Location = new Point(label19.Location.X, label4.Location.Y);
            labelunit2.Location = new Point(labelunit2.Location.X, label4.Location.Y);
        }
        #endregion
    }
}
