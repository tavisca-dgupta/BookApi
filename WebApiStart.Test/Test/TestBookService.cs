using System;
using System.Collections.Generic;
using WebApiStart.Errors;
using WebApiStart.Model;
using WebApiStart.View;
using Xunit;

namespace WebApiStart.Test
{
    public class TestBookService
    {
        [Fact]
        public void Add_a_Book()
        {
            Book book = new Book(4, "The Stranger", "Albert Camus", 300);
            BookService bookService = new BookService();
            BookResponseModel response = bookService.AddBook(book);
            Assert.Equal(1,response.Status);
            bookService.DeleteBook(book.Name);
        }
        [Fact]
        public void Delete_A_Book()
        {
            Book book = new Book(4, "The Decameron", "Giovanni Boccaccio", 300);
            BookService bookService = new BookService();
            bookService.AddBook(book);
            BookResponseModel response = bookService.DeleteBook(book.Name);
            List<Book> books = bookService.GetBooks();
            Assert.DoesNotContain(book, bookService.GetBooks());

        }

        [Fact]
        public void Get_a_Book_By_Name()
        {
            Book book = new Book(0, "Samuel Beckett", "Molloy", 300);
            BookService bookService = new BookService();
            bookService.AddBook(book);
            Assert.Equal(book.Name, bookService.GetBookByName(book.Name).Book.Name);
            bookService.DeleteBook(book.Name);

        }

        [Fact]
        public void Update_a_Book_Data_By_Searching_the_Book_By_Name()
        {
            Book book = new Book(4,"Old Norse", "Unknown", 300);
            Book newbook = new Book(4,"Old Norse", "Abc", 500);
            BookService bookService = new BookService();
            bookService.AddBook(book);
            bookService.UpdateBook(book.Name, newbook);
            Assert.Equal(500, bookService.GetBookByName(newbook.Name).Book.Price);
            bookService.DeleteBook(newbook.Name);

        }

        [Fact]
        public void Get_a_Book_By_Name_Which_Is_Not_Present_In_File()
        {
            List<ErrorModel> error = new List<ErrorModel>();
            BookService bookService = new BookService();
            BookResponseModel response = new BookResponseModel();
            response.errorList.Add(new ErrorModel(103, "Name you are Looking for is not present"));
            Assert.Equal(response.errorList[0].Message, bookService.GetBookByName("abc").errorList[0].Message);
        }
        
        [Fact]
        public void Delete_a_Book_By_Name_which_Is_Not_Present_In_File()
        {
            List<ErrorModel> error = new List<ErrorModel>();
            BookService bookService = new BookService();
            BookResponseModel response = new BookResponseModel();
            response.errorList.Add(new ErrorModel(103, "Name you are Looking for is not present"));
            Assert.Equal(response.errorList[0].Message, bookService.DeleteBook("abc").errorList[0].Message);
        }

        [Fact]
        public void Add_a_Book_With_Incorrect_Name_Of_Book()
        {
            Book book = new Book(4, "Incorrect123", "Unknown", 300);
            BookService bookService = new BookService();
            BookResponseModel bookResponse= bookService.AddBook(book);
            List<ErrorModel> errors = new List<ErrorModel>
            {
                new ErrorModel(104, "Invalid Name: Name should not contain digits")
            };
            Assert.Equal(errors[0].Message, bookResponse.errorList[0].Message);

        }
        [Fact]
        public void Add_a_Book_with_Incorrect_Author_and_Price()
        {
            Book book = new Book(4, "Incorrect", "Unknown123", -300);
            BookService bookService = new BookService();
            BookResponseModel bookResponse = bookService.AddBook(book);
            List<ErrorModel> errors = new List<ErrorModel>
            {
                new ErrorModel(105, "Invalid Author: Author should not contain digits"),
                new ErrorModel(102, "price Cannot be Negative")
            };
            Assert.Equal(errors[0].Code+errors[1].Code, bookResponse.errorList[0].Code+bookResponse.errorList[1].Code);
        }

        [Fact]
        public void Update_a_Book_with_Incorrect_Author_and_Price()
        {
            Book book = new Book(4, "TestBook", "Unknown",300);
            Book newBook = new Book(4, "TestBook", "Unknown123",-300);
            BookService bookService = new BookService();
            bookService.AddBook(book);
            BookResponseModel bookResponse = bookService.UpdateBook(book.Name, newBook);
            List <ErrorModel> errors = new List<ErrorModel>
            {
                new ErrorModel(105, "Invalid Author: Author should not contain digits"),
                new ErrorModel(102, "price Cannot be Negative")
            };
            Assert.Equal(errors[0].Code + errors[1].Code, bookResponse.errorList[0].Code + bookResponse.errorList[1].Code);
            bookService.DeleteBook(book.Name);
        }


    }
}
