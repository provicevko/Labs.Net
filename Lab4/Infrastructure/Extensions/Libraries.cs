using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lab4Lib;

namespace Lab4.Infrastructure.Extensions
{
    public static class Libraries
    {
        /// <summary>
        /// This method selects book names
        /// </summary>
        /// <param name="library"></param>
        /// <returns></returns>
        public static IEnumerable<string> SelectBookNames(this Library library)
        {
            if (library == null)
                throw new ArgumentNullException(nameof(library));

            return from bI in library.BookInstances select bI.Book.Name;
        }

        /// <summary>
        /// This method selects book names with LINQ Extensions
        /// </summary>
        /// <param name="library"></param>
        /// <returns></returns>
        public static IEnumerable<string> SelectBookNamesWithLinqExtensions(this Library library)
        {
            if (library == null)
                throw new ArgumentNullException(nameof(library));

            return library.BookInstances.Select(x => x.Book.Name);
        }

        /// <summary>
        /// This method selects authors and genres from all books
        /// </summary>
        /// <param name="library"></param>
        /// <returns></returns>
        public static IEnumerable<Tuple<string, string>> SelectBookAuthorsAndGenres(this Library library)
        {
            if (library == null)
                throw new ArgumentNullException(nameof(library));

            return from bI in library.BookInstances select new Tuple<string, string>(bI.Book.Author, bI.Book.Genre);
        }

        /// <summary>
        /// This method selects authors and genres from all books with LINQ Extensions
        /// </summary>
        /// <param name="library"></param>
        /// <returns></returns>
        public static IEnumerable<Tuple<string, string>> SelectBookAuthorsAndGenresWithLinqExtensions(this Library library)
        {
            if (library == null)
                throw new ArgumentNullException(nameof(library));

            return library.BookInstances.Select(x => new Tuple<string, string>(x.Book.Author, x.Book.Genre));
        }

        /// <summary>
        /// This method finds book instances with amount > 1
        /// </summary>
        /// <param name="library"></param>
        /// <returns></returns>
        public static IEnumerable<BookInstance> FindBookInstancesWithMoreThanOneInstance(this Library library)
        {
            if (library == null)
                throw new ArgumentNullException(nameof(library));

            return from bI in library.BookInstances where bI.Amount > 1 select bI;
        }

        /// <summary>
        /// This method finds book instances with amount > 1 with LINQ Extensions 
        /// </summary>
        /// <param name="library"></param>
        /// <returns></returns>
        public static IEnumerable<BookInstance> FindBookInstancesWithMoreThanOneInstanceWithLinqExtensions(this Library library)
        {
            if (library == null)
                throw new ArgumentNullException(nameof(library));

            return library.BookInstances.Where(x => x.Amount > 1);
        }

        /// <summary>
        /// This method get ordered books from library
        /// </summary>
        /// <param name="library"></param>
        /// <returns></returns>
        public static IEnumerable<Book> GetOrderedBooks(this Library library)
        {
            if (library == null)
                throw new ArgumentNullException(nameof(library));

            return from bI in library.BookInstances orderby bI.Book.Name select bI.Book;
        }

        /// <summary>
        /// This method get ordered books from library with LINQ Extensions
        /// </summary>
        /// <param name="library"></param>
        /// <returns></returns>
        public static IEnumerable<Book> GetOrderedBooksWithLinqExtensions(this Library library)
        {
            if (library == null)
                throw new ArgumentNullException(nameof(library));

            return library.BookInstances.Select(x => x.Book).OrderBy(b => b.Name);
        }

        //////////////////////////////////Here only with LINQ Extensions//////////////////////////

        /// <summary>
        /// This method takes 3 cheapest books
        /// </summary>
        /// <param name="library"></param>
        /// <returns></returns>
        public static IEnumerable<BookInstance> Take3CheapestBooks(this Library library)
        {
            if (library == null)
                throw new ArgumentNullException(nameof(library));

            return library.BookInstances.OrderBy(x => x.PriceADay).Take(3);
        }

        /// <summary>
        /// This method gets readers with their Log Data
        /// </summary>
        /// <param name="library"></param>
        /// <returns></returns>
        public static IEnumerable<(long ReaderId, string Name, string Surname, long BookInstanceId, DateTime StartDate, DateTime EndDate)> GetReadersWithLogData(this Library library)
        {
            if (library == null)
                throw new ArgumentNullException(nameof(library));

            return library.Readers.Join(library.LogData, r => r.Id, l => l.ReaderId, (r, l) =>
                    (r.Id, r.Name, r.SurName, l.BookInstanceId, l.StartDate, l.EndDateTime));
        }

        /// <summary>
        /// This method gets readers with their Log Data grouped by reader Id
        /// </summary>
        /// <param name="library"></param>
        /// <returns></returns>
        public static IEnumerable<((long Id, string Name, string SurName) Reader, IEnumerable<long> BookInstanceIds)> GetReadersWithLogDataGroupByReaderId(this Library library)
        {
            if (library == null)
                throw new ArgumentNullException(nameof(library));

            return library.Readers.GroupJoin(library.LogData, r => r.Id, l => l.ReaderId,
                (r, l) => ((r.Id, r.Name, r.SurName), l.Select(t => t.BookInstanceId))
                    );
        }
        /// <summary>
        /// This method finds the most popular book in library
        /// </summary>
        /// <param name="library"></param>
        /// <returns></returns>
        public static Book FindTheMostPopularBook(this Library library)
        {
            if (library == null)
                throw new ArgumentNullException(nameof(library));

            var popularBookKey = library.LogData.GroupBy(x => x.BookInstanceId).Select(x => new {Key = x.Key, Count = x.Count()})
                .OrderByDescending(x=>x.Count).Select(xr=>xr.Key).FirstOrDefault();
            return library.BookInstances.FirstOrDefault(t => t.Id == popularBookKey)?.Book;
        }

        /// <summary>
        /// This method gets all logs by dates
        /// </summary>
        /// <param name="library"></param>
        /// <param name="leftDate"></param>
        /// <param name="rightDate"></param>
        /// <returns></returns>
        public static IEnumerable<LogData> GetAllLogsBetweenDate(this Library library, DateTime leftDate, DateTime rightDate)
        {
            if (library == null)
                throw new ArgumentNullException(nameof(library));

            return library.LogData.Where(x => x.StartDate >= leftDate && x.EndDateTime <= rightDate);
        }

        /// <summary>
        /// This method check if any readers with given surname exist
        /// </summary>
        /// <param name="library"></param>
        /// <param name="surname"></param>
        /// <returns></returns>
        public static bool IsAnyReaderWithSurname(this Library library, string surname)
        {
            if (library == null)
                throw new ArgumentNullException(nameof(library));

            return library.Readers.Any(x=>x.SurName == surname);
        }

        /// <summary>
        /// This method gets books by author name
        /// </summary>
        /// <param name="library"></param>
        /// <param name="authorName"></param>
        /// <returns></returns>
        public static IEnumerable<Book> GetBooksByAuthorName(this Library library, string authorName)
        {
            if (library == null)
                throw new ArgumentNullException(nameof(library));

            return library.BookInstances.Where(x => x.Book.Author == authorName).Select(x=>x.Book);
        }

        /// <summary>
        /// This method gets books by genre name
        /// </summary>
        /// <param name="library"></param>
        /// <param name="genre"></param>
        /// <returns></returns>
        public static IEnumerable<Book> GetBooksByGenreName(this Library library, string genre)
        {
            if (library == null)
                throw new ArgumentNullException(nameof(library));

            return library.BookInstances.Where(x => x.Book.Genre == genre).Select(x => x.Book);
        }

        /// <summary>
        /// This method gets books which except book with genre name 
        /// </summary>
        /// <param name="library"></param>
        /// <param name="genreName"></param>
        /// <returns></returns>
        public static IEnumerable<Book> GetBooksExceptBookWithGenre(this Library library, string genreName)
        {
            if (library == null)
                throw new ArgumentNullException(nameof(library));

            return library.BookInstances.Except(library.BookInstances.Where(x => x.Book.Genre == genreName).Select(x => x)).Select(x=>x.Book);
            //return library.BookInstances.Where(x => x.Book.Genre != genreName).Select(x=>x.Book);
        }
    }
}
