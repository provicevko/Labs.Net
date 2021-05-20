using Lab4Lib;

namespace Lab4.Models
{
    public static class SeedData
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

        public static void AddReaders(this Library library, params Reader[] readers)
        {
            foreach (var reader in readers)
            {
                reader.RegisterInLibrary(library);
            }
        }
    }
}
