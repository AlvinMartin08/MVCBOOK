using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBOOK.Models
{
    public class BookService : IBookService
    {
        InMemoryBookRepo inMemoryBook = new InMemoryBookRepo();

        public Book Add(CreateBookViewModel book)
        {
            Book bk = new Book();
            bk.BookId = book.BookId;
            bk.BookName = book.BookName;
            bk.BookAuthor = book.BookAuthor;
            bk.BookPrice = book.BookPrice;

            return inMemoryBook.Create(bk);
        }

        public List<Book> All()
        {
            return inMemoryBook.Read();
        }

        public bool Edit(int id, CreateBookViewModel book)
        {
            Book bk = new Book();
            bk.BookId = book.BookId;
            bk.BookName = book.BookName;
            bk.BookAuthor = book.BookAuthor;
            bk.BookPrice = book.BookPrice;

            bool chk = inMemoryBook.Update(bk);
            return chk;
        }

        public Book FindById(int id)
        {
            return inMemoryBook.Read(id);
        }

        public bool Remove(int id)
        {
            Book p = FindById(id);
            bool chk = inMemoryBook.Delete(p);
            return chk;
        }

        public List<Book> Search(string search)
        {
            List<Book> lstSearchresults = new List<Book>();
            foreach (Book p in inMemoryBook.Read())
            {
                if (p.BookName.Contains(search) || p.BookAuthor.Contains(search))
                    lstSearchresults.Add(p);
            }
            return lstSearchresults;
        }
    }
}