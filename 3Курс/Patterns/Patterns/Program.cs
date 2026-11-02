using System;
using System.Text;

namespace Creator
{
    internal class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Game game = new Game();
            game.Run();
        }
    }
}