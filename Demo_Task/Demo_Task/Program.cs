using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Demo_Task
{
    class Program
    {
        private const string fruitFileName = "Fruit.txt";
        private const string citrusFileName = "Citrus.txt";
        private const string sortedListFileName = "SortedFruits.txt";
        private const string xmlSerelizationFruits = "Fruit.xml";
        private const string removePath = "\\bin\\Debug";

        private static List<Fruit> fruitsList = new List<Fruit>();
        private static string directoryPath = String.Empty;
        /*Утворити List фруктів і додати до нього 5 різних фруктів і цитрусів.
- Видрукувати дані про ті фрукти, колір яких є 'жовтий'.
- Посортувати список фруктів за назвою і результат вивести у файл
- Передбачити перехоплення виняткових ситуацій
- Сериалізувати-десериалізувати список у Xml форматі
- Написати  юніт-тести на методи класів
*/
        static void Main(string[] args)
        {
            directoryPath = Directory.GetCurrentDirectory().Replace(removePath, "");
            CreateFruitData();
            CreateCitrusData();
            PrintYellowFruit();
            SortFruitByName();
            FruitsSerialization();
            FruitsDeserialization();

            Console.ReadKey();
        }

        private static void CreateFruitData()
        {
            string readerData = String.Empty;
            Fruit fruit = new Fruit();
            fruit.Input();
            fruitsList.Add(fruit);
            using (StreamReader reader = new StreamReader(Path.Combine(directoryPath, fruitFileName)))
            {
                while ((readerData = reader.ReadLine()) != null)
                {
                    Fruit fruitData = new Fruit();
                    fruitData.Input(readerData);
                    fruitsList.Add(fruitData);
                }
            }
        }

        private static void CreateCitrusData()
        {
            string readerData = String.Empty;
            Citrus citrus = new Citrus();
            citrus.Input();
            fruitsList.Add(citrus);
            using (StreamReader reader = new StreamReader(Path.Combine(directoryPath, citrusFileName)))
            {
                while ((readerData = reader.ReadLine()) != null)
                {
                    Citrus citrusData = new Citrus();
                    citrusData.Input(readerData);
                    fruitsList.Add(citrusData);
                }
            }
        }

        private static void PrintYellowFruit()
        {
            var yellowFruits = fruitsList.Where(fruit => fruit.Colour == "Yellow");
            foreach (var fruit in yellowFruits) {
                fruit.Print();
            }

        }

        private static void SortFruitByName()
        {
            var sortedFruits = fruitsList.OrderBy(fruit => fruit.Name);
            using (StreamWriter writer = new StreamWriter(Path.Combine(directoryPath, sortedListFileName )))
            {
                foreach (var fruit in sortedFruits) {
                    writer.WriteLine(fruit.ToString());
                }
            }
        }

        private static void FruitsSerialization()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Fruit>));
            using (FileStream fileStream = new FileStream(Path.Combine(directoryPath, xmlSerelizationFruits), FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fileStream, fruitsList);
            }
        }

        private static void FruitsDeserialization()
        {
            List<Fruit> xmlFruits = new List<Fruit>();
            XmlSerializer xmlDeserializer = new XmlSerializer(typeof(List<Fruit>));
            using (FileStream fileStream = new FileStream(Path.Combine(directoryPath, xmlSerelizationFruits), FileMode.Open))
            {
                try {
                    xmlFruits = (List<Fruit>)xmlDeserializer.Deserialize(fileStream);
                }
                catch (InvalidOperationException e) {
                    Console.WriteLine(e);
                    throw;
                }
               
            }

            foreach (Fruit fruit in xmlFruits) {
                if (!fruitsList.Any(item => item.Name == fruit.Name && item.Colour == fruit.Colour)) {
                    fruitsList.Add(fruit);
                }
            }
        }
    }
}
