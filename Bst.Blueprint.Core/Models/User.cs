using System;
using System.Collections.Generic;

namespace Bst.Blueprint.Core.Models
{
    public class User : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public ICollection<UserTenant> Tenants { get; private set; }

        public static User Create(string firstName, string lastName, string email, string password)
        {
            EnsureRequiredFieledsAreValid(firstName, lastName, email, password);

            return new User { FirstName = firstName,
                              LastName = lastName,
                              Email = email,
                              Password = BCrypt.Net.BCrypt.HashPassword($"{firstName}123!") };
        }

        public void ChangePassword(string newPassword)
        {
            Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
        }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Password);
        }

        private static void EnsureRequiredFieledsAreValid(string firstName, string lastName, string email, string password)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException(nameof(FirstName));

            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException(nameof(LastName));

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(Email));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(Password));
        }
    }
}
