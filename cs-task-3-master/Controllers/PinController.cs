using Csharp_Task_3.Data;
using Csharp_Task_3.Models;
using Csharp_Task_3.Models.Dto;
using Csharp_Task_3.Pins;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Text.RegularExpressions;

namespace Csharp_Task_3.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/pins")]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
public class PinController : ControllerBase
{
    protected APIResponse _response;
    private readonly ILogger<PinController> _logger;
    public PinController(ILogger<PinController> logger)
    {
        _logger = logger;
        this._response = new APIResponse();
    }

    [MapToApiVersion("1.0")]
    [HttpGet("{pin}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public ActionResult<APIResponse> Get(string pin)
    {
        _logger.LogInformation("Get one pin ");
        if (pin.Length > 8)
        {
            _logger.LogError("Pin is out of scope. Maximum lenght is 8");
            
            this._response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            this._response.IsSuccess = false;
            this._response.ErrorMessages.Add("Pin is out of scope. Maximum lenght is 8");
            return BadRequest(this._response);
        }
        //input validation
        //we accept only digits
        Regex  regex = new Regex("^[0-9]+$");

        if (regex.IsMatch(pin))
        {
            //prepare DTO object 
            PinDTO pins = new PinDTO();

            PinMatrix pmx = new PinMatrix();
            //calculate all variations
            try
            {
                pins.CalulatedPins = pmx.GetPINs(pin);
            }
            catch (Exception ee)
            {
                _logger.LogError($"GetPINs exception: {ee.Message}" , ee);
                
                this._response.StatusCode = System.Net.HttpStatusCode.NotFound;
                this._response.IsSuccess = false;
                this._response.ErrorMessages.Add($"Cannot find any variations for pin: {pin}" );
                this._response.ErrorMessages.Add(ee.Message);
                return NotFound(this._response);
            }


            if (pins.CalulatedPins != null)
            {
                _logger.LogInformation($"GetPINs finished OK");
                this._response.Result = pins;
                this._response.StatusCode = System.Net.HttpStatusCode.OK;
                this._response.IsSuccess = true;
                return Ok(this._response);
                
            }
            else
            {
                _logger.LogWarning($"GetPINs cannot find any variations for pin: {pin}");
                this._response.StatusCode = System.Net.HttpStatusCode.NotFound;
                this._response.IsSuccess = false;
                this._response.ErrorMessages.Add($"Cannot find any variations for pin: {pin}");
                return NotFound(this._response);
            }
        }
        else
        {
            //input validation failed
            Log.Error($"input validation failed for input: {pin}" );
            this._response.StatusCode = System.Net.HttpStatusCode.NotFound;
            this._response.IsSuccess = false;
            this._response.ErrorMessages.Add($"Input string is not valid. Please use numbers fom 0-9, your pin is: {pin}" );
            return NotFound(this._response);

        }

    }


   

}