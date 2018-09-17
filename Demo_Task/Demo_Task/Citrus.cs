using System;
using System.IO;

namespace Demo_Task
{
    /*Create a derived class Citrus from class Fruit, which has:
    - field - the amount of vitamin C in grams,
    - define the constructor with parameters
    - property,
    - Redefined methods Input () and Print ().*/

    [Serializable]
    public class Citrus : Fruit
    {
        #region Fields

        private float amountCVitamine;

        #endregion


        #region Constructors

        public Citrus()
        { }

        public Citrus(string name, string colour, float amountCVitamine) : base(name, colour)
        {
            this.amountCVitamine = amountCVitamine;
        }

        #endregion

        #region Proporties

        public float AmountCVitamine
        {
            get { return amountCVitamine; }
            set { amountCVitamine = value; }
        }

        #endregion

        #region Methods

        public override void Input()
        {
            Console.WriteLine("Enter citrus name");
            this.Name = Console.ReadLine();
            Console.WriteLine("Enter citrus colour");
            this.Colour = Console.ReadLine();
            Console.WriteLine("Enter citrus amount C vitamine in gramm");
            string enteredVitamineC = Console.ReadLine().Replace('.', ',');
            this.AmountCVitamine = ((String.IsNullOrEmpty(enteredVitamineC)) &&
                                    (String.IsNullOrWhiteSpace(enteredVitamineC)))
                                    ? 0
                                    : float.Parse(enteredVitamineC);
        }

        public override void Input(StreamReader reader)
        {
            string dataReader = reader?.ReadLine();
            string[] readCitrus = dataReader.Split(' ');
            this.Name = readCitrus[0];
            this.Colour = readCitrus[1];
            this.AmountCVitamine = ((String.IsNullOrEmpty(readCitrus[2])) &&
                                    (String.IsNullOrWhiteSpace(readCitrus[2])))
                                    ? 0
                                    : float.Parse(readCitrus[2].Replace('.', ','));
        }


        public override void Print()
        {

            if (this.Name != null && this.Colour != null)
            {
                Console.WriteLine("Citrus {0}, it's color {1} and the amount of vitamin C {2}", this.Name, this.Colour,
                            this.AmountCVitamine);
            }  
        }

        public override void Print(StreamWriter writer)
        {
            writer?.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Colour} {this.AmountCVitamine}";
        }

        #endregion
    }
}
