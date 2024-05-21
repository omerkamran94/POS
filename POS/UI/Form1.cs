using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.DAL;
using POS.UI;
using POS.UI.Sales_Man;

namespace POS
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            fillChart();
        }
        public void fillChart()
        {
            sales_analyticsdal sales_Analyticsdal = new sales_analyticsdal();

            DataTable table = sales_Analyticsdal.ShowSalesDataByDate();

            chart1.DataSource = table;
            chart1.Series["Sales"].XValueMember = "Date";
            chart1.Series["Sales"].YValueMembers = "Sales";

            //AddXY value in chart1 in series named as Salary  

            //chart title  
            chart1.Titles.Add("Sales Chart");
        }
        private void ShowForm(Form f)
        {
            f.MdiParent = this;
            f.Show();
            f.Activate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowForm(Stock.instance);
            chart1.Hide();
            //Stock obj= new Stock();
            //   obj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowForm(Sales_Analytics.instance);
            chart1.Hide();
            //Sales_Analytics obj = new Sales_Analytics();
            //obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowForm(Invoice_Details.instance);
            chart1.Hide();
            //Manage_Products obj = new Manage_Products();
            //obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            //Suppliers obj = new Suppliers();
            //obj.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowForm(Sale_Register.instance);
            chart1.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            //Catagories obj = new Catagories();
            //obj.Show();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Getting username 
            //lblusername.Text = Login.loggedIn;
            lblname.Text = Login.loggedIn;
        }

       
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login obj = new Login();
            Main ob = new Main();
            //Closing all Forms and show login form
               DialogResult result = MessageBox.Show("Do You Want to LogOut and Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ob.Close();
                    obj.Show();
                }
                else
                {
                     e.Cancel = true;
                }
        }

        private void button8_Click(object sender, EventArgs e)
        {
               
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(Users.instance);
            chart1.Hide();
        }

        private void catagoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(Catagories.instance);
            chart1.Hide();
        }
         private void doctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(Doctors.instance);
            chart1.Hide();
        }
        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(Client.instance);
            chart1.Hide();
        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(Suppliers.instance);
            chart1.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ShowForm(Return.instance);
            chart1.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void invoiceDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            ShowForm(Manage_Products.instance);
            chart1.Hide();
        }

        private void Form_Clicked(object sender, EventArgs e)
        {
             
            chart1.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            ShowForm(ProductAnalytics.instance);
            chart1.Hide();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            ShowForm(CashDrawer.instance);
            chart1.Hide();
        }
    }
}
