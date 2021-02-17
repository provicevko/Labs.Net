using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public int Id { get; } = ++_gameCounter;
        public string Name { get; init; }

        private static int _gameCounter;
        private readonly List<Chip> _chips;
        private readonly GameSpace _gameSpace;

        private readonly IDirector _director = Director.GetInstance();

        public record Rules { } // RECORD OF RULES

        public Rules rules = new Rules(); // An instance that encapsulate a rules with one-initialize [init accessors] 
        public Game(GameFactory factory)
        {
            _chips = factory.CreateChips();
            var (width, height) = _director.SetSpaceSizes();
            _gameSpace = factory.CreateSpace(width, height);
            _director.SetRules(rules);
        }

        public void StartGame()
        {
            // Start game process
            _director.StartProcess(this);
        }

        public void EndGame()
        {
            // Finish game process
            _director.StopProcess(this);
        }

        public void RestartGame()
        {
            // Restart game process
            _director.RestartProcess(this);
        }

        public Chip GetChipWithId(int id)
        {
            if (_chips == null || _chips.Count <= 0)
                throw new InvalidOperationException();

            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            return _chips.SingleOrDefault(c => c.Id == id);
        }

        public ReadOnlyCollection<Chip> GetChips()
        {
            if (_chips == null || _chips.Count <= 0)
                throw new InvalidOperationException();

            return _chips.AsReadOnly();
        }

        public int[] GetChipsIndexes()
        {
            if (_chips == null || _chips.Count <= 0)
                throw new InvalidOperationException();

            return _chips.Select(c => c.Id).ToArray();
        }

        private void MoveChip(Chip chip, int x, int y)
        {
            if (!IsValidateCoords(x, y))
                throw new ArgumentOutOfRangeException("CoordsValidation");
            
            chip.Move(x,y);
        }

        public void MoveChip(int chipId, int x, int y)
        {
            if (chipId <= 0)
                throw new ArgumentOutOfRangeException(nameof(chipId));

            var chip = GetChipWithId(chipId);
            MoveChip(chip, x, y);
        }

        /// <summary>
        /// This method validates input coords
        /// </summary>
        private static bool IsValidateCoords(int x, int y)
        {
            // Here validation
            return x >= 1 && x < 7 && y >= 1 && y < 7;
        }
    }
}
