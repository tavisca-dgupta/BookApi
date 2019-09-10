using AutoMapper;
using FluentValidation.Results;
using NLog;
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
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Book, BookModel>();

            //});
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
            RequestValidator validator = new RequestValidator();
            ValidationResult result = validator.Validate(book);
            if(result.Errors.Count == 0)
            {
                response.Status = 1;
                response.Book = dbbook.AddBook(book);
            }
            else
            {
                response.result = result;
            }
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
            RequestValidator validator = new RequestValidator();
            ValidationResult result = validator.Validate(book);
            if (result.Errors.Count == 0)
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
            {
                response.result = result;
            }
            return response;

        }

    }
}
