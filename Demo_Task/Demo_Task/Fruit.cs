using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Demo_Task
{
    /*1) Утворити клас Фрукт, який містить:
- поля назва та колір, 
- визначити конструктор з параметрами, 
- віртуальні методи Input() та Print(), для зчитування даних з консолі та виведення даних на консоль, 
а також перевантажити варіанти введення-виведення з файлу.
- властивості для полів, 
- перевизначити метод ToString(). 
*/
    [XmlInclude(typeof(Citrus))]
    [Serializable]
    public class Fruit
    {
        #region Fields

        private string name;
        private string colour;

        #endregion


        #region Constructors

        public Fruit()
        { }

        public Fruit(string name, string colour)
        {
            this.name = name;
            this.colour = colour;
        }

        #endregion

        #region Proporties

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Colour
        {
            get { return colour; }
            set { colour = value; }
        }

        #endregion

        #region Methods

        public virtual void Input()
        {
            Console.WriteLine("Enter fruit name");
            this.Name = Console.ReadLine();
            Console.WriteLine("Enter fruit colour");
            this.Colour = Console.ReadLine();
        }

        public virtual void Input(string dataReader)
        {
            string[] readFruit = dataReader.Split(' ');
            this.Name = readFruit[0];
            this.Colour = readFruit[1];
        }
        

        public virtual void Print()
        {
            Console.WriteLine("Fruit {0} with color {1}", this.Name, this.Colour);
        }

        public virtual void Print(StreamWriter writer)
        {
         writer.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Colour}";
        }

        #endregion


    }
}
