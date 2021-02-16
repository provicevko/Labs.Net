using System.Collections.Generic;
using Lab1.Chips;
using Lab1.GameSpaces;

namespace Lab1.GameFactories
{
    public abstract class GameFactory
    {
        public abstract List<Chip> CreateChips();
        public abstract GameSpace CreateSpace(int width, int height);
    }
}
