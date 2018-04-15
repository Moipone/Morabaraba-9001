using System;
using System.Text;

namespace Morabaraba
{
    class Program
    {
        static void Main(string[] args)
        {
            World world = new World(new Player(Symbol.CW), new Player(Symbol.CB));
            world.printBoard();
            Console.Read();
            Console.WriteLine("Hello World!");
            
        }
    }
}
