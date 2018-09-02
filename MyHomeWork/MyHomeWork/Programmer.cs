using System;

namespace MyHomeWork
{
    class Programmer: IDeveloper

    {
        private string _language;
        public string Tool { get; set; }
        public void Create() {
            Console.WriteLine("Method Create of the class Programmer");
        }

        public void Destroy() {
            Console.WriteLine("Method Destroy of the class Programmer ");
        }
    }
}
