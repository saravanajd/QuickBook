namespace QB.WindowApplication
{
    partial class FormGeneralReport
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
            this.btnViewReport = new System.Windows.Forms.Button();
            this.gvReport = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // btnViewReport
            // 
            this.btnViewReport.Location = new System.Drawing.Point(12, 12);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(111, 34);
            this.btnViewReport.TabIndex = 0;
            this.btnViewReport.Text = "Generate Report";
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // gvReport
            // 
            this.gvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvReport.Location = new System.Drawing.Point(12, 52);
            this.gvReport.Name = "gvReport";
            this.gvReport.Size = new System.Drawing.Size(841, 438);
            this.gvReport.TabIndex = 1;
            // 
            // FormGeneralReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 502);
            this.Controls.Add(this.gvReport);
            this.Controls.Add(this.btnViewReport);
            this.Name = "FormGeneralReport";
            this.Text = "FormGeneralReport";
            ((System.ComponentModel.ISupportInitialize)(this.gvReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.DataGridView gvReport;
    }
}