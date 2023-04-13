using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_Image.Services
{
    internal class StringService
    {
        public string int2FileSize(int size)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double tempSize = (double)size;
            int order = 0;
            while (tempSize >= 1024 && order < sizes.Length - 1)
            {
                order++;
                tempSize = tempSize / 1024;
            }

            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
            // show a single decimal place, and no space.
            return String.Format("{0:0.##} {1}", tempSize, sizes[order]);
        }

        public string double2FileSize(double size)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double tempSize = size;
            int order = 0;
            while (tempSize >= 1024 && order < sizes.Length - 1)
            {
                order++;
                tempSize = tempSize / 1024;
            }

            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
            // show a single decimal place, and no space.
            return String.Format("{0:0.##} {1}", tempSize, sizes[order]);
        }

        public string removeSpace(string text)
        {
            return text.Trim().Replace('\n', ',');
        }
        public string removeNumbering(string text)
        {
            string result = removeSpace(text);
            List<string> strings = result.Split(',').ToList();
            int index = 0;

            result = "";
            foreach (string s in strings)
            {
                result += s.Substring(s.IndexOf('.') + 1);
                if(index < strings.Count) { result += ","; }
                index++;
            }

            return result;
        }

        public string removeBulleting(string text)
        {
            string result = removeSpace(text);
            char[] chars = " -,'|".ToCharArray();

            result = result.Trim(chars).Replace("-", "");

            return result;
        }

        public bool hashtagChecking(string text)
        {

            try
            {
                string temp = removeSpace(text.ToLower().Trim());
                foreach(string s in temp.Split(",")) {
                    if (!(s.StartsWith('#') && s.Substring(1).Any(ch => char.IsLetterOrDigit(ch)))) {
                        throw new Exception();
                    }
                }

                return true;

            } catch(Exception e)
            {
                return false;
            }
        }

        public string string2CapitalEachWord(string text)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string result = "";
            int index = 0;

            foreach(string s in text.Split(","))
            {
                result += textInfo.ToTitleCase(s);
                if (index < text.Split(",").Length - 1) { result += ","; }
                index++;
            }

            return result;
        }

        public string convert2Hastag(string text)
        {
            string result = "";
            char[] chars = " -,'|•".ToCharArray();

            foreach (string s in text.Split(','))
            {
                result += $"#{s.Trim(chars).Replace(" ", "").ToLower()} ";
            }

            return result;
        }

        public string Convert2CapitalEachWord(string text)
        {
            string result = ""; 

            if (text.Trim().StartsWith("1. "))
            {
                result = removeNumbering(text);
                result = convert2Hastag(result);
            }
            else if (text.Trim().StartsWith('-') || text.Trim().StartsWith('•'))
            {
                result = removeBulleting(text);
            } else
            {
                result = string2CapitalEachWord(text);
            }

            return result;
        }

        public string string2Hashtag(string text)
        {
            string result = "";
            MessageBox.Show(text);

            if(hashtagChecking(text))
            {
                return text;
            } 
            else if(text.Trim().StartsWith("1. "))
            {
                result = removeNumbering(text);
                result = convert2Hastag(result);
            } 
            else if (text.Trim().StartsWith('#'))
            {
                result = text.Replace(',', ' ').Trim();
            } 
            else if (text.Trim().StartsWith('-'))
            {
                result = removeBulleting(text);
            } 
            else
            {
                result = convert2Hastag(text);
            }

            return result.Trim().Trim('\n');
        }
    
        public string ContentsToDesc(string description, string keywords = "", string hastags = "") {
            // Template :
            // Desc
            // -------
            // Keywords
            // -------
            // Hashtags


            return description + "\n\n-------\n\n" + keywords + "\n\n-------\n\n" + hastags;
        }

        public string imgurDescToDesc(string imgurDesc)
        {
            try
            {
                var result = imgurDesc.Trim("\n".ToCharArray()).Split("-------");

                return result[0].Trim();
            } 
            catch (Exception ex)
            {
                AppService.DefaultMessageBox(ex.Message);
                return "";
            }
        }
        public string imgurDescToKeywords(string imgurDesc)
        {
            try
            {
                var result = imgurDesc.Trim("\n".ToCharArray()).Split("-------");

                return result[1].Trim().TrimStart().TrimEnd();
            }
            catch (Exception ex)
            {
                AppService.DefaultMessageBox(ex.Message);
                return "";
            }
        }
        public string imgurDescToHastags(string imgurDesc)
        {
            try
            {
                var result = imgurDesc.Trim('\n').Split("-------");

                return result[2].Trim().TrimStart().TrimEnd();
            }
            catch (Exception ex)
            {
                AppService.DefaultMessageBox(ex.Message);
                return "";
            }
        }
    }
}
