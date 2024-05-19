using POS.BLL;
using POS.DAL;
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

namespace POS.UI
{
    public partial class Doctors : Form
    {
        private static Doctors _instance;

        public static Doctors instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Doctors();
                return _instance;
            }
        }
        public Doctors()
        {
            InitializeComponent();
           // fillcombo();
        }

        Doctorsbll u = new Doctorsbll();
        Doctorsdal dal = new Doctorsdal();
        userdal da = new userdal();

        private void Doctors_Load(object sender, EventArgs e)
        {
            //To load data in DataGridView doctors Doctors
            DataTable dt = dal.select();
            dgvdoctors.DataSource = dt;
        }

        private void dgvdoctors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            //Checking if text boxes are empty or null
            if (Validation())
            {
                //Gettting Data FRom UI

                u.doctor = txtdoctor.Text;
                

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
                        u.doctorsid = Convert.ToInt32(txtid.Text);
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
                        DataTable dt1 = dal.select();
                        dgvdoctors.DataSource = dt1;
                    }
                }
                else
                {
                    //Inserting data in DataBase
                    bool check = dal.insert(u);
                    if (check == true)
                    {
                        MessageBox.Show("Doctos Data Added Successfully");
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("error");
                    }
                }
                //Refreshing Data Grid View
                DataTable dt = dal.select();
                dgvdoctors.DataSource = dt;
            }
        }

        //Function to clear text bocxes after insert,update or delete data
        private void clear()
        {
            txtdoctor.Text = "";
            chk_active.Checked = false;
        }

        private void dgvdoctors_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the index of particular row
            int ri = e.RowIndex;
            txtid.Text = dgvdoctors.Rows[ri].Cells["doctorsid"].Value.ToString();
            txtdoctor.Text = dgvdoctors.Rows[ri].Cells["doctor"].Value.ToString();
            chk_active.Checked = Convert.ToBoolean(dgvdoctors.Rows[ri].Cells["active"].Value.ToString());
            // txtsupplier.Text = dgvdoctors.Rows[ri].Cells[2].Value.ToString();
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
                u.doctorsid = Convert.ToInt32(txtid.Text);
                u.doctor = txtdoctor.Text;
                u.active = chk_active.Checked;


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
                DataTable dt = dal.select();
                dgvdoctors.DataSource = dt;
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                //Showing Dialog Box to get yes or no result
                DialogResult = MessageBox.Show("Are You Want to delete", "Message", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    //Getting User ID from Form 
                    u.doctorsid = Convert.ToInt32(txtid.Text);
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
                    dgvdoctors.DataSource = dt;
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
                dgvdoctors.DataSource = dt;
            }
            else
            {
                //show all users from the database
                DataTable dt = dal.select();
                dgvdoctors.DataSource = dt;
            }
        }

        //Function to check if Text Boxes are Empty or null
        private bool Validation()
        {
            bool result = false;
            if (String.IsNullOrEmpty(txtdoctor.Text))
            {
                MessageBox.Show("Doctor Required");
                return false;
            }            

            else
            {
                
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
         
        #endregion

        private void Doctors_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;

        }



    }
}
