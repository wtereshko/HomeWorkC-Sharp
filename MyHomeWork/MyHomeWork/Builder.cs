using System;

namespace MyHomeWork
{
    class Builder:IDeveloper

    {
        private string _tool;
        public string Tool { get; set; }
        public void Create() {
            Console.WriteLine("Method Create of the class Builder");
        }

        public void Destroy() {
            Console.WriteLine("Method Destroy of the class Builder");
        }
    }
}
