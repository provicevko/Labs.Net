using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4Lib
{
    public class LogData
    {
        public LogData(long readerId, long bookInstanceId, int countOfDays)
        {
            ReaderId = readerId;
            BookInstanceId = bookInstanceId;
            EndDateTime = StartDate.AddDays(countOfDays);
        }
        public long ReaderId { get; }
        public long BookInstanceId { get; }
        public DateTime StartDate { get; } = DateTime.Today;
        public DateTime EndDateTime { get; }
    }
}
