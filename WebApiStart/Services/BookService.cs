using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiStart.Database;
using WebApiStart.Errors;

using WebApiStart.Model;

namespace WebApiStart.View
{
    public class BookService:IBookService
    {
        private static List<Book> bookList=new List<Book>();
        private BookResponseModel response = new BookResponseModel();
        BookDb dbbook = new BookDb();
        private Errors.Errors errors = new Errors.Errors();
        public List<Book> GetBooks()
        {
            bookList = dbbook.GetBooks();
            return bookList;
        }

        public BookResponseModel GetBookByName(string name)
        {

            bookList = dbbook.GetBooks();
            try
            {
                response.Book = bookList[bookList.IndexOf(bookList.Where(b => b.Name == name).First())];
            }
            catch
            {
                response.errorList.Add(errors.GetError("NameNotFound"));
            }
            return response;

        }
        public BookResponseModel AddBook(Book book)
        {
            if (IsAValidName(book.Name) && IsAValidName(book.Author) && book.Price > 0)
            {
                if (dbbook.AddBook(book))
                {
                    response.Status = 1;
                    response.Book = book;
                }
            }
            else
                response.errorList=GetErrorList(book,response.errorList);
            return response;
        }

        public BookResponseModel DeleteBook(string name)
        {

            if(dbbook.DeleteBook(name))
            {
                response.Status = 1;
            }
            else
                response.errorList.Add(errors.GetError("NameNotFound"));
            return response;

        }

        public BookResponseModel UpdateBook(string name,Book book)
        {
            if (IsAValidName(book.Name) && IsAValidName(book.Author) && book.Price > 0)
            {
                if (dbbook.UpdateBook(name, book))
                {
                    response.Status = 1;
                    response.Book = book;
                }
                else
                    response.errorList.Add(errors.GetError("NameNotFound"));
            }
            else
                response.errorList = GetErrorList(book,response.errorList);
            return response;

        }

        public bool IsAValidName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;
           foreach(char n in name)
            {
                if (char.IsDigit(n))
                    return false;
            }
            return true;
           
        }

        public List<ErrorModel> GetErrorList(Book book, List<ErrorModel> errorList)
        {
            if (!(IsAValidName(book.Name)))
                errorList.Add(errors.GetError("InvalidName"));
            if (!(IsAValidName(book.Author)))
                errorList.Add(errors.GetError("InvalidAuthorName"));
            if (book.Price <= 0)
                errorList.Add(errors.GetError("PriceCannotBeNegetive"));

            return errorList;
        }
    }
}
