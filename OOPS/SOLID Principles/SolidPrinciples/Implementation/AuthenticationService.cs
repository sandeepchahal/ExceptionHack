using SolidPrinciples.Models;

namespace SolidPrinciples.Implementation;

public class StudentAuthenticationService:IAuthenticationService
{
    public bool IsValid(Student student)
    {
        return student.UserName == "user" && student.Password == "password";
    }
}

public class UserAuthenticationService:IAuthenticationService
{
    public bool IsValid(Student student)
    {
        return student.UserName == "user1" && student.Password == "password1";
    }
}


public interface IAuthenticationService
{
    public bool IsValid(Student student);
}
