using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Commands
{
    public class MoveShapeAction : IAction
    {
        private Shape _shape;
        private Point _newPos;
        private Point _oldPos;

        public MoveShapeAction(Shape shape, Point newPosition)
        {
            _shape = shape;
            _oldPos = shape.Position;
            _newPos = newPosition;
        }

        public void Execute()
        {
            _shape.Position = _newPos;
            _oldPos = _shape.Position;
        }

        public void Undo()
        {
            _shape.Position = _oldPos;
            _oldPos = _shape.Position;
        }

    }
}
