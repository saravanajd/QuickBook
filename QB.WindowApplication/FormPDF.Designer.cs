namespace QB.WindowApplication
{
    partial class FormPDF
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
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtShipTo = new System.Windows.Forms.RichTextBox();
            this.gvOrders = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInvoiceDate = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLogo
            // 
            this.pbLogo.Location = new System.Drawing.Point(449, 24);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(125, 54);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(251, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtShipTo);
            this.panel1.Location = new System.Drawing.Point(12, 101);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 144);
            this.panel1.TabIndex = 2;
            // 
            // txtShipTo
            // 
            this.txtShipTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtShipTo.Location = new System.Drawing.Point(6, 28);
            this.txtShipTo.Name = "txtShipTo";
            this.txtShipTo.Size = new System.Drawing.Size(191, 104);
            this.txtShipTo.TabIndex = 7;
            this.txtShipTo.Text = "";
            // 
            // gvOrders
            // 
            this.gvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvOrders.Location = new System.Drawing.Point(12, 458);
            this.gvOrders.Name = "gvOrders";
            this.gvOrders.Size = new System.Drawing.Size(555, 208);
            this.gvOrders.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // txtInvoiceDate
            // 
            this.txtInvoiceDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInvoiceDate.Location = new System.Drawing.Point(18, 275);
            this.txtInvoiceDate.Name = "txtInvoiceDate";
            this.txtInvoiceDate.Size = new System.Drawing.Size(203, 132);
            this.txtInvoiceDate.TabIndex = 6;
            this.txtInvoiceDate.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(394, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // FormPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 711);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInvoiceDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gvOrders);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pbLogo);
            this.Name = "FormPDF";
            this.Text = "FormPDF";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gvOrders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtShipTo;
        private System.Windows.Forms.RichTextBox txtInvoiceDate;
        private System.Windows.Forms.Label label2;
    }
}