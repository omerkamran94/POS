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
using DGVPrinterHelper;
using POS.BLL;
using POS.DAL;
using POS.Utility;

namespace POS.UI.Sales_Man
{
    public partial class Sale_Register : Form
    {
        private static Sale_Register _instance;

        public static Sale_Register instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Sale_Register();
                return _instance;
            }
        }
        public Sale_Register()
        {
            InitializeComponent();
            fillDoctorDropDown();
        }
        DataTable table = new DataTable();
        Manage_Productsbll u = new Manage_Productsbll();
        Manage_Productsdal dal = new Manage_Productsdal();
        invoicebll inbll = new invoicebll();
        invoicedal indal = new invoicedal();
        userdal user = new userdal();
        product_detailsdal prdal = new product_detailsdal();
        product_detailsbll prbll = new product_detailsbll();
        string item = "";
        string quantity = "";
        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        private string _barcode = "";
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            char c = (char)keyData;

            if (char.IsNumber(c))
                _barcode += c;


            if (c == (char)Keys.Return)
            {
                DoSomethingWithBarcode(_barcode);
                _barcode = "";
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        public bool DoSomethingWithBarcode(string barcode)
        {
            btnadd_Scanner(barcode);
            return true;
        }
        private void fillDoctorDropDown()
        {
            DataTable table = new DataTable();
            Doctorsdal doctorsdal = new Doctorsdal();
            table = doctorsdal.selectList();

            foreach (DataRow dr in table.Rows)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = dr["doctor"].ToString();
                item.Value = (int)dr["doctorsid"];
                cmbcustomer.Items.Add(item);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Celar the Data Grid View and Clear all the TExtboxes
            dgvinvoice.DataSource = null;
            dgvinvoice.Rows.Clear();

            txttotal.Text = "";
            txtdiscount.Text = "";
            txtsubtotal.Text = "";
            txtpaidamount.Text = "";
            txtdueamount.Text = "";
            txtchangeamount.Text = "";
            cmbcustomer.Text = "";
            txtcomment.Text = "0";
        }

        private void Sale_Register_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet2.tbl_stock' table. You can move, or remove it, as needed.
            //this.tbl_stockTableAdapter.Fill(this.posDataSet2.tbl_stock);
            DataTable dt = dal.selectPublic();
            dgvstock.DataSource = dt;

            table.Columns.Add("Item Name", typeof(string));
            table.Columns.Add("Code", typeof(string));
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Price", typeof(string));
            table.Columns.Add("Quantity", typeof(string));
            table.Columns.Add("Total", typeof(string));
            dgvinvoice.DataSource = table;
            dgvinvoice.Columns[0].Width = 90;
            dgvinvoice.Columns[1].Width = 40;
            dgvinvoice.Columns[2].Width = 65;
            dgvinvoice.Columns[3].Width = 60;
            dgvinvoice.Columns[4].Width = 40;
            dgvinvoice.Columns[5].Width = 60;
            ToGetInvoiceID();
        }

        //bool updatedgv = false;
        bool update = false;
        double qty;
        double price;
        double purchaseprice;
        string type;
        string code;
        private void dgvstock_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int ri = e.RowIndex;
            qty = Convert.ToDouble(dgvstock.Rows[ri].Cells[8].Value);
            if (qty <= 0)
            {
                MessageBox.Show("Product quantity is zero. Please update stock");
            }
            //else if (dgvinvoice.Rows.Count > 0 && Convert.ToDouble(dgvinvoice.Rows[ri].Cells[4].Value) >= qty)
            //{
            //    MessageBox.Show("No More Stock Available for this product");
            //}
            else
            {
                txtitemname.Text = dgvstock.Rows[ri].Cells[1].Value.ToString();
                txtprice.Text = dgvstock.Rows[ri].Cells[6].Value.ToString();
                type = dgvstock.Rows[ri].Cells[7].Value.ToString();
                code = dgvstock.Rows[ri].Cells[2].Value.ToString();

                txtquantity.Text = "1";
                if (!update)
                {
                    try
                    {
                        update = true;
                        if (string.IsNullOrWhiteSpace(txtquantity.Text))
                        {
                            txttotal1.Clear();
                            return;
                        }

                        price = Convert.ToDouble(txtprice.Text);
                        txttotal1.Text = ((Convert.ToDouble(txtquantity.Text)) * price).ToString();

                    }
                    finally
                    {
                        update = false;
                    }
                }
                AddToInvoice();
            }


        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtsearch.Text;
            if (keyword != null)
            {
                DataTable dt = dal.SearchPublic(keyword);
                dgvstock.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.selectPublic();
                dgvstock.DataSource = dt;
            }
        }


        private void txtquantity_TextChanged(object sender, EventArgs e)
        {
            if (!update)
            {
                try
                {
                    update = true;
                    if (string.IsNullOrWhiteSpace(txtquantity.Text))
                    {
                        txttotal1.Clear();
                        return;
                    }

                    //price = Convert.ToDouble(txtprice.Text);

                    //txttotal1.Text = ((Convert.ToDouble(txtquantity.Text)) * price).ToString();
                    //purchaseprice = ((Convert.ToDouble(txtquantity.Text)) * purchaseprice);
                }
                finally
                {
                    update = false;
                }
            }



        }

        private void Sale_Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }

      

        private void btn_update(object sender, EventArgs e)
        {
            if(item != null && item!="")
            {
                foreach (DataRow dr in table.Rows)
                {
                    if (dr["Item Name"].ToString() == item)
                    {
                        if (Convert.ToDouble(txtquantity.Text)   > GetProductQuantityInStock(item))
                        {
                            MessageBox.Show("No More Stock Available for this Item");
                        }
                        else
                        {
                            dr["Quantity"] = txtquantity.Text;
                            dr["Total"] = Convert.ToDouble(dr["Quantity"]) * Convert.ToDouble(dr["Price"]);
                        }

                    }
                }

                SetValueForAllFields();
                item = "";
                quantity = "";
            }
            
        }
        private double GetProductQuantityInStock(string name)
        {
            double qty = 0;
            DataTable dataTable= new DataTable();

            dataTable = (DataTable)dgvstock.DataSource;

            foreach (DataRow dr in dataTable.Rows)
            {
                if (dr["product_name"].ToString() == name)
                {
                    qty = Convert.ToDouble(dr["Quantity"]);
                    break;
                }
            }

            return qty;

        }
        //double sum = 0;
        private void AddToInvoice()
        {
            if (Validation())
            {
                if (Convert.ToDouble(txtquantity.Text) > qty)
                {
                    MessageBox.Show("Your entered quantity is greater than quantity in stock");
                    txtquantity.Text = "1";
                }
                else if (Convert.ToDouble(txtquantity.Text) == 0)
                {
                    MessageBox.Show("Please enter product quantity");
                    txtquantity.Text = "1";
                }
                else
                {


                    var item = new
                    {
                        Item = txtitemname.Text,
                        Code = code,
                        Type = type,
                        Price = txtprice.Text,
                        Qty = txtquantity.Text,
                        Total = txttotal1.Text
                    };



                    bool contains = table.AsEnumerable().Any(row => item.Item == row.Field<String>("Item Name"));

                    if (contains)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            if (row["Item Name"].ToString() == item.Item)
                            {
                                if (Convert.ToDouble(row["Quantity"]) + 1 > qty)
                                {
                                    MessageBox.Show("No More Stock Available for this Item");
                                }
                                else
                                {
                                    row["Quantity"] = Convert.ToDouble(item.Qty) + Convert.ToDouble(row["Quantity"]);
                                    row["Total"] = Convert.ToDouble(row["Quantity"]) * Convert.ToDouble(row["Price"]);
                                }

                            }
                        }
                    }
                    else
                    {
                        table.Rows.Add(item.Item, item.Code, item.Type, item.Price, item.Qty, item.Total);
                    }



                    SetValueForAllFields();



                }
            }

        }
        public void SetValueForAllFields()
        {
            double[] columnData = (from DataGridViewRow row in dgvinvoice.Rows
                                   where row.Cells[5].FormattedValue.ToString() != string.Empty
                                   select Convert.ToDouble(row.Cells[5].FormattedValue)).ToArray();

            txttotal.Text = columnData.Sum().ToString();

            dgvinvoice.DataSource = table;
            clear();




            if (string.IsNullOrEmpty(txtdiscount.Text))
            {
                txtdiscount.Text = "0";
                txtsubtotal.Text = txttotal.Text;
            }
            else
            {

                if (!updatedisc)
                {
                    try
                    {
                        updatedisc = true;
                        if (string.IsNullOrWhiteSpace(txtdiscount.Text))
                        {
                            txtsubtotal.Clear();
                            return;
                        }
                        txtsubtotal.Text = ((double.Parse(txttotal.Text)) - ((double.Parse(txttotal.Text) * double.Parse(txtdiscount.Text)) / 100)).ToString();
                        txtdueamount.Text = txtsubtotal.Text;
                    }
                    finally
                    {
                        updatedisc = false;
                    }
                }
            }


            if (string.IsNullOrEmpty(txtpaidamount.Text))
            {
                txtpaidamount.Text = "0";
                txtdueamount.Text = txtsubtotal.Text;
            }
            else
            {
                if (!updatepaid)
                {
                    try
                    {
                        updatepaid = true;
                        if (string.IsNullOrEmpty(txtpaidamount.Text))
                        {
                            txtchangeamount.Clear();
                            txtdueamount.Clear();
                            return;
                        }
                        paidamount = double.Parse(txtpaidamount.Text);
                        totalpayable = double.Parse(txtsubtotal.Text);
                        if (paidamount == totalpayable)
                        {
                            txtdueamount.Text = "0";
                            txtchangeamount.Text = "0";
                        }

                        if (paidamount > totalpayable)
                        {
                            txtdueamount.Text = "0";
                            txtchangeamount.Text = (paidamount - totalpayable).ToString();
                        }
                        if (paidamount < totalpayable)
                        {
                            txtchangeamount.Text = "0";
                            txtdueamount.Text = (totalpayable - paidamount).ToString();
                        }
                    }
                    finally
                    {
                        updatepaid = false;
                    }
                }
            }
        }
        private void btnadd_Scanner(string code)
        {
            DataTable dt = new DataTable();
            dt = dal.SearchBarcode(code);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                var item = new
                {
                    Item = dr["product_name"].ToString(),
                    Code = dr["code"].ToString(),
                    Type = dr["type"].ToString(),
                    Price = dr["retail_price"].ToString(),
                    Qty = "1",
                    Total = dr["retail_price"].ToString()
                };

                qty = Convert.ToDouble(dr["quantity"].ToString());

                bool contains = table.AsEnumerable().Any(row => item.Item == row.Field<String>("Item Name"));

                if (contains)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        if (row["Item Name"].ToString() == item.Item)
                        {
                            if (Convert.ToDouble(row["Quantity"]) + 1 > qty)
                            {
                                MessageBox.Show("No More Stock Available for this Item");
                            }
                            else
                            {
                                row["Quantity"] = Convert.ToDouble(item.Qty) + Convert.ToDouble(row["Quantity"]);
                                row["Total"] = Convert.ToDouble(row["Quantity"]) * Convert.ToDouble(row["Price"]);
                            }

                        }
                    }
                }
                else
                {
                    table.Rows.Add(item.Item, item.Code, item.Type, item.Price, item.Qty, item.Total);
                }



                //Calculate total invoice from the InvoiceGridView

                SetValueForAllFields();


            }

        }

        private void dgvinvoice_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {

        }

        private void clear()
        {
            txtitemname.Text = "";
            txtprice.Text = "";
            txtquantity.Text = "";
            txttotal1.Text = "";
          //  table.Rows.Clear();
        }

        private bool Validation()
        {
            bool result = false;
            if (String.IsNullOrEmpty(txtitemname.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtitemname, "Product Name Required");
            }
            else if (String.IsNullOrEmpty(txtprice.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtprice, "Ptoduct Price Required");
            }
            else if (String.IsNullOrEmpty(txtquantity.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtquantity, "Quantity Required");
            }
            else if (String.IsNullOrEmpty(txttotal1.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txttotal1, "Total Required");
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            return result;
        }


        private void txttotal_TextChanged(object sender, EventArgs e)
        {
            //double sum = 0;
            //for (int i = 0; i <= dgvinvoice.Rows.Count; i++)
            //{
            //    sum += Convert.ToDouble(dgvinvoice.Rows[i].Cells[3].Value);
            //}
            //txttotal.Text = sum.ToString();



        }

        private void dgvinvoice_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            quantity = "";
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvinvoice.Rows[e.RowIndex];
                txtquantity.Text = row.Cells["Quantity"].Value.ToString();
                item = row.Cells["Item Name"].Value.ToString();
                quantity = txtquantity.Text;


            }
        }

        private void dgvinvoice_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int ri = dgvinvoice.CurrentCell.RowIndex;
            dgvinvoice.Rows.RemoveAt(ri);

            double[] columnData = (from DataGridViewRow row in dgvinvoice.Rows
                                   where row.Cells[5].FormattedValue.ToString() != string.Empty
                                   select Convert.ToDouble(row.Cells[5].FormattedValue)).ToArray();

            txttotal.Text = columnData.Sum().ToString();
            if (string.IsNullOrEmpty(txtdiscount.Text))
            {
                txtdiscount.Text = "0";
                txtsubtotal.Text = txttotal.Text;
                txtdueamount.Text = txtsubtotal.Text;

            }
            else
            {

                if (!updatedisc)
                {
                    try
                    {
                        updatedisc = true;
                        if (string.IsNullOrWhiteSpace(txtdiscount.Text))
                        {
                            txtsubtotal.Clear();
                            return;
                        }
                        txtsubtotal.Text = ((double.Parse(txttotal.Text)) - ((double.Parse(txttotal.Text) * double.Parse(txtdiscount.Text)) / 100)).ToString();
                        txtdueamount.Text = txtsubtotal.Text;
                    }
                    finally
                    {
                        updatedisc = false;
                    }
                }
            }

            if (string.IsNullOrEmpty(txtpaidamount.Text))
            {
                txtpaidamount.Text = "0";
                txtdueamount.Text = txtsubtotal.Text;

            }
            else
            {
                if (!updatepaid)
                {
                    try
                    {
                        updatepaid = true;
                        if (string.IsNullOrEmpty(txtpaidamount.Text))
                        {
                            txtchangeamount.Clear();
                            txtdueamount.Clear();
                            return;
                        }
                        paidamount = double.Parse(txtpaidamount.Text);
                        totalpayable = double.Parse(txtsubtotal.Text);
                        if (paidamount == totalpayable)
                        {
                            txtdueamount.Text = "0";
                            txtchangeamount.Text = "0";
                        }

                        if (paidamount > totalpayable)
                        {
                            txtdueamount.Text = "0";
                            txtchangeamount.Text = (paidamount - totalpayable).ToString();
                        }
                        if (paidamount < totalpayable)
                        {
                            txtchangeamount.Text = "0";
                            txtdueamount.Text = (totalpayable - paidamount).ToString();
                        }
                    }
                    finally
                    {
                        updatepaid = false;
                    }
                }
            }
        }
        bool updatedisc = false;

        private void txtdiscount_TextChanged(object sender, EventArgs e)
        {
            if (!updatedisc)
            {
                try
                {
                    updatedisc = true;
                    if (string.IsNullOrWhiteSpace(txtdiscount.Text))
                    {
                        txtsubtotal.Clear();
                        return;
                    }


                    txtsubtotal.Text = ((double.Parse(txttotal.Text)) - ((double.Parse(txttotal.Text) * double.Parse(txtdiscount.Text)) / 100)).ToString();

                    //if (string.IsNullOrEmpty(txtpaidamount.Text))
                    //{
                    //    txtdueamount.Text = txtsubtotal.Text;
                    //}
                    if (!updatepaid)
                    {
                        try
                        {
                            updatepaid = true;
                            if (string.IsNullOrEmpty(txtpaidamount.Text))
                            {
                                //txtchangeamount.Clear();
                                //txtdueamount.Clear();
                                txtdueamount.Text = txtsubtotal.Text;
                                return;
                            }
                            paidamount = double.Parse(txtpaidamount.Text);
                            totalpayable = double.Parse(txtsubtotal.Text);
                            if (paidamount == totalpayable)
                            {
                                txtdueamount.Text = "0";
                                txtchangeamount.Text = "0";
                            }

                            if (paidamount > totalpayable)
                            {
                                txtdueamount.Text = "0";
                                txtchangeamount.Text = (paidamount - totalpayable).ToString();
                            }
                            if (paidamount < totalpayable)
                            {
                                txtchangeamount.Text = "0";
                                txtdueamount.Text = (totalpayable - paidamount).ToString();
                            }
                        }
                        finally
                        {
                            updatepaid = false;
                        }
                    }

                }
                finally
                {
                    updatedisc = false;
                }
            }
        }

        bool updatepaid = false;
        double paidamount = 0;
        double totalpayable = 0;
        private void txtpaidamount_TextChanged(object sender, EventArgs e)
        {
            if (!updatepaid)
            {
                try
                {
                    updatepaid = true;
                    if (string.IsNullOrEmpty(txtpaidamount.Text))
                    {
                        txtchangeamount.Clear();
                        txtdueamount.Clear();
                        return;
                    }
                    paidamount = double.Parse(txtpaidamount.Text);
                    totalpayable = double.Parse(txtsubtotal.Text);
                    if (paidamount == totalpayable)
                    {
                        txtdueamount.Text = "0";
                        txtchangeamount.Text = "0";
                    }

                    if (paidamount > totalpayable)
                    {
                        txtdueamount.Text = "0";
                        txtchangeamount.Text = (paidamount - totalpayable).ToString();
                    }
                    if (paidamount < totalpayable)
                    {
                        txtchangeamount.Text = "0";
                        txtdueamount.Text = (totalpayable - paidamount).ToString();
                    }
                }
                finally
                {
                    updatepaid = false;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtitemname.Text = "";
            txtprice.Text = "";
            txtquantity.Text = "";
            txttotal1.Text = "";
            txttotal.Text = "";
            txtsubtotal.Text = "";
            txtdueamount.Text = "";
            table.Rows.Clear();
        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {

        }

        decimal quantity1;
        double t1, t2;
        private void btncomplete_Click(object sender, EventArgs e)
        {
            if (Validation1())
            {
                //printPreviewDialog1.Document = printDocument1;
                //printPreviewDialog1.ShowDialog();


                //Gettting Data FRom UI
                inbll.inv_no = Convert.ToInt32(lblinvoiceno.Text);
                inbll.customer_name = cmbcustomer.Text;
                inbll.total_payable = txtsubtotal.Text;
                inbll.paid_amount = txtpaidamount.Text;
                inbll.discount = txtdiscount.Text;
                inbll.due_amount = txtdueamount.Text;
                inbll.change_amount = txtchangeamount.Text;
                inbll.sales_date = DateTime.Now;



                if (cmbcustomer.SelectedItem == null)
                {
                    inbll.doctorsid = 0;
                }
                else
                {
                    inbll.doctorsid = ((ComboboxItem)cmbcustomer.SelectedItem).Value;
                }

                //Getting Username of the logged in user
                string loggedUser = Login.loggedIn;
                usersbll usr = user.GetIDFromUsername(loggedUser);
                inbll.added_by = usr.usersid;
                //Inserting Data into DAtabase
                bool w = indal.insert(inbll);
                bool sucess = false;

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    bool x = false;
                    //Get the Product name and convert it to id
                    string ProductName = table.Rows[i][0].ToString();
                    string type1 = table.Rows[i][2].ToString();
                    string ccode = table.Rows[i][1].ToString();
                    Manage_Productsbll p = dal.GetProductIDFromName(ProductName, type1, ccode);
                    prbll.productid = p.stockid;

                    prbll.product_name = table.Rows[i][0].ToString();
                    prbll.type = table.Rows[i][2].ToString();
                    prbll.price = table.Rows[i][3].ToString();
                    prbll.quantity = table.Rows[i][4].ToString();
                    //prbll.code = Convert.ToInt32( table.Rows[i][1]);
                    prbll.discount = txtdiscount.Text;
                    //prbll.total = table.Rows[i][3].ToString();
                    //Getting total value by calculating discount
                    t1 = Convert.ToDouble(txtdiscount.Text);
                    t2 = Convert.ToDouble(table.Rows[i][5]);
                    prbll.total = (t2 - (t2 * t1) / 100).ToString();

                    //Method to get purchase price an multiply it with quantity
                    Manage_Productsbll pr = dal.GetProductpriceFromId(p.stockid.ToString());
                    purchaseprice = Convert.ToDouble(pr.purchase_price);
                    prbll.purchase_price = ((Convert.ToDouble(table.Rows[i][4])) * purchaseprice).ToString();

                    prbll.inv_no = lblinvoiceno.Text;
                    prbll.added_by = usr.usersid;
                    prbll.added_date = DateTime.Now;

                    quantity1 = Convert.ToDecimal(prbll.quantity);

                    // Decreasing product quantity in DAtabase
                    bool y = false;
                    y = dal.DecreaseProduct(prbll.productid, quantity1);

                    // Inserting Data into DAtabase
                    x = prdal.insert(prbll);
                    sucess = w && x && y;
                }

                if (sucess == true)
                {
                    PrinterUtility printerUtility = new PrinterUtility();
                    printerUtility.PrintDocumentFromDataGridView(dgvinvoice);
                    //code to print Bill
                    //DGVPrinter printer = new DGVPrinter();
                    //printer.Title = "\r \r Hardware Store";
                    //printer.SubTitle = "Khokhar Plaza, Near Alied Bank, Main Behria Enclave Road \r \n Phone: 031659007044 \r \r \r \r \r \r Invoice #:" + lblinvoiceno.Text + "\r";
                    //printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    //printer.PageNumbers = true;
                    //printer.PageNumberInHeader = false;
                    //printer.PorportionalColumns = true;
                    //printer.HeaderCellAlignment = StringAlignment.Near;
                    //printer.Footer = "Grand Total: " + txtsubtotal.Text + " \r \r \r \r \r \r \r \r \r \r \r \r" + "Total Paid:" + txtpaidamount.Text + " \r \n" + "Thank You, for doing business with us. \n";
                    ////printer.PageText = "Developed By: \r \r \r Engr. Azhar Mir \r \r \r \r \r \r \r \r \r Mailing Contact: \r \r \r azharmir526@live.com \n";
                    //printer.FooterSpacing = 2;
                    //printer.PrintDataGridView(dgvinvoice);


                    MessageBox.Show("Transaction Completed Sucessfully");

                    //Celar the Data Grid View and Clear all the TExtboxes
                    dgvinvoice.DataSource = null;
                    dgvinvoice.Rows.Clear();
                    table.Rows.Clear();
                    txttotal.Text = "";
                    txtdiscount.Text = "";
                    txtsubtotal.Text = "";
                    txtpaidamount.Text = "";
                    txtdueamount.Text = "";
                    txtchangeamount.Text = "";
                    cmbcustomer.Text = "";
                    txtcomment.Text = "0";
                    //To refresh stock in Data grid view
                    DataTable dt = dal.selectPublic();
                    dgvstock.DataSource = dt;

                    ToGetInvoiceID();
                }
                else
                {
                    //Transaction Failed
                    MessageBox.Show("Transaction Failed");
                }
            }


        }

        private void txtdueamount_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbcustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtchangeamount_TextChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //    e.Graphics.DrawString("Welcome To Times paint House",new Font("Ariel",25,FontStyle.Bold),Brushes.Red,new Point(150,30));
            //    e.Graphics.DrawString("Date:", new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(5, 90));
            //    e.Graphics.DrawString(dtsalesdate.Text, new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(90, 90));
            //    e.Graphics.DrawString("Name:", new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(550, 90));
            //    e.Graphics.DrawString(cmbcustomer.Text, new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(630, 90));
            //    e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------", new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(5, 140));
            //    e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------", new Font("Ariel", 15, FontStyle.Bold), Brushes.Black, new Point(5, 190));
            //    Bitmap bm = new Bitmap(this.dgvinvoice.Width, this.dgvinvoice.Height);
            //    dgvinvoice.DrawToBitmap(bm, new Rectangle(0, 0, this.dgvinvoice.Width, this.dgvinvoice.Height));
            //    e.Graphics.DrawImage(bm, 5, 240);
        }

        private bool Validation1()
        {
            bool result = false;
            if (String.IsNullOrEmpty(txtsubtotal.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtsubtotal, "Total Payable required");
            }
            //else if (String.IsNullOrEmpty(cmbcustomer.Text))
            //{
            //    errorProvider1.Clear();
            //    errorProvider1.SetError(cmbcustomer, "Customer name required");
            //}
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            return result;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (Validation1())
            {
                //printPreviewDialog1.Document = printDocument1;
                //printPreviewDialog1.ShowDialog();


                //Gettting Data FRom UI
                inbll.inv_no = Convert.ToInt32(lblinvoiceno.Text);
                inbll.customer_name = cmbcustomer.Text;
                inbll.total_payable = txtsubtotal.Text;
                inbll.paid_amount = txtpaidamount.Text;
                inbll.discount = txtdiscount.Text;
                inbll.due_amount = txtdueamount.Text;
                inbll.change_amount = txtchangeamount.Text;
                inbll.sales_date = DateTime.Now;
                if (cmbcustomer.SelectedItem == null)
                {
                    inbll.doctorsid = 0;
                }
                else
                {
                    inbll.doctorsid = ((ComboboxItem)cmbcustomer.SelectedItem).Value;
                }

                //Getting Username of the logged in user
                string loggedUser = Login.loggedIn;
                usersbll usr = user.GetIDFromUsername(loggedUser);
                inbll.added_by = usr.usersid;
                //Inserting Data into DAtabase
                bool w = indal.insert(inbll);
                bool sucess = false;

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    bool x = false;
                    //Get the Product name and convert it to id
                    string ProductName = table.Rows[i][0].ToString();
                    string type1 = table.Rows[i][2].ToString();
                    string ccode = table.Rows[i][1].ToString();
                    Manage_Productsbll p = dal.GetProductIDFromName(ProductName, type1, ccode);
                    prbll.productid = p.stockid;

                    prbll.product_name = table.Rows[i][0].ToString();
                    prbll.type = table.Rows[i][2].ToString();
                    prbll.price = table.Rows[i][3].ToString();
                    prbll.quantity = table.Rows[i][4].ToString();
                    //prbll.code = Convert.ToInt32(table.Rows[i][1]);
                    prbll.discount = txtdiscount.Text;
                    //prbll.total = table.Rows[i][3].ToString();
                    //Getting total value by calculating discount
                    t1 = Convert.ToDouble(txtdiscount.Text);
                    t2 = Convert.ToDouble(table.Rows[i][5]);
                    prbll.total = (t2 - (t2 * t1) / 100).ToString();

                    //Method to get purchase price an multiply it with quantity
                    Manage_Productsbll pr = dal.GetProductpriceFromId(p.stockid.ToString());
                    purchaseprice = Convert.ToDouble(pr.purchase_price);
                    prbll.purchase_price = ((Convert.ToDouble(table.Rows[i][4])) * purchaseprice).ToString();

                    prbll.inv_no = lblinvoiceno.Text;
                    prbll.added_by = usr.usersid;
                    prbll.added_date = DateTime.Now;

                    quantity1 = Convert.ToDecimal(prbll.quantity);

                    // Decreasing product quantity in DAtabase
                    bool y = false;
                    y = dal.DecreaseProduct(prbll.productid, quantity1);

                    // Inserting Data into DAtabase
                    x = prdal.insert(prbll);
                    sucess = w && x && y;
                }

                if (sucess == true)
                {
                    MessageBox.Show("Transaction Completed Sucessfully");

                    //Celar the Data Grid View and Clear all the TExtboxes
                    dgvinvoice.DataSource = null;
                    dgvinvoice.Rows.Clear();
                    table.Rows.Clear();
                    txttotal.Text = "";
                    txtdiscount.Text = "";
                    txtsubtotal.Text = "";
                    txtpaidamount.Text = "";
                    txtdueamount.Text = "";
                    txtchangeamount.Text = "";
                    cmbcustomer.Text = "";
                    txtcomment.Text = "0";
                    //To refresh stock in Data grid view
                    DataTable dt = dal.selectPublic();
                    dgvstock.DataSource = dt;

                    ToGetInvoiceID();
                }
                else
                {
                    //Transaction Failed
                    MessageBox.Show("Transaction Failed");
                }
            }
        }

        

        #region To get Invoice id from Data Base
        public void ToGetInvoiceID()
        {           
            lblinvoiceno.Text = indal.GetMaxInvoiceId();                    
        }
        #endregion
    }
}
