﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{
    class HomeWork6
    {
        /*
         In Main() method declare Dictionary PhoneBook for keeping pairs PersonName-PhoneNumber. 
         1) From file "phones.txt" read 9 pairs into PhoneBook. Write only PhoneNumbers into file "Phones.txt".
         2) Find and print phone number by the given name (name input from console)
         3) Change all phone numbers, which are in format 80######### into new format +380#########. 
         The result write into file "New.txt"

        B) Write a method ReadNumber(int start, int end), that reads from Console (or from file) integer number 
        and return it, if it is in the range [start...end]. 
        If an invalid number or non-number text is read, the method should throw an exception. 
        Using this method write a method Main(), that has to enter 10 numbers:
		a1, a2, ..., a10, such that 1 < a1 < ... < a10 < 100

         */
        private static Dictionary<string, string> phoneBook = new Dictionary<string, string>();

        public static void HW6() {
        }

        public static void PhoneBooks() {
           string onlyNumbers = String.Empty;
            string directory = Directory.GetCurrentDirectory();
            string[] phoneData = File.ReadAllLines(directory + @"\\phones.txt");
            foreach (string item in phoneData) {
                string[] data = item.Split(' ');
                phoneBook.Add(data[0], data[1]);
                onlyNumbers += (data[0] + '\n');
            }

            if (!File.Exists(directory + @"\\Phones.txt")) {
                File.CreateText(directory + @"\\Phones.txt");
                File.WriteAllText((directory + @"\\Phones.txt"), onlyNumbers);

            }
            else {
                File.WriteAllText((directory + @"\\Phones.txt"), onlyNumbers);
            }
        }
    }
}
