using System;
using System.IO;
using System.Xml.Serialization;

namespace Demo_Task
{
    /*Create a Fruit class that contains:
    - field name and color,
    - define the constructor with the parameters,
    - virtual methods Input () and Print (), to read data from the console and output data to the console,
    as well as overload I / O options from a file.
    - properties for fields,
    - redefine the ToString () method. */

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

        public virtual void Input(StreamReader reader)
        {
            string dataReader = reader?.ReadLine();
            if (!String.IsNullOrEmpty(dataReader) && !String.IsNullOrWhiteSpace(dataReader))
            {
                string[] fruit = dataReader.Split(' ');
                this.Name = fruit[0];
                this.Colour = fruit[1];
            }
        }

        public virtual void Print()
        {
            if (this.Name != null && this.Colour != null)
            {
                Console.WriteLine("Fruit {0} and it's colour {1}", this.Name, this.Colour);
            }
        }

        public virtual void Print(StreamWriter writer)
        {
            writer?.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Colour}";
        }

        #endregion


    }
}
