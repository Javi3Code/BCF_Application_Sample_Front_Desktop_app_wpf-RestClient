using System;
using System.Collections.Generic;

namespace RestClientBCF.restclient.request.model
{
    public class Player
    {
        public long playerId { get; set; }
        public String playerNick { get; set; }
        public String playerMail { get; set; }
        public int playerTotalPoints { get; set; }
        public List<PlayerFootballMatch> lstOfPlayerFootBallMatch { get; set; }
    }
}
