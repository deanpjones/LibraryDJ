using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDJ.Extensions
{
    public static class OutputExtension
    {
        //PRINT TO CONSOLE
        public static void PrintToConsole(this List<int> list)
        {
            foreach (var x in list)
            {
                Console.WriteLine(x);
            }
        }
    }
}
