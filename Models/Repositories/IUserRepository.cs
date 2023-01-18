using FFFWebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FFFWebApplication.Models.Respositories
{
    public interface IUserRepository
    {
        IEnumerable<User> SelectAll();
        User SelectByID(int id);
        void Insert(User obj);
        void Update(User obj);
        void Delete(int id);
        void Save();

    }
}
