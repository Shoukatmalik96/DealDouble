using DealDouble.Data;
using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Services
{
    public class SharedService
    {
        DealDoubleDataContext context = new DealDoubleDataContext();

        public int Savepicture(Picture picture)
        {
            context.Pictures.Add(picture);
            context.SaveChanges();
            return picture.ID;
        }
    }
}
