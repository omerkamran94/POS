using DGVPrinterHelper;
using POS.DAL;
using POS.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.UI
{
    public partial class Invoice_Details : Form
    {
        private static Invoice_Details _instance;

        public static Invoice_Details instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Invoice_Details();
                return _instance;
            }
        }
        public Invoice_Details()
        {
            InitializeComponent();
            onLoad();
        }

        invoicedetailsdal dal = new invoicedetailsdal();
        invoicedal dal1 = new invoicedal();
        PrinterUtility printerUtility = new PrinterUtility();
        private void onLoad()
        {
            dt1.Value = DateTime.Now;
            dt2.Value = System.DateTime.Now;
            //date_checkbox.Checked = false;

            dt1.Enabled= false;
            dt2.Enabled = false;
            btnmonth.Enabled = false;
            btntoday.Enabled = false;
            PopulateGridWithData();
            SetValuesForSale_Profit();
        }
        private void PopulateGridWithData()
        {            
            DataTable dt = dal1.BetweenTwoDates(txtsearch.Text.ToString(),(dt1.Value.AddDays(-1)).ToString(), (dt2.Value.AddDays(1)).ToString(), date_checkbox.Checked);
            dgvinvoicedetails.DataSource = dt;
            dgvDetailsInvoice.DataSource = null;           
        }
        public  object GetCellValueFromColumnHeader(DataGridViewCellCollection CellCollection, string HeaderText)
        {
            return CellCollection.Cast<DataGridViewCell>().First(c => c.OwningColumn.HeaderText == HeaderText).Value;
        }
        private void SetValuesForSale_Profit()
        {
            
            

 
            
        }
        private void Invoice_Details_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }

        

        
        

        

        private void btntoday_Click(object sender, EventArgs e)
        {
            dt1.Value = DateTime.Now;
            dt2.Value = System.DateTime.Now;

            PopulateGridWithData();
            SetValuesForSale_Profit();
        }

        private void btnmonth_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            dt1.Value = new DateTime(today.Year, today.Month, 1);
            dt2.Value = dt1.Value.AddMonths(1).AddDays(-1);

            PopulateGridWithData();
            SetValuesForSale_Profit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           

            //int selectedRowIndex = dgvinvoicedetails.CurrentCell.RowIndex;

            //string id  = dgvinvoicedetails.Rows[selectedRowIndex].Cells[2].Value.ToString();

            //DataTable table= new DataTable();
            //table = GetInvoiceDetailsById(id);


            ////code to print Bill
            //DGVPrinter printer = new DGVPrinter();
            //printer.Title = "\r \r Time Paint & Hardware Store";
            //printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            //printer.PageNumbers = true;
            //printer.PageNumberInHeader = false;
            //printer.PorportionalColumns = true;
            //printer.HeaderCellAlignment = StringAlignment.Near;
            //printer.Footer = "Invoice Sales History " + "\r \r \r \r \r \r \r \r \r \r \r \r \r \r \r \r \r \r" + "Total Amount:" + txttotalamount.Text + "\r \r \r \r \r \r \r \r \r \r \r \r \r \r \r \r \r \r" + "Due Amount:" + txtdueamount.Text + "\r \r \r \r \r \r \r \r \r \r \r \r \r \r \r \r \r \r" + "Change Amount:" + txtreturnamount.Text + "\r";
            //printer.FooterSpacing = 15;

            //DataGridView dataGridView = new DataGridView();
            //dataGridView.DataSource = table;

            ExcelUtility utility = new ExcelUtility();
            utility.DownloadDataGridViewToExcel(dgvinvoicedetails, "InvoiceDetails");


          //  printer.PrintDataGridView(dataGridView) ;

        }

        public DataTable GetInvoiceDetailsById(string id)
        {
            DataTable dt = new DataTable();
            product_detailsdal product_Detailsdal = new product_detailsdal();
            dt = product_Detailsdal.Search(id);
            dt.Columns.Remove("productdetailsid");
            dt.Columns.Remove("discount");
            dt.Columns.Remove("purchase_price");
            dt.Columns.Remove("type");
            dt.Columns.Remove("added_by");
            dt.Columns.Remove("added_date");


            return dt;

        }

        private void go_button_Click(object sender, EventArgs e)
        {
            PopulateGridWithData();
            SetValuesForSale_Profit();
        }

        private void checkbox_date_changed(object sender, EventArgs e)
        {
            if(date_checkbox.Checked)
            {
                dt1.Enabled= true;
                dt2.Enabled = true;
                btnmonth.Enabled = true;
                btntoday.Enabled = true;
                txtsearch.Enabled = false;
            }
            else
            {
                dt1.Enabled = false;
                dt2.Enabled = false;
                btnmonth.Enabled = false;
                btntoday.Enabled = false;
                txtsearch.Enabled = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void invoice_doubleclick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int ri = e.RowIndex;

            string inv_no = dgvinvoicedetails.Rows[ri].Cells["inv_no"].Value.ToString();

            dgvDetailsInvoice.DataSource = GetInvoiceDetailsById(inv_no);

            if (dgvDetailsInvoice.Rows.Count > 0)
            {
                double[] columnData = (from DataGridViewRow row in dgvDetailsInvoice.Rows
                                       where row.Cells["total"].FormattedValue.ToString() != string.Empty
                                       select Convert.ToDouble(row.Cells["total"].FormattedValue)).ToArray();
                txttotalamount.Text = columnData.Sum().ToString();
            }
            else
            {
                txttotalamount.Text = "0";
            }

        }

        private void btn_printInvoice_Click(object sender, EventArgs e)
        {
            if (dgvDetailsInvoice.Rows.Count > 0)
            {
                //printerUtility.PrintDocumentFromDataGridView(dgvDetailsInvoice);

                DataTable dt = new DataTable();
                dt = (DataTable)dgvDetailsInvoice.DataSource;

                //dt.Columns.Remove("productdetailsid");
                //dt.Columns.Remove("discount");
                //dt.Columns.Remove("purchase_price");
                //dt.Columns.Remove("type");
                //dt.Columns.Remove("added_by");
                //dt.Columns.Remove("added_date");

                dt.Columns.Remove("productid");
                dt.Columns.Remove("inv_no");
                dt.Columns.Remove("code");

                //printerUtility.PrintDocumentFromDataGridView(dgvDetailsInvoice);
                printerUtility.PrintDocumentFromDataTable(dt);
            }
            
        }
    }
}
