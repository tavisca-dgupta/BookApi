using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiStart.Model;

namespace WebApiStart.Database
{
    public class BookDb
    {
        private static List<Book> _bookList = new List<Book>
        {
            new Book(1,"abc","xyz",10),
            new Book(2,"","",120)
        };
        private static int id=3;
        public List<Book> GetBooks()
        {
            return _bookList;
        }

        public bool AddBook(Book book)
        {
            id++;
            book.Id = id;
            _bookList.Add(book);
            return true;
        }
        public bool UpdateBook(string name,Book book)
        {
            if(_bookList.IndexOf(_bookList.Where(b => b.Name == name).First()) == -1)
            {
                return false;
            }
            _bookList[_bookList.IndexOf(_bookList.Where(b => b.Name == name).First())] = book;
           // _bookList[_bookList.IndexOf(_bookList.Where(b => b.Name == name).First())].Price = book.Price;
           // _bookList[_bookList.IndexOf(_bookList.Where(b => b.Name == name).First())].Name = book.Name;
            return true;
        }
        public bool DeleteBook(string name)
        {
            _bookList.RemoveAt(_bookList.IndexOf(_bookList.Where(b => b.Name == name).First()));
            return true;
        }

    }
}
