using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab2.Components
{
    public sealed class Operator : SimpleExpression<char>
    {
        private List<Component> _childrens = new();
        public Operator(char value) : base(value)
        {
            if (!IsValidValue(value))
                throw new ArgumentOutOfRangeException(nameof(value));
        }

        private bool IsValidValue(char value)
        {
            string pattern = @"^[-+*/]{1}$";
            return Regex.IsMatch(value.ToString(), pattern);
        }

        public override void Add(Component leftComponent, Component rightComponent)
        {
            ValidateInput(leftComponent, rightComponent);

            _childrens.Add(leftComponent);
            _childrens.Add(rightComponent);
        }

        public override void Remove(Component leftComponent, Component rightComponent)
        {
            ValidateInput(leftComponent, rightComponent);

            _childrens.Add(leftComponent);
            _childrens.Add(rightComponent);
        }

        public override StringBuilder ExpressionBuild()
        {
            StringBuilder str = new StringBuilder("(");

            str.Append(_childrens.ElementAt(0).ExpressionBuild());
            str.Append(Value);
            str.Append(_childrens.ElementAt(1).ExpressionBuild());

            return str.Append(")");
        }

        private void ValidateInput(params Component[] components)
        {
            foreach (var component in components)
            {
                if (component == null)
                    throw new ArgumentNullException(nameof(component));
            }
        }

        public IEnumerator<Component> GetEnumerator()
        {
            return _childrens.GetEnumerator();
        }
    }
}
