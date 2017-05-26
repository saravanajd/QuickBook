using QB.DAL;
using QB.DAL.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QB.WindowApplication
{
    public partial class FormGeneralReport : Form
    {
        QuickBook qb = new QuickBook();
        FileExcel excel = new FileExcel();
        DataTable dt = null;

        public FormGeneralReport()
        {
            InitializeComponent();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            try
            {
                dt = qb.ReportProfitAndLossByJob();
                gvReport.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dt != null)
                    MessageBox.Show(excel.ExportToExcel(dt) ? "Exported Successfully !" : "Uknown Error ");
                else
                    MessageBox.Show("Please Load the data to gridview then Click Export !!! ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
