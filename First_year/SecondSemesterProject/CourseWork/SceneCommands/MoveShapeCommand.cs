using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Commands;

namespace WindowsFormsApp1.SceneCommands
{
    public class MoveShapeCommand : IMoveShape
    {
        public MoveShapeCommand()
        {
        }
        public void OnMouseDown(MouseEventArgs e) 
        { 
        }

        public void OnMouseMove(MouseEventArgs e,ActionHistory actions ,ref Shape _selectedShape, ref Point _lastMousePos, ref bool _isDragged)
        {
            if (_selectedShape != null && _isDragged)
            {
                int deltaX = e.X - _lastMousePos.X;
                int deltaY = e.Y - _lastMousePos.Y;
                Point newPos = new Point(_selectedShape.Position.X + deltaX, _selectedShape.Position.Y + deltaY);
                MoveShape(newPos,_selectedShape, actions);
                _lastMousePos = e.Location;
            }
        }
        public void OnMouseUp(MouseEventArgs e, ref bool isDragged) { isDragged = false; }
        void ICommandScene.OnMouseMove(MouseEventArgs e) { }
        void ICommandScene.OnMouseUp(MouseEventArgs e) { }
        public void MoveShape(Point newPosition, Shape _selectedShape, ActionHistory _actions)
        {
            IAction command = new MoveShapeAction(_selectedShape, newPosition);
            command.Execute();
            _actions.AddCommand(command);
        }
    }
}
