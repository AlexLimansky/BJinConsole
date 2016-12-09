using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class GameIO
    {
        public GameSession Session { get; set; }

        public void GameStart()
        {
            Console.WriteLine("Игра началась. Ваши карты:" + Session.GetPlayerCards(Session.Player));
        }

        public void LoopForMoreCards()
        {
            Console.WriteLine("Взять еще карту? д/н");
            var ans = Console.ReadLine();
            while (ans != "н")
            {
                Session.Game.More(Session.Player);
                Console.WriteLine("Ваши карты:" + Session.GetPlayerCards(Session.Player));
                Console.WriteLine("Взять еще карту? д/н");
                ans = Console.ReadLine();
            }
        }

        public void GetAScore()
        {
            Console.WriteLine("Ваши карты:" + Session.GetPlayerCards(Session.Player));
            Console.WriteLine("Карты банка:" + Session.GetPlayerCards(Session.Bank));
            Console.WriteLine("Ваши очки:" + Session.GetPlayerPoints(Session.Player));
            Console.WriteLine("Очки банка:" + Session.GetPlayerPoints(Session.Bank));
            Console.WriteLine(Session.GetPlayerPoints(Session.Player) > Session.GetPlayerPoints(Session.Bank) && Session.GetPlayerPoints(Session.Player) <= RulesAndSettings.ScoreToWin()
                ? "Поздравляем, Вы выиграли"
                : "Увы, Вы проиграли");
        }

        public GameIO(GameSession session)
        {
            Session = session;
        }
    }
}
