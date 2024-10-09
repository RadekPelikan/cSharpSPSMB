using System;
using System.Data;

namespace App
{
    public class Triangle
    {
        public Point A;
        public Point B;
        public Point C;

        public Triangle(Point a, Point b, Point c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }

        public double Obvod()
        {
            Vector aVector = new Vector(B.x - A.x, B.y - A.y);
            Vector bVector = new Vector(C.x - B.x, C.y - B.y);
            Vector cVector = new Vector(A.x - C.x, A.y - C.y);

            double a = aVector.Length();
            double b = bVector.Length();
            double c = cVector.Length();
            
            return a+b+c;
        }

        public double Obsah()
        {
            Vector aVector = new Vector(B.x - A.x, B.y - A.y);
            Vector hVector = new Vector(0, C.y - A.y);

            double obs = aVector.Length() * hVector.Length() / 2;
            return obs;

        }

       

    public override string ToString()
        {
            return $"a: {A} \n" +
                   $"b: {B} \n" +
                   $"c: {C} ";
                    
        }
        
    }
}