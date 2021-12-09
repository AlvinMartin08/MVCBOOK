using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBOOK.Models
{
    public class InMemoryBookRepo : IBookRepo
    {

        private static List<Book> listBook = new List<Book> {
            new Book{ BookId=101, BookName="The Guard", BookAuthor="Thomas Partey", BookPrice=7050},
            new Book{ BookId=102, BookName="Balarama", BookAuthor="Malayala Manorama", BookPrice=15},
            new Book{ BookId=103, BookName="The Wings Of Fire", BookAuthor="A.P.J Abdul Kalam", BookPrice=3050},
            new Book{ BookId=104, BookName="Half Girlfriend", BookAuthor="Chetan Bhagat", BookPrice=850},
        };
        

        public Book Create(Book book)
        {
            listBook.Add(book);
            return book;
        }

        public bool Delete(Book book)
        {
            bool chk = false;
            foreach (Book p in listBook)
            {
                if (p.BookId == book.BookId)
                {
                    listBook.Remove(book);
                    chk = true;
                    break;
                }
            }
            return chk;
        }

        public List<Book> Read()
        {
            return listBook;
        }

        public Book Read(int id)
        {
            Book bk = null;
            foreach (Book p in listBook)
            {
                if (p.BookId == id)
                {
                    bk = new Book();
                    bk = p;
                    break;
                }
            }
            return bk;
        }

        public bool Update(Book book)
        {
            bool chk = false;
            foreach (Book p in listBook)
            {
                if (p.BookId == book.BookId)
                {
                    p.BookId = book.BookId;
                    p.BookName = book.BookName;
                    p.BookAuthor = book.BookAuthor;
                    p.BookPrice =book.BookPrice;
                    chk = true;
                    break;
                }
            }
            return chk;
        }
    }
}