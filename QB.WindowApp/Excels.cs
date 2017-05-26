using System;
using System.Text;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;

namespace QB.WindowApp
{
    class ConvertXLStoDT
    {
        private StringBuilder errorMessages;

        public StringBuilder ErrorMessages
        {
            get { return errorMessages; }
            set { errorMessages = value; }
        }

        public ConvertXLStoDT()
        {
            ErrorMessages = new StringBuilder();
        }

        public DataTable XLStoDTusingInterOp(string FilePath)
        {
           
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;


            DataTable dt = new DataTable(); //Creating datatable to read the content of the Sheet in File.

            try
            {

                excelApp = new Excel.Application(); 

                workbook = excelApp.Workbooks.Open(FilePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                Excel.Worksheet ws = (Excel.Worksheet)workbook.Sheets.get_Item(1);

                Excel.Range excelRange = ws.UsedRange; //gives the used cells in sheet

                ws = null; // now No need of this so should expire.

                //Reading Excel file.               
                object[,] valueArray = (object[,])excelRange.get_Value(Excel.XlRangeValueDataType.xlRangeValueDefault);

                excelRange = null; // you don't need to do any more Interop. Now No need of this so should expire.

                dt = ProcessObjects(valueArray);

            }
            catch (Exception ex)
            {
                ErrorMessages.Append(ex.Message);
            }
            finally
            {
                #region Clean Up                
                if (workbook != null)
                {
                    #region Clean Up Close the workbook and release all the memory.
                    workbook.Close(false, FilePath, Missing.Value);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                    #endregion
                }
                workbook = null;

                if (excelApp != null)
                {
                    excelApp.Quit();
                }
                excelApp = null;

                #endregion
            }
            return (dt);
        }

        /// <summary>
        /// Scan the selected Excel workbook and store the information in the cells
        /// for this workbook in an object[,] array. Then, call another method
        /// to process the data.
        /// </summary>
        private void ExcelScanIntenal(Excel.Workbook workBookIn)
        {
            //
            // Get sheet Count and store the number of sheets.
            //
            int numSheets = workBookIn.Sheets.Count;

            //
            // Iterate through the sheets. They are indexed starting at 1.
            //
            for (int sheetNum = 1; sheetNum < numSheets + 1; sheetNum++)
            {
                Excel.Worksheet sheet = (Excel.Worksheet)workBookIn.Sheets[sheetNum];

                //
                // Take the used range of the sheet. Finally, get an object array of all
                // of the cells in the sheet (their values). You can do things with those
                // values. See notes about compatibility.
                //
                Excel.Range excelRange = sheet.UsedRange;
                object[,] valueArray = (object[,])excelRange.get_Value(Excel.XlRangeValueDataType.xlRangeValueDefault);

                //
                // Do something with the data in the array with a custom method.
                //
                ProcessObjects(valueArray);
            }
        }
        private DataTable ProcessObjects(object[,] valueArray)
        {
            DataTable dt = new DataTable();

            #region Get the COLUMN names

            for (int k = 1; k <= valueArray.GetLength(1); k++)
            {
                dt.Columns.Add((string)valueArray[1, k]);  //add columns to the data table.
            }

            #endregion

            #region Load Excel SHEET DATA into data table

            object[] singleDValue = new object[valueArray.GetLength(1)];
            //value array first row contains column names. so loop starts from 2 instead of 1
            for (int i = 2; i <= valueArray.GetLength(0); i++)
            {
                for (int j = 0; j < valueArray.GetLength(1); j++)
                {
                    if (valueArray[i, j + 1] != null)
                    {
                        singleDValue[j] = valueArray[i, j + 1].ToString();
                    }
                    else
                    {
                        singleDValue[j] = valueArray[i, j + 1];
                    }
                }
                dt.LoadDataRow(singleDValue, LoadOption.PreserveChanges);
            }
            #endregion


            return (dt);
        }
    }
}
