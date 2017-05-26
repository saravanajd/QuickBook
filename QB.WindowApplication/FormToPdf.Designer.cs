namespace QB.WindowApplication
{
    partial class FormToPdf
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtShip = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBill = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.gvOrders = new System.Windows.Forms.DataGridView();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ship To";
            // 
            // txtShip
            // 
            this.txtShip.BackColor = System.Drawing.SystemColors.Window;
            this.txtShip.Location = new System.Drawing.Point(3, 40);
            this.txtShip.Name = "txtShip";
            this.txtShip.Size = new System.Drawing.Size(194, 113);
            this.txtShip.TabIndex = 1;
            this.txtShip.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtShip);
            this.panel1.Location = new System.Drawing.Point(12, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 156);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtBill);
            this.panel2.Location = new System.Drawing.Point(271, 122);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 156);
            this.panel2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Bill To";
            // 
            // txtBill
            // 
            this.txtBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBill.Location = new System.Drawing.Point(6, 40);
            this.txtBill.Name = "txtBill";
            this.txtBill.Size = new System.Drawing.Size(191, 113);
            this.txtBill.TabIndex = 1;
            this.txtBill.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(274, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Invoice NO: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(274, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date :";
            // 
            // txtInvoice
            // 
            this.txtInvoice.Location = new System.Drawing.Point(359, 51);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(112, 20);
            this.txtInvoice.TabIndex = 7;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(359, 86);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(112, 20);
            this.txtDate.TabIndex = 8;
            // 
            // gvOrders
            // 
            this.gvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvOrders.Location = new System.Drawing.Point(12, 320);
            this.gvOrders.Name = "gvOrders";
            this.gvOrders.Size = new System.Drawing.Size(459, 191);
            this.gvOrders.TabIndex = 9;
            // 
            // pbLogo
            // 
            this.pbLogo.BackgroundImage = global::QB.WindowApplication.Properties.Resources.logo;
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbLogo.ImageLocation = "C:\\Users\\ESTSYS\\Downloads\\Amazon\\logo.png";
            this.pbLogo.Location = new System.Drawing.Point(12, 51);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(97, 55);
            this.pbLogo.TabIndex = 10;
            this.pbLogo.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(372, 533);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(99, 23);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // FormToPdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 565);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.gvOrders);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtInvoice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormToPdf";
            this.Text = "FormToPdf";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtShip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtBill;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.DataGridView gvOrders;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnExport;
    }
}