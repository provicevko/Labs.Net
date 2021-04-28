using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
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

            Console.WriteLine("Max value: " + intArrayContext.MaxValue());
            Console.WriteLine("Min value: " + intArrayContext.MinValue());
            OutputArrayContext("INT[], QuickSort", intArrayContext);
            intArrayContext.SortAlgorithm = new InsertionSort();

            OutputArrayContext("INT[], InsertionSort", intArrayContext);
            Console.WriteLine();

            Console.WriteLine("Max value: " + doubleArrayContext.MaxValue());
            Console.WriteLine("Min value: " + doubleArrayContext.MinValue());
            OutputArrayContext("DOUBLE[], QuickSort", doubleArrayContext);
            doubleArrayContext.SortAlgorithm = new InsertionSort();

            OutputArrayContext("DOUBLE[], InsertionSort", doubleArrayContext);
            Console.WriteLine();
        }

        private static void OutputArrayContext<T>(string text, ArrayContext<T> arrayContext) where T : IComparable
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
