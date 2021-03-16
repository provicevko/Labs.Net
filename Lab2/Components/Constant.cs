using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Components
{
    public sealed class Constant : SimpleExpression<int>
    {
        public Constant(int value) : base(value)
        {
        }
    }
}
