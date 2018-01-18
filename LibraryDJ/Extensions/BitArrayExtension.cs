using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDJ.Extensions
{
    public static class BitArrayExtension
    {
        public static BitArray NthDigit()
        {
            // https://www.dotnetperls.com/bitarray
            // 
            BitArray bin1 = new BitArray(4);        //create array, (set # of digits/bits),     eg. 0000
            bin1.Set(0, true);                      //set each bit (1st column),                eg. 0001
            bin1.Set(3, true);                      //set each bit (4th column),                eg. 1001

            var x = CreateArray(new bool[] { true, false, true, true });
            var y = CreateArray(5);
            return y;
        }

        //CREATE BIT ARRAY (from number (base-10))
        public static BitArray CreateArray(this int num)
        {
            string binary = Convert.ToString(num, 2);                   //converts (int 5) to (string 101)
            BitArray bitArray = new BitArray(binary.Length);            //create list (proper length)
            char[] arr = binary.ToCharArray();                          //convert string to (Char array)
            //loop to set array values
            for (int i = 0; i < arr.Length; i++)
            {
                bitArray.Set(i, ((int)arr[i] == '1') ? true : false);
            }
            return bitArray;
        }

        //CREATE BIT ARRAY (from bool array)
        public static BitArray CreateArray(this bool[] list)
        {
            //bool[] list = { true, false, true, false };
            BitArray bitArray = new BitArray(list.Length);  //create list (proper length)
            for (int i = 0; i < list.Length; i++)
            {
                bitArray.Set(i, list[i]);
            }
            return bitArray;
        }

        //PRINT BIT ARRAY
        public static void DisplayBitArray(this BitArray bitArray)
        {
            for (int i = 0; i < bitArray.Length; i++)
            {
                bool bit = bitArray.Get(i);
                Console.Write(bit ? 1 : 0);
            }
            Console.WriteLine();
        }

        //BIT ARRAY (TOSTRING)
        public static string ToMyString(this BitArray bitArray)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bitArray.Length; i++)
            {
                bool bit = bitArray.Get(i);
                sb.Append(bit ? 1 : 0);
            }
            return sb.ToString();
        }
    }
}
