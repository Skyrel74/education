using System;
using DesignPattertTest.BehaviorPatterns.Strategy.Implementations;
using DesignPattertTest.CreationalPatterns.AbstractFactory.Implementations;
using DesignPattertTest.CreationalPatterns.AbstractFactory.Intefaces;
using DesignPattertTest.CreationalPatterns.FactoryMethod.Implementations;

namespace DesignPattertTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //FactoryMethodDemo();
            //AbstractFactoryDemo();
            StrategyDemo();
            Console.ReadKey();
        }

        public static void FactoryMethodDemo()
        {
            var winButtonCreator = new WinButtonCreater();
            var winButton = winButtonCreator.CreateButton();
            winButton.Draw();
            var osxButtonCreator = new OsxButtonCreater();
            var osxButton = osxButtonCreator.CreateButton();
            osxButton.Draw();
        }

        public static void AbstractFactoryDemo()
        {
            var key = Console.ReadLine();
            IGUIFactory factory;
            switch (key)
            {
                case "W":
                    factory = new WinFactory();
                    break;
                case "O":
                    factory = new OsxFactory();
                    break;
                default:
                    factory = new WinFactory();
                    break;
            }
            CreateWindowWithTwoButoonsAndProgressBar(factory);
        }

        private static void CreateWindowWithTwoButoonsAndProgressBar(IGUIFactory factory)
        {
            var button1 = factory.CreateButton();
            var button2 = factory.CreateButton();
            var progressBar = factory.CreateProgressBar();
            button1.Draw();
            button2.Draw();
            progressBar.Draw();
            progressBar.SetProgress(45);
        }

        private static void StrategyDemo()
        {
            var hybridCar = new HybridCar(new PetrolEngine());
            hybridCar.Move();
            hybridCar.Strategy = new ElectricEngine();
            hybridCar.Move();
        }
    }
}
