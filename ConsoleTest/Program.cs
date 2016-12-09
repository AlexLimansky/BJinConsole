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
                var game = new Game();
                var bank = new Player();
                var player = new Player();
                var gameSession = new GameSession(game, bank, player);
                gameSession.Run();
                Console.WriteLine("Для выхода нажмите Esc");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    cont = false;
                }
            }
        }       
    }
}