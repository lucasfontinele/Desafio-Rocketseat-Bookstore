using Desafio_Rocketeat_Bookstore.Communication.Requests;
using Desafio_Rocketeat_Bookstore.Data;
using Desafio_Rocketeat_Bookstore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Rocketeat_Bookstore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public IActionResult GetBooks()
    {
        return Ok(BookStore.Books);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] RequestRegisterBookJson request)
    {
        var book = new Book
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Genre = request.Genre,
            Price = request.Price,
            Stock = request.Stock,
            Author = request.Author,
        };

        BookStore.Books.Add(book);

        return Created(string.Empty, book);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var book = BookStore.Books.Find(x => x.Id == id);

        if (book is null)
        {
            return NotFound("Book not found");
        }

        BookStore.Books.Remove(book);
        
        return NoContent();
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] Guid id, [FromBody] RequestUpdateBookJson request)
    {
        var book = BookStore.Books.Find(x => x.Id == id);

        if (book is null)
        {
            return NotFound("Book not found");
        }

        if (request.Title != null)
        {
            book.Title = request.Title;
        }
        if (request.Author != null)
        {
            book.Author = request.Author;
        }
        
        if (request.Price != null)
        {
            book.Price = request.Price.Value;
        }
        if (request.Stock != null)
        {
            book.Stock = request.Stock.Value;
        }
        
        book.Genre = request.Genre;

        var index = BookStore.Books.IndexOf(book);
        BookStore.Books[index] = book;

        return NoContent();
    }
}
