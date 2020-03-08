using DesignPattertTest.BehaviorPatterns.Strategy.Interfaces;
using System;

namespace DesignPattertTest.BehaviorPatterns.Strategy.Implementations
{
    public class PetrolEngine : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Moving car with petrol.");
        }
    }
}
