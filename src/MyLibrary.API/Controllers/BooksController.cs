using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Application.DTOs;
using MyLibrary.Application.Services;

namespace MyLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BookService bookService = new BookService();

        [HttpPost]
        public IActionResult AddBook([FromBody] BookDTO bookDto)
        {
            var book = bookService.AddBook(bookDto);
            return Ok(book);
        }

        [HttpGet]
        public IActionResult GetBooks([FromQuery] string? title, [FromQuery] string? author)
        {
            var books = bookService.GetBooks(title, author);
            return Ok(books);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(Guid id, [FromBody] BookDTO bookDto)
        {
            var book = bookService.UpdateBook(id, bookDto);

            if (book == null)
            {
                return NotFound("No se encontró el libro.");
            }

            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(Guid id)
        {
            var deleted = bookService.DeleteBook(id);

            if (!deleted)
            {
                return NotFound("No se encontró el libro.");
            }

            return Ok("Se elimino el libro de manera correcta.");
        }




    }
}
