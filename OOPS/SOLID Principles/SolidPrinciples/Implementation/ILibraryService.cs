using SolidPrinciples.Models;

namespace SolidPrinciples.Implementation;

public interface ILibraryService
{
    void ProcessCheckout(ICatalogItem item, Student student);
    void ProcessReturn(ICatalogItem book);
}