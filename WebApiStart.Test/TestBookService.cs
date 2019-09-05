using System;
using System.Collections.Generic;
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
            Book book = new Book(4, "Old Norse", "Unknown", 300);
            BookService bookService = new BookService();
            bookService.AddBook(book);
            Assert.Equal(book.Price,bookService.GetBookByName(book.Name).Price);
        }

        [Fact]
        public void Delete_A_Book()
        {
            Book book = new Book(4, "Old Norse", "Unknown", 300);
            BookService bookService = new BookService();
            bookService.AddBook(book);
            bookService.DeleteBook(book.Name);
            List<Book> books = bookService.GetBooks();
            Assert.DoesNotContain(book, bookService.GetBooks());
        }

        [Fact]
        public void Get_a_Book_By_Name()
        {
            Book book = new Book(4, "Old Norse", "Unknown", 300);
            BookService bookService = new BookService();
            bookService.AddBook(book);
            Assert.Equal(book, bookService.GetBookByName(book.Name));
        }

        [Fact]
        public void Update_a_Book_Data_By_Searching_the_Book_By_Name()
        {
            Book book = new Book(4, "Old Norse", "Unknown", 300);
            Book newbook = new Book(4, "Old_Norse", "Abc", 500);
            BookService bookService = new BookService();
            bookService.AddBook(book);
            bookService.UpdateBook(book.Name, newbook);
            Assert.Contains(newbook, bookService.GetBooks());

        }
    }
}
