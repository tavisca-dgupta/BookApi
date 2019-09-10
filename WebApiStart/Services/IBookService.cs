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
        BookResponseModel GetBookByName(string name);
        BookResponseModel AddBook(Book book);
        BookResponseModel DeleteBook(string name);
        BookResponseModel UpdateBook(string name, Book book);
    }
}
