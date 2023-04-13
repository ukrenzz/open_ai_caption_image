using AC_Image.Config;
using AC_Image.Models;
using RestSharp.Authenticators.OAuth2;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_Image.Providers
{
    abstract class OpenAIProvider
    {
        RestClient client;
        public OpenAIProvider()
        {
            client = new RestClient("https://api.openai.com/v1/");
            client.AddDefaultHeader("Accept", "application/json");
        }

        public async Task<OpenAIRepsonse> post(string resource, object body)
        {
            string token = new SecretKeys().openAIAccessToken;
            client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token, "Bearer");

            var request = new RestRequest(resource, Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(body);

            var response = await client.ExecutePostAsync(request);


            if (response.IsSuccessful)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<OpenAIRepsonse>(response.Content);
                
            }
            
            MessageBox.Show(response.ErrorException.Message);

            return new OpenAIRepsonse();

        }
    }
}
