using System;
using System.Collections.Generic;
using BackEndTest.Interface;

namespace BackEndTest.Business
{
    public class TestViewModel : ITestViewModel
    {
        public void Dispose()
        {
            // Clean up
        }

        public List<User> GetUsers()
        {
            try
            {
                // call the data layer to get the users from the database
                return default;
            }
            catch (Exception ex)
            {
                // Log exception
                return default;
            }
        }

        public User SaveUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
