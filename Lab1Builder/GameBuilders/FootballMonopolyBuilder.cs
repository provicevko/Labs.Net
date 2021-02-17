using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1Builder.Chips;
using Lab1Builder.GameSpecs;

namespace Lab1Builder.GameBuilders
{
    public class FootballMonopolyBuilder : GameBuilder
    {
        public override void CreateSpace()
        {
            // Create football space
            Game.Field = new Field { Width = 200, Height = 150 };
        }

        public override void CreateChips()
        {
            // Create chips for football monopoly
            Game.Chips = new List<Chip> { new BlueChip("Blue"), new GreenChip("Green"), new RedChip("Red"), new YellowChip("Yellow") };
        }
    }
}
