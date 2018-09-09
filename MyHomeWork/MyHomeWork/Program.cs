using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{
    class Program
    {
        static void Main(string[] args) {
            HomeWork6.PhoneBooks();
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
    }
}

