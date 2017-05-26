namespace QB.WindowApp
{
    partial class FormExcel
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
            this.gvExcel = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cmbTableName = new System.Windows.Forms.ComboBox();
            this.btnLoadExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // gvExcel
            // 
            this.gvExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvExcel.Location = new System.Drawing.Point(12, 118);
            this.gvExcel.Name = "gvExcel";
            this.gvExcel.Size = new System.Drawing.Size(709, 316);
            this.gvExcel.TabIndex = 0;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(205, 48);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cmbTableName
            // 
            this.cmbTableName.FormattingEnabled = true;
            this.cmbTableName.Location = new System.Drawing.Point(12, 50);
            this.cmbTableName.Name = "cmbTableName";
            this.cmbTableName.Size = new System.Drawing.Size(173, 21);
            this.cmbTableName.TabIndex = 2;
            // 
            // btnLoadExcel
            // 
            this.btnLoadExcel.Location = new System.Drawing.Point(12, 9);
            this.btnLoadExcel.Name = "btnLoadExcel";
            this.btnLoadExcel.Size = new System.Drawing.Size(119, 23);
            this.btnLoadExcel.TabIndex = 3;
            this.btnLoadExcel.Text = "Load Excel";
            this.btnLoadExcel.UseVisualStyleBackColor = true;
            this.btnLoadExcel.Click += new System.EventHandler(this.btnLoadExcel_Click);
            // 
            // FormExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 461);
            this.Controls.Add(this.btnLoadExcel);
            this.Controls.Add(this.cmbTableName);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.gvExcel);
            this.Name = "FormExcel";
            this.Text = "FormExcel";
            ((System.ComponentModel.ISupportInitialize)(this.gvExcel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvExcel;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ComboBox cmbTableName;
        private System.Windows.Forms.Button btnLoadExcel;
    }
}