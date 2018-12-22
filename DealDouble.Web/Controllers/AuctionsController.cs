using DealDouble.Entities;
using DealDouble.Services;
using DealDouble.Web.Models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Create(Auctions auctions)
        {
            AuctionsService.SaveAuction(auctions);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

    }
}