using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Exceptions
{
    public class FilterNotClearedException : Exception
    {
        public FilterNotClearedException() { }
        public FilterNotClearedException(string message) : base(message) { }
        public FilterNotClearedException(string message, Exception inner) : base(message, inner) { }
    }
}
