using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_Image.Models
{
    internal class IRestResponse
    {
        public IRestResponse(int status = -1) {
            this.status = status;
            this.success = false;
        }

        public object data { get; set; }
        public bool success { get; set; } 
        public int status { get; set; }
    }
}
