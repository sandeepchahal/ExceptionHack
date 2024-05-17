namespace SolidPrinciples.Models;

public class Dvd:ICheckout
{
    public string Title { get;}
    public bool IsAvailable { get;}

    public Dvd(string title)
    {
        Title = title;
        IsAvailable = true;
    }
}