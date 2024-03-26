using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Commands
{
    public class ActionHistory
    {
        private Stack<IAction> _undoStack = new Stack<IAction>();
        private Stack<IAction> _redoStack = new Stack<IAction>();

        public void AddCommand(IAction command)
        {
            _undoStack.Push(command);
            _redoStack.Clear();
        }

        public void Undo()
        {
            if (_undoStack.Count == 0) return;

            IAction command = _undoStack.Pop();
            command.Undo();
            _redoStack.Push(command);
        }

        public void Redo()
        {
            if (_redoStack.Count == 0) return;

            IAction command = _redoStack.Pop();
            command.Execute();
            _undoStack.Push(command);
        }
    }
}
