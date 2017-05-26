using System;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Linq;

namespace QB.DataAccess.Files
{
    public class FileCSV
    {

        public static DataTable ReadCSVFile(string path)
        {
            try
            {
                DataTable dt = new DataTable();

                File.ReadLines(@path).Take(1)
                    .SelectMany(columns => columns.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    .ToList()
                    .ForEach(column => dt.Columns.Add(column.Trim()));

                File.ReadLines(@path).Skip(1)
                    .Select(rows => rows.Split(new[] { ',' }))
                    .ToList()
                    .ForEach(row => dt.Rows.Add(row));

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void CreateFile(string contents, string path)
        {
            File.WriteAllText(@path, contents);
        }

        public static void GridViewToCSV(DataGridView gv, string path)
        {
            try
            {
                string csvFile = string.Empty;
                foreach (DataGridViewColumn column in gv.Columns)
                {
                    csvFile += column.HeaderText + ",";
                }

                csvFile += "\r\n";

                for (int i = 0; i < gv.Rows.Count - 1; i++)
                {
                    DataGridViewRow row = gv.Rows[i];
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        csvFile += cell.Value.ToString().Replace(",", ";") + ',';
                    }

                    csvFile += "\r\n";
                }

                CreateFile(csvFile, path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
