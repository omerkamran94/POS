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
    public partial class ExpenseForm : Form
    {
        private static ExpenseForm _instance;
        public CashDrawer cashDrawer { get; set; }
        public ExpenseBLL expenseBll { get; set; }
        public static ExpenseForm instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ExpenseForm();
                return _instance;
            }
        }
        
        public ExpenseForm()
        {
            InitializeComponent();
        }
        public ExpenseForm(CashDrawer ExpenseForm, ExpenseBLL expenseBll)
        {
            InitializeComponent();

            this.cashDrawer = ExpenseForm;
            this.expenseBll = expenseBll;
            SetValuesForm();
        }

        CashDrawerDAL cashDrawerDAL = new CashDrawerDAL();
        userdal da = new userdal();
        CommonUtility commonUtility = new CommonUtility();

        public void SetValuesForm()
        {
            txtExpenseDesc.Text = (expenseBll.ExpenseDescription ?? "").ToString();
            txtExpenseAmount.Text = (expenseBll.ExpenseAmount).ToString();
            txtExpenseId.Text = (expenseBll.ExpenseId).ToString();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            //Checking if text boxes are empty or null
            if (Validation())
            {
                //Gettting Data FRom UI
                string loggedUser = Login.loggedIn;
                usersbll usr = da.GetIDFromUsername(loggedUser);


                this.expenseBll.CashDrawerId = this.expenseBll.CashDrawerId;
                expenseBll.ExpenseDescription = (txtExpenseDesc.Text).ToString();
                expenseBll.ExpenseAmount = Convert.ToDecimal(txtExpenseAmount.Text);
                // expenseBLL.Type = Convert.ToDecimal(txtExpenseType.Text);
                expenseBll.added_by = usr.usersid;
                expenseBll.added_date = DateTime.Now;



                //Getting Username of the logged in user





                //Inserting data in DataBase
                bool check = cashDrawerDAL.insertExpense(expenseBll);
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
            txtExpenseAmount.Text = "";
            txtExpenseDesc.Text = "";
            txtExpenseId.Text = "";
            //cmbExpenseType.SelectedIndex = 0;
        }




        private void btnupdate_Click(object sender, EventArgs e)
        {
            //Checking if text boxes are empty or null
            if (Validation())
            {
                string loggedUser = Login.loggedIn;
                usersbll usr = da.GetIDFromUsername(loggedUser);

                expenseBll.CashDrawerId = expenseBll.CashDrawerId;
                expenseBll.ExpenseId = Convert.ToInt32(txtExpenseId.Text);
                expenseBll.ExpenseDescription = txtExpenseDesc.Text.ToString();
                expenseBll.ExpenseAmount = Convert.ToDecimal(txtExpenseId.Text);
                //expenseBLL.Type = Convert.ToDecimal(txtExpenseType.Text);
                expenseBll.added_by = usr.usersid;
                expenseBll.added_date = DateTime.Now;



                //Updating Data into database
                bool check = cashDrawerDAL.updateExpense(expenseBll);
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
            if (String.IsNullOrEmpty(txtExpenseDesc.Text))
            {
                MessageBox.Show("Expense Description Required");
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
            clear();
            this.cashDrawer.onLoad();
            this.cashDrawer.expenseBLL = new ExpenseBLL();
            this.Close();
            
         
        }
        

         

        private void button_del_Click(object sender, EventArgs e)
        {
            expenseBll.CashDrawerId = Convert.ToInt32(txtExpenseId.Text);
            bool check = cashDrawerDAL.deleteExpense(expenseBll);
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
