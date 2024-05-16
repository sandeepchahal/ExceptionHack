using SolidPrinciples.Models;

namespace SolidPrinciples.Implementation;

public class AuthenticationService
{
    public bool IsAStudent(Student student)
    {
        return student.UserName == "user" && student.Password == "password";
    }
}
