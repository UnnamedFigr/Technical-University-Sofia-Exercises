using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Exceptions
{
    internal class SelectedShapeNullException : Exception
    {
        public SelectedShapeNullException() { }
        public SelectedShapeNullException(string message) : base(message){ }
        public SelectedShapeNullException(string message, Exception inner) : base(message, inner) { }
    }
}
