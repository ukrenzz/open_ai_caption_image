using AC_Image.Exceptions;
using AC_Image.Models;
using AC_Image.Services;
using AC_Image.Services.Imgur;
using AC_Image.Services.OpenAI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace AC_Image
{
    public partial class ImageDetail : Form
    {
        readonly InternalAppServices internalAppServices = new();
        readonly ImageServices imageServices = new();
        readonly StringService stringService = new();
        readonly TextAIService textServices = new();

        readonly string imageId;
        Models.Image imageGlobalData;
        public ImageDetail(string imageId)
        {
            this.imageId = imageId;

            InitializeComponent();

            // Disable all button while image loading
            DisableAllButtons();
        }

        private void EnableAllButtons()
        {
            btnAutoCaption.Enabled = true;
            btnGenerateContent.Enabled = true;
            btnCopyTitle.Enabled = true;
            btnCopyLink.Enabled = true;
            btnCopyCaption.Enabled = true;
            btnCopyDescription.Enabled = true;
            btnCopyKeywords.Enabled = true;
            btnCopyHastags.Enabled = true;
        }

        private void DisableAllButtons()
        {
            btnAutoCaption.Enabled = false;
            btnGenerateContent.Enabled = false;
            btnCopyTitle.Enabled = false;
            btnCopyLink.Enabled = false;
            btnCopyCaption.Enabled = false;
            btnCopyDescription.Enabled = false;
            btnCopyKeywords.Enabled = false;
            btnCopyHastags.Enabled = false;
        }

        

        private async void ImageDetail_Load(object sender, EventArgs e)
        {
            try
            {
                tsProgressBar.Visible = true;
                Progress<ImageDownloadProgressReport> progress = new();
                progress.ProgressChanged += ImageDownloadProgress_ProgressChanged;


                // Get image data from API
                var getImage = await Task.Run(() => imageServices.getImage(this.imageId));

                if(getImage.success && getImage.data != null)
                {
                    this.imageGlobalData = getImage.data;

                    // Download image
                    if (getImage.data.link != null)
                    {
                        // Set image to picture box
                        var image = await Task.Run(() => new NetworkService().DownloadImage(getImage.data.link, progress, targetSize: getImage.data.size));

                        // Set image and detail to display
                        if (image != null)
                        {
                            Size newImageSize = image.Size;
                            // Set image to picture box
                            if (image.Width > image.Height)
                            {
                                newImageSize = AppService.GetSizeOriginalAspectRatio(image.Width, image.Height, toWidth: pbImageDetail.Width - 10);
                            }
                            else if (image.Height > image.Width)
                            {
                                newImageSize = AppService.GetSizeOriginalAspectRatio(image.Width, image.Height, toHeight: pbImageDetail.Height - 10);
                            }

                            //MessageBox.Show($"{newImageSize.Width}, {newImageSize.Height}");

                            var responsiveImage = new Bitmap(image, newImageSize);


                            pbImageDetail.Image = System.Drawing.Image.FromHbitmap(responsiveImage.GetHbitmap());
                            //pbImageDetail.Image = image;
                        }

                        // Set image detail
                        rtbTitle.Text = getImage.data.title;
                        txtLink.Text = getImage.data.link;
                        txtFilename.Text = getImage.data.name;
                        txtDimension.Text = $"{getImage.data.width} x {getImage.data.height}";
                        lblViews.Text = getImage.data.views.ToString();
                        lblSize.Text = stringService.int2FileSize(getImage.data.size);

                        // Set image content
                        rtbDescription.Text = stringService.imgurDescToDesc(getImage.data.description).Trim();
                        rtbKeywords.Text = stringService.imgurDescToKeywords(getImage.data.description).Trim();
                        rtbHashtags.Text = stringService.imgurDescToHastags(getImage.data.description).Trim(); 
                    }

                    tsLblDownloadedStatus.Text = stringService.int2FileSize(getImage.data.size);
                }
                else
                {
                    throw new AppException($"Images could't downloading. {getImage.message}.", "Fetch data error!");
                }
            }
            catch (AppException appEx)
            {
                AppService.DefaultMessageBox(appEx.message, appEx.caption);
            }
            catch (Exception ex)
            {
                AppService.DefaultMessageBox(ex.Message);
            }
            finally 
            {
                tsProgressBar.Visible = false;
                EnableAllButtons();
            }
        }

        private void ImageDownloadProgress_ProgressChanged(object? sender, ImageDownloadProgressReport e)
        {
            tsLblDownloadedStatus.Text = $"{stringService.double2FileSize(e.downloadedByte)} / {stringService.double2FileSize(e.size)}";
            tsProgressBar.Value = e.percentageComplete;
        }


        private async void BtnAutoCaption_Click(object sender, EventArgs e)
        {
            internalAppServices.InfiniteLoading(tsProgressBar, true);
            var getCaption = await Task.Run(() => textServices.GetCaption(imageGlobalData.link));
            string caption = getCaption.Trim().Replace("\"", "");

            if (caption != null) { 
                rtbTitle.Text = caption;

                var updateImageInformation = await Task.Run(() => imageServices.updateImageInformation(this.imageId, caption));

                if (updateImageInformation != null && updateImageInformation.success)
                {
                    imageGlobalData.title = caption;
                    MessageBox.Show("Your image title has been change.", "Update Image Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else
            {
                AppService.DefaultMessageBox("Update caption failed");
            }


            internalAppServices.InfiniteLoading(tsProgressBar, false);
        }

        private void BtnCopyTitle_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtbTitle.Text);
        }

        private void BtnCopyLink_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtLink.Text);
        }
        private void btnCopyCaption_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtbCaption.Text);
        }
        private void BtnCopyDescription_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtbDescription.Text);
        }

        private void BtnCopyKeywords_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtbKeywords.Text);
        }

        private void BtnCopyHastags_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtbHastags.Text);
        }

        private async void btnGenerateContent_Click(object sender, EventArgs e)
        {
            
            try
            {
                // Start with disable button and running progress bar
                btnGenerateContent.Enabled = true;
                internalAppServices.InfiniteLoading(tsProgressBar, true);
                string getDescription = "";
                string getKeywords = "";
                string getHashtags = "";



                if (cbDescription.Checked)
                {
                    getDescription = await Task.Run(() => textServices.GetDescription(imageGlobalData.link));

                    if(getDescription != null)
                    {
                        rtbDescription.Text = stringService.removeSpace(getDescription).Trim();
                    } 
                    else
                    {
                        AppService.DefaultMessageBox("Error get description", "Generate content failed!");
                    }
                }

                if (cbKeywords.Checked)
                {
                    getKeywords = await Task.Run(() => textServices.GetKeywords(imageGlobalData.link));

                    if (getKeywords != null)
                    {
                        rtbKeywords.Text = stringService.Convert2CapitalEachWord(getKeywords).Trim();
                    }
                    else
                    {
                        AppService.DefaultMessageBox("Error get description", "Generate content failed!");
                    }
                }

                if (cbHashtags.Checked)
                {
                    getHashtags = await Task.Run(() => textServices.GetHashtags(imageGlobalData.link));

                    if (getHashtags != null)
                    {
                        rtbHashtags.Text = stringService.string2Hashtag(getHashtags).Trim();
                    }
                    else
                    {
                        AppService.DefaultMessageBox("Error get description", "Generate content failed!");
                    }
                }

                var updateImage = await imageServices.updateImageInformation(imageGlobalData.id, description: getDescription, keywords: getKeywords, hastags: getHashtags);
            
                if(updateImage != null && updateImage.success)
                {
                    imageGlobalData.description = stringService.ContentsToDesc(getDescription, getKeywords, hastags: getHashtags);
                    MessageBox.Show("Your image description has been change.", "Update Image Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    throw new Exception("Update description failed");
                }
            }
            catch (Exception ex)
            {
                AppService.DefaultMessageBox(ex.Message);
            }
            finally
            {
                btnGenerateContent.Enabled = true;
                internalAppServices.InfiniteLoading(tsProgressBar, false);
            }
        }

        
    }
}
