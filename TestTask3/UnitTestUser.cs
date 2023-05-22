using Castle.Core.Configuration;
using Csharp_Task_3.Controllers;
using Csharp_Task_3.Data;
using Csharp_Task_3.Models;
using Csharp_Task_3.Models.Dto;
using Csharp_Task_3.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Moq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Tests
{
    
    public class UnitTestUser
    {
        private UserRepository userRepository;
        ApplicationDbContext db;
        private DbContextOptions<ApplicationDbContext> _options;
        private IConfigurationRoot _configuration;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true);

            _configuration = builder.Build();

            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseSqlServer(_configuration.GetConnectionString("DeafaultSQLConnection"))
              .Options;

            var mock = new Mock<ILogger<UserController>>();
            ILogger<UserController> logger = mock.Object;

            userRepository = new UserRepository(_configuration, logger);
            
        }

        [Test]
        [TestCase("darko", "12345", true)]
        [TestCase("darko", "123", false)]

        public async Task UserLoginAsync(string UserName, string Password, bool ExpectedStatus)
        {
            LoginRequestDTO model = new LoginRequestDTO();
            model.UserName = UserName;
            model.Password = Password;

            using (var context = new ApplicationDbContext(_options))
            {
                LoginResponseDTO res = await userRepository.Login(model, context);

                if (ExpectedStatus)
                {
                    if (res.IsLogged == true)
                    {
                        Assert.True(true);
                    }
                    else
                    {
                        Assert.False(true);
                    }
                }
                else
                {
                    if (res.IsLogged == false)
                    {
                        Assert.True(true);
                    }
                    else
                    {
                        Assert.False(true);
                    }
                }
            }


                

           
        }
        
        [Test]
        [TestCase("theTokenKeyShouldBeAtLeast128bitLenght","darko", "12345", true)]
        [TestCase("theTokenKey", "darko", "12345", false)]

        public void CreateToken(string secretKey, string UserName, string Password, bool ExpectedStatus)
        {
            try
            {
                LocalUser user = new LocalUser();

                user.Name = UserName;
                user.Password = Password;
                user.Role = "admin";

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
                if(ExpectedStatus)
                {
                    if (token != null)
                    {
                        Assert.True(true);
                    }
                    else
                    {
                        Assert.False(true);
                    }
                }
                else
                {
                    if (token == null)
                    {
                        Assert.True(true);
                    }
                    else
                    {
                        Assert.False(true);
                    }
                }
                
            }
            catch (Exception ee)
            {
                if (!ExpectedStatus)
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.False(true);
                }
                    //Console.WriteLine(ee);
                
            }
        }

    }
}
