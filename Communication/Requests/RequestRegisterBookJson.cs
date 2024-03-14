using Desafio_Rocketeat_Bookstore.Entities;

namespace Desafio_Rocketeat_Bookstore.Communication.Requests;

public class RequestRegisterBookJson
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public BookGenre Genre { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
}