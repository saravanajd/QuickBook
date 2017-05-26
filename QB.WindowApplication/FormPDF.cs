using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QB.DAL.Files;

namespace QB.WindowApplication
{
    public partial class FormPDF : Form
    {
        FilePDF pdf = new FilePDF();
        public FormPDF()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string s = pdf.GetText();
                var lines = new List<string>();

                lines = s
                    .Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                // label2.Text = $"{lines[0].Substring(lines[0].IndexOf(':'))} \n {lines[1].Substring(lines[1].IndexOf(':'))}";
                label2.Text = lines[1].Substring(lines[1].IndexOf(':'));
                txtShipTo.Text = s.Substring(s.IndexOf("Ship To"), s.IndexOf("Bill To"));

                txtInvoiceDate.Text = s.Substring(s.IndexOf("Bill To"));
                pbLogo.Image = pdf.GetImage()[0];
                label1.Text = s;
                //label1.Text = s.Substring(s.IndexOf("Item"));
                //MessageBox.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
