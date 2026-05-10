using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_university
{
    public class Staff
    {
        public int s_id { get; set; }
        public string s_name { get; set; } = "";
        public string s_phone { get; set; } = "";
        public string s_email { get; set; } = "";
        public decimal s_salary { get; set; }
        public DateTime hire_date { get; set; }
        public int d_code { get; set; }
        public int stf_p_id { get; set; }
    }

}