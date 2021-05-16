using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lab4Lib
{
    public class Reader
    {
        private static long _idCounter;
        internal Reader()
        {
        }
        public long Id { get; } = ++_idCounter;
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Library Library { get; set; } = new();

        public void RegisterInLibrary(Library library)
        {
            Library = library ?? throw new ArgumentNullException(nameof(library));
            library.RegisterReader(this);
        }
        public Book GetBook(string name, string author, short countOfDays) => Library?.GetBookFromLibrary(this, new BookOrder{BookName = name, BookAuthor = author, CountOfDays = countOfDays});
    }
}
