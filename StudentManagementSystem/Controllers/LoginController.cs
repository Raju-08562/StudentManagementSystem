using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public  ActionResult Index(User_Registration user_Registration)
        {
            if(ModelState.IsValid)
            {
                using (StudentManagementSystemEntities db = new StudentManagementSystemEntities())
                {
                    var user = db.User_Registrations.Where(a => a.User_Name.Equals(user_Registration.User_Name)
                                      && a.Password.Equals(user_Registration.Password)).FirstOrDefault();

                    if (user != null)
                    {
                        Session["UserID"] = user.ID;
                        Session["UserName"] = user.User_Name;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "User Not Found");
                        return View(user_Registration);
                    }
                }
            }
            

            return View();
        }

        public  ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}