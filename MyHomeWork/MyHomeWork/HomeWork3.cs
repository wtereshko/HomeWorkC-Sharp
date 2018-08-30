using System;

namespace MyHomeWork
{
    /*a) Read the text as a string value and calculate the counts of characters 'a', 'o', 'i', 'e' in this text.
      b) Ask user to enter the number of month. Read the value and write the amount of days in this month.
      c) Enter 10 integer numbers. Calculate the sum of first 5 elements if they are positive or product of last 5 element in  the other case.
     */
    class HomeWork3
    {
        public static void CalculateCharacters() {
            Console.WriteLine("Write some text");
            int count = 0;
            string someText = Console.ReadLine();
            string[] arraytext = someText.Split(' ');
            foreach (string item in arraytext) {
                count += item.Length;
            };
            Console.WriteLine("Lenght {0}", count);
        }

        public static void CountMonthDays() {
            int enteredValue;
            Console.WriteLine("Please, enter the number of month");       
            int.TryParse(Console.ReadLine(), out enteredValue);
            if (enteredValue > 0 && enteredValue <= 12)
            {
               Console.WriteLine("The amount of days in this month {0}", 
                   DateTime.DaysInMonth(DateTime.Now.Year, enteredValue));
            }else { Console.WriteLine("Entered incorrect data"); }
        }
    }
}
