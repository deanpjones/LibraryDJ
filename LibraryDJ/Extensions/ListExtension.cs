using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDJ.Extensions
{
    //DEAN JONES
    //JUL.23, 2017
    //LIST MANIPULATION EXTENSION

    public static class ListExtension
    {
        //TODO
        //LIST FUNCTION (create a square list)(from two lists)
        //one list (1, 1,2, 1,2,3, 1,2,3,4, ...)(triangular)
        //...

        //FOREACH EXTENSION     https://stackoverflow.com/questions/101265/why-there-is-no-foreach-extension-method-on-ienumerable
        public static void MyForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T element in source)
                action(element);
        }

        //APPLY FUNCTION (to a list)
        public static int[] Apply2(this int[] list, Func<int, int> func)
        {
            //apply (x + 1) to all elements of list
            return list.Select(func).ToArray();
        }

        //APPLY FUNCTION (to a list)
        public static int[] Apply(this int[] list)
        {
            //apply (x + 1) to all elements of list
            return list.Select(x => x + 1).ToArray();
        }

        //LIST (IS EVEN, true)(ODD, false)
        public static bool IsEven(this List<int> list)
        {
            return list.Count % 2 == 0;
        }

        //LIST (GET NTH OF LIST)
        public static List<int> GetNthList(this List<int> list, int nth, int nthEqualTo)
        {
            List<int> newList = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if(list[i] % nth == nthEqualTo)  //if element equals the multiple (nthEqualTo 1 if odd, 0 if even)
                {
                    newList.Add(list[i]);
                }
            }

            return newList;
        }

        //SYMMETRY (TEST)
        //public static bool IsSymmetrical(this List<int> list)
        //{
        //    if (list.IsEven())
        //    {
        //        int half = list.Count / 2;
        //        for (int i = 0; i < half; i++)
        //        {
        //            list[i]
        //        }
        //    }
        //    else
        //    {
        //        int half = (list.Count - 1) / 2;
        //    }
        //}

        //LIST TRIANGULAR (from one list)
        public static List<int> ListTriangular(this List<int> list)
        {
            List<int> resultList = new List<int>();

            int count = 1;
            while (count <= list.Count)
            {
                for (int i = 0; i < count; i++)
                {
                    resultList.Add(list[i]);
                }
                count++;
            }

            return resultList;
            
        }

        //LIST INCREMENT (+/- plus/minus at same time)(eg. 6a +/- 1)
        public static List<int> ListIncrementPlusMinus(this List<int> list, int increment)
        {
            List<int> resultList = new List<int>();
            foreach (var n in list)
            {
                resultList.Add(n - increment);      //6a - 1
                resultList.Add(n + increment);      //6a + 1
            }
            return resultList;
        }

        //LIST INCREMENT (eg. 6a + 1, or 6a - 1)
        public static List<int> ListIncrement(this List<int> list, int increment)
        {
            List<int> resultList = new List<int>();
            foreach (var n in list)
            {
                resultList.Add(n + increment);
            }
            return resultList;
        }

        //GENERATE LIST
        public static List<int> ListByIncrement(int rangeFrom, int rangeTo, int increment)
        {
            var resultList = new List<int>();
            for (int i = rangeFrom; i < rangeTo; i += increment)
            {
                resultList.Add(i);
            }
            return resultList;
        }

        //COMBINE TWO LIST
        //public static List<int> ListCombine(this List<int> list, List<int> list2)
        //{
        //    List<int> resultList = new List<int>();
        //    resultList = list.AddRange(list2);

        //}

        //LIST OF NATURAL NUMBERS
        public static List<int> NumberList(int rangeFrom, int rangeTo)
        {
            var numList = Enumerable.Range(rangeFrom, rangeTo).ToList();
            return numList;
        }

        //LIST FUNCTION (create a triangular list)
        public static IEnumerable<int> ListTriangular(this List<int> list, List<int> list2)
        {
            //foreach (var n in list)
            //{
            //    foreach (var item in list2)
            //    {

            //    }
            //}
            //do something to make 2d triangular list
            return list;
        }
    }
}
