using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_Image.Models
{

    internal class OpenAIChoiceResponse
    {
        public string text { get; init; }
        public int index { get; init; }
        public string finish_reason { get; init; }
    }
}
