using RestClientBCF.restclient.constants;
using System.Net.Http;

namespace RestClientBCF.restclient.request
{
    public class AbstractRestClientService
    {
        protected HttpClient restClient;
        public AbstractRestClientService()
        {
            this.restClient = RestConstants.CLIENT;
        }

    }
}
