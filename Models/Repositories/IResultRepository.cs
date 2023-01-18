using FFFWebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FFFWebApplication.Models.Respositories
{
    public interface IResultRepository
    {
        IEnumerable<Result> SelectAll();
        Result SelectByID(int id);
        void Insert(Result obj);
        void Update(Result obj);
        void Delete(int id);
        void Save();

    }
}
