using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1Builder.Chips;
using Lab1Builder.GameSpecs;

namespace Lab1Builder.GameBuilders
{
    public class BusinessMonopolyBuilder : GameBuilder
    {
        public override void CreateSpace()
        {
            // Create business space
            Game.Field = new Field {Width = 150, Height = 150};
        }

        public override void CreateChips()
        {
            // Create chips for business monopoly
            Game.Chips = new List<Chip> { new GreenChip("Green"), new RedChip("Red"), new YellowChip("Yellow") };
        }
    }
}
