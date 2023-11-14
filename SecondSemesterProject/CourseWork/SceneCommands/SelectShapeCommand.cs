using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.SceneCommands
{
    public class SelectShapeCommand : ISelectShape
    {

        public void OnMouseDown(MouseEventArgs e,
        List<Shape> _shapes,
        ref Shape _selectedShape,
        ref Point _lastMousePos,
        ref bool _isDragged,
        Label _surfaceArea)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    for (int i = _shapes.Count - 1; i >= 0; i--)
                    {
                        if (!_shapes[i].ContainsPoint(e.Location))
                        {
                            _selectedShape = null;
                            _surfaceArea.Text = "Select a shape";
                            continue;
                        }
                        _isDragged = true;
                        _lastMousePos = e.Location;
                        _selectedShape = _shapes[i];
                        _shapes[i] = _shapes[_shapes.Count - 1];
                        _shapes[_shapes.Count - 1] = _selectedShape;
                        break;

                    }
                    break;
            }
            if (_selectedShape != null)
            {
                _surfaceArea.Text = string.Format("{0:F2}", _selectedShape.CalculateArea(_selectedShape));
            }
        }
        public void OnMouseMove(MouseEventArgs e){}
        public void OnMouseUp(MouseEventArgs e){}
        void ICommandScene.OnMouseDown(MouseEventArgs e){ }

    }
}
