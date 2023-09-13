using Auth.Data.Additional;
using Auth.Data.Enums;

namespace Auth.Data.EfClasses
{
    public class Manager : User
    {
        public Manager(string fullName,
            DateTime birthDate,
            Gender gender,
            string phone,
            string email,
            string password)
            : base(Guid.NewGuid(), fullName, birthDate, gender, phone, email, password, new Role(nameof(Manager)))
        {
        }
    }
}