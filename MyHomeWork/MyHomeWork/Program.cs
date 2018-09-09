using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHomeWork.HomeWorkAbstractClass;

namespace MyHomeWork
{
    class Program
    {
       private static List<Shape> shapes = new List<Shape>();

        static void Main(string[] args) {
            SomeLinqueTask();
            //HomeWork6.PhoneBooks();
           // HomeWork5_Collection();
;            //Person person = new Person();
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

        #region HomeWork5

        private static void CreateIDeveloperData() {
            List<IDeveloper> developers = new List<IDeveloper>();
            Programmer programmer1 = new Programmer();
            Programmer programmer2 = new Programmer();
            programmer1.Tool = "1_Programmer Tool";
            programmer2.Tool = "2_Programmer Tool";
            Builder builder1 = new Builder();
            Builder builder2 = new Builder();
            builder1.Tool = "1_Builder Tool";
            builder2.Tool = "2_Builder Tool";
           
            developers.Add(builder1);
            developers.Add(programmer1);
            developers.Add(builder2);
            developers.Add(programmer2);
            foreach (IDeveloper item in developers) {
                Console.WriteLine(item.Tool);
                item.Create();
                item.Destroy();
            }
        }

        private static void HomeWork5_Collection() {
            Dictionary<uint, string> users = new Dictionary<uint, string>();
            byte count = 0;
            uint id;
            string enteredtext = String.Empty;
            while (count < 3) {
                Console.WriteLine("Enter unique number and name person throught a space");
                enteredtext = Console.ReadLine();
                string[] text = enteredtext.Split(' ');
                if(uint.TryParse(text[0], out id)){
                    users.Add(id, text[1]);
                    count++;
                }
                else {
                    Console.WriteLine("Entered incorect data");
                }
            }
            Console.WriteLine("Entered some id number");
            enteredtext = Console.ReadLine();
            uint.TryParse(enteredtext, out id);
            foreach (var user in users) {
                if (id == user.Key) {
                    Console.WriteLine(String.Format("Name from your dictionary {0}", user.Value));
                    break;
                }
                else {
                    Console.WriteLine(String.Format("User with ID {0} not found", id));
                    break;
                }
            }
        }
        #endregion

        #region HomeWork7
        /*In Main() create list of Shape, then ask user to enter data of 10 different shapes.  Write name, area 
            and perimeter of all shapes. 
            b) Find shape with the largest perimeter and print its name. 
            3) Sort shapes by area and print obtained list (Remember about IComparable)*/
        private static void CreateShapeData() {
            
            int count = 0;
            Console.WriteLine("Enter data of 10 different shapes. Name and lenght though a space");           
            while (count < 2) {
                string enteredData = Console.ReadLine();
                string[] text = enteredData.Split(' ');
                if (text[0].Contains("Square")) {
                    Square square = new Square(text[0], double.Parse(text[1]));
                    shapes.Add(square);
                }
                else {
                    Circle circle = new Circle(text[0], double.Parse(text[1]));
                    shapes.Add(circle);
                }
                count++;
            }
        }



        #endregion

        #region HomeWork8
        /*Create Console Application project.
        Use classes Shape, Circle, Square from your previous homework.
        Use Linq and string functions to complete next tasks:
        1) Create list of Shape and fill it with 6 different shapes (Circle and Square).
        2) Find and write into the file shapes with area from range [10,100]
        3) Find and write into the file shapes which name contains letter 'a'
        4) Find and remove from the list all shapes with perimeter less then 5. Write resulted list into Console 
        */
        private static void SomeLinqueTask() {
            CreateShapeData();
            string directory = Directory.GetCurrentDirectory();

            string shapeText = String.Empty;

            IEnumerable<Shape> name = from s in shapes
                where (s.Name.Contains('a'))
                select s;

            IEnumerable<Shape> range = from s in shapes
                where (s.Area() > 10 && s.Area() < 100)
                select s;

            IEnumerable<Shape> perimetr = from s in shapes
                where (s.Area() < 5)
                select s;

            foreach (var item in name) {
                shapeText += item.Name + "\n";
            }


            if (!File.Exists(directory + @"\\shapes.txt"))
            {
                File.CreateText(directory + @"\\shapes.txt");
                File.WriteAllText((directory + @"\\shapes.txt"), shapeText);
            }
            else
            {
                File.WriteAllText((directory + @"\\Phones.txt"), shapeText);
            }
            
        }


        #endregion
    }
}

