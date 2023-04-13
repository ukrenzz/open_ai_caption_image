using AC_Image.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_Image.Services.OpenAI
{
    internal class TextAIService : OpenAIProvider
    {
        StringService stringService = new StringService();

        public async Task<string> GetCaption(string imageUrl)
        {
            try
            {
                string resource = "completions";
                object body = new
                {
                    model = "text-davinci-003",
                    prompt = $"Best caption this image: {imageUrl}",
                    max_tokens = 100,
                };

                var response = await Task.Run(() => this.post(resource, body));

                if (response.choices != null && response.choices.Length > 0)
                {
                    return response.choices[0].text;
                }
                else
                {
                    throw new Exception("Response null");
                }
            } catch (Exception ex)
            {
                AppService.DefaultMessageBox(ex.Message, "Open API Error!");

                return ex.Message;
            }
        }

        public async Task<string> GetDescription(string imageUrl)
        {
            try
            {
                string resource = "completions";
                object body = new
                {
                    model = "text-davinci-003",
                    prompt = $"Best description this image: {imageUrl}",
                    max_tokens = 100,
                };

                var response = await this.post(resource, body);

                if (response.choices != null && response.choices.Length > 0)
                {
                    return response.choices[0].text;
                }
                else
                {
                    throw new Exception("Response null");
                }
            }
            catch (Exception ex)
            {
                AppService.DefaultMessageBox(ex.Message, "Open API Error!");

                return ex.Message;
            }
        }

        public async Task<string> GetKeywords(string imageUrl)
        {
            try
            {
                string resource = "completions";
                object body = new
                {
                    model = "text-davinci-003",
                    prompt = $"Get keywords this photo: {imageUrl}",
                    max_tokens = 100,
                };

                var response = await this.post(resource, body);

                if (response.choices != null && response.choices.Length > 0)
                {
                    return stringService.Convert2CapitalEachWord(response.choices[0].text);
                }
                else
                {
                    throw new Exception("Response null");
                }
            }
            catch (Exception ex)
            {
                AppService.DefaultMessageBox(ex.Message, "Open API Error!");

                return ex.Message;
            }
        }

        public async Task<string> GetHashtags(string imageUrl)
        {
            try
            {
                string resource = "completions";
                object body = new
                {
                    model = "text-davinci-003",
                    prompt = $"Get hashtags this photo: {imageUrl}",
                    max_tokens = 100,
                };

                var response = await this.post(resource, body);

                if (response.choices != null && response.choices.Length > 0)
                {
                    return stringService.string2Hashtag(response.choices[0].text);
                }
                else
                {
                    throw new Exception("Response null");
                }
            }
            catch (Exception ex)
            {
                AppService.DefaultMessageBox(ex.Message, "Open API Error!");

                return ex.Message;
            }
        }
        public async Task<string> GetLabels(string imageUrl)
        {
            try
            {
                string resource = "completions";
                object body = new
                {
                    model = "text-davinci-003",
                    prompt = $"Get labels this photo: {imageUrl}",
                    max_tokens = 100,
                };

                var response = await this.post(resource, body);

                if (response.choices != null && response.choices.Length > 0)
                {
                    return stringService.Convert2CapitalEachWord(response.choices[0].text);
                }
                else
                {
                    throw new Exception("Response null");
                }
            }
            catch (Exception ex)
            {
                AppService.DefaultMessageBox(ex.Message, "Open API Error!");

                return ex.Message;
            }
        }
    }
}
