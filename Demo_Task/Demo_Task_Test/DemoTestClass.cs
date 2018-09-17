using NUnit.Framework;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using Demo_Task;

namespace Demo_Task_Test
{
    [TestFixture]
    public class DemoTestClass
    {
        private const string fruitFileName = "Fruit.txt";
        private const string citrusFileName = "Citrus.txt";
        private const string sortedListFileName = "SortedFruits.txt";
        private const string xmlSerelizationFruits = "FruitXMLFile.xml";
        private const string removePath = "\\bin\\Debug";
        private string directoryPath = "C:\\Users\\vtereshko\\source\\repos\\Demo_Task\\Demo_Task";

        #region TestFruitMethod

        [TestCase("Berry", "Black")]
        public void Test_Input_Fruit_Console_Method(string name, string colour)
        {
            using (StringWriter writer = new StringWriter())
            {
                Console.SetOut(writer);

                using (StringReader reader = new StringReader(string.Format("{1}{0}{2}{0}",
                            Environment.NewLine, name, colour)))
                {
                    Console.SetIn(reader);

                    Fruit fruit = new Fruit();
                    fruit.Input();

                    string expected = "Enter fruit name\r\nEnter fruit colour\r\n";
                    string actual = writer.ToString();
                    reader.Close();

                    Assert.AreEqual(expected, actual);
                }

                writer.Close();
            }
        }

        [TestCase("Cherry", "Red")]
        public void Test_Print_Fruit_Console_Method(string name, string colour)
        {
            using (StringWriter writer = new StringWriter())
            {
                Console.SetOut(writer);

                Fruit fruit = new Fruit(name, colour);
                fruit.Print();

                string expected = String.Format("Fruit {0} and it's colour {1}\r\n", name, colour);
                string actual = writer.ToString();

                Assert.AreEqual(expected, actual);

                writer.Close();
            }
        }

        [Test]
        public void Test_Input_Fruit_From_File_Method()
        {
            using (StreamReader reader = new StreamReader(Path.Combine(directoryPath, fruitFileName)))
            {
                string actual = String.Empty;
                while (reader.EndOfStream != true)
                {
                    Fruit fruit = new Fruit();
                    fruit.Input(reader);
                    
                    actual += $"{fruit.Name} {fruit.Colour}\n\r";
                }

                string expected = "Apple Red\n\r" +
                                  "Banana Yellow\n\r" +
                                  "Pineapple Yellow\n\r";
                            
                reader.Close();

                Assert.AreEqual(expected, actual);
            }
        }

        #endregion

        #region TestCitrusMethod

        [TestCase("Lime", "Green", "3,5")]
        public void Test_Input_Citrus_Console_Method(string name, string colour, string vitamineC)
        {
            float amountCVitamine = float.Parse(vitamineC);
            using (StringWriter writer = new StringWriter())
            {

                Console.SetOut(writer);

                using (StringReader reader = new StringReader(string.Format("{1}{0}{2}{0}{3}{0}",
                            Environment.NewLine, name, colour, amountCVitamine)))
                {
                    Console.SetIn(reader);

                    Citrus citrus = new Citrus();
                    citrus.Input();

                    string expected =
                                "Enter citrus name\r\nEnter citrus colour\r\nEnter citrus amount C vitamine in gramm\r\n";
                    string actual = writer.ToString();

                    reader.Close();

                    Assert.AreEqual(expected, actual);
                }

                writer.Close();
            }
        }

        [TestCase("Grapefruit", "Orange", "2,32")]
        public void Test_Print_Citrus_Console_Method(string name, string colour, string vitamineC)
        {
            float amountCVitamine = float.Parse(vitamineC);
            using (StringWriter writer = new StringWriter())
            {
                Console.SetOut(writer);

                Citrus citrus = new Citrus(name, colour, amountCVitamine);
                citrus.Print();

                string expected = String.Format("Citrus {0}, it's color {1} and the amount of vitamin C {2}\r\n",
                            name, colour, amountCVitamine);
                string actual = writer.ToString();

                Assert.AreEqual(expected, actual);

                writer.Close();
            }
        }

        [Test]
        public void Test_Input_Citrus_From_File_Method()
        {
            using (StreamReader reader = new StreamReader(Path.Combine(directoryPath, citrusFileName)))
            {
                string actual = String.Empty;
                while (reader.EndOfStream != true)
                {
                    Citrus citrus = new Citrus();
                    citrus.Input(reader);
                    actual += $"{citrus.Name} {citrus.Colour} {citrus.AmountCVitamine}\n\r";
                }

                string expected = "Pomelo Green 0,95\n\r" +
                                  "Lemon Yellow 2,98\n\r" +
                                  "Mandarin Orange 1,76\n\r";

                reader.Close();

                Assert.AreEqual(expected, actual);
            }
        }

        #endregion

        #region TestMainMethods

        [Test]
        public void Catch_Exception_Create_Fruits_Data_From_Console_Method()
        {
            using (StringReader fruitreader = new StringReader(string.Format("{1}{0}{2}{0}",
                        Environment.NewLine, null, null)))
            {
                Console.SetIn(fruitreader);

                Assert.Throws<NullReferenceException>(() => FruitsHelper.CreateFruitsDataFromConsole());
            }
        }

        [Test]
        public void Test_Print_Yellow_Fruits_Method()
        {
            FruitsHelper.CreateFruitsTestData();
            using (StringWriter writer = new StringWriter())
            {

                Console.SetOut(writer);

                FruitsHelper.PrintYellowFruit();

                string expected =
                            "Fruit Banana and it's colour Yellow\r\n" +
                            "Fruit Pineapple and it's colour Yellow\r\n" +
                            "Citrus Lemon, it's color Yellow and the amount of vitamin C 3\r\n";

                string actual = writer.ToString();

                Assert.AreEqual(expected, actual);

                writer.Close();
            }
        }

        [Test]
        public void Test_Fruits_Deserialization_Method()
        {
            FruitsHelper.CreateFruitsTestData();
            FruitsHelper.FruitsSerialization();
            using (StringWriter writer = new StringWriter())
            {

                Console.SetOut(writer);

                FruitsHelper.FruitsDeserialization();

                string expected =
                            "Fruit Apple and it's colour Red\r\n" +
                            "Fruit Banana and it's colour Yellow\r\n" +
                            "Fruit Pineapple and it's colour Yellow\r\n" +
                            "Citrus Pomelo, it's color Green and the amount of vitamin C 2\r\n" +
                            "Citrus Lemon, it's color Yellow and the amount of vitamin C 3\r\n" +
                            "Citrus Mandarin, it's color Orange and the amount of vitamin C 1\r\n";

                string actual = writer.ToString();

                Assert.AreEqual(expected, actual);

                writer.Close();
            }

        }


        #endregion
    }
}