using System;
using System.Globalization;

namespace MyHomeWork
{

    /*a) read 3 float numbers and check: are they all belong to the range [-5,5].

    b) read 3 integers and write max and min of them.

    c) read number of HTTP Error (400, 401,402, ...) and write the name of this error 
    (Declare enum HTTPError)

    d) declare struct Dog with fields Name, Mark, Age. 
    Declare variable myDog of Dog type and read values for it. Output myDos into console. 
    (Declare method ToString in struct)
            */
    enum HttpError
    {
        BadRequest = 400,
        Unauthorized = 401,
        PaymentRequired = 402,
        Forbidden = 403,
        NotFound = 404
    }

    class HomeWork2
    {
        public static void HW2() {
            Console.WriteLine("Choose your subtask. Enter number 1, 2, 3 or 4");
            int someChoice;
            Int32.TryParse(Console.ReadLine(), out someChoice);
            switch (someChoice)
            {
                case 1:
                    CheckRangeNumbers();                    ;
                    break;
                case 2:
                    FindMaxMinValue();
                    break;
                case 3:
                    ReadHttpError();
                    break;
                case 4:
                    RegistersDog();
                    break;
            }
        }

        private static void CheckRangeNumbers() {
            bool result = false;
            string notInRange = String.Empty;
            string inRange = String.Empty;
            float number;
            Console.WriteLine("Enter three float number ​​througn a space");
            string readLine = Console.ReadLine();
            if (!String.IsNullOrEmpty(readLine)) {
                string[] textSplit = readLine.Split(' ');
                foreach (string item in textSplit) {
                    if (float.TryParse(item, out number)) {
                        if (-5 < number && number < 5) {
                            inRange += number.ToString(CultureInfo.CurrentCulture) + ' ';
                        }
                        else {
                            notInRange += number.ToString(CultureInfo.CurrentCulture) + ' ';
                        }

                        result = true;
                    }
                }
            }

            if (!result) {
                Console.WriteLine("Entered incorrect data");
            }

            if (!String.IsNullOrEmpty(inRange)) {
                Console.WriteLine("Numbers {0} belong to the range [-5,5]", inRange);
            }

            if (!String.IsNullOrEmpty(notInRange)) {
                Console.WriteLine("Numbers {0} not belong to the range [-5,5]", notInRange);
            }
        }

        private static void FindMaxMinValue() {
            bool result = false;
            int maxValue = 0;
            int minValue = 0;
            int someNumber;
            int comparableNumber = 0;
            Console.WriteLine("Enter three number ​​througn a space");
            string readLine = Console.ReadLine();
            if (!String.IsNullOrEmpty(readLine)) {
                string[] textSplit = readLine.Split(' ');
                foreach (string item in textSplit) {
                    if (int.TryParse(item, out someNumber)) {
                        maxValue = comparableNumber < someNumber ? someNumber : comparableNumber;
                        minValue = comparableNumber > someNumber ? someNumber : comparableNumber;
                        comparableNumber = someNumber;
                        result = true;
                    }
                }
            }

            if (result) {
                Console.WriteLine("Max value {0} Min value {1}", maxValue, minValue);
            }
            else {
                Console.WriteLine("Entered incorrect data");

            }

        }

        private static void ReadHttpError() {
            int httpCode;
            Console.WriteLine("Enter Http Error Code");
            int.TryParse(Console.ReadLine(), out httpCode);
            switch (httpCode) {
                case 400:
                    Console.WriteLine(HttpError.BadRequest);
                    break;
                case 401:
                    Console.WriteLine(HttpError.Unauthorized);
                    break;
                case 402:
                    Console.WriteLine(HttpError.PaymentRequired);
                    break;
                case 403:
                    Console.WriteLine(HttpError.Forbidden);
                    break;
                case 404:
                    Console.WriteLine(HttpError.NotFound);
                    break;
            }
        }

        private static void RegistersDog() {
            bool result = false;
            Dog myDog = new Dog();
            int age;
            Console.WriteLine("Enter your's dog name");
            myDog.Name = Console.ReadLine();

            Console.WriteLine("Enter your's dog mark");
            myDog.Mark = Console.ReadLine();

            Console.WriteLine("Enter your's dog age (full years)");
            while (!result) {
                if (int.TryParse(Console.ReadLine(), out age)) {
                    myDog.Age = age;
                    result = true;
                }
                else {
                    Console.WriteLine("Entered incorrect data. Try again");
                }
            }
            Console.WriteLine("Dog with name {0}, mark {1}, age {2}, are registered",
                myDog.Name, myDog.Mark, myDog.Age);
        }
    }

    struct Dog
    {
        public string Name;
        public string Mark;
        public int Age;
    }
}

