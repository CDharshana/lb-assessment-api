using LoanApplication.Data;
using LoanApplication.Models;
using System.Threading.Tasks;

namespace LoanApplication.Services
{
    public interface IAuthService
    {
        Task<TokenModel> Login(ApplicationUser user, LoginModel model);
        Task<Response> Register(RegisterModel model);
        Task<Response> RegisterAdmin(RegisterModel model);
    }
}