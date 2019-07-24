using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace TacitAssignment.Interfaces
{
    public abstract class HttpClientBase
    {
        public virtual HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseURL"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("EN"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", ConfigurationManager.AppSettings["Authorization"]);
            client.DefaultRequestHeaders.Add("Site-Name", ConfigurationManager.AppSettings["Site-Name"]);
            client.DefaultRequestHeaders.Add("App-Key", ConfigurationManager.AppSettings["App-Key"]);
            client.DefaultRequestHeaders.Add("App-Language", ConfigurationManager.AppSettings["App-Language"]);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}