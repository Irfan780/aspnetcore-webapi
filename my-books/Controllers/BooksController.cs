using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BookService _bookService;
        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooKs()
        {
            var allBooks = _bookService.GetAllBooks();
            return Ok(allBooks);
        }
        [HttpGet("book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            return Ok(book);
        }


        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BooKVM book)
        {
            _bookService.AddBook(book);
            return Ok();

        }
        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id,[FromBody]BooKVM book )
        {
            var updatebook = _bookService.UpdateBookbyId(id, book);
            return Ok(updatebook);
        }
        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult BookDeleteById(int id)
        {
            _bookService.DelettBookById(id);
            return Ok();
        }
    }
}
