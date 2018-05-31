using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Navy.Core;

namespace Navy.View
{
    public partial class PersonShortDetailView : UserControl
    {
        #region Constructors

        public PersonShortDetailView()
        {
            InitializeComponent();
        }

        public PersonShortDetailView(PersonRequest personShortDetailData)
        {
            InitializeComponent();
            InitialValue(personShortDetailData);
        }

        #endregion

        #region Methods
        public void InitialValue(PersonRequest personShortDetailData)
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
        #endregion
    }
}
