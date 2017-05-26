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

namespace QB.WindowApp
{
    public partial class FormPdf : Form
    {
        public FormPdf()
        {
            InitializeComponent();
        }

        private void FormPdf_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FilePDF pdf = new FilePDF();
                MessageBox.Show(pdf.GetText());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
