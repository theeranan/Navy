//----------------------------------------------------------------------------
//  Copyright (C) 2004-2015 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;

namespace Navy.Forms
{
    public partial class OCRForm : Form
    {
        private Tesseract _ocr;
        public OCRForm()
        {
            InitializeComponent();
            _ocr = new Tesseract("", "eng", OcrEngineMode.TesseractOnly);
            languageNameLabel.Text = "eng : tesseract + cube";
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            if (openImageFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Bgr drawColor = new Bgr(Color.Blue);
                Gray drawColor = new Gray();
                try
                {
                    Image<Bgr, Byte> image = new Image<Bgr, byte>(openImageFileDialog.FileName);

                    using (Image<Gray, byte> gray = image.Convert<Gray, Byte>())
                    {
                        //image.ga
                        //CvInvoke.GaussianBlur(gray, gray, new Size(5, 5), 1.5);
                        CvInvoke.GaussianBlur(gray, gray, new Size(3, 3), 1.5);
                        
                        gray.ROI = new Rectangle(gray.Width / 3, 0, gray.Width - (gray.Width / 3), gray.Height / 3);

                        _ocr.Recognize(gray);
                        Tesseract.Character[] characters = _ocr.GetCharacters();
                        foreach (Tesseract.Character c in characters)
                        {
                            Tesseract.Character c2 = c;
                            c2.Region.X = c.Region.X + (gray.Width / 3);
                            gray.Draw(c.Region, drawColor, 1);
                        }

                        imageBox1.Image = gray;

                        String text = _ocr.GetText();
                        ocrTextBox.Text = text;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void loadLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openLanguageFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _ocr.Dispose();
                string path = Path.GetDirectoryName(openLanguageFileDialog.FileName);
                string lang = Path.GetFileNameWithoutExtension(openLanguageFileDialog.FileName).Split('.')[0];
                _ocr = new Tesseract(path, lang, OcrEngineMode.Default);
                languageNameLabel.Text = String.Format("{0} : tesseract", lang);
            }
        }
    }
}
