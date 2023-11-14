using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.SceneCommands
{
    public interface ISelectShape : ICommandScene
    {
        void OnMouseDown(MouseEventArgs e,
        List<Shape> _shapes,
        ref Shape _selectedShape,
        ref Point _lastMousePos,
        ref bool _isDragged,
        Label _surfaceArea);
    }


}
