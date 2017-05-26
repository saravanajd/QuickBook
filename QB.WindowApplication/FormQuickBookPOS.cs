using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QB.DAL;
using QB.DataAccess;

namespace QB.WindowApplication
{
    public partial class FormQuickBookPOS : Form
    {
        QuickBookPOS pos = new QuickBookPOS();

        Customer customer = new Customer();
        Item item = new Item();
        Bill bill = new Bill();
        Invoice invoice = new Invoice();
        Vendor vendor = new Vendor();
        Account account = new Account();
        SalesOrder salesOrder = new SalesOrder();
        Department dept = new Department();
        PurchaseOrder purchaseOrder = new PurchaseOrder();

        DataSet ds = null;

        public FormQuickBookPOS()
        {
            InitializeComponent();
        }

        public void FetchDataToDataSet()
        {
            ds = new DataSet();

            ds.Tables.Add(pos.ViewCustomer());
            ds.Tables.Add(pos.ViewItem());
            ds.Tables.Add(pos.ViewDepartment());
            ds.Tables.Add(pos.ViewVendor());

            cmbCusomerNameList.DataSource = ds.Tables[0];
            cmbCusomerNameList.DisplayMember = "Name";
            cmbCusomerNameList.ValueMember = "QuickBooksID";

            cmbItemNameList.DataSource = ds.Tables[1];
            cmbItemNameList.DisplayMember = "Item Name";
            cmbItemNameList.ValueMember = "Item ListId";

            cmbPOItemNameList.DataSource = ds.Tables[1];
            cmbPOItemNameList.DisplayMember = "Item Name";
            cmbPOItemNameList.ValueMember = "Item ListId";

            cmbDepartmentNameList.DataSource = ds.Tables[2];
            cmbDepartmentNameList.DisplayMember = "Department Name";
            cmbDepartmentNameList.ValueMember = "ListID";

            cmbVendorNameList.DataSource = ds.Tables[3];
            cmbVendorNameList.DisplayMember = "Comapny Name";
            cmbVendorNameList.ValueMember = "Vendor ListID";


        }

        private void btnCustomerView_Click(object sender, EventArgs e)
        {
            try
            {
                gvQBPOS.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCustomerAdd_Click(object sender, EventArgs e)
        {
            try
            {

                customer.FirstName = txtCustomerFirstName.Text;
                customer.LastName = txtCustomerLastName.Text;
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
                if (pos.AddCustomer(customer))
                    MessageBox.Show($"Customer Name = {customer.CustomerName} Added Successfully");
                else
                    MessageBox.Show("Unknown Erroe !! ");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDepartmentAdd_Click(object sender, EventArgs e)
        {
            try
            {
                dept.DepartmentCode = txtDepartmentCode.Text;
                dept.DepartmentName = txtDepartmentName.Text;
                if (pos.AddDepartment(dept))
                    MessageBox.Show($"Department Name = {dept.DepartmentName} Added Successfully");
                else
                    MessageBox.Show("Unknown Erroe !! ");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDepartmentView_Click(object sender, EventArgs e)
        {
            try
            {
                gvQBPOS.DataSource = ds.Tables[2];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnItemView_Click(object sender, EventArgs e)
        {
            try
            {
                gvQBPOS.DataSource = ds.Tables[1];
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
                item.Name = txtItemName.Text;
                item.DepartmentListId = cmbDepartmentNameList.SelectedValue.ToString();
                item.Rate = Convert.ToDouble(txtItemPrice.Text);
                if (pos.AddItem(item))
                    MessageBox.Show($"Item Name = { item.Name } Added Successfully");
                else
                    MessageBox.Show("Unknown Erroe !! ");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                FetchDataToDataSet();
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
                salesOrder.CustomerRefListID = cmbCusomerNameList.SelectedValue.ToString();
                salesOrder.ItemRefListID = cmbItemNameList.SelectedValue.ToString();
                salesOrder.ItemQuantity = Convert.ToDouble(txtItemQuantity.Text);
                if (pos.AddSalesOrder(salesOrder))
                    MessageBox.Show($"Item Name Added Successfully");
                else
                    MessageBox.Show("Unknown Erroe !! ");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void btnSalesOrderView_Click(object sender, EventArgs e)
        {
            try
            {
                gvQBPOS.DataSource = pos.ViewSalesOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnVendorAdd_Click(object sender, EventArgs e)
        {
            try
            {
                vendor.CompanyName = txtVedorCompanyName.Text;
                vendor.Name = txtVendorName.Text;
                vendor.VendorCode = txtVendorCode.Text;
                if (pos.AddVendor(vendor))
                    MessageBox.Show($"Vendor Added Successfully");
                else
                    MessageBox.Show("Unknown Erroe !! ");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }

        private void btnVendorView_Click(object sender, EventArgs e)
        {
            try
            {
                gvQBPOS.DataSource = ds.Tables[3];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnPoAdd_Click(object sender, EventArgs e)
        {
            try
            {
                purchaseOrder.ItemRefListID = cmbPOItemNameList.SelectedValue.ToString();
                purchaseOrder.PONumber = txtPONumber.Text;
                purchaseOrder.ItemQuantity = Convert.ToDouble(txtPOItemQuantity.Text);
                purchaseOrder.VendorRefListID = cmbVendorNameList.SelectedValue.ToString();

                if (pos.AddPurchaseOrder(purchaseOrder))
                    MessageBox.Show($"Vendor Added Successfully");
                else
                    MessageBox.Show("Unknown Erroe !! ");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }

        private void btnPoView_Click(object sender, EventArgs e)
        {
            try
            {
                gvQBPOS.DataSource = pos.ViewPurchaseOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddCustomFieldCustomer_Click(object sender, EventArgs e)
        {

            try
            {
                customer.FirstName = txtCustomFieldName.Text;
                customer.LastName = "jd";
                customer.Phone = "1234567899";
                customer.CustomField = txtCustomField.Text;
                MessageBox.Show(pos.AddCustomFieldCustomer(customer)
                    ? "Customer Added Successfully"
                    : "Unkown Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewCustomFieldCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                gvQBPOS.DataSource = pos.ViewCustomFieldCustomer();
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
                vendor.CompanyName = txtCustomFieldName.Text;
                vendor.CustomField = txtCustomField.Text;
                vendor.VendorCode = txtVendorCodeCust.Text;
                MessageBox.Show(pos.AddCustomFieldVendor(vendor)
                    ? "Vendor Added Successfully"
                    : "Unkown Error");
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
                gvQBPOS.DataSource = pos.ViewCustomFieldVendor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddCustFieldItem_Click(object sender, EventArgs e)
        {
            try
            {
                item.DepartmentListId = cmbDepartmentNameList.SelectedValue.ToString();
                item.Name = txtCustomFieldName.Text;
                item.CustomField = txtCustomField.Text;
                item.Rate = 100;
                MessageBox.Show(pos.AddCustomFieldItem(item)
                    ? "Item Added Successfully"
                    : "Unkown Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewCustFieldItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvQBPOS.DataSource = pos.ViewCustomFieldItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModViewCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                txtModName.Text = pos.GetCustomer(txtModListID.Text).FirstName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                customer.ListId = txtModListID.Text;
                customer.FirstName = txtModName.Text;
                MessageBox.Show(pos.UpdateCustomer(customer)
                    ? "Customer Updated Successfully"
                    : "Unkown Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModViewVendor_Click(object sender, EventArgs e)
        {
            try
            {
                txtModName.Text = pos.GetVendor(txtModListID.Text).CompanyName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnModVendor_Click(object sender, EventArgs e)
        {
            try
            {
                vendor.VendorList= txtModListID.Text;
                vendor.CompanyName = txtModName.Text;
                MessageBox.Show(pos.UpdateVendor(vendor)
                    ? "Vendor Updated Successfully"
                    : "Unkown Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnModViewItem_Click(object sender, EventArgs e)
        {
            try
            {
                txtModName.Text = pos.GetItem(txtModListID.Text).Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModItem_Click(object sender, EventArgs e)
        {
            try
            {
                item.Name = txtModName.Text;
                item.ListID = txtModListID.Text;
                MessageBox.Show(pos.UpdateItem(item)
                    ? "Item Updated Successfully"
                    : "Unkown Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
