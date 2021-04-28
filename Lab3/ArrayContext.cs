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

        private ISortAlgorithm _sortAlgorithm = new QuickSort();
        public ISortAlgorithm SortAlgorithm
        {
            get => _sortAlgorithm;
            set => _sortAlgorithm = value ?? throw new ArgumentNullException(nameof(value));
        }

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
            SortAlgorithm = sortAlgorithm ?? throw new ArgumentNullException(nameof(sortAlgorithm));
        }

        public T[] Sort()
        {
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
