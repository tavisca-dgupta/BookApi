using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStart.Model
{
    public class BookModel
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool OnSale { get; set; }
    }
}
