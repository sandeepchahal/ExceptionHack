using SolidPrinciples.Models;

namespace SolidPrinciples.Implementation;

public class LibraryService: ILibraryService
{
    private readonly AuthenticationService _authentication;
    public LibraryService(AuthenticationService service)
    {
        _authentication = service;
    }
    public void ProcessCheckout(ICatalogItem book, Student student)
    {
        if (book.IsCheckAllowed)
        {
            if (_authentication.IsAStudent(student: student))
            {
                Console.WriteLine(book.IsAvailable
                    ? $"{book.Title} is checked out successfully!"
                    : $"{book.Title} is not available");
            }
            else
            {
                Console.WriteLine("User is not student");
            }
        } 
    }
    public void ProcessReturn(ICatalogItem book)
    {
      Console.WriteLine("Book is returned successfully");
    }

}