using System;
using System.Collections.Generic;
using System.Linq;
using Lab4.Infrastructure;
using Lab4.Infrastructure.Extensions;
using Lab4.Models;
using Lab4Lib;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            library.AddBooks();

            Reader reader1 = new("Abra", "Cadabra", "LakeStreet", "+380661111111");
            Reader reader2 = new("Vik", "Prv", "PrvStreet", "+111111111111");
            Reader reader3 = new("Aka", "Aka", "AWAStreet", "+444444444444");
            Reader reader4 = new("SSS", "SSS", "QWWStreet", "+555555555555");
            library.AddReaders(reader1, reader2, reader3, reader4);
            var book1 = reader1.GetBook("ASP.NET for Professionals", "DDD", 5);
            var book2 = reader1.GetBook("erfgherh", "erherh", 10);
            var book3 = reader2.GetBook("ASP.NET for Professionals", "DDD", 3);
            var book4 = reader2.GetBook("TATATA", "BBB", 20);
            var book5 = reader1.GetBook("TATATA", "BBB", 12);
            var book7 = reader1.GetBook("ASP.NET for Professionals", "DDD", 5);


            library.SelectBookNames();
            library.SelectBookNamesWithLinqExtensions();
            library.SelectBookAuthorsAndGenres();
            library.SelectBookAuthorsAndGenresWithLinqExtensions();
            library.FindBookInstancesWithMoreThanOneInstance();
            library.FindBookInstancesWithMoreThanOneInstanceWithLinqExtensions();
            library.GetOrderedBooks();
            library.GetOrderedBooksWithLinqExtensions();
            library.Take3CheapestBooks();
            library.GetReadersWithLogData();
            library.GetReadersWithLogDataGroupByReaderId();
            library.FindTheMostPopularBook();
            library.GetAllLogsBetweenDate(DateTime.Today.AddDays(-5),DateTime.Today.AddDays(-2));
            library.IsAnyReaderWithSurname("Ban");
            library.GetBooksByAuthorName("Haha");
            library.GetBooksByGenreName("hz");
            library.GetBooksExceptBookWithGenre("ttt");
            
            //var books = library.BookInstances;
            //var logs = library.LogData;
            //var readers = library.Readers;
        }
    }
}
