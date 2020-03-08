using DesignPattertTest.CreationalPatterns.AbstractFactory.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattertTest.CreationalPatterns.AbstractFactory.Implementations
{
    public class OsxProgressBar : IProgressBar
    {
        public void Draw()
        {
            Console.WriteLine("Render a Progress Bar in Windows style");
        }

        public void SetProgress(int percents)
        {
            Console.WriteLine($"Win progress bar value {percents}%.");
        }
    }
}
