using POS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.UI.Sales_Man
{
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
            fillChart();
        }
        public void fillChart()
        {
            sales_analyticsdal sales_Analyticsdal = new sales_analyticsdal();

            DataTable table = sales_Analyticsdal.ShowSalesDataByDate();

            chart1.DataSource= table;
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
            ShowForm(Sale_Register.instance);
            chart1.Hide();
        }

       
        private void mainform_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login obj = new Login();
            Main ob = new Main();

            DialogResult result = MessageBox.Show("Are You Want to LogOut and Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void button2_Click(object sender, EventArgs e)
        {
            ShowForm(Manage_Products.instance);
            chart1.Hide();
            //Manage_Products obj = new Manage_Products();
            //obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowForm(Return.instance);
            chart1.Hide();
            //Return obj = new Return();
            //obj.Show();
        }

        private void mainform_Load(object sender, EventArgs e)
        {
            lblusername.Text = Login.loggedIn;
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowForm(Stock.instance);
            chart1.Hide();
        }

        private void Form_Clicked(object sender, EventArgs e)
        {
            chart1.Show();
        }
    }
}
