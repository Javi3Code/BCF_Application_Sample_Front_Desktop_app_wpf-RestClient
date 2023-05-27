
namespace RestClientBCF.restclient.request.model
{
    public class PlayerFootballMatch
    {

        public long playerFootBallMatchId { get; set; }
        public string playerFootBallMatchResult { get; set; }
        public short winnerSign { get; set; }
        public short burgosCFGoals { get; set; }

        public string playerNick { get; set; }
        public Player player { get; set; }
        public ConcreteMatch concreteMatch { get; set; }
        public short matchPoints { get; set; }
    }
}
