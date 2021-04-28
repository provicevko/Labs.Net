using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Lab3.Sorting;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArr = {1, 4, 546, -3, 2, 4, 5, 35, 6, 456, -4, 6,457457,-457,45,7,4,3,-2,99,23,-53,53,-53,2,53,6};
            double[] doubleArr = {45.5, -346.333, 3.456, 8.554, -13.24, 567.547, -2.3, -345.33, 7.77, 4574, 4744.7};
            
            ArrayContext<int> intArrayContext = new(intArr);
            ArrayContext<double> doubleArrayContext = new(doubleArr);

            Output("INT[], QuickSort", intArrayContext);
            intArrayContext.SortAlgorithm = new InsertionSort();

            Output("INT[], InsertionSort", intArrayContext);
            Console.WriteLine();

            Output("DOUBLE[], QuickSort", doubleArrayContext);
            doubleArrayContext.SortAlgorithm = new InsertionSort();

            Output("DOUBLE[], InsertionSort", doubleArrayContext);
            Console.WriteLine();
        }

        private static void Output<T>(string text, ArrayContext<T> arrayContext) where T : IComparable
        {
            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine(text);
            stopwatch.Start();
            arrayContext.Sort();
            stopwatch.Stop();
            OutputArray(arrayContext.ArrayValues);
            Console.WriteLine("\n" + stopwatch.Elapsed + "\n");
        }

        private static void OutputArray<T>(ICollection<T> arr)
        {
            foreach (var elem in arr)
            {
                Console.Write(elem + " ");
            }
        }
    }
}
