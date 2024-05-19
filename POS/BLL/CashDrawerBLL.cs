using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BLL
{
    public class CashDrawerBLL
    {
        public int CashDrawerId { get; set; }
        public decimal CashDrawerStart { get; set; }
        public decimal CashDrawerAdded { get; set; }
        public decimal CashDrawerRemoved { get; set; }
        public DateTime added_date { get; set; }
        public int added_by { get; set; }
        public bool active { get; set; }


    }
}
