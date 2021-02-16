using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Directors
{
    public interface IDirector
    {
        public void SetRules();
        public (int, int) SetSpaceSizes();
    }
}
