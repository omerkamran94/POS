using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BLL
{
   public class ExpenseBLL
    {
        public int ExpenseId { get; set; }
        public int CashDrawerId { get; set; }
        public string ExpenseDescription { get; set; }
        public decimal ExpenseAmount { get; set; }
        public string Type { get; set; }
        public DateTime added_date { get; set; }
        public int added_by { get; set; }
        public bool active { get; set; }


    }
}
