using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_Image.Models
{
    internal class Account
    {
        public int id { get; set; }
        public string url { get; set; }
        public string account_url { get; set; }
        public string bio { get; set; }
        public float reputation { get; set; }
        public int created { get; set; }
    }
}
