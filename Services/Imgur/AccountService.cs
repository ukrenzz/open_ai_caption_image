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
    internal class AccountService : ImgurProvider
    {
        public AccountService() { }

        public async Task<ImgurResponse<ImgurAccount>> getAccount(string username)
        {
            string resource = "account/" + username;

            var response = await this.Get<ImgurAccount>(resource);

            return response;
        }

        public async Task<ImgurResponse<ImgurAccount>> getAccount()
        {

            string resource = "account/me/settings";

            var response = await this.Get<ImgurAccount>(resource);

            return response;
        }
    }
}
