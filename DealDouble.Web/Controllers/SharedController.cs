using DealDouble.Entities;
using DealDouble.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Web.Controllers
{
    public class SharedController : Controller
    {
        SharedService SharedService = new SharedService();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UploadPictures()
        {
            JsonResult result = new JsonResult();
            List<object> pictureJSON = new List<object>();

            var pictures = Request.Files;

            for (int i = 0; i < pictures.Count; i++)
            {
                var picture = pictures[i];

                var fileName = Guid.NewGuid() + Path.GetExtension(picture.FileName);

                var path = Server.MapPath("~/Content/images/") + fileName;

                picture.SaveAs(path);

                var dbpictures = new Picture();
                dbpictures.URL = path;
                int pictureID = SharedService.Savepicture(dbpictures);
                pictureJSON.Add(new { PictureID = pictureID, pictureURL = "/Content/images/" + fileName });
            }
            result.Data = pictureJSON;
            return result;
        }
    }
}