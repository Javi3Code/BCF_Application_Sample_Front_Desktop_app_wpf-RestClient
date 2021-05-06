
using System.Net.Http;
using System.Threading.Tasks;

namespace RestClientBCF.restclient.request
{
    class SeasonRestClientService : AbstractRestClientService
    {
        private const string SEASON_Uri = "/seasons";

        public async Task<HttpResponseMessage> resetSeason()
        {
            return await restClient.PutAsync(SEASON_Uri, null);
        }
    }
}
