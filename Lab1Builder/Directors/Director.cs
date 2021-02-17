using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1Builder.GameBuilders;

namespace Lab1Builder.Directors
{
    public class Director : IDirector
    {
        private static readonly Director _director = new();

        public static Director GetInstance() => _director;

        public Game CreateGame(GameBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.CreateGameInstance();
            builder.CreateSpace();
            builder.CreateChips();
            return builder.Game;
        }
    }
}
