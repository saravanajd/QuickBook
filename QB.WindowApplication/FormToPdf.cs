using QB.DAL.Files;
using QB.DataAccess.Files;
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
    public partial class FormToPdf : Form
    {
        MyPDF pdf = new MyPDF();
        public FormToPdf()
        {
            InitializeComponent();
            gvLoad();
        }

        public void gvLoad()
        {
            try
            {
                gvOrders.DataSource = FileCSV.ReadCSVFile(@"C:\Users\ESTSYS\Downloads\invoicecsv.csv");
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
                List<string> list = new List<string>();
                list.Add($"Invoice No: {txtInvoice.Text}");
                list.Add($"Date : {txtDate.Text}");
                list.Add($"{txtShip.Text}");
                list.Add($"{txtBill.Text}");
                string imagePath = pbLogo.ImageLocation;
                pdf.CreatePDF(list,imagePath);
                MessageBox.Show("Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
