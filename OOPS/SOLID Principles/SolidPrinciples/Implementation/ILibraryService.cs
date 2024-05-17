using SolidPrinciples.Models;

namespace SolidPrinciples.Implementation;

public interface ILibraryService
{
    void ProcessCheckout(ICheckout item, Student student);
    void ProcessReturn(ICheckout book);
}