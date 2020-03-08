using DesignPattertTest.CreationalPatterns.FactoryMethod.AbstractClasses;
using DesignPattertTest.CreationalPatterns.FactoryMethod.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattertTest.CreationalPatterns.FactoryMethod.Implementations
{
    public class WinButtonCreater : ButtonCreater
    {
        public override ICrossplatformButton CreateButton()
        {
            return new WinCrossplatformButton();
        }
    }
}
