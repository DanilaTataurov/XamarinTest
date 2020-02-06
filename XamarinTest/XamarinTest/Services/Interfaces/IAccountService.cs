using System.Threading.Tasks;
using XamarinTest.Services.Models;

namespace XamarinTest.Services.Interfaces {
    public interface IAccountService {
        Task<ServiceResult> RegisterAsync(string username, string password);
        Task<ServiceResult> LoginAsync(string userName, string password);
        Task<ServiceResult> LogoutAsync();
        Task<ServiceResult> CheckEmailAsync(string email);
    }
}
