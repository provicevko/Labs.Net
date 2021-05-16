using System;
using System.Collections.Generic;
using Lab4Lib;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            library.AddBookIntoLibrary(new("ASP.NET for Professionals", "DDD", "Programming"), 500, 50);
            library.AddBookIntoLibrary(new("C#8.0", "DDD", "Programming"), 400, 40);
            library.AddBookIntoLibrary(new("TATATA", "BBB", "AAAA"), 700, 60);
            library.GetBookInstanceFromLibrary("ASP.NET for Professionals", "DDD").Amount = 5;

            Reader reader1 = new("Abra", "Cadabra", "LakeStreet", "+380661111111");
            Reader reader2 = new("Vik", "Prv", "PrvStreet", "+111111111111");
            reader1.RegisterInLibrary(library);
            reader2.RegisterInLibrary(library);

            var book1 = reader1.GetBook("ASP.NET for Professionals", "DDD", 5);
            var book2 = reader1.GetBook("erfgherh", "erherh", 10);
            var book3 = reader2.GetBook("ASP.NET for Professionals", "DDD", 3);
            var book4 = reader2.GetBook("TATATA", "BBB", 20);
            var book5 = reader1.GetBook("TATATA", "BBB", 12);
            var books = library.BokBookInstances;
            var logs = library.LogDatas;
            var readers = library.Readers;
        }
    }
}
