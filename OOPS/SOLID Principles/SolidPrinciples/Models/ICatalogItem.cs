namespace SolidPrinciples.Models;

public interface ICatalogItem
{
    public string Title { get;}
    public bool IsAvailable { get;}
    
    public bool IsCheckAllowed { get; set; }

}