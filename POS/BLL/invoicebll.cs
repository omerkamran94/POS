using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BLL
{
    class invoicebll
    {
        public int invoiceid { get; set; }
        public int inv_no { get; set; }
        public int doctorsid { get; set; }
        public string doctor { get; set; }
        public string customer_name { get; set; }
        public string total_payable { get; set; }
        public string paid_amount { get; set; }
        public string discount { get; set; }
        public string due_amount { get; set; }
        public string change_amount { get; set; }
        public int added_by { get; set; }
        public DateTime sales_date { get; set; }
    }
}
