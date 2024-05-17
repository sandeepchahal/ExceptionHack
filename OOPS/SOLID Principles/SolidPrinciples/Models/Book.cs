namespace SolidPrinciples.Models;

public class Book:ICheckout
{
    public string Title { get;}
    public bool IsAvailable { get;}

    public Book(string title)
    {
        Title = title;
        IsAvailable = true;
    }
    
}

public class ReferenceBook : INonCheckout
{
    public ReferenceBook(string title)
    {
        Title = title;
        IsAssigned = true;
    }

    public string Title { get; }
    public bool IsAssigned { get; }
}