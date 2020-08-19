using System;
using System.Collections.Generic;
using System.Text;

namespace newOLog
{
    /// <summary>
    /// This class will perform an OLogN search on a given array of type T for a given parameter of type T, 
    /// so long as the type implements the IComparable interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OLogN<T> where T : IComparable
    {
        private T[] ArrayToSearch { get; set; }

        private T SearchParameter { get; set; }

        enum Comparison
        {
            LessThan = -1,
            Equal = 0,
            GreaterThan = 1
        }

        public OLogN(T[] arr, T search)
        {
            Array.Sort(arr);
            ArrayToSearch = arr;
            SearchParameter = search;
        }

        public bool SearchArray()
        {
            var upperBoundary = ArrayToSearch.Length;
            var lowerBoundary = 0;
            do
            {
                var currentPosition = (lowerBoundary + upperBoundary) / 2;
                var comparisonValue = (Comparison) ArrayToSearch[currentPosition].CompareTo(SearchParameter);
                if (comparisonValue == Comparison.Equal)
                {
                    return true;
                }
                if (currentPosition == lowerBoundary || currentPosition == upperBoundary)
                {
                    return false;
                }
                if (comparisonValue == Comparison.LessThan)
                {
                    lowerBoundary = currentPosition;
                }
                else
                {
                    upperBoundary = currentPosition;
                }
            } while (true);
        }
    }
}
