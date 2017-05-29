namespace QB.WindowApp
{
    partial class FormQuickBook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSessionOpen = new System.Windows.Forms.Button();
            this.btnSessionClose = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnViewBill = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.btnViewCustomer = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnViewVendor = new System.Windows.Forms.Button();
            this.txtVendorName = new System.Windows.Forms.TextBox();
            this.btnAddVendor = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnViewItem = new System.Windows.Forms.Button();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.btnItemAdd = new System.Windows.Forms.Button();
            this.btnViewInvoice = new System.Windows.Forms.Button();
            this.btnInvoiceAdd = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.btnInvoiceBulkAdd = new System.Windows.Forms.Button();
            this.btnSalesOrderView = new System.Windows.Forms.Button();
            this.btnSalesOrderAdd = new System.Windows.Forms.Button();
            this.btnBillAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtItemQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbItem = new System.Windows.Forms.ComboBox();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.btnAccountAdd = new System.Windows.Forms.Button();
            this.btnViewAccount = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gvBill = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEditSequence = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.txtMob = new System.Windows.Forms.TextBox();
            this.txtModCustomerName = new System.Windows.Forms.TextBox();
            this.btnUpdateCustomer = new System.Windows.Forms.Button();
            this.txtCustomerQuickBookID = new System.Windows.Forms.TextBox();
            this.btnLoadCustomer = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnViewCustItem = new System.Windows.Forms.Button();
            this.btnAddCustItem = new System.Windows.Forms.Button();
            this.btnViewCustVendor = new System.Windows.Forms.Button();
            this.btnAddCustVendor = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCustomField = new System.Windows.Forms.TextBox();
            this.txtCustomFieldName = new System.Windows.Forms.TextBox();
            this.btnViewCustCustomer = new System.Windows.Forms.Button();
            this.btnAddCustCustomer = new System.Windows.Forms.Button();
            this.btnSalesOrderBulkAdd = new System.Windows.Forms.Button();
            this.btnBillBulkAdd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvBill)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(6, 20);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(107, 32);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Open Connection";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSessionOpen
            // 
            this.btnSessionOpen.Location = new System.Drawing.Point(134, 20);
            this.btnSessionOpen.Name = "btnSessionOpen";
            this.btnSessionOpen.Size = new System.Drawing.Size(117, 32);
            this.btnSessionOpen.TabIndex = 1;
            this.btnSessionOpen.Text = "Session Open";
            this.btnSessionOpen.UseVisualStyleBackColor = true;
            this.btnSessionOpen.Click += new System.EventHandler(this.btnSessionOpen_Click);
            // 
            // btnSessionClose
            // 
            this.btnSessionClose.Location = new System.Drawing.Point(134, 67);
            this.btnSessionClose.Name = "btnSessionClose";
            this.btnSessionClose.Size = new System.Drawing.Size(117, 32);
            this.btnSessionClose.TabIndex = 2;
            this.btnSessionClose.Text = "Session Close";
            this.btnSessionClose.UseVisualStyleBackColor = true;
            this.btnSessionClose.Click += new System.EventHandler(this.btnSessionClose_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(6, 67);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 32);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close Connection";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.Location = new System.Drawing.Point(6, 64);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(117, 32);
            this.btnCustomer.TabIndex = 4;
            this.btnCustomer.Text = "Add Customer";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnViewBill
            // 
            this.btnViewBill.Location = new System.Drawing.Point(114, 242);
            this.btnViewBill.Name = "btnViewBill";
            this.btnViewBill.Size = new System.Drawing.Size(99, 32);
            this.btnViewBill.TabIndex = 5;
            this.btnViewBill.Text = "View Bill";
            this.btnViewBill.UseVisualStyleBackColor = true;
            this.btnViewBill.Click += new System.EventHandler(this.btnBill_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.btnSessionOpen);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnSessionClose);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 106);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connections";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCustomerName);
            this.groupBox2.Controls.Add(this.btnViewCustomer);
            this.groupBox2.Controls.Add(this.btnCustomer);
            this.groupBox2.Location = new System.Drawing.Point(276, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 106);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(6, 20);
            this.txtCustomerName.Multiline = true;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(201, 27);
            this.txtCustomerName.TabIndex = 6;
            // 
            // btnViewCustomer
            // 
            this.btnViewCustomer.Location = new System.Drawing.Point(142, 64);
            this.btnViewCustomer.Name = "btnViewCustomer";
            this.btnViewCustomer.Size = new System.Drawing.Size(117, 32);
            this.btnViewCustomer.TabIndex = 5;
            this.btnViewCustomer.Text = "View Customer";
            this.btnViewCustomer.UseVisualStyleBackColor = true;
            this.btnViewCustomer.Click += new System.EventHandler(this.btnCustomerView_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnViewVendor);
            this.groupBox3.Controls.Add(this.txtVendorName);
            this.groupBox3.Controls.Add(this.btnAddVendor);
            this.groupBox3.Location = new System.Drawing.Point(276, 124);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(269, 120);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ventor";
            // 
            // btnViewVendor
            // 
            this.btnViewVendor.Location = new System.Drawing.Point(142, 65);
            this.btnViewVendor.Name = "btnViewVendor";
            this.btnViewVendor.Size = new System.Drawing.Size(117, 32);
            this.btnViewVendor.TabIndex = 19;
            this.btnViewVendor.Text = "View Vendor";
            this.btnViewVendor.UseVisualStyleBackColor = true;
            this.btnViewVendor.Click += new System.EventHandler(this.btnViewVendor_Click);
            // 
            // txtVendorName
            // 
            this.txtVendorName.Location = new System.Drawing.Point(6, 21);
            this.txtVendorName.Multiline = true;
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.Size = new System.Drawing.Size(182, 27);
            this.txtVendorName.TabIndex = 10;
            // 
            // btnAddVendor
            // 
            this.btnAddVendor.Location = new System.Drawing.Point(6, 65);
            this.btnAddVendor.Name = "btnAddVendor";
            this.btnAddVendor.Size = new System.Drawing.Size(117, 32);
            this.btnAddVendor.TabIndex = 18;
            this.btnAddVendor.Text = "Add Vendor";
            this.btnAddVendor.UseVisualStyleBackColor = true;
            this.btnAddVendor.Click += new System.EventHandler(this.btnAddVendor_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnViewItem);
            this.groupBox5.Controls.Add(this.txtItemName);
            this.groupBox5.Controls.Add(this.btnItemAdd);
            this.groupBox5.Location = new System.Drawing.Point(12, 124);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(258, 120);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Items";
            // 
            // btnViewItem
            // 
            this.btnViewItem.Location = new System.Drawing.Point(134, 63);
            this.btnViewItem.Name = "btnViewItem";
            this.btnViewItem.Size = new System.Drawing.Size(117, 32);
            this.btnViewItem.TabIndex = 9;
            this.btnViewItem.Text = "View Item";
            this.btnViewItem.UseVisualStyleBackColor = true;
            this.btnViewItem.Click += new System.EventHandler(this.btnViewItem_Click);
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(6, 19);
            this.txtItemName.Multiline = true;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(182, 27);
            this.txtItemName.TabIndex = 7;
            // 
            // btnItemAdd
            // 
            this.btnItemAdd.Location = new System.Drawing.Point(6, 63);
            this.btnItemAdd.Name = "btnItemAdd";
            this.btnItemAdd.Size = new System.Drawing.Size(117, 32);
            this.btnItemAdd.TabIndex = 8;
            this.btnItemAdd.Text = "Add Item";
            this.btnItemAdd.UseVisualStyleBackColor = true;
            this.btnItemAdd.Click += new System.EventHandler(this.btnItemAdd_Click);
            // 
            // btnViewInvoice
            // 
            this.btnViewInvoice.Location = new System.Drawing.Point(114, 126);
            this.btnViewInvoice.Name = "btnViewInvoice";
            this.btnViewInvoice.Size = new System.Drawing.Size(99, 32);
            this.btnViewInvoice.TabIndex = 7;
            this.btnViewInvoice.Text = "View Invoice";
            this.btnViewInvoice.UseVisualStyleBackColor = true;
            this.btnViewInvoice.Click += new System.EventHandler(this.btnInvoiceView_Click);
            // 
            // btnInvoiceAdd
            // 
            this.btnInvoiceAdd.Location = new System.Drawing.Point(9, 126);
            this.btnInvoiceAdd.Name = "btnInvoiceAdd";
            this.btnInvoiceAdd.Size = new System.Drawing.Size(99, 32);
            this.btnInvoiceAdd.TabIndex = 6;
            this.btnInvoiceAdd.Text = "Add Invoice";
            this.btnInvoiceAdd.UseVisualStyleBackColor = true;
            this.btnInvoiceAdd.Click += new System.EventHandler(this.btnInvoiceAdd_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnBillBulkAdd);
            this.groupBox6.Controls.Add(this.btnSalesOrderBulkAdd);
            this.groupBox6.Controls.Add(this.dtTo);
            this.groupBox6.Controls.Add(this.dtFrom);
            this.groupBox6.Controls.Add(this.btnInvoiceBulkAdd);
            this.groupBox6.Controls.Add(this.btnSalesOrderView);
            this.groupBox6.Controls.Add(this.btnSalesOrderAdd);
            this.groupBox6.Controls.Add(this.btnBillAdd);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.txtItemQuantity);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.btnViewInvoice);
            this.groupBox6.Controls.Add(this.btnViewBill);
            this.groupBox6.Controls.Add(this.cbItem);
            this.groupBox6.Controls.Add(this.cbCustomer);
            this.groupBox6.Controls.Add(this.btnInvoiceAdd);
            this.groupBox6.Location = new System.Drawing.Point(551, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(336, 324);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Bill And Invoice";
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "mm/dd/yyyy";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(114, 212);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(99, 20);
            this.dtTo.TabIndex = 22;
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "mm/dd/yyyy";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(9, 212);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(99, 20);
            this.dtFrom.TabIndex = 21;
            // 
            // btnInvoiceBulkAdd
            // 
            this.btnInvoiceBulkAdd.Location = new System.Drawing.Point(216, 126);
            this.btnInvoiceBulkAdd.Name = "btnInvoiceBulkAdd";
            this.btnInvoiceBulkAdd.Size = new System.Drawing.Size(114, 32);
            this.btnInvoiceBulkAdd.TabIndex = 20;
            this.btnInvoiceBulkAdd.Text = "Bulk Invoice Add";
            this.btnInvoiceBulkAdd.UseVisualStyleBackColor = true;
            this.btnInvoiceBulkAdd.Click += new System.EventHandler(this.btnInvoiceBulkAdd_Click);
            // 
            // btnSalesOrderView
            // 
            this.btnSalesOrderView.Location = new System.Drawing.Point(114, 164);
            this.btnSalesOrderView.Name = "btnSalesOrderView";
            this.btnSalesOrderView.Size = new System.Drawing.Size(99, 32);
            this.btnSalesOrderView.TabIndex = 19;
            this.btnSalesOrderView.Text = "View SalesOrder";
            this.btnSalesOrderView.UseVisualStyleBackColor = true;
            this.btnSalesOrderView.Click += new System.EventHandler(this.btnSalesOrderView_Click);
            // 
            // btnSalesOrderAdd
            // 
            this.btnSalesOrderAdd.Location = new System.Drawing.Point(9, 164);
            this.btnSalesOrderAdd.Name = "btnSalesOrderAdd";
            this.btnSalesOrderAdd.Size = new System.Drawing.Size(99, 32);
            this.btnSalesOrderAdd.TabIndex = 18;
            this.btnSalesOrderAdd.Text = "Add SalesOrder";
            this.btnSalesOrderAdd.UseVisualStyleBackColor = true;
            this.btnSalesOrderAdd.Click += new System.EventHandler(this.btnSalesOrderAdd_Click);
            // 
            // btnBillAdd
            // 
            this.btnBillAdd.Location = new System.Drawing.Point(9, 242);
            this.btnBillAdd.Name = "btnBillAdd";
            this.btnBillAdd.Size = new System.Drawing.Size(99, 32);
            this.btnBillAdd.TabIndex = 15;
            this.btnBillAdd.Text = "AddBill";
            this.btnBillAdd.UseVisualStyleBackColor = true;
            this.btnBillAdd.Click += new System.EventHandler(this.btnBillAdd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Quantity";
            // 
            // txtItemQuantity
            // 
            this.txtItemQuantity.Location = new System.Drawing.Point(114, 85);
            this.txtItemQuantity.Multiline = true;
            this.txtItemQuantity.Name = "txtItemQuantity";
            this.txtItemQuantity.Size = new System.Drawing.Size(121, 21);
            this.txtItemQuantity.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Item";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Customer";
            // 
            // cbItem
            // 
            this.cbItem.FormattingEnabled = true;
            this.cbItem.Location = new System.Drawing.Point(114, 58);
            this.cbItem.Name = "cbItem";
            this.cbItem.Size = new System.Drawing.Size(121, 21);
            this.cbItem.TabIndex = 14;
            // 
            // cbCustomer
            // 
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Location = new System.Drawing.Point(114, 31);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(121, 21);
            this.cbCustomer.TabIndex = 13;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtAccountName);
            this.groupBox7.Controls.Add(this.btnAccountAdd);
            this.groupBox7.Controls.Add(this.btnViewAccount);
            this.groupBox7.Location = new System.Drawing.Point(551, 343);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(336, 117);
            this.groupBox7.TabIndex = 20;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Account";
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(6, 26);
            this.txtAccountName.Multiline = true;
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(182, 27);
            this.txtAccountName.TabIndex = 20;
            // 
            // btnAccountAdd
            // 
            this.btnAccountAdd.Location = new System.Drawing.Point(6, 59);
            this.btnAccountAdd.Name = "btnAccountAdd";
            this.btnAccountAdd.Size = new System.Drawing.Size(117, 32);
            this.btnAccountAdd.TabIndex = 19;
            this.btnAccountAdd.Text = "Add Account";
            this.btnAccountAdd.UseVisualStyleBackColor = true;
            this.btnAccountAdd.Click += new System.EventHandler(this.btnAccountAdd_Click);
            // 
            // btnViewAccount
            // 
            this.btnViewAccount.Location = new System.Drawing.Point(134, 59);
            this.btnViewAccount.Name = "btnViewAccount";
            this.btnViewAccount.Size = new System.Drawing.Size(117, 32);
            this.btnViewAccount.TabIndex = 18;
            this.btnViewAccount.Text = "View Accounts";
            this.btnViewAccount.UseVisualStyleBackColor = true;
            this.btnViewAccount.Click += new System.EventHandler(this.btnAccountView_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // gvBill
            // 
            this.gvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBill.Location = new System.Drawing.Point(12, 426);
            this.gvBill.Name = "gvBill";
            this.gvBill.Size = new System.Drawing.Size(533, 227);
            this.gvBill.TabIndex = 6;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtEditSequence);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtEmail);
            this.groupBox4.Controls.Add(this.txtCompany);
            this.groupBox4.Controls.Add(this.txtMob);
            this.groupBox4.Controls.Add(this.txtModCustomerName);
            this.groupBox4.Controls.Add(this.btnUpdateCustomer);
            this.groupBox4.Controls.Add(this.txtCustomerQuickBookID);
            this.groupBox4.Controls.Add(this.btnLoadCustomer);
            this.groupBox4.Location = new System.Drawing.Point(12, 250);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(533, 170);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ventor";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(202, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Edit Sequence";
            // 
            // txtEditSequence
            // 
            this.txtEditSequence.Location = new System.Drawing.Point(205, 32);
            this.txtEditSequence.Multiline = true;
            this.txtEditSequence.Name = "txtEditSequence";
            this.txtEditSequence.Size = new System.Drawing.Size(182, 27);
            this.txtEditSequence.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(202, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Email";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(202, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Company";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Mobile";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "QuickBooks ID";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(205, 136);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(182, 27);
            this.txtEmail.TabIndex = 23;
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(205, 86);
            this.txtCompany.Multiline = true;
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(182, 27);
            this.txtCompany.TabIndex = 22;
            // 
            // txtMob
            // 
            this.txtMob.Location = new System.Drawing.Point(6, 136);
            this.txtMob.Multiline = true;
            this.txtMob.Name = "txtMob";
            this.txtMob.Size = new System.Drawing.Size(182, 27);
            this.txtMob.TabIndex = 21;
            // 
            // txtModCustomerName
            // 
            this.txtModCustomerName.Location = new System.Drawing.Point(6, 86);
            this.txtModCustomerName.Multiline = true;
            this.txtModCustomerName.Name = "txtModCustomerName";
            this.txtModCustomerName.Size = new System.Drawing.Size(182, 27);
            this.txtModCustomerName.TabIndex = 20;
            // 
            // btnUpdateCustomer
            // 
            this.btnUpdateCustomer.Location = new System.Drawing.Point(393, 132);
            this.btnUpdateCustomer.Name = "btnUpdateCustomer";
            this.btnUpdateCustomer.Size = new System.Drawing.Size(117, 32);
            this.btnUpdateCustomer.TabIndex = 19;
            this.btnUpdateCustomer.Text = "Update Customer";
            this.btnUpdateCustomer.UseVisualStyleBackColor = true;
            this.btnUpdateCustomer.Click += new System.EventHandler(this.btnUpdateCustomer_Click);
            // 
            // txtCustomerQuickBookID
            // 
            this.txtCustomerQuickBookID.Location = new System.Drawing.Point(6, 36);
            this.txtCustomerQuickBookID.Multiline = true;
            this.txtCustomerQuickBookID.Name = "txtCustomerQuickBookID";
            this.txtCustomerQuickBookID.Size = new System.Drawing.Size(156, 27);
            this.txtCustomerQuickBookID.TabIndex = 10;
            this.txtCustomerQuickBookID.Text = "80000004-1495000906";
            // 
            // btnLoadCustomer
            // 
            this.btnLoadCustomer.Location = new System.Drawing.Point(393, 32);
            this.btnLoadCustomer.Name = "btnLoadCustomer";
            this.btnLoadCustomer.Size = new System.Drawing.Size(117, 27);
            this.btnLoadCustomer.TabIndex = 18;
            this.btnLoadCustomer.Text = "View Customer";
            this.btnLoadCustomer.UseVisualStyleBackColor = true;
            this.btnLoadCustomer.Click += new System.EventHandler(this.btnLoadCustomer_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnViewCustItem);
            this.groupBox8.Controls.Add(this.btnAddCustItem);
            this.groupBox8.Controls.Add(this.btnViewCustVendor);
            this.groupBox8.Controls.Add(this.btnAddCustVendor);
            this.groupBox8.Controls.Add(this.label11);
            this.groupBox8.Controls.Add(this.label10);
            this.groupBox8.Controls.Add(this.txtCustomField);
            this.groupBox8.Controls.Add(this.txtCustomFieldName);
            this.groupBox8.Controls.Add(this.btnViewCustCustomer);
            this.groupBox8.Controls.Add(this.btnAddCustCustomer);
            this.groupBox8.Location = new System.Drawing.Point(551, 466);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(336, 187);
            this.groupBox8.TabIndex = 21;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Customer Custome Field";
            // 
            // btnViewCustItem
            // 
            this.btnViewCustItem.Location = new System.Drawing.Point(142, 140);
            this.btnViewCustItem.Name = "btnViewCustItem";
            this.btnViewCustItem.Size = new System.Drawing.Size(117, 32);
            this.btnViewCustItem.TabIndex = 35;
            this.btnViewCustItem.Text = "View Item";
            this.btnViewCustItem.UseVisualStyleBackColor = true;
            this.btnViewCustItem.Click += new System.EventHandler(this.btnViewCustItem_Click);
            // 
            // btnAddCustItem
            // 
            this.btnAddCustItem.Location = new System.Drawing.Point(6, 140);
            this.btnAddCustItem.Name = "btnAddCustItem";
            this.btnAddCustItem.Size = new System.Drawing.Size(117, 32);
            this.btnAddCustItem.TabIndex = 34;
            this.btnAddCustItem.Text = "Add Item";
            this.btnAddCustItem.UseVisualStyleBackColor = true;
            this.btnAddCustItem.Click += new System.EventHandler(this.btnAddCustItem_Click);
            // 
            // btnViewCustVendor
            // 
            this.btnViewCustVendor.Location = new System.Drawing.Point(142, 102);
            this.btnViewCustVendor.Name = "btnViewCustVendor";
            this.btnViewCustVendor.Size = new System.Drawing.Size(117, 32);
            this.btnViewCustVendor.TabIndex = 33;
            this.btnViewCustVendor.Text = "View Vendor";
            this.btnViewCustVendor.UseVisualStyleBackColor = true;
            this.btnViewCustVendor.Click += new System.EventHandler(this.btnViewCustVendor_Click);
            // 
            // btnAddCustVendor
            // 
            this.btnAddCustVendor.Location = new System.Drawing.Point(6, 102);
            this.btnAddCustVendor.Name = "btnAddCustVendor";
            this.btnAddCustVendor.Size = new System.Drawing.Size(117, 32);
            this.btnAddCustVendor.TabIndex = 32;
            this.btnAddCustVendor.Text = "Add Vendor";
            this.btnAddCustVendor.UseVisualStyleBackColor = true;
            this.btnAddCustVendor.Click += new System.EventHandler(this.btnAddCustVendor_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(139, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Custom Field";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Customer Name";
            // 
            // txtCustomField
            // 
            this.txtCustomField.Location = new System.Drawing.Point(142, 31);
            this.txtCustomField.Multiline = true;
            this.txtCustomField.Name = "txtCustomField";
            this.txtCustomField.Size = new System.Drawing.Size(117, 27);
            this.txtCustomField.TabIndex = 7;
            // 
            // txtCustomFieldName
            // 
            this.txtCustomFieldName.Location = new System.Drawing.Point(9, 31);
            this.txtCustomFieldName.Multiline = true;
            this.txtCustomFieldName.Name = "txtCustomFieldName";
            this.txtCustomFieldName.Size = new System.Drawing.Size(117, 27);
            this.txtCustomFieldName.TabIndex = 6;
            // 
            // btnViewCustCustomer
            // 
            this.btnViewCustCustomer.Location = new System.Drawing.Point(142, 64);
            this.btnViewCustCustomer.Name = "btnViewCustCustomer";
            this.btnViewCustCustomer.Size = new System.Drawing.Size(117, 32);
            this.btnViewCustCustomer.TabIndex = 5;
            this.btnViewCustCustomer.Text = "View Customer";
            this.btnViewCustCustomer.UseVisualStyleBackColor = true;
            this.btnViewCustCustomer.Click += new System.EventHandler(this.btnViewCustomerCustomField_Click);
            // 
            // btnAddCustCustomer
            // 
            this.btnAddCustCustomer.Location = new System.Drawing.Point(6, 64);
            this.btnAddCustCustomer.Name = "btnAddCustCustomer";
            this.btnAddCustCustomer.Size = new System.Drawing.Size(117, 32);
            this.btnAddCustCustomer.TabIndex = 4;
            this.btnAddCustCustomer.Text = "Add Customer";
            this.btnAddCustCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustCustomer.Click += new System.EventHandler(this.btnAddCustCustomer_Click);
            // 
            // btnSalesOrderBulkAdd
            // 
            this.btnSalesOrderBulkAdd.Location = new System.Drawing.Point(216, 164);
            this.btnSalesOrderBulkAdd.Name = "btnSalesOrderBulkAdd";
            this.btnSalesOrderBulkAdd.Size = new System.Drawing.Size(114, 32);
            this.btnSalesOrderBulkAdd.TabIndex = 23;
            this.btnSalesOrderBulkAdd.Text = "Bulk SalesOrder Add";
            this.btnSalesOrderBulkAdd.UseVisualStyleBackColor = true;
            this.btnSalesOrderBulkAdd.Click += new System.EventHandler(this.btnSalesOrderBulkAdd_Click);
            // 
            // btnBillBulkAdd
            // 
            this.btnBillBulkAdd.Location = new System.Drawing.Point(216, 244);
            this.btnBillBulkAdd.Name = "btnBillBulkAdd";
            this.btnBillBulkAdd.Size = new System.Drawing.Size(114, 32);
            this.btnBillBulkAdd.TabIndex = 24;
            this.btnBillBulkAdd.Text = "Bulk Bill Add";
            this.btnBillBulkAdd.UseVisualStyleBackColor = true;
            this.btnBillBulkAdd.Click += new System.EventHandler(this.btnBillBulkAdd_Click);
            // 
            // FormQuickBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 665);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.gvBill);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormQuickBook";
            this.Text = "FormQuickBook";
            this.Load += new System.EventHandler(this.FormQuickBook_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvBill)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSessionOpen;
        private System.Windows.Forms.Button btnSessionClose;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnViewBill;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnViewCustomer;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnInvoiceAdd;
        private System.Windows.Forms.Button btnViewInvoice;
        private System.Windows.Forms.Button btnItemAdd;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnViewItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbItem;
        private System.Windows.Forms.ComboBox cbCustomer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtItemQuantity;
        private System.Windows.Forms.Button btnBillAdd;
        private System.Windows.Forms.Button btnAddVendor;
        private System.Windows.Forms.TextBox txtVendorName;
        private System.Windows.Forms.Button btnViewVendor;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnAccountAdd;
        private System.Windows.Forms.Button btnViewAccount;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Button btnSalesOrderView;
        private System.Windows.Forms.Button btnSalesOrderAdd;
        private System.Windows.Forms.Button btnInvoiceBulkAdd;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DataGridView gvBill;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.TextBox txtMob;
        private System.Windows.Forms.TextBox txtModCustomerName;
        private System.Windows.Forms.Button btnUpdateCustomer;
        private System.Windows.Forms.TextBox txtCustomerQuickBookID;
        private System.Windows.Forms.Button btnLoadCustomer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEditSequence;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox txtCustomFieldName;
        private System.Windows.Forms.Button btnViewCustCustomer;
        private System.Windows.Forms.Button btnAddCustCustomer;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCustomField;
        private System.Windows.Forms.Button btnViewCustItem;
        private System.Windows.Forms.Button btnAddCustItem;
        private System.Windows.Forms.Button btnViewCustVendor;
        private System.Windows.Forms.Button btnAddCustVendor;
        private System.Windows.Forms.Button btnBillBulkAdd;
        private System.Windows.Forms.Button btnSalesOrderBulkAdd;
    }
}