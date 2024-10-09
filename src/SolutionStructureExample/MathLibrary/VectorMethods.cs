using System;

namespace App
{
    public partial class Vector
    {
        // scale(double n)
        public void Scale(double n)
        {
            x *= n;
            y *= n;
        }

        // add(Vector v)
        public void Add(Vector v)
        {
            this.x += v.x;
            this.y += v.y;
        }

        public Vector Clone()
        {
            Vector v = new Vector(this.x, this.y);
            return v;
        }

        public double Length()
        {
            return (Math.Sqrt(x * x + y * y));
        }
    }
}