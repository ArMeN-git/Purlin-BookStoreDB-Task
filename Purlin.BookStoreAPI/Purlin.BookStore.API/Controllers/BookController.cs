using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Purlin.BookStore.BLL.Interfaces;
using Purlin.BookStore.DAL.Interfaces;
using Purlin.BookStore.DAL.Models;
using System.Web.Http.Results;

namespace Purlin.BookStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet, Route("getallbooks")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            try
            {
                var books = await _bookService.GetAllBooksAsync();
                return Ok(books);
            }
            catch (Exception)
            {
                // log the error
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet, Route("getbookbyid/{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            try
            {
                if (id < 0)
                    return BadRequest("Book Id can't be negative");

                var book = await _bookService.GetBookByIdAsync(id);

                if (book == null)
                {
                    return NotFound();
                }

                return Ok(book);
            }
            catch (Exception)
            {
                // log the error
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost, Route("addbook")]
        public async Task<IActionResult> CreateBook(Book book)
        {
            try
            {
                await _bookService.AddBookAsync(book);
                return CreatedAtAction(nameof(GetBook), new { id = book.BookId }, book);
            }
            catch (Exception ex)
            {
                // log the error
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut, Route("updatebook")]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            try
            {
                var existingBook = _bookService.GetBookByIdAsync(book.BookId);

                if (existingBook == null)
                {
                    return BadRequest("record doesn't exist");
                }

                await _bookService.UpdateBookAsync(book);
                return Ok();
            }
            catch (Exception ex)
            {
                // log the error
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete, Route("deletebook/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var book = await _bookService.GetBookByIdAsync(id);

                if (book == null)
                {
                    return NotFound();
                }

                await _bookService.DeleteBookAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                // log the error
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
