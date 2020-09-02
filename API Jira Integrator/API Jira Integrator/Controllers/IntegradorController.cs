using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace API_Jira_Integrator.Controllers
{
    public class IntegradorController : ApiController
    {
        [HttpGet]
        public Task<string> ApiJIRA(string query)
        {
            Task<string> strObj = null;
            using (var httpClient = new HttpClient())
            {
                string url = @"http://jira.segurosbolivar.com/rest/api/2/search?jql=" + query;
                string authInfo = "1076622744:David10.,";
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                var header = new AuthenticationHeaderValue("Basic", authInfo);
                httpClient.DefaultRequestHeaders.Authorization = header;                
                HttpResponseMessage res = httpClient.GetAsync(url).Result;

                if (res != null && res.Content != null)
                {
                    strObj = res.Content.ReadAsStringAsync();
                    ///strObj1 = JsonConvert.DeserializeObject<string>(strObj.Result.ToString());
                }
            }
            return strObj;
        }
    }
}
