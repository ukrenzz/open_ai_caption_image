using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_Image.Exceptions
{
    [Serializable]
    internal class ImgurException : Exception
    {
        public ImgurException(int statusCode, string message)
        {
            this.statusCode = statusCode;
            this.message = message;
        }
        public int statusCode { get; init; }
        public string? message { get; init; }
    }
}
