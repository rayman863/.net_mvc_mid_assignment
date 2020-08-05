using Ch24ShoppingCartMVC.Models;
using Ch24ShoppingCartMVC.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch24ShoppingCartMVC.Controllers
{
    public class UserController : Controller
    {
        //Registration GET
        [HttpGet]
        public ActionResult Registration() {
            return View();    
        }

        //Registration POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(User user) {

            //Validation
            if (ModelState.IsValid) {
                using (HalloweenEntities data = new HalloweenEntities())
                {
                    data.User.Add(user);
                    data.SaveChanges();
                }
            }
            
            return View(user);
        }

        //Login Get
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            using (HalloweenEntities data = new HalloweenEntities())
            {
                var u = data.User.Where(a => a.Username == login.Username).FirstOrDefault();
                if (u != null)
                {
                    if (string.Compare(login.Password, u.Password) == 0)
                    {
                        Session["user"] = u.Username;
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewBag.Message = "Invalid credential!!";
                }
                return View();
            }
        }
    }
}
