using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealDouble.Web.Models.viewModels
{
    public class AuctionsViewModels
    {


        public class CreateAuctionViewModel
        {

            public string Title { get; set; }
            public string Description { get; set; }
            public decimal ActualAmount { get; set; }
            public DateTime StartingDate { get; set; }
            public DateTime EndingDate { get; set; }
            public string AuctionPictures { get; set; }
            public List<AuctionPicture> AuctionPicture { get; set; }

        }
    }
}