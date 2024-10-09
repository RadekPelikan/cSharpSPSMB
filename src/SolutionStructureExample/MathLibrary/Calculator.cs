using System;
using System.Collections.Generic;

namespace App
{
    public class Calculator
    {
        // properta 1
        public double a;

        // properta 2
        public double b;
        
        // properta resultCashe
        public Dictionary<Operation, double> resultCache = new Dictionary<Operation, double>();
        /*
         * key: value
         * sum: 13
         * sub: -3
         * mul: 40
         * div: 0.625
         */
        
        // constructor (double a, double b)
        public Calculator(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public Answer Sum()
        {
            double result = a + b;
            resultCache.Add(Operation.Sum, result);
            return new Answer(Operation.Sum, result);
        }

        public Answer Sub()
        {
            double result = a - b;
            resultCache.Add(Operation.Sub, result);
            return new Answer(Operation.Sub, result);
        }

        public Answer Div()
        {
            double result = a / b;
            resultCache.Add(Operation.Div, result);
            return new Answer(Operation.Div, result);
        }

        public Answer Mul()
        {
            double result = a * b;
            resultCache.Add(Operation.Mul, result);
            return new Answer(Operation.Mul, result);
        }

        // 1 1 2 3 5 8 13 21 
        // Fibonacci(5) == 8;
        public Answer Fibonacci(int index)
        {
            double lastNum = 1;
            double ans = lastNum;
            
            for (int i = 1; i < index; i++)
            {
                double s = ans;
                ans += lastNum;
                lastNum = s;
            }
            
            resultCache.Add(Operation.Fib, ans);
            return new Answer(Operation.Fib, ans);
            
        }
        
        // Pythagorova věta (double a, double b)
        // Math.Sqrt();
        public Answer Hypotenuse(double a, double b)
        {
            double c = Math.Sqrt(a * a + b * b);
            resultCache.Add(Operation.Hypotenuse, c);
            return new Answer(Operation.Hypotenuse, c);
        }

        public double GetLastAngle(double a, double b)
        {
            double ang = 180 - a - b;
            return ang;
        }
        
    }
}