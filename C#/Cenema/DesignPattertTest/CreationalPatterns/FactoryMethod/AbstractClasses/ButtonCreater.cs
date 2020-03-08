using DesignPattertTest.CreationalPatterns.FactoryMethod.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattertTest.CreationalPatterns.FactoryMethod.AbstractClasses
{
    public abstract class ButtonCreater
    {
        public abstract ICrossplatformButton CreateButton();
        public ICrossplatformButton RenderButton()
        {
            var button = CreateButton();
            button.Draw();
            return button;
        }
    }
}
