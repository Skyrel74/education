﻿using DesignPattertTest.CreationalPatterns.FactoryMethod.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattertTest.CreationalPatterns.FactoryMethod.Implementations
{
    public class OsxCrossplatformButton : ICrossplatformButton
    {
        public void Draw()
        {
            Console.WriteLine("Rened a button in Osx style");
        }
    }
}
