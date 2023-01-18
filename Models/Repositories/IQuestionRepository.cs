using FFFWebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FFFWebApplication.Models.Respositories
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> SelectAll();
        Question SelectByID(int id);
        IEnumerable<Question> SelectRandom();
        void Insert(Question obj);
        void Update(Question obj);
        void Delete(int id);
        void Save();

    }
}
