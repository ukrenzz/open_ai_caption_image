using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_Image.Exceptions
{
    [Serializable]
    public class AppException : Exception
    {
        public AppException() { }
        public AppException(string message)
        {
            this.caption = "Application get an exception!";
            this.message = message;
        }
        public AppException(string caption, string message) {
            this.caption = caption;
            this.message = message;
        }
        public AppException(string caption, string message, MessageBoxButtons buttons)
        {
            this.caption = caption;
            this.message = message;
            this.buttons = buttons;
        }
        public AppException(string caption, string message, MessageBoxIcon icon)
        {
            this.caption = caption;
            this.message = message;
            this.icon = icon;
        }
        public AppException(string caption, string message, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            this.caption = caption;
            this.message = message;
            this.buttons = buttons;
            this.icon = icon;
        }

        public string caption { get; init; }
        public string message { get; init; }
        public MessageBoxButtons? buttons { get; init; }
        public MessageBoxIcon? icon { get; init;}
        
    }
}
