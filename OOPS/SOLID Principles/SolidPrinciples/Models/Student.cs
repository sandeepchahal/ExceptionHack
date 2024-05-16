namespace SolidPrinciples.Models;

public class Student
{
    public string UserName { get;  }
    public string Password { get;  }

    public Student(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
}