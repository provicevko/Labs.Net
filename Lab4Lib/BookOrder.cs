using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4Lib
{
    public record BookOrder
    {
        public string BookName { get; init; }
        public string BookAuthor { get; init; }
        public short CountOfDays { get; init; }
    }
}
