
using RestClientBCF.restclient.constants;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestClientBCF.restclient.request
{
    public class RulesRestClientService : AbstractRestClientService
    {

        private const string RULES_Uri = "/rules";

        public async Task<HttpResponseMessage> getRules()
        {
            return await restClient.GetAsync(RULES_Uri);
        }

        public async Task<HttpResponseMessage> setRules(Rules rules, String fileUri, String fileName)
        {

            var multipart = new MultipartFormDataContent();
            var fileStream = System.IO.File.OpenRead(fileUri);
            StreamContent fileContent = new StreamContent(fileStream);
            fileContent.Headers.Add("Content-Type", "multipart/form-data; name=\"rulesPdf\"; filename=\"" + fileName + "\"");
            multipart.Add(fileContent, "rulesPdf", "dd.pdf");
            var rulesJson = JsonSerializer.Serialize(rules);
            StringContent jsnContent = new StringContent(rulesJson, Encoding.UTF8, "application/json");
            multipart.Add(jsnContent, "rules");
            restClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(RestConstants.APP_JSON));
            return await restClient.PutAsync(RULES_Uri, multipart);
        }



    }
}
