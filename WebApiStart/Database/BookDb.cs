using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApiStart.Model;

namespace WebApiStart.Database
{
    public class BookDb
    {
        private static List<Book> _bookList = new List<Book>();
        
        public BookDb()
        {
            using (StreamReader r = new StreamReader("DbFiles/book.json"))
            {
                string json = r.ReadToEnd();
                _bookList = JsonConvert.DeserializeObject<List<Book>>(json);
            }
        }
        
        public List<Book> GetBooks()
        {
            return _bookList;
        }

        public Book AddBook(Book book)
        {
            //id++;
            //book.Id = id;
            int idCount = _bookList.Count();
            book.Id = ++idCount;
            string convertedJson;
            using (StreamReader r = new StreamReader("DbFiles/book.json"))
            {
                string json = r.ReadToEnd();
                _bookList = JsonConvert.DeserializeObject<List<Book>>(json);
                _bookList.Add(book);
                convertedJson = JsonConvert.SerializeObject(_bookList, Formatting.Indented);

            }
            File.WriteAllText("DbFiles/book.json", convertedJson);

            return book;

        }
        public bool UpdateBook(string name,Book book)
        {
            if (!(IsElementPresent(name)))
            {
                return false;
            }
            _bookList[_bookList.IndexOf(_bookList.Where(b => b.Name == name).First())].Author = book.Author;
            _bookList[_bookList.IndexOf(_bookList.Where(b => b.Name == name).First())].Price = book.Price;
            _bookList[_bookList.IndexOf(_bookList.Where(b => b.Name == name).First())].Name = book.Name;
            string convertedJson = JsonConvert.SerializeObject(_bookList, Formatting.Indented);
            File.WriteAllText("DbFiles/book.json", convertedJson);
            return true;
        }
        public bool DeleteBook(string name)
        {
            if (!(IsElementPresent(name)))
            {
                return false;
            }
            _bookList.RemoveAt(_bookList.IndexOf(_bookList.Where(b => b.Name == name).First()));
            string convertedJson = JsonConvert.SerializeObject(_bookList, Formatting.Indented);
            File.WriteAllText("DbFiles/book.json", convertedJson);
            return true;
        }

        public bool IsElementPresent(string name)
        {
            foreach(Book book in _bookList)
            {
                if(book.Name==name)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
