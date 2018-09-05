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
            HomeWork3.HW3();
            //CreateIDeveloperData();
            //Person person = new Person();
            //person.CreatePersonData();
            //Console.ReadKey();
            //person.CalculateAge();
            //Console.ReadKey();
            //person.ChangeName();
            //Console.ReadKey();
            //person.Input();
            //Console.ReadKey();
            //person.Output();
            //Console.ReadKey();
            //person.Equal();
            //Console.WriteLine("Choose your Home Work. Enter number home work number");
            //int someChoice;
            //if (Int32.TryParse(Console.ReadLine(), out someChoice))
            //{
            //    switch (someChoice)
            //    {
            //        case 1:
            //            HomeWork1.HW1();
            //            break;
            //        case 2:
            //            HomeWork2.HW2();
            //            break; 
            //        case 3:
            //            HomeWork3.HW3();
            //            break;
            //    }
            //}
            Console.ReadKey();
        }

        private static void CreateIDeveloperData() {
            Programmer programmer = new Programmer();
            programmer.Tool = "Programmer Tool";
            Builder builder = new Builder();
            builder.Tool = "Builder Tool";
            List<IDeveloper> developers = new List<IDeveloper>();
            developers.Add(builder);
            developers.Add(programmer);
            programmer.Create();
            programmer.Destroy();
            builder.Create();
            builder.Destroy();
        }
    }
}

