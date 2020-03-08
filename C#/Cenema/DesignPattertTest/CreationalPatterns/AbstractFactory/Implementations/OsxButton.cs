using DesignPattertTest.CreationalPatterns.AbstractFactory.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattertTest.CreationalPatterns.AbstractFactory.Implementations
{
    public class OsxButton : IButton
    {
        public void Draw()
        {
            Console.WriteLine("Render a button in OSX style");
        }
    }
}
