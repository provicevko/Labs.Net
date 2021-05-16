using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4Lib
{
    public class BookInstance
    {
        private static long _idCounter;
        public readonly Book Book;
        internal BookInstance(Book book, decimal depositPrice, decimal priceADay)
        {
            Book = book ?? throw new ArgumentNullException(nameof(book));
            DepositPrice = depositPrice;
            PriceADay = priceADay;
            Amount++;
        }
        public short Amount { get; set; }
        public long Id { get; } = ++_idCounter;
        public decimal DepositPrice { get; set; }
        public decimal PriceADay { get; set; }
    }
}
