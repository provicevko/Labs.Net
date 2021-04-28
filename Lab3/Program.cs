using System;
using Lab3.Sorting;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArr = {1, 4, 546, -3, 2, 4, 5, 35, 6, 456, -4, 6,457457,-457,45,7,4,3,-2,99,23,-53,53,-53,2,53,6};
            double[] doubleArr = {45.5, -346.333, 3.456, 8.554, -13.24, 567.547, -2.3, -345.33, 7.77, 4574, 4744.7};
            QuickSort quickSort = new();
            var sortedIntArray = quickSort.Sort(intArr);
            OutputArray(sortedIntArray);
            Console.WriteLine();
            var sortedDoubleArray = quickSort.Sort(doubleArr);
            OutputArray(sortedDoubleArray);
            Console.WriteLine();

            InsertionSort insertionSort = new InsertionSort();
            var sortedIntArray2 = insertionSort.Sort(intArr);
            OutputArray(sortedIntArray);
            Console.WriteLine();
            var sortedDoubleArray2 = insertionSort.Sort(doubleArr);
            OutputArray(sortedDoubleArray);
        }

        private static void OutputArray<T>(T[] arr)
        {
            foreach (var elem in arr)
            {
                Console.Write(elem + " ");
            }
        }
    }
}
