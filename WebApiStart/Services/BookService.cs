using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiStart.Database;
using WebApiStart.Model;

namespace WebApiStart.View
{
    public class BookService:IBookService
    {
        private static List<Book> bookList=new List<Book>();
        BookDb dbbook = new BookDb();
        public List<Book> GetBooks()
        {
            bookList = dbbook.GetBooks();
            return bookList;
        }

        public Book GetBookByName(string name)
        {
            bookList = dbbook.GetBooks();
            return bookList[bookList.IndexOf(bookList.Where(b => b.Name == name).First())];
        }
        public bool AddBook(Book book)
        {
            if(!(book.Name.All(char.IsDigit))&&!(string.IsNullOrEmpty(book.Name)))
            {
                return dbbook.AddBook(book);
            }
            else
            {
                throw new NameCannotBeAddedException(); 
            }
        }

        public bool DeleteBook(string name)
        {
            return dbbook.DeleteBook(name);
        }

        public bool UpdateBook(string name,Book book)
        {
            //if (!(book.Name.All(char.IsDigit)) && !(string.IsNullOrEmpty(book.Name)))
            //{
            //    return dbbook.UpdateBook(name, book);
            //}
            //else
            //{
            //    throw new NameCannotBeAddedException();
            //}
            return dbbook.UpdateBook(name, book);
        }
    }
}
