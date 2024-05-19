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
using POS.BLL;
using POS.DAL;
using POS.Utility;

namespace POS.UI
{
    public partial class Manage_Products : Form
    {
        private static Manage_Products _instance;
        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        public static Manage_Products instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Manage_Products();
                return _instance;
            }
        }
        public Manage_Products()
        {
            InitializeComponent();
            //fillcombo();
            fillcombo1();
        }
        Manage_Productsbll u = new Manage_Productsbll();
        Manage_Productsdal dal = new Manage_Productsdal();

        userdal da = new userdal();


        private void Manage_Products_Load(object sender, EventArgs e)
        {
            //To load data in DataGridView
            DataTable dt = dal.select();
            dgvmanageproducts.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Checking if text boxes are empty or null
            if (Validation())
            {
                //Gettting Data FRom UI
                
                u.product_name = txtproductname.Text;
                u.code = txtcolourcode.Text;
                //u.supplier = txtsupplier.Text;
                
                //ComboboxItem supitem = new ComboboxItem();
                //supitem = (ComboboxItem)txtsupplier.SelectedItem;
                //u.suppliersid = supitem.Value;

                ComboboxItem catitem = new ComboboxItem();
                catitem = (ComboboxItem)txtcatagory.SelectedItem;
                u.categoriesid = catitem.Value;

                u.category = txtcatagory.Text;
                u.purchase_price = txtpurchaseprice.Text;
                u.retail_price = txtretailprice.Text;
                //u.type = txtmaxdiscount.Text;
                u.quantity = txtquantity.Text;
                //u.added_by = 1;
                u.added_date = DateTime.Now;
                u.active = chk_active.Checked;

                //Getting Username of the logged in user
                string loggedUser = Login.loggedIn;
                usersbll usr = da.GetIDFromUsername(loggedUser);

                u.added_by = usr.usersid;
                //Inserting Data into DAtabase
                bool check1 = dal.exist(u);
                //Checking if Product Already Exist
                if (check1 == true)
                {
                    //Showing MessageBox
                    DialogResult = MessageBox.Show("Product already exist do you want to update", "Message", MessageBoxButtons.YesNo);
                    if (DialogResult == DialogResult.Yes)
                    {
                        u.stockid = Convert.ToInt32(txtproductid.Text);
                        //Update Data in DataBase
                        bool check = dal.update_(u);
                        if (check == true)
                        {
                            MessageBox.Show("Record updated successfully");
                            clear();
                        }
                        else
                        {
                            MessageBox.Show("error");
                        }
                        //Refreshing Data Grid View
                        DataTable dt1 = dal.select();
                        dgvmanageproducts.DataSource = dt1;
                    }
                }
                else
                {
                    //Inserting data in DataBase
                    bool check = dal.insert(u);
                    if (check == true)
                    {
                        MessageBox.Show("Record added successfully");
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("error");
                    }
                }
                //Refreshing Data Grid View
                DataTable dt = dal.select();
                dgvmanageproducts.DataSource = dt;
            }

        }

        //Function to clear text bocxes after insert,update or delete data
        private void clear()
        {
            txtproductname.Text = "";
            txtcolourcode.Text = "";
            //txtsupplier.Text = "";
            txtcatagory.Text = "";
            txtpurchaseprice.Text = "";
            txtretailprice.Text = "";
            //txtmaxdiscount.Text = "";
            txtquantity.Text = "";
            chk_active.Checked = false;
        }

        private void dgvmanageproducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            //Checking if text boxes are empty or null
            if (Validation())
            {
            //Gettting Data FRom UI
            u.stockid = Convert.ToInt32(txtproductid.Text);
            u.product_name = txtproductname.Text;
            u.code = txtcolourcode.Text;
            //u.supplier = txtsupplier.Text;
            //    ComboboxItem supitem = new ComboboxItem();
            //    supitem = (ComboboxItem)txtsupplier.SelectedItem;
            //    u.suppliersid = supitem.Value;

                u.category = txtcatagory.Text;
                ComboboxItem catitem = new ComboboxItem();
                catitem = (ComboboxItem)txtcatagory.SelectedItem;
                u.categoriesid = catitem.Value;

                u.purchase_price = txtpurchaseprice.Text;
            u.retail_price = txtretailprice.Text;
            //u.type = txtmaxdiscount.Text;
            u.quantity = txtquantity.Text;
                u.active = chk_active.Checked;

                //Updating Data into database
                bool check = dal.update_(u);
            if (check == true)
            {
                MessageBox.Show("Record updated successfully");
                clear();
            }
            else
            {
                MessageBox.Show("error");
            }
                //Refreshing Data Grid View
                DataTable dt = dal.select();
                dgvmanageproducts.DataSource = dt;
            }
        }

        private void dgvmanageproducts_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the index of particular row
            int ri = e.RowIndex;
            txtproductid.Text = dgvmanageproducts.Rows[ri].Cells["stockid"].Value.ToString();
            txtproductname.Text = dgvmanageproducts.Rows[ri].Cells["product_name"].Value.ToString();
            txtcolourcode.Text = dgvmanageproducts.Rows[ri].Cells["code"].Value.ToString();

           // txtsupplier.Text = dgvmanageproducts.Rows[ri].Cells[3].Value.ToString();
            //txtsupplier.SelectedIndex = txtsupplier.FindStringExact(dgvmanageproducts.Rows[ri].Cells[13].Value.ToString());

           // txtcatagory.Text = dgvmanageproducts.Rows[ri].Cells[4].Value.ToString();
            txtcatagory.SelectedIndex = txtcatagory.FindStringExact(dgvmanageproducts.Rows[ri].Cells["category"].Value.ToString());

            txtpurchaseprice.Text = dgvmanageproducts.Rows[ri].Cells["purchase_price"].Value.ToString();
            txtretailprice.Text = dgvmanageproducts.Rows[ri].Cells["retail_price"].Value.ToString();
            //txtmaxdiscount.Text = dgvmanageproducts.Rows[ri].Cells[7].Value.ToString();
            txtquantity.Text = dgvmanageproducts.Rows[ri].Cells["quantity"].Value.ToString();
            chk_active.Checked = Convert.ToBoolean(dgvmanageproducts.Rows[ri].Cells["active"].Value.ToString());
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if(Validation())
            {
                //Showing Dialog Box to get yes or no result
                DialogResult = MessageBox.Show("Are You Want to delete", "Message", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    //Getting User ID from Form 
                    u.stockid = Convert.ToInt32(txtproductid.Text);
                    //Deleting Data From DataBase
                    bool check = dal.delete(u);
                    if (check == true)
                    {
                        MessageBox.Show("Record deleted sucessfully");
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Record not deleted");
                    }
                    //refreshing Datagrid view
                    DataTable dt = dal.select();
                    dgvmanageproducts.DataSource = dt;
                }
            }
            
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            //Get Keyword from Text box
            string keyword = txtsearch.Text;
            //Check if the keywords has value or not
            if (keyword != null)
            {
                //Show user based on keywords
                DataTable dt = dal.Search(keyword);
                dgvmanageproducts.DataSource = dt;
            }
            else
            {
                //show all users from the database
                DataTable dt = dal.select();
                dgvmanageproducts.DataSource = dt;
            }
        }

        //Function to check if Text Boxes are Empty or null
        private bool Validation()
        {
            bool result = false;
            if (String.IsNullOrEmpty(txtproductname.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtproductname, "Product Name Required");
            }
            else if (String.IsNullOrEmpty(txtcatagory.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtcatagory, "Product Catagory Required");
            }
            else if (String.IsNullOrEmpty(txtpurchaseprice.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtpurchaseprice, "Purchase Price Required");
            }
            else if (String.IsNullOrEmpty(txtretailprice.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtretailprice, "Retail Price Required");
            }
            else if (String.IsNullOrEmpty(txtquantity.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtquantity, "Product Quantity Required");
            }
            //else if (String.IsNullOrEmpty(txtmaxdiscount.Text))
            //{
            //    errorProvider1.Clear();
            //    errorProvider1.SetError(txtmaxdiscount, "Product Type Required");
            //}
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            return result;
        }

        #region fill supplierdata data in combobox
        public bool fillcombo()
        {
            bool issucess = false;
            connclass c = new connclass();
            SqlConnection conn = new SqlConnection(c.connection);
            suppliersdal suppliersdal = new suppliersdal();
            try
            {
                DataTable suppliersData = suppliersdal.selectList();
                ComboboxItem comboboxItem = new ComboboxItem();
                foreach (DataRow dr in suppliersData.Rows)
                {
                    comboboxItem = new ComboboxItem();
                    comboboxItem.Text = dr["company"].ToString();
                    comboboxItem.Value = (int)dr["suppliersid"];

                    //txtsupplier.Items.Add(comboboxItem);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }
            return issucess;
        }
        #endregion

        #region fill catagory data in combobox
        public bool fillcombo1()
        {
            bool issucess = false;
            connclass c = new connclass();
            SqlConnection conn = new SqlConnection(c.connection);
            Catagoriesdal catagoriesdal = new Catagoriesdal();
          
            try
            {
                DataTable catagoriesData = catagoriesdal.selectList();
                ComboboxItem comboboxItem = new ComboboxItem();
                foreach (DataRow dr in catagoriesData.Rows)
                {
                    comboboxItem = new ComboboxItem();
                    comboboxItem.Text = dr["category"].ToString();
                    comboboxItem.Value = (int)dr["categoriesid"];

                    txtcatagory.Items.Add(comboboxItem);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }
            return issucess;
        }
        #endregion
        private void Manage_Products_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }

        private void Download_Excel(object sender, EventArgs e)
        {
            ExcelUtility utility = new ExcelUtility();
            utility.DownloadDataGridViewToExcel(dgvmanageproducts, "Products");
        }
    }
}
