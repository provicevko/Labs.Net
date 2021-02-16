using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.GameSpaces
{
    public abstract class GameSpace
    {
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public GameSpace(int width, int height)
        {
            Width = width;
            Height = height;
        }
        /// <summary>
        /// This method creates a game field
        /// </summary>
        public abstract GameSpace CreateField();
    }
}
