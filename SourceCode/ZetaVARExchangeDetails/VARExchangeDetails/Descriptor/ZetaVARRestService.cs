using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ZetaVARDataExchange
{
    public class ZetaVARRestService : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly string _acumaticaBaseUrl;

        public ZetaVARRestService(string acumaticaBaseUrl, string userName, string password,  string company, string branch)
        {
            _acumaticaBaseUrl = acumaticaBaseUrl;

            _httpClient = new HttpClient(new HttpClientHandler
            {
                UseCookies = true,
                CookieContainer = new CookieContainer()
            })
            {
                BaseAddress = new Uri(acumaticaBaseUrl + ZetaVARConstants.EntityNameAndVersion),
                DefaultRequestHeaders = { Accept = { MediaTypeWithQualityHeaderValue.Parse(ZetaVARConstants.ContentType) } }
            };

            LoginDetails login = new LoginDetails()
            {
                name = userName,
                password = password,
                Tenant = company,
               // Branch = branch,
            };

            string jsondata = JsonConvert.SerializeObject(login);

            HttpContent _Body = new StringContent(jsondata);
            _Body.Headers.ContentType = new MediaTypeHeaderValue(ZetaVARConstants.ContentType);

            _httpClient.PostAsync(acumaticaBaseUrl + ZetaVARConstants.LoginUrl, _Body).Result.EnsureSuccessStatusCode();
        }

        void IDisposable.Dispose()
        {
            _httpClient.PostAsync(_acumaticaBaseUrl + ZetaVARConstants.LogOutUrl,
            new ByteArrayContent(new byte[0])).Wait();
            _httpClient.Dispose();
        }

        public string Get(string entityName)
        {
            var res = _httpClient.GetAsync(_acumaticaBaseUrl + ZetaVARConstants.EntityNameAndVersion + entityName).Result.EnsureSuccessStatusCode();
            return res.Content.ReadAsStringAsync().Result;
        }

        public string Put(string entityName, string parameters, string entity)
        {
            var result = _httpClient.PutAsync(_acumaticaBaseUrl + ZetaVARConstants.EntityNameAndVersion +  entityName + "?" + parameters,  new StringContent(entity, Encoding.UTF8, ZetaVARConstants.ContentType));
            var res = result.Result;
            if (res.StatusCode.ToString() == StatusCode.Ok || res.StatusCode.ToString()== StatusCode.Accepted || res.StatusCode.ToString() == StatusCode.UnprocessableEntity || res.StatusCode.ToString() == StatusCode.Ok_200)        
                return res.Content.ReadAsStringAsync().Result;       
            else           
                return null;           
        }

        public string Post(string entityName, string entityAndParameters)
        {
            var result = _httpClient.PostAsync(_acumaticaBaseUrl + ZetaVARConstants.EntityNameAndVersion + entityName, new StringContent(entityAndParameters, Encoding.UTF8, ZetaVARConstants.ContentType));
            var res = result.Result;          
            res.EnsureSuccessStatusCode();
            return res.Content.ReadAsStringAsync().Result;
        }
    }
}
