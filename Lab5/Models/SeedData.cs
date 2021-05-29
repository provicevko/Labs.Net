using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4Lib;

namespace Lab5.Models
{
    public static class SeedLibraryData
    {
        public static void AddBooks(this Library library)
        {
            library.AddBookIntoLibrary(new("ASP.NET for Professionals", "DDD", "Programming"), 500, 50);
            library.AddBookIntoLibrary(new("C#9.0", "DDD", "Programming"), 400, 40);
            library.AddBookIntoLibrary(new("TATATA", "BBB", "AAAA"), 700, 60);
            library.AddBookIntoLibrary(new("Azbuka", "Hz", "KtoZnaet"), 700, 23);
            library.GetBookInstanceFromLibrary("ASP.NET for Professionals", "DDD").Amount = 5;
            library.GetBookInstanceFromLibrary("Azbuka", "Hz").Amount = 2;
        }
    }
}
