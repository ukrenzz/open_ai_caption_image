using AC_Image.Services.Imgur;
using AC_Image.Services;
using AC_Image.Config;
using AC_Image.Models;
using System.Net;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using AC_Image.Exceptions;

namespace AC_Image
{
    public partial class MainForm : Form
    {
        AccountService accountService = new();
        AlbumService albumServices = new();
        ImageServices imageServices = new();
        StringService stringService= new();
        SecretKeys secretKeys = new();

        CancellationTokenSource cancellationToken = new CancellationTokenSource();

        ImageList imageList = new ImageList();

        string username = "";
        int lastAlbumsSelectedIndex = 0;

        public MainForm()
        {
            InitializeComponent();

            txtUsername.Text = "";

            lvImages.Enabled = false;
            lvAlbums.Enabled = false; 
        }
        
        

        private async void Form1_Load(object sender, EventArgs e)
        {
            try {
                // Open MyImages tab page first
                tabControl1.SelectedTab = tabControl1.TabPages["tpMyImages"];

                // Get username
                var getUsername = await Task.Run(() => accountService.getAccount());

                if(getUsername.success && getUsername.data!= null)
                {
                    this.username = getUsername.data.account_url;

                    txtUsername.Text = "Hi, " + username;

                    await generateAlbumViews();
                    await generateImagesViews(cts: this.cancellationToken.Token, lvAlbums.Items[1].SubItems[2].Text);
                } 
                else
                {
                    throw new AppException(getUsername.message ?? "", "Account Request Failed");
                }
            } 
            catch (AppException appEx)
            {
                AppService.DefaultMessageBox(appEx.message, appEx.caption);
            } 
            catch (Exception ex) {
                AppService.DefaultMessageBox(ex.Message);
            }
        }

        private async Task generateAlbumViews()
        {
            try
            {
                // Refresh items in album listview
                lvAlbums.Items.Clear();

                // Init "All" to show all images
                // Get all Images and get images count
                var getImages = await Task.Run(() => imageServices.getImages());

                if(getImages.success && getImages.data!= null)
                {
                    ListViewItem firstItem = new ListViewItem();
                    firstItem.Text = "All";
                    firstItem.SubItems.Add(getImages.data.Count.ToString());
                    lvAlbums.Items.Add(firstItem);
                } else
                {
                    throw new AppException($"Can't fetch all images. {getImages.message}.", "Fetch data error!");
                }

                // Get all albums
                var getAlbums = await Task.Run(() => albumServices.getAlbums(username));

                if(getAlbums.success && getAlbums.data!= null) {
                    foreach (var album in getAlbums.data)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Tag = album;
                        item.Text = album.title;
                        item.SubItems.Add(album.images_count.ToString());
                        item.SubItems.Add(album.id.ToString());

                        lvAlbums.Items.Add(item);
                    }
                } else
                {
                    throw new AppException($"Can't fetch all albums. {getAlbums.message}.", "Fetch data error!");
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
        }

        private async Task addImageViewItem(Models.Image image, int index, CancellationToken cts)
        {
            try
            {
                cts.ThrowIfCancellationRequested();

                ListViewItem item = new ListViewItem();
                item.Tag = image;

                item.Text = image.link.ToString();
                item.SubItems.Add($"{image.name}");
                item.SubItems.Add($"{image.width}x{image.height}");
                item.SubItems.Add($"{image.link}");
                item.SubItems.Add($"{image.id}");

                var imageResult = await Task.Run(() => new NetworkService().DownloadImage(image.link, targetSize: image.size), cts);
                this.imageList.Images.Add(image.id, imageResult);

                lvImages.LargeImageList = this.imageList;

                item.ImageKey = image.id;

                lvImages.Items.Add(item);
            } catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }                       
        }

        private async Task generateImagesViews(CancellationToken cts, string? albumId = null)
        {
            try
            {
                //lock list view when loading
                lvAlbums.Enabled = false;
                lvImages.Enabled = false;

                // Clear before update
                lvImages.Clear();

                // Config ImageList
                this.imageList.ImageSize = new Size(240, 135);
                this.imageList.ColorDepth = ColorDepth.Depth32Bit;
                this.imageList.TransparentColor = Color.Transparent;

                // Generate Images to List
                ImgurResponse<List<Models.Image>> images = new ImgurResponse<List<Models.Image>>();
                if (albumId != null)
                {
                    images = await Task.Run(() => imageServices.getImages(albumId));
                }
                else
                {
                    images = await Task.Run(() => imageServices.getImages());
                }
                
                // Define task list
                List<Task> tasks = new List<Task>();
                int index = 0;

                if(images.success && images.data != null)
                {
                    foreach (var image in images.data)
                    {
                        tasks.Add(addImageViewItem(image, index, cts));
                        index++;
                    }

                    await Task.WhenAll(tasks);
                }
                else
                {
                    throw new AppException($"Images could't downloading. {images.message}.", "Fetch data error!");
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
                //unlock list view when complete
                lvAlbums.Enabled = true;
                lvImages.Enabled = true;
            }

            
        }


        ListViewItem selectedImageItemTemp = new ListViewItem();
        private void lvImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvImages.SelectedItems.Count > 0)
            {
                this.selectedImageItemTemp = lvImages.SelectedItems[0];
            }
            else
            {
                this.selectedImageItemTemp = new ListViewItem();
            }
        }

        private void detailCtxRightClickImage_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(selectedImageItemTemp.ImageKey);
            if(selectedImageItemTemp.Tag != null )
            {
                var image = selectedImageItemTemp.Tag as Models.Image;

                ImageDetail imageDetail = new ImageDetail(image.id);
            
                imageDetail.ShowDialog();
            }
        }

        private void ctxRightClickImage_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void crxRciCopyTitle_Click(object sender, EventArgs e)
        {
            if(selectedImageItemTemp != null && selectedImageItemTemp.Tag != null)
            {
                var data = selectedImageItemTemp.Tag as Models.Image;

                if(data != null && data.title != "") { Clipboard.SetText(data.title); }

            }
        }

        private void crxRciCopyLink_Click(object sender, EventArgs e)
        {
            if (selectedImageItemTemp != null && selectedImageItemTemp.Tag != null)
            {
                var data = selectedImageItemTemp.Tag as Models.Image;

                if (data != null) { Clipboard.SetText(data.link); }

            }
        }

        private void crxRciCopyDescription_Click(object sender, EventArgs e)
        {
            if (selectedImageItemTemp != null && selectedImageItemTemp.Tag != null)
            {
                var data = selectedImageItemTemp.Tag as Models.Image;
                string? content = stringService.imgurDescToDesc(data.description);

                if (data != null && content != null && content != "") { Clipboard.SetText(content); }

            }
        }

        private void crxRciCopyKeywords_Click(object sender, EventArgs e)
        {
            if (selectedImageItemTemp != null && selectedImageItemTemp.Tag != null)
            {
                var data = selectedImageItemTemp.Tag as Models.Image;
                string? content = stringService.imgurDescToKeywords(data.description);

                if (data != null && content != null && content != "") { Clipboard.SetText(content); }

            }
        }

        private void crxRciCopyHashtags_Click(object sender, EventArgs e)
        {
            if (selectedImageItemTemp != null && selectedImageItemTemp.Tag != null)
            {
                var data = selectedImageItemTemp.Tag as Models.Image;
                string? content = stringService.imgurDescToHastags(data.description);

                if (data != null && content != null && content != "") { Clipboard.SetText(content); }

            }
        }

        private void lvImages_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var lv = sender as ListView;
                var item = lv.HitTest(e.Location).Item;

                if (item != null)
                {
                    lv.FocusedItem = item;
                    ctxRightClickImage.Show(lv, e.Location);


                }
            }
        }

        private async void lvAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAlbums.SelectedItems.Count > 0)
            {
                int selectedIndex = lvAlbums.Items.IndexOf(lvAlbums.SelectedItems[0]);


                if (selectedIndex > 0 && selectedIndex != this.lastAlbumsSelectedIndex)
                {
                    var selected = lvAlbums.SelectedItems[0].Tag as Album;

                    string albumId = selected.id;

                    await generateImagesViews(this.cancellationToken.Token, albumId);
                }
                else if (selectedIndex == 0 && selectedIndex != this.lastAlbumsSelectedIndex)
                {
                    await generateImagesViews(cts: this.cancellationToken.Token);
                }

                // Set last albums index selected
                this.lastAlbumsSelectedIndex = selectedIndex;
            }
        }
    }
}