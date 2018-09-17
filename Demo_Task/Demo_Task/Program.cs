using System;

namespace Demo_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            FruitsHelper.CreateFruitsDataFromConsole();
            FruitsHelper.CreateFruitsDataFromFile(new Fruit());
            FruitsHelper.CreateFruitsDataFromFile(new Citrus());
            FruitsHelper.PrintYellowFruit();
            FruitsHelper.SortFruitByName();
            FruitsHelper.FruitsSerialization();
            FruitsHelper.FruitsDeserialization();

            Console.ReadKey();
        }

    }
}
