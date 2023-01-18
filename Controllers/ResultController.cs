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
    public class ResultController : Controller
    {
        private IResultRepository repository = null;

        public ResultController()
        {
            this.repository = new ResultRepository();
        }

        public ResultController(IResultRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Result> model = (List<Result>)repository.SelectAll();
            return View(model);

        }

        [HttpGet]
        public ActionResult ThankYouComplete()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ThankYou()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThankYou(Result obj)
        {
            if (ModelState.IsValid)
            { // check valid state
                repository.Insert(obj);
                repository.Save();
                return RedirectToAction("ThankYouComplete");
            }
            else // not valid so redisplay
            {
                return View(obj);
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Result existing = repository.SelectByID(id);
            return View(existing);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Result obj)
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
            Result existing = repository.SelectByID(id);
            return View(existing);
        }

        [HttpPost]
        public ActionResult Edit(Result obj)
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
            Result existing = repository.SelectByID(id);
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