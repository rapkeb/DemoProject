using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserDemo.Models;

namespace UserDemo.Controllers
{
    public class ImageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadImage()
        {
            foreach (var file in Request.Form.Files)
            {
                Image img = new Image();
                img.ImageTitle = file.FileName;

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                img.ImageData = ms.ToArray();

                ms.Close();
                ms.Dispose();
                using (var db = new DemoContext())
                {
                    db.Images.Add(img);
                    db.SaveChanges();
                }
            }
            ViewBag.Message = "Image(s) stored in database!";
            return View("Index");
        }
        [Route("/Image/Check/{userName}")]
        public IActionResult Check(string userName)
        {
            return View("Index");
        }

        public ActionResult Images()
        {
            List<Image> images;
            List<string> titles = new List<string>();
            List<string> ImageDataUrls = new List<string>();
            using (var db = new DemoContext())
            {
                images = db.Images.ToList();
            }
            foreach(Image img in images)
            {
                string imageBase64Data = Convert.ToBase64String(img.ImageData);
                string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                titles.Add(img.ImageTitle);
                ImageDataUrls.Add(imageDataURL);
            }
            ViewBag.ImageTitle = titles;
            ViewBag.ImageDataUrl = ImageDataUrls;
            return View();
        }
    }
}