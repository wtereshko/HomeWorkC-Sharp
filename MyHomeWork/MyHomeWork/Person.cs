using System;
using System.Collections.Generic;

namespace MyHomeWork
{
    class Person: IPerson
    {
        /* 1) Create class Person.
    Class Person should consists of
              a) two private fields: name and birthYear (the birthday year).                 
              (*As a type for this field you may use DataTime type.)
              b) two properties for access to these fields (only get)
              c) default constructor and constructor with 2 parameters 
              d) methods:
                   - CalculateAge() - to calculate the age of person
                    -Input() - to input information about person
                    -ChangeName() - to change the name of person
                    -ToString() 
                     -Output() - to output information about person (call ToString())
                    - operator== (equal by name)
     In the method Main() create 6 objects of Person type and input information about them.  
     Then calculate and write to console the name and Age of each person; 
     Change the name of persons, which Age is less then 16, to "Very Young".
Output information about all persons. 
Find and output information about Persons with the same names (use ==)
*/
        #region Fields

        private string _name;
        private DateTime _birthYear;
        private List<Person> allPersons = new List<Person>();

        #endregion Fields

        #region Constructors

        public Person() { }

        public Person(string cname, DateTime cbirtYear)
        {
            _name = cname;
            _birthYear = cbirtYear;
        }

        #endregion

        #region Proporties

        public string Name
        {
            get { return _name; } 
        }
        public DateTime BirtYear
        {
            get { return _birthYear; }
        }

        #endregion

        #region Methods

        public void CreatePersonData() {
            int count = 0;
            while (count < 2) {
                Person person = new Person();
                Console.WriteLine("Enter Person Name");
                person._name = Console.ReadLine();
                Console.WriteLine("Enter Person BirthYear");
                person._birthYear = Convert.ToDateTime(Console.ReadLine());
                allPersons.Add(person);
                count++;
            }
        }

        public void CalculateAge() {
            int age;
            string personsData = String.Empty;
            foreach (Person item in allPersons) {
                age = (DateTime.Now - item._birthYear).Days / 365;
                personsData += item.Name + ' ' + item.BirtYear + ' ' + age + '\n';
            }
            Console.WriteLine(personsData);
        }

        public void Input() {
            Person person = new Person();
            Console.WriteLine("Enter Person Name");
            person._name = Console.ReadLine();
            Console.WriteLine("Enter Person BirthDate");
            person._birthYear = Convert.ToDateTime(Console.ReadLine());
            allPersons.Add(person);
        }

        public void ChangeName() {
            int age;
            foreach (Person item in allPersons)
            {
                age = (DateTime.Now - item._birthYear).Days / 365;
                if (age < 16) {
                    item._name += " Very Young";
                }
               }
        }

        public void Output() {
            Console.WriteLine(ToString(allPersons));
        }

        public string ToString(List<Person> persons) {
            int age;
            string result = String.Empty;
            foreach (Person item in persons)
            {
                age = (DateTime.Now - item._birthYear).Days / 365;
                result += item.Name + ' ' + item.BirtYear + ' ' + age + '\n';
            }
            return result;
        }

        public void Equal() {
            List<Person> listPersons = new List<Person>();
            foreach (Person item in allPersons) {
                for (int i = 0; i < allPersons.Count; i++) {
                    if (item.Name == allPersons[i].Name &&
                        item.BirtYear != allPersons[i].BirtYear) {
                            listPersons.Add(allPersons[i]);
                    }
                }
                
            }

            Console.WriteLine(ToString(listPersons));
        }
    #endregion
    }
}
