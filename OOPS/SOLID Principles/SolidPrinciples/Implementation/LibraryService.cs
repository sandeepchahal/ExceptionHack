using SolidPrinciples.Models;

namespace SolidPrinciples.Implementation;

public class LibraryService : ILibraryService
{
    private readonly IAuthenticationService _authentication;

    public LibraryService(IAuthenticationService service)
    {
        _authentication = service;
    }

    public void ProcessCheckout(ICheckout book, Student student)
    {
        if (_authentication.IsValid(student: student))
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

    public void ProcessReturn(ICheckout book)
    {
        Console.WriteLine("Book is returned successfully");
    }
}