using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattertTest.CreationalPatterns.AbstractFactory.Intefaces
{
    public interface IGUIFactory
    {
        IButton CreateButton();
        IProgressBar CreateProgressBar();
    }
}
