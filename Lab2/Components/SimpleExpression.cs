using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Components
{
    public abstract class SimpleExpression<T> : Component
    {
        public T Value { get; init; }

        protected SimpleExpression(T value)
        {
            Value = value;
        }

        public override void Add(Component leftComponent, Component rightComponent)
        {
            throw new NotSupportedException();
        }

        public override void Remove(Component leftComponent, Component rightComponent)
        {
            throw new NotSupportedException();
        }

        public override StringBuilder ExpressionBuild()
        {
            return new(Value.ToString());
        }
    }
}
