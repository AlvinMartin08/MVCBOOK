using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBOOK.Models
{
    public interface IBookRepo
    {
        Book Create(Book book);
        List<Book> Read();
        Book Read(int id);
        bool Update(Book book);
        bool Delete(Book book);
    }
}
