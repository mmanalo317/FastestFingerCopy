using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FFFWebApplication.Models.Respositories;
using FFFWebApplication;

namespace FFFWebApplication.Models.Respositories
{
    public class ResultRepository : IResultRepository
    {
        private FFFContext db = null;

        public ResultRepository()
        {
            this.db = new FFFContext();
        }

        public ResultRepository(FFFContext db)
        {
            this.db = db;
        }

        public IEnumerable<Result> SelectAll()
        {
            return db.Results.Include(c => c.User).ToList();
        }

        public Result SelectByID(int id)
        {
            return db.Results.Find(id);
        }

        public void Insert(Result obj)
        {
            db.Results.Add(obj);
        }

        public void Update(Result obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Result existing = db.Results.Find(id);
            db.Results.Remove(existing);
        }

        public void Save()
        {
            db.SaveChanges();
        }

    }
}