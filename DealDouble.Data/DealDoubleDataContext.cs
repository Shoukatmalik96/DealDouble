using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Data
{
    public class DealDoubleDataContext:DbContext
    {
        public DealDoubleDataContext():base("name=DealDoubleConnectionString")
        {

        }
        public DbSet<Auctions>Auctions { get; set; }
    }
}
