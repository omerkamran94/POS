using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DAL
{
    //Creating Connection Class 
    //AttachDbFileName=|DataDirectory|\Database\pos.mdf;
    class connclass
    {
        public string connection = @"Data Source=OMER-KAMRAN\SQLEXPRESS01;Initial Catalog=pos;Integrated Security=True";
        //public string connection = @"data source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\pointofsale.mdf;Integrated Security=True;Connect Timeout=30";
    }
}
