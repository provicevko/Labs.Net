using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4Lib;

namespace Lab5.Models
{
    public class BookInstanceModel
    {
        public Book Book { get; set; }
        public short Amount { get; set; }
        public long Id { get; set; } 
        public decimal DepositPrice { get; set; }
        public decimal PriceADay { get; set; }
    }
}
