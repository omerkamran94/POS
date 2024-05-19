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
    public partial class Client : Form
    {
        private static Client _instance;

        public static Client instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Client();
                return _instance;
            }
        }
        public Client()
        {
            InitializeComponent();
        }

        Clientbll u = new Clientbll();
        Clientdal dal = new Clientdal();
        userdal da = new userdal();
        CommonUtility commonUtility = new CommonUtility();


        private void btnadd_Click(object sender, EventArgs e)
        {
            //Checking if text boxes are empty or null
            if (Validation())
            {
                //Gettting Data FRom UI

                u.clientid = txtclientid.Text;
                u.logo = txtlogo.Text;
                u.title = txttitle.Text;
                u.detail = txtdetail.Text;
                u.footer = txtfooter.Text;
                
 

                //Getting Username of the logged in user
                string loggedUser = Login.loggedIn;
                usersbll usr = da.GetIDFromUsername(loggedUser);

         
          

                    //Inserting data in DataBase
                    bool check = dal.insert(u);
                    if (check == true)
                    {
                        MessageBox.Show("Client Data Added Successfully");
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("error");
                    }
                }
                //Refreshing Data Grid View
                DataTable dt = dal.select();
                dgvclient.DataSource = dt;
         
        }

        //Function to clear text bocxes after insert,update or delete data
        private void clear()
        {
            txtclientid.Text = "";
            txtlogo.Text = "";
            txttitle.Text = "";
            txtdetail.Text = "";
            txtfooter.Text = "";
            pictureBox1.Image = null;

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

                u.clientid = txtclientid.Text;
                u.logo = txtlogo.Text;
                u.title = txttitle.Text;
                u.detail = txtdetail.Text;
                u.footer = txtfooter.Text;
               u.photo =  GetImage();



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
                dgvclient.DataSource = dt;
            }
        }

        private byte[] GetImage()
        {
            byte[] image;
            MemoryStream stream = new MemoryStream();
            pictureBox1.Image.Save(stream, pictureBox1.Image.RawFormat);
            image = stream.GetBuffer();
            return image;
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

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            //Get Keyword from Text box
            //string keyword = txtsearch.Text;
            ////Check if the keywords has value or not
            //if (keyword != null)
            //{
            //    //Show user based on keywords
            //    DataTable dt = dal.Search(keyword);
            //    dgvdoctors.DataSource = dt;
            //}
            //else
            //{
            //    //show all users from the database
            //    DataTable dt = dal.select();
            //    dgvdoctors.DataSource = dt;
            //}
        }

        //Function to check if Text Boxes are Empty or null
        private bool Validation()
        {
            bool result = false;
            if (String.IsNullOrEmpty(txtlogo.Text))
            {
                MessageBox.Show("Logo Required");
                return false;
            }  
            else if (String.IsNullOrEmpty(txttitle.Text))
            {
                MessageBox.Show("Title Required");
                return false;
            }
            else if (String.IsNullOrEmpty(txtdetail.Text))
            {
                MessageBox.Show("Detail Required");
                return false;
            } 
            else if (String.IsNullOrEmpty(txtfooter.Text))
            {
                MessageBox.Show("Footer Required");
                return false;
            }            

            else
            {
                
                result = true;
            }
            return result;
        }

       

        

        private void dgvclient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvclient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the index of particular row
            int ri = e.RowIndex;
            txtclientid.Text = dgvclient.Rows[ri].Cells["clientid"].Value.ToString();
            txtlogo.Text = dgvclient.Rows[ri].Cells["logo"].Value.ToString();
            txttitle.Text = dgvclient.Rows[ri].Cells["title"].Value.ToString();
            txtdetail.Text = dgvclient.Rows[ri].Cells["detail"].Value.ToString();
            txtfooter.Text = dgvclient.Rows[ri].Cells["footer"].Value.ToString();
            byte[] img = (Byte[])(dgvclient.Rows[ri].Cells["photo"].Value);
            pictureBox1.Image = commonUtility.ByteToImage(img);

        }
        //public Bitmap ByteToImage(byte[] blob)
        //{
        //    MemoryStream mStream = new MemoryStream();
        //    byte[] pData = blob;
        //    mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
        //    Bitmap bm = new Bitmap(mStream, false);
        //    mStream.Dispose();
        //    return bm;
        //}

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }

        private void Client_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.select();
            dgvclient.DataSource = dt;
        }

        private void OpenDialog(object sender, EventArgs e)
        {
            try
            {
                
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                    MemoryStream stream= new MemoryStream();    
                    pictureBox1.Image.Save(stream,pictureBox1.Image.RawFormat);
                    u.photo = stream.GetBuffer();


                }
                openFileDialog1.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
            }
            catch(Exception ex)
            {
                MessageBox.Show("Some error occured during uploading the photo" + ex.Message);
            }
            
            

        }

        private void button_del_Click(object sender, EventArgs e)
        {
            u.clientid = txtclientid.Text;
           bool check =  dal.del(u);
            if(check)
            {
                MessageBox.Show("record deleted successfully");
                clear();
                DataTable dt = dal.select();
                dgvclient.DataSource = dt;
            }
        }
    }
}
