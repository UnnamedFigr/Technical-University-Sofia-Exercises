using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Commands
{
    public class EditShapeAction : IAction
    {
        private readonly List<Shape> _shapes;
        private readonly Shape _oldShape;
        private readonly Shape _newShape;
        public EditShapeAction(List<Shape> shapes, Shape oldShape,Shape newShape)
        {
            _shapes = shapes;
            _newShape = newShape;
            _oldShape = oldShape;
        }

        public void Execute()
        {
            _shapes[_shapes.IndexOf(_oldShape)] = _newShape;
        }
        public void Undo()
        {
            _shapes[_shapes.IndexOf(_newShape)] = _oldShape;
        }
    }
}
