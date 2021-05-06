using System.Net.Http;
using System.Threading.Tasks;

namespace RestClientBCF.restclient.request
{
    class DownloadLicenseRestClientService : AbstractRestClientService
    {
        private const string LICENSE_URi = "/license";

        public async Task<HttpResponseMessage> serveApplicationLicense()
        {
            return await restClient.GetAsync(LICENSE_URi);
        }
    }
}
