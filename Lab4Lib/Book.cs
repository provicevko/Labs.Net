using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4Lib
{
    public class Book
    {
        public Book(string name, string author, string genre)
        {
            Name = name;
            Author = author;
            Genre = genre;
        }
        public string Name { get;}
        public string Author { get;}
        public string Genre { get;}
    }
}
