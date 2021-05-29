using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Lab4Lib;
using Lab5.Models;

namespace Lab5
{
    public class XmlBookInstances
    {
        public async Task WriteToXmlAsync(string fileName, IEnumerable<BookInstance> bookInstances)
        {
            if (bookInstances == null)
                throw new ArgumentNullException(nameof(bookInstances));

            XmlWriterSettings settings = new XmlWriterSettings { Async = true, Indent = true };

            await using XmlWriter xmlWriter = XmlWriter.Create(fileName + ".xml", settings);

            await xmlWriter.WriteStartElementAsync(null, "bookInstances", null);

            foreach (var bI in bookInstances)
            {
                await xmlWriter.WriteStartElementAsync(null, "bookInstance", null);
                await xmlWriter.WriteAttributeStringAsync(null, "id", null, bI.Id.ToString());

                await xmlWriter.WriteStartElementAsync(null, "book", null);
                await xmlWriter.WriteElementStringAsync(null, "name", null, bI.Book.Name);
                await xmlWriter.WriteElementStringAsync(null, "author", null, bI.Book.Author);
                await xmlWriter.WriteElementStringAsync(null, "genre", null, bI.Book.Genre);
                await xmlWriter.WriteEndElementAsync();

                await xmlWriter.WriteElementStringAsync(null, "amount", null, bI.Amount.ToString());
                await xmlWriter.WriteElementStringAsync(null, "depositPrice", null, bI.DepositPrice.ToString(CultureInfo.InvariantCulture));
                await xmlWriter.WriteElementStringAsync(null, "priceADay", null, bI.PriceADay.ToString(CultureInfo.InvariantCulture));

                await xmlWriter.WriteEndElementAsync();
            }

            await xmlWriter.WriteEndElementAsync();
        }

        public IEnumerable<BookInstanceModel> ParseFromXml(string fileName)
        {
            XDocument xDocument = XDocument.Load(fileName + ".xml");

            return xDocument.Element("bookInstances")?.Elements("bookInstance")
                .Select(x => new BookInstanceModel
                {
                    Amount = short.Parse(x.Element("amount")?.Value!),
                    Book = new Book(x.Element("book")?.Element("name")?.Value, x.Element("book")?.Element("author")?.Value, x.Element("book")?.Element("genre")?.Value),
                    DepositPrice = decimal.Parse(x.Element("depositPrice")?.Value!),
                    PriceADay = decimal.Parse(x.Element("priceADay")?.Value!),
                    Id = long.Parse(x.Attribute("id")?.Value!)
                });
        }

        public IEnumerable<string> SelectBookNames(string fileName)
        {
            XDocument xDocument = XDocument.Load(fileName + ".xml");

            return xDocument.Element("bookInstances")?.Elements("bookInstance").Elements("book").Select(x => x.Element("name")?.Value);
        }

        public IEnumerable<Book> GetOrderedBooks(string fileName)
        {
            XDocument xDocument = XDocument.Load(fileName + ".xml");

            return xDocument.Element("bookInstances")?.Elements("bookInstance").Select(x => new Book(x.Element("book")?.Element("name")?.Value, x.Element("book")?.Element("author")?.Value, x.Element("book")?.Element("genre")?.Value)).OrderBy(x => x.Name);
        }

        public IEnumerable<BookInstanceModel> Take3CheapestBooks(string fileName)
        {
            XDocument xDocument = XDocument.Load(fileName + ".xml");

            return ParseFromXml(fileName).OrderBy(x => x.PriceADay).Take(3);
        }

        public IEnumerable<Book> GetBooksByAuthorName(string fileName, string authorName)
        {
            XDocument xDocument = XDocument.Load(fileName + ".xml");

            return xDocument.Element("bookInstances")?.Elements("bookInstance").Elements("book")
                .Where(t => t.Element("author")?.Value == authorName).Select(x =>
                    new Book(x.Element("name")?.Value, x.Element("author")?.Value,
                        x.Element("genre")?.Value));
        }

        public IEnumerable<Book> GetBooksByGenreName(string fileName, string genre)
        {
            XDocument xDocument = XDocument.Load(fileName + ".xml");

            return xDocument.Element("bookInstances")?.Elements("bookInstance").Elements("book")
                .Where(t => t.Element("genre")?.Value == genre).Select(x =>
                    new Book(x.Element("name")?.Value, x.Element("author")?.Value,
                        x.Element("genre")?.Value));
        }

        public IEnumerable<Book> GetBooksExceptBookWithGenre(string fileName, string genreName)
        {
            XDocument xDocument = XDocument.Load(fileName + ".xml");
            var books = xDocument.Element("bookInstances")?.Elements("bookInstance").Elements("book");

            return (books ?? throw new InvalidOperationException()).Except(books.Where(x => x.Element("genre")?.Value == genreName)).Select(b=>new Book(b.Element("name")?.Value, b.Element("author")?.Value,
                        b.Element("genre")?.Value));
        }
    }
}
