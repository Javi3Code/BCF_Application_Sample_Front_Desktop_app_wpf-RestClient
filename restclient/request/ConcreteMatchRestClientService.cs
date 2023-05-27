using RestClientBCF.restclient.constants;
using RestClientBCF.restclient.request.model;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestClientBCF.restclient.request
{
    public class ConcreteMatchRestClientService : AbstractRestClientService
    {
        private const string CONCRETEMATCH_URi = "/specificmatches";
        public async Task<HttpResponseMessage> insertConcreteMatch(ConcreteMatch concreteMatch)
        {
            return await HttpClientExtensions.PostAsJsonAsync(restClient, CONCRETEMATCH_URi, concreteMatch);
        }

        public async Task<HttpResponseMessage> getOpenMatch()
        {
            return await restClient.GetAsync(CONCRETEMATCH_URi);
        }

        public async Task<HttpResponseMessage> deleteOpenConcreteMatch()
        {
            return await restClient.DeleteAsync(CONCRETEMATCH_URi);
        }

        public async Task<HttpResponseMessage> deleteAllConcreteMatch()
        {
            return await restClient.DeleteAsync(CONCRETEMATCH_URi + RestConstants.ALL_PARAM_TRUE);
        }

    }
}
