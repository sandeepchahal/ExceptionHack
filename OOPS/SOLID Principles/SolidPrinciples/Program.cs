using SolidPrinciples.Implementation;
using SolidPrinciples.Models;

Book book = new Book("How to kill a Mocking bird");

Dvd dvd = new Dvd("C# programming");

ReferenceBook referenceBook = new ReferenceBook("Refer-1");

Student student = new Student("user1", "password1");
AuthenticationService authenticationService = new AuthenticationService();
ILibraryService libraryService = new LibraryService(authenticationService);
libraryService.ProcessCheckout( book, student);
Console.Read();

