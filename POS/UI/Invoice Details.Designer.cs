namespace POS.UI
{
    partial class Invoice_Details
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
            this.txttotalamount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnmonth = new System.Windows.Forms.Button();
            this.btntoday = new System.Windows.Forms.Button();
            this.dgvinvoicedetails = new System.Windows.Forms.DataGridView();
            this.tblinvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.posDataSet4 = new POS.posDataSet4();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.dt2 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dt1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.tbl_invoiceTableAdapter = new POS.posDataSet4TableAdapters.tbl_invoiceTableAdapter();
            this.date_checkbox = new System.Windows.Forms.CheckBox();
            this.go_button = new System.Windows.Forms.Button();
            this.dgvDetailsInvoice = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_printInvoice = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvinvoicedetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblinvoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailsInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // txttotalamount
            // 
            this.txttotalamount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txttotalamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.txttotalamount.Location = new System.Drawing.Point(971, 578);
            this.txttotalamount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txttotalamount.Name = "txttotalamount";
            this.txttotalamount.ReadOnly = true;
            this.txttotalamount.Size = new System.Drawing.Size(285, 64);
            this.txttotalamount.TabIndex = 53;
            this.txttotalamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(1045, 549);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 25);
            this.label8.TabIndex = 52;
            this.label8.Text = "Total Amount";
            // 
            // btnmonth
            // 
            this.btnmonth.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnmonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnmonth.ForeColor = System.Drawing.Color.White;
            this.btnmonth.Location = new System.Drawing.Point(1133, 162);
            this.btnmonth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnmonth.Name = "btnmonth";
            this.btnmonth.Size = new System.Drawing.Size(123, 82);
            this.btnmonth.TabIndex = 51;
            this.btnmonth.Text = "Monthly Sale";
            this.btnmonth.UseVisualStyleBackColor = false;
            this.btnmonth.Click += new System.EventHandler(this.btnmonth_Click);
            // 
            // btntoday
            // 
            this.btntoday.BackColor = System.Drawing.Color.DodgerBlue;
            this.btntoday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btntoday.ForeColor = System.Drawing.Color.White;
            this.btntoday.Location = new System.Drawing.Point(971, 162);
            this.btntoday.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btntoday.Name = "btntoday";
            this.btntoday.Size = new System.Drawing.Size(125, 82);
            this.btntoday.TabIndex = 50;
            this.btntoday.Text = "Today,s Sale";
            this.btntoday.UseVisualStyleBackColor = false;
            this.btntoday.Click += new System.EventHandler(this.btntoday_Click);
            // 
            // dgvinvoicedetails
            // 
            this.dgvinvoicedetails.AllowUserToAddRows = false;
            this.dgvinvoicedetails.AllowUserToDeleteRows = false;
            this.dgvinvoicedetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvinvoicedetails.Location = new System.Drawing.Point(-1, 165);
            this.dgvinvoicedetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvinvoicedetails.Name = "dgvinvoicedetails";
            this.dgvinvoicedetails.ReadOnly = true;
            this.dgvinvoicedetails.RowHeadersWidth = 51;
            this.dgvinvoicedetails.RowTemplate.Height = 24;
            this.dgvinvoicedetails.Size = new System.Drawing.Size(952, 274);
            this.dgvinvoicedetails.TabIndex = 49;
            this.dgvinvoicedetails.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.invoice_doubleclick);
            // 
            // tblinvoiceBindingSource
            // 
            this.tblinvoiceBindingSource.DataMember = "tbl_invoice";
            this.tblinvoiceBindingSource.DataSource = this.posDataSet4;
            // 
            // posDataSet4
            // 
            this.posDataSet4.DataSetName = "posDataSet4";
            this.posDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtsearch
            // 
            this.txtsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtsearch.Location = new System.Drawing.Point(83, 66);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(457, 34);
            this.txtsearch.TabIndex = 48;
            // 
            // dt2
            // 
            this.dt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dt2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt2.Location = new System.Drawing.Point(1035, 64);
            this.dt2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dt2.Name = "dt2";
            this.dt2.Size = new System.Drawing.Size(217, 26);
            this.dt2.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(987, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 25);
            this.label5.TabIndex = 46;
            this.label5.Text = "To:";
            // 
            // dt1
            // 
            this.dt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dt1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt1.Location = new System.Drawing.Point(741, 66);
            this.dt1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dt1.Name = "dt1";
            this.dt1.Size = new System.Drawing.Size(217, 26);
            this.dt1.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(672, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 25);
            this.label4.TabIndex = 44;
            this.label4.Text = "From:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(11, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 43;
            this.label1.Text = "Search:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(461, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 48);
            this.label2.TabIndex = 42;
            this.label2.Text = "Invoice";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DodgerBlue;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(971, 666);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(285, 65);
            this.button4.TabIndex = 58;
            this.button4.Text = "Download Excel";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tbl_invoiceTableAdapter
            // 
            this.tbl_invoiceTableAdapter.ClearBeforeFill = true;
            // 
            // date_checkbox
            // 
            this.date_checkbox.AutoSize = true;
            this.date_checkbox.Location = new System.Drawing.Point(593, 72);
            this.date_checkbox.Name = "date_checkbox";
            this.date_checkbox.Size = new System.Drawing.Size(58, 20);
            this.date_checkbox.TabIndex = 59;
            this.date_checkbox.Text = "Date";
            this.date_checkbox.UseVisualStyleBackColor = true;
            this.date_checkbox.CheckedChanged += new System.EventHandler(this.checkbox_date_changed);
            // 
            // go_button
            // 
            this.go_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.go_button.Location = new System.Drawing.Point(1146, 112);
            this.go_button.Name = "go_button";
            this.go_button.Size = new System.Drawing.Size(106, 33);
            this.go_button.TabIndex = 60;
            this.go_button.Text = "GO";
            this.go_button.UseVisualStyleBackColor = false;
            this.go_button.Click += new System.EventHandler(this.go_button_Click);
            // 
            // dgvDetailsInvoice
            // 
            this.dgvDetailsInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailsInvoice.Location = new System.Drawing.Point(5, 513);
            this.dgvDetailsInvoice.Name = "dgvDetailsInvoice";
            this.dgvDetailsInvoice.RowHeadersWidth = 51;
            this.dgvDetailsInvoice.RowTemplate.Height = 24;
            this.dgvDetailsInvoice.Size = new System.Drawing.Size(946, 211);
            this.dgvDetailsInvoice.TabIndex = 61;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(414, 479);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 62;
            this.label3.Text = "Invoice Details";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(414, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 16);
            this.label6.TabIndex = 63;
            this.label6.Text = "Invoices";
            // 
            // btn_printInvoice
            // 
            this.btn_printInvoice.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_printInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btn_printInvoice.ForeColor = System.Drawing.Color.White;
            this.btn_printInvoice.Location = new System.Drawing.Point(971, 272);
            this.btn_printInvoice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_printInvoice.Name = "btn_printInvoice";
            this.btn_printInvoice.Size = new System.Drawing.Size(285, 65);
            this.btn_printInvoice.TabIndex = 64;
            this.btn_printInvoice.Text = "Print Invoice";
            this.btn_printInvoice.UseVisualStyleBackColor = false;
            this.btn_printInvoice.Click += new System.EventHandler(this.btn_printInvoice_Click);
            // 
            // Invoice_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1587, 845);
            this.Controls.Add(this.btn_printInvoice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvDetailsInvoice);
            this.Controls.Add(this.go_button);
            this.Controls.Add(this.date_checkbox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txttotalamount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnmonth);
            this.Controls.Add(this.btntoday);
            this.Controls.Add(this.dgvinvoicedetails);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.dt2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dt1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Invoice_Details";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice_Details";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Invoice_Details_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvinvoicedetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblinvoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailsInvoice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txttotalamount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnmonth;
        private System.Windows.Forms.Button btntoday;
        private System.Windows.Forms.DataGridView dgvinvoicedetails;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.DateTimePicker dt2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dt1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private posDataSet4 posDataSet4;
        private System.Windows.Forms.BindingSource tblinvoiceBindingSource;
        private posDataSet4TableAdapters.tbl_invoiceTableAdapter tbl_invoiceTableAdapter;
        private System.Windows.Forms.CheckBox date_checkbox;
        private System.Windows.Forms.Button go_button;
        private System.Windows.Forms.DataGridView dgvDetailsInvoice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_printInvoice;
    }
}