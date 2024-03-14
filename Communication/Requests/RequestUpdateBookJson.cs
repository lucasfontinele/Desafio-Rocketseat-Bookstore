using Desafio_Rocketeat_Bookstore.Entities;

namespace Desafio_Rocketeat_Bookstore.Communication.Requests;

public class RequestUpdateBookJson
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public BookGenre Genre { get; set; }
    public double? Price { get; set; }
    public int? Stock { get; set; }
}