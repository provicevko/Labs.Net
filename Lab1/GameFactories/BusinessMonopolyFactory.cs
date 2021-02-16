using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Chips;
using Lab1.GameSpaces;

namespace Lab1.GameFactories
{
    public class BusinessMonopolyFactory : GameFactory
    {
        public override List<Chip> CreateChips() => new List<Chip>{new GreenChip("Green"), new RedChip("Red"), new YellowChip("Yellow")};

        public override GameSpace CreateSpace(int width, int height)
        {
            return new BusinessMonopolySpace(width, height).CreateField();
        }
    }
}
