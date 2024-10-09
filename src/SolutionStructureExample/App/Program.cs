using System;
using System.Collections.Generic;
using ConsoleLibrary;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {

            Grid grid = new Grid(7);

            Point p1 = new Point(1, 6);
            Point p2 = new Point(2, 7);
            Point p3 = new Point(5, 2);
            Point p4 = new Point(3, 1);
            grid.AddPoint(p1);
            grid.AddPoint(p2);
            grid.AddPoint(p3);
            grid.AddPoint(p4);
            grid.Print();
        }
    }

}