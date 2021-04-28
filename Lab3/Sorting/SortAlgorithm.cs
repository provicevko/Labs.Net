using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Helpers;

namespace Lab3.Sorting
{
    public abstract class SortAlgorithm : ISortAlgorithm
    {
        public abstract T[] Sort<T>(T[] array) where T : IComparable;

        private protected virtual void ValidateNumericType(Type type)
        {
            if (!TypeHelper.IsNumericType(type))
                throw new InvalidOperationException($"{nameof(type)} is not numeric type");
        }
    }
}
