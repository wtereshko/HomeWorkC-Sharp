using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Task
{
    /*2) Утворити похідний від нього клас Цитрус, який має:
- поле - вміст вітаміну С в грамах, 
- конструктор з параметрами, 
- властивість, 
- перевизначені методи Input() та Print().
*/
   [Serializable]
   public class Citrus : Fruit
    {
        #region Fields

        private float amountCVitamine;

        #endregion


        #region Constructors

        public Citrus() { }

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
            try
            {
                float vitamineC = float.Parse(enteredVitamineC);
                this.AmountCVitamine = vitamineC;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override void Input(string dataReader)
        {
            if (!String.IsNullOrEmpty(dataReader)) {
                string[] readCitrus = dataReader.Split(' ');
                this.Name = readCitrus[0];
                this.Colour = readCitrus[1];
                try {
                    this.AmountCVitamine = float.Parse(readCitrus[2].Replace('.', ','));
                }
                catch (FormatException e) {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public override void Print()
        {
            Console.WriteLine("Citrus {0} with color {1} and the amount of vitamin C {2}", this.Name, this.Colour, this.AmountCVitamine);
        }

        public override void Print(StreamWriter writer)
        {
            writer.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Colour} {this.AmountCVitamine}";
        }
        #endregion
    }
}
