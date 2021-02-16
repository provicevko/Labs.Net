using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Chips;
using Lab1.Directors;
using Lab1.GameFactories;
using Lab1.GameSpaces;


namespace Lab1
{
    public class Game : IGame
    {
        public string Name { get; init; }

        private static int _gameCounter;
        private List<Chip> _chips;
        private GameSpace _gameSpace;

        private IDirector _director = Director.GetInstance();
        public Game(GameFactory factory)
        {
            _chips = factory.CreateChips();
            var (width, height) = _director.SetSpaceSizes();
            _gameSpace = factory.CreateSpace(width, height);
        }

        public int id { get; } = ++_gameCounter;


        public void StartGame()
        {
            // Start game process
        }

        public void EndGame()
        {
            // Finish game process
        }

        public void RestartGame()
        {
            // Restart game process
        }
    }
}
