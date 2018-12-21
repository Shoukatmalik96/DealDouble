using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Entities
{
    public class Auctions:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal ActualAmount { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
    }
}
