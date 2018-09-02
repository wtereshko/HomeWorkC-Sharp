using System;

namespace MyHomeWork
{
    interface IPerson
    {
        string Name { get; }
        DateTime BirtYear { get; }

        void CalculateAge();
        void Input();
        void ChangeName();
        string ToString();
        void Output();
        void Equal();
    }
}
