using Auth.Data.Additional;
using Auth.Services.AccauntService.DTOs;

namespace Auth.Services.AccauntService
{
    public interface IAccountService
    {
        Task<Response> Update(AccountUpdateDto accountUpdateDto, string token);
        Task<Response> Delete(string token);
    }
}
