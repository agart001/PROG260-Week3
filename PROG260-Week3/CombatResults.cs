namespace PROG260_Week3
{
    public class CombatResults
    {
        public Actor Player { get; protected set;}
        public Actor Opponent { get; protected set;}
        public int TotalRounds { get; protected set;}

        public CombatResults()
        {

        }

        public CombatResults(Actor player, Actor opponent, int totalrounds)
        {
            Player = player;
            Opponent = opponent;
            TotalRounds = totalrounds;
        }

        public override string ToString()
        {
            return $"{Player} | {Opponent} | {TotalRounds}";
        }
    }
}