using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Commands
{
    
    public interface IAction

    {
        void Execute();
        void Undo();
    }
}
