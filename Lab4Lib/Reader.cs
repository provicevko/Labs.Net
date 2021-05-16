using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4Lib
{
    public class Reader
    {
        private static long _idCounter;
        public long Id { get; } = ++_idCounter;
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public Book GetBook(string name, string author)
        {
            throw new NotImplementedException();
        }
    }
}
