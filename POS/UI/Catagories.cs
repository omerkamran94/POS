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

namespace POS.UI
{
    public partial class Catagories : Form
    {
        private static Catagories _instance;

        public static Catagories instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Catagories();
                return _instance;
            }
        }
        public Catagories()
        {
            InitializeComponent();
            fillcombo();
        }

        Categoriesbll u = new Categoriesbll();
        Catagoriesdal dal = new Catagoriesdal();
        userdal da = new userdal();

        private void Catagories_Load(object sender, EventArgs e)
        {
            //To load data in DataGridView
            refreshData();
        }
        private void refreshData()
        {
            DataTable dt = dal.select();
            dgvcatagories.DataSource = dt;
        }
        private void dgvcatagories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            //Checking if text boxes are empty or null
            if (Validation())
            {
                //Gettting Data FRom UI
                
                u.category = txtcatagory.Text;
                u.supplier = txtsupplier.Text;
                ComboboxItem item = new ComboboxItem();
                item = (ComboboxItem)txtsupplier.SelectedItem;
                u.suppliersid = item.Value;
                u.active = chk_active.Checked;
                //u.added_by = 1;
                u.added_date = DateTime.Now;

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
                        u.categoriesid = Convert.ToInt32(txtid.Text);
                        //Update Data in DataBase
                        bool check = dal.update(u);
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
                        refreshData();
                    }
                }
                else
                {
                    //Inserting data in DataBase
                    bool check = dal.insert(u);
                    if (check == true)
                    {
                        MessageBox.Show("Categoties Data Added Successfully");
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("error");
                    }
                }
                //Refreshing Data Grid View
                refreshData();
            }
        }

        //Function to clear text bocxes after insert,update or delete data
        private void clear()
        {
            txtcatagory.Text = "";
            txtsupplier.Text = "";
            chk_active.Checked = false;
        }

        private void dgvcatagories_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the index of particular row
            int ri = e.RowIndex;
            txtid.Text = dgvcatagories.Rows[ri].Cells["categoriesid"].Value.ToString();
            txtcatagory.Text = dgvcatagories.Rows[ri].Cells["category"].Value.ToString();
           // txtsupplier.Text = dgvcatagories.Rows[ri].Cells[2].Value.ToString();
            txtsupplier.SelectedIndex  = txtsupplier.FindStringExact(dgvcatagories.Rows[ri].Cells["supplier"].Value.ToString());
            chk_active.Checked  = Convert.ToBoolean(dgvcatagories.Rows[ri].Cells["active"].Value.ToString());
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            //Checking if text boxes are empty or null
            if (Validation())
            {
                string loggedUser = Login.loggedIn;
                usersbll usr = da.GetIDFromUsername(loggedUser);

                u.added_by = usr.usersid;
                //Gettting Data FRom UI
                u.categoriesid = Convert.ToInt32(txtid.Text);
                u.category = txtcatagory.Text;
                u.active = chk_active.Checked;
                ComboboxItem item = new ComboboxItem();
                item = (ComboboxItem)txtsupplier.SelectedItem;
                u.suppliersid = item.Value;
               // u.suppliersid =(int)txtsupplier.SelectedValue;
                
                //Updating Data into database
                bool check = dal.update(u);
                if (check == true)
                {
                    MessageBox.Show("record updated successfully");
                    clear();
                }
                else
                {
                    MessageBox.Show("error");
                }

                //Refreshing Data Grid View
                refreshData();
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if(Validation())
            {
                //Showing Dialog Box to get yes or no result
                DialogResult = MessageBox.Show("Are You Want to delete", "Message", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    //Getting User ID from Form 
                    u.categoriesid = Convert.ToInt32(txtid.Text);
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
                    refreshData();
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
                dgvcatagories.DataSource = dt;
            }
            else
            {
                //show all users from the database
                refreshData();
            }
        }

        //Function to check if Text Boxes are Empty or null
        private bool Validation()
        {
            bool result = false;
            if (String.IsNullOrEmpty(txtcatagory.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtcatagory, "Catagory Required");
            }
            else if (String.IsNullOrEmpty(txtsupplier.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtsupplier, "Supplier Required");
            }
            
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            return result;
        }

        #region fill combo box data
        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
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

                    txtsupplier.Items.Add(comboboxItem);
                    
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

        private void Catagories_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }

        private void txtsupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


    }
}
