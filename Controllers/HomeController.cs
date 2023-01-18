using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;
using FFFWebApplication.Models;
using FFFWebApplication;
using NWebsec.Mvc.HttpHeaders.Csp;

namespace FFFWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Sorry()
        {
            return View();
        }
        [HttpGet]
        public ActionResult NoAccess()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                FFFContext db = new FFFContext();
                var user = (from userlist in db.Users
                            where userlist.Email == login.Email && userlist.Password == login.Password
                            select new
                            {
                                userlist.UserId,
                                userlist.Email,
                                userlist.AccessLevel,
                                userlist.FirstName
                            }).ToList();

                if (user.FirstOrDefault() != null)
                {
                    Session["UserName"] = user.FirstOrDefault().Email;
                    Session["UserID"] = user.FirstOrDefault().UserId;
                    Session["UserAccessLevel"] = user.FirstOrDefault().AccessLevel;
                    Session["UserFirstName"] = user.FirstOrDefault().FirstName;
                    var accessNum = user.FirstOrDefault().AccessLevel;
                    //Check the access level to determine dashboard
                    if (accessNum == "Contestant")
                    {
                        //Check if already attempted quiz
                        var userId = user.FirstOrDefault().UserId;
                        var resultCheck = db.Results.Where(i => i.UserId == userId);
                        if (resultCheck.Any())
                        {
                            return Redirect("~/Home/Sorry");
                        }
                        else
                        {
                            return Redirect("~/Question/Start");
                        }
                    }
                    else if (accessNum == "Admin")
                    {
                        return Redirect("~/Home/AdminDB");
                    }
                    else
                    {
                        return Redirect("~/Home/Index");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Invalid login credentials.");
                }
            }
            return View(login);
        }

        public ActionResult ContestantDB()
        {
            return View();
        }

        public ActionResult AdminDB()
        {
            return View();
            /*
            var accessLevel = Session["UserAccessLevel"].ToString();
            //Check there is a stored access level
            if (accessLevel != null)
            {
                //Check if the user is an Admin
                if (accessLevel == "Admin")
                {
                    return View();
                }
                else
                {
                    return Redirect("/Home/NoAccess");
                }
            }
            else
            {
                return Redirect("/Shared/Error");
            }
            */
        }
    }
}