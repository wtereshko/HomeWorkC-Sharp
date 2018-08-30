using System;

namespace MyHomeWork
{
    /*a) Read the text as a string value and calculate the counts of characters 'a', 'o', 'i', 'e' in this text.
      b) Ask user to enter the number of month. Read the value and write the amount of days in this month.
      c) Enter 10 integer numbers. Calculate the sum of first 5 elements if they are positive or product of last 5 element in  the other case.
     */
    class HomeWork3
    {
        public static void HW3() {
            Console.WriteLine("Make your choose. Enter number 1, 2 or 3");
            int someChoice;
            Int32.TryParse(Console.ReadLine(), out someChoice);
            switch (someChoice)
            {
                case 1:
                    CalculateCharacters();
                    break;
                case 2:
                    CountMonthDays();
                    break;
                case 3:
                    CalculateSum();
                    break;
            }
        }

        private static void CalculateCharacters() {
            Console.WriteLine("Write some text");
            int count = 0;
            string someText = Console.ReadLine();
            if (!String.IsNullOrEmpty(someText)) {
                string[] arraytext = someText.Split(' ');
                foreach (string item in arraytext) {
                    count += item.Length;
                }
            }
            else {
                Console.WriteLine("Entered incorect data");
            }

            Console.WriteLine("Lenght {0}", count);
        }

        private static void CountMonthDays() {
            int enteredValue;
            Console.WriteLine("Please, enter the number of month");
            if (int.TryParse(Console.ReadLine(), out enteredValue)) {
                if (enteredValue > 0 && enteredValue <= 12) {
                    Console.WriteLine("The amount of days in this month {0}",
                        DateTime.DaysInMonth(DateTime.Now.Year, enteredValue));
                }
                else {
                    Console.WriteLine("Entered incorrect number");
                }
            }
            else {
                Console.WriteLine("Entered incorrect data"); 
                }
        }

        private static void CalculateSum() {
            Console.WriteLine("Enter 10 integer numbers througn a space");
            bool negative = false;
            int number;
            int positiveSum = 0;
            int restSum = 0;
            string someText = Console.ReadLine();
            if (!String.IsNullOrEmpty(someText)) {
                string[] textArray = someText.Split(' ');
                for (int i = 0; i < textArray.Length; i++) {
                    if (int.TryParse(textArray[i], out number)) {
                       if (i < 5 ) {
                           if (number > 0) {
                               positiveSum += number;
                           }
                           else {
                               negative = true;
                           }           
                        }
                        if (i > 4 && negative) {
                            restSum += number;
                        }
                    }
                }
            }

            if (!negative) {
                Console.WriteLine("Sum of first 5 elements is {0}", positiveSum);
            }
            else {
                Console.WriteLine("Sum of last 5 elements is {0}", restSum);
            }
        }
    }
}
