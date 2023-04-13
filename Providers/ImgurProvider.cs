using AC_Image.Config;
using RestSharp.Authenticators.OAuth2;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AC_Image.Models;
using AC_Image.Exceptions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace AC_Image.Providers
{
    abstract class ImgurProvider
    {
        private RestClient client;
        public ImgurProvider()
        {

            this.client = new RestClient("https://api.imgur.com/3/");
        }

        public ImgurProvider(string baseUrl)
        {

            client = new RestClient(baseUrl);
        }

        public async Task<ImgurResponse<T>> Get<T>(string resource) where T : class
        {
            try
            {
                if (typeof(T).IsClass)
                {
                    T? result;

                    string token = new SecretKeys().accessToken;
                    client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token, "Bearer");

                    var request = new RestRequest(resource, Method.Get);

                    var response = await client.ExecuteGetAsync(request);

                    if (response.IsSuccessful)
                    {
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<ImgurResponse<T>>(response.Content);
                        
                    }
                    throw new ImgurException(((int)response.StatusCode), response.ErrorException.Message);
                }

                // throw a class exception 
                throw new Exception("Generic type is not a class");
            }
            catch (ImgurException iex)
            {
                return new ImgurResponse<T>(iex.statusCode, iex.message);
            }
            catch (Exception ex)
            {
                return new ImgurResponse<T>(ex.HResult, ex.Message);
            }

        }

        public async Task<ImgurResponse> Post(string resource, object body)
        {
            try
            {
                string token = new SecretKeys().accessToken;
                client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token, "Bearer");

                var request = new RestRequest(resource, Method.Post);
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(body);

                var response = await client.ExecutePostAsync(request);

                if (response.IsSuccessful)
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<ImgurResponse>(response.Content);
                    
                }

                throw new ImgurException(((int)response.StatusCode), response.ErrorException.Message);
            }
            catch (ImgurException iex)
            {
                return new ImgurResponse(iex.statusCode, iex.message);
            }
            catch (Exception ex)
            {
                return new ImgurResponse(ex.HResult, ex.Message);
            }
        }
    }
}
