using System;
using System.Collections.Generic;
using BackEndTest.Interface;

namespace BackEndTest.Business
{
    public interface ITestViewModel : IDisposable
    {
        List<User> GetUsers();
        bool UserExists(int userId);
        User SaveUser(User user);
    }
}
