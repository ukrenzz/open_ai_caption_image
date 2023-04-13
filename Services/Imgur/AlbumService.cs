using AC_Image.Models;
using AC_Image.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AC_Image.Services.Imgur
{
    internal class AlbumService : ImgurProvider
    {

        public AlbumService() {}

        public async Task<ImgurResponse<List<Album>>> getAlbums(string username)
        {

            string resource = "account/" + username + "/albums";

            var response = await this.Get<List<Album>>(resource);

            return response;
        }
    }
}
