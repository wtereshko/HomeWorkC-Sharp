using System;

namespace MyHomeWork
{
    class HomeWork1
    {
         /*1) define integer variable a. Read the value of a from console and calculate area and perimetr of square with length a. Output obtained results.
           2) define string variable name and integer value age. Output question "What is your name?";Read the value name and output next question: "How old are you,(name)?". Read age and write whole information  
           3) Read double number r and calculate the length (l=2*pi*r), area (S=pi*r*r) and volume (4/3*pi*r*r*r) of a circle of given r 
           */
        public static void HW1()
        {
            Console.WriteLine("Make your choose. Enter number 1, 2 or 3");
            int someChoice;
            Int32.TryParse(Console.ReadLine(), out someChoice);
            switch (someChoice)
            {
                case 1:
                    CalculateSqareProporties();
                    break;
                case 2:
                    CreateUser();
                    break;
                case 3:
                    CalculateCircleProporties();
                    break;
            }
        }

        private static void CalculateSqareProporties()
        {
            int a;
            Console.WriteLine("Enter number");
            Int32.TryParse(Console.ReadLine(), out a);
            int perimetr = 4 * a;
            int area = a * a;
            Console.WriteLine("The square with lenght {0} have perimetr {1} and area {2}", a, perimetr, area);

        }

        private static void CreateUser()
        {
            string name;
            int age;
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();
            Console.WriteLine("How old are you,(name)?");
            Int32.TryParse(Console.ReadLine(), out age);
            Console.WriteLine("CreateUser with Name {0} and Age {1} created", name, age);
        }

        private static void CalculateCircleProporties()
        {
            double r;
            double pi = 3.14;
            Console.WriteLine("Enter some number");
            Double.TryParse(Console.ReadLine(), out r);
            double lenght = (2 * pi * r);
            double area = pi * r * r;
            double volume = (4 / 3) * pi * r * r * r;
            Console.WriteLine("Calculated circle data: length = {0}, area = {1}, volume = {2}", lenght, area, volume);
        }
    }
}

