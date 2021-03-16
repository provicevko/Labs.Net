using System;
using System.Linq;
using Lab1Builder.Directors;
using Lab1Builder.GameBuilders;

namespace Lab1Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Director director = new();
            GameBuilder builder = new BusinessMonopolyBuilder();
            Game game = director.CreateGame(builder);
            
        }
    }
}
