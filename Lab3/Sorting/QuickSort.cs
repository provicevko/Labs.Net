using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Helpers;

namespace Lab3.Sorting
{
    public class QuickSort : SortAlgorithm
    {
        private protected int Partition<T>(T[] array, int minIndex, int maxIndex) where T : IComparable
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i].CompareTo(array[maxIndex]) < 0)
                {
                    pivot++;
                    (array[pivot], array[i]) = (array[i], array[pivot]);
                }
            }
            
            (array[++pivot], array[maxIndex]) = (array[maxIndex], array[pivot]);
            return pivot;
        }

        private protected T[] Sort<T>(T[] array, int minIndex, int maxIndex) where T : IComparable
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            Sort(array, minIndex, pivotIndex - 1);
            Sort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        public override T[] Sort<T>(T[] array)
        {
            ValidateNumericType(typeof(T));
            return Sort(array, 0, array.Length - 1);
        }
    }
}
