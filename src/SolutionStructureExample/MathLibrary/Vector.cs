using System;

namespace App
{
    public partial class Vector
    {
        // properta double x
        public double x;

        // properta double y
        public double y;

        // constructor (x, y)
        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{this.x} {this.y}";
        }
    }
}