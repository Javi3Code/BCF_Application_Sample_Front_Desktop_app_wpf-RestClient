
using RestClientBCF.restclient.constants;
using RestClientBCF.restclient.request.model;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestClientBCF.restclient.request
{
    public class TeamRestClientService : AbstractRestClientService
    {
        private const string TEAMS_URi = "/teams";

        public async Task<HttpResponseMessage> insertOneTeam(Team team)
        {
            return await HttpClientExtensions.PostAsJsonAsync(restClient, TEAMS_URi, team);
        }

        public async Task<HttpResponseMessage> getTeams()
        {
            return await restClient.GetAsync(TEAMS_URi);
        }

        public async Task<HttpResponseMessage> deleteOneTeam(Team team)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = HttpMethod.Delete;
            request.RequestUri = new System.Uri(restClient.BaseAddress + TEAMS_URi);
            var teamJson = JsonSerializer.Serialize(team);
            request.Content = new StringContent(teamJson, Encoding.UTF8, RestConstants.APP_JSON);
            HttpResponseMessage httpResponseMessage = await restClient.SendAsync(request);
            return httpResponseMessage;
        }

    }
}
