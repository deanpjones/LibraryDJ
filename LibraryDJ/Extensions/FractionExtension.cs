using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDJ.Extensions
{
    public class Fraction
    {
        //VARIABLES
        private int numerator;
        private int denominator;

        //CONSTRUCTOR
        public Fraction(int num, int den)
        {
            this.numerator = num;
            this.denominator = den;
        }

        //METHOD CONVERT (fraction) TO DECIMAL
        public double ToDecimal(Fraction frac)
        {
            return frac.numerator / frac.denominator;
        }

        //METHOD INVERT (fraction)
        public Fraction Invert(Fraction frac)
        {
            //create temp fraction with numerator/denominator REVERSED
            return new Fraction(frac.denominator, frac.numerator);
        }

        //// overload operator +
        //public static Fraction operator +(Fraction a, Fraction b)
        //{
        //    return new Fraction(a.num * b.den + b.num * a.den,
        //       a.den * b.den);
        //}

        //// overload operator *
        //public static Fraction operator *(Fraction a, Fraction b)
        //{
        //    return new Fraction(a.num * b.num, a.den * b.den);
        //}

        //// define operator double
        //public static implicit operator double(Fraction f)
        //{
        //    return (double)f.num / f.den;
        //}
    }
 
}
