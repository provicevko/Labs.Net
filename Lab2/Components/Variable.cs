using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Components
{
    public sealed class Variable : SimpleExpression<string>
    {
        public Variable(string value) : base(value)
        {
            if (string.IsNullOrEmpty(Value))
                throw new ArgumentNullException(nameof(Value));
        }

        public override StringBuilder ExpressionBuild()
        {
            return new(Value);
        }
    }
}
