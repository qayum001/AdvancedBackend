using Auth.Data.Additional;
using Auth.Data.Enums;
using Microsoft.AspNetCore.Identity;

namespace Auth.Data.EfClasses
{
    public class Customer : User
    {
        //address might has own class with properties as city, street, home etc
        public string Address { get; private set; }

        public Customer(string fullName,
            DateTime birthDate,
            Gender gender, 
            string phone, 
            string email,
            string address,
            string password)
            : base(Guid.NewGuid(), fullName, birthDate, gender, phone, email, password, new Role(nameof(Customer)))
        {
            Address = address; 
        }

        public Task UpdateAddress(string address)
        {
            Address = address;
            return Task.CompletedTask;
        }
    }
}
