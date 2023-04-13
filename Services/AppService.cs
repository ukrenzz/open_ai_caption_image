using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AC_Image.Services
{
    public class InternalAppServices
    {
        public void InfiniteLoading(ToolStripProgressBar progressBar, bool running)
        {
            if (running)
            {
                progressBar.Style = ProgressBarStyle.Marquee;
                progressBar.Visible = true;
            }
            else
            {
                progressBar.Style = ProgressBarStyle.Continuous;
                progressBar.Visible = false;
            }
        }
    }

    static class AppService
    {
        static public void DefaultMessageBox(string message, string? caption = null, MessageBoxButtons? buttons = null, MessageBoxIcon? icon = null)
        {
            string defaultCaption = caption ?? "App has been error!";
            MessageBoxButtons defaultButtons = buttons ?? MessageBoxButtons.OK;
            MessageBoxIcon defaultIcon = icon ?? MessageBoxIcon.Error;

            MessageBox.Show(message, defaultCaption, defaultButtons, defaultIcon);
        }

        static public Size GetSizeOriginalAspectRatio(int originalWidth, int originalHeight, int? toWidth = null, int? toHeight = null)
        {
            // Using toWidth for new width of a object
            // Using toHeight for new height of a object 

            Size result = new Size(originalWidth, originalHeight);

            try
            {
                if (originalHeight > 0 && originalWidth > 0 && (toWidth > 0 || toHeight > 0))
                {
                    // Get aspect ratio
                    float ratio = originalWidth > originalHeight ? (float)originalHeight / originalWidth : (float)originalWidth / originalHeight;
                    int newWidth = 0;
                    int newHeight = 0;

                    if (toWidth != null && toHeight != null)
                    {
                        MessageBox.Show("New size just can set one of them");
                    }
                    else if (toWidth != null && toWidth > 0)
                    {
                        newWidth = toWidth ?? originalWidth;
                        newHeight = (int)((toWidth + 0.0 ?? originalWidth + 0.0) * ratio);
                    }
                    else if (toHeight != null && toHeight > 0)
                    {
                        newWidth = (int)((toHeight + 0.0 ?? originalHeight + 0.0) * ratio);
                        newHeight = toHeight ?? originalHeight;
                    }

                    result = new Size(newWidth, newHeight);

                }
                else
                {
                    MessageBox.Show("Original width and original height at least 0");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;
        }

        static void InfiniteLoading(ToolStripProgressBar progressBar, bool running)
        {
            if (running)
            {
                progressBar.Style = ProgressBarStyle.Marquee;
                progressBar.Visible = true;
            }
            else
            {
                progressBar.Style = ProgressBarStyle.Continuous;
                progressBar.Visible = true;
            }
        }
    
        static public string GetImageCacheDirectory()
        {
            if(Properties.Settings.Default.DefaultImageCacheDirectory == Properties.Settings.Default.ImageCacheDirectory)
            {
                return System.IO.Directory.GetCurrentDirectory() + Properties.Settings.Default.DefaultImageCacheDirectory;
                //return Path.GetDirectoryName(Path.Combine(Assembly.GetEntryAssembly().Location, Properties.Settings.Default.DefaultImageCacheDirectory));
            }

            return Properties.Settings.Default.ImageCacheDirectory;
        }
    }
}
