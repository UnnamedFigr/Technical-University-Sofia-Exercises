using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlCrawler2._2.Exceptions
{
    public class InvalidQueryException : Exception
    {
        public InvalidQueryException() { }

        public InvalidQueryException(string message) : base(message) { }

        public InvalidQueryException(string message,  Exception innerException) : base(message, innerException) { }

    }
}
