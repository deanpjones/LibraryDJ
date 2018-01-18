using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Geometry
{
    //DEAN JONES
    //JUL.31, 2017
    //GEOMETRY CLASS (SHAPE 2D)(triangle, square, etc.)

    public class Shape2d : Line
    {
        //VARIABLES
        private List<Line> linesList;

        //GETTERS AND SETTERS
        internal List<Line> LinesList { get => linesList; set => linesList = value; }

        //CONSTRUCTOR
        public Shape2d() { }

        //CONSTRUCTOR
        public Shape2d(List<Line> linesList)
        {
            this.linesList = linesList;
        }

        //TOSTRING
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            //build string with (all lines)
            for (int i = 0; i < linesList.Count; i++)
            {
                string myLine = "Line" + i;
                string lineInfo = linesList[i].ToString();
                sb.Append(myLine + ": " + lineInfo);
            }
            return sb.ToString();
        }
    }
}
