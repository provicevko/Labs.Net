using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Lab3.Helpers;
using Lab3.Sorting;

namespace Lab3
{
    public class ArrayContext<T>
    {
        private T[] _array;
        public ISortAlgorithm SortAlgorithm { get; set; }
        public ArrayContext(T[] array)
        {
            if (!TypeHelper.IsNumericType(typeof(T)))
                throw new InvalidOperationException("T is not numeric type");
            _array = array;
        }

        public ArrayContext(T[] array, ISortAlgorithm sortAlgorithm) : this(array)
        {
            SortAlgorithm = sortAlgorithm;
        }

        public T[] Sort()
        {
            throw new NotImplementedException();
        }

        
    }
}
