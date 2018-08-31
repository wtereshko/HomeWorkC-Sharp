using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{
    class Person: IPerson
    {
        #region Fields

        private string name;
        private DateTime birthYear;
        private List<Person> allPersons = new List<Person>();

        #endregion Fields

        #region Constructors

        public Person() { }

        public Person(string cname, DateTime cbirtYear)
        {
            name = cname;
            birthYear = cbirtYear;
        }

        #endregion

        #region Proporties

        public string Name
        {
            get { return name; } 
        }
        public DateTime BirtYear
        {
            get { return birthYear; }
        }

        #endregion

        #region Methods

        public void CreatePersonData() {
            int count = 0;
            while (count < 2) {
                Person person = new Person();
                Console.WriteLine("Enter Person Name");
                person.name = Console.ReadLine();
                Console.WriteLine("Enter Person BirthYear");
                person.birthYear = Convert.ToDateTime(Console.ReadLine());
                allPersons.Add(person);
                count++;
            }
        }
        /* Then calculate and write to console the name and Age of each person; 
         * Change the name of persons, which Age is less then 16, to "Very Young".
            Output information about all persons. 
            Find and output information about Persons with the same names (use ==)
*/

        public void Age() {
            int age;
            string personsData = String.Empty;
            foreach (Person item in allPersons) {
                age = (DateTime.Now - item.birthYear).Days / 365;
                personsData += (item.Name + ' ' + item.BirtYear + ' ' + age + '\n').ToString();
            }
            Console.WriteLine(personsData);
        }

        public void Input() {
            Person person = new Person();
            Console.WriteLine("Enter Person Name");
            person.name = Console.ReadLine();
            Console.WriteLine("Enter Person BirthYear");
            person.birthYear = Convert.ToDateTime(Console.ReadLine());
            allPersons.Add(person); ;
        }

        public void ChangeName() {
            int age;
            foreach (Person item in allPersons)
            {
                age = (DateTime.Now - item.birthYear).Days / 365;
                if (age < 16) {
                    item.name += " Very Young";
                }
               }
        }

        public void Output() {
            Console.WriteLine(ToString(allPersons));
        }

        public virtual string ToString(List<Person> persons) {
            int age;
            string result = String.Empty;
            foreach (Person item in persons)
            {
                age = (DateTime.Now - item.birthYear).Days / 365;
                result += (item.Name + ' ' + item.BirtYear + ' ' + age + '\n').ToString();
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
