using System;
using System.Diagnostics;

namespace Calculator
{
    public abstract class Calculation
    {
        public abstract double Calculate(double number1, double number2);
    }

    public class Addition : Calculation
    {
        public override double Calculate(double number1, double number2) => number1 + number2;
    }

    public class Subtraction : Calculation
    {
        public override double Calculate(double number1, double number2) => number1 - number2;
    }

    public class Multiplication : Calculation
    {
        public override double Calculate(double number1, double number2) => number1 * number2;
    }

    public class Division : Calculation
    {
        public override double Calculate(double number1, double number2) => number1 / number2;
    }

    public enum Operation
    {
        ADD,
        SUB,
        MUL,
        DIV
    }

    public class Calculator
    {
        public Operation Operation { get; set; }

        private Calculation calculation => Operation switch
        {
            Operation.ADD => new Addition(),
            Operation.SUB => new Subtraction(),
            Operation.MUL => new Multiplication(),
            Operation.DIV => new Division(),
        };

        public Calculator(Operation operation)
        {
            Operation = operation;
        }

        public double GetResult(double num1, double num2)
        {
            return calculation.Calculate(num1, num2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator(Operation.ADD);
            calculator.Operation = Operation.MUL;
            Console.WriteLine(calculator.GetResult(3, 4));
        }
    }
}