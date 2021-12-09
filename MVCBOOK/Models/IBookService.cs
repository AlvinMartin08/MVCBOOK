using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBOOK.Models
{
    public interface IBookService
    {
        Book Add(CreateBookViewModel book);
        List<Book> All();
        List<Book> Search(string search);
        Book FindById(int id);
        bool Edit(int id, CreateBookViewModel book);
        bool Remove(int id);
    }
}
