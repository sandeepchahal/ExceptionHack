namespace SolidPrinciples.Models;

public class Dvd:ICatalogItem
{
    public string Title { get;}
    public bool IsAvailable { get;}
    public bool IsCheckAllowed { get; set; }

    public Dvd(string title)
    {
        Title = title;
        IsAvailable = true;
        IsCheckAllowed = true;
    }
}