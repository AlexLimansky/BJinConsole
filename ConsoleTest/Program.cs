using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool cont = true;
            while (cont)
            {
                Game g = new Game();
                Player Bank = new Player();
                Player Player = new Player();
                g.GameStart(Bank, Player);
                Console.WriteLine("Игра началась. Ваши карты:" + Player.Cards);
                string ans = "";
                Console.WriteLine("Взять еще карту? д/н");
                ans = Console.ReadLine();
                while(ans != "н")
                {
                    g.More(Player);
                    Console.WriteLine("Ваши карты:" + Player.Cards);
                    Console.WriteLine("Взять еще карту? д/н");
                    ans = Console.ReadLine();                    
                }
                Console.WriteLine("Ваши карты:" + Player.Cards);
                Console.WriteLine("Карты банка:" + Bank.Cards);
                Console.WriteLine(Player.Points > Bank.Points && Player.Points < 22 ? "Поздравляем, Вы выиграли" : "Увы, Вы проиграли");
                Console.WriteLine("Для выхода нажмите Esc");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    cont = false;
                }
            }
        }
    }
}
