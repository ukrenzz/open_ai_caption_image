using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_Image.Models
{
    internal class ImgurResponse<T>
    {
        public ImgurResponse() { }
        public ImgurResponse(int statusCode, string message)
        {

            this.status = statusCode;
            this.message = message;
        }

        public T data { get; init; }
        public bool success { get; init; }
        public int status { get; init; }
        public string? message { get; init; }
    }

    internal class ImgurResponse
    {
        public ImgurResponse() { }
        public ImgurResponse(int statusCode, string message)
        {

            this.status = statusCode;
            this.message = message;
        }

        public object data { get; init; }
        public bool success { get; init; }
        public int status { get; init; }
        public string? message { get; init; }
    }
}
