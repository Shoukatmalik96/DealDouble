using DealDouble.Entities;
using DealDouble.Services;
using DealDouble.Web.Models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DealDouble.Web.Models.viewModels.AuctionsViewModels;

namespace DealDouble.Web.Controllers
{
    public class AuctionsController : Controller
    {
        AuctionsService AuctionsService = new AuctionsService();
        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            else
            {
                return View();
            }
           
        }
        public ActionResult Listing()
        {
            List<Auctions> model = new List<Auctions>();
            model = AuctionsService.GetAllAuctions();
            return PartialView(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(CreateAuctionViewModel model)
        {
            Auctions auction = new Auctions();
            auction.Title = model.Title;
            auction.Description = model.Description;
            auction.ActualAmount = model.ActualAmount;
            auction.StartingDate = model.StartingDate;
            auction.EndingDate = model.EndingDate;
            auction.AuctionPictures = new List<AuctionPicture>();

            if (!string.IsNullOrEmpty(model.AuctionPictures))
            {
                //LINQ
                var pictureIDs = model.AuctionPictures.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(ID => int.Parse(ID)).ToList();

                auction.AuctionPictures = new List<AuctionPicture>();
                auction.AuctionPictures.AddRange(pictureIDs.Select(x => new AuctionPicture() { PictureID = x }).ToList());
            }

            AuctionsService.SaveAuction(auction);
            AuctionsService.SaveAuction(auction);
            return RedirectToAction("Listing");
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var auction = AuctionsService.GetAuctionsByID(ID);
            return PartialView(auction);
        }
        [HttpPost]
        public ActionResult Edit(Auctions auctions)
        {
            AuctionsService.UpdateAuction(auctions);
            return RedirectToAction("Listing");
        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            var auction = AuctionsService.GetAuctionsByID(ID);
            return PartialView(auction);
        }
        [HttpPost]
        public ActionResult Delete(Auctions auctions)
        {
            AuctionsService.DeleteAuction(auctions);
            return RedirectToAction("Listing");
        }

    }
}