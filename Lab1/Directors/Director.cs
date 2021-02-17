using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Directors
{
    internal sealed class Director : IDirector
    {
        private static readonly Director _director = new();

        public static Director GetInstance() => _director;
        public void SetRules(Game.Rules rules)
        {
            // Some rules here
        }

        public (int, int) SetSpaceSizes()
        {
            // Here the director sets space sizes
            return (150, 150);
        }

        public void StartProcess(Game game)
        {
            // Here the director starts game process
        }

        public void StopProcess(Game game)
        {
            // Here the director starts game process
        }

        public void RestartProcess(Game game)
        {
            // Here the director starts game process
        }
    }
}
