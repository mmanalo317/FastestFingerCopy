using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FFFWebApplication.Models.Respositories;
using FFFWebApplication;

namespace FFFWebApplication.Models.Respositories
{
    public class UserRepository : IUserRepository
    {
        private FFFContext db = null;

        public UserRepository()
        {
            this.db = new FFFContext();
        }

        public UserRepository(FFFContext db)
        {
            this.db = db;
        }

        public IEnumerable<User> SelectAll()
        {
            return db.Users.ToList();
        }

        public User SelectByID(int id)
        {
            return db.Users.Find(id);
        }

        public void Insert(User obj)
        {
            db.Users.Add(obj);
        }

        public void Update(User obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User existing = db.Users.Find(id);
            db.Users.Remove(existing);
        }

        public void Save()
        {
            db.SaveChanges();
        }

    }
}