using RestClientBCF.restclient.constants;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestClientBCF.restclient.request
{
    public class SendLogsRestClientService : AbstractRestClientService
    {
        private const string SEND_LOGS_URi = "/logs";

        public async Task<HttpResponseMessage> sendLogsToApplicationSupport(string message)
        {
            var msgParam = message != null ? RestConstants.LOGS_SUPPORT_MSG_PARAM + message : "";
            return await restClient.GetAsync(SEND_LOGS_URi + msgParam);
        }
    }
}
