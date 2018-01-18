using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Geometry
{
    //DEAN JONES
    //JUL.31, 2017
    //GEOMETRY CLASS (POINT)

    public class Point
    {
        //VARIABLES
        private int xCoordinate;
        private int yCoordinate;

        //private int zCoordinate;

        //GETTERS AND SETTERS
        public int XCoordinate { get => xCoordinate; set => xCoordinate = value; }
        public int YCoordinate { get => yCoordinate; set => yCoordinate = value; }

        //CONSTRUCTOR
        public Point()
        {
            this.xCoordinate = 0;
            this.yCoordinate = 0;
        }

        //CONSTRUCTOR
        public Point(int xCoordinate, int yCoordinate)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
        }

        //TOSTRING
        public override string ToString()
        {
            return "x: " + this.xCoordinate + ", y: " + this.yCoordinate;
        }
    }
}
