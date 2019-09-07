using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
                BookResponseModel bookResponse = _book.GetBookByName(name);
                if (bookResponse.errorList.Count > 0)
                    return BadRequest(bookResponse.errorList);
                return Ok(bookResponse.Book);
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
                BookResponseModel bookResponse = _book.AddBook(book);
                if(bookResponse.Status==1)
                    return Ok();
                return BadRequest(bookResponse.errorList);
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
                BookResponseModel bookResponse = _book.UpdateBook(name, book);
                if (bookResponse.Status == 1)
                    return Ok();
                else
                    return BadRequest(bookResponse.errorList);
               
            }
            catch(Exception e)
            {
                return NotFound(e);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{name}")]
        public ActionResult Delete(string name)
        {
            try
            {
                BookResponseModel bookResponse= _book.DeleteBook(name);
                if (bookResponse.Status == 1)
                    return Ok();
                return BadRequest(bookResponse.errorList);
            }
            catch(Exception e)
            {
                return NotFound(e);
            }
        }
    }
}
