using AppDataTools.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppDataTools.RequestApi
{
    public class requestApi
    {
        private AppResult rs = new AppResult();
        private IEnumerable<Transporte> cl;
        public async Task<AppResult> RequestApiResourcePost<T>(string Baseurl, string apiName, T Entidad) where T : class
        {
            var client = new HttpClient();

            client.Timeout = new TimeSpan(0, 0, 30);
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var stringValues = JsonConvert.SerializeObject(Entidad);
            var httpContent = new StringContent(stringValues, Encoding.UTF8, "application/json");
            HttpResponseMessage Res = await client.PostAsync(apiName, httpContent);

            if (Res.IsSuccessStatusCode)
            {
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                rs = JsonConvert.DeserializeObject<AppResult>(EmpResponse);

            }

            return rs;
        }

        public async Task<IEnumerable<Transporte>> RequestApiResourceGet(string Baseurl, string apiName)
        {
            var client = new HttpClient();

            client.Timeout = new TimeSpan(0, 0, 30);
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage Res = await client.GetAsync(apiName);

            if (Res.IsSuccessStatusCode)
            {
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                cl = JsonConvert.DeserializeObject<IEnumerable<Transporte>>(EmpResponse);

            }

            return cl;
        }

    }
}