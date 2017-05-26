using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Runtime.InteropServices;
using System;
using System.Reflection;

namespace QB.WindowApp
{
    public class MyExcel
    {
        private Excel.Application app;
        private Excel.Workbook workBook;
        private Excel.Worksheet workSheet;
        private Excel.Range range;

        public string path = @"E:\Saravanan\Projects\QB Project\QuickBooks\QB.WindowApp\IncomeExpense.xlsx";
        private void InitializeExcel()
        {
            app = new Excel.Application();
            workBook = app.Workbooks.Open(path);
            workSheet = (Excel.Worksheet)workBook.Sheets[1];
            range = workSheet.UsedRange;
        }

        public void CloseExcel()
        {
            if (workBook != null)
            {
                workBook.Close(false, path, Missing.Value);
                Marshal.ReleaseComObject(workBook);
            }
            workBook = null;
        }

        public void Export(DataTable dt)
        {

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
    }
}
