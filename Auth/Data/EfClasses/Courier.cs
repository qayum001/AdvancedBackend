using Auth.Data.Additional;
using Auth.Data.Enums;

namespace Auth.Data.EfClasses
{
    public class Courier : User
    {
        public Courier(string fullName,
            DateTime birthDate,
            Gender gender,
            string phone,
            string email,
            string password) 
            : base(Guid.NewGuid(), fullName, birthDate, gender, phone, email, password, new Role("Courier"))
        {
        }
    }
}
