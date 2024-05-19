using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.DAL;
using DGVPrinterHelper;
using POS.Utility;

namespace POS.UI
{
    public partial class ProductAnalytics : Form
    {
        private static ProductAnalytics _instance;

        public static ProductAnalytics instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ProductAnalytics();
                return _instance;
            }
        }
        public ProductAnalytics()
        {
            InitializeComponent();
             
            onLoad();
        }
        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        sales_analyticsdal dal = new sales_analyticsdal();


        double totalamount;
        double totalrevenue;
        double purchaseprice;
         

       
        private void onLoad()
        {
            dt1.Value = DateTime.Now;
            dt2.Value = System.DateTime.Now;

            PopulateGridWithData();
            SetValuesForSale_Profit();
        }

        private void ProductAnalytics_Load(object sender, EventArgs e)
        {

          
 
        }

        private void ProductAnalytics_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }    


        private void btntoday_Click(object sender, EventArgs e)
        {
            //To Create Variables for sale history 
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

        private void PopulateGridWithData()
        {
            DataTable dt = dal.ShowSalesByProduct((dt1.Value.AddDays(-1)).ToString(), (dt2.Value.AddDays(1)).ToString());
            dgvProductAnalytics.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //code to print Bill
            //DGVPrinter printer = new DGVPrinter();
            //printer.Title = "\r \r Time Paint & Hardware Store";
            //printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            //printer.PageNumbers = true;
            //printer.PageNumberInHeader = false;
            //printer.PorportionalColumns = true;
            //printer.HeaderCellAlignment = StringAlignment.Near;
            ////printer.Footer = "Products Sales History " + "\r \r \r \r \r \r \r \r \r \r \r \r \r \r \r \r \r \r" + "Total Quantity:" + txtquantity.Text + "\r \r \r \r \r \r \r \r \r \r \r \r \r \r \r \r \r \r" + "Total Amount:" + txtamount.Text + "\r \r \r \r \r \r \r \r \r \r \r \r \r \r \r \r \r \r" + "Total Revenue:" + txtrevenue.Text + "\r";
            //printer.FooterSpacing = 15;
            //printer.PrintDataGridView(dgvProductAnalytics);

            ExcelUtility utility = new ExcelUtility();
            utility.DownloadDataGridViewToExcel(dgvProductAnalytics,"ProductAnaylytics");
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            PopulateGridWithData();
            SetValuesForSale_Profit();
        }


        private void SetValuesForSale_Profit()
        {
            if(dgvProductAnalytics.Rows.Count > 0)
            {
                double[] sales = (from DataGridViewRow row in dgvProductAnalytics.Rows
                                  where row.Cells["Total"].FormattedValue.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells["Total"].FormattedValue)).ToArray();
                txtamount.Text = sales.Sum().ToString();

                ////To calculate total amount from table
                double[] profit = (from DataGridViewRow row in dgvProductAnalytics.Rows
                                   where row.Cells["Profit"].FormattedValue.ToString() != string.Empty
                                   select Convert.ToDouble(row.Cells["Profit"].FormattedValue)).ToArray();
                txtrevenue.Text = profit.Sum().ToString();

                double[] quantity = (from DataGridViewRow row in dgvProductAnalytics.Rows
                                     where row.Cells["Quantity"].FormattedValue.ToString() != string.Empty
                                     select Convert.ToDouble(row.Cells["Quantity"].FormattedValue)).ToArray();
                txtquantity.Text = quantity.Sum().ToString();
            }
            else
            {
                txtamount.Text = "0";
                txtrevenue.Text = "0";
                txtquantity.Text = "0";
            }
            ////To calculate total sales from table
            
        }
    }
}
