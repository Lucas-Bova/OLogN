using System;
using System.Collections.Generic;
using System.Text;

namespace newOLog
{
    public class OLogN<T> where T : IComparable
    {
        private T[] Arr { get; set; }
        private T SearchParm { get; set; }

        public OLogN(T[] arr, T search)
        {
            Array.Sort(arr);
            Arr = arr;
            SearchParm = search;
        }

        //search the array for the search parameter
        public bool Search()
        {
            //we start the indexer at the middle of the array
            var indexer = Arr.Length / 2;
            //the roof of the array starts at the end of the array
            var roof = Arr.Length;
            //the floor starts at the begining of the array
            var floor = 0;
            var found = false;
            var end = false;
            do
            {
                if ((indexer == floor || indexer == roof) && Arr[indexer].CompareTo(SearchParm) != 0)
                {
                    //we could not find a match
                    end = true;
                    break;
                }
                if (Arr[indexer].CompareTo(SearchParm) == 0)
                {
                    found = true;
                    end = true;
                }
                else if (SearchParm.CompareTo(Arr[indexer]) > 0)
                {
                    //look at second half of array only
                    floor = indexer;
                    indexer = (floor + roof) / 2;
                }
                else
                {
                    //look at the first half of the array
                    roof = indexer;
                    indexer = (floor + roof) / 2;
                }
            } while (!end);
            return found;
        }
    }
}
