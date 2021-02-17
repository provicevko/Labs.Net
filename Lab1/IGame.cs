using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public interface IGame
    {
        public int Id { get; }
        public void StartGame();
        public void EndGame();
        public void RestartGame();
    }
}
