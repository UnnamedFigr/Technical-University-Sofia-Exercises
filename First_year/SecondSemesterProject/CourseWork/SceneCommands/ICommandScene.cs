using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.SceneCommands
{
    public interface ICommandScene
    {
        void OnMouseDown(MouseEventArgs e); 
        void OnMouseUp(MouseEventArgs e);
        void OnMouseMove(MouseEventArgs e);
    }
}
