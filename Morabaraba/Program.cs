using System;
using System.Text;

namespace Morabaraba
{
    class Program
    {
        static void Main(string[] args)
        {
            World world = new World(new Player(Symbol.CB ), new Player(Symbol.CW));
            world.RunAllPhases();
            //world.PlayAllPhases();
            //world.printBoard("Where would you like to play");
            Console.Read();
            Console.WriteLine("Hello World!");
            
        }
    }
}
