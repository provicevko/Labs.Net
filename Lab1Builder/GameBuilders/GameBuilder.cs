using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Builder.GameBuilders
{
    public abstract class GameBuilder
    {
        public Game Game { get; private set; }

        public void CreateGameInstance()
        {
            Game = new();
        }

        public abstract void CreateSpace();
        public abstract void CreateChips();
    }
}
