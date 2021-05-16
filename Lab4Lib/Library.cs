using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4Lib
{
    public class Library
    {
        private readonly List<BookInstance> _bookInstances = new();
        private readonly List<Reader> _readers = new();
        private readonly List<LogData> _logs = new();
        public Library()
        {
            
        }

        public void RegisterReader(Reader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            if(!IsReaderInLibrary(reader))
                _readers.Add(reader);
        }

        private bool IsReaderInLibrary(Reader reader) => _readers.Any(x=>x.Id == reader.Id);

        public Book FindBook(string name, string author) => GetBookInstanceFromLibrary(name, author)?.Book;

        public Book GetBookFromLibrary(Reader reader, BookOrder bookOrder)
        {
            if (!IsReaderInLibrary(reader))
                throw new InvalidOperationException();

            var bookInstance = GetBookInstanceFromLibrary(bookOrder.BookName, bookOrder.BookAuthor);

            if (bookInstance != null && IsAvailableBook(bookInstance))
            {
                bookInstance.Amount--;
                _logs.Add(new(reader.Id, bookInstance.Id, bookOrder.CountOfDays));
            }

            return bookInstance?.Book;
        }
        private BookInstance GetBookInstanceFromLibrary(string name, string author) => _bookInstances.FirstOrDefault(d=>d.Book.Name == name && d.Book.Author == author);

        private bool IsAvailableBook(BookInstance bookInstance) => bookInstance?.Amount >= 1;
        
        private bool IsExistBook(string name, string author) => _bookInstances.Any(d=>d.Book.Name == name && d.Book.Author == author);
        
        public void AddBookIntoLibrary(Book book, decimal depositPrice, decimal priceADay)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (IsExistBook(book.Name, book.Author))
                throw new InvalidOperationException();

            _bookInstances.Add(new(book, depositPrice, priceADay));
        }
    }
}
