using System;
using System.Collections.Generic;
using App;

namespace ConsoleLibrary
{
    public class Grid
    {
        public int size;
        public List<Point> Points = new List<Point>();

        public Grid(int size)
        {
            this.size = size;
        }

        public void AddPoint(Point p)
        {
            Points.Add(p);
        }

        public void RemovePoint(int index)
        {
            Points.RemoveAt(index);
        }

        public void Print()
        {
            foreach (var p in Points)
            {
            }
            
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        foreach (var p in Points)
                        {
                            if (p.x == j && p.y == k)
                            {
                                Console.Write("x");
                            }
                            else
                            {
                                Console.Write(".");
                            }
                        }
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}