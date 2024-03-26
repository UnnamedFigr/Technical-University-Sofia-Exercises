using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Commands
{
    public class RemoveShapeAction : IAction
    {
        private readonly Shape _shape;
        private readonly List<Shape> _shapes;

        public RemoveShapeAction(Shape shape, List<Shape> shapes)
        {
            _shape = shape;
            _shapes = shapes;
        }

        public void Execute()
        {
            _shapes.Remove(_shape);
        }
        public void Undo()
        {
            _shapes.Add(_shape);
        }

    }
}
