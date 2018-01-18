using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryDJ.Extensions
{
    //DEAN JONES
    //JUL.8, 2017
    //STRING EXTENSIONS

    public static class StringExtension
    {
        //convert CHAR to (int, etc)
        //is empty

        //LETTER (CHAR)
        //one(1) letter only
        //is a digit?
        //is alphanumeric?
        //is other? (special characters)(+-*/'"\[]{}(),.<>?!@#$%^&*_=`~|:)
        //is match (regular expression)

        //WORDS
        //one(1) or more letters (no spaces)
        //word count (0 is empty string, 1 is one word, many is > 1 word)(word must have at least one vowel?)
        //test for vowel
        //test for consonant

        //to uppercase
        //to lowercase
        //to capitalize
        //spellcheck (is a word)
        //to camelcase(need dictionary for words reference)

        

        //???
        public static T TestGeneric<T>(T myType)
        {
            return myType;
        }

        //PRINT LIST (list of INTEGERS)
        public static string PrintIntList(this List<int> listInt, string delim)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var x in listInt)
            {
                sb.Append(x);
                sb.Append(delim);
            }
            int len = sb.ToString().Length;
            return sb.ToString().Substring(0, len - 2);     //substring removes last ", " delim
        }

        //PRINT ARRAY
        public static string PrintIntArray(this int[] intArray, string delim)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var x in intArray)
            {
                sb.Append(x);
                sb.Append(delim);
            }
            int len = sb.ToString().Length;
            return sb.ToString().Substring(0, len - 2);     //substring removes last ", " delim
        }

        //STRING ADD PREFIX
        public static string Prefix(this string str, string prefix)
        {
            return prefix + str;
        }

        //STRING ADD SUFFIX
        public static string Suffix(this string str, string suffix)
        {
            return str + suffix;
        }

        //STRING IS STRING LENGTH (only)
        public static bool IsStringLength(this string str, int length)
        {
            string expression = @"^.{" + length + "}$";
            Regex rgx = new Regex(expression);
            return rgx.IsMatch(str);
        }

        //STRING IS ALPHANUMERIC (only)
        public static bool IsAlphaOnly(this string str)
        {
            Regex rgx = new Regex(@"^[a-zA-Z]+$");
            return rgx.IsMatch(str);
        }

        //STRING IS DIGITS (only)
        public static bool IsDigitOnly(this string str)
        {
            Regex rgx = new Regex(@"^[0-9]+$");
            return rgx.IsMatch(str);
        }

        //STRING IS MATCH (to regular expression)
        public static bool IsRegEx(this string str, string regularExpression)
        {
            Regex rgx = new Regex(regularExpression);
            return rgx.IsMatch(str);
        }

        //STRING IS EMPTY
        public static bool IsEmpty(this string str)
        {
            return str == "";
        }

        //STRING IS NULL
        public static bool IsNull(this string str)
        {
            return str == null;
        }

        //STRING IS NULL OR EMPTY
        public static bool IsNullOrEmpty(this string str)
        {
            return String.IsNullOrEmpty(str);
        }

        //STRING IS NULL or EMPTY or HAS ONLY WHITESPACE
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return String.IsNullOrWhiteSpace(str);
        }

        //CAPITALIZE (the first character)
        public static string Capitalize(this string str)
        {
            if (str.IsNull() || str.IsEmpty())
            {
                throw new Exception("The string is null or empty");
            }
            else if (str.ToCharArray().Length == 1)             //test string is only (1) char long
            {
                return char.ToUpper(str[0]) + "";
            }
            else if (str.ToCharArray().Length > 2)              //test string is more than (2) chars long
            {
                return char.ToUpper(str[0]) + str.Substring(1);
            }
            else
                throw new Exception("The string cannot be capitalized");

        }

        //SENTENCE 
        //remove additional spaces (make sure only single space)
        public static string SingleSpace(this string sentence)
        {
            sentence = Regex.Replace(sentence, @"\s+", " ");
            return sentence;
        }
        //test that it is a sentence?
        public static bool IsSentence(this string sentence)
        {
            //if it has more than one word
            //separated by space
            string[] wordArray = sentence.Split(' ');
            return wordArray.Length > 1;
        }




        // This is the extension method.
        // The first parameter takes the "this" modifier
        // and specifies the type for which the method is defined.
        public static string TrimAndReduce(this string str)
        {
            return ConvertWhitespacesToSingleSpaces(str).Trim();
        }

        public static string ConvertWhitespacesToSingleSpaces(this string value)
        {
            return Regex.Replace(value, @"\s+", " ");
        }

        public static string AddString(this string str, string extra)
        {
            return str + extra;
        }
        public static string MyUpper(this string s)
        {
            return s.ToUpper();
        }
    }
}
