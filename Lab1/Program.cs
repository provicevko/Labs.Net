using System;
using Lab1.GameFactories;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Game testGame = new Game(new BusinessMonopolyFactory());
        }

        
    }
}
