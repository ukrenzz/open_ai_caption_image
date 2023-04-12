using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_Image.Models
{
    internal class Image
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int datetime { get; set; }
    
        public string type { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int size { get; set; }
        public int views { get; set; }
        public string deletehash { get; set; }
        public string name { get; set; }
        public string section { get; set; }
        public string link { get; set; }

    }
}
