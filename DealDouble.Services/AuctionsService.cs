using DealDouble.Data;
using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Services
{
    public class AuctionsService
    {

        public Auctions GetAuctionsByID(int ID)
        {
            return context.Auctions.Find(ID);      
        }
        public List<Auctions> GetAllAuctions()
        {
            return context.Auctions.ToList();
        }
        DealDoubleDataContext context = new DealDoubleDataContext();
        public void SaveAuction(Auctions auctions)
        {
            context.Auctions.Add(auctions);
            context.SaveChanges();
        }
        public void UpdateAuction(Auctions auctions)
        {
            context.Entry(auctions).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteAuction(Auctions auctions)
        {
            context.Entry(auctions).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }
        
        public int Savepicture(Picture picture)
        {
            context.Pictures.Add(picture);
            context.SaveChanges();
            return picture.ID;
        }

    }
}
