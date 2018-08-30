using System;

namespace MyHomeWork
{
    class HomeWork1
    {
        public static void HW1()
        {
            Console.WriteLine("Make your choose. Enter number 1, 2 or 3");
            int someChoice;
            Int32.TryParse(Console.ReadLine(), out someChoice);
            switch (someChoice)
            {
                case 1:
                    Sqare();
                    break;
                case 2:
                    User();
                    break;
                case 3:
                    SomeFunction();
                    break;
            }
        }

        private static void Sqare()
        {
            int a;
            Console.WriteLine("Enter number");
            Int32.TryParse(Console.ReadLine(), out a);
            int perimetr = 4 * a;
            int area = a * a;
            Console.WriteLine("The square with lenght {0} have perimetr {1} and area {2}", a, perimetr, area);

        }

        private static void User()
        {
            string name;
            int age;
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();
            Console.WriteLine("How old are you,(name)?");
            Int32.TryParse(Console.ReadLine(), out age);
            Console.WriteLine("User with Name {0} and Age {1} created", name, age);
        }

        private static void SomeFunction()
        {
            double r;
            double pi = 3.14;
            Console.WriteLine("Enter some number");
            Double.TryParse(Console.ReadLine(), out r);
            double lenght = (2 * pi * r);
            double area = pi * r * r;
            double volume = 4 / 3 * pi * r * r * r;
            Console.WriteLine("Calculated circle data: length = {0}, area = {1}, volume = {2}", lenght, area, volume);
        }
    }
}

