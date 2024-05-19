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
    public partial class Sales_Analytics : Form
    {
        private static Sales_Analytics _instance;

        public static Sales_Analytics instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Sales_Analytics();
                return _instance;
            }
        }
        public Sales_Analytics()
        {
            InitializeComponent();
            fillDoctorDropDown();
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
        private string GetDoctor()
        {
            string doctors;
            if (((ComboboxItem)cmbDoctor.SelectedItem) == null)
            {
                doctors = null;
            }
            else
            {
                doctors = ((ComboboxItem)cmbDoctor.SelectedItem).Value.ToString();
            }

            return doctors;
        }

        private void fillDoctorDropDown()
        {
            DataTable table = new DataTable();
            Doctorsdal doctorsdal = new Doctorsdal();
            table = doctorsdal.selectList();
            ComboboxItem item = new ComboboxItem();
            item.Text = "All";
            item.Value = -1;
            cmbDoctor.Items.Add(item);
            item = new ComboboxItem();
            item.Text = "CASH";
            item.Value = 0;
            cmbDoctor.Items.Add(item);

            foreach (DataRow dr in table.Rows)
            {
                 item = new ComboboxItem();
                item.Text = dr["doctor"].ToString();
                item.Value = (int)dr["doctorsid"];
                cmbDoctor.Items.Add(item);
            }

           cmbDoctor.SelectedIndex = 0;

        }
        private void onLoad()
        {
            dt1.Value = DateTime.Now;
            dt2.Value = System.DateTime.Now;

            PopulateGridWithData();
            SetValuesForSale_Profit();
        }

        private void Sales_Analytics_Load(object sender, EventArgs e)
        {

          
 
        }

        private void Sales_Analytics_FormClosed(object sender, FormClosedEventArgs e)
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
            DataTable dt = dal.ShowSales(GetDoctor(), (dt1.Value.AddDays(-1)).ToString(), (dt2.Value.AddDays(1)).ToString());
            dgvsalesanalytics.DataSource = dt;
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
            //printer.PrintDataGridView(dgvsalesanalytics);

            ExcelUtility utility = new ExcelUtility();
            utility.DownloadDataGridViewToExcel(dgvsalesanalytics,"SalesAnaylytics");
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            PopulateGridWithData();
            SetValuesForSale_Profit();
        }


        private void SetValuesForSale_Profit()
        {
            if(dgvsalesanalytics.Rows.Count > 0)
            {
                double[] columnData = (from DataGridViewRow row in dgvsalesanalytics.Rows
                                       where row.Cells[2].FormattedValue.ToString() != string.Empty
                                       select Convert.ToDouble(row.Cells[2].FormattedValue)).ToArray();
                txtamount.Text = columnData.Sum().ToString();

                //To calculate total amount from table
                double[] columnData1 = (from DataGridViewRow row in dgvsalesanalytics.Rows
                                        where row.Cells[4].FormattedValue.ToString() != string.Empty
                                        select Convert.ToDouble(row.Cells[4].FormattedValue)).ToArray();
                txtrevenue.Text = columnData1.Sum().ToString();
            }
            else
            {
                txtamount.Text = "0";
                txtrevenue.Text = "0";
            }
            //To calculate total sales from table
           
        }
    }
}
