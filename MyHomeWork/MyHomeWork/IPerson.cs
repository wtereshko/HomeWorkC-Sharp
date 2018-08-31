using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{
    interface IPerson
    {
        string Name { get; }
        DateTime BirtYear { get; }

        void Age();
        void Input();
        void ChangeName();
        string ToString();
        void Output();
        void Equal();
    }
}
