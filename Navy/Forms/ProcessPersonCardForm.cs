using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Navy.Core;
using Navy.Data;
using Navy.Data.DataTemplate;
using System.IO;

namespace Navy.Forms
{
    public partial class ProcessPersonCardForm : Form
    {
        PersonDataSet.PersonNivyDataTable personNivyData;
        PersonDataSet.PersonNivyRow personNivyRow;
        DataCoreLibrary dcoreSearch;
        DataCoreLibrary dcoreSave;
        InputSearchPersonNivy tempInput;
        int count = -1;
        int itemsPerPage = Constants.countItemResult;
        int page = 1;
        int totalPage = -1;
        List<string> pathImgs = new List<string>();
        DataTable tableImages = new DataTable();

        int countImageInFolder = -1;
        int countItemPass = -1;//Found + NotFound
        int countItemDataFound = -1;
        int countItemDataNotFound = -1;
        int pageImage = -1;

        public ProcessPersonCardForm()
        {
            InitializeComponent();
            searchPersonNivyInputControl1.SearchButtonClick += new EventHandler(SearchPersonNivy_ButtonSubmitClick);
            DataControls.LoadComboBoxData(cbbArmtown, DataDefinition.GetArmtownTab(), "ARMNAME", "ARMID");
            
            dcoreSearch = new DataCoreLibrary(System.Configuration.ConfigurationManager.ConnectionStrings["midb"].ConnectionString);
            dcoreSave = new DataCoreLibrary();

            tableImages.Columns.Add("no", typeof(int));
            tableImages.Columns.Add("name", typeof(string));
            tableImages.Columns.Add("size", typeof(string));
        }

        //private void loadImageButton_Click(object sender, EventArgs e)
        //{
        //    if (openImageFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        Bgr drawColor = new Bgr(Color.Blue);
        //        try
        //        {
        //            Image<Bgr, Byte> image = new Image<Bgr, byte>(openImageFileDialog.FileName);

        //            using (Image<Gray, byte> gray = image.Convert<Gray, Byte>())
        //            {
        //                _ocr.Recognize(gray);
        //                Tesseract.Character[] characters = _ocr.GetCharacters();
        //                foreach (Tesseract.Character c in characters)
        //                {
        //                    image.Draw(c.Region, drawColor, 1);
        //                }

        //                imageBox1.Image = image;

        //                String text = _ocr.GetText();
        //                ocrTextBox.Text = text;
        //            }
        //        }
        //        catch (Exception exception)
        //        {
        //            MessageBox.Show(exception.Message);
        //        }
        //    }
        //}

        //private void loadLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (openLanguageFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        _ocr.Dispose();
        //        string path = Path.GetDirectoryName(openLanguageFileDialog.FileName);
        //        string lang = Path.GetFileNameWithoutExtension(openLanguageFileDialog.FileName).Split('.')[0];
        //        _ocr = new Tesseract(path, lang, OcrEngineMode.Default);
        //        languageNameLabel.Text = String.Format("{0} : tesseract", lang);
        //    }
        //}

        private void GetAllImagePathInFolder(string path)
        {
            if (path != "")
            {
                pathImgs = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly).ToList<string>();
                countImageInFolder = pathImgs.Count;
                labelCountImageFiles.Text = countImageInFolder.ToString();
                tableImages.Clear();

                if (pathImgs.Count > 0)
                {                    
                    foreach (string p in pathImgs)
                    {
                        string fileName = Path.GetFileName(p);
                        tableImages.Rows.Add(tableImages.Rows.Count + 1, fileName, (new FileInfo(p).Length).ToString("d")+" bytes");
                    }
                    LoadPersonCard(0);        
                }
                else
                {
                    personCardControl1.SetImage("");
                }
                gvFileList.DataSource = tableImages;
                gvFileList.Columns["no"].Width = 35;
                gvFileList.Columns["name"].Width = 150;

                pageImage = 1;
                countItemPass = 0;//Found + NotFound
                countItemDataFound = 0;
                countItemDataNotFound = 0;                               
            }
            else
            {
                personCardControl1.SetImage("");
            }
            EnableButtonPagingImage();
        }
        
        private void LoadPersonCard(int index)
        {
            personCardControl1.SetImage(pathImgs[index]);
        }

        private void Search()
        {
            try
            {
                tempInput = searchPersonNivyInputControl1.GetInput();
                personNivyData = dcoreSearch.GetSearchPersonNivyTemplate(tempInput, itemsPerPage, page, out count);
                gvResult.DataSource = personNivyData;                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gvFileList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadPersonCard(e.RowIndex);
            InputSearchPersonNivy input = new InputSearchPersonNivy();
            input.id13 = tableImages.Rows[e.RowIndex]["name"].ToString().Split('.')[0];
            searchPersonNivyInputControl1.SetInput(input);
        }

        private void gvResult_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //btnSubmit.Enabled = gvResult.SelectedRows.Count > 0 ? true : false;
        }

        private void gvResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSubmit_Click(sender, e);
                e.Handled = true;
            }
        }

        private void SearchPersonNivy_ButtonSubmitClick(object sender, EventArgs e)
        {
            Search();
            gvResult.Focus();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (gvResult.SelectedRows.Count > 0)
            {
                personNivyRow = personNivyData.FindByID13(gvResult.SelectedRows[0].Cells["ID13"].Value.ToString());
                try
                {
                    bool success = dcoreSave.InsertPersonNivy(personNivyRow);
                    if(success)
                    {
                        MessageBox.Show("บันทึกเรียบร้อย");
                    }
                    else
                    {
                        MessageBox.Show("พบข้อผิดพลาดในการบันทึก");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("กรุณาเลือกข้อมูลก่อนที่จะบันทึก");
            }
            searchPersonNivyInputControl1.SetFocusID13();
        }

        private void cbbArmtown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = Function.SelectProvinceDirectory(DataControls.GetSelectedValueComboBoxToString(cbbArmtown), Constants.ImagePath.PersonCardPreValidate);
            GetAllImagePathInFolder(path);
        }

        private void btnImgPre_Click(object sender, EventArgs e)
        {
            pageImage--;
            LoadPersonCard(pageImage - 1);
            EnableButtonPagingImage();
        }

        private void btnImgNext_Click(object sender, EventArgs e)
        {
            pageImage++;
            LoadPersonCard(pageImage - 1);
            EnableButtonPagingImage();
        }

        private void EnableButtonPagingImage()
        {
            if (pageImage < pathImgs.Count)
            {
                btnImgNext.Enabled = true;
                btnImgPre.Enabled = true;
            }
            else if (pageImage == pathImgs.Count)
            {
                btnImgNext.Enabled = false;
                btnImgPre.Enabled = true;
            }

            if (pageImage <= 1)
            {
                btnImgPre.Enabled = false;
            }

            //btnSubmit.Enabled = pathImgs.Count > 0 ? true : false;
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cbbArmtown_SelectedIndexChanged(sender, e);
        }
    }
}
