using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1Builder.Chips;
using Lab1Builder.GameSpecs;

namespace Lab1Builder
{
    public class Game : IGame
    {
        public Field Field { get; set; }

        public List<Chip> Chips;

        public record Rules { } // RECORD OF RULES

        public Rules rules = new(); // An instance that encapsulate a rules with one-initialize [init accessors] 

        public int Id { get; } = ++_gameCounter;

        private static int _gameCounter;
        public void StartGame()
        {
        }

        public void EndGame()
        {
        }

        public void RestartGame()
        {
        }

        public Chip GetChipWithId(int id)
        {
            if (Chips == null || Chips.Count <= 0)
                throw new InvalidOperationException();

            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            return Chips.SingleOrDefault(c => c.Id == id);
        }

        public void MoveChip(Chip chip, int x, int y)
        {
            if (!IsValidateCoords(x, y))
                throw new ArgumentOutOfRangeException("CoordsValidation");

            chip.Move(x, y);
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
            // Here validation from Rules
            return x >= 1 && x < 7 && y >= 1 && y < 7;
        }
    }
}
