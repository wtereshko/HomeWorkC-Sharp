using System;

namespace MyTestProject
{
    public class Calculator
    {
        public int Add(int a, int b) {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiplication(int a, int b)
        {
            return a * b;
        }

        public int Division(int a, int b)
        {
            return a / b;
        }

        public double GetSquareRoot(double a) {
            return Math.Sqrt(a);
        }
    }
}
