using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using QB.DataAccess.Files;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace QB.WindowApplication
{
    public class MyPDF
    {
        private string filePath = @"C:\Users\ESTSYS\Downloads\test.pdf";


        private PdfPCell getCell(string text, int alignment, int rowIndex)
        {
            Font font = FontFactory.GetFont("Verdana", 12, new BaseColor(System.Drawing.Color.Black));
            var cell = new PdfPCell(new Phrase(text,font));
            cell.Padding = 6;
            cell.Colspan = 1;
            cell.BackgroundColor = ((rowIndex % 2) == 0) ? new BaseColor(226, 226, 226) : new BaseColor(60, 60, 60);
            cell.HorizontalAlignment = alignment;
            cell.Border = Rectangle.NO_BORDER;
            return cell;
        }
        private PdfPCell getCells(string text, int alignment)
        {
            Font font = FontFactory.GetFont("Verdana", 12, new BaseColor(System.Drawing.Color.Black));
            var cell = new PdfPCell(new Phrase(text, font));
            cell.Padding = 10;
            cell.Colspan = 1;
            cell.HorizontalAlignment = alignment;
            cell.Border = Rectangle.NO_BORDER;
            return cell;
        }
        public void CreatePDF(List<string> list,string imagePath)
        {
            var doc = new Document(PageSize.A4, 20f, 20f, 20f, 10f);

            try
            {
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                Image image = Image.GetInstance(imagePath);
                image.ScalePercent(10f);

                doc.Add(new Paragraph(new Phrase("\n")));
                var table1 = new PdfPTable(2);
                table1.SpacingBefore = 45;
                table1.WidthPercentage = 100;

                var cell = new PdfPCell(image);
                cell.Padding = 1;
                cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cell.Border = PdfPCell.NO_BORDER;

                table1.AddCell(cell);
                table1.AddCell(getCells($"{list[0]}  \n\n{list[1]}", Element.ALIGN_RIGHT));
                doc.Add(table1);

                var table2 = new PdfPTable(2);
                table2.SpacingBefore = 50;
                table2.WidthPercentage = 90;

                PdfPCell c1 = new PdfPCell(new Phrase("Ship To", new Font(FontFactory
                    .GetFont("Ariel", 16, Font.BOLD, new BaseColor(System.Drawing.Color.Black)))));
                c1.Border = Rectangle.NO_BORDER;

                PdfPCell c2 = new PdfPCell(new Phrase("Bill To", new Font(FontFactory
                    .GetFont("Ariel", 16, Font.BOLD, new BaseColor(System.Drawing.Color.Black)))));
                c2.Border = Rectangle.NO_BORDER;
                table2.AddCell(c1);
                table2.AddCell(c2);
                table2.AddCell(getCells($"\n{list[2]}", Element.ALIGN_LEFT));
                table2.AddCell(getCells($"\n{list[3]}", Element.ALIGN_LEFT));
                doc.Add(table2);

                var pdfTable = new PdfPTable(3);
                pdfTable.SpacingBefore = 100;
                pdfTable.DefaultCell.Padding = 1;
                pdfTable.WidthPercentage = 100;
                pdfTable.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                pdfTable.DefaultCell.BorderWidth = 1;

                BuildPDFHeader(pdfTable, "Item");
                BuildPDFHeader(pdfTable, "Quantity");
                BuildPDFHeader(pdfTable, "Amount");

                DataTable dt = FileCSV.ReadCSVFile(@"C:\Users\ESTSYS\Downloads\invoicecsv.csv");

                for (int intIndex = 0; intIndex < dt.Rows.Count; intIndex++)
                {
                    pdfTable.AddCell(getCell(dt.Rows[intIndex]["Item"].ToString(), Element.ALIGN_LEFT,intIndex));
                    pdfTable.AddCell(getCell(dt.Rows[intIndex]["Quantity"].ToString(), Element.ALIGN_LEFT, intIndex));
                    pdfTable.AddCell(getCell(dt.Rows[intIndex]["Amount"].ToString(), Element.ALIGN_LEFT, intIndex));
                }

                doc.Add(pdfTable);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                doc.Close();
            }

        }

        private void BuildPDFHeader(PdfPTable pdfTable, String strText)
        {
            Font font = FontFactory.GetFont("Arial", 16, new BaseColor(System.Drawing.Color.White));
            PdfPCell cell = new PdfPCell(new Phrase(strText, font));
            cell.BackgroundColor = new BaseColor(51, 102, 102);
            cell.Padding = 3;
            cell.Border = Rectangle.NO_BORDER;
            pdfTable.AddCell(cell);
        }
    }
}
