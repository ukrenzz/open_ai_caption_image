using AC_Image.Models;
using AC_Image.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AC_Image.Services.Imgur
{
    internal class ImageServices : ImgurProvider
    {
        public ImageServices() { }

        public async Task<ImgurResponse<List<Models.Image>>> getImages()
        {

            string resource = "account/me/images";

            var response = await this.Get<List<Models.Image>>(resource);

            return response;
        }

        public async Task<ImgurResponse<List<Models.Image>>> getImages(string albumId)
        {

            string resource = "album/" + albumId + "/images";

            var response = await this.Get<List<Models.Image>>(resource);

            return response;
        }

        public async Task<ImgurResponse<Models.Image>> getImage(string imageId)
        {

            string resource = "image/" + imageId;

            var response = await this.Get<Models.Image>(resource);

            return response;
        }

        public async Task<ImgurResponse> updateImageInformation(string imageId, string? imageTitle = null, string? description = null, string? keywords = null, string? hastags = null)
        {
            try
            {
                string resource = "image/" + imageId;
                string descText = description ?? "Undescribe";
                object body = new { };

                descText = new StringService().ContentsToDesc(descText, keywords, hastags);

                if (imageTitle != null)
                {
                    body = new
                    {
                        title = imageTitle ,
                        description = descText
                    };
                } 
                else
                {
                    body = new
                    {
                        description = descText
                    };
                }

                var response = await this.Post(resource, body);

                return response;
            }
            catch (Exception ex) 
            {
                AppService.DefaultMessageBox(ex.Message, caption: "Update image error!");
                return new ImgurResponse(500, ex.Message);
            }
        }

        public List<string> getImagesLink(List<Models.Image> images)
        {
            List<string> result = new List<string>();

            foreach (var image in images)
            {
                result.Add(image.link.ToString());
            }

            return result;
        }
    }
}
