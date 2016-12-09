namespace ConsoleTest
{
    class GameSession
    {
        public Game Game { get; set; }
        public Player Bank { get; set; }
        public Player Player { get; set; }

        public void Run()
        {
            var consoleIO = new GameIO(Game, Bank, Player);
            Game.GameStart(Bank, Player);
            consoleIO.GameStart();
            consoleIO.LoopForMoreCards();               
            consoleIO.GetAScore();
        }
        public static string GetPlayerCards(Player player)
        {
            var cards = "";
            for (var i = 0; i < player.Hand.Count; i++)
            {
                var c = player.Hand[i];
                cards += c.Title + "-" + c.Color + " ";
            }
            return cards;
        }

        public static int GetPlayerPoints(Player player)
        {
            var total = 0;
            var aceNum = 0;
            foreach (var c in player.Hand)
            {
                if (c.Value == RulesAndSettings.AceValueMax())
                {
                    aceNum += 1;
                }
                total += c.Value;
            }
            if (total <= RulesAndSettings.ScoreToWin())
            {
                return total;
            }
            return total - aceNum * (RulesAndSettings.AceValueMax() - RulesAndSettings.AceValueMin());
        }

        public GameSession(Game game, Player bank, Player player)
        {
            Game = game;
            Bank = bank;
            Player = player;
        }
    }
}
