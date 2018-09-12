using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Person.CreatePersonData();
            Person person = new Person();
            person.CalculateAge();
            Console.ReadKey();
            person.ChangeName();
            Console.ReadKey();
            person.Input();
            Console.ReadKey();
            person.Output();
            Console.ReadKey();
            Person.ToString(person);
            Console.ReadKey();
        }
    }
}
