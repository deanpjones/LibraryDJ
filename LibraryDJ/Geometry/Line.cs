using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDJ.Extensions;             //needs reference for INT's (METHODS: Power, SquareRoot)

namespace Extensions.Geometry
{
    //DEAN JONES
    //JUL.31, 2017
    //GEOMETRY CLASS (LINE)

    public class Line : Point
    {
        //VARIABLES
        private Point firstPoint;
        private Point secondPoint;

        //GETTERS AND SETTERS
        internal Point FirstPoint { get => firstPoint; set => firstPoint = value; }
        internal Point SecondPoint { get => secondPoint; set => secondPoint = value; }

        //CONSTRUCTOR 
        public Line() { }

        //CONSTRUCTOR 
        public Line(Point firstPoint, Point secondPoint)
        {
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
        }

        //CONSTRUCTOR 
        public Line(int x1, int y1, int x2, int y2)
        {
            this.firstPoint = new Point(x1, y1);
            this.secondPoint = new Point(x2, y2);
        }

        //METHOD (GET DISTANCE)
        public double GetLength()
        {
            //get points
            int x1 = this.firstPoint.XCoordinate;
            int y1 = this.firstPoint.YCoordinate;
            int x2 = this.secondPoint.XCoordinate;
            int y2 = this.secondPoint.YCoordinate;

            //formula
            //sqrt((x2-x1)^2 + (y2-y1)^2)
            int myX = x2 - x1;
            int myY = y2 - y1;
            double myX2 = myX.Power(2);
            double myY2 = myY.Power(2);
            double result1 = myX2 + myY2;
            double result2 = result1.SquareRoot();

            return result2;
        }      

        //TOSTRING
        public override string ToString()
        {
            return "First point: " + firstPoint.ToString() +
                "\nSecond point: " + secondPoint.ToString();
        }
    }
}
