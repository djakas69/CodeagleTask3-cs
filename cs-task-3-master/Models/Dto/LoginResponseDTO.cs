namespace Csharp_Task_3.Models.Dto
{
    public class LoginResponseDTO
    {
        public LocalUser User { get; set; }
        public string Token { get; set; }
        public bool IsLogged { get; set; }
    }
}
