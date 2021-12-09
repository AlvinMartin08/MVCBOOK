using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBOOK.Models;

namespace MVCBOOK.Controllers
{
    public class BookController : Controller
    {
        BookService ps = new BookService();
        // GET: Book
        public ActionResult Index()
        {
            List<BookViewModel> pvm = new List<BookViewModel>();
            BookViewModel bk = null;
            foreach (Book p in ps.All())
            {
                bk = new BookViewModel();
                bk.BookId = p.BookId;
                bk.BookName = p.BookName;
                bk.BookAuthor = p.BookAuthor;
                bk.BookPrice = p.BookPrice;
                pvm.Add(bk);
            }
            return View(pvm);
        }

        public ActionResult AddNewBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBook(CreateBookViewModel book)
        {
            if (ModelState.IsValid)
            {
                Book p = ps.Add(book);
                if (p != null)
                    return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            Book pd = ps.FindById(id);
            return View(pd);
        }

        public ActionResult Delete(int id)
        {
            bool chk = ps.Remove(id);
            if (chk == true)
                return RedirectToAction("Index");
            return View();
        }

        public ActionResult SearchBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchBook(FormCollection f)
        {
            string str = f["txtSearch"].ToString();
            List<Book> lstBook = ps.Search(str);
            return View(lstBook);
        }

        public ActionResult Modify(int id)
        {
            Book pd = ps.FindById(id);
            CreateBookViewModel cp = new CreateBookViewModel();
            cp.BookId = pd.BookId;
            cp.BookName = pd.BookName;
            cp.BookAuthor = pd.BookAuthor;
            cp.BookPrice = pd.BookPrice;
            return View(cp);
        }
        [HttpPost]
        public ActionResult Modify(CreateBookViewModel cpv)
        {
            bool chk = ps.Edit(cpv.BookId, cpv);
            if (chk == true)
                return RedirectToAction("Index");
            return View();
        }
    }
}