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

        public OLogN(T[] arr, T search)
        {
            Array.Sort(arr);
            ArrayToSearch = arr;
            SearchParameter = search;
        }

        public bool SearchArray()
        {
            int currentPosition;

            var roof = ArrayToSearch.Length;

            var floor = 0;

            do
            {
                currentPosition = (floor + roof) / 2;

                if (ArrayToSearch[currentPosition].CompareTo(SearchParameter) == 0)
                {
                    return true;
                }
                if ((currentPosition == floor || currentPosition == roof))
                {
                    return false;
                }
                else if (ArrayToSearch[currentPosition].CompareTo(SearchParameter) < 0)
                {
                    floor = currentPosition;
                }
                else
                {
                    roof = currentPosition;
                }
            } while (true);
        }
    }
}
