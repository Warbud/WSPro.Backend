using System.Threading.Tasks;
using WSPro.Backend.Application.Dto;

namespace WSPro.Backend.Application.Interfaces
{
    public interface IUserService
    {
        Task<LoginPayload> Login(LoginInput input);
        Task<T> GetMe<T>();
        Task<UserPayload> GetUser(UserInput input);
        Task<RegisterPayload> Register(RegisterInput input);
    }
}