using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Choose your Home Work. Enter number home work number");
            int someChoice;
            if (Int32.TryParse(Console.ReadLine(), out someChoice))
            {
                switch (someChoice)
                {
                    case 1:
                        HomeWork1.HW1();
                        break;
                    case 2:
                        HomeWork2.HW2();
                        break;
                    case 3:

                        break;
                                        }
            }
            Console.ReadKey();
        }
    }
}

