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
}
