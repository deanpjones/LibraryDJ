using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDJ.Extensions
{
    //DEAN JONES
    //JUL.8, 2017
    //NUMBER EXTENSIONS

    //TODO
    //make a class for DIGITS (just like CHAR in a string)(only allow one)

    public static class NumberExtension
    {
        //SUM RANGE (adds the numbers sequentially)(3 + 4 + 5 = 12, 2 + 3 + 4 = 9)

        //SUM (adds the numbers sequentially)(1 + 2 + 3 + 4 + 5)
        public static int Sum(this int n)
        {
            int x = 0;
            for (int i = 0; i <= n; i++)
            {
                x = x + i;
            }
            return x;
        }

        //SUM (adds the numbers up backwards)(6 + 5 + 4 + 3 + 2 + 1)
        public static int Sum2(this int n)
        {
            int i = n - 1;
            while (i != 0)
            {
                n = n + i;
                i--;
            }
            return n;
        }

        //FACTORIAL (n!)
        public static int Factorial(this int n)
        {           
            if (n == 0)                         //make sure (divide by zero) doesn't throw exception
                return 1;
            else
                //(4! = 1 * 2 * 3 * 4 = 24)
                return n * Factorial(n - 1);        //recursive (method calls itself)  
        }

        //SUM OF DIGITS (adds up digits of one number)
        public static int DigitSum(this int n)
        {
            int sum = 0;
            int tempInt = n;

            while(tempInt != 0)
            {
                sum = sum + (tempInt % 10);   //get last digit
                tempInt = tempInt / 10;
            }
            
            return sum;
        }

        //CONVERT (list of List<int>) TO INTEGER
        public static int ConvertListToInt(this List<int> list)
        {
            int myInt = 0;

            foreach (var n in list)
            {
                myInt = 10 * myInt + n;
            }

            return myInt;
        }

        //CONVERT TO MOD (take b10 number and convert it to given base)
        public static List<int> ConvertToBase(this int n, int modulo)
        {
            int changedInt = n;
            int currentDigit;
            //int count = n.DigitCount();

            //convert int to a list of digits
            List<int> listInt = new List<int>();
            
            while(changedInt != 0)
            {
                //get mod
                currentDigit = changedInt.DigitMod(modulo);

                //add to list
                listInt.Add(currentDigit);

                //remove last digit
                changedInt = changedInt / modulo;     
            }

            //reverse the list
            listInt.Reverse();

            return listInt;
        }

        //MODULO INTEGER (MOD-n)
        public static int DigitMod(this int n, int modulo)
        {
            int remainder;
            remainder = n % modulo;

            return remainder;
        }

        //COUNT DIGITS IN INTEGER (without converting to string)    //Math.Floor(Math.Log10(n) + 1);
        public static int DigitCount(this int n)
        {
            int digitCount;
            digitCount = (int)Math.Log10(n) + 1;                    //casting to INT (don't need FLOOR)

            return digitCount;
        }

        //REMOVE LAST DIGIT
        public static int RemoveLastDigit(this int n)
        {
            int remainingDigits;
            remainingDigits = n / 10;

            return remainingDigits;
        }

        //GET LAST (nth) DIGITS OF INTEGER 
        public static int GetLastNthDigits(this int n, int digits)
        {
            int lastDigits;
            lastDigits = n % (int)Math.Pow(10, digits);     //n mod 10 will return the last digits

            return lastDigits;
        }

        //GET LAST DIGIT OF INTEGER 
        public static int GetLastDigit(this int n)
        {
            int lastDigit;
            lastDigit = n % 10;     //n mod 10 will return the last digit

            return lastDigit;
        }

        //TEST INTEGER (is even)
        public static bool IsEven(this int n)
        {
            switch (n % 2)
            {
                case 0:
                    return true;
                default:
                    return false;
            }
        }

        //TEST INTEGER (is odd)
        public static bool IsOdd(this int n)
        {
            switch (n % 2)
            {
                case 1:
                    return true;
                default:
                    return false;
            }
        }

        //INTEGER TO ARRAY (convert integer to array of digits)
        public static int[] IntToDigitArray(this int n)
        {
            int[] digitArray = n.ToString().Select(x => int.Parse(x.ToString())).ToArray();
            return digitArray;
        }

        //MATH POWERS (exponent)
        public static double Power(this int n, int exponent)
        {
            return Math.Pow(n, exponent);
        }

        //MATH POWERS (exponent)
        public static double Power(this double n, int exponent)
        {
            return Math.Pow(n, exponent);
        }

        //MATH SQUARE ROOT
        public static double SquareRoot(this int n)
        {
            return Math.Sqrt(n);
        }

        //MATH SQUARE ROOT
        public static double SquareRoot(this double n)
        {
            return Math.Sqrt(n);
        }

        //LAST DIGIT
        public static int LastDigit(this int n)
        {
            return n % 10;      //mod returns the last digit only
        }

        //TO DECIMAL 
        public static decimal ToDec(this double n)
        {
            return Convert.ToDecimal(n);
        }
        public static decimal ToDec(this int n)
        {
            return Convert.ToDecimal(n);
        }
        public static decimal ToDec(this float n)
        {
            return Convert.ToDecimal(n);
        }
        public static decimal ToDec(this long n)
        {
            return Convert.ToDecimal(n);
        }

        //TO DOUBLE 
        public static double ToDbl(this decimal n)
        {
            return Convert.ToDouble(n);
        }
        public static double ToDbl(this int n)
        {
            return Convert.ToDouble(n);
        }
        public static double ToDbl(this float n)
        {
            return Convert.ToDouble(n);
        }
        public static double ToDbl(this long n)
        {
            return Convert.ToDouble(n);
        }

        //TO INT (INTEGER)
        public static int ToInt(this decimal n)
        {
            return Convert.ToInt32(n);
        }
        public static int ToInt(this double n)
        {
            return Convert.ToInt32(n);
        }
        public static int ToInt(this float n)
        {
            return Convert.ToInt32(n);
        }
        public static int ToInt(this long n)
        {
            return Convert.ToInt32(n);
        }
    }
}
