using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BLL
{
    class Categoriesbll
    {
        public int categoriesid { get; set; }
        public string category { get; set; }
        public string supplier { get; set; }
        public int suppliersid { get; set; }
        public int added_by { get; set; }
        public DateTime added_date { get; set; }
        public bool active { get; set; }
    }
}
