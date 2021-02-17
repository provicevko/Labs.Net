using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Builder
{
    public interface IGame
    {
        public int Id { get; }
        public void StartGame();
        public void EndGame();
        public void RestartGame();
    }
}
