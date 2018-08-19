using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_commerce_website.Models;

namespace E_commerce_website.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Table_UserLoginDetails userModel)
        {
            Entities db = new Entities();
            var userDetails = db.Table_UserLoginDetails.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();
           
            if(userDetails == null)
            {                
                userModel.ErrorMessage = "Invalid username or password";
                return View("Index",userModel);
            }
            else
            {
                Session["Id"] = userDetails.UserId;
                Session["userName"] = userDetails.UserName;
                return RedirectToAction("Index", "Home", new {userId = userDetails.UserId});
            }            
        }
        public ActionResult Logout()
        {
            int userId = (int)Session["Id"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}