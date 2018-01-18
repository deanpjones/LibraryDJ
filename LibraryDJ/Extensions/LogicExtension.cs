using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDJ.Extensions
{
    class TruthTable
    {
        //VARIABLES
        private int[] elements;
        private int[,] array;

        //GETTERS AND SETTERS
        public int[] Elements { get => elements; set => elements = value; }

        //CONSTRUCTOR
        public TruthTable()
        {
            elements = new int[2] { 0, 1 };     //define default elements (0, 1)
        }

        //CONSTRUCTOR
        public TruthTable(int[] elementArray)
        {
            elements = elementArray;
        }

        //METHOD
        //public void CreateArray(int[] elements, int arrayLevel)
        public void CreateArray()
        {
            //define matrix
            int arrayLevel = 2;
            int row = arrayLevel * elements.Length;
            int col = arrayLevel;

            //number of elements 
            int n = elements.Length;

            //temp lists 
            int[] temp1 = elements;
            int[] temp2 = elements;

            //declare array
            array = new int[row, col];

            // truth table example
            // 0 0
            // 0 1
            // 1 0
            // 1 1
            
            //??? how to loop this (FOR OTHER LEVELS OF ARRAYS?)
            //one's digits
            array[0, 1] = elements[0];
            array[1, 1] = elements[1];
            array[2, 1] = elements[0];
            array[3, 1] = elements[1];

            //tens's digits
            array[0, 0] = elements[0];
            array[1, 0] = elements[0];
            array[2, 0] = elements[1];
            array[3, 0] = elements[1];

        }
        

        //METHOD (OUTPUT)
        public int Output()
        {
            // { 0, 1, 1, 0 } XOR
            //logic = new int[4];

            return 0;
            //return 1;
            
            //logic goes here
        }

        //TOSTRING
        public override string ToString()
        {          
            return elements.PrintIntArray(", ");
        }

    }
}
