namespace POS.UI
{
    partial class Sales_Analytics
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales_Analytics));
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dt1 = new System.Windows.Forms.DateTimePicker();
            this.dt2 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvsalesanalytics = new System.Windows.Forms.DataGridView();
            this.tblproductdetailsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.posDataSet5 = new POS.posDataSet5();
            this.tblproductdetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.posDataSet3 = new POS.posDataSet3();
            this.btntoday = new System.Windows.Forms.Button();
            this.btnmonth = new System.Windows.Forms.Button();
            this.txtamount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtrevenue = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.tbl_productdetailsTableAdapter = new POS.posDataSet3TableAdapters.tbl_productdetailsTableAdapter();
            this.tbl_productdetailsTableAdapter1 = new POS.posDataSet5TableAdapters.tbl_productdetailsTableAdapter();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsalesanalytics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblproductdetailsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblproductdetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDataSet3)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(496, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 48);
            this.label2.TabIndex = 21;
            this.label2.Text = "Sales Analytics";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(41, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 25);
            this.label4.TabIndex = 24;
            this.label4.Text = "From:";
            // 
            // dt1
            // 
            this.dt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dt1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt1.Location = new System.Drawing.Point(110, 99);
            this.dt1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dt1.Name = "dt1";
            this.dt1.Size = new System.Drawing.Size(177, 26);
            this.dt1.TabIndex = 26;
            // 
            // dt2
            // 
            this.dt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dt2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt2.Location = new System.Drawing.Point(339, 97);
            this.dt2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dt2.Name = "dt2";
            this.dt2.Size = new System.Drawing.Size(192, 26);
            this.dt2.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(291, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 25);
            this.label5.TabIndex = 27;
            this.label5.Text = "To:";
            // 
            // dgvsalesanalytics
            // 
            this.dgvsalesanalytics.AllowUserToAddRows = false;
            this.dgvsalesanalytics.AllowUserToDeleteRows = false;
            this.dgvsalesanalytics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsalesanalytics.Location = new System.Drawing.Point(44, 144);
            this.dgvsalesanalytics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvsalesanalytics.Name = "dgvsalesanalytics";
            this.dgvsalesanalytics.ReadOnly = true;
            this.dgvsalesanalytics.RowHeadersWidth = 51;
            this.dgvsalesanalytics.RowTemplate.Height = 24;
            this.dgvsalesanalytics.Size = new System.Drawing.Size(951, 566);
            this.dgvsalesanalytics.TabIndex = 32;
            // 
            // tblproductdetailsBindingSource1
            // 
            this.tblproductdetailsBindingSource1.DataMember = "tbl_productdetails";
            this.tblproductdetailsBindingSource1.DataSource = this.posDataSet5;
            // 
            // posDataSet5
            // 
            this.posDataSet5.DataSetName = "posDataSet5";
            this.posDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblproductdetailsBindingSource
            // 
            this.tblproductdetailsBindingSource.DataMember = "tbl_productdetails";
            this.tblproductdetailsBindingSource.DataSource = this.posDataSet3;
            // 
            // posDataSet3
            // 
            this.posDataSet3.DataSetName = "posDataSet3";
            this.posDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btntoday
            // 
            this.btntoday.BackColor = System.Drawing.Color.DodgerBlue;
            this.btntoday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btntoday.ForeColor = System.Drawing.Color.White;
            this.btntoday.Location = new System.Drawing.Point(1005, 142);
            this.btntoday.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btntoday.Name = "btntoday";
            this.btntoday.Size = new System.Drawing.Size(125, 82);
            this.btntoday.TabIndex = 33;
            this.btntoday.Text = "Today,s Sale";
            this.btntoday.UseVisualStyleBackColor = false;
            this.btntoday.Click += new System.EventHandler(this.btntoday_Click);
            // 
            // btnmonth
            // 
            this.btnmonth.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnmonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnmonth.ForeColor = System.Drawing.Color.White;
            this.btnmonth.Location = new System.Drawing.Point(1168, 142);
            this.btnmonth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnmonth.Name = "btnmonth";
            this.btnmonth.Size = new System.Drawing.Size(123, 82);
            this.btnmonth.TabIndex = 34;
            this.btnmonth.Text = "Monthly Sale";
            this.btnmonth.UseVisualStyleBackColor = false;
            this.btnmonth.Click += new System.EventHandler(this.btnmonth_Click);
            // 
            // txtamount
            // 
            this.txtamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.txtamount.Location = new System.Drawing.Point(1005, 430);
            this.txtamount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtamount.Name = "txtamount";
            this.txtamount.ReadOnly = true;
            this.txtamount.Size = new System.Drawing.Size(285, 64);
            this.txtamount.TabIndex = 39;
            this.txtamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.Location = new System.Drawing.Point(1080, 401);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 25);
            this.label9.TabIndex = 38;
            this.label9.Text = "Total Sales";
            // 
            // txtrevenue
            // 
            this.txtrevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.txtrevenue.Location = new System.Drawing.Point(1005, 551);
            this.txtrevenue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtrevenue.Name = "txtrevenue";
            this.txtrevenue.ReadOnly = true;
            this.txtrevenue.Size = new System.Drawing.Size(285, 64);
            this.txtrevenue.TabIndex = 41;
            this.txtrevenue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.Location = new System.Drawing.Point(1080, 524);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 25);
            this.label10.TabIndex = 40;
            this.label10.Text = "Total Revenue";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DodgerBlue;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(1005, 645);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(285, 65);
            this.button4.TabIndex = 43;
            this.button4.Text = "Download Excel";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tbl_productdetailsTableAdapter
            // 
            this.tbl_productdetailsTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_productdetailsTableAdapter1
            // 
            this.tbl_productdetailsTableAdapter1.ClearBeforeFill = true;
            // 
            // cmbDoctor
            // 
            this.cmbDoctor.FormattingEnabled = true;
            this.cmbDoctor.Location = new System.Drawing.Point(678, 97);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(170, 24);
            this.cmbDoctor.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(572, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 45;
            this.label3.Text = "Select Doctor";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(867, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 38);
            this.button1.TabIndex = 46;
            this.button1.Text = "GO";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Sales_Analytics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1670, 953);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbDoctor);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtrevenue);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtamount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnmonth);
            this.Controls.Add(this.btntoday);
            this.Controls.Add(this.dgvsalesanalytics);
            this.Controls.Add(this.dt2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dt1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Sales_Analytics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales_Analytics";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Sales_Analytics_FormClosed);
            this.Load += new System.EventHandler(this.Sales_Analytics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvsalesanalytics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblproductdetailsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblproductdetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDataSet3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dt1;
        private System.Windows.Forms.DateTimePicker dt2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvsalesanalytics;
        private System.Windows.Forms.Button btntoday;
        private System.Windows.Forms.Button btnmonth;
        private System.Windows.Forms.TextBox txtamount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtrevenue;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button4;
       
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasepriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addedbyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addeddateDataGridViewTextBoxColumn;
        private posDataSet3 posDataSet3;
        private System.Windows.Forms.BindingSource tblproductdetailsBindingSource;
        private posDataSet3TableAdapters.tbl_productdetailsTableAdapter tbl_productdetailsTableAdapter;
        private posDataSet5 posDataSet5;
        private System.Windows.Forms.BindingSource tblproductdetailsBindingSource1;
        private posDataSet5TableAdapters.tbl_productdetailsTableAdapter tbl_productdetailsTableAdapter1;
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}