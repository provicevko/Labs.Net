using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1Builder.GameBuilders;

namespace Lab1Builder.Directors
{
    public interface IDirector
    {
        public Game CreateGame(GameBuilder builder);
    }
}
