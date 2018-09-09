using System;
using System.Collections.Generic;

namespace MyHomeWork
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
