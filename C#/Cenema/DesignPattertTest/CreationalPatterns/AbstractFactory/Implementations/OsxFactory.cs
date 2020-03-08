using DesignPattertTest.CreationalPatterns.AbstractFactory.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattertTest.CreationalPatterns.AbstractFactory.Implementations
{
    public class OsxFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new OsxButton();
        }

        public IProgressBar CreateProgressBar()
        {
            return new OsxProgressBar();
        }
    }
}
