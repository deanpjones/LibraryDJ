using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Extensions.Extensions;

namespace LibraryDJ.Extensions
{
    //DEAN JONES
    //JUL.23, 2017
    //PRIME NUMBER EXTENSION

    public static class PrimeExtension
    {
        //TODO 
        //isPrime(a number) return true or false
        //nthPrime(an nth) returns a number
        //nthPrime(a number) returns nth

        //FACTORS (of a number)(from Rosetta Code)  https://rosettacode.org/wiki/Factors_of_an_integer#C.23
        public static List<int> Factor(this int num)
        {
            return Enumerable.Range(1, num).Where(x => num % x == 0).ToList();
        }

        //PRIME FUNCTIONS (real primes)
        public static IEnumerable<int> PrimeReal(int rangeTo)
        {
            //list of numbers (1 to 100)
            var nums = ListExtension.NumberList(1, rangeTo);      //need to start at 1(if higher may miss some primes)

            //prime exceptions
            var primeExceptions = PrimeException(rangeTo);
            //var primeExceptions = PrimeException2(rangeTo);

            //prime rows only
            var primeRows = nums.PrimeFilterRows();

            //get real primes (remove all prime exceptions from prime rows)
            var primeReal = primeRows.Except(primeExceptions);

            //remove (1 from beginning)
            primeReal = primeReal.ToList().PrimeSkipFirstElement();

            //add (2 and 3) to beginning of list
            List<int> finalPrimes = new List<int>();
            finalPrimes.Add(2);
            finalPrimes.Add(3);
            finalPrimes.AddRange(primeReal);  //add rest of prime list

            return finalPrimes;
        }

        //PRIME FUNCTIONS (exception list)
        //?????? (not correct...)
        public static IEnumerable<int> PrimeException2(int rangeTo)
        {
            //???
            //if limit is (100)
            //sqrt(100) = 10
            //the highest square root is 7(because 11 is higher than  10)
            //which means I only need to test(5's, 7's until it goes higher than 100)

            //list of numbers (1 to 100)
            //var nums = ListExtension.NumberList(1, rangeTo);      //need to start at 1(if higher may miss some primes)

            var modRange = (int)rangeTo.SquareRoot();   //limits by square root (eliminates many iterations)

            var modList = Enumerable
                .Range(1, modRange).ToList()            //use (modRange)(sqrt 100 would be 10)(10 is limit)
                .PrimeFilterRows().ToList()
                .Skip(1).ToList();
            var modListMax = modList.Max();

            //var primeRows = Enumerable
            //    .Range(6, modRange);
            var primeRows = ListExtension.ListByIncrement(0, rangeTo, 6).Skip(1).ToList();
            var lst = ListExtension.ListIncrementPlusMinus(primeRows, 1);
            var lst2 = lst;

            var lst3 = ListExtension.ListTriangular(modList);

            var newList = new List<int>();

            for (int i = 0; i < modList.Count; i++)
            {
                for (int j = 0; j < modList.Count; j++)
                {
                    newList.Add(i * j);
                }
            }
            //foreach (var p in modList)
            //{
            //    foreach (var q in modList)
            //    {
            //        newList.Add(p * q);
            //    }
            //}
            return newList;

            //lst.Where(x => x ==)

            //var list1 = ListExtension.ListIncrement(primeRows.ToList(), 1);     //6a + 1
            //var list2 = ListExtension.ListIncrement(primeRows.ToList(), -1);    //6a - 1

            //var list3 = list1.Union(list2).OrderBy(x => x);                     //combine lists

            //new to find all multiples of (modList * modList)(that are less than 200(rangeTo))


            //create a separate (mod list) to test for (each multiple) to use as exceptions
            //var modList = Enumerable
            //    .Range(1, rangeTo).ToList()
            //    .TakeWhile(y => y.Power(2) <= rangeTo)              //test for power 
            //    //.TakeWhile(x => x % 6 == 1 || x % 6 == 5)           //(and only 1 and 5 columns) 
            //    .Where(x => x % 6 == 1 || x % 6 == 5).ToList()
            //    .Skip(1).ToList();                                  //removes (the number 1 from list)

            //.Where(y => y.Power(2) > rangeTo)   //square root mod is less than...(should be faster than testing all)

            //var newList = new List<int>();          //new list for prime exceptions
            //var testMod = new List<int>();

            ////iterate through all mod's
            ////foreach (var mod in modList)           
            //foreach (var mod in modList)
            //{
            //    while (mod < modList.Max())
            //    {
            //        testMod = lst
            //            .PrimeFilterMod(mod).ToList();

            //        //add each (mod set of numbers) to new list
            //        newList.AddRange(testMod);
            //    }
            //}            

            ////create a new list of prime exceptions
            //newList = newList
            //    .Distinct()                                     //no repeats
            //    .OrderBy(x => x).ToList();                      //sort ascending

            //return newList;
        }

        //PRIME FUNCTIONS (exception list)
        public static IEnumerable<int> PrimeException(int rangeTo)
        {
            //list of numbers (1 to 100)
            var nums = ListExtension.NumberList(1, rangeTo);      //need to start at 1(if higher may miss some primes)

            //create a separate (mod list) to test for (each multiple) to use as exceptions
            var modList = nums
                .PrimeFilterRows().ToList()
                .PrimeSkipFirstElement().ToList();

            var newList = new List<int>();          //new list for prime exceptions
            var testMod = new List<int>();

            //iterate through all mod's
            foreach (var mod in modList)
            {
                testMod = nums
                    .PrimeFilterRows().ToList()
                    .PrimeFilterMod(mod).ToList()
                    .PrimeSkipFirstElement().ToList();

                //add each (mod set of numbers) to new list
                newList.AddRange(testMod);
            }

            //create a new list of prime exceptions
            newList = newList
                .Distinct()                                     //no repeats
                .OrderBy(x => x).ToList();                      //sort ascending

            return newList;
        }

        //PRIME FUNCTIONS (remove first element)
        public static IEnumerable<int> PrimeSkipFirstElement(this List<int> list)
        {
            var enumList = list
                .Skip(1);
            return enumList;
        }

        //PRIME FUNCTIONS (filter out 5x... by mod(modular))
        //public static IEnumerable<int> PrimeFilterMod2(this List<int> list, int mod, int rangeLimit)
        //{          
        //    //get highest number (int) from limit
        //    var highestModToTest = rangeLimit.SquareRoot().ToInt(); 

        //    var enumList = list
        //        .Where(y => y % mod == 0)
        //        .Where(z => z < rangeLimit.SquareRoot());   //??? not working properly...
        //        //optimize this (sqrt n)
        //        //optimize by (lower limit, do all 5's, then start at 7, not 5 again...)(triangular)
        //    return enumList;
        //}

        //PRIME FUNCTIONS (filter out 5x... by mod(modular))
        public static IEnumerable<int> PrimeFilterMod(this List<int> list, int mod)
        {
            var enumList = list
                .Where(y => y % mod == 0);
            return enumList;
        }

        //PRIME FUNCTIONS (filter out the 1st and 5th row first)
        public static IEnumerable<int> PrimeFilterRows(this List<int> list)
        {
            var enumList = list
                .Where(x => x % 6 == 1 || x % 6 == 5);
            return enumList;
        }

        //PRIME HELPER FUNCTION
        public static IEnumerable<int> PrimeFilter(this List<int> list, int mod)
        {
            var enumList = list
                .Where(x => x % 6 == 1 || x % 6 == 5)       //filter out the 1st and 5th row first
                .Where(y => y % mod == 0)                   //filter out 5x...
                .Skip(1);                                   //remove first element (5, 7, etc.)
            return enumList;
        }

        //PRIME TEST (all exceptions)
        public static IEnumerable<int> PrimeAllExceptionsTESTING()
        {
            //list of numbers (1 to 100)
            var nums = ListExtension.NumberList(1, 1000);
            var myPrimeRows = nums.Where(x => x % 6 == 1 || x % 6 == 5);
            var list = myPrimeRows.ToList();    //need to set to list
            List<int> exceptions = new List<int>();

            var test1 = nums
                .Where(x => x % 6 == 1 || x % 6 == 5)       //filter out the 1st and 5th row first
                .Where(y =>
                    y % 5 == 0 ||                           //filter out 5x...
                    y % 7 == 0
                    )
                    .Skip(1);                               //remove first element (5, 7, etc.)

            //------
            var modList = nums
                .PrimeFilterRows().ToList()
                .PrimeSkipFirstElement().ToList();
            var newList = new List<int>();
            var test5 = new List<int>();
            foreach (var mod in modList)
            {
                test5 = nums
                    .PrimeFilterRows().ToList()
                    .PrimeFilterMod(mod).ToList()
                    .PrimeSkipFirstElement().ToList();
                newList.AddRange(test5);
            }
            //newList = newList
            //    .Distinct().ToList();
            newList = newList
                .Distinct()                                     //no repeats
                .OrderBy(x => x).ToList();                      //sort ascending

            //------

            var test4 = nums
                .PrimeFilterRows().ToList()
                .PrimeSkipFirstElement();

            var test3 = nums
                .PrimeFilterRows().ToList()
                .PrimeFilterMod(7).ToList()
                .PrimeSkipFirstElement().ToList();

            var test2 = nums.PrimeFilter(5);
            //.Where(x => x % 6 == 1 || x % 6 == 5)       //filter out the 1st and 5th row first
            //.Where(y => y % 5 == 0)                     //filter out 5x...
            //.Skip(1);                                   //remove first element (5, 7, etc.)

            var myPrimeExceptions = myPrimeRows.Where(x =>
                (x % 6 == 1 || x % 6 == 5) &&
                //???remove first element from list...(5,7,11,13,17,19...)
                //???add parameter for higher options
                //???filter (from range, 5 * 19 = 95, therefore, 5 * (a number) that is higher than limit (100)
                //???       means that (don't need to test higher than MOD-19)(for a limit of 100)
                (
                    (x % 5 == 0) ||
                    (x % 7 == 0) ||
                    (x % 11 == 0) ||
                    (x % 13 == 0) ||
                    (x % 17 == 0) ||
                    (x % 19 == 0)
                )
                );

            //foreach (var mod in list)
            //{
            //    var myPrimeExceptions = nums.Where(x =>
            //    (x % 6 == 1 || x % 6 == 5) &&
            //    (x % mod == 0)
            //    );
            //    exceptions.AddRange(myPrimeExceptions); //add to list
            //}

            return newList;
            //return myPrimeExceptions.Distinct();
            //return exceptions.Distinct();  //exceptions.OrderBy(x => x).ToList();
        }

        //PRIME TEST (7x exceptions)
        public static IEnumerable<int> PrimeExceptions7s()
        {
            var nums = ListExtension.NumberList(1, 100);
            var myPrimeExceptions = nums.Where(x => x % 7 == 0 && (x % 6 == 1 || x % 6 == 5));
            return myPrimeExceptions;
        }

        //PRIME TEST (5x exceptions)
        public static IEnumerable<int> PrimeExceptions5s()
        {
            var nums = ListExtension.NumberList(1, 100);
            var myPrimeExceptions = nums.Where(x => x % 5 == 0 && (x % 6 == 1 || x % 6 == 5));
            return myPrimeExceptions;
        }

        //PRIME TEST (find 1st and 5th columns)
        //EXCEL     =OR(MOD(C3,6)=1, MOD(C3,6)=5)
        public static IEnumerable<int> Prime5s()
        {
            var nums = ListExtension.NumberList(1, 100);
            var myPrime5s = nums.Where(x => x % 5 == 0);
            return myPrime5s;
        }

        //PRIME TEST (1st and 5th rows)
        public static IEnumerable<int> PrimeRowException()
        {
            //get a list of natural numbers... (1, 2, 3, 4, 5, etc)
            var nums = ListExtension.NumberList(1, 100);
            var myPrime5s = nums.Where(x => x % 5 == 0);                    //all numbers divisible by 5
            var myPrimeRows = nums.Where(x => x % 6 == 1 || x % 6 == 5);    //all numbers 1st and 5th column
            return myPrimeRows;

        }
    }
}
