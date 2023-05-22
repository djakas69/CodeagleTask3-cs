using Csharp_Task_3.Models;
using Csharp_Task_3.Models.Dto;

namespace Csharp_Task_3.Repository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO);

    }
}
