using Csharp_Task_3.Data;
using Csharp_Task_3.Models;
using Csharp_Task_3.Models.Dto;

namespace Csharp_Task_3.Repository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> LoginDemo(LoginRequestDTO loginRequestDTO);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO);

    }
}
