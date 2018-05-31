using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navy.MyControls
{
    public partial class PersonCardControl : UserControl
    {
        public PersonCardControl()
        {
            InitializeComponent();
        }

        public PersonCardControl(string imagePath)
        {
            InitializeComponent();
            SetImage(imagePath);
        }

        public string GetImage()
        {
            return this.picboxPersonCard.ImageLocation;
        }

        public void SetImage(string imagePath)
        {
            this.picboxPersonCard.ImageLocation = imagePath;
        }
    }
}
