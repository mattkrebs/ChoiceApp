using ChoiceApp.Shared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceApp.Shared.Services
{
    public class ChoiceServices
    {
        private string _url = "http://choice.azurewebsites.net/api/{0}";

        public static List<Choice> Choices { get; set; }
        private static readonly ChoiceServices _instance = new ChoiceServices();

        public static ChoiceServices Instance
        {
            get
            {
                return _instance;
            }
        }

        public ChoiceServices() { }

        public async Task<List<Choice>> GetChoices()
        {
            var request = HttpWebRequest.Create("http://choice.azurewebsites.net/api/Choices");           
            request.Method = "GET";


            try
            {
                //WebResponse response = await request.GetResponseAsync();
                //HttpWebResponse httpResponse = (HttpWebResponse)response;
                //string result;

                //using (Stream responseStream = httpResponse.GetResponseStream())
                //{
                //    result = new StreamReader(responseStream).ReadToEnd();
                //}

                var httpClient = new HttpClient();
                var choices = await httpClient.GetStringAsync("http://choice.azurewebsites.net/api/Choices");



                List<Choice> models = new List<Choice>();
                models = JsonConvert.DeserializeObject<List<Choice>>(choices);
                return models;
            }
            catch (SecurityException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Unable to get login providers", ex);
            }
        }

    }
}
