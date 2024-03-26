using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Commands
{
    public class AddShapeAction : IAction
    {
        private readonly Shape _shape;
        private readonly List<Shape> _shapes =  new List<Shape>();
        public AddShapeAction(Shape shape, List<Shape> shapes)
        {
            _shape = shape;
            _shapes = shapes;
        }

        public void Execute()
        {
            _shapes.Add(_shape);
        }
        public void Undo()
        {
            _shapes.Remove(_shape);
        }
    }
}
