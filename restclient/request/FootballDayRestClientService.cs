using RestClientBCF.restclient.constants;
using RestClientBCF.restclient.request.model;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestClientBCF.restclient.request
{
    class FootballDayRestClientService : AbstractRestClientService
    {
        private const string FOOTBALLDAY_URi = "/bets";
        public async Task<HttpResponseMessage> insertOnePlayerResult(PlayerFootballMatch playerResult)
        {
            return await HttpClientExtensions.PostAsJsonAsync(restClient, FOOTBALLDAY_URi, playerResult);
        }

        public async Task<HttpResponseMessage> getPlayersWithoutResult()
        {
            return await restClient.GetAsync(FOOTBALLDAY_URi);//No necesito parámetro ya que por defecto es 0, el que necesito para esta request
        }

        public async Task<HttpResponseMessage> getPlayersWithoutResultDataTable()
        {
            return await restClient.GetAsync(FOOTBALLDAY_URi + RestConstants.FT_DAY_TYPE_OF_DATA_PARAM + RestConstants.PLFM_DATA_PLAYERS_WITH_RESULT_DATA_TABLE);
        }
        public async Task<HttpResponseMessage> getAllData()
        {
            return await restClient.GetAsync(FOOTBALLDAY_URi + RestConstants.FT_DAY_TYPE_OF_DATA_PARAM + RestConstants.PLFM_ALL_DATA);
        }
        public async Task<HttpResponseMessage> endTheFootballDay(ConcreteMatch concreteMatch)
        {
            return await HttpClientExtensions.PutAsJsonAsync(restClient, FOOTBALLDAY_URi, concreteMatch);
        }


    }
}
