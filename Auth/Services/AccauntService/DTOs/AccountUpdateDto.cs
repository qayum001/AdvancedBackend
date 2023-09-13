using Auth.Data.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Auth.Services.AccauntService.DTOs
{
    public class AccountUpdateDto
    {
        public string FullName { get; } = string.Empty;
        public DateTime BirthDate { get; }
        public Gender Gender { get; }
        public string Address { get; } = string.Empty;

    }
}
