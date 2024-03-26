using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Commands
{
    internal class RemoveAllShapesAction : IAction
    {
        private List<Shape> _newList;
        private List<Shape> _oldList;
        public RemoveAllShapesAction(List<Shape> shapes)
        {
            _oldList= shapes;
        }

        public void Execute() 
        {
            _newList = new List<Shape>(_oldList);
            _oldList.Clear();
        }

        public void Undo()
        {
            _oldList.AddRange(_newList);
        }
    }
}
