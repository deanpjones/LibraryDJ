using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDJ.Extensions
{
    public static class GenericExtension
    {
        //SWAP
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/generic-methods
        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;

        }
    }
}
