using RestClientBCF.restclient.request.model;
using System.Collections.Generic;

namespace JPA_Porra_Burgos.restclient
{
    class PlayerListWrapper
    {
        public List<Player> playersWithoutResult { get; set; }
        public List<PlayerFootballMatch> playersDataWithResult { get; set; }
    }
}
