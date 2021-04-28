using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Lab3.Helpers;
using Lab3.Sorting;

namespace Lab3
{
    public class ArrayContext<T> where T : IComparable
    {
        private readonly T[] _array;
        public ReadOnlyCollection<T> ArrayValues => Array.AsReadOnly(_array);
        public ISortAlgorithm SortAlgorithm { get; set; } = new QuickSort();
        public ArrayContext(T[] array)
        {
            if (!TypeHelper.IsNumericType(typeof(T)))
                throw new InvalidOperationException("T is not numeric type");

            if (array == null || array.Length <= 0)
                throw new ArgumentException("Array is null or empty");

            _array = array;
        }

        public ArrayContext(T[] array, ISortAlgorithm sortAlgorithm) : this(array)
        {
            SortAlgorithm = sortAlgorithm;
        }

        public T[] Sort()
        {
            if (SortAlgorithm == null)
                throw new InvalidOperationException();

            return SortAlgorithm.Sort(_array);
        }

        public T MaxValue()
        {
            return _array.Max();
        }

        public T MinValue()
        {
            return _array.Min();
        }
    }
}
