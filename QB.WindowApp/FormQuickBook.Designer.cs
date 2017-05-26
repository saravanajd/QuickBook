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
            this.btnBill = new System.Windows.Forms.Button();
            this.gvBill = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.btnCustomerView = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnViewVendor = new System.Windows.Forms.Button();
            this.txtVendorName = new System.Windows.Forms.TextBox();
            this.btnAddVendor = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnViewItem = new System.Windows.Forms.Button();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.btnItemAdd = new System.Windows.Forms.Button();
            this.btnInvoiceView = new System.Windows.Forms.Button();
            this.btnInvoiceAdd = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
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
            this.btnAccountView = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.gvBill)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(6, 40);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(107, 32);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Open Connection";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSessionOpen
            // 
            this.btnSessionOpen.Location = new System.Drawing.Point(134, 40);
            this.btnSessionOpen.Name = "btnSessionOpen";
            this.btnSessionOpen.Size = new System.Drawing.Size(117, 32);
            this.btnSessionOpen.TabIndex = 1;
            this.btnSessionOpen.Text = "Session Open";
            this.btnSessionOpen.UseVisualStyleBackColor = true;
            this.btnSessionOpen.Click += new System.EventHandler(this.btnSessionOpen_Click);
            // 
            // btnSessionClose
            // 
            this.btnSessionClose.Location = new System.Drawing.Point(134, 87);
            this.btnSessionClose.Name = "btnSessionClose";
            this.btnSessionClose.Size = new System.Drawing.Size(117, 32);
            this.btnSessionClose.TabIndex = 2;
            this.btnSessionClose.Text = "Session Close";
            this.btnSessionClose.UseVisualStyleBackColor = true;
            this.btnSessionClose.Click += new System.EventHandler(this.btnSessionClose_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(6, 87);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 32);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close Connection";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.Location = new System.Drawing.Point(6, 87);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(117, 32);
            this.btnCustomer.TabIndex = 4;
            this.btnCustomer.Text = "Add Customer";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnBill
            // 
            this.btnBill.Location = new System.Drawing.Point(114, 242);
            this.btnBill.Name = "btnBill";
            this.btnBill.Size = new System.Drawing.Size(99, 32);
            this.btnBill.TabIndex = 5;
            this.btnBill.Text = "GetBill";
            this.btnBill.UseVisualStyleBackColor = true;
            this.btnBill.Click += new System.EventHandler(this.btnBill_Click);
            // 
            // gvBill
            // 
            this.gvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBill.Location = new System.Drawing.Point(6, 28);
            this.gvBill.Name = "gvBill";
            this.gvBill.Size = new System.Drawing.Size(579, 196);
            this.gvBill.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.btnSessionOpen);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnSessionClose);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 158);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connections";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCustomerName);
            this.groupBox2.Controls.Add(this.btnCustomerView);
            this.groupBox2.Controls.Add(this.btnCustomer);
            this.groupBox2.Location = new System.Drawing.Point(276, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 158);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(6, 43);
            this.txtCustomerName.Multiline = true;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(201, 27);
            this.txtCustomerName.TabIndex = 6;
            // 
            // btnCustomerView
            // 
            this.btnCustomerView.Location = new System.Drawing.Point(142, 87);
            this.btnCustomerView.Name = "btnCustomerView";
            this.btnCustomerView.Size = new System.Drawing.Size(117, 32);
            this.btnCustomerView.TabIndex = 5;
            this.btnCustomerView.Text = "View Customer";
            this.btnCustomerView.UseVisualStyleBackColor = true;
            this.btnCustomerView.Click += new System.EventHandler(this.btnCustomerView_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnViewVendor);
            this.groupBox3.Controls.Add(this.txtVendorName);
            this.groupBox3.Controls.Add(this.btnAddVendor);
            this.groupBox3.Location = new System.Drawing.Point(276, 189);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(269, 147);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ventor";
            // 
            // btnViewVendor
            // 
            this.btnViewVendor.Location = new System.Drawing.Point(142, 82);
            this.btnViewVendor.Name = "btnViewVendor";
            this.btnViewVendor.Size = new System.Drawing.Size(117, 32);
            this.btnViewVendor.TabIndex = 19;
            this.btnViewVendor.Text = "View Vendor";
            this.btnViewVendor.UseVisualStyleBackColor = true;
            this.btnViewVendor.Click += new System.EventHandler(this.btnViewVendor_Click);
            // 
            // txtVendorName
            // 
            this.txtVendorName.Location = new System.Drawing.Point(6, 38);
            this.txtVendorName.Multiline = true;
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.Size = new System.Drawing.Size(182, 27);
            this.txtVendorName.TabIndex = 10;
            // 
            // btnAddVendor
            // 
            this.btnAddVendor.Location = new System.Drawing.Point(6, 82);
            this.btnAddVendor.Name = "btnAddVendor";
            this.btnAddVendor.Size = new System.Drawing.Size(117, 32);
            this.btnAddVendor.TabIndex = 18;
            this.btnAddVendor.Text = "Add Vendor";
            this.btnAddVendor.UseVisualStyleBackColor = true;
            this.btnAddVendor.Click += new System.EventHandler(this.btnAddVendor_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.gvBill);
            this.groupBox4.Location = new System.Drawing.Point(18, 356);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(591, 206);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnViewItem);
            this.groupBox5.Controls.Add(this.txtItemName);
            this.groupBox5.Controls.Add(this.btnItemAdd);
            this.groupBox5.Location = new System.Drawing.Point(12, 189);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(258, 147);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Items";
            // 
            // btnViewItem
            // 
            this.btnViewItem.Location = new System.Drawing.Point(134, 82);
            this.btnViewItem.Name = "btnViewItem";
            this.btnViewItem.Size = new System.Drawing.Size(117, 32);
            this.btnViewItem.TabIndex = 9;
            this.btnViewItem.Text = "View Item";
            this.btnViewItem.UseVisualStyleBackColor = true;
            this.btnViewItem.Click += new System.EventHandler(this.btnViewItem_Click);
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(6, 38);
            this.txtItemName.Multiline = true;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(182, 27);
            this.txtItemName.TabIndex = 7;
            // 
            // btnItemAdd
            // 
            this.btnItemAdd.Location = new System.Drawing.Point(6, 82);
            this.btnItemAdd.Name = "btnItemAdd";
            this.btnItemAdd.Size = new System.Drawing.Size(117, 32);
            this.btnItemAdd.TabIndex = 8;
            this.btnItemAdd.Text = "Add Item";
            this.btnItemAdd.UseVisualStyleBackColor = true;
            this.btnItemAdd.Click += new System.EventHandler(this.btnItemAdd_Click);
            // 
            // btnInvoiceView
            // 
            this.btnInvoiceView.Location = new System.Drawing.Point(114, 126);
            this.btnInvoiceView.Name = "btnInvoiceView";
            this.btnInvoiceView.Size = new System.Drawing.Size(99, 32);
            this.btnInvoiceView.TabIndex = 7;
            this.btnInvoiceView.Text = "View Invoice";
            this.btnInvoiceView.UseVisualStyleBackColor = true;
            this.btnInvoiceView.Click += new System.EventHandler(this.btnInvoiceView_Click);
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
            this.groupBox6.Controls.Add(this.btnInvoiceView);
            this.groupBox6.Controls.Add(this.btnBill);
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
            this.groupBox7.Controls.Add(this.btnAccountView);
            this.groupBox7.Location = new System.Drawing.Point(615, 343);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(272, 117);
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
            // btnAccountView
            // 
            this.btnAccountView.Location = new System.Drawing.Point(134, 59);
            this.btnAccountView.Name = "btnAccountView";
            this.btnAccountView.Size = new System.Drawing.Size(117, 32);
            this.btnAccountView.TabIndex = 18;
            this.btnAccountView.Text = "View Accounts";
            this.btnAccountView.UseVisualStyleBackColor = true;
            this.btnAccountView.Click += new System.EventHandler(this.btnAccountView_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
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
            // dtTo
            // 
            this.dtTo.CustomFormat = "mm/dd/yyyy";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(114, 212);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(99, 20);
            this.dtTo.TabIndex = 22;
            // 
            // FormQuickBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 577);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormQuickBook";
            this.Text = "FormQuickBook";
            this.Load += new System.EventHandler(this.FormQuickBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvBill)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSessionOpen;
        private System.Windows.Forms.Button btnSessionClose;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnBill;
        private System.Windows.Forms.DataGridView gvBill;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCustomerView;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnInvoiceAdd;
        private System.Windows.Forms.Button btnInvoiceView;
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
        private System.Windows.Forms.Button btnAccountView;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Button btnSalesOrderView;
        private System.Windows.Forms.Button btnSalesOrderAdd;
        private System.Windows.Forms.Button btnInvoiceBulkAdd;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
    }
}