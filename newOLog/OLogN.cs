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

        private int getCurrentPosition(int floor, int roof)
        {
            return (floor + roof) / 2;
        }

        public bool SearchArray()
        {
            var roof = ArrayToSearch.Length;

            var floor = 0;

            var currentPosition = 0;

            var found = false;

            var end = false;

            do
            {
                currentPosition = getCurrentPosition(floor, roof);

                if ((currentPosition == floor || currentPosition == roof) && ArrayToSearch[currentPosition].CompareTo(SearchParameter) != 0)
                {
                    //we could not find a match
                    end = true;
                    break;
                }
                if (ArrayToSearch[currentPosition].CompareTo(SearchParameter) == 0)
                {
                    found = true;
                    end = true;
                }
                else if (SearchParameter.CompareTo(ArrayToSearch[currentPosition]) > 0)
                {
                    floor = currentPosition;
                }
                else
                {
                    roof = currentPosition;
                }
            } while (!end);
            return found;
        }
    }
}
