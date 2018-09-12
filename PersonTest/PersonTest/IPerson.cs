using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTest
{
    interface IPerson
    {
        string Name { get; }
        DateTime BirtDate { get; }

        void CalculateAge();
        void Input();
        void ChangeName();
        string ToString(List<Person> persons);
        void Output();
        void Equal();
    }
}
