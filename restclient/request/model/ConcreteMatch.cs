using System;
using System.Collections.Generic;

namespace RestClientBCF.restclient.request.model
{
    public class ConcreteMatch
    {
        public long concreteMatchId { get; set; }
        public String localTeam { get; set; }
        public String visitorTeam { get; set; }
        public String resultOfConcreteMatch { get; set; }
        public List<PlayerFootballMatch> lstOfPlayerFootballMatch { get; set; }
    }
}
