using System;

namespace ConsoleTest
{
    class GameIO
    {
        public Game Game { get; set; }
        public Player Bank { get; set; }
        public Player Player { get; set; }

        public void GameStart()
        {
            Console.WriteLine("Игра началась. Ваши карты:" + GameSession.GetPlayerCards(Player));
        }

        public void LoopForMoreCards()
        {
            Console.WriteLine("Взять еще карту? д/н");
            var ans = Console.ReadLine();
            while (ans != "н")
            {
                Game.More(Player);
                Console.WriteLine("Ваши карты:" + GameSession.GetPlayerCards(Player));
                Console.WriteLine("Взять еще карту? д/н");
                ans = Console.ReadLine();
            }
        }

        public void GetAScore()
        {
            Console.WriteLine("Ваши карты:" + GameSession.GetPlayerCards(Player));
            Console.WriteLine("Карты банка:" + GameSession.GetPlayerCards(Bank));
            Console.WriteLine("Ваши очки:" + GameSession.GetPlayerPoints(Player));
            Console.WriteLine("Очки банка:" + GameSession.GetPlayerPoints(Bank));
            Console.WriteLine(GameSession.GetPlayerPoints(Player) > GameSession.GetPlayerPoints(Bank) && GameSession.GetPlayerPoints(Player) <= RulesAndSettings.ScoreToWin()
                ? "Поздравляем, Вы выиграли"
                : "Увы, Вы проиграли");
        }

        public GameIO(Game game, Player bank, Player player)
        {
            Game = game;
            Bank = bank;
            Player = player;
        }
    }
}
