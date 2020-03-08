using DesignPattertTest.BehaviorPatterns.Strategy.Interfaces;
using System;

namespace DesignPattertTest.BehaviorPatterns.Strategy.Implementations
{
    public class ElectricEngine : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Moving car with electricity.");
        }
    }
}
