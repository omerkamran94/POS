using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BLL
{
    class Doctorsbll
    {
        public int doctorsid { get; set; }
        public string doctor { get; set; }
        public int added_by { get; set; }
        public DateTime added_date { get; set; }
        public bool active { get; set; }
    }
}
