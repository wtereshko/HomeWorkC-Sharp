using System;

namespace MyTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Console.WriteLine(calculator.Add(5, 2));
            Console.WriteLine(calculator.Division(4, 2));
            Console.WriteLine(calculator.Multiplication(3, 4));
            Console.WriteLine(calculator.Subtract(8, 4));
            Console.WriteLine(calculator.GetSquareRoot(121));
            Console.ReadKey();
        }
    }
}
