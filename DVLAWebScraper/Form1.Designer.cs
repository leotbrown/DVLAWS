
namespace DVLAWebScraper
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.VehicleRegistration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RunButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.LoadExcel = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.ExportFolderDialog = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VehicleRegistration,
            this.TaxCol,
            this.DateCol});
            this.dataGridView1.Location = new System.Drawing.Point(58, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(619, 544);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // VehicleRegistration
            // 
            this.VehicleRegistration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VehicleRegistration.HeaderText = "Vehicle Registration";
            this.VehicleRegistration.MinimumWidth = 6;
            this.VehicleRegistration.Name = "VehicleRegistration";
            // 
            // TaxCol
            // 
            this.TaxCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TaxCol.HeaderText = "Taxation Status";
            this.TaxCol.MinimumWidth = 6;
            this.TaxCol.Name = "TaxCol";
            this.TaxCol.ReadOnly = true;
            // 
            // DateCol
            // 
            this.DateCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DateCol.HeaderText = "Date Due";
            this.DateCol.MinimumWidth = 6;
            this.DateCol.Name = "DateCol";
            this.DateCol.ReadOnly = true;
            // 
            // RunButton
            // 
            this.RunButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunButton.Location = new System.Drawing.Point(709, 88);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(173, 90);
            this.RunButton.TabIndex = 1;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(709, 194);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(173, 50);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(738, 563);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(126, 21);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Visible Browser";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // LoadExcel
            // 
            this.LoadExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LoadExcel.Location = new System.Drawing.Point(709, 473);
            this.LoadExcel.Name = "LoadExcel";
            this.LoadExcel.Size = new System.Drawing.Size(173, 50);
            this.LoadExcel.TabIndex = 4;
            this.LoadExcel.Text = "Load Sheet";
            this.LoadExcel.UseVisualStyleBackColor = true;
            this.LoadExcel.Click += new System.EventHandler(this.LoadExcel_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ExportButton.Location = new System.Drawing.Point(709, 410);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(173, 50);
            this.ExportButton.TabIndex = 5;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // ExportFolderDialog
            // 
            this.ExportFolderDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ExportFolderDialog.Location = new System.Drawing.Point(888, 410);
            this.ExportFolderDialog.Name = "ExportFolderDialog";
            this.ExportFolderDialog.Size = new System.Drawing.Size(43, 50);
            this.ExportFolderDialog.TabIndex = 6;
            this.ExportFolderDialog.Text = "...";
            this.ExportFolderDialog.UseVisualStyleBackColor = true;
            this.ExportFolderDialog.Click += new System.EventHandler(this.ExportFolderDialog_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ClearButton.Location = new System.Drawing.Point(709, 260);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(173, 50);
            this.ClearButton.TabIndex = 7;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 683);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ExportFolderDialog);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.LoadExcel);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "DVLA Web Scraper";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleRegistration;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCol;
        private System.Windows.Forms.Button LoadExcel;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Button ExportFolderDialog;
        private System.Windows.Forms.Button ClearButton;
    }
}

