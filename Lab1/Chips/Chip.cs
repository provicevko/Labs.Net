using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Chips
{
    /// <summary>
    /// This class represents a chip
    /// </summary>
    public abstract class Chip
    {
        public int Id { get; } = ++_idCounter;
        public string Name { get; }

        public int XCoord { get; protected set; }
        public int YCoord { get; protected set; }

        private static int _idCounter;
        public Chip(string name)
        {
            Name = name;
        }
        /// <summary>
        /// This method moves a chip on the realization specifics
        /// </summary>
        public abstract void Move(int x, int y);
    }
}
