using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDJ.Extensions
{
    //PERMUTATION (how many ways to order 3 elements? (3! = 6))
    //COMBINATION (how many different ways ...)
    //TODO 
    //

    class PermutationExtension
    {
        //COMBINATIONS (POW)(Vivian Assignment)
        //Carmen can babysit for three(3) days, she can only work up to (5hrs/day max)
        //How many different combinations can she work in the three days to earn $9.00 she needs?
        public static List<String> GetCombination()
        {
            //can only work (up to 5 hrs) per day (each list is a day)
            int[] day1 = { 0, 1, 2, 3, 4, 5 };
            int[] day2 = { 0, 1, 2, 3, 4, 5 };
            int[] day3 = { 0, 1, 2, 3, 4, 5 };

            List<string> s = new List<string>();

            for (int i = 0; i < day1.Length; i++)
            {
                for (int j = 0; j < day2.Length; j++)
                {
                    for (int k = 0; k < day3.Length; k++)
                    {
                        if (i + j + k == 9)     //condition (filter to TOTAL $9.00)
                        {
                            s.Add(day1[i] + ", " + day2[j] + ", " + day3[k]);
                        }
                    }
                }
            }

            return s;
        }

        //3D ENUMERATION (COMBINATIONS) PRINT
        public static void Combination3dEnum(int rangeLow, int rangeHigh)
        {
            var columns = from I in Enumerable.Range(rangeLow, rangeHigh)       //(0, 3)
                           from J in Enumerable.Range(rangeLow, rangeHigh)      //(0, 3)
                           from K in Enumerable.Range(rangeLow, rangeHigh)      //(0, 3)
                           select new { I, J, K };
            foreach (var c in columns)
            {
                Console.WriteLine("{0}, {1}, {2}", c.I, c.J, c.K);
            }
        }

        //TEST 3D ARAY
        public static void Test3dArray(int x, int y, int z)
        {
            List<List<int>> list = Array3d(x, y, z);
            Print3dArray(list);
        }

        //TEST 2D ARAY
        public static void Test2dArray(int x, int y)
        {
            List<List<int>> list = Array2d(x, y);
            Print2dArray(list);
        }

        //PRINT (3D list)(use with Array3d method)
        public static void Print3dArray(List<List<int>> list)
        {
            for (int i = 0; i < list[0].Count; i++)
            {
                for (int j = 0; j < list[1].Count; j++)
                {
                    for (int k = 0; k < list[2].Count; k++)
                    {
                        Console.Write("({0}, {1}, {2})", list[0][i], list[1][j], list[2][k]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            //for (int i = 0; i < list[0].Count; i++)
            //{
            //    for (int j = 0; j < list[1].Count; j++)
            //    {
            //        Console.Write("({0}, {1})", list[0][i], list[1][j]);
            //    }
            //    Console.WriteLine();
            //}
        }

        //PRINT (2D list)(use with Array2d method)
        public static void Print2dArray(List<List<int>> list)
        {
            for (int i = 0; i < list[0].Count; i++)
            {
                for (int j = 0; j < list[1].Count; j++)
                {
                    Console.Write("({0}, {1})", list[0][i], list[1][j]);
                }
                Console.WriteLine();
            }
        }

        //3D ARRAY (create the 3d dimension list)
        public static List<List<int>> Array3d(int element1, int element2, int element3)
        {
            //list (overall)
            List<List<int>> listAll = new List<List<int>>();

            //list dimensions
            List<int> list1D = new List<int>();
            List<int> list2D = new List<int>();
            List<int> list3D = new List<int>();

            //add elements (1D)
            for (int i = 0; i < element1; i++)
            {
                list1D.Add(i);
            }

            //add elements (2D)
            for (int i = 0; i < element2; i++)
            {
                list2D.Add(i);
            }

            //add elements (2D)
            for (int i = 0; i < element3; i++)
            {
                list3D.Add(i);
            }

            //add overall (list to list)
            listAll.Add(list1D);
            listAll.Add(list2D);
            listAll.Add(list3D);

            return listAll;
        }

        //2D ARRAY (create the 2d dimension list)
        public static List<List<int>> Array2d(int element1, int element2)
        {
            //list (overall)
            List<List<int>> listAll = new List<List<int>>();

            //list dimensions
            List<int> list1D = new List<int>();
            List<int> list2D = new List<int>();

            //add elements (1D)
            for (int i = 0; i < element1; i++)
            {
                list1D.Add(i);
            }

            //add elements (2D)
            for (int i = 0; i < element2; i++)
            {
                list2D.Add(i);
            }

            //add overall (list to list)
            listAll.Add(list1D);
            listAll.Add(list2D);

            return listAll;
        }

        //CREATE A (2D) PERMUTATION LIST (n x m elements)
        public static void Perm2d(int element1, int element2)
        {
            List<int> list1D = new List<int>();
            List<int> list2D = new List<int>();

            for (int i = 0; i < element1; i++)
            {
                list1D.Add(i);
            }

            for (int i = 0; i < element2; i++)
            {
                list2D.Add(i);
            }

            for (int i = 0; i < list1D.Count; i++)
            {
                for (int j = 0; j < list2D.Count; j++)
                {
                    Console.Write("({0}, {1})", list1D[i], list2D[j]);
                }
                Console.WriteLine();
            }

        }

        //CREATE A (2D) PERMUTATION LIST (n elements)
        public static void Perm2d(int elements)
        {
            List<int> list1D = new List<int>();
            List<int> list2D = new List<int>();

            for (int i = 0; i < elements; i++)
            {
                list1D.Add(i);
                list2D.Add(i);
            }

            for (int i = 0; i < list1D.Count; i++)
            {
                for (int j = 0; j < list2D.Count; j++)
                {
                    Console.Write("({0}, {1})", list1D[i], list2D[j]);
                }
                Console.WriteLine();
            }

        }

        //CREATE A (3D) PERMUTATION LIST (n elements)
        public static void Perm3d(int elements)
        {
            List<int> list1D = new List<int>();
            List<int> list2D = new List<int>();
            List<int> list3D = new List<int>();

            for (int i = 0; i < elements; i++)
            {
                list1D.Add(i);
                list2D.Add(i);
                list3D.Add(i);
            }

            for (int i = 0; i < list1D.Count; i++)
            {
                for (int j = 0; j < list2D.Count; j++)
                {
                    for (int k = 0; k < list3D.Count; k++)
                    {
                        Console.Write("({0}, {1}, {2})", list1D[i], list2D[j], list3D[k]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

        }

        //CREATE PERMUTATION (any dimension, any number of rows)
        //      Permutation(new int[]{ 2, 3 });     
        public static void Permutation(int[] arrayOfDimensions)
        {
            //create a list of lists, that is created when needed
            // arrayOfDimensions(eg. int[] arr = new int[] { 2, 2 })(2D array with two elements each)
            int arrayCount = arrayOfDimensions.Count();

            //create a (list of lists)
            List<List<MyNode>> perm = new List<List<MyNode>>();
            //create (x) number of lists
            for (int i = 0; i < arrayOfDimensions.Length; i++)
            {
                //create each column of permutation
                perm.Add(new List<MyNode>());
            }

            //create a (node) for each element in this list
            for (int i = 0; i < perm.Count; i++)
            {              
                perm[i].Add(new MyNode());
            } 



            //int len1 = list1.Count;
            //int len2 = list2.Count;
            ////MyNode[] result = new MyNode[]();

            //for (int i = 0; i < perm.Count; i++)
            //{
            //    for (int j = 0; j < arrayOfDimensions[j]; j++)
            //    {
            //        var x = perm[i][j].Child = i;
            //        //var y = list2[j].Parent = i;
            //        var y = perm[j].Child = j;

            //        Console.WriteLine("({0}, {1})", x, y);
            //    }
            //}
        }

        //CREATE PERMUTATION (2D only, meaning two rows only)
        //      Permutation(2, 4);
        public static void Permutation(int element1, int element2)
        {
            List<MyNode> list1 = new List<MyNode>();
            for (int i = 0; i < element1; i++)
            {
                list1.Add(new MyNode());
            }

            List<MyNode> list2 = new List<MyNode>();
            for (int i = 0; i < element2; i++)
            {
                list2.Add(new MyNode());
            }

            int len1 = list1.Count;
            int len2 = list2.Count;
            //MyNode[] result = new MyNode[]();

            for (int i = 0; i < len1; i++)
            {
                for (int j = 0; j < len2; j++)
                {
                    var x = list1[i].Child = i;
                    //var y = list2[j].Parent = i;
                    var y = list2[j].Child = j;

                    Console.WriteLine("({0}, {1})", x, y);
                }
            }
        }
    }

    //CLASS NODE
    class MyNode
    {
        public int Parent { get; set; }
        public int Child { get; set; }
    }
}

