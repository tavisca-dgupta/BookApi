using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStart.Model
{
    public class Book
    {
        public Book(int id,string name,string author,int price)
        {
            Id = id;
            Name = name;
            Price = price;
            Author = author;
        }
        public string Name { get;  set; }
        public string Author { get;  set; }
        [JsonIgnore]
        public int Id { get;  set; }
        public int Price { get;  set; }
        
    }
}
