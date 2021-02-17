using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1Builder.Chips;

namespace Lab1Builder
{
    public interface IGame
    {
        public int Id { get; }
        public void StartGame();
        public void EndGame();
        public void RestartGame();

        public void MoveChip(Chip chip, int x, int y);
    }
}
