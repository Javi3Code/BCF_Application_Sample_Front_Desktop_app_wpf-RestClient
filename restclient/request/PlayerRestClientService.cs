
using RestClientBCF.restclient.constants;
using RestClientBCF.restclient.request.model;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestClientBCF.restclient.request
{
    class PlayerRestClientService : AbstractRestClientService
    {
        private const string PLAYERS_URi = "/players";

        public async Task<HttpResponseMessage> insertOnePlayer(Player player)
        {
            return await HttpClientExtensions.PostAsJsonAsync(restClient, PLAYERS_URi, player);
        }

        public async Task<HttpResponseMessage> updateOnePlayer(Player player)
        {
            return await HttpClientExtensions.PutAsJsonAsync(restClient, PLAYERS_URi, player);
        }

        public async Task<HttpResponseMessage> getPlayers(int level)
        {
            return await restClient.GetAsync(PLAYERS_URi + RestConstants.PLAYER_LEVEL_OF_DATA + level);
        }

        public async Task<HttpResponseMessage> deleteOnePlayer(Player player)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = HttpMethod.Delete;
            request.RequestUri = new System.Uri(restClient.BaseAddress + PLAYERS_URi);
            var teamJson = JsonSerializer.Serialize(player);
            request.Content = new StringContent(teamJson, Encoding.UTF8, RestConstants.APP_JSON);
            HttpResponseMessage httpResponseMessage = await restClient.SendAsync(request);
            return httpResponseMessage;
        }

    }
}
