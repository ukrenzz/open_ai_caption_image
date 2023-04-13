using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_Image.Models
{
    internal class ImageDownloadProgressReport
    {
        public int percentageComplete { get; set; } = 0;
        public double downloadedByte { get; set; } = 0;
        public double size { get; set; } = 0;

        public Models.Image downloadImage { get; set; }
    }
}
