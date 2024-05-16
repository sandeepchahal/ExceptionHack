namespace SolidPrinciples.Models;

public class Book:ICatalogItem
{
    public string Title { get;}
    public bool IsAvailable { get;}
    public bool IsCheckAllowed { get; set; }

    public Book(string title)
    {
        Title = title;
        IsAvailable = true;
        IsCheckAllowed = true;
    }
    
}

public class ReferenceBook : Book
{
    public ReferenceBook(string title) : base(title)
    {
        IsCheckAllowed = false;
    }
}