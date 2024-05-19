using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.DAL
{
    class sales_analyticsdal
    {

        #region select data from database

        public DataTable select()
        {
            //MEthod to connect Database
            connclass c = new connclass();
            SqlConnection conn = new SqlConnection(c.connection);
            //TO hold the data from database 
            DataTable dt = new DataTable();
            try
            {
                //SQL Query to Get Data From DAtabase
                string query = "select * from productdetails";
                //For Executing Command
                SqlCommand cmd = new SqlCommand(query, conn);
                //Getting DAta from dAtabase
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Database Connection Open
                conn.Open();
                //Fill Data in our DataTable
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                //Throw Message if any error occurs
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Closing Connection
                conn.Close();
            }
            //Return the value in DataTable
            return dt;

        }
        #endregion

        #region Search Data From DataBase
        public DataTable Search(string keyword)
        {
            //MEthod to connect Database
            connclass c = new connclass();
            SqlConnection conn = new SqlConnection(c.connection);
            //TO hold the data from database 
            DataTable dt = new DataTable();
            try
            {
                //SQL Query to search Data from DAtabase
                string query = "SELECT * FROM  productdetails WHERE productid Like '%" + keyword + "%' OR product_name like '%" + keyword + "%' OR inv_no like '%" + keyword + "%' OR code like '%" + keyword + "%'"; 
                 //For Executing Command
                 SqlCommand cmd = new SqlCommand(query, conn);
                //Getting DAta from dAtabase
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Database Connection Open
                conn.Open();
                //Fill Data in our DataTable
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                //Throw Message if any error occurs
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Closing Connection
                conn.Close();
            }
            //Return the value in DataTable
            return dt;
        }
        #endregion

        #region reports

        public DataTable ShowSalesDataByDate()
        {
            //MEthod to connect Database
            connclass c = new connclass();
            SqlConnection conn = new SqlConnection(c.connection);
            //TO hold the data from database 
            DataTable dt = new DataTable();
            try
            {
                //SQL Query to Get Data From DAtabase
                string query = "select top 7 SUM(convert (int, total_payable)) as Sales, CONVERT(DATE, sales_date) as [Date]\r\nfrom invoice\r\ngroup by CONVERT(DATE, sales_date)\r\norder by CONVERT(DATE, sales_date)  desc";
                //For Executing Command
                SqlCommand cmd = new SqlCommand(query, conn);
                //Getting DAta from dAtabase
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Database Connection Open
                conn.Open();
                //Fill Data in our DataTable
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                //Throw Message if any error occurs
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Closing Connection
                conn.Close();
            }
            //Return the value in DataTable
            return dt;

        }

        #endregion

        #region reports

        public DataTable ShowSales(string doctor,string d1, string d2)
        {
            //MEthod to connect Database
            connclass c = new connclass();
            SqlConnection conn = new SqlConnection(c.connection);
            //TO hold the data from database 
            DataTable dt = new DataTable();

            if(doctor == null || doctor == "-1")
            {
                doctor = "null";
            }


            try
            {
                //SQL Query to Get Data From DAtabase
                string query = "select  i.inv_no,   ";

                query += " ISNULL(d.doctor,'CASH') as InvoiceOf ,  "; 
                query += " \tSUM(convert(int,pd.total)) as Total, "; 
                query += " SUM(convert(int,pd.purchase_price)) as CostPrice,  "; 
                query += " SUM(convert(int,pd.total)) - SUM(convert(int,pd.purchase_price)) as Profit, "; 
                query += " i.sales_date "; 
                query += "  from invoice i "; 
                query += " inner join productdetails pd on pd.inv_no = i.inv_no  "; 
                query += " left join doctors d on d.doctorsid = i.doctorsid  "; 
                query += " where (" + doctor + " is null OR i.doctorsid =  " + doctor + ") "; 
                if((d1 != null) && (d2 != null))
                {
                    query += " AND (   i.sales_date >= '" + d1 + "')  AND  (   i.sales_date <= '" + d2 + "')";

                }
                 


                query += " group by  i.inv_no,d.doctor,i.sales_date  ";

               
                //For Executing Command
                SqlCommand cmd = new SqlCommand(query, conn);

                 //Getting DAta from dAtabase
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Database Connection Open
                conn.Open();
                //Fill Data in our DataTable
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                //Throw Message if any error occurs
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Closing Connection
                conn.Close();
            }
            //Return the value in DataTable
            return dt;

        }



        public DataTable ShowSalesByProduct(  string d1, string d2)
        {
            //MEthod to connect Database
            connclass c = new connclass();
            SqlConnection conn = new SqlConnection(c.connection);
            //TO hold the data from database 
            DataTable dt = new DataTable();

           

            try
            {
                //SQL Query to Get Data From DAtabase
                string query = "select productid, ";

                query += " product_name,  ";
                query += " SUM(convert (int, quantity)) as Quantity, ";
                query += " SUM(convert(int, total)) as Total,    ";
                query += " SUM(convert(int, purchase_price)) as CostPrice, ";
                query += " SUM(convert(int, total)) - SUM(convert(int, purchase_price)) as Profit  ";
                query += "  from productdetails ";

               
                if ((d1 != null) && (d2 != null))
                {
                    query += " WHERE  added_date >= '" + d1 + "'   AND    added_date <= '" + d2 + "'";

                }



                query += " group by productid,product_name  ";
                query += " order By SUM(convert (int, quantity)) desc  ";


                //For Executing Command
                SqlCommand cmd = new SqlCommand(query, conn);

                //Getting DAta from dAtabase
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Database Connection Open
                conn.Open();
                //Fill Data in our DataTable
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                //Throw Message if any error occurs
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Closing Connection
                conn.Close();
            }
            //Return the value in DataTable
            return dt;

        }

        #endregion
    }
}
