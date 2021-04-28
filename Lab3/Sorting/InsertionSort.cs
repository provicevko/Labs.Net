using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Sorting
{
    public class InsertionSort : SortAlgorithm
    {
        public override T[] Sort<T>(T[] array)
        {
            ValidateNumericType(typeof(T));
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            for (var i = 1; i < array.Length; i++)
            {
                var key = array[i];
                var j = i;
                while (j > 1 && array[j-1].CompareTo(key) > 0)
                {
                    (array[j-1], array[j]) = (array[j], array[j-1]);
                    j--;
                }

                array[j] = key;
            }

            return array;
        }
    }
}
