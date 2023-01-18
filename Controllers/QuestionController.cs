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
    public class QuestionController : Controller
    {
        private IQuestionRepository repository = null;

        public QuestionController()
        {
            this.repository = new QuestionRepository();
        }

        public QuestionController(IQuestionRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Question> model = (List<Question>)repository.SelectAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Start()
        {
            List<Question> randomSelect = (List<Question>)repository.SelectRandom();
            return View(randomSelect);
        }

        [HttpGet]
        public ActionResult ThankYou()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Question existing = repository.SelectByID(id);
            return View(existing);
        }

        [HttpGet]
        public ActionResult Q1()
        {
            List<Question> model = (List<Question>)repository.SelectAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Question obj)
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
            Question existing = repository.SelectByID(id);
            return View(existing);
        }

        [HttpPost]
        public ActionResult Edit(Question obj)
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
            Question existing = repository.SelectByID(id);
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