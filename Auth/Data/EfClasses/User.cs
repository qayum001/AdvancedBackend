using Auth.Data.Additional;
using Auth.Data.Enums;
using Microsoft.Identity.Client;

namespace Auth.Data.EfClasses
{
    public class User
    {
        public Guid Id { get; }
        public string FullName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Gender Gender { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public bool IsBanned { get; private set; }
        
        //refresh token properties
        public string RefreshToken { get; private set; } = string.Empty;
        public DateTime ExpiriesDate {  get; private set; }

        private User() { }

        public User(Guid id,
            string fullName,
            DateTime birthDate,
            Gender gender,
            string phone,
            string email,
            string password,
            Role role)
        {
            Id = id;
            FullName = fullName;
            BirthDate = birthDate;
            Gender = gender;
            Phone = phone;
            Email = email;
            Password = password;
            Role = role.Name;
            IsBanned = false;
        }

        public Task BanUser()
        {
            IsBanned = true;
            return Task.CompletedTask;
        }
        public Task UnBanUser()
        {
            IsBanned = false;
            return Task.CompletedTask;
        }
        public Task UpdateRefreshToken(string token)
        {
            RefreshToken = token;
            return Task.CompletedTask;
        }
        public Task UpdateExpiryingsDate(DateTime dateTime)
        {
            ExpiriesDate = dateTime;
            return Task.CompletedTask;
        }
        public Task ReName(string name)
        {
            FullName = name;
            return Task.CompletedTask;
        }
        public Task UpdeteBirthDate(DateTime birthDate)
        {
            BirthDate = birthDate;
            return Task.CompletedTask;
        }
        public Task UpdateGender(Gender gender)
        {
            Gender = gender;
            return Task.CompletedTask;
        }
        public Task UpdatePhone(string phone)
        {
            Phone = phone;
            return Task.CompletedTask;
        }
        public Task UpdateEmail(string email)
        {
            Email = email;
            return Task.CompletedTask;
        }
        public Task UpdatePasswordl(string password)
        {
            Password = password;
            return Task.CompletedTask;
        }
    }
}