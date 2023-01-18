using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FFFWebApplication.Models.Respositories;
using FFFWebApplication.Models;
using FFFWebApplication;

namespace FFFWebApplication.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository repository = null;

        public UserController()
        {
            this.repository = new UserRepository();
        }

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<User> model = (List<User>)repository.SelectAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            User existing = repository.SelectByID(id);
            return View(existing);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User obj)
        {
            if (ModelState.IsValid)
            { // check valid state
                repository.Insert(obj);
                repository.Save();
                return RedirectToAction("Index");
            }
            else // not valid so redisplay
            {
                return View(obj);
            }
        }

        [HttpGet, ActionName("Edit")]
        public ActionResult ConfirmEdit(int id)
        {
            User existing = repository.SelectByID(id);
            return View(existing);
        }

        [HttpPost]
        public ActionResult Edit(User obj)
        {
            if (ModelState.IsValid)
            { // check valid state
                repository.Update(obj);
                repository.Save();
                return RedirectToAction("Index");
            }
            else // not valid so redisplay
            {
                return View(obj);
            }
        }

        [HttpGet, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            //Instance to get record in the Results table if it exists
            FFFContext db = new FFFContext();
            var result = (from resultList in db.Results
                        where resultList.UserId == id
                        select new
                        {
                            resultList.ResultId,
                            resultList.UserId,

                        }).ToList();
            //If user id is found in results table, send to storage
            if (result.FirstOrDefault() != null)
            {
                Session["CheckResultsTable"] = result.FirstOrDefault().UserId;
                Session["ResultId"] = result.FirstOrDefault().ResultId;
            }
            User existing = repository.SelectByID(id);
            return View(existing);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            repository.Save();
            return RedirectToAction("Index");
        }


    }
}
