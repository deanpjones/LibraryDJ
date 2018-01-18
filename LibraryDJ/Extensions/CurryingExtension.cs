using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDJ.Extensions
{
    public static class CurryingExtension
    {
        //JUST A BUNCH OF TESTS... NOTHING REAL HERE YET...

        //---------------------------
        //---------------------------
        static int a = -1;
        static int b = -1;
        static int c = -1;

        static int repeatA = 1;
        static int repeatB = 1;
        static int repeatC = 0;     //set to ZERO(0) to turn off(not display funcC)

        //CREATE A LOOP OF FUNCTIONS (calling next one, to form a CYCLE)
        //this creates an INFINITE LOOP (error StackOverflow)
        public static void ChainRun()
        {
            for (int loop = 0; loop < 3; loop++)
            {
                //for loop only runs this (3)thrice
                for (int i = 0; i < 1; i++)
                {
                    a++;
                    b++;
                    c++;
                    ChainFuncA();   //one function to run all three
                }
                Console.WriteLine("---");
            }
                   
        }
        public static void ChainFuncA()
        {
            //Console.WriteLine("ChainFuncA calling B");
            for (int i = 0; i < repeatA; i++)
            {
                Console.WriteLine("ChainFuncA:    a:" + a);
            }
            
            ChainFuncB();
        }
        public static void ChainFuncB()
        {
            //Console.WriteLine("ChainFuncB calling C");
            for (int i = 0; i < repeatB; i++)
            {
                Console.WriteLine("ChainFuncB:    b:" + b);
            }           
            ChainFuncC();
        }
        public static void ChainFuncC()
        {
            //Console.WriteLine("ChainFuncC calling A, repeat the cycle");
            for (int i = 0; i < repeatC; i++)
            {
                Console.WriteLine("ChainFuncC:    c:" + c);
            }    
            //ChainFuncA();     //repeats A, B & C
            //ChainFuncB();       //repeats B & C
            //ChainFuncC();       //repeats C only
        }
        //---------------------------
        //---------------------------

        public static void TestSwap()
        {
            //make a point
            Pt pt = new Pt();
            pt.X = 4;
            pt.Y = 5;
            Console.WriteLine("original point: x=" + pt.X + ", y=" + pt.Y);
            //swap function 
            Func<Pt, Pt> Swap = (point) =>
            {
                int temp = point.X;
                point.X = point.Y;
                point.Y = temp;
                return point;
            };

            //test
            //Pt newPt = new Pt();
            //newPt = Swap(pt);
            Swap(pt);
            Console.WriteLine("original point: x=" + pt.X + ", y=" + pt.Y);
            //Console.WriteLine("NEW point: x=" + newPt.X + ", y=" + newPt.Y);
        }

        public static void Test5()
        {
            Func<int, int> inc = (x) => x + 1;
            int b = inc(4);
            //how to map something or provide a simple connection to another object
            
        }
        
        public static void Test1()
        {
            Func<int, int, int> add = (x, y) => x + y;
            int a = add(2, 3);
            Console.WriteLine("Add: " + a);
        }

        public static void Test2()
        {
            Func<int, Func<int, int>> curriedAdd = x => y => x + y;
            int b = curriedAdd(3)(4);
            Console.WriteLine("Currying add: " + b);
        }

        public static void Test3()
        {
            int[] lst1 = new int[3] { 0, 1, 2 };
            int[] lst2 = new int[3] { 0, 1, 2 };
            int count1 = lst1.Length;
            int count2 = lst2.Length;

            int repeat3 = 3;
            while(repeat3 != 0)
            {
                for (int i = 0; i < count1; i++)
                {
                    int repeat1 = 1;
                    while (repeat1 != 0)
                    {
                        Console.Write(lst1[i] + "\t");
                        repeat1--;
                    }
                }
                repeat3--;
            }

            Console.WriteLine();
            for (int i = 0; i < count2; i++)
            {
                int repeat2 = 3;
                while (repeat2 != 0)
                {
                    Console.Write(lst2[i] + "\t");
                    repeat2--;
                }
            }
        }

        //REPEAT LOOP 
        public static void Repeat(this int[] list, int n)
        {
            int count = n;
            while(n != 0)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    Console.Write(list[i]);
                }                   
            }
        }

        //PERMUTATION (TRUTH TABLE?)
        public static int[] Permutation(int[] list, int exponent)
        {
            //create a new list
            int j = 0;
            int[] listOut = new int[list.Length * (int)Math.Pow(list.Length, exponent)];

            int repeat3 = (int)Math.Pow(list.Length, exponent);             //digit place
            while (repeat3 != 0)
            {
                for (int i = 0; i < list.Length; i++)                       //one pass through digits
                {
                    //int repeat1 = 1;                                      //digits to repeat
                    int repeat1 = (int)Math.Pow(list.Length -1, exponent);  //digits to repeat
                    while (repeat1 != 0)
                    {
                        //listOut[j] = list[i];                               //add to list 
                        j++;                                                //increment j

                        Console.Write(list[i] + "  ");
                        repeat1--;
                    }
                    //j++;    //increment j
                }
                repeat3--;
                                                                       
            }
            Console.WriteLine();        //new line

            return listOut;
        }
    }

    class Pt
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
