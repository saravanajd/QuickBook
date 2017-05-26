using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Runtime.InteropServices;
using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace QB.DAL.Files
{
    public class FileExcel
    {
        private Excel.Application app;
        private Excel.Workbook workBook;
        private Excel.Worksheet workSheet;
        private Excel.Range range;

        public string path = @"E:\Saravanan\Projects\QB Project\QuickBooks\QB.WindowApp\IncomeExpense.xlsx";
        public string excelFilePath = @"E:\Saravanan\Projects\QB Project\QuickBooks\QB.WindowApp\ReportProfitAndLoss.xls";

        private void InitializeExcel()
        {
            app = new Excel.Application();
            workBook = app.Workbooks.Open(path);
            workSheet = (Excel.Worksheet)workBook.Sheets[1];
            range = workSheet.UsedRange;

        }

        private void CloseExcel()
        {
            if (workBook != null)
            {
                workBook.Close(false, path, Missing.Value);
                Marshal.ReleaseComObject(workBook);
            }
            workBook = null;
        }

        public DataSet ReadExcel()
        {
            var ds = new DataSet();
            try
            {
                app = new Excel.Application();
                workBook = app.Workbooks.Open(path);
                workSheet = (Excel.Worksheet)workBook.Sheets[1];
                range = workSheet.UsedRange;

                workSheet = null;
                object[,] valueArray = (object[,])range.get_Value(Excel.XlRangeValueDataType.xlRangeValueDefault);
                range = null;



                for (int col = 10; col < valueArray.GetLength(1); col++)
                {

                    if (valueArray[4, col] != null)
                    {
                        string tableName = valueArray[4, col].ToString();
                        if (!string.IsNullOrEmpty(tableName))
                        {
                            var dt = new DataTable();
                            dt.TableName = tableName;

                            dt.Columns.Add("IncomeAndExpense");
                            dt.Columns.Add("Column A");
                            dt.Columns.Add("Column B");
                            dt.Columns.Add("Income");
                            dt.Columns.Add("Income Percentage");

                            for (int row = 8; row <= valueArray.GetLength(0); row++)
                            {
                                DataRow dr = dt.NewRow();

                                if (valueArray[row, 4] != null)
                                    dr[0] = valueArray[row, 4].ToString();
                                if (valueArray[row, 5] != null)
                                    dr[1] = valueArray[row, 5].ToString();
                                if (valueArray[row, 6] != null)
                                    dr[2] = valueArray[row, 6].ToString();

                                if (valueArray[row, col] != null)
                                    dr[3] = valueArray[row, col].ToString();
                                if (valueArray[row, col + 1] != null)
                                    dr[4] = valueArray[row, col + 1].ToString();

                                dt.Rows.Add(dr);
                            }

                            ds.Tables.Add(dt);
                        }
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseExcel();
                if (app != null)
                {
                    app.Quit();
                }
                Marshal.ReleaseComObject(app);
            }
        }
        public DataTable ReadExcelFileUsingStream()
        {
            try
            {
                var dt = new DataTable();
                using (StreamReader sr = new StreamReader(@"C:\Users\ESTSYS\Downloads\invoice.xls"))
                {
                    List<string> lines;
                    lines = sr.ReadToEnd()
                        .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    lines.Take(1)
                        .SelectMany(x => x.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries))
                        .ToList()
                        .ForEach(row => dt.Columns.Add(row));

                    lines.Skip(1)
                        .Select(x => x.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries))
                        .ToList()
                        .ForEach(row => dt.Rows.Add(row));

                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ExportToExcel(DataTable dt)
        {
            try
            {
                app = new Excel.Application();
                workBook = app.Workbooks.Add(1);
                workSheet = (Excel.Worksheet)workBook.Worksheets[1];

                // export column headers
                for (int colNdx = 0; colNdx < dt.Columns.Count; colNdx++)
                {
                    workSheet.Cells[1, colNdx + 1] = dt.Columns[colNdx].ColumnName;
                }

                // export data
                for (int rowNdx = 0; rowNdx < dt.Rows.Count; rowNdx++)
                {
                    for (int colNdx = 0; colNdx < dt.Columns.Count; colNdx++)
                    {
                        workSheet.Cells[rowNdx + 2, colNdx + 1] = GetString(dt.Rows[rowNdx][colNdx]);
                    }
                }
                workBook.SaveAs(excelFilePath,Excel.XlSaveAsAccessMode.xlNoChange);
                workBook.Close(false, Type.Missing, Type.Missing);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseExcel();
                if (app != null)
                {
                    app.Quit();
                }
                Marshal.ReleaseComObject(app);
            }
        }

        private string GetString(object o)
        {
            if (o == null)
                return "";
            return o.ToString();
        }
    }
}
