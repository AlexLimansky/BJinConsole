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
                var game = new ConsoleGameSession();
                game.Run();
                Console.WriteLine("Для выхода нажмите Esc");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    cont = false;
                }
            }
        }       
    }
}