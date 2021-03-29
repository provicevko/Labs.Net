using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Components
{
    public abstract class Component
    {
        public abstract void Add(Component leftComponent, Component rightComponent);
        public abstract void Remove(Component leftComponent, Component rightComponent);

        public abstract StringBuilder ExpressionBuild();
    }
}
