using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiStart.Model;

namespace WebApiStart
{
    public interface IBookService
    {
        List<Book> GetBooks();
        Book GetBookByName(string name);
        bool AddBook(Book book);
        bool DeleteBook(string name);
        bool UpdateBook(string name, Book book);
    }
}
