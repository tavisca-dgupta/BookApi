using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiStart.Model;
using WebApiStart.View;

namespace WebApiStart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private BookService _book = new BookService();
        // GET: api/Books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return Ok(_book.GetBooks());
        }

        // GET: api/Books/5
        [HttpGet("{name}", Name = "Get")]
        public ActionResult<Book> Get(string name)
        {
            try
            {
                return Ok(_book.GetBookByName(name));
            }
            catch
            {
                return NotFound();
            }
        }

        // POST: api/Books
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            try
            {
                if(_book.AddBook(book))
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT: api/Books/5
        [HttpPut("{name}")]
        public ActionResult<Book> Put(string name, [FromBody] Book book)
        {
            try
            {
                if (_book.UpdateBook(name, book))
                {
                    return Ok(_book.UpdateBook(name, book));
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return NotFound();
            }
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string name)
        {
            try
            {
                return Ok(_book.DeleteBook(name));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
