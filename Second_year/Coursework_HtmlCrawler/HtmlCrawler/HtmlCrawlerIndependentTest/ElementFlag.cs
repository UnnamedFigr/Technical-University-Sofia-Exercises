using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlCrawlerIndependentTest
{
    internal enum ElementFlag
    {
        CData = 1,

        Empty = 2,

        Closed = 4,

        CanOverlap = 8
    }
}
