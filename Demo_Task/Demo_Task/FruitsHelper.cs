using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Demo_Task
{
    public class FruitsHelper
    {
        /*Create a List of Fruits and add 5 different fruits and citrus to it.
       - Print data for those fruits whose color is 'yellow'.
       - Sort the list of fruits by name and output the result to a file
       - Provide interception of exceptional situations
       - Serialize-deserialize the list in Xml format
       - Write unit tests for class methods*/

        #region Constants
        private const string fruitFileName = "Fruit.txt";
        private const string citrusFileName = "Citrus.txt";
        private const string sortedListFileName = "SortedFruits.txt";
        private const string xmlSerelizationFruits = "FruitXMLFile.xml";
        private const string removePath = "\\bin\\Debug";
        #endregion

        #region Fields
        private static List<Fruit> fruitsList = new List<Fruit>();
        private static string directoryPath = Directory.GetCurrentDirectory().Replace(removePath, "");
        #endregion

        #region Methods

        public static void CreateFruitsTestData()
        {
            if (fruitsList.Count > 0)
            {
                fruitsList.Clear();
            }
            fruitsList.Add(new Fruit("Apple", "Red"));
            fruitsList.Add(new Fruit("Banana", "Yellow"));
            fruitsList.Add(new Fruit("Pineapple", "Yellow"));
            fruitsList.Add(new Citrus("Pomelo", "Green", 2));
            fruitsList.Add(new Citrus("Lemon", "Yellow", 3));
            fruitsList.Add(new Citrus("Mandarin", "Orange", 1));
        }

        public static void CreateFruitsDataFromConsole()
        {
            Fruit fruit = new Fruit();
            Citrus citrus = new Citrus();

            try
            {
                fruit.Input();
                citrus.Input();
            }
            catch (FormatException formatException)
            {
                Console.WriteLine(formatException);
            }
            //testing null reference exception
            catch (NullReferenceException nullReferenceException)
            {
                Console.WriteLine(nullReferenceException.Message);
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            fruitsList.Add(fruit);
            fruitsList.Add(citrus);
        }

        public static void CreateFruitsDataFromFile(Fruit fruit)
        {
            string fileName = fruit.GetType() == typeof(Fruit) ? fruitFileName : citrusFileName;

            using (StreamReader reader = new StreamReader(Path.Combine(directoryPath, fileName)))
            {
                while (reader.EndOfStream != true)
                {
                    Fruit newFruit = (Fruit) Activator.CreateInstance(fruit.GetType());
                    try
                    {
                        newFruit.Input(reader);
                    }
                    catch (IOException ioException)
                    {
                        Console.WriteLine(ioException.Message);
                    }
                    catch (IndexOutOfRangeException outOfRangeException)
                    {
                        Console.WriteLine(outOfRangeException.Message);
                    }
                    catch (FormatException formatException)
                    {
                        Console.WriteLine(formatException.Message);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }

                    fruitsList.Add(newFruit);
                }
            }
        }

        public static void PrintYellowFruit()
        {
            var yellowFruits = fruitsList.Where(fruit => fruit.Colour == "Yellow");
            foreach (var fruit in yellowFruits)
            {
                fruit.Print();
            }

        }

        public static void SortFruitByName()
        {
            var sortedFruits = fruitsList.OrderBy(fruit => fruit.Name);
            using (StreamWriter writer = new StreamWriter(Path.Combine(directoryPath, sortedListFileName)))
            {
                foreach (var fruit in sortedFruits)
                {
                    try
                    {
                        writer.WriteLine(fruit.ToString());
                    }
                    catch (IOException ioException)
                    {
                        Console.WriteLine(ioException.Message);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            }
        }

        public static void FruitsSerialization()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Fruit>));
            using (FileStream fileStream =
                        new FileStream(Path.Combine(directoryPath, xmlSerelizationFruits), FileMode.Create))
            {
                try
                {
                    xmlSerializer.Serialize(fileStream, fruitsList);

                }
                catch (InvalidOperationException exception)
                {
                    Console.WriteLine(exception.Message);
                    throw;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

            }
        }

        public static void FruitsDeserialization()
        {
            List<Fruit> xmlFruits = new List<Fruit>();
            XmlSerializer xmlDeserializer = new XmlSerializer(typeof(List<Fruit>));
            using (FileStream fileStream =
                        new FileStream(Path.Combine(directoryPath, xmlSerelizationFruits), FileMode.Open))
            {
                try
                {
                    xmlFruits = (List<Fruit>) xmlDeserializer.Deserialize(fileStream);
                }
                catch (InvalidOperationException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

            }

            foreach (Fruit fruit in xmlFruits)
            {
                fruit.Print();
            }
        }
        #endregion
    }
}
