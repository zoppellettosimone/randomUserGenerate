using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

namespace RandomUserGenerateConsole
{
    class RandomUserGenerate
    {
        static void Main(string[] args)
        {
            //string apiUrl = "https://randomuser.me/api/";

            string apiUrl = "http://ipinfo.io/151.44.22.179/geo";

            //Chiamata Api
            Uri address = new Uri(apiUrl);
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
            request.Method = "GET";

            //Stringa Json dalla chiamata Api
            string jsonString = "";

            try
            {
                //Salvataggio su "jsonString" della risposta
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    jsonString = reader.ReadToEnd();
                }

                //Conversione da Json String a Json
                var allJsonContent = JObject.Parse(jsonString);

                Console.WriteLine(allJsonContent);

            }
            catch (Exception err)
            {
                Console.WriteLine($"\n{err.StackTrace}\n{err.Message}");
            }
            finally
            {
                Console.WriteLine("\nFine");
            }
        }
    }
}
