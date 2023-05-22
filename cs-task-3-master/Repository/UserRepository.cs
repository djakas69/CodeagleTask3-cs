using Csharp_Task_3.Controllers;
using Csharp_Task_3.Data;
using Csharp_Task_3.Models;
using Csharp_Task_3.Models.Dto;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Csharp_Task_3.Helpers;

namespace Csharp_Task_3.Repository
{
    public class UserRepository : IUserRepository
    {
        #region PROPERTIES
        private string secretKey;
        private string demoUser;
        private string demoPwd;
        ApplicationDbContext _db;
        private readonly ILogger<UserController> _logger;
        #endregion

        #region CONSTRUCTOR
        public UserRepository(IConfiguration configuration, ILogger<UserController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            demoUser = configuration.GetValue<string>("ApiSettings:demoUser");
            demoPwd = configuration.GetValue<string>("ApiSettings:demoPwd");
            _db = db;

        }
        #endregion

        #region METHODS
        /// <summary>
        /// for registration purpose
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public bool IsUniqueUser(string UserName)
        {
            //for test only
            //that should be check in database
            //_logger.LogWarning($"For  demo purpose, this method IsUniqueUser will return true only for demo user {demoUser}");
            LocalUser findUser = _db.Users.FirstOrDefault(u => u.Name == UserName);

            if (UserName == demoUser)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Login in database is only for one user for testing
        /// User: darko
        /// Password: 12345
        /// 
        /// </summary>
        /// <param name="loginRequestDTO"></param>
        /// <param name="_db"></param>
        /// <returns></returns>
        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                Token = ""
            };

            try
            {
                //with database option, find the user and check 
                LocalUser findUser = _db.Users.FirstOrDefault(u => u.Name == loginRequestDTO.UserName);

                if (findUser != null)
                {
                    string encPassword = Criptography.GetHashString(loginRequestDTO.Password);
                    if (loginRequestDTO.UserName == findUser.UserName && encPassword == findUser.Password)
                    {
                        //valid user

                        //Generate JWT Token
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var key = Encoding.ASCII.GetBytes(secretKey);

                        SecurityTokenDescriptor tokenDescriptor = Criptography.CreateTokenDesctiptor(secretKey, findUser);

                        var token = tokenHandler.CreateToken(tokenDescriptor);
                        
                        //Response
                        loginResponseDTO = new LoginResponseDTO()
                        {
                            Token = tokenHandler.WriteToken(token),
                            User = findUser,
                            IsLogged = true
                        };


                    }
                }
                else
                {
                    _logger.LogWarning($"Login failed for user {loginRequestDTO.UserName}");
                }
            }
            catch (Exception ee)
            {

                _logger.LogError($"Login exception {ee.Message}", ee);
            }


            return loginResponseDTO;
        }
        public async Task<LoginResponseDTO> LoginDemo(LoginRequestDTO loginRequestDTO)
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

                    SecurityTokenDescriptor tokenDescriptor = Criptography.CreateTokenDesctiptor(secretKey,user);

                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    //Response
                    loginResponseDTO = new LoginResponseDTO()
                    {
                        Token = tokenHandler.WriteToken(token),
                        User = user,
                        IsLogged = true
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
