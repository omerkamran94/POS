using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.BLL;

namespace POS.DAL
{
    class invoicedal
    {
        #region Insert data into database
        public bool insert(invoicebll u)
        {
            //Create a boolean variable and set its value to false and return it
            bool issucess = false;
            //MEthod to connect Database
            connclass c = new connclass();
            SqlConnection conn = new SqlConnection(c.connection);
            try
            {
                //SQL Query to insert Data in DAtabase
                string query = "Insert into invoice(inv_no,customer_name,total_payable,paid_amount,discount,due_amount,change_amount,added_by,sales_date,doctorsid)Values(@inv_no,@customer_name,@total_payable,@paid_amount,@discount,@due_amount,@change_amount,@added_by,@sales_date,@doctorsid)";
                //For Executing Command
                SqlCommand cmd = new SqlCommand(query, conn);
                //Passing Values to the Variables
                cmd.Parameters.AddWithValue("@inv_no", u.inv_no);
                cmd.Parameters.AddWithValue("@customer_name", u.customer_name);
                cmd.Parameters.AddWithValue("@total_payable", u.total_payable);
                cmd.Parameters.AddWithValue("@paid_amount", u.paid_amount);
                cmd.Parameters.AddWithValue("@discount", u.discount);
                cmd.Parameters.AddWithValue("@due_amount", u.due_amount);
                cmd.Parameters.AddWithValue("@change_amount", u.change_amount);
                cmd.Parameters.AddWithValue("@added_by", u.added_by);
                cmd.Parameters.AddWithValue("@sales_date", u.sales_date);
                cmd.Parameters.AddWithValue("@doctorsid", u.doctorsid);
                //Database Connection Open
                conn.Open();
                //To execute non query
                int row = cmd.ExecuteNonQuery();
                //If the query is executed Successfully then the value to rows will be greater than 0 else it will be less than 0
                if (row > 0)
                {
                    //Query Sucessfull
                    issucess = true;
                }
                else
                {
                    //Query Failed
                    issucess = false;
                }
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

            return issucess;
        }
        #endregion

        #region Search Data From DataBase (for Return Items)
        public DataTable Search(string id)
        {
            //MEthod to connect Database
            connclass c = new connclass();
            SqlConnection conn = new SqlConnection(c.connection);
            //TO hold the data from database 
            DataTable dt = new DataTable();
            try
            {
                //SQL Query to search Data from DAtabase
                string query = "SELECT * FROM  invoice WHERE inv_no = " + id ;
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

        #region Delete record in Data Base
        public bool delete(invoicebll u)
        {
            //Create a boolean variable and set its value to false and return it
            bool issucess = false;
            //MEthod to connect Database
            connclass c = new connclass();
            SqlConnection conn = new SqlConnection(c.connection);
            try
            {
                //SQL Query to delete Data in DAtabase
                string query = "DELETE FROM invoice WHERE invoiceid=@id";
                //For Executing Command
                SqlCommand cmd = new SqlCommand(query, conn);
                //Passing Values to the Variables
                cmd.Parameters.AddWithValue("@id", u.invoiceid);
                //Database Connection Open
                conn.Open();
                //To execute non query
                int row = cmd.ExecuteNonQuery();
                //If the query is executed Successfully then the value to rows will be greater than 0 else it will be less than 0
                if (row > 0)
                {
                    //Query Sucessfull
                    issucess = true;
                }
                else
                {
                    //Query Failed
                    issucess = false;
                }
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

            return issucess;
        }
        #endregion

        #region Update data into database
        public bool update(invoicebll u)
        {
            //Create a boolean variable and set its value to false and return it
            bool issucess = false;
            //MEthod to connect Database
            connclass c = new connclass();
            SqlConnection conn = new SqlConnection(c.connection);
            try
            {
                //SQL Query to insert Data in DAtabase
                string query = "UPDATE invoice set inv_no=@inv_no, customer_name=@customer_name,total_payable=@total_payable,paid_amount=@paid_amount,discount=@discount,due_amount=@due_amount,change_amount=@change_amount,added_by=@added_by,sales_date=@sales_date WHERE invoiceid=@invoiceid";
                //For Executing Command
                SqlCommand cmd = new SqlCommand(query, conn);
                //Passing Values to the Variables
                cmd.Parameters.AddWithValue("@invoiceid", u.invoiceid);
                cmd.Parameters.AddWithValue("@inv_no", u.inv_no);
                cmd.Parameters.AddWithValue("@customer_name", u.customer_name);
                cmd.Parameters.AddWithValue("@total_payable", u.total_payable);
                cmd.Parameters.AddWithValue("@paid_amount", u.paid_amount);
                cmd.Parameters.AddWithValue("@discount", u.discount);
                cmd.Parameters.AddWithValue("@due_amount", u.due_amount);
                cmd.Parameters.AddWithValue("@change_amount", u.change_amount);
                cmd.Parameters.AddWithValue("@added_by", u.added_by);
                cmd.Parameters.AddWithValue("@sales_date", u.sales_date);
                //Database Connection Open
                conn.Open();
                //To execute non query
                int row = cmd.ExecuteNonQuery();
                //If the query is executed Successfully then the value to rows will be greater than 0 else it will be less than 0
                if (row > 0)
                {
                    //Query Sucessfull
                    issucess = true;
                }
                else
                {
                    //Query Failed
                    issucess = false;
                }
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

            return issucess;
        }
        #endregion

        #region Show Data between Two dates
        public DataTable BetweenTwoDates(string text,string d1, string d2,bool check_date)
        {
            //MEthod to connect Database
            connclass c = new connclass();
            SqlConnection conn = new SqlConnection(c.connection);
            //TO hold the data from database 
            DataTable dt = new DataTable();
            try
            {
                //SQL Query to insert Data in DAtabase
                string query = "SELECT * FROM invoice ";
                if (check_date)
                {
                    query += " WHERE  sales_date >= '" + d1 + "'   AND    sales_date <= '" + d2 + "'";
                }
                else if (!check_date)
                {
                    query += " WHERE inv_no = " + (text == "" ? "null" : text);
                }
                
               
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

            return dt;
        }
        #endregion

        #region Show Data Monthly And Daily
        public DataTable MonthlyAndDailyData(string d1, string d2)
        {
            //MEthod to connect Database
            connclass c = new connclass();
            SqlConnection conn = new SqlConnection(c.connection);
            //TO hold the data from database 
            DataTable dt = new DataTable();
            //string d1 = DateTime.Now.ToString();
            try
            {
                //SQL Query to insert Data in DAtabase
                string query = "SELECT* FROM invoice WHERE sales_date BETWEEN '" + d2 + "' AND '" + d1 + "' ";
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

            return dt;
        }
        #endregion

        public string GetMaxInvoiceId()
        {
            //Create a boolean variable and set its value to false and return it
            string invoiceId = "1";

            int a;
            //MEthod to connect Database
            connclass c = new connclass();
            SqlConnection conn = new SqlConnection(c.connection);
            try
            {
                //SQL Query to insert Data in DAtabase
                string query = "Select Max (inv_no) From invoice";
                //For Executing Command
                SqlCommand cmd = new SqlCommand(query, conn);
                //Database Connection Open
                conn.Open();
                //To execute reader
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    string val = dr[0].ToString();
                    if (val == "")
                    {
                        invoiceId = "1";
                    }
                    else
                    {
                        a = Convert.ToInt32(dr[0].ToString());
                        a = a + 1;
                        invoiceId = a.ToString();
                    }

                }
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

            return invoiceId;
        }
    }


}
