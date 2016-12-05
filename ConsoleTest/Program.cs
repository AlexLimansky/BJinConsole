using System;

namespace ConsoleTest
{
    internal class Program
    {
        private static void Main()
        {
            var cont = true;
            while (cont)
            {
                var g = new Game();
                var bank = new Player();
                var player = new Player();
                g.GameStart(bank, player);
                Console.WriteLine("Игра началась. Ваши карты:" + GetPlayerCards(player));
                Console.WriteLine("Взять еще карту? д/н");
                var ans = Console.ReadLine();
                while (ans != "н")
                {
                    g.More(player);
                    Console.WriteLine("Ваши карты:" + GetPlayerCards(player));
                    Console.WriteLine("Взять еще карту? д/н");
                    ans = Console.ReadLine();
                }
                Console.WriteLine("Ваши карты:" + GetPlayerCards(player));
                Console.WriteLine("Карты банка:" + GetPlayerCards(bank));
                Console.WriteLine("Ваши очки:" + GetPlayerPoints(player));
                Console.WriteLine("Очки банка:" + GetPlayerPoints(bank));
                Console.WriteLine(GetPlayerPoints(player) > GetPlayerPoints(bank) && GetPlayerPoints(player) < 22
                    ? "Поздравляем, Вы выиграли"
                    : "Увы, Вы проиграли");
                Console.WriteLine("Для выхода нажмите Esc");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    cont = false;
                }
            }
        }

        private static string GetPlayerCards(Player player)
        {
            var cards = "";
            for (var i = 0; i < player.Hand.Count; i++)
            {
                var c = player.Hand[i];
                cards += c.Title + "-" + c.Color + " ";
            }
            return cards;
        }

        private static int GetPlayerPoints(Player player)
        {
            var total = 0;
            var aceNum = 0;
            foreach (var c in player.Hand)
            {
                if (c.Value == 11)
                {
                    aceNum += 1;
                }
                total += c.Value;
            }
            if (total < 22)
            {
                return total;
            }
            return total - aceNum*10;
        }
    }
}