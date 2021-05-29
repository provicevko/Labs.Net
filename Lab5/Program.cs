using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Lab4Lib;
using Lab5.Models;

namespace Lab5
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Library library = new Library();
            library.AddBooks();

            XmlBookInstances xmlBookInstances = new XmlBookInstances();
            await xmlBookInstances.WriteToXmlAsync("bookInstance", library.BookInstances);

            IEnumerable<BookInstanceModel> bookInstances = xmlBookInstances.ParseFromXml("bookInstance");

            xmlBookInstances.SelectBookNames("bookInstance");
            xmlBookInstances.GetOrderedBooks("bookInstance");
            xmlBookInstances.Take3CheapestBooks("bookInstance");
            xmlBookInstances.GetBooksByAuthorName("bookInstance", "DDD");
            xmlBookInstances.GetBooksByGenreName("bookInstance", "AAAA");
            xmlBookInstances.GetBooksExceptBookWithGenre("bookInstance", "AAAA");
        }
    }
}
