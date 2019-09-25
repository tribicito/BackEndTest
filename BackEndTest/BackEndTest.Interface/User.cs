using System;
namespace BackEndTest.Interface
{
    public class User : IUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string ColorPreference { get; set; }
    }
}
