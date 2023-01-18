using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using FFFWebApplication.Models.Respositories;
using FFFWebApplication;

namespace FFFWebApplication.Models.Respositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private FFFContext db = null;

        public QuestionRepository()
        {
            this.db = new FFFContext();
        }

        public QuestionRepository(FFFContext db)
        {
            this.db = db;
        }

        public IEnumerable<Question> SelectAll()
        {
            return db.Questions.OrderBy(x => x.QuestionSet).ToList();
        }

        public Question SelectByID(int id)
        {
            return db.Questions.Find(id);
        }

        public IEnumerable<Question> SelectRandom()
        {
            //var idsList = db.Questions.Select(item => item.QuestionId).ToList();

            //Random r = new Random();
            //int randIndex = r.Next(idsList.Count);
            //id = idsList[randIndex];
            //id = 2;

            return db.Questions.ToList();
        }

        public void Insert(Question obj)
        {
            db.Questions.Add(obj);
        }

        public void Update(Question obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Question existing = db.Questions.Find(id);
            db.Questions.Remove(existing);
        }

        public void Save()
        {
            db.SaveChanges();
        }

    }
}