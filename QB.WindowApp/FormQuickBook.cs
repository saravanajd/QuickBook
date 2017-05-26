using System;
using System.Data;
using System.Windows.Forms;
using QB.DAL;
using System.IO;
using QB.DAL.Files;

namespace QB.WindowApp
{
    public partial class FormQuickBook : Form
    {
        QuickBook qb = new QuickBook();

        Customer customer = new Customer();
        Item item = new Item();
        Bill bill = new Bill();
        Invoice invoice = new Invoice();
        Vendor vendor = new Vendor();
        Account account = new Account();
        SalesOrder salesOrder = new SalesOrder();

        FileExcel excel = new FileExcel();

        public FormQuickBook()
        {

            InitializeComponent();
        }

        private void FormQuickBook_Load(object sender, EventArgs e)
        {
            cbCustomer.DataSource = qb.ViewCustomer();
            cbCustomer.DisplayMember = "Name";
            cbCustomer.ValueMember = "QuickBooksID";

            cbItem.DataSource = qb.ViewItem();
            cbItem.DisplayMember = "Name";
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (qb.OpenConnection("new"))
                    MessageBox.Show("Created");
                else
                    MessageBox.Show("Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSessionOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (qb.OpenSession(@"C:\Users\Public\Documents\Intuit\QuickBooks\sampl\jadesoltech.qbw"))
                    MessageBox.Show("Session Started");
                else
                    MessageBox.Show("Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSessionClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (qb.CloseSession())
                    MessageBox.Show("Session Close");
                else
                    MessageBox.Show("Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (qb.CloseConnection())
                    MessageBox.Show("Connection Close");
                else
                    MessageBox.Show("Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            try
            {

                customer.CustomerName = txtCustomerName.Text;
                customer.Email = "saravana.jd@gmial.com";
                customer.CCEmail = "sara@gmial.com";
                customer.BillAddressAdd1 = "test";
                customer.BillAddressAdd2 = "guindy";
                customer.BillAddressCity = "fuindy";
                customer.BillAddressPostalCode = "610001";
                customer.BillAddressState = "TamilNadu";
                customer.Phone = "1234567891";
                customer.Fax = "456235";
                customer.Memo = "jade";
                customer.Currency = "US Dollar";
                if (qb.AddCustomer(customer))
                    MessageBox.Show($"Customer Name = {customer.CustomerName} Added Successfully");
                else
                    MessageBox.Show("Unknown Erroe !! ");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            try
            {
                bill.FromDate = dtFrom.Text;
                bill.ToDate = dtTo.Text;
                gvBill.DataSource = qb.ViewBill(bill);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCustomerView_Click(object sender, EventArgs e)
        {
            try
            {
                gvBill.DataSource = qb.ViewCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInvoiceAdd_Click(object sender, EventArgs e)
        {
            try
            {

                invoice.BillAddressAdd1 = "Olimbiya";
                invoice.CustomerName = cbCustomer.Text;
                invoice.Item = cbItem.Text;
                invoice.ListId = cbCustomer.SelectedValue.ToString();
                invoice.Quantity = int.Parse(txtItemQuantity.Text);
                MessageBox.Show(qb.AddInvoice(invoice) ? "Invoice Added" : "Uknown Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnInvoiceView_Click(object sender, EventArgs e)
        {
            try
            {
                gvBill.DataSource = qb.ViewInvoice();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnItemAdd_Click(object sender, EventArgs e)
        {
            try
            {
                item.ItemType = "Inventory";
                item.Name = txtItemName.Text;
                item.Description = "Test Item";
                item.Rate = 185;
                item.OnHandQuantity = 500;
                MessageBox.Show(qb.AddItem(item));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnViewItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvBill.DataSource = qb.ViewItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void btnBillAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bill.Address = "Chennai";
                bill.CustomerListID = cbCustomer.SelectedValue.ToString();
                bill.Description = "Create Bill Using window app";
                bill.Memo = "1234";
                bill.VendorName = "jd";
                bill.ItemName = cbItem.Text;
                bill.ItemQuantity = int.Parse(txtItemQuantity.Text);
                MessageBox.Show(qb.AddBill(bill) ? "Bill Created" : "Unkonwn Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            try
            {
                vendor.Name = txtVendorName.Text;
                vendor.Balance = 5000;
                vendor.CompanyName = "JadesolTech";
                MessageBox.Show(qb.AddVendor(vendor) 
                    ? $"Vendor Added Successfully \n Name = {vendor.Name}\n OpenBalance = {vendor.Balance}" 
                    : "Unkonwn Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnViewVendor_Click(object sender, EventArgs e)
        {
            try
            {
                gvBill.DataSource = qb.ViewVendor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAccountView_Click(object sender, EventArgs e)
        {
            try
            {
                gvBill.DataSource = qb.ViewAccount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAccountAdd_Click(object sender, EventArgs e)
        {
            try
            {
                account.Name = txtAccountName.Text;
                account.Description = "Account Create from Window App";
                MessageBox.Show(qb.AddAccount(account)
                    ? $"Account Added Successfully \n Name = {account.Name}"
                    : "Unkonwn Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSalesOrderAdd_Click(object sender, EventArgs e)
        {
            try
            {
                salesOrder.Address = "Chennai";
                salesOrder.CustomerName = cbCustomer.Text;
                salesOrder.CustomerRefListID = cbCustomer.SelectedValue.ToString();
                salesOrder.Description = "Sales Order Created By Window App";
                salesOrder.ItemName = cbItem.Text;
                salesOrder.ItemOrdered = Convert.ToInt32(txtItemQuantity.Text);
                MessageBox.Show(qb.AddSalesOrder(salesOrder)
                    ? $"SalesOrder Created Successfully"
                    : "Unkonwn Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalesOrderView_Click(object sender, EventArgs e)
        {
            try
            {
                gvBill.DataSource = qb.ViewSalesOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnInvoiceBulkAdd_Click(object sender, EventArgs e)
        {
            // Need to add a method in file excel
            #region Need To Add a method in FileExcel 

           
            //OpenFileDialog openFileDialog = new OpenFileDialog();

            //openFileDialog.InitialDirectory = @"C:\Users\ESTSYS\Downloads";
            //openFileDialog.Filter = "CSV file (*.csv)|*.csv|Excel File (*.xls)|*.xls";
            //openFileDialog.FilterIndex = 2;
            //openFileDialog.RestoreDirectory = true;

            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    try
            //    {
            //        string fileType = Path.GetExtension(openFileDialog.FileName);

            //        DataTable dt = null;

            //        if (fileType == ".csv")
            //            dt = excel.ReadExcel(openFileDialog.FileName);
            //        else if (fileType == ".xls")
            //            dt = FileExcel.ReadExcelFileUsingStream(openFileDialog.FileName);

            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {
            //            if(dt.Rows[i]["ListId"].ToString() != null)
            //                invoice.ListId = dt.Rows[i]["ListId"].ToString();
            //            if(dt.Rows[i]["CustomerName"].ToString() != null)
            //                invoice.CustomerName = dt.Rows[i]["CustomerName"].ToString();
            //            if(dt.Rows[i]["Item"].ToString() != null)
            //                invoice.Item = dt.Rows[i]["Item"].ToString();
            //            if(dt.Rows[i]["Quantity"].ToString() != null)
            //                invoice.Quantity = int.Parse(dt.Rows[i]["Quantity"].ToString());
            //            if(dt.Rows[i]["Address"].ToString() != null)
            //                invoice.BillAddressAdd1 = dt.Rows[i]["Address"].ToString();

            //            qb.AddInvoice(invoice);
            //        }

            //        MessageBox.Show("Invoice Added Successfully");


            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            //    }
            //}
            #endregion

        }
    }
}
