using DesignPattertTest.BehaviorPatterns.Strategy.Interfaces;

namespace DesignPattertTest.BehaviorPatterns.Strategy.Implementations
{
    public class HybridCar
    {
        public IMovable Strategy { get; set; }

        public HybridCar(IMovable stategy)
        {
            Strategy = stategy;
        }

        public void Move()
        {
            Strategy.Move();
        }
    }
}
