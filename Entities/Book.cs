namespace Desafio_Rocketeat_Bookstore.Entities;

public class Book
{
    public Guid Id;
    public String Title = string.Empty;
    public String Author = string.Empty;
    public BookGenre Genre;
    public double Price;
    public int Stock;
}