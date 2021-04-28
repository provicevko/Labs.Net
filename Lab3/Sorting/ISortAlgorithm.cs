using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Helpers;

namespace Lab3.Sorting
{
    public interface ISortAlgorithm
    {
        T[] Sort<T>(T[] array) where T : IComparable;
    }
}
