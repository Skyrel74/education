using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattertTest.CreationalPatterns.AbstractFactory.Intefaces
{
    public interface IProgressBar
    {
        void Draw();
        void SetProgress(int percents);
    }
}
