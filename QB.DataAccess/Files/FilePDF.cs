using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace QB.DAL.Files
{
    public class FilePDF
    {
        private string filePath = @"C:\Users\ESTSYS\Downloads\test.pdf";
        public void CreateNewFile(string fileName = "TestPDF", string paragraph = "Test Pdf File")
        {
            try
            {
                var rootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
                using (var fs = new FileStream(rootDir + "/Files/" + fileName + ".pdf", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    var doc = new Document();
                    var writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();
                    var prag = new Paragraph(paragraph);
                    doc.Add(prag);
                    doc.Close();
                }
            }
            catch (DocumentException docEx)
            {
                throw docEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetText()
        {
            try
            {
                var sb = new StringBuilder();
                using (var pdfReader = new PdfReader(filePath))
                {
                    for (int pgNumber = 1; pgNumber <= pdfReader.NumberOfPages; pgNumber++)
                    {
                        sb.Append(PdfTextExtractor.GetTextFromPage(pdfReader, pgNumber));
                    }
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<System.Drawing.Image> GetImage()
        {
            var imageList = new List<System.Drawing.Image>();
            try
            {
                var pdfReader = new PdfReader(filePath);
                var contentParser = new PdfReaderContentParser(pdfReader);
                var imageListener = new MyImageRenderListener();
                for (int pageNumber = 1; pageNumber <= pdfReader.NumberOfPages; pageNumber++)
                {
                    contentParser.ProcessContent(pageNumber, imageListener);
                }
                for (int i = 0; i < imageListener.Images.Count; i++)
                {
                    using (MemoryStream ms = new MemoryStream(imageListener.Images[i]))
                    {
                        System.Drawing.Image imag = new Bitmap(ms);
                        imageList.Add(imag);
                    }
                }
                return imageList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class MyImageRenderListener : IRenderListener
    {
        public void RenderText(TextRenderInfo renderInfo) { }
        public void BeginTextBlock() { }
        public void EndTextBlock() { }

        public List<byte[]> Images = new List<byte[]>();
        public List<string> ImageNames = new List<string>();
        public void RenderImage(ImageRenderInfo renderInfo)
        {
            PdfImageObject image = renderInfo.GetImage();
            try
            {
                image = renderInfo.GetImage();
                if (image == null) return;

                ImageNames.Add(string.Format(
                  "Image{0}.{1}", renderInfo.GetRef().Number, image.GetFileType()
                ));
                using (MemoryStream ms = new MemoryStream(image.GetImageAsBytes()))
                {
                    Images.Add(ms.ToArray());
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }
    }
}
