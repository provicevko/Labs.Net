using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.GameSpaces
{
    public class BusinessMonopolySpace : GameSpace
    {
        public BusinessMonopolySpace(int width, int height) : base(width, height)
        {
        }

        public override GameSpace CreateField()
        {
            // Create specifications
            return this;
        }
    }
}
