using System;
using System.Collections.Generic;

namespace PersonTest
{
    public class Person: IPerson
    {
        #region Fields

        private string name;
        private DateTime birthDate;
        private static List<Person> allPersons = new List<Person>();
       
        #endregion

        #region Constructors

        public Person() { }

        public Person(string name, DateTime birthDate)
        {
            this.name = name;
            this.birthDate = birthDate;
        }

        #endregion
       
        #region Proporties

        public string Name
        {
            get { return name; }
        }

        public DateTime BirtDate
        {
            get { return birthDate; }
        }

        #endregion

        #region Methods

        public static void CreatePersonData()
        {
            int count = 0;
            while (count < 3)
            { 
                Console.WriteLine("Enter Person Name");
                string enteredName = Console.ReadLine();
                Console.WriteLine("Enter Person BirthYear");
                DateTime enteredBirthDate = Convert.ToDateTime(Console.ReadLine());
                Person person = new Person(enteredName, enteredBirthDate);
                allPersons.Add(person);
                count++;
            }
        }

        public void CalculateAge()
        {
            int age;
            string personsData = String.Empty;
            foreach (Person item in allPersons)
            {
                age = (DateTime.Now - item.birthDate).Days / 365;
                personsData += item.Name + ' ' + item.BirtDate.Date + ' ' + age + '\n';
            }
            Console.WriteLine(personsData);
        }

        public void Input()
        {
            Console.WriteLine("Enter Person Name");
            string enteredName = Console.ReadLine();
            Console.WriteLine("Enter Person BirthDate");
            DateTime enteredBirthDate = Convert.ToDateTime(Console.ReadLine());
            Person person = new Person(enteredName, enteredBirthDate);
            allPersons.Add(person);
        }

        public void ChangeName()
        {
            int age;
            foreach (Person item in allPersons)
            {
                age = (DateTime.Now - item.birthDate).Days / 365;
                if (age < 16)
                {
                    item.name += " Very Young";
                }
            }
        }

        public void Output()
        {
            Console.WriteLine(ToString(allPersons));
        }

        public string ToString(List<Person> persons)
        {
            int age;
            string result = String.Empty;
            foreach (Person item in persons)
            {
                age = (DateTime.Now - item.birthDate).Days / 365;
                result += item.Name + ' ' + item.BirtDate.Date + ' ' + age + '\n';
            }
            return result;
        }

        public static string ToString(Person person)
        {
            int age = (DateTime.Now - person.birthDate).Days / 365;
            return person.Name + ' ' + person.BirtDate.Date + ' ' + age + '\n';         
        }

        public void Equal()
        {
            List<Person> listPersons = new List<Person>();
            foreach (Person item in allPersons)
            {
                for (int i = 0; i < allPersons.Count; i++)
                {
                    if (item.Name == allPersons[i].Name &&
                        item.BirtDate != allPersons[i].BirtDate)
                    {
                        listPersons.Add(allPersons[i]);
                    }
                }

            }
            Console.WriteLine(ToString(listPersons));
        }

        public static bool operator == (Person first, Person second)
        {
            return first != null && first.name == second.name;
        }

        public static bool operator !=(Person first, Person second)
        {
            return first != null && !(first == second);
        }

        #endregion
    }
}
