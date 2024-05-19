using POS.BLL;
using POS.DAL;
using POS.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.UI
{
    public partial class CashDrawerForm : Form
    {
        private static CashDrawerForm _instance;
        public CashDrawer cashDrawerForm { get; set; }
        public CashDrawerBLL cashDrawerBLL { get; set; }
        public static CashDrawerForm instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CashDrawerForm();
                return _instance;
            }
        }
        
        public CashDrawerForm()
        {
            InitializeComponent();
        }
        public CashDrawerForm(CashDrawer cashDrawerForm, CashDrawerBLL cashDrawerBLL)
        {
            InitializeComponent();
            this.cashDrawerForm = cashDrawerForm;
            this.cashDrawerBLL = cashDrawerBLL;
            SetValuesForm();
        }

        
        CashDrawerDAL cashDrawerDAL = new CashDrawerDAL();
        userdal da = new userdal();
        CommonUtility commonUtility = new CommonUtility();

        public void SetValuesForm()
        {
            txtCashDrawerId.Text = cashDrawerBLL.CashDrawerId.ToString();
            txtCashDrawerStart.Text = cashDrawerBLL.CashDrawerStart.ToString();
            txtCashDrawerRemoved.Text = cashDrawerBLL.CashDrawerRemoved.ToString();
            txtCashDrawerAdded.Text = cashDrawerBLL.CashDrawerAdded.ToString();
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            //Checking if text boxes are empty or null
            if (Validation())
            {
                //Gettting Data FRom UI
                string loggedUser = Login.loggedIn;
                usersbll usr = da.GetIDFromUsername(loggedUser);


                cashDrawerBLL.CashDrawerId = Convert.ToInt32(txtCashDrawerId.Text);
                cashDrawerBLL.CashDrawerStart = Convert.ToDecimal(txtCashDrawerStart.Text);
                cashDrawerBLL.CashDrawerAdded = Convert.ToDecimal(txtCashDrawerAdded.Text);
                cashDrawerBLL.CashDrawerRemoved = Convert.ToDecimal(txtCashDrawerRemoved.Text);
                cashDrawerBLL.added_by = usr.usersid;
                cashDrawerBLL.added_date = DateTime.Now;



                //Getting Username of the logged in user





                //Inserting data in DataBase
                bool check = cashDrawerDAL.insert(cashDrawerBLL);
                if (check == true)
                {
                    MessageBox.Show("Added Successfully");
                    clear();
                }
                else
                {
                    MessageBox.Show("error");
                }
            }
            //Refreshing Data Grid View
            Form_Closed();


        }

        //Function to clear text bocxes after insert,update or delete data
        private void clear()
        {
            txtCashDrawerId.Text = "";
            txtCashDrawerStart.Text = "";
            txtCashDrawerAdded.Text = "";
            txtCashDrawerRemoved.Text = "";
        }

        private void dgvdoctors_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            //Checking if text boxes are empty or null
            if (Validation())
            {
                string loggedUser = Login.loggedIn;
                usersbll usr = da.GetIDFromUsername(loggedUser);

                cashDrawerBLL.CashDrawerId = Convert.ToInt32(txtCashDrawerId.Text);
                cashDrawerBLL.CashDrawerStart = Convert.ToDecimal(txtCashDrawerStart.Text);
                cashDrawerBLL.CashDrawerAdded = Convert.ToDecimal(txtCashDrawerAdded.Text);
                cashDrawerBLL.CashDrawerRemoved = Convert.ToDecimal(txtCashDrawerRemoved.Text);
                cashDrawerBLL.added_by = usr.usersid;
                cashDrawerBLL.added_date = DateTime.Now;



                //Updating Data into database
                bool check = cashDrawerDAL.update(cashDrawerBLL);
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
                Form_Closed();
            }
        }



        private void btndel_Click(object sender, EventArgs e)
        {
            //if (Validation())
            //{
            //    //Showing Dialog Box to get yes or no result
            //    DialogResult = MessageBox.Show("Are You Want to delete", "Message", MessageBoxButtons.YesNo);
            //    if (DialogResult == DialogResult.Yes)
            //    {
            //        //Getting User ID from Form 
            //        u.doctorsid = Convert.ToInt32(txtid.Text);
            //        //Deleting Data From DataBase
            //        bool check = dal.delete(u);
            //        if (check == true)
            //        {
            //            MessageBox.Show("Record deleted sucessfully");
            //            clear();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Record not deleted");
            //        }
            //        //refreshing Datagrid view
            //        DataTable dt = dal.select();
            //        dgvdoctors.DataSource = dt;
            //    }
            //}
        }



        //Function to check if Text Boxes are Empty or null
        private bool Validation()
        {
            bool result = false;
            if (String.IsNullOrEmpty(txtCashDrawerStart.Text))
            {
                MessageBox.Show("CashDrawerStart Required");
                return false;
            }

            else
            {

                result = true;
            }
            return result;
        }







        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
           _instance= null;
        }
        private void Form_Closed()
        {
            this.cashDrawerForm.onLoad();
            this.Close();
            
         
        }
        

         

        private void button_del_Click(object sender, EventArgs e)
        {
            cashDrawerBLL.CashDrawerId = Convert.ToInt32(txtCashDrawerId.Text);
            bool check = cashDrawerDAL.delete(cashDrawerBLL);
            if (check)
            {
                MessageBox.Show("record deleted successfully");
                clear();
               
            }
            else
            {
                MessageBox.Show("error");
            }

            Form_Closed();
        }
    }
}
