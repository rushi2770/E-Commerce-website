using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_commerce_website.Models;
namespace E_commerce_website.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int userId)
        {
            Entities Pdb = new Entities();
            var products = Pdb.Table_ProductDetail.Where(c => c.UserId == userId).ToList();
            return View(products);
        }
    }
}