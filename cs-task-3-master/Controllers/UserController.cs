using Csharp_Task_3.Models;
using Csharp_Task_3.Models.Dto;
using Csharp_Task_3.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Net.NetworkInformation;

namespace Csharp_Task_3.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/UsersAuth")]

    public class UserController : Controller
    {
        #region PROPERTIES
        private readonly IUserRepository _userRepo;
        private readonly ILogger<PinController> _logger;
        protected APIResponse _response;
        #endregion

        #region CONTROLLER
        public UserController(IConfiguration configuration,ILogger<UserController> logger)
        {
            _userRepo = new UserRepository(configuration, logger);
            _response=new APIResponse();
        }
        #endregion

        #region ENDPOINTS
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            try
            {
                var LoginResponse = await _userRepo.Login(model);
                if (LoginResponse.User == null || string.IsNullOrEmpty(LoginResponse.Token))
                {
                    _logger.LogError($"Login failed, User or Token are null");
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Username or password is incorrect");
                    return BadRequest(_response);
                }
                _logger.LogInformation($"Login status for user {LoginResponse.User} is {LoginResponse.IsLogged}");
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = LoginResponse;
                return Ok(_response);
            }
            catch (Exception ee)
            {

                _logger.LogError($"Login exception {ee.Message}", ee);
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username or password is incorrect");
                return BadRequest(_response);
            }
           
        }

        //[HttpPost("Register")]
        //public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
        //{
        //    bool ifUserNameUnigue = _userRepo.IsUniqueUser(model.UserName);
        //    if(!ifUserNameUnigue)
        //    {
        //        _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
        //        _response.IsSuccess = false;
        //        _response.ErrorMessages.Add("Username already exist");
        //        return BadRequest(_response);
        //    }
        //    var user = await _userRepo.Register(model);
        //    if(user == null)
        //    {
        //        _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
        //        _response.IsSuccess = false;
        //        _response.ErrorMessages.Add("Error while registering");
        //        return BadRequest(_response);
        //    }


        //    _response.StatusCode = System.Net.HttpStatusCode.OK;
        //    _response.IsSuccess = true;
        //    return Ok(_response);

        //}

        #endregion
    }
}
