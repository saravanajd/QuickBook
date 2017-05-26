using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QB.WindowApp
{
    public partial class FormExcel : Form
    {
        MyExcel xl = new MyExcel();
        DataSet ds = new DataSet();
        BindingList<string> tableName = new BindingList<string>();
        public FormExcel()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                gvExcel.DataSource = ds.Tables[cmbTableName.Text];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoadExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ds = xl.ReadExcel();
                foreach (DataTable table in ds.Tables)
                {
                    tableName.Add(table.TableName);
                }
                cmbTableName.DataSource = tableName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
