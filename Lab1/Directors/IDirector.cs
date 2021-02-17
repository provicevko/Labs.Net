using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Directors
{
    internal interface IDirector
    {
        public void SetRules(Game.Rules rules);
        public (int, int) SetSpaceSizes();

        public void StartProcess(Game game);
        public void StopProcess(Game game);
        public void RestartProcess(Game game);
    }
}
