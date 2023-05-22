using Csharp_Task_3.Controllers;
using Csharp_Task_3.Models;
using Csharp_Task_3.Models.Dto;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Csharp_Task_3.Repository
{
    public class UserRepository : IUserRepository
    {
        #region PROPERTIES
        private string secretKey;
        private string demoUser;
        private string demoPwd;
        private readonly ILogger<UserController> _logger;
        #endregion

        #region CONSTRUCTOR
        public UserRepository(IConfiguration configuration, ILogger<UserController> logger)
        {
            _logger = logger;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            demoUser = configuration.GetValue<string>("ApiSettings:demoUser");
            demoPwd = configuration.GetValue<string>("ApiSettings:demoPwd");
        }
        #endregion

        #region METHODS
        public bool IsUniqueUser(string UserName)
        {
            //for test only
            //that should be check in database
            _logger.LogWarning($"For  demo purpose, this method IsUniqueUser will return true only for demo user {demoUser}");

            if (UserName == demoUser)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            //with database option, find the user and check 
            //so far we will use only one user for test, darko

            LocalUser user = new LocalUser();
            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                Token = "",
                User = user
            };
            if (loginRequestDTO.UserName == demoUser && loginRequestDTO.Password == demoPwd)
            {
                try
                {
                    //valid user
                    user.Id = 1;
                    user.Name = loginRequestDTO.UserName;
                    user.Password = loginRequestDTO.Password;
                    user.Role = "admin";

                    //Generate JWT Token
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(secretKey);

                    var tokenDescriptor = new SecurityTokenDescriptor()
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, user.Id.ToString()),
                            new Claim(ClaimTypes.Role, user.Role)
                        }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    //Response
                    loginResponseDTO = new LoginResponseDTO()
                    {
                        Token = tokenHandler.WriteToken(token),
                        User = user,
                        IsLogged= true
                    };
                }
                catch (Exception ee)
                {
                    _logger.LogError($"Login exception {ee.Message}", ee);
                }
              
            }

            return loginResponseDTO;
        }

        /// <summary>
        /// Register new user if not exist
        /// This is for future steps
        /// </summary>
        /// <param name="registrationRequestDTO"></param>
        /// <returns></returns>
        public async Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            LocalUser user = new LocalUser()
            {
                UserName = registrationRequestDTO.UserName,
                Name = registrationRequestDTO.Name,
                Password = registrationRequestDTO.Password,
                Role = registrationRequestDTO.Role
            };
            //save to database

            //clean password before return user object
            user.Password = "";
            
            return user;

        }
        #endregion
    }
}
