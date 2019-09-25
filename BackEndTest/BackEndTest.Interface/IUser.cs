using System;
namespace BackEndTest.Interface
{
    public interface IUser
    {
        string FirstName { get; }
        string LastName { get; }
        int Age { get; }
        string ColorPreference { get; }
    }
}
