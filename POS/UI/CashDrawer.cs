using DGVPrinterHelper;
using POS.BLL;
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
    public partial class CashDrawer : Form
    {
        private static CashDrawer _instance;

        public static CashDrawer instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CashDrawer();
                return _instance;
            }
        }
        public CashDrawer()
        {
            InitializeComponent();
            onLoad();
        }

        CashDrawerDAL dal = new CashDrawerDAL();
        CashDrawerBLL cashDrawerBLL = new CashDrawerBLL();
        public ExpenseBLL expenseBLL = new ExpenseBLL();
        PrinterUtility printerUtility = new PrinterUtility();
        public void onLoad()
        {
            dt1.Value = DateTime.Now;
            dt2.Value = System.DateTime.Now;

            PopulateGridWithData();
            SetValuesForSale_Profit();
        }
        private void PopulateGridWithData()
        {            
            DataTable dt = dal.SearchBetweenDates((dt1.Value.AddDays(-1)).ToString(), (dt2.Value.AddDays(1)).ToString());
            dgvcashdrawer.DataSource = dt;
            
            dgvExpense.DataSource = null;           
        }
       
        private void SetValuesForSale_Profit()
        {
            
            

 
            
        }
        private void CashDrawer_FormClosed(object sender, FormClosedEventArgs e)
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
           

            ExcelUtility utility = new ExcelUtility();
            utility.DownloadDataGridViewToExcel(dgvcashdrawer, "CashDrawer");


          //  printer.PrintDataGridView(dataGridView) ;

        }

      

        private void go_button_Click(object sender, EventArgs e)
        {
            PopulateGridWithData();
            SetValuesForSale_Profit();
        }

       

        private void label3_Click(object sender, EventArgs e)
        {

        }

       
        private void btn_printInvoice_Click(object sender, EventArgs e)
        {
            if (dgvExpense.Rows.Count > 0)
            {
                //printerUtility.PrintDocumentFromDataGridView(dgvDetailsInvoice);

                DataTable dt = new DataTable();
                dt = (DataTable)dgvExpense.DataSource;


                dt.Columns.Remove("productid");
                dt.Columns.Remove("inv_no");
                dt.Columns.Remove("code");

                //printerUtility.PrintDocumentFromDataGridView(dgvDetailsInvoice);
                printerUtility.PrintDocumentFromDataTable(dt);
            }
            
        }

        private void cashdrawer_click(object sender, DataGridViewCellMouseEventArgs e)
        {
            int ri = e.RowIndex;

            string id = dgvcashdrawer.Rows[ri].Cells["CashDrawerId"].Value.ToString();

            DataTable table = new DataTable();
            table = dal.GetExpenseCashDrawerId(id);
            dgvExpense.DataSource = table;

            this.expenseBLL.CashDrawerId = Convert.ToInt32(dgvcashdrawer.Rows[ri].Cells["CashDrawerId"].Value.ToString());
            this.cashDrawerBLL.CashDrawerId = Convert.ToInt32(dgvcashdrawer.Rows[ri].Cells["CashDrawerId"].Value.ToString());
            this.cashDrawerBLL.CashDrawerStart = Convert.ToDecimal(dgvcashdrawer.Rows[ri].Cells["CashDrawerStart"].Value.ToString());
            this.cashDrawerBLL.CashDrawerAdded = Convert.ToDecimal(dgvcashdrawer.Rows[ri].Cells["CashDrawerAdded"].Value.ToString());
            this.cashDrawerBLL.CashDrawerRemoved = Convert.ToDecimal(dgvcashdrawer.Rows[ri].Cells["CashDrawerRemoved"].Value.ToString());
            //this.cashDrawerBLL.added_by = Convert.ToInt32(dgvcashdrawer.Rows[ri].Cells["CashDrawerId"].Value.ToString());
            //this.cashDrawerBLL.added_date = Convert.ToDateTime(dgvcashdrawer.Rows[ri].Cells["CashDrawerId"].Value.ToString());



            if (dgvExpense.Rows.Count > 0)
            {
                double[] columnData = (from DataGridViewRow row in dgvExpense.Rows
                                       where row.Cells["ExpenseAmount"].FormattedValue.ToString() != string.Empty
                                       select Convert.ToDouble(row.Cells["ExpenseAmount"].FormattedValue)).ToArray();
                txttotalamount.Text = columnData.Sum().ToString();
            }
            else
            {
                txttotalamount.Text = "0";
            }
        }

        private void cashdrawerdouble_click(object sender, DataGridViewCellMouseEventArgs e)
        {
            int ri = e.RowIndex;
            this.expenseBLL.CashDrawerId = Convert.ToInt32(dgvcashdrawer.Rows[ri].Cells["CashDrawerId"].Value.ToString());
            this.cashDrawerBLL.CashDrawerId = Convert.ToInt32(dgvcashdrawer.Rows[ri].Cells["CashDrawerId"].Value.ToString());
            this.cashDrawerBLL.CashDrawerStart = Convert.ToDecimal(dgvcashdrawer.Rows[ri].Cells["CashDrawerStart"].Value.ToString());
            this.cashDrawerBLL.CashDrawerAdded = Convert.ToDecimal(dgvcashdrawer.Rows[ri].Cells["CashDrawerAdded"].Value.ToString());
            this.cashDrawerBLL.CashDrawerRemoved = Convert.ToDecimal(dgvcashdrawer.Rows[ri].Cells["CashDrawerRemoved"].Value.ToString());
            //this.cashDrawerBLL.added_by = Convert.ToInt32(dgvcashdrawer.Rows[ri].Cells["CashDrawerId"].Value.ToString());
            //this.cashDrawerBLL.added_date = Convert.ToDateTime(dgvcashdrawer.Rows[ri].Cells["CashDrawerId"].Value.ToString());


            var form = new CashDrawerForm(this, cashDrawerBLL);
            form.Show();
        }

        private void expense_doubleclick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int ri = e.RowIndex;
            this.expenseBLL.CashDrawerId = Convert.ToInt32(dgvExpense.Rows[ri].Cells["CashDrawerId"].Value.ToString());
            this.expenseBLL.ExpenseId = Convert.ToInt32(dgvExpense.Rows[ri].Cells["ExpenseId"].Value.ToString());
            this.expenseBLL.ExpenseDescription = (dgvExpense.Rows[ri].Cells["ExpenseDescription"].Value.ToString());
            this.expenseBLL.ExpenseAmount = Convert.ToDecimal(dgvExpense.Rows[ri].Cells["ExpenseAmount"].Value.ToString());
            //this.expenseBLL.Type = Convert.ToDecimal(dgvcashdrawer.Rows[ri].Cells["Type"].Value.ToString());
            this.expenseBLL.added_by = Convert.ToInt32(dgvExpense.Rows[ri].Cells["added_by"].Value.ToString());
            this.expenseBLL.added_date = Convert.ToDateTime(dgvExpense.Rows[ri].Cells["added_date"].Value.ToString());

            var form = new ExpenseForm(this, this.expenseBLL);
            form.Show();

        }

        private void add_Cash_register(object sender, EventArgs e)
        {
            var form = new CashDrawerForm(this,cashDrawerBLL);
            form.Show();

        }
        private void ShowForm(Form f)
        {
            f.MdiParent = this;
            f.Show();
            f.Activate();
        }

        private void btn_Expense_Add(object sender, EventArgs e)
        {
            
            if(expenseBLL.CashDrawerId != 0)
            {
                var form = new ExpenseForm(this, expenseBLL);
                form.Show();
            }
            else
            {
                MessageBox.Show("Please select Cash Register First");
            }
                
     
            
        }
    }
}
