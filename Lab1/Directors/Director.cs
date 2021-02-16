using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Directors
{
    public sealed class Director : IDirector
    {
        private static readonly Director _director = new();

        public static Director GetInstance() => _director;
        public void SetRules()
        {
            // Some rules here
        }

        public (int, int) SetSpaceSizes()
        {
            // Here the director sets space sizes
            return (150, 150);
        }
    }
}
