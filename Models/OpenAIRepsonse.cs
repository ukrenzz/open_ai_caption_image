using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_Image.Models
{
    internal class OpenAIRepsonse
    {

        public string id { get; init;  }
        public int created { get; init;  }
        public OpenAIChoiceResponse[] choices { get; set; }
        public object usage { get;  init; }

        public string message { get; init; }
        public int status { get; init; }
    }
}
