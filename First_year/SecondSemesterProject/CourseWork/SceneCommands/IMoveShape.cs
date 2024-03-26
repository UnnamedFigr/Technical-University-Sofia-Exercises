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
    public interface IMoveShape : ICommandScene
    {
        void OnMouseMove(MouseEventArgs e, ActionHistory actions, ref Shape _selectedShape, ref Point _lastMousePos, ref bool _isDragged);
        void OnMouseUp(MouseEventArgs e, ref bool isDragged);
    }
}
